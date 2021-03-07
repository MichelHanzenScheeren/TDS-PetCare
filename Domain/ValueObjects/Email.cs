using PetCare.Shared.Contracts;
using PetCare.Shared.ValueObjects;

namespace PetCare.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;
            ApplyContracts(address);
        }

        public void SetEmail(string address)
        {
            ApplyContracts(address);
            if (IsValid())
                Address = address;
        }
        private void ApplyContracts(string address)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(address, "Email.Address", "O email não pode ser nulo")
               .IsValidEmail(address, "Email.Address", "O email informado não é valido."));
        }
    }
}
