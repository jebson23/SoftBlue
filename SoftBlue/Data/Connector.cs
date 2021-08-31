using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SoftBlue.Data
{
    class Connector
    {
        private MySqlConnection connection;
        private string ConnectionString = "server=localhost;port=3306;user id=root;password=root;database=softblue";

        public static Connector GetConnection()
        {
            return new Connector();
        }
        public Connector ()
        {
            this.connection = new MySqlConnection(this.ConnectionString);
        }

        public Connector(string ConnectionString) : this()
        {
            this.ConnectionString = ConnectionString;
        }

        public void Open()
        {
            if (this.connection.State == System.Data.ConnectionState.Closed)
                this.connection.Open();
        }

        public void Close()
        {
            if (this.connection.State == System.Data.ConnectionState.Open)
                this.connection.Close();
        }

        public MySqlParameter PrepareParameter(string column, dynamic value, MySqlDbType type)
        {
            MySqlParameter param = new MySqlParameter(column, null);

            param.MySqlDbType = type;
            param.Value = value;

            return param;
        }

        public MySqlCommand PrepareCommand(string query, params MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, this.connection);

            foreach (MySqlParameter parameter in parameters)
            {
                if (parameter == null) continue;
                command.Parameters.Add(parameter);
            }

            return command;
        }

        public MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            MySqlCommand command = this.PrepareCommand(query, parameters);

            return command.ExecuteReader();
        }

        public long ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            MySqlCommand command = this.PrepareCommand(query, parameters);

            return command.ExecuteNonQuery();
        }

        public long ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            MySqlCommand command = this.PrepareCommand(query, parameters);

            object scalar = command.ExecuteScalar();

            if (DBNull.Value.Equals(scalar) || scalar == null) return -1;

            return Convert.ToInt64(scalar);
        }
    }
}
