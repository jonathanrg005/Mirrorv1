using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data.SqlClient;


namespace Configurador.Formularios
{
    public partial class frmConfiguracion : Form
    {
        public string stringConnection;
        // esta variable determina que accion ejecutara.... 0 registrar pc, 1 registrar o modificar configuracion
        public int accion;
        public frmConfiguracion(string Connection)
        {
            InitializeComponent();
            stringConnection = Connection;

            CargarInformacionPC();
            RevisarComputadora(stringConnection);
            FechaVencimiento("0");
        }



        // Metodo para cargar la informacion de la pc
        public void CargarInformacionPC()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            lblMac.Text = macAddresses;
            lblUsuario.Text = Environment.UserName;
            lblStringConnection.Text = stringConnection;
        }

        // Metodo para revisar si la computadora esta registrada en el sistema
        public void RevisarComputadora(string con)
        {
            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion","0"),
                        new SqlParameter("@ComputadoraID","0"),
                        new SqlParameter("@MAC", lblMac.Text),
                        new SqlParameter("@Usuario", lblUsuario.Text),
                        new SqlParameter("@CajaID","0"),
                        new SqlParameter("@SucursalID", "0"),
                        new SqlParameter("@TipoImpresora", "0"),
                        new SqlParameter("@PuertoImpresora", ""),
                        new SqlParameter("@Estado", "0"),
                        new SqlParameter("@FechaRegistro","")
            };

            DataTable dt = new DataTable();
            dt = Main.ClassMain.runDataTable(con, "usp_SisComputadora", parametro, "StoredProcedure");
            parametro.Clear();


            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show("Esta computadora esta registrada en el sistema, desea empezar el proceso de configuracion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    PanelConfiguracion.Enabled = true;
                    txtCajaID.Text = dt.Rows[0]["CajaID"].ToString();
                    txtSucursalID.Text = dt.Rows[0]["SucursalID"].ToString();
                    cbTipoImpresora.SelectedIndex = Convert.ToInt32(dt.Rows[0]["TipoImpresora"].ToString());
                    txtPuertoImpresora.Text = dt.Rows[0]["PuertoImpresora"].ToString();

                    if (dt.Rows[0]["Estado"].ToString() == "Activa")
                    {
                        chbActiva.Checked = true;
                        lblEstado.Text = "Activa";
                    }
                    else
                    {
                        chbActiva.Checked = false;
                        lblEstado.Text = "Inactiva";
                    }

                    accion = 1;
                }
                else
                {
                    Application.Exit();
                }
            }
            else {
                if (MessageBox.Show("Esta computadora no esta registrada en el sistema, desea empezar el proceso de configuracion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    lblEstado.Text = "Inactiva";
                    PanelConfiguracion.Enabled = false;
                    accion = 0;
                }
                else {
                    Application.Exit();
                }
            }
            dt.Dispose();

        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Metodo para registrar la computadora al sistema con una configuracion por defecto
        public void RegistroComputadora(string con)
        {
            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion","1"),
                        new SqlParameter("@ComputadoraID","0"),
                        new SqlParameter("@MAC", lblMac.Text),
                        new SqlParameter("@Usuario", lblUsuario.Text),
                        new SqlParameter("@CajaID","0"),
                        new SqlParameter("@SucursalID", "0"),
                        new SqlParameter("@TipoImpresora", "0"),
                        new SqlParameter("@PuertoImpresora", "0"),
                        new SqlParameter("@Estado", "Activa"),
                        new SqlParameter("@FechaRegistro","")
            };

            
            Main.ClassMain.runDataTable(con, "usp_SisComputadora", parametro, "StoredProcedure");
        }

        // Metodo para guardar la configuracion de la computadora
        public void ActualizarComputadora(string con)
        {
            string Estado;
            if (chbActiva.Checked == true)
            {
                Estado = "Activa";
            }
            else {
                Estado = "Inactiva";
            }


            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion","2"),
                        new SqlParameter("@ComputadoraID","0"),
                        new SqlParameter("@MAC", lblMac.Text),
                        new SqlParameter("@Usuario", lblUsuario.Text),
                        new SqlParameter("@CajaID",txtCajaID.Text),
                        new SqlParameter("@SucursalID", txtSucursalID.Text),
                        new SqlParameter("@TipoImpresora", cbTipoImpresora.SelectedIndex.ToString()),
                        new SqlParameter("@PuertoImpresora", txtPuertoImpresora.Text),
                        new SqlParameter("@Estado", Estado),
                        new SqlParameter("@FechaRegistro","")
            };

            Main.ClassMain.runDataTable(con, "usp_SisComputadora", parametro, "StoredProcedure");
        }

        // Metodo para cargar la configuracion
        public void LoadConfiguracion(string con)
        {
            PanelConfiguracion.Enabled = true;

            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion","0"),
                        new SqlParameter("@ComputadoraID","0"),
                        new SqlParameter("@MAC", lblMac.Text),
                        new SqlParameter("@Usuario", lblUsuario.Text),
                        new SqlParameter("@CajaID","0"),
                        new SqlParameter("@SucursalID", "0"),
                        new SqlParameter("@TipoImpresora", "0"),
                        new SqlParameter("@PuertoImpresora", ""),
                        new SqlParameter("@Estado", "0"),
                        new SqlParameter("@FechaRegistro","")
            };

            DataTable dt = new DataTable();
            dt = Main.ClassMain.runDataTable(con, "usp_SisComputadora", parametro, "StoredProcedure");
            parametro.Clear();


            if (dt.Rows.Count > 0)
            {
                txtCajaID.Text = dt.Rows[0]["CajaID"].ToString();
                txtSucursalID.Text = dt.Rows[0]["SucursalID"].ToString();
                cbTipoImpresora.SelectedIndex = Convert.ToInt32(dt.Rows[0]["TipoImpresora"].ToString());
                txtPuertoImpresora.Text = dt.Rows[0]["PuertoImpresora"].ToString();

                if (dt.Rows[0]["Estado"].ToString() == "Activa")
                {
                    chbActiva.Checked = true;
                    lblEstado.Text = "Activa";
                }
                else {
                    chbActiva.Checked = false;
                    lblEstado.Text = "Inactiva";
                }

            }
           
            dt.Dispose();
        }

        //metodo para crear nueva fecha de vencimiento y actualizar la misma
        public void FechaVencimiento(string Opcion)
        {
            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion",Opcion),
                        new SqlParameter("@NuevaFechaVencimiento",dtpFechaVencimiento.Text)
            };

            DataTable dt = new DataTable();
            dt = Main.ClassMain.runDataTable(stringConnection, "usp_SisFechaVencimiento", parametro, "StoredProcedure");
            parametro.Clear();


            if (dt.Rows.Count > 0)
            {
                lblDiasRestantes.Text = dt.Rows[0]["DiasRestantes"].ToString();
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que quiere registrar esta pc en la ruta especificada?","Atencion!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
            if (accion == 0)
            {
                RegistroComputadora(stringConnection);
                
            }

            if (accion == 1)
            {
                ActualizarComputadora(stringConnection);
            }

                Main.ClassMain.checkJsonFiles(stringConnection);
                Main.ClassMain.Encriptar();
                LoadConfiguracion(stringConnection);
            }
        }

        private void btnActualizarFecha_Click(object sender, EventArgs e)
        {
            FechaVencimiento("1");
        }
    }
}
