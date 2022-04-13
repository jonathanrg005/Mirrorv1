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
    public partial class frmMenuSistema : Form
    {
        public TabControl TabContenedor;
        public frmMenuSistema()
        {
            InitializeComponent();
        }
        public frmMenuSistema(TabControl tabContenedor)
        {
            InitializeComponent();
            TabContenedor = tabContenedor;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistroUsuarios_Click(object sender, EventArgs e)
        {
            frmRegistroUsuarios frm = new frmRegistroUsuarios();
            Main.ClassMetodosPublicos.NewForm(TabContenedor, "Registro de Usuario", frm);
            this.Dispose();
            
        }
    }
}
