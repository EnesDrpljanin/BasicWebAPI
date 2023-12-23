using InterviewTask.Service.Interfaces;
using InterviewTask.Service;

namespace InterviewTask.Api.Modules
{
    public static class RegisteringModule
    {
        public static IServiceCollection RegisterServicesModule(this IServiceCollection services)
        {
            // Service registration
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
