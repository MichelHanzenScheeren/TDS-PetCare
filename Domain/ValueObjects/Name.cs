using PetCare.Shared.Contracts;
using PetCare.Shared.ValueObjects;

namespace PetCare.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            ApplyFirstNameContracts(FirstName);
            ApplyLastNameNameContracts(LastName);
        }
        public void SetFirstName(string firstName)
        {
            ApplyFirstNameContracts(firstName);
            if (IsValid())
                FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            ApplyLastNameNameContracts(lastName);
            if (IsValid())
                LastName = lastName;
        }

        private void ApplyFirstNameContracts(string firstName)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(firstName, "Name.FirstName", "O primeiro nome não pode ser nulo")
                .IsNotEmpty(firstName, "Name.FirstName", "O primeiro nome não pode ser vazio")
                .MinAndMaxLength(firstName, 3, 40, "Name.FirstName",
                    "O primeiro nome precisa ter entre 3 e 40 caracteres"
                )
            );
        }
        private void ApplyLastNameNameContracts(string lastName)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(lastName, "Name.LastName", "O sobrenome nome não pode ser nulo")
                .IsNotEmpty(lastName, "Name.LastName", "O sobrenome nome não pode ser vazio")
                .MinAndMaxLength(lastName, 5, 60, "Name.LastName",
                    "O sobrenome precisa ter entre 5 e 60 caracteres"
                )
            );
        }
    }
}
