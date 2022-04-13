using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Mirrorv1;
using Mirrorv1.Modulos.Sistema.Reportes;
using Microsoft.Reporting.WinForms;

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmRegistroUsuarios : UserControl
    {
        public DataTable dtsp;
        public DataTable dt;
        public DataTable dtDetalle;
        public DataSet ds;
        public int Estado;
        public frmRegistroUsuarios()
        {
            InitializeComponent();
            txtEmpleadoNombre.ReadOnly = true;
            txtUsuarioID.ReadOnly = true;
            btnGuardar.Enabled = false;
        }
        private void Buscar()
        {
            if (lblEstatus.Text != "Buscando")
            {
                Limpiar();
                Habilitar(true);
                dgvDetalle.ReadOnly = true;
                txtUsuarioID.ReadOnly = false;
                lblEstatus.Text = "Buscando";
                dgvDetalle.DataSource = null;
                txtUsuarioID.Focus();
            }
            else {
                if (txtUsuarioID.Text == "" || txtUsuarioID.Text == "0")
                {
                    MessageBox.Show("Completar el campo Usuario ID para la busqueda!");
                }
                else {
                    Cargar(5, Convert.ToInt32(txtUsuarioID.Text));
                }
            }
        }

        private void Habilitar(bool Estado)
        {
            txtUsuarioID.ReadOnly = Estado;
            txtPassWord.ReadOnly = Estado;

            txtEmpleadoID.ReadOnly = Estado;
            txtCuenta.ReadOnly = Estado;
            cbEstado.Enabled = !Estado;
            cbxTipoUsuario.Enabled = !Estado;
            btEmpleado.Enabled = !Estado;
        }

        private void HabilitarBotones(bool Estado)
        {

        }

        private void Limpiar()
        {
            txtCuenta.Clear();
            txtEmpleadoID.Clear();
            txtEmpleadoNombre.Clear();
            txtPassWord.Clear();
            txtUsuarioID.Clear();
            cbEstado.Checked = false;
            cbxTipoUsuario.SelectedIndex = 1;
        }
        private void Nuevo()
        {



            dgvDetalle.ReadOnly = false;
            lblEstatus.Text = "Agregando";
            Limpiar();
            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion","6"),
                new SqlParameter("@UsuarioID","0"),
                new SqlParameter("@UserLogin",""),
                new SqlParameter("@UserPassWord",""),
                new SqlParameter("@TipoCuenta",""),
                new SqlParameter("@EmpleadoID",""),
                new SqlParameter("@Activo","")
            };


            {
                dt = new DataTable();
                dt = Data.ClassData.runDataTable("usp_SisLogin", listSqlParameter, "StoredProcedure");
                dgvDetalle.DataSource = dt;
            }
        }


        private void Cargar(int Opcion, int UsuarioID) {
            //desactivar campos
            Habilitar(true);
            dgvDetalle.ReadOnly = true;
            lblEstatus.Text = "Consultando";
            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",Opcion),
                new SqlParameter("@Tabla","tSisUsuario"),
                new SqlParameter("@Campo","UsuarioID"),
                new SqlParameter("@ID",UsuarioID),
                new SqlParameter("@Where","")

            };

            dt = new DataTable();
            dt = Data.ClassData.runDataTable("usp_SisConsulta", listSqlParameter, "StoredProcedure");


            if (dt.Rows.Count != 0)
            {

                txtUsuarioID.Text = dt.Rows[0]["UsuarioID"].ToString();
                txtCuenta.Text = dt.Rows[0]["UserLogin"].ToString();
                txtEmpleadoID.Text = dt.Rows[0]["EmpleadoID"].ToString();

                txtPassWord.Text = dt.Rows[0]["UserPassWord"].ToString();
                cbEstado.Checked = Convert.ToBoolean(dt.Rows[0]["Activo"].ToString());
                cbxTipoUsuario.SelectedIndex = Convert.ToInt32(dt.Rows[0]["TipoCuentaID"].ToString());

                dt.Clear();
                txtEmpleadoID_Validated(null, null);
                CargarDetalle(4, Convert.ToInt32(txtUsuarioID.Text));
            }
            else {
                MessageBox.Show("No se encontró registro");
            }

        }
        private void CargarDetalle(int Opcion, int UsuarioID)
        {


            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",Opcion),
                new SqlParameter("@Tabla","tSisPermisosFormularios"),
                new SqlParameter("@Campo","UsuarioID"),
                new SqlParameter("@ID",UsuarioID),
                new SqlParameter("@Where","")

            };

            dtDetalle = new DataTable();
            dtDetalle = Data.ClassData.runDataTable("usp_SisConsulta", listSqlParameter, "StoredProcedure");

            dgvDetalle.DataSource = dtDetalle;

            // dtDetalle.Clear();
        }
        private void frmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            Cargar(0, 0);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Cargar(3, Convert.ToInt32(txtUsuarioID.Text));
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Cargar(2, Convert.ToInt32(txtUsuarioID.Text));
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            Cargar(1, 0);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            Cargar(0, 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            btnPrimero.Enabled = false;
            btnNuevo.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnImprimir.Enabled = false;

            btnGuardar.Enabled = false;
            Buscar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            btnPrimero.Enabled = false;
            btnBuscar.Enabled = false;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnImprimir.Enabled = false;

            btnGuardar.Enabled = true;
            Habilitar(false);
            Nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            txtUsuarioID.ReadOnly = true;
            lblEstatus.Text = "Modificando";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbEstado.Checked == true)
            {
                Estado = 1;
            }
            else {
                Estado = 0;
            }

            if (lblEstatus.Text == "Agregando")
            {
                List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",7),
                new SqlParameter("@UsuarioID",""),
                new SqlParameter("@UserLogin",txtCuenta.Text),
                new SqlParameter("@UserPassWord",txtPassWord.Text),
                new SqlParameter("@TipoCuenta",cbxTipoUsuario.SelectedIndex),
                new SqlParameter("@EmpleadoID",txtEmpleadoID.Text),
                new SqlParameter("@Activo",Estado)
            };

                ds = new DataSet();
                ds = Data.ClassData.runDataSet("usp_SisLogin", listSqlParameter, "StoredProcedure");
            }
            else if (lblEstatus.Text == "Agregando") {

            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            List<Control> campos = new List<Control>()
            {
                txtCuenta
            };
            if (Main.ClassMetodosPublicos.validacion(campos) == "Correcto")
            {
                MessageBox.Show("campo comletado");
            }
            else {
                MessageBox.Show("campo vacio");
            }
        }

        private void btEmpleado_Click(object sender, EventArgs e)
        {
            //creo lista de campos por lo que quiero filtrar la busqueda
            List<string> campos = new List<string> {
            "EmpleadoID",
            "Nombre",
            "Documento"
            };

            //invoco el formulario de busqueda enviandole la tabla que quiero consultar, los filtros y el campo que quiero obtener de la busqueda
            frmBuscar frm = new frmBuscar("tEmpEmpleado", campos, "EmpleadoID");
            frm.ShowDialog();

            if (Main.ClassVariablesPublicas.Busqueda == true)
            {
                //igualo el campo al resultado de la busqueda
                txtEmpleadoID.Text = Main.ClassVariablesPublicas.ResultadoBusqueda;
                //invoco el evento validated de ese campo para actualizar la informacion
                txtEmpleadoID_Validated(null, null);

                //limpio las variables publicas para una proxima busqueda
                Main.ClassVariablesPublicas.Busqueda = false;
                Main.ClassVariablesPublicas.ResultadoBusqueda = "";

            }
            else {
                txtEmpleadoID.Text = "";
            }

        }

        private void txtEmpleadoID_Validated(object sender, EventArgs e)
        {
            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion",4),
                new SqlParameter("@Tabla","tEmpEmpleado"),
                new SqlParameter("@Campo","EmpleadoID"),
                new SqlParameter("@ID",txtEmpleadoID.Text),
                new SqlParameter("@Where","")

            };

            dt = new DataTable();
            dt = Data.ClassData.runDataTable("usp_SisConsulta", listSqlParameter, "StoredProcedure");
            txtEmpleadoNombre.Text = dt.Rows[0]["Nombre"].ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;
            btnPrimero.Enabled = true;
            btnBuscar.Enabled = true;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnImprimir.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion","0"),
                new SqlParameter("@UsuarioID","0"),
                new SqlParameter("@UserLogin","0"),
                new SqlParameter("@UserPassWord","0"),
                new SqlParameter("@TipoCuenta","0"),
                new SqlParameter("@EmpleadoID","0"),
                new SqlParameter("@Activo","0")
            };
            dtsp = new DataTable();
            dtsp = Data.ClassData.runDataTable("usp_SisPrueba", Parametros, "StoredProcedure");

            Imprimir();
        }
        private void Imprimir()
        {


            //List<ReportParameter> Parametro = new List<ReportParameter>()
            //{
            //    new ReportParameter("Usuario1","Jonathan")

            //};


            List<SqlParameter> Parametro = new List<SqlParameter>()
            {
                new SqlParameter("Usuario",Main.ClassVariablesPublicas.UsuarioID+"-"+Main.ClassVariablesPublicas.UsuarioNombre),
                new SqlParameter("Empresa",Main.ClassVariablesPublicas.EmpresaNombre),
                new SqlParameter("Sucursal","Sucursal:"+Main.ClassVariablesPublicas.SucursalNombre)
            };


           repSisListaUsuarios  rep = new repSisListaUsuarios();
           frmContenedorReportes cr = new frmContenedorReportes(rep, dtsp, Parametro);
           cr.ShowDialog();
        }

        }
    
    
    
}
