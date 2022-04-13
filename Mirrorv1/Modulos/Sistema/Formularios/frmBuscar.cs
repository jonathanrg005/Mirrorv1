using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmBuscar : Form
    {
        public string Tabla = "";
        public List<string> Campos = null;
        public string StringWhere = "";
        public DataTable dtDetalle = null;
        public string Resultado = "";
        public frmBuscar()
        {
            InitializeComponent();
           
        }



        /*
         este formulario resive:
        1)las tablas que quieres consultar
         2)los campos por lo que quieres filtrar la informacion
          3) el resultado que esperas obtener de la busqueda
         */
        public frmBuscar(string tabla, List<string> listaCampos, string resultado)
        {
            InitializeComponent();
            Campos = listaCampos;
            Tabla = tabla;
            Resultado = resultado;
        }
        
        private void frmBuscar_Load(object sender, EventArgs e)
        {
            
            
            txtBuscar_KeyDown(null, null);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            string Textbox = "%" + txtBuscar.Text + "%";
            int i = 0;
            foreach (string a in Campos)
            {
                if (i == 0)
                {
                    StringWhere = Tabla+" Where " + a + " Like '%" + txtBuscar.Text + "%' ";
                    i = i + 1;
                }
                else
                {
                    StringWhere = StringWhere + " or " + a + " Like '%" + txtBuscar.Text + "%' ";
                }
            }

            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",5),
                new SqlParameter("@Tabla",Tabla),
                new SqlParameter("@Campo",""),
                new SqlParameter("@ID",""),
                new SqlParameter("@Where",StringWhere)
            };

            dtDetalle = new DataTable();
            dtDetalle = Data.ClassData.runDataTable("usp_SisConsulta", listSqlParameter, "StoredProcedure");

            dgvDetalle.DataSource = dtDetalle;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Main.ClassVariablesPublicas.Busqueda = false;
        }

        private void dgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Main.ClassVariablesPublicas.Busqueda = true;
            Main.ClassVariablesPublicas.ResultadoBusqueda = dgvDetalle.CurrentRow.Cells[Resultado].Value.ToString();
            this.Close();
            
        }
    }
}
    

