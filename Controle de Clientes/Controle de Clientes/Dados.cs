using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Controle_de_Clientes
{
    public class Dados
    {
        List<Cliente> Cadastros;

        public Dados()
        {
            Cadastros = new List<Cliente>();
        }                

        public void InserirCliente(Cliente C)
        {                      
            Cadastros.Add(C);
        }

        public void AlterarCliente(Cliente C, int Index)
        {
            Cadastros[Index] = C;
        }

        public bool PesquisarCLiente(Frm F)
        {
            string Palavra = F.txtPesquisa.Text;
            bool Encontrar = false;

            F.txtPesquisa.Text = "";

            for (int i = 0; i < F.dgvClientes.RowCount; i++)
            {
                if (F.dgvClientes.Rows[i].Cells[0].Value.ToString() == Palavra)
                {
                    F.dgvClientes.CurrentCell = F.dgvClientes.Rows[i].Cells[0];
                    Encontrar = true;
                }
            }

            return Encontrar;
        }

        public bool ExcluirCliente(Frm F)
        {
            bool Excluir = false;

            if (Cadastros.Count == 0)
                MessageBox.Show("Sem Clientes para excluir!", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {                
                Cadastros.RemoveAt(F.dgvClientes.CurrentRow.Index);                
                Excluir = true;
            }

            return Excluir;
        }

        public List<Cliente> OrdenarClientes()
        {
            List<Cliente> CadastroOrdenado = new List<Cliente>();
            var ClientesOrdenados = from C in Cadastros
                                    orderby C.Nome
                                    select C;

            foreach (Cliente c in ClientesOrdenados)
            {
                CadastroOrdenado.Add(c);
            }

            return CadastroOrdenado;
        }

        public void Salvar()
        {
            try
            {
                if (Cadastros.Count > 0)
                {
                    TextWriter MeuWriter = new StreamWriter(@".\CadastroClientes.xml");                    
                    XmlSerializer Serializacao = new XmlSerializer(Cadastros.GetType());

                    Serializacao.Serialize(MeuWriter, Cadastros);

                    MessageBox.Show("Arquivo XML Salvo!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MeuWriter.Close();
                }
                else
                {
                    MessageBox.Show("Sem registros para salvar!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void Carregar(Frm F)
        {
            try
            {
                XmlSerializer Serializacao = new XmlSerializer(Cadastros.GetType());
                FileStream Arquivo = new FileStream(@".\CadastroClientes.xml", FileMode.Open);                
                Cadastros.Clear();
                Cadastros = (List<Cliente>)Serializacao.Deserialize(Arquivo);

                MessageBox.Show("Abrindo Arquivo XML!", "Abrir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                F.CarregarGrid();
                Arquivo.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); 
            }
        }

        public List<Cliente> Listar()
        {
            return Cadastros;
        }
    }
}
