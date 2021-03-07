using PetCare.Shared.Models;
using PetCare.Domain.ValueObjects;

namespace PetCare.Domain.Models
{
    public class Owner : Model
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Telephone Telephone { get; private set; }
        public Document Document { get; private set; }

        public Owner(Name name, Email email, Telephone telephone, Document document)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
            Document = document;

            AddNotifications(Name);
            AddNotifications(Email);
            AddNotifications(Telephone);
            AddNotifications(Document);
        }
    }
}