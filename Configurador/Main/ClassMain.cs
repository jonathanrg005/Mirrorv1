using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Configurador.Main
{
    public class AppConfig
    {
        public string StringConnectionSqlServer { get; set; }
        public string StringConnectionMySql { get; set; }

    }
    public class ClassMain
    {
        #region variables
        public static string stringBaseDirectory = baseDirectory();
        public static string stringJsonFileDirectory = @"Json\AppConfig.Json";
        public static string stringPathJsonFiles;
        public static string Key = "StringCN";
        #endregion variables

        #region determina y devuelve la carpeta base de la aplicacion en un string
        public static string baseDirectory()
        {
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
        #endregion determina y devuelve la carpeta base de la aplicacion en un string

        public static string checkJsonFiles(string con)
        {
            try
            {

                if (File.Exists(baseDirectory() + stringJsonFileDirectory) == false)
                {
                    createJsonFile(con);
                    return "Correcto";
                }
                else
                {
                    System.IO.File.Delete(baseDirectory() + stringJsonFileDirectory);
                    createJsonFile(con);
                    return "Correcto";
                }

            }
            catch (Exception exception)
            {
                return "error" + exception.ToString();
            }


        }

        #region creacion del archivo Json
        // este metodo crea el archivo json con los atrubutos de la clase AppConfig
        public static void createJsonFile(string con)
        {

            AppConfig appConfig = new AppConfig();
            appConfig.StringConnectionSqlServer = con;
            appConfig.StringConnectionMySql = "N/A";

            string pathJson = stringBaseDirectory + stringJsonFileDirectory;

            using (StreamWriter file = File.CreateText(pathJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, appConfig);
            }
        }
        #endregion creacion del archivo Json

        #region leer el archivo json
        //este metodo sirve para leer un atributo en especifico del archivo json
        public static string readJsonFile(string Atributo)
        {
            string pathJson = stringBaseDirectory + stringJsonFileDirectory;

            StreamReader sr = new StreamReader(pathJson);
            String json = sr.ReadToEnd();

            dynamic appConfig = JsonConvert.DeserializeObject(json);

            string Conexion = appConfig[Atributo].ToString();

            return Conexion;


        }
        #endregion leer el archivo json


        public static void Encriptar() 
        {
            string FilePath = baseDirectory() + stringJsonFileDirectory;
            
            byte[] plainContent = File.ReadAllBytes(FilePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(Key);
                DES.Key = Encoding.UTF8.GetBytes(Key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(),CryptoStreamMode.Write);

                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(FilePath, memStream.ToArray());
                }
            }

        }

        public static void Desencriptar()
        {
            string FilePath = baseDirectory() + stringJsonFileDirectory;

            byte[] encrypted = File.ReadAllBytes(FilePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(Key);
                DES.Key = Encoding.UTF8.GetBytes(Key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Write);

                    cryptoStream.Write(encrypted, 0, encrypted.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(FilePath, memStream.ToArray());
                }
            }
        }



        public static DataTable runDataTable(string StringConnection, string NameStoredProcedure, List<SqlParameter> listParameter = null, string stringParameterCommandType = "CommandText")
        {
            SqlConnection con = new SqlConnection(StringConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            // creando el datatable
            DataTable dataTable = new DataTable();

            try
            {
                //abrir la conexion si esta cerrada.
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                // creando el data adapter


                sqlDataAdapter.SelectCommand = new SqlCommand(NameStoredProcedure, con);
                sqlDataAdapter.SelectCommand.CommandType = stringParameterCommandType == "CommandText" ? CommandType.Text : CommandType.StoredProcedure;

                if (listParameter != null)
                {
                    foreach (SqlParameter sqlParameter in listParameter)
                    {
                        sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
               // Main.ClassVariablesPublicas.CreacionDataTable = "error" + exception.ToString();
                // throw new ArgumentNullException(exception.Message);
            }
            finally
            {
                sqlDataAdapter.Dispose();
                con.Close();
            }
            return dataTable;
        }








    }
}
