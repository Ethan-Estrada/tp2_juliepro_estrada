using JuliePro.Models;
using JuliePro_DataModels;

namespace JuliePro.Services
{
    public interface ICertificationService : IServiceBaseAsync<Certification>
    {
        public Task<TrainerCertificationViewModel> GetAllByTrainerAsync(int trainerId);


    }
}
