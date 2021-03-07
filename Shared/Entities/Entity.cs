using PetCare.Shared.Models;

namespace PetCare.Shared.Entities
{
    public abstract class Entity
    {
        public abstract Model ToModel();
    }
}