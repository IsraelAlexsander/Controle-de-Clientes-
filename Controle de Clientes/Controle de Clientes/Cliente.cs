using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Controle_de_Clientes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Mail { get; set; }

        public Cliente()
        {
            Nome = "Digite os dados do cliente";
            CPF = "";
            Nascimento = "";
            Telefone = "";
            Endereco = "";
            Mail = "";
        }     
        
        public void LerDados(Frm F)
        {
            Nome = F.dgvClientes.CurrentRow.Cells[0].Value.ToString();
            CPF = F.dgvClientes.CurrentRow.Cells[1].Value.ToString();
            Nascimento = F.dgvClientes.CurrentRow.Cells[2].Value.ToString();
            Telefone = F.dgvClientes.CurrentRow.Cells[3].Value.ToString();
            Endereco = F.dgvClientes.CurrentRow.Cells[4].Value.ToString();
            Mail = F.dgvClientes.CurrentRow.Cells[5].Value.ToString();
        }        
    }
}
