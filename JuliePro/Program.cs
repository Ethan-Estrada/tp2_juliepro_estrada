using JuliePro.Services;
using JuliePro.Services.impl;
using JuliePro_DataAccess;
using Microsoft.AspNetCore.Mvc.Razor;
using JuliePro_DataAccess.DataSeed;
using JuliePro_Utility;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddViewLocalization(); //TODO : ajoutez la bonne configuration
CultureInfo[] supportedCultures = new[]
{
                new CultureInfo("en-US"),
                new CultureInfo("fr-CA")
       };

builder.Services.AddDbContext<JulieProDbContext>(opt => {

    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseLazyLoadingProxies();

});


builder.Services.AddScoped<IJulieProDbContextSeed, JulieProDbContextSeedDev>();

builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBaseEF<>));
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<ICertificationService, CertificationService>();

builder.Services.AddSingleton<IImageFileManager, ImageFileManager>();


// localisation
#region Localizer configuration
builder.Services.AddLocalization(options => options.ResourcesPath = "i18n");

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
                   .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                   .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


#endregion

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope()) {

    var scopeProvider = scope.ServiceProvider;
    try
    {
        var seed = scopeProvider.GetRequiredService<IJulieProDbContextSeed>();
        await seed.SeedAsync();

    }
    catch (Exception ex) {

        app.Logger.LogError(EventCode.ErrorDb, ex, ex.Message);
    }

}


app.Run();
