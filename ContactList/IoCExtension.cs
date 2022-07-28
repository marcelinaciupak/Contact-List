using ContactList.Database.Repositories;
using ContactList.Domain.Models;
using ContactList.Domain.Models.Validators;
using ContactList.Domain.Repositories;
using ContactList.Services;
using ContactList.Services.BusinessValidation;
using FluentValidation;

namespace ContactList
{
    public static class IoCExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactValidationService, ContactValidationService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ContactDto>, ContactDtoValidator>();
        }

    }
}
