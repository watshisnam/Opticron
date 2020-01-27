using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.IO;
using System.Configuration;
using Opticron.Classes;
using Microsoft.Extensions.Configuration;
namespace Opticron.Classes.DataHandler
{
    public class Datahandler
    {
        private OleDbConnection connector ;
        public Datahandler()
        {
            connector = new OleDbConnection(@"Provider=SQLNCLI11;Data Source=DESKTOP-4G3UF6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Opticron");
			//Hard coded connection string , will have to be changed once run on another computer
        }
        public List<object[]> Select(string sql)//Recieves an Sql statement for a select query and runs it on the db and will return a list of object arrays which are all the rows selected.
        {
            List<object[]> returnList = new List<object[]>();
            try
            {
                connector.Open();
                if(connector.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand(sql,connector);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        object[] row = new object[50];
                        reader.GetValues(row);
                        returnList.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DbConnectionFailurExcpetion("Failed to Connect to Database/n" + e.Message);
            }
            finally
            {
                connector.Close();
            }
            return returnList;
        }

        public bool Update(string sql)//Recieves a sql statement that will modify the database , eg. insert , update or delete and runs the query returning a bool if any rows were effected.
        {
            bool returnBool = false;
            try
            {
                connector.Open();
                if(connector.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand(sql, connector);
                   if(cmd.ExecuteNonQuery() != 0)
                   {
                        returnBool = true;
                   }
                }

            }
            catch (Exception e)
            {
                throw new DbConnectionFailurExcpetion("Failed to Connect to Database/n" + e.Message);
            }
            finally
            {
                connector.Close();
            }
            return returnBool;
        }
    }
}
