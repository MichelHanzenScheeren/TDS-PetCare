using PetCare.Domain.Models;
using PetCare.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class OwnerForm : Form
    {
        public OwnerForm()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            Owner owner = new Owner(
                new Name(tbFirstName.Text, tbLastname.Text),
                new Email(tbEmail.Text),
                new Telephone(tbPhone.Text),
                new Document(tbCpf.Text)
            );

            if(owner.IsValid())
            {
                MessageBox.Show("Dados Corretos!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                string errors = "";
                foreach (var item in owner.Notifications)
                {
                    errors += item.Message + ".\n";
                }
                MessageBox.Show(errors, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
