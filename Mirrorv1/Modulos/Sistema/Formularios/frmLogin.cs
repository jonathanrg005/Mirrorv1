using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            /* parametros que necesita el proceso almacenado */
            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@Opcion","0"),
                new SqlParameter("@UsuarioID","0"),
                new SqlParameter("@UserLogin",txtUserName.Text),
                new SqlParameter("@UserPassWord",txtPassWord.Text),
                new SqlParameter("@TipoCuenta","0"),
                new SqlParameter("@EmpleadoID","0"),
                new SqlParameter("@Activo","0")
            };

            /* validar campos vacios */
            List<Control> listaCampos = new List<Control>()
            {
                txtUserName,
                txtPassWord
            };

            string validacion = Main.ClassMetodosPublicos.validacion(listaCampos);
            if (validacion == "Correcto")
            {
                DataTable dt = new DataTable();
                dt = Data.ClassData.runDataTable("usp_SisLogin", listSqlParameter, "StoredProcedure");


                if (dt.Rows.Count != 0)
                {

                    if (dt.Rows[0]["Activo"].ToString() == "True")
                    {
                        if (dt.Rows[0]["UserLogin"].ToString().Trim() == txtUserName.Text && dt.Rows[0]["UserPassWord"].ToString().Trim() == txtPassWord.Text)
                        {
                            Main.ClassVariablesPublicas.UsuarioID = dt.Rows[0]["UsuarioID"].ToString().Trim();
                            Main.ClassVariablesPublicas.EmpleadoID = dt.Rows[0]["EmpleadoID"].ToString().Trim();
                            Main.ClassVariablesPublicas.UsuarioNombre = dt.Rows[0]["UsuarioNombre"].ToString().Trim();
                            Main.ClassVariablesPublicas.TipoCuenta = dt.Rows[0]["TipoCuenta"].ToString().Trim();


                             MessageBox.Show("Bienvenido: " + Main.ClassVariablesPublicas.UsuarioNombre);
                            Main.ClassVariablesPublicas.validacion = true;
                            this.Dispose();
                        }
                        else
                        {
                            Main.ClassVariablesPublicas.validacion = false;
                            MessageBox.Show("Datos Incorrectos");
                        }
                    }
                    else
                    {
                        Main.ClassVariablesPublicas.validacion = false;
                        MessageBox.Show("Usuario no activo");
                    }

                }
                else
                {

                    MessageBox.Show("Datos Incorrectos");
                    Main.ClassVariablesPublicas.validacion = false;
                }


            }
            else
            {
                //MessageBox.Show("Por favor completar el campo: "+validacion);
                MessageBox.Show("Favor completar el campo: " + validacion);
                Main.ClassVariablesPublicas.validacion = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Main.ClassVariablesPublicas.validacion = false;
            this.Dispose();
        }
    }
}

