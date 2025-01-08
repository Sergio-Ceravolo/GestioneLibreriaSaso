using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace GestioneLibreriaSaso.Classi
{
    public class Autore
    {
        [Required(ErrorMessage = "Il campo Autore è obbligatorio")]
        public int IdAutore { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Data di Nascita è obbligatorio")]
        public DateTime DataNascita { get; set; }

        [Required(ErrorMessage = "Il campo Paese è obbligatorio")]
        public string Paese { get; set; }

        public string? NomeCognome { get; private set; }


        public Autore()
        {
            
        }

        public static List<Autore> getAutori(string connectionString)
        {
            List<Autore> listAutori = new List<Autore>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT " +
                               "ID_AUTORE, " +
                               "NOME, " +
                               "COGNOME, " +
                               "DATA_NASCITA, " +
                               "PAESE " +
                               "FROM [GestioneLibreria_Saso].[dbo].[AUTORI] " +
                               "ORDER BY ID_AUTORE DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            
                            listAutori.Add(new Autore
                            {
                                IdAutore = (int)reader["ID_AUTORE"],
                                Nome = reader["NOME"].ToString(),
                                Cognome = reader["COGNOME"].ToString(),
                                DataNascita = (DateTime)reader["DATA_NASCITA"],
                                Paese = reader["PAESE"].ToString(),
                                NomeCognome = reader["NOME"].ToString() + " " + reader["COGNOME"].ToString()
                            });
                        }

                    }
                }
            }

            return listAutori;
        }



        public void createAutore(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT " +
                                "INTO AUTORI (NOME, COGNOME, DATA_NASCITA, PAESE) " +
                                "VALUES (@NOME, @COGNOME, @DATA_NASCITA, @PAESE); " +
                                "SELECT @@IDENTITY";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NOME", Nome);
                    cmd.Parameters.AddWithValue("@COGNOME", Cognome);
                    cmd.Parameters.AddWithValue("@DATA_NASCITA", DataNascita);
                    cmd.Parameters.AddWithValue("@PAESE", Paese);

                    cmd.ExecuteScalar();
                }
            }
        }



        public void deleteAutore(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE " +
                               "FROM AUTORI " +
                               "WHERE ID_Autore = @ID_Autore";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Autore", IdAutore);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void editAutore(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE AUTORI " +
                               "SET NOME = @NOME, " +
                               "COGNOME = @COGNOME, " +
                               "DATA_NASCITA = @DATA_NASCITA, " +
                               "PAESE = @PAESE " +
                               "WHERE ID_AUTORE = @ID_AUTORE";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_AUTORE", IdAutore);
                    cmd.Parameters.AddWithValue("@NOME", Nome);
                    cmd.Parameters.AddWithValue("@COGNOME", Cognome);
                    cmd.Parameters.AddWithValue("@DATA_NASCITA", DataNascita);
                    cmd.Parameters.AddWithValue("@PAESE", Paese);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void getAutore(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ID_AUTORE, " +
                               "NOME, " +
                               "COGNOME, " +
                               "DATA_NASCITA, " +
                               "PAESE " +
                               "FROM AUTORI " +
                               "WHERE ID_AUTORE = @ID_AUTORE";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_AUTORE", IdAutore);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            IdAutore = (int)reader["ID_AUTORE"];
                            Nome = reader["NOME"].ToString();
                            Cognome = reader["COGNOME"].ToString();
                            DataNascita = (DateTime)reader["DATA_NASCITA"];
                            Paese = reader["PAESE"].ToString();
                            NomeCognome = reader["NOME"].ToString() + " " + reader["COGNOME"].ToString();
                        }

                    }
                }
            }
        }
    }
}
