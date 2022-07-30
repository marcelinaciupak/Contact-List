using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
using ContactList.Exceptions;
using ContactList.Services.BusinessValidation;
using Moq;

namespace ContactList.Tests
{
    public class ContactValidationServiceTests
    {
        private readonly Mock<IContactRepository> _contactRepository;
        private readonly ContactValidationService _contactValidationService;
        private readonly ContactDto contact;
        private readonly ContactDto contactPhone;
        private readonly ContactDto contactEmail;

        public ContactValidationServiceTests()
        {
            _contactRepository = new Mock<IContactRepository>();
            _contactValidationService = new ContactValidationService(_contactRepository.Object);
            contact = new ContactDto() { FirstName = "test", LastName = "test", Phone = "test123456", Email = "test" };
            contactPhone = new ContactDto() { FirstName = "testp", LastName = "testp", Phone = "test123456", Email = "test" };
            contactEmail = new ContactDto() { FirstName = "test1", LastName = "test1", Phone = "test223456", Email = "test" };
        }

        [Fact]
        public async void ValidateContact_ContactWithNoUniqueFullName_ExceptionShouldBeThrown()
        {
            _contactRepository.Setup(x => x.GetByFullName(contact)).ReturnsAsync(contact);

            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _contactValidationService.ValidateContact(contact));

            Assert.Equal($"Contact {contact.FirstName} {contact.LastName} already exists", exception.Message);
        }

        [Fact]
        public async void ValidateContact_ContactWithUniqueFullName_WithoutException()
        {
            _contactRepository.Setup(x => x.GetByFullName(contact)).ReturnsAsync((ContactDto)null);

            var result = await Record.ExceptionAsync(async() => await _contactValidationService.ValidateContact(contact));

            Assert.Null(result);
        }


        [Fact]
        public async void ValidateContact_ContactWithNoUniquePhone_ExceptionShouldBeThrown()
        {
            _contactRepository.Setup(x => x.GetByPhone(contact.Phone)).ReturnsAsync(contact);

            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _contactValidationService.ValidateContact(contactPhone));

            Assert.Equal($"Contact with phone: {contact.Phone} already exists", exception.Message);
        }

        [Fact]
        public async void ValidateContact_ContactWithUniquePhone_WithoutException()
        {
            _contactRepository.Setup(x => x.GetByPhone(contact.Phone)).ReturnsAsync((ContactDto)null);

            var result = await Record.ExceptionAsync(async () => await _contactValidationService.ValidateContact(contact));

            Assert.Null(result);
        }


        [Fact]
        public async void ValidateContact_ContactWithNoUniqueEmail_ExceptionShouldBeThrown()
        {
            _contactRepository.Setup(x => x.GetByEmail(contact.Email)).ReturnsAsync(contact);

            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _contactValidationService.ValidateContact(contactEmail));

            Assert.Equal($"Contact with email: {contact.Email} already exists", exception.Message);
        }

        [Fact]
        public async void ValidateContact_ContactWithUniqueEmail_WithoutException()
        {
            _contactRepository.Setup(x => x.GetByEmail(contact.Email)).ReturnsAsync((ContactDto)null);

            var result = await Record.ExceptionAsync(async () => await _contactValidationService.ValidateContact(contact));

            Assert.Null(result);
        }
    }
}
