using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SoftBlue.Models;
using SoftBlue.Data;

namespace SoftBlue.Controller
{
    class AlunoController
    {
        public static List<Aluno> GetAll()
        {
            List<Aluno> alunos = new List<Aluno>();
            Connector connection = Connector.GetConnection();

            try
            {
                connection.Open();
            } catch(Exception error) { }

            MySqlDataReader reader = connection.ExecuteReader("SELECT * FROM ALUNO;");

            while(reader.Read())
            {
                alunos.Add(
                    new Aluno
                    {
                        Codigo = reader.GetInt32("CODIGO"),
                        Nome = reader.GetString("ALUNO"),
                        Endereco = reader.GetString("ENDERECO"),
                        Email = reader.GetString("EMAIL")
                    }
                );
            }

            try
            {
                connection.Close();
            } catch(Exception error) { }

            return alunos;
        }

        public static Aluno Insert(Aluno aluno)
        {
            Connector connection = Connector.GetConnection();

            try
            {
                connection.Open();
            } catch(Exception error) { }

            long codigo = connection.ExecuteScalar(
                "INSERT INTO ALUNO (ALUNO, ENDERECO, EMAIL) VALUES (@NOME, @ENDERECO, @EMAIL); SELECT LAST_INSERT_ID();",
                 connection.PrepareParameter("@NOME", aluno.Nome, MySqlDbType.VarChar),
                 connection.PrepareParameter("@ENDERECO", aluno.Endereco, MySqlDbType.VarChar),
                 connection.PrepareParameter("@EMAIL", aluno.Email, MySqlDbType.VarChar)
            );

            Aluno inserido = new Aluno
            {
                Codigo = Convert.ToInt32(codigo),
                Nome = aluno.Nome,
                Endereco = aluno.Endereco,
                Email = aluno.Email
            };

            try
            {
                connection.Close();
            } catch(Exception error) { }

            return inserido;
        }

        public static int Delete(long codigo)
        {
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch(Exception error) { }

            try
            {
                 long retorno = connection.ExecuteNonQuery("DELETE FROM ALUNO WHERE CODIGO = " + codigo);
                 return Convert.ToInt32(retorno);

            } catch(MySqlException error)
            {

            }
            
            try { connection.Close(); } catch(Exception error) { }

            return 0;

        }
        
        public static int Update(Aluno aluno)
        {
            Connector connection = Connector.GetConnection();

            try { connection.Open(); } catch(Exception error) { }

            long retorno = connection.ExecuteNonQuery(
                "UPDATE ALUNO SET ALUNO = @NOME, ENDERECO = @ENDERECO, EMAIL = @EMAIL WHERE CODIGO = @CODIGO",
                connection.PrepareParameter("@NOME", aluno.Nome, MySqlDbType.VarChar),
                connection.PrepareParameter("@ENDERECO", aluno.Endereco, MySqlDbType.VarChar),
                connection.PrepareParameter("@EMAIL", aluno.Email, MySqlDbType.VarChar),
                connection.PrepareParameter("@CODIGO", aluno.Codigo, MySqlDbType.Int32)
            );

            try { connection.Close(); } catch(Exception error) { }

            return Convert.ToInt32(retorno);
        }
    }
}
