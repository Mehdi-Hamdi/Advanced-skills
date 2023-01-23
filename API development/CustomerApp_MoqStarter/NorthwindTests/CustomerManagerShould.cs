using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using System;
using System.Collections.Generic;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;

        [Test]
        public void BeAbleToBeConstructed()
        {
            //arrange
            var dummyCustomerService = new Mock<ICustomerService>().Object; //this is a dummy customer service
            //act
            _sut = new CustomerManager(dummyCustomerService); //this is a dummy customer manager

            //assert
            Assert.That( _sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValid()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That( result, Is.True );
        }

        [Test]
        public void UpdateCustomer_WhenUpdateIsCalled_WithValidIdAndInputs()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() 
            { 
                CustomerId = "JSMITH",
                ContactName = "John Smith",
                Country = "UK",
                City = "Birmingham",
                PostalCode = "B99 AB3",
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Update("JSMITH", "Jonothan Smith", "UK", "London", originalCustomer.PostalCode);

            Assert.That(originalCustomer.ContactName, Is.EqualTo("Jonothan Smith"));
            Assert.That(originalCustomer.City, Is.EqualTo("London"));
        }

        [Test]

        public void ReturnFalse_WhenUpdateIsCalled_WithInvalidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        [Test]

        public void ReturnTrue_WhenDeleteIsCalled_WithValid()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Delete("JSMITH");
            Assert.That(result, Is.True);

        }

        [Test]
        public void ReturnFalse_WhenDeleteIsCalled_WithInvalid()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Delete("JSMITH");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DeleteCustomer_WhenDeleteIsCalled_WithValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "JSMITH",
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.Delete("JSMITH");

            Assert.That(_sut.SelectedCustomer, Is.EqualTo(null));
         
        }

        [Test]
        public void ReturnFalse_WhenUpdateIsCalled_AndDatabaseExceptionOccurs()
        {
            var mockCustomerservice = new Mock<ICustomerService>();
            mockCustomerservice.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(new Customer() { CustomerId = "JSMITH" });
            mockCustomerservice.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();

            _sut = new CustomerManager(mockCustomerservice.Object);

            var result = _sut.Update("JSMITH", "", "", "", "");

            Assert.That(result, Is.False);
        }

        [Test]
        public void CallSaveCustomerChangesOnce_WhenUpdateIsCalled_ValidId()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() { CustomerId = "JSMITH" };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

           _sut.Update("JSMITH", "", "", "", "");

            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Exactly(1));
            
        }

        [Test]
        public void LetsSeeWhatHappens_WhenUpdateIsCalled_IfAllInvocationsArentSetUp()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Loose);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Update("ROCK", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            // Assert
            Assert.That(result);
        }

        //Moq Lab
        //Set selected customer tests
        [Test]
        public void SelectACustomer_WhenValid()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer();

            _sut.SetSelectedCustomer(customer);

            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
        }

        //Retrieve all tests

        [Test]
        public void ReturnAListOfCustomers_ForAllValidCustomers()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var ListOfCustomers = new List<Customer>() 
            {
                new Customer(),
                new Customer()
            };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(ListOfCustomers);
            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.RetrieveAll();

            Assert.That(result, Is.EqualTo(ListOfCustomers));
        }

        [Test]
        public void ReturnAnEmptyList_WhenCustomersDontExist()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            var ListOfCustomers = new List<Customer>() { };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(ListOfCustomers);
            _sut = new CustomerManager(mockCustomerService.Object);

            var result = _sut.RetrieveAll();

            Assert.That(result, Is.Empty);
        }
    }
}

