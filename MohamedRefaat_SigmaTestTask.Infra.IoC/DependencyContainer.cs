using Microsoft.Extensions.DependencyInjection;
using MohamedRefaat_SigmaTestTask.API.Data;
using MohamedRefaat_SigmaTestTask.Domain.IRepository;


namespace MohamedRefaat_SigmaTestTask.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
                
            

            //Infra Layer
            services.AddScoped<ICandidateRepository , CandidateRepository>();
            services.AddScoped<CandidateContext>();
           

        }
    }
}
