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

        public static Instrutor Insert(Instrutor instrutor)
        {
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch (Exception error) { }

            long codigo = connection.ExecuteScalar(
                "INSERT INTO INSTRUTOR (INSTRUTOR, TELEFONE) VALUES (@NOME, @TELEFONE); SELECT LAST_INSERT_ID();",
                connection.PrepareParameter("@NOME", instrutor.Nome, MySqlDbType.VarChar),
                connection.PrepareParameter("@TELEFONE", instrutor.Telefone, MySqlDbType.VarChar)
            );

            Instrutor instrutorInserido = new Instrutor
            {
                Codigo = Convert.ToInt32(codigo),
                Nome = instrutor.Nome,
                Telefone = instrutor.Telefone
            };

            try { connection.Close(); } catch(Exception error) { }

            return instrutorInserido;
        }

        public static int Delete(long codigo)
        {
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch (Exception error) { }

            try
            {
                long retorno = connection.ExecuteNonQuery("DELETE FROM INSTRUTOR WHERE CODIGO = " + codigo);
                return Convert.ToInt32(retorno);

            }
            catch (MySqlException error)
            {

            }

            try { connection.Close(); } catch (Exception error) { }

            return 0;
        }

        public static int Update(Instrutor instrutor)
        {
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch (Exception error) { }

            long retorno = connection.ExecuteNonQuery(
                "UPDATE INSTRUTOR SET INSTRUTOR = @NOME, TELEFONE = @TELEFONE WHERE CODIGO = @CODIGO",
                connection.PrepareParameter("@NOME", instrutor.Nome, MySqlDbType.VarChar),
                connection.PrepareParameter("@TELEFONE", instrutor.Telefone, MySqlDbType.VarChar),
                connection.PrepareParameter("@CODIGO", instrutor.Codigo, MySqlDbType.Int32)
            );

            try { connection.Close(); } catch (Exception error) { }

            return Convert.ToInt32(retorno);
        }
    }
}
