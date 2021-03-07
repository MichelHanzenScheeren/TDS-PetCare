using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetCare.Domain.ValueObjects;

namespace PetCare.Tests.ValueObjects
{
    [TestClass]
    public class NameTest
    {
        [TestMethod]
        public void ShouldBeInvalidWhenFirstNameIsNull()
        {
            Name name = new Name(null, "Silva");
            Assert.AreEqual(name.IsValid(), false);
            Assert.AreEqual(name.Notifications.First().Key, "Name.FirstName");
            Assert.AreEqual(name.Notifications.First().Message, "O primeiro nome não pode ser nulo");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenFirstNameIsEmptyString()
        {
            Name name = new Name("", "Silva");
            Assert.AreEqual(name.IsValid(), false);
            Assert.AreEqual(name.Notifications.First().Key, "Name.FirstName");
            Assert.AreEqual(name.Notifications.First().Message, "O primeiro nome não pode ser vazio");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenFirstNameHasInsufficientLength()
        {
            Name name = new Name("M", "Silva");
            Assert.AreEqual(name.IsValid(), false);
            Assert.AreEqual(name.Notifications.First().Key, "Name.FirstName");
            Assert.AreEqual(name.Notifications.First().Message, "O primeiro nome precisa ter entre 3 e 40 caracteres");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenFirstNameHasExcessiveLength()
        {
            string firstName = "123456789,123456789,123456789,123456789,1";
            Name name = new Name(firstName, "Silva");
            Assert.AreEqual(name.IsValid(), false);
            Assert.AreEqual(name.Notifications.First().Key, "Name.FirstName");
            Assert.AreEqual(name.Notifications.First().Message, "O primeiro nome precisa ter entre 3 e 40 caracteres");
        }

        [TestMethod]
        public void ShouldBeValidWhenNameIsCorrect()
        {
            Name name = new Name("Luis", "Silva");
            Assert.AreEqual(name.IsValid(), true);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenEditWithInvalidFirstName()
        {
            Name name = new Name("Luis", "Silva");
            name.SetFirstName("A");
            Assert.AreEqual(name.IsValid(), false);
            Assert.AreEqual(name.FirstName, "Luis");
        }
    }
}
