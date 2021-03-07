using System;
using System.Linq;
using PetCare.Domain.Models;
using PetCare.Domain.Entities;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Data;
using Microsoft.EntityFrameworkCore;


namespace PetCare.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetCareDataContext _context = new PetCareDataContext();

        public Owner GetById(Guid id)
        {
            return _context.Owners.AsNoTracking()
                .Where(owner => owner.Id.Equals(id)).FirstOrDefault().ToModel();
        }

        public Owner GetByEmail(string email)
        {
            return _context.Owners.AsNoTracking()
                .Where(owner => owner.Email.ToLower().Equals(email.ToLower()))
                .FirstOrDefault()?.ToModel();
        }

        public void Create(Owner owner)
        {
            _context.Owners.Add(owner.ToEntity());
            _saveChanges();
        }

        public void Update(Owner owner)
        {
            _context.Entry<OwnerEntity>(owner.ToEntity()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _saveChanges();
        }

        public void Delete(Owner owner)
        {
            _context.Owners.Remove(owner.ToEntity());
            _saveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private void _saveChanges() => _context.SaveChanges();
    }
}