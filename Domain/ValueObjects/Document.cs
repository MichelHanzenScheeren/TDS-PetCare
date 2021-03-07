using PetCare.Shared.Contracts;
using PetCare.Shared.ValueObjects;

namespace PetCare.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public string Cpf { get; private set; }

        public Document(string cpf)
        {
            cpf = RemoveSymbols(cpf);
            Cpf = cpf;

            ApplyContracts(cpf);
        }
        public string GetFormatedCpf()
        {
            return Cpf.Substring(0, 3) + "."
                + Cpf.Substring(3, 3) + "."
                + Cpf.Substring(6, 3) + "-"
                + Cpf.Substring(9, 2);
        }
        public void SetCpf(string cpf)
        {
            cpf = RemoveSymbols(cpf);
            ApplyContracts(cpf);

            if (IsValid())
                Cpf = cpf;
        }

        private string RemoveSymbols(string cpf)
        {
            return cpf
                ?.Replace(" ", "")
                ?.Replace(".", "")
                ?.Replace("-", "");
        }
        private void ApplyContracts(string cpf)
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(cpf, "Document.Number", "O CPF não pode ser nulo")
               .IsNotEmpty(cpf, "Document.Number", "O CPF não pode ser vazio")
               .IsValidCPF(cpf, "Document.Number", "O CPF não é valido.")
            );
        }
    }
}
