using PetCare.Shared.Contracts;
using PetCare.Shared.ValueObjects;

namespace PetCare.Domain.ValueObjects
{
    public class Telephone : ValueObject
    {
        public string Number { get; private set; }

        public Telephone(string number)
        {
            number = RemoveSymbols(number);
            Number = number;

            ApplyContracts(number);
        }
        public string GetFormatedNumber()
        {
            return "(" + Number.Substring(0, 2) + ")"
                + Number.Substring(2, 5) + "-" + Number.Substring(7, 4);
        }
        public void SetNumber(string number)
        {
            number = RemoveSymbols(number);
            ApplyContracts(number);

            if (IsValid())
                Number = number;
        }

        private string RemoveSymbols(string number)
        {
            return number
                ?.Replace(" ", "")
                ?.Replace("(", "")
                ?.Replace(")", "")
                ?.Replace("-", "");
        }
        private void ApplyContracts(string number)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(number, "Telephone.Number", "O número de telefone não pode ser nulo")
                .IsValidPhone(number, "Telephone.Number", "O número de telefone não é valido.")
            );
        }
    }
}
