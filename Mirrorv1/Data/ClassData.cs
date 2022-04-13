using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Mirrorv1.Data
{

    class ClassData
    {
        // NEXT********************************************
        #region creando la cadena de conexion
        //cadena de conexion
        public static SqlConnection sqlConnection;
        #endregion creando la cadena de conexion


        // NEXT********************************************
        #region probar conexion
        public static string probarConexion()
        {
            string resultado;
            sqlConnection = new SqlConnection(Aplication.ClassAplication.readJsonFile("StringConnectionSqlServer"));
            try {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                resultado = "Correcto";
                return resultado;
            }
            catch (Exception exception)
            {
                resultado = "error" + exception.ToString();
                return resultado;
            }
        }
        #endregion probar conexion

        // NEXT********************************************

        #region ejecutar un proceso almacenado y retorna un datatable
        // esta clase resive el nombre del storeprocedure y los parametros
        public static void runDataTable2(string NameStoredProcedure, List<SqlParameter> listParameter = null, string stringParameterCommandType = "CommandText")
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            // creando el datatable
            DataTable dataTable = new DataTable();

            try
            {
                //abrir la conexion si esta cerrada.
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                // creando el data adapter


                sqlDataAdapter.SelectCommand = new SqlCommand(NameStoredProcedure, sqlConnection);
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
                Main.ClassVariablesPublicas.CreacionDataTable = "error" + exception.ToString();
                // throw new ArgumentNullException(exception.Message);
            }
            finally
            {
                sqlDataAdapter.Dispose();
                sqlConnection.Close();
            }
            //return dataTable;
        }
        #endregion ejecutar un proceso almacenado y retorna un datatable


        #region ejecutar un proceso almacenado y retorna un datatable
        // esta clase resive el nombre del storeprocedure y los parametros
        public static DataTable runDataTable(string NameStoredProcedure, List<SqlParameter> listParameter = null, string stringParameterCommandType = "CommandText")
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            // creando el datatable
            DataTable dataTable = new DataTable();

            try
            {
                //abrir la conexion si esta cerrada.
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                // creando el data adapter
               

                sqlDataAdapter.SelectCommand = new SqlCommand(NameStoredProcedure, sqlConnection);
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
                Main.ClassVariablesPublicas.CreacionDataTable = "error" + exception.ToString();
               // throw new ArgumentNullException(exception.Message);
            }
            finally
            {
                sqlDataAdapter.Dispose();
                sqlConnection.Close();
            }
            return dataTable;
        }
        #endregion ejecutar un proceso almacenado y retorna un datatable


        #region ejecutar un proceso almacenado y retorna un dataset
        public static DataSet runDataSet(string NameStoredProcedure, List<SqlParameter> listParameter = null, string stringParameterCommandType = "CommandText")
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            // creando el datatable
            DataSet dataSet = new DataSet();

            try
            {
                //abrir la conexion si esta cerrada.
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                // creando el data adapter


                sqlDataAdapter.SelectCommand = new SqlCommand(NameStoredProcedure, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = stringParameterCommandType == "CommandText" ? CommandType.Text : CommandType.StoredProcedure;

                if (listParameter != null)
                {
                    foreach (SqlParameter sqlParameter in listParameter)
                    {
                        sqlDataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                Main.ClassVariablesPublicas.CreacionDataTable = "error" + exception.ToString();
                // throw new ArgumentNullException(exception.Message);
            }
            finally
            {
                sqlDataAdapter.Dispose();
                sqlConnection.Close();
            }
            return dataSet;
        }
#endregion ejecutar un proceso almacenado y retorna un dataset


    }
}
