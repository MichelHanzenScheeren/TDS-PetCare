using PetCare.Shared.Notifications;

namespace PetCare.Shared.Contracts
{
    public partial class Contract : Notifiable
    {
        public Contract Requires() => this;
    }
}
