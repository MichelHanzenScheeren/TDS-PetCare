using PetCare.Shared.Notifications;

namespace PetCare.Shared.Contracts
{
    public partial class Contract : Notifiable
    {
        public Contract IsNotNull(string value, string property, string message)
        {
            if (value == null)
                AddNotification(property, message);
            return this;
        }

        public Contract IsNotEmpty(string value, string property, string message)
        {
            if (value?.Trim().Length == 0)
                AddNotification(property, message);
            return this;
        }

        public Contract MinLength(string value, int minLength, string property, string message)
        {
            if (value?.Trim().Length < minLength)
                AddNotification(property, message);
            return this;
        }

        public Contract MaxLength(string value, int maxLength, string property, string message)
        {
            if (value?.Trim().Length > maxLength)
                AddNotification(property, message);
            return this;
        }

        public Contract MinAndMaxLength(string value, int minLength, int maxLength, string property, string message)
        {
            if (value?.Trim().Length < minLength || value?.Trim().Length > maxLength)
                AddNotification(property, message);
            return this;
        }

        public Contract IsValidEmail(string value, string property, string message)
        {
            string regex = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (value != null && !System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                AddNotification(property, message);
            return this;
        }

        public Contract IsValidPhone(string value, string property, string message)
        {
            string regex = "^([0-9]{11})$";
            if (value != null && !System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                AddNotification(property, message);
            return this;
        }

        public Contract IsValidCPF(string value, string property, string message)
        {
            string regex = "^([0-9]{11})$";
            if (value != null && !System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                AddNotification(property, message);
            return this;
        }
    }
}
