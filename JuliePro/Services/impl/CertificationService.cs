using JuliePro.Models;
using JuliePro_DataAccess;
using JuliePro_DataModels;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services.impl
{
    public class CertificationService : ServiceBaseEF<Certification>, ICertificationService
    {
        public CertificationService(JulieProDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TrainerCertificationViewModel> GetAllByTrainerAsync(int trainerId)
        {
            var trainer = await _dbContext.Trainers.FindAsync(trainerId);
            var model = await _dbContext.Certifications.Where(x => x.TrainerCertification.Any(y => y.Trainer_Id == trainerId)).ToListAsync();
            return new TrainerCertificationViewModel(trainer, model);
        
        }
    }
}
