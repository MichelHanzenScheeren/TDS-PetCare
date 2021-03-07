using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetCare.Domain.ValueObjects;

namespace PetCare.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void ShouldRemoveAllSymbolsOfCpf()
        {
            Document document = new Document("122.134.356-87");
            Assert.AreEqual(document.Cpf, "12213435687");
        }

        [TestMethod]
        public void ShouldBeInvalidWhenCpfHasInsufficientLength()
        {
            Document document = new Document("122.367.85.2");
            Assert.AreEqual(document.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenCpfHasExcessiveLength()
        {
            Document document = new Document("122.367.856.224");
            Assert.AreEqual(document.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenCpfHasLetter()
        {
            Document document = new Document("122.367.85.2A");
            Assert.AreEqual(document.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenCpfIsNull()
        {
            Document document = new Document(null);
            Assert.AreEqual(document.IsValid(), false);
        }

        [TestMethod]
        public void ShouldBeValidWhenCpfIsCorrect()
        {
            Document document = new Document("123.368.987-21");
            Assert.AreEqual(document.IsValid(), true);
        }

        [TestMethod]
        public void ShouldCorrectFormatNumberInGetter()
        {
            Document document = new Document("12235689235");
            Assert.AreEqual(document.GetFormatedCpf(), "122.356.892-35");
        }
    }
}
