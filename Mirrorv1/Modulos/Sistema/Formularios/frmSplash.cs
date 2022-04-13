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

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmSplash : Form
    {
        public int porciento = 0;
        

        public string Estado;
        public frmSplash()
        {
            InitializeComponent();

            Main.ClassVariablesPublicas.validacion = true;

            lblProceso.Text = "inicio.";
            lblProgreso.Text = "%" + pgbProceso.Value.ToString();
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pgbProceso.Value <= 10)
            {
                this.Opacity = pgbProceso.Value * 0.10;
            }
            
            if (pgbProceso.Value == 30)
            {
                Proceso1();
            }

            if (pgbProceso.Value == 60)
            {
                Proceso2();
            }

            if (pgbProceso.Value == 90)
            {
                Proceso3();
            }
          
            if (pgbProceso.Value < 100)
            {
                lblProgreso.Text = "%" + pgbProceso.Value.ToString();
                pgbProceso.Value = pgbProceso.Value + 1;
                
            }
            if (pgbProceso.Value == 100 && Main.ClassVariablesPublicas.validacion == true)
            {
               // this.Close();
                this.Dispose();
            }
            
        }


        private void Proceso1()
        {
           
            Estado = Aplication.ClassAplication.VerificarArchivoJson(); //Aplication.ClassAplication.checkJsonFiles();
            if (Estado == "Correcto")
            {
                lblProceso.Text = "Cargando Complementos.";
            }
            else
            {
                lblProgreso.ForeColor = Color.Red;
                lblProceso.ForeColor = Color.Red;
                lblProgreso.Text = "%" + pgbProceso.Value.ToString();
                lblProceso.Text = Estado;
                Main.ClassVariablesPublicas.validacion = false;
                timer1.Stop();
                MessageBox.Show(Estado);
                pgbProceso.Value = 100;
                
            }

        }
        private void Proceso2()
        {

            /* proceso para crear probar la conexion con la bd*/
            Aplication.ClassAplication.Desencriptar();
            Estado = Data.ClassData.probarConexion();
            Aplication.ClassAplication.Encriptar();
            if (Estado == "Correcto")
            {

                lblProceso.Text = "Probando Conexión.";
            }
            else
            {
                lblProgreso.ForeColor = Color.Red;
                lblProceso.ForeColor = Color.Red;
                lblProgreso.Text = "%" + pgbProceso.Value.ToString();
                lblProceso.Text = "Conexión Fallida.";
                Main.ClassVariablesPublicas.validacion = false;
                timer1.Stop();
                MessageBox.Show(Estado);
                pgbProceso.Value = 100;
                
            }

            

        }


        private void Proceso3()
        {
            string UsuarioWindiows = Environment.UserName;
            string Mac = Main.ClassMetodosPublicos.GetMacAddress();
            List<SqlParameter> parametro = new List<SqlParameter>
            {
                        new SqlParameter("@Opcion","0"),
                        new SqlParameter("@ComputadoraID","0"),
                        new SqlParameter("@MAC", Mac),
                        new SqlParameter("@Usuario", UsuarioWindiows),
                        new SqlParameter("@CajaID","0"),
                        new SqlParameter("@SucursalID", "0"),
                        new SqlParameter("@TipoImpresora", "0"),
                        new SqlParameter("@PuertoImpresora", ""),
                        new SqlParameter("@Estado", "0"),
                        new SqlParameter("@FechaRegistro","")
            };

            DataTable dt = new DataTable();
            dt = Data.ClassData.runDataTable("usp_SisComputadora", parametro, "StoredProcedure");
            parametro.Clear();


            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Estado"].ToString() == "Activa")
                {


                    Main.ClassVariablesPublicas.CajaID = dt.Rows[0]["CajaID"].ToString();
                    Main.ClassVariablesPublicas.TipoImpresora = dt.Rows[0]["TipoImpresora"].ToString();
                    Main.ClassVariablesPublicas.PuertoImpresora = dt.Rows[0]["PuertoImpresora"].ToString();
                    Main.ClassVariablesPublicas.SucursalID = dt.Rows[0]["SucursalID"].ToString();
                    Main.ClassVariablesPublicas.SucursalNombre = dt.Rows[0]["SucursalNombre"].ToString();
                    Main.ClassVariablesPublicas.SucursalDireccion = dt.Rows[0]["SucursalDireccion"].ToString();
                    Main.ClassVariablesPublicas.Telefono1 = dt.Rows[0]["Telefono1"].ToString();
                    Main.ClassVariablesPublicas.Telefono2 = dt.Rows[0]["Telefono2"].ToString();
                    Main.ClassVariablesPublicas.Correo = dt.Rows[0]["Correo"].ToString();
                    Main.ClassVariablesPublicas.EmpresaID = dt.Rows[0]["EmpresaID"].ToString();
                    Main.ClassVariablesPublicas.EmpresaNombre = dt.Rows[0]["EmpresaNombre"].ToString();
                    Main.ClassVariablesPublicas.RNC = dt.Rows[0]["RNC"].ToString();
                    Main.ClassVariablesPublicas.Logo = dt.Rows[0]["Logo"].ToString();


                    lblProceso.Text = "Preparando sistemas.";
                    Main.ClassMetodosPublicos.ListForm2();
                }
                else {
                    lblProgreso.ForeColor = Color.Red;
                    lblProceso.ForeColor = Color.Red;
                    lblProgreso.Text = "%" + pgbProceso.Value.ToString();
                    lblProceso.Text = "Equipo no activo";
                    Main.ClassVariablesPublicas.validacion = false;
                    timer1.Stop();
                    MessageBox.Show("Este equipo no esta certificado, favor de comunicarse con soporte tecnico");
                    pgbProceso.Value = 100;
                }

                
            }
            else
            {
                lblProgreso.ForeColor = Color.Red;
                lblProceso.ForeColor = Color.Red;
                lblProgreso.Text = "%" + pgbProceso.Value.ToString();
                lblProceso.Text = "Equipo no certificado";
                Main.ClassVariablesPublicas.validacion = false;
                timer1.Stop();
                MessageBox.Show("Este equipo no esta certificado, favor de comunicarse con soporte tecnico");
                pgbProceso.Value = 100;

            }

        }

    

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Main.ClassVariablesPublicas.validacion = false;
            this.Dispose();
            
        }


    }
}


