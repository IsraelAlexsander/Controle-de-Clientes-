using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle_de_Clientes
{
    public partial class Frm : System.Windows.Forms.Form
    {
        Dados MeusDados;
        Operacoes MinhasOperacoes;

        #region Mover Form

        private bool Mover;
        private int cX, cY;
        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                Mover = true;
            }
        }

        private void pnlTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover)
            {
                this.Left += e.X - (cX - panel1.Left);
                this.Top += e.Y - (cY - panel1.Top);
            }
        }

        private void pnlTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Mover = false;
        }
        #endregion

        #region Mouse Enter/Leave
        public void MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;

            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Cursor = Cursors.Hand;
        }        

        public void MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;

            b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Cursor = Cursors.Default;
        }
        
        #endregion

        public Frm()
        {
            InitializeComponent();

            MeusDados = new Dados();
            MinhasOperacoes = new Operacoes();
        }            

        public void CarregarGrid()
        {
            MinhasOperacoes.CarregarGrid(this, MeusDados);            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.Inserir(this, new Cliente(), MeusDados);
        }

        private void dgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MinhasOperacoes.Alterar(this, new Cliente(), MeusDados);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.Pesquisar(this, MeusDados);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.Excluir(this, MeusDados);
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.Ordenar(this, MeusDados);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.SalvarXML(MeusDados);
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            MinhasOperacoes.CarregarXML(this, MeusDados);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
