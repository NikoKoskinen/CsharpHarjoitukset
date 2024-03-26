using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Libraries for database
using System.Data;
using System.Data.SqlClient;

namespace DatabaseTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TEST ALL CRUD (create,read,update and delete) OPERATIONS USING TYONTEKIJA TABLE
            // -------------------------------------------------------------------------------

            // Create a connection to SQL Server using Windows Authentication
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-FJGQ5SM\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {  conn.Open();
                Console.WriteLine(conn.State);
                Console.WriteLine("Yhteyteen vastaa SQL Server versio " + conn.ServerVersion);

                // Create a SQL command to insert new employee to Tyontekija table
                string insertEmployee = "INSERT INTO dbo.Tyontekija (Etunimi, Sukunimi) VALUES ('Taavi', 'Toivoton');";

                // Send command to connection
                SqlCommand cmd = new SqlCommand(insertEmployee, conn);

                // Execute command whitc does not return a results set
                cmd.ExecuteNonQuery();

                // Close the connection when done
                conn.Close();
            }

            using (SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-FJGQ5SM\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn2.Open();
                Console.WriteLine(conn2.State);

                // Create a sql command to update Calles city in Tyontekija table
                string updateEmployee = "UPDATE dbo.Tyontekija SET Postitoimipaikka = 'Turku' WHERE TyontekijaID = 1008;";
                SqlCommand cmd2 = new SqlCommand(updateEmployee, conn2);
                cmd2.ExecuteNonQuery();
                conn2.Close();
            }

            // Create 3rd connection to the db
            using (SqlConnection conn3 = new SqlConnection("Data Source=DESKTOP-FJGQ5SM\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn3.Open();
                
                //Create SQL query to retvieve all rows from Tyontekija table
                string queryAllEmployees = "SELECT Etunimi, Sukunimi FROM dbo.Tyontekija;";
                SqlCommand cmd3 = new SqlCommand(queryAllEmployees, conn3);

                // To avoid eternal loop use timeout
                cmd3.CommandTimeout = 10;

                // Use reader to handle result set
                SqlDataReader reader = cmd3.ExecuteReader();

                // Print data to screen while reader gets more rows
                while (reader.Read())
                {
                    // Format output with tabs
                    Console.WriteLine("{0}\t{1}",reader.GetString(0),reader.GetString(1));
                }

                // Close connection to the db
                conn3.Close();
            }
            using (SqlConnection conn4 = new SqlConnection("Data Source=DESKTOP-FJGQ5SM\\SQLEXPRESS;Initial Catalog=Henkilosto;Integrated Security=True"))
            {
                conn4.Open();
                string deleteEmployee = "DELETE FROM dbo.Tyontekija WHERE TyontekijaID in (1011,11012);";
                SqlCommand cmd4 = new SqlCommand(deleteEmployee, conn4);
                cmd4.ExecuteNonQuery();
                conn4.Close();

            }

            Console.ReadLine();
           
           

        }
    }
}
