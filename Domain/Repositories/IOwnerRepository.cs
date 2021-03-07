using System;
using PetCare.Domain.Models;

namespace PetCare.Domain.Repositories
{
    public interface IOwnerRepository : IDisposable
    {
        Owner GetById(Guid Id);
        Owner GetByEmail(string email);
        void Create(Owner owner);
        void Update(Owner owner);
        void Delete(Guid Id);

    }
}