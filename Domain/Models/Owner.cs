using PetCare.Shared.Models;
using PetCare.Domain.ValueObjects;
using System;
using PetCare.Domain.Entities;

namespace PetCare.Domain.Models
{
    public class Owner : Model
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Telephone Telephone { get; private set; }
        public Document Document { get; private set; }

        public Owner(Name name, Email email, Telephone telephone, Document document, Guid? id = null)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
            Document = document;
            Id = id ?? Guid.NewGuid();

            AddNotifications(Name);
            AddNotifications(Email);
            AddNotifications(Telephone);
            AddNotifications(Document);
        }

        public override OwnerEntity ToEntity()
        {
            return new OwnerEntity(Id, Name.FirstName, Name.LastName,
                Email.Address, Telephone.Number, Document.Cpf
            );
        }
    }
}