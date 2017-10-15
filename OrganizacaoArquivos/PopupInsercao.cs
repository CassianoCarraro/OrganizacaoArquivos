using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OrganizacaoArquivos
{
    public partial class PopupInsercao : Form
    {
        OrganizacaoArquivo oa;

        public PopupInsercao(OrganizacaoArquivo oa)
        {
            InitializeComponent();
            this.oa = oa;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Colaborador colaborador = new Colaborador(Decimal.ToInt32(txtNumero.Value), txtNome.Text, Decimal.ToInt32(txtIdade.Value), Double.Parse(txtSalario.Text));

                oa.inserir(colaborador, "Numero");
                oa.finalizar();

                if (MessageBox.Show("Informações inseridas.", "Inserir", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            } catch (Exception)
            {
                if (MessageBox.Show("Informações no formato incorreto.", "Erro", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void PopupInsercao_FormClosed(object sender, FormClosedEventArgs e)
        {
            oa.finalizar();
        }
    }
}