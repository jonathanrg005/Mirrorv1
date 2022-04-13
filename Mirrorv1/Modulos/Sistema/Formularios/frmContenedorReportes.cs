
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirrorv1.Modulos.Sistema.Formularios
{
    public partial class frmContenedorReportes : Form
    {
        public frmContenedorReportes()
        {
            InitializeComponent();
        }

        public frmContenedorReportes(CrystalDecisions.CrystalReports.Engine.ReportDocument Reporte, DataTable dt, List<ReportParameter> Parametros)
        {
            InitializeComponent();
            



            //Agregando el datasource al reporte
            Reporte.SetDataSource(dt);

         
            //agregando la lista de parametros al reporte
            foreach (ReportParameter a in Parametros)
            {
              //  Reporte.SetParameterValue(a.Name, /*valor*/);
            }

            this.crystalReportViewer1.ReportSource = Reporte;
            this.crystalReportViewer1.Show();
        }
        public frmContenedorReportes(CrystalDecisions.CrystalReports.Engine.ReportDocument Reporte, DataTable dt, List<SqlParameter> Parametros)
        {
            InitializeComponent();
            string nombre = "";
            string valor = "";



            //Agregando el datasource al reporte
            Reporte.SetDataSource(dt);




            //agregando la lista de parametros al reporte
            foreach (SqlParameter a in Parametros)
            {
                Reporte.SetParameterValue(a.ParameterName, a.Value);
            }



            //foreach (var item in Parametros)
            //{
            //    Type type = item.GetType();
            //    PropertyInfo[] properties = type.GetProperties();

            //    foreach (PropertyInfo property in properties)
            //    {
            //        nombre = property.Name.ToString();
            //        valor = property.GetValue(item).ToString();
            //    }
            //    Reporte.SetParameterValue(nombre, valor);
            //}

            this.crystalReportViewer1.ReportSource = Reporte;
            this.crystalReportViewer1.Show();
            //this.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
