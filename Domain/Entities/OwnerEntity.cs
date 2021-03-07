using PetCare.Shared.Entities;
using PetCare.Domain.Models;
using PetCare.Domain.ValueObjects;
using System;

namespace PetCare.Domain.Entities
{
    public class OwnerEntity : Entity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Document { get; private set; }

        protected OwnerEntity() { }
        public OwnerEntity(Guid id, string firstName, string lastName, string email, string telephone, string document)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Document = document;
        }

        public override Owner ToModel()
        {
            return new Owner(
                new Name(FirstName, LastName),
                new Email(Email),
                new Telephone(Telephone),
                new Document(Document),
                Id
            );
        }
    }
}