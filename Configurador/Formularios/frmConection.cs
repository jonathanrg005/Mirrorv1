using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Configurador.Formularios
{
    public partial class frmConection : Form
    {
        public static SqlConnection sqlConnection;
        public string stringConnection;
        public frmConection()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
        }


        //determinar si hay campos vacios
        public Boolean ValidarCampos(string TypeConnection)
        {
            bool exito = true;
            List<TextBox> ListaControles = new List<TextBox> { };

            if (TypeConnection == "Standard")
            {
                ListaControles = new List<TextBox>
                {
                    txtServerSS,
                    txtDataBaseSS,
                    txtUsuarioIDSS,
                    txtPassWordSS
                };

            }
            if (TypeConnection == "Trusted")
            {
                ListaControles = new List<TextBox>
                {
                    txtServerTC,
                    txtDataBaseTC
                };

            }

            foreach (TextBox textbox in ListaControles)
            {
                if (textbox.Text == "")
                {
                    MessageBox.Show("No pueden quedar campos vacios");
                    exito = false;
                    textbox.Focus();
                    break;
                }

            }
            ListaControles.Clear();
            return exito;
        }


        // crea la cadena de conexion dependiendo el tipo de conexion
        public void StringConnection(string TypeConnection)
        {
            

            if(TypeConnection == "Standard")
            {
                stringConnection = @"Server="+ txtServerSS.Text + ";Database=" + txtDataBaseSS.Text + ";User Id=" + txtUsuarioIDSS.Text + ";Password=" + txtPassWordSS.Text + ";";
            }

            if (TypeConnection == "Trusted")
            {
                stringConnection = @"Server=" + txtServerTC.Text + ";Database=" + txtDataBaseTC.Text + ";Trusted_Connection=True;";
            }
            sqlConnection = new SqlConnection(stringConnection);
        
        }

        // probar si la conexiono funciona 
        public static string probarConexion()
        {
            string resultado;
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                resultado = "Correcto";
                sqlConnection.Close();
                return resultado;
            }
            catch (Exception exception)
            {
                resultado = "error" + exception.ToString();
                return resultado;
            }
            
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string TypeConnection = "";

            if (TabStandardSecurity.Focus() == true)
            {
                TypeConnection = "Standard";
            }
            if (TabTrustedConnection.Focus() == true)
            {
                TypeConnection = "Trusted";
            }

            if (ValidarCampos(TypeConnection) == true)
            {
                StringConnection(TypeConnection);
                if (probarConexion() == "Correcto")
                {
                    frmConfiguracion frm = new frmConfiguracion(stringConnection);
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            frmMensajeServidor frm = new frmMensajeServidor();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
