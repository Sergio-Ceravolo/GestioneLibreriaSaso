using Microsoft.Data.SqlClient;

namespace GestioneLibreriaSaso.Classi
{
    public class Autore
    {
        public int IdAutore { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string Paese { get; set; }

        public string NomeCognome { get; private set; }


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
                               "ORDER BY NOME ASC";

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
    }
}
