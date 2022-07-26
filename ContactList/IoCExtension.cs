using ContactList.Database.Repositories;
using ContactList.Domain.Repositories;
using ContactList.Services;

namespace ContactList
{
    public static class IoCExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {

        }

    }
}
