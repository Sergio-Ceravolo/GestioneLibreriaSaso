using Microsoft.Data.SqlClient;

namespace GestioneLibreriaSaso.Classi
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public string Copertina { get; set; }
        public DateTime DataPubblicazione { get; set; }
        public string Genere { get; set; }
        public Autore Autore { get; set; }




        public Libro()
        {
            Autore = new Autore();
        }

        public static Libro getLastLibro(string connectionString)
        {
            Libro lastLibro = new Libro();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT TOP (1) " +
                               "ID_Libro, " +
                               "TITOLO, " +
                               "DESCRIZIONE, " +
                               "COPERTINA, " +
                               "DATA_PUBBLICAZIONE, " +
                               "GENERE, " +
                               "NOME, " +
                               "COGNOME, " +
                               "LIBRI.ID_AUTORE " +
                               "FROM LIBRI " +
                               "JOIN AUTORI " +
                               "ON AUTORI.ID_AUTORE = LIBRI.ID_AUTORE " +
                               "ORDER BY ID_LIBRO DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Autore autore = new Autore();
                            int IdAutore = 0;
                            int.TryParse(reader["ID_AUTORE"].ToString(), out IdAutore);
                            autore.IdAutore = IdAutore;
                            autore.Nome = reader["NOME"].ToString();
                            autore.Cognome = reader["COGNOME"].ToString();


                            lastLibro.IdLibro = (int)reader["ID_Libro"];
                            lastLibro.Titolo = reader["TITOLO"].ToString();
                            lastLibro.Descrizione = reader["DESCRIZIONE"].ToString();
                            lastLibro.Copertina = reader["COPERTINA"].ToString();
                            lastLibro.DataPubblicazione = (DateTime)reader["DATA_PUBBLICAZIONE"];
                            lastLibro.Genere = reader["GENERE"].ToString();
                            lastLibro.Autore = autore;
                        }

                    }
                }
            }

            return lastLibro;
        }



        public static List<Libro> getLibriGenres(string connectionString, string genre)
        {
            List<Libro> listLibri = new List<Libro>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT " +
                               "ID_Libro, " +
                               "TITOLO, " +
                               "DESCRIZIONE, " +
                               "COPERTINA, " +
                               "DATA_PUBBLICAZIONE, " +
                               "GENERE, " +
                               "NOME, " +
                               "COGNOME, " +
                               "LIBRI.ID_AUTORE " +
                               "FROM LIBRI " +
                               "JOIN AUTORI " +
                               "ON AUTORI.ID_AUTORE = LIBRI.ID_AUTORE " +
                               "WHERE GENERE = '" + genre + "'" +
                               "ORDER BY ID_LIBRO DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Autore autore = new Autore();
                            int IdAutore = 0;
                            int.TryParse(reader["ID_AUTORE"].ToString(), out IdAutore);
                            autore.IdAutore = IdAutore;
                            autore.Nome = reader["NOME"].ToString();
                            autore.Cognome = reader["COGNOME"].ToString();

                            listLibri.Add(new Libro
                            {
                                IdLibro = (int)reader["ID_Libro"],
                                Titolo = reader["TITOLO"].ToString(),
                                Descrizione = reader["DESCRIZIONE"].ToString(),
                                Copertina = reader["COPERTINA"].ToString(),
                                DataPubblicazione = (DateTime)reader["DATA_PUBBLICAZIONE"],
                                Genere = reader["GENERE"].ToString(),
                                Autore = autore
                            });
                        }

                    }
                }
            }

            return listLibri;
        }



        public static List<Libro> getLibri(string connectionString)
        {
            List<Libro> listLibri = new List<Libro>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT " +
                               "ID_Libro, " +
                               "TITOLO, " +
                               "DESCRIZIONE, " +
                               "COPERTINA, " +
                               "DATA_PUBBLICAZIONE, " +
                               "GENERE, " +
                               "NOME, " +
                               "COGNOME, " +
                               "LIBRI.ID_AUTORE " +
                               "FROM LIBRI " +
                               "JOIN AUTORI " +
                               "ON AUTORI.ID_AUTORE = LIBRI.ID_AUTORE " +
                               "ORDER BY ID_LIBRO DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Autore autore = new Autore();
                            int IdAutore = 0;
                            int.TryParse(reader["ID_AUTORE"].ToString(), out IdAutore);
                            autore.IdAutore = IdAutore;
                            autore.Nome = reader["NOME"].ToString();
                            autore.Cognome = reader["COGNOME"].ToString();

                            listLibri.Add(new Libro
                            {
                                IdLibro = (int)reader["ID_Libro"],
                                Titolo = reader["TITOLO"].ToString(),
                                Descrizione = reader["DESCRIZIONE"].ToString(),
                                Copertina = reader["COPERTINA"].ToString(),
                                DataPubblicazione = (DateTime)reader["DATA_PUBBLICAZIONE"],
                                Genere = reader["GENERE"].ToString(),
                                Autore = autore
                            });
                        }

                    }
                }
            }

            return listLibri;
        }



        public void createLibro(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO LIBRI (TITOLO, DESCRIZIONE, GENERE, DATA_PUBBLICAZIONE, ID_AUTORE ) VALUE (@TITOLO, @DESCRIZIONE, @GENERE, @COPERTINA, @DATA_PUBBLICAZIONE, @ID_AUTORE); SELECT @@IDENTITY";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TITOLO", Titolo);
                    cmd.Parameters.AddWithValue("@DESCRIZIONE", Descrizione);
                    cmd.Parameters.AddWithValue("@GENERE", Genere);
                    cmd.Parameters.AddWithValue("@COPERTINA", Copertina);
                    cmd.Parameters.AddWithValue("@DATA_PUBBLICAZIONE", DataPubblicazione);
                    cmd.Parameters.AddWithValue("@ID_AUTORE", Autore.IdAutore);

                    cmd.ExecuteScalar();
                }
            }
        }


        /*
        public void editLibro(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE LIBRI " +
                               "SET TITOLO = @Titolo, " +
                               "DESCRIZIONE = @Descrizione, " +
                               "GENERE = @Genere, " +
                               "COPERTINA = @Copertina, " +
                               "DATA_PUBBLICAZIONE = @DataPubblicazione, " +
                               "WHERE ID_LIBRI = @IdLibro";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TITOLO", Titolo);
                    cmd.Parameters.AddWithValue("@DESCRIZIONE", Descrizione);
                    cmd.Parameters.AddWithValue("@GENERE", Genere);
                    cmd.Parameters.AddWithValue("@COPERTINA", Copertina);
                    cmd.Parameters.AddWithValue("@DATA_PUBBLICAZIONE", DataPubblicazione);
                    cmd.Parameters.AddWithValue("@ID_AUTORE", Autore.IdAutore);

                    cmd.ExecuteScalar();
                }
            }
        }*/

    }
}
