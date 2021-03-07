using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetCare.Domain.ValueObjects;

namespace PetCare.Tests.ValueObjects
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void ShouldBeInvalidWhenAddressIsNull()
        {
            Email email = new Email(null);
            Assert.AreEqual(email.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenAddressIsInvalid()
        {
            Email email = new Email("adsfads@fdsfdsf");
            Assert.AreEqual(email.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeValidWhenAddressIsCorrect()
        {
            Email email = new Email("michel@gmail.com");
            Assert.AreEqual(email.IsValid(), true);
        }
    }
}
