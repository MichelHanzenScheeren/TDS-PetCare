using PetCare.Shared.Notifications;
using PetCare.Shared.Entities;

namespace PetCare.Shared.Models
{
    public abstract class Model : Notifiable
    {
        public abstract Entity ToEntity();
    }
}
