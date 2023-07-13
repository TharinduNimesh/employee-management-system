using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace employee_management_system
{
    public class Mysql
    {
        private static MySqlConnection connection;
        public static void connect()
        {
            // create connection to the database
            String connectionString = "server=localhost;database=employee_management_system;uid=root;password=Well#ON123;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public static void insert(String query, String[] param)
        {
            // get command and execute it
            MySqlCommand cmd = PrepareQuery(query, param);
            cmd.ExecuteNonQuery();
        }

        public static void update(String query, String[] param)
        {
            // get command and execute it
            MySqlCommand cmd = PrepareQuery(query, param);
            cmd.ExecuteNonQuery();
        }

        public static void delete(String query, String[] param)
        {
            // get command and execute it
            MySqlCommand cmd = PrepareQuery(query, param);
            cmd.ExecuteNonQuery();
        }

        public static MySqlDataReader search(String query, String[] param)
        {
            // get command and execute it
            MySqlCommand cmd = PrepareQuery(query, param);
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        private static MySqlCommand PrepareQuery(string query, object[] parameters)
        {
            // validate parameters count
            if (parameters.Length == 0)
            {
                return new MySqlCommand(query, connection);
            }

            // split query from ? mark
            string[] queryParts = query.Split('?');

            // validate parameters count equals to the ? marks count
            if (queryParts.Length - 1 != parameters.Length)
            {
                throw new ArgumentException("Number of parameters does not match the number of placeholders in the query.");
            }

            // add parameters sql query
            StringBuilder preparedQuery = new StringBuilder(queryParts[0]);
            for (int i = 0; i < parameters.Length; i++)
            {
                string parameterName = $"@param{i}";
                preparedQuery.Append(parameterName);
                preparedQuery.Append(queryParts[i + 1]);
            }

            // prepare the mysql command
            using (MySqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = preparedQuery.ToString();
                if (parameters.Length > 0)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        string parameterName = $"@param{i}";
                        cmd.Parameters.AddWithValue(parameterName, parameters[i]);
                    }
                }
                return cmd;
            }
        }

        public static void disconnect()
        {
            // close connection
            connection.Close();
        }

    }
}
