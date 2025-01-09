using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace GestioneLibreriaSaso.Classi
{
    public class Genere
    {
        [Required(ErrorMessage = "Il campo Genere è obbligatorio")]
        public int IdGenere { get; set; }

        public string? NomeGenere { get; set; }



        public Genere()
        {
        }


        public static List<Genere> getGeneri(string stringConnection)
        {
            List<Genere> listGeneri = new List<Genere>();
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                conn.Open();

                string query = "SELECT ID_GENERE, NOME_GENERE " +
                               "FROM GENERI";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listGeneri.Add(new Genere()
                            {
                                IdGenere = (int)reader["ID_GENERE"],
                                NomeGenere = reader["NOME_GENERE"].ToString()
                            });
                        }
                    }
                }
            }

            return listGeneri;
        }
    }
}
