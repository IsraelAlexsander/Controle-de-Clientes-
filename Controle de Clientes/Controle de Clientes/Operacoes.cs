using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Clientes
{
    public class Operacoes
    {
        public void CarregarGrid(Frm F, Dados D)
        {
            List<Cliente> Cadastros = D.Listar();

            F.dgvClientes.DataSource = null;
            F.dgvClientes.DataSource = Cadastros;
            F.dgvClientes.ClearSelection();
        }
        public void CarregarGrid(Frm F, List<Cliente> C)
        {
            List<Cliente> Cadastros = C;

            F.dgvClientes.DataSource = null;
            F.dgvClientes.DataSource = Cadastros;
            F.dgvClientes.ClearSelection();
        }
        public void Inserir(Frm F, Cliente C, Dados D)
        {
            D.InserirCliente(C);

            F.CarregarGrid();

            F.dgvClientes.CurrentCell = F.dgvClientes.Rows[F.dgvClientes.RowCount - 1].Cells[0];
        }

        public void Alterar(Frm F, Cliente C, Dados D)
        {
            C.LerDados(F);
            D.AlterarCliente(C, F.dgvClientes.CurrentRow.Index);
        }

        public void Pesquisar(Frm F, Dados D)
        {
            bool encontrar = D.PesquisarCLiente(F);

            if (!encontrar)
                MessageBox.Show("Cliente não encontrado!", "Pesquisar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Excluir(Frm F, Dados D)
        {
            bool Excluir = D.ExcluirCliente(F);

            if (Excluir)
                F.CarregarGrid();
        }

        public void Ordenar(Frm F, Dados D)
        {
            List<Cliente> Cadastro = D.OrdenarClientes();
            if(Cadastro.Count > 1)
            {
                CarregarGrid(F, Cadastro);
                MessageBox.Show("Cadastros ordenados!", "Ordenar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não é possível ordenar!", "Ordenar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SalvarXML(Dados D)
        {
            D.Salvar();
        }

        public void CarregarXML(Frm F, Dados D)
        {
            D.Carregar(F);
        }
    }
}
