using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Mirrorv1.Aplication
{
    //clase de las cadena de conexiones de la base de datos
    public class AppConfig
    {
        public string StringConnectionSqlServer { get; set; }
        public string StringConnectionMySql { get; set; }

    }
    class ClassAplication
    {
        // NEXT*******************************************
        #region variables
        public static string stringBaseDirectory = baseDirectory();
        public static string stringJsonFileDirectory = @"Json\AppConfig.Json";
        public static string stringPathJsonFiles;
        public static string Key = "StringCN";
        #endregion variables


        // NEXT*******************************************
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


        // NEXT*******************************************
        #region revisar si existe el archivo xml y de no encontrarlo lo crea
        //validar si existe el AppConfig.Json, si no existe el AppConfig.Json lo crea, si existe lo borra y lo crea nuevamente
        public static string checkJsonFiles()
        {
            try
            {

                if (File.Exists(baseDirectory() + stringJsonFileDirectory) == false)
                {
                    createJsonFile();
                    return "Correcto";
                }
                else
                {
                    System.IO.File.Delete(baseDirectory() + stringJsonFileDirectory);
                    createJsonFile();
                    return "Correcto";
                }

            }
            catch (Exception exception)
            {
                return "error" + exception.ToString();
            }


        }


        #endregion revisar si existe el archivo xml y de no encontrarlo lo crea


        // NEXT*******************************************
        #region creacion del archivo Json
        // este metodo crea el archivo json con los atrubutos de la clase AppConfig
        public static void createJsonFile()
        {

            AppConfig appConfig = new AppConfig();
            appConfig.StringConnectionSqlServer = @"Server=JONATHANRG005;Database=dbMirror;Integrated Security=true;";
            appConfig.StringConnectionMySql = "N/A";

            string pathJson = stringBaseDirectory + stringJsonFileDirectory;

            using (StreamWriter file = File.CreateText(pathJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, appConfig);
            }
        }
        #endregion creacion del archivo Json

        // NEXT*******************************************
        #region leer el archivo json
        //este metodo sirve para leer un atributo en especifico del archivo json
        public static string readJsonFile(string Atributo)
        {
            string pathJson = stringBaseDirectory + stringJsonFileDirectory;

            StreamReader sr = new StreamReader(pathJson);
            String json = sr.ReadToEnd();

            dynamic appConfig = JsonConvert.DeserializeObject(json);

            string Conexion = appConfig[Atributo].ToString();
            sr.Close();

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
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);

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
                    memStream.Dispose();
                }
            }
        }

        public static string VerificarArchivoJson()
        {

            if (File.Exists(baseDirectory() + stringJsonFileDirectory) == false)
            {
                return "Sistema corrupto";
            }
            else
            {
                return "Correcto";
            }




        }





    }
}
