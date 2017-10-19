using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class Controller
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=localhost; Initial Catalog=TestDB; Integrated Security=True");            
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;

        //TODO
        public List<string> GetListOfImagesFromDB ()
        {
            List<string> listOfImageTitle = new List<string>();

            string query = "select ImageTitle from TestDB.dbo.testTable order by ID;";
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                
                while (sqlDataReader.Read())
                {
                    listOfImageTitle.Add(sqlDataReader.GetString(0));                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DEBUG: {0} ", e.Message);
            }
            finally
            {
                sqlDataReader.Close();
                sqlConnection.Close();                
            }

            return listOfImageTitle;
        }

        //TODO
        public void WriteToDB(string imageTitle, string image)
        {
            string query = "INSERT INTO TestDB.dbo.testTable (ImageTitle, Image) VALUES ('" + imageTitle + "', '" + image + "')";
            try
            {
                sqlCommand = new SqlCommand(query,sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("DEBUG: {0}", e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void TestSQLConnection()
        {
            
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select count (*) from TestDB.dbo.testTable", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();                                                           
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlDataReader.Close();
                sqlConnection.Close();
            }
        }        
    }
}
