using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace winedrops_coding_challenge.backend
{
   
    public class dbconnector
    {

        private static string connection_str = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        private static SQLiteConnection connection;
        private SQLiteCommand command;

        public dbconnector() { }

        void startConnection()
        {
            connection = new SQLiteConnection(connection_str);
            command = new SQLiteCommand(connection);
            command.CommandType = CommandType.Text;
           

            if (connection.State == ConnectionState.Open) connection.Close();

            connection.Open();

        }

        public void runCommand(string cmd)
        {
            startConnection();
            command.CommandText = cmd;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet selectCommand(string cmd)
        {
            startConnection();
            command.CommandText = cmd;
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.Close();

            return ds;

        }

    }
}