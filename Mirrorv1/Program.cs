using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirror_v1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Mirrorv1.Modulos.Sistema.Formularios.frmSplash());

            if (Mirrorv1.Main.ClassVariablesPublicas.validacion == true)
            {
                Application.Run(new Mirrorv1.Modulos.Sistema.Formularios.frmLogin());
            }
            if (Mirrorv1.Main.ClassVariablesPublicas.validacion == true)
            {
                Application.Run(new Mirrorv1.Modulos.Sistema.Formularios.frmMenu());
            }
        }
    }
}
