using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.IO;

namespace Mirrorv1.Main
{
    public class ClassMetodosPublicos
    {
        /*metodo para obtener la ruta del sistema*/
        public static string BaseDirectory()
        {
            string stringBaseDirectory = "";

            if (AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin") > 0)
            {
                stringBaseDirectory = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            }
            else
            {
                stringBaseDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
            return stringBaseDirectory;

        }

        /*metodo para verificar si existe un archivo*/
        public static bool CheckFile(string NameFile)
        {
            try
            {

                if (File.Exists(BaseDirectory() + NameFile))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exception)
            {
                return false;
            }


        }


        /*metodo para validar campos*/
        public static string validacion(List<Control> listaObjetos)
        {
            string resultado = "Correcto";

            foreach (Control control in listaObjetos)
            {

                if (control is TextBox)
                {
                    TextBox textbox = control as TextBox;
                    if (textbox.Text != "")
                    {
                        resultado = "Correcto";
                    }
                    else
                    {
                        resultado = textbox.Name;
                        break;
                    }
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked == true)
                    {
                        resultado = "Correcto";
                    }
                    else
                    {
                        resultado = checkBox.Name;
                        break;
                    }
                }

            }
            return resultado;
        }


        /*metodo para crear un tab para el menu y asignarle un UserControl*/
        public static void NewForm(TabControl Contenedor, string Texto, UserControl NuevoFormulario)
        {
            if (Main.ClassVariablesPublicas.TabPageAbierto <= 14)
            {
                Main.ClassVariablesPublicas.TabPageAbierto = Main.ClassVariablesPublicas.TabPageAbierto + 1;
                TabPage NuevaPagina = new TabPage(Texto);
                NuevaPagina.Controls.Add(NuevoFormulario);
                Contenedor.TabPages.Add(NuevaPagina);
                Contenedor.SelectTab(NuevaPagina);
            }
            else
            {
                MessageBox.Show("tiene demaciadas ventanas abiertas");
            }
        }


        /*metodo para crear la lista de formularios del sistema*/
        public static DataTable ListForm()
        {
            System.Reflection.Assembly assembly;
            assembly = System.Reflection.Assembly.GetExecutingAssembly();

            DataTable lista = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NameSpace";
            lista.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FullName";
            lista.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            lista.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Text";
            lista.Columns.Add(column);

            foreach (Type t in assembly.GetTypes())
            {

                var nombreTipo = t.BaseType.Name;
                var instancia = assembly.CreateInstance(t.Name);
                Control control;


                if (nombreTipo.ToLower().Contains("usercontrol") || nombreTipo.ToLower().Contains("form"))
                {

                    control = Activator.CreateInstance(t) as Control;
                    if (control is Form)
                    {
                        Form frm = control as Form;

                        row = lista.NewRow();
                        row["NameSpace"] = t.Namespace.Replace("Mirrorv1.Modulos.", string.Empty).Replace(".Formularios", string.Empty);
                        // row["NameSpace"] = t.Namespace;
                        row["FullName"] = t.FullName;
                        row["Name"] = t.Name;
                        row["Text"] = control.Text;
                        lista.Rows.Add(row);

                    }
                    else
                    {
                        UserControl frm = control as UserControl;

                        row = lista.NewRow();
                        row["NameSpace"] = t.Namespace.Replace("Mirrorv1.Modulos.", string.Empty).Replace(".Formularios", string.Empty);
                        //row["NameSpace"] = t.Namespace;
                        row["FullName"] = t.FullName;
                        row["Name"] = t.Name;
                        row["Text"] = control.Tag.ToString();
                        lista.Rows.Add(row);
                    }


                    control.Dispose();

                }

            }

            return lista;

        }


        /*metodo para crear la lista de formularios del sistema*/
        public static void ListForm2()
        {
            System.Reflection.Assembly assembly;
            assembly = System.Reflection.Assembly.GetExecutingAssembly();



            foreach (Type t in assembly.GetTypes())
            {

                var nombreTipo = t.BaseType.Name;
                var instancia = assembly.CreateInstance(t.Name);
                string text;
                Control control;


                if (nombreTipo.ToLower().Contains("usercontrol") || nombreTipo.ToLower().Contains("form"))
                {

                    control = Activator.CreateInstance(t) as Control;
                    if (control is Form)
                    {
                        Form frm = control as Form;
                        text = control.Text;
                    }
                    else
                    {
                        UserControl frm = control as UserControl;
                        text = control.Tag.ToString();
                    }

                    List<SqlParameter> listSqlParameters = new List<SqlParameter>()
                    {
                        new SqlParameter("@Opcion","0"),
                        new SqlParameter("@NameSpace",t.FullName.ToString()),
                        new SqlParameter("@Nombre", t.Name.ToString()),
                        new SqlParameter("@Modulo", t.Namespace.Replace("Mirrorv1.Modulos.", string.Empty).Replace(".Formularios", string.Empty).ToString()),
                        new SqlParameter("@Text", text.ToString()),
                        new SqlParameter("@UsuarioID","0")
                    };

                    Data.ClassData.runDataTable2("usp_SisPermisos", listSqlParameters, "StoredProcedure");
                    listSqlParameters.Clear();
                    control.Dispose();

                }

            }


        }



        /* metodo para verificar los permisos de los modulos*/
        public static bool PermisosMetodos(string Modulo)
        {
            bool validar = false;
            List<SqlParameter> listSqlParameters = new List<SqlParameter>()
            {
                        new SqlParameter("@Opcion","1"),
                        new SqlParameter("@NameSpace",""),
                        new SqlParameter("@Nombre", ""),
                        new SqlParameter("@Modulo", Modulo),
                        new SqlParameter("@Text", ""),
                        new SqlParameter("@UsuarioID",Main.ClassVariablesPublicas.UsuarioID.ToString())
            };

            DataTable dt = new DataTable();
            dt = Data.ClassData.runDataTable("usp_SisPermisos", listSqlParameters, "StoredProcedure");
            if (dt.Rows.Count > 0)
            {
                validar = true;
            }
            return validar;
        }


        /*metodo para verificar los permisos de los formularios*/
        public static bool PermisosFormularios(Control control)
        {
            
            var t = control.GetType();
            
            List<SqlParameter> listSqlParameters = new List<SqlParameter>()
            {
                        new SqlParameter("@Opcion","2"),
                        new SqlParameter("@NameSpace",t.FullName.ToString()),
                        new SqlParameter("@Nombre", ""),
                        new SqlParameter("@Modulo", ""),
                        new SqlParameter("@Text", ""),
                        new SqlParameter("@UsuarioID",Main.ClassVariablesPublicas.UsuarioID.ToString())
            };

            DataTable dt = new DataTable();
            dt = Data.ClassData.runDataTable("usp_SisPermisos", listSqlParameters, "StoredProcedure");

            if (dt.Rows[0]["Ver"].ToString() == "True")
            {
                return true;
            }
            else
            {
                //OJO
                //Modulos.Sistema.Formularios.frmSesion frm = new Modulos.Sistema.Formularios.frmSesion();
                //frm.Show();
                //return false;
            }
            //puse este return para qu eno de error

            return true;
        }

        /*mostrar sub menu*/
        public static void MostrarSubMenu(string Modulo, Form frm, Panel PanelContenedor)
        {
            if (PermisosMetodos(Modulo) == true)
            {
                
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para usar el modulo de Clientes");
            }

        }

        /*obtener la direccion mac*/
        public static string GetMacAddress()
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

            return macAddresses;
        }

        /*crear reporte con 1 tabla de datos*/
        public static void CreateReport(CrystalDecisions.CrystalReports.Engine.ReportDocument Reporte, DataSet ds)
        { 
        
        }


    }



}
