using ContactList.Domain.Models;
using ContactList.Domain.Repositories;
using ContactList.Exceptions;
using ContactList.Services;
using ContactList.Services.BusinessValidation;
using Moq;
using Xunit;

namespace ContactList.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _contactRepositoryMock;
        private readonly Mock<IContactValidationService> _contactValidationServiceMock;
        private readonly ContactService _contactService;
        private readonly ContactDto contact;

        public ContactServiceTests()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _contactValidationServiceMock = new Mock<IContactValidationService>();
            _contactService = new ContactService(_contactRepositoryMock.Object, _contactValidationServiceMock.Object);
            contact = new ContactDto();
        }

        [Fact]
        public async void CreateAsync_CallingOrder_ValidationBeforeRepository()
        {
            var sequence = new MockSequence();

            _contactValidationServiceMock.InSequence(sequence).Setup(x => x.ValidateContact(It.IsAny<ContactDto>())).Verifiable();
            _contactRepositoryMock.InSequence(sequence).Setup(x => x.CreateAsync(It.IsAny<ContactDto>())).ReturnsAsync(contact);

            _contactService.CreateAsync(contact);
        }

        [Fact]
        public async void CreateAsync_ValidContac_CreateInRepositoryWasCalled()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Verifiable();
            _contactRepositoryMock.Setup(x => x.CreateAsync(contact)).ReturnsAsync(contact);

            _contactService.CreateAsync(contact);

            _contactRepositoryMock.Verify(x => x.CreateAsync(contact), Times.Once);
        }

        [Fact]
        public async void CreateAsync_InValidContact_CreateInRepositoryWasNotCalled()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Throws(new BusinessException(""));
            _contactRepositoryMock.Setup(x => x.CreateAsync(contact)).ReturnsAsync(contact);

            try
            {
                _contactService.CreateAsync(contact);
            }
            catch
            {
            }

            _contactRepositoryMock.Verify(x => x.CreateAsync(contact), Times.Never);
        }

        [Fact]
        public async void GetByIdAsync_ContactNotExists_ExceptionShouldBeThrown()
        {
            _contactRepositoryMock.Setup(x => x.GetByIdAsync(contact.Id)).ReturnsAsync((ContactDto)null);

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _contactService.GetByIdAsync(contact.Id));

            Assert.Equal("Contact not found", exception.Message);

        }

        [Fact]
        public async void GetByIdAsync_ContactExists_WithoutException()
        {
            _contactRepositoryMock.Setup(x => x.GetByIdAsync(contact.Id)).ReturnsAsync(contact);

            var result = await _contactService.GetByIdAsync(contact.Id);

            Assert.Equal(contact, result);
        }

        [Fact]
        public async void UpdateAsync_CallingOrder_ValidationBeforeRepository()
        {
            var sequence = new MockSequence();

            _contactValidationServiceMock.InSequence(sequence).Setup(x => x.ValidateContact(It.IsAny<ContactDto>())).Verifiable();
            _contactRepositoryMock.InSequence(sequence).Setup(x => x.UpdateAsync(It.IsAny<ContactDto>())).ReturnsAsync(contact);

            _contactService.UpdateAsync(contact);
        }

        [Fact]
        public async void UpdateAsync_ValidContact_UpdateInRepositoryWasCalled()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Verifiable();
            _contactRepositoryMock.Setup(x => x.UpdateAsync(contact)).ReturnsAsync(contact);

            _contactService.UpdateAsync(contact);

            _contactRepositoryMock.Verify(x => x.UpdateAsync(contact), Times.Once);
        }

        [Fact]
        public async void UpdateAsync_InValidContact_UpdateInRepositoryWasNotCalled()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Throws(new BusinessException(""));
            _contactRepositoryMock.Setup(x => x.UpdateAsync(contact)).ReturnsAsync(contact);

            try
            {
                _contactService.UpdateAsync(contact);
            }
            catch
            {
            }

            _contactRepositoryMock.Verify(x => x.UpdateAsync(contact), Times.Never);
        }

        [Fact]
        public async void UpdateAsync_ContactNotExists_ExceptionShouldBeThrown()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Verifiable();
            _contactRepositoryMock.Setup(x => x.UpdateAsync(contact)).ReturnsAsync((ContactDto)null);
            
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _contactService.UpdateAsync(contact));

            Assert.Equal("Contact not found", exception.Message);
        }

        [Fact]
        public async void UpdateAsync_ContactExists_WithoutException()
        {
            _contactValidationServiceMock.Setup(x => x.ValidateContact(contact)).Verifiable();
            _contactRepositoryMock.Setup(x => x.UpdateAsync(contact)).ReturnsAsync(contact);

            var result = await _contactService.UpdateAsync(contact);

            Assert.Equal(contact, result);
        }

        [Fact]
        public async void RemoveAsync_ContactNotExists_ExceptionShouldBeThrown()
        {
            _contactRepositoryMock.Setup(x => x.RemoveAsync(contact.Id)).ReturnsAsync((ContactDto)null);

            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _contactService.RemoveAsync(contact.Id));

            Assert.Equal("Contact not found", exception.Message);
        }

        [Fact]
        public async void RemoveAsync_ContactExists_WithoutException()
        {
            _contactRepositoryMock.Setup(x => x.RemoveAsync(contact.Id)).ReturnsAsync(contact);

            var result = await _contactService.RemoveAsync(contact.Id);
            Assert.Equal(contact, result);
        }
    }
}