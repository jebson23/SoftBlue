using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SoftBlue.Data;
using SoftBlue.Models;

namespace SoftBlue.Controller
{
    class InstrutorController
    {
        public static List<Instrutor> GetAll()
        {
            List<Instrutor> instrutores = new List<Instrutor>();
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch(Exception error) { }

            MySqlDataReader reader = connection.ExecuteReader("SELECT * FROM INSTRUTOR;");

            while(reader.Read())
            {
                instrutores.Add(
                    new Instrutor
                    {
                        Codigo = reader.GetInt32("CODIGO"),
                        Nome = reader.GetString("INSTRUTOR"),
                        Telefone = reader.GetString("TELEFONE")
                    }    
                );
            }

            try { connection.Close(); } catch(Exception error) { }

            return instrutores;
        }
    }
}
