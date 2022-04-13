using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes.Formularios.frmMenuClientes frm = new Clientes.Formularios.frmMenuClientes();
            Main.ClassMetodosPublicos.MostrarSubMenu("Clientes", frm, PanelContenedor);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmMenuSistema frm = new frmMenuSistema(this.TabContenedor);
            Main.ClassMetodosPublicos.MostrarSubMenu("Sistema", frm, PanelContenedor);
        }
    }
}
