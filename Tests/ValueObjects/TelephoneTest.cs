using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetCare.Domain.ValueObjects;

namespace PetCare.Tests.ValueObjects
{
    [TestClass]
    public class TelephoneTest
    {
        [TestMethod]
        public void ShouldRemoveAllSymbolsOfNumber()
        {
            Telephone phone = new Telephone("(45) 91234-5678");
            Assert.AreEqual(phone.Number, "45912345678");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenNumberHasInsufficientLength()
        {
            Telephone phone = new Telephone("(45) 91234-567");
            Assert.AreEqual(phone.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenNumberHasExcessiveLength()
        {
            Telephone phone = new Telephone("(45) 91234-56789");
            Assert.AreEqual(phone.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenNumberHasLetter()
        {
            Telephone phone = new Telephone("(45) 9A234-5678");
            Assert.AreEqual(phone.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenNumberIsNull()
        {
            Telephone phone = new Telephone(null);
            Assert.AreEqual(phone.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeValidWhenNumberIsCorrect()
        {
            Telephone phone = new Telephone("45912345678");
            Assert.AreEqual(phone.IsValid(), true);
        }

        [TestMethod]
        public void ShouldCorrectFormatNumberInGetter()
        {
            Telephone phone = new Telephone("45912345678");
            Assert.AreEqual(phone.GetFormatedNumber(), "(45)91234-5678");
        }
    }
}
