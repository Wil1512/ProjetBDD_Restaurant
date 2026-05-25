using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBDD_Restaurant
{
    internal class AccesDonnees
    {
        // Remplace par le nom de ton serveur SQL
        private string connectionString = @"Server=(localdb)\mssqllocaldb ;Database=RestaurantTatebong;Trusted_Connection=True;";

        // Une fonction générique pour lire des données
        public DataTable GetDonnees(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Une fonction pour insérer ou modifier (Clients, Réservations)
        public void ExecuterCommande(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Cette fonction va dans AccesDonnees.cs
        public DataTable ObtenirHitParade()
        {
            // La requête SQL pour le hitparade [cite: 11]
            string query = @"SELECT TOP 5 p.Nom, COUNT(c.PlatID) as Ventes 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     GROUP BY p.Nom 
                     ORDER BY Ventes DESC";

            return GetDonnees(query); // Utilise la fonction GetDonnees que nous avons créée avant
        }

        public decimal ObtenirChiffreAffaires(DateTime debut, DateTime fin)
        {
            // La requête pour le chiffre d'affaires hebdomadaire [cite: 13]
            string query = @"SELECT SUM(p.Prix * c.Quantite) 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     JOIN Reservations r ON c.ResID = r.ResID 
                     WHERE r.DateRes BETWEEN @debut AND @fin";

            // Ici, il faudra utiliser des paramètres pour la sécurité
            // Pour l'instant, retiens que la logique SQL reste dans cette classe.
            return 0; // (Exemple simplifié)
        }

        public void AjouterClient(string nom, string prenom, string telephone)
        {
            string query = "INSERT INTO Clients (Nom, Prenom, Telephone) VALUES (@nom, @prenom, @tel)";
            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@nom", nom),
             new SqlParameter("@prenom", prenom),
             new SqlParameter("@tel", telephone)
            };
            ExecuterCommande(query, parameters); // Appel de ta méthode générique d'exécution
        }

        // 1. Ajouter un plat à la commande en base de données
        public void AjouterPlatCommande(int resID, int platID, int quantite)
        {
            string query = "INSERT INTO Commandes (ResID, PlatID, Quantite) VALUES (@resID, @platID, @quantite)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@resID", resID);
                    cmd.Parameters.AddWithValue("@platID", platID);
                    cmd.Parameters.AddWithValue("@quantite", quantite);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 2. Calculer le montant total pour une réservation spécifique (Ticket)
        public decimal CalculerTotalTicket(int resID)
        {
            // On multiplie le prix du plat par sa quantité et on fait la somme (SUM)
            string query = @"SELECT SUM(p.Prix * c.Quantite) 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     WHERE c.ResID = @resID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@resID", resID);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public void AjouterReservation(int clientID, int tableNum, DateTime dateRes)
        {
            string query = "INSERT INTO Reservations (ClientID, TableNum, DateRes) VALUES (@clientID, @tableNum, @dateRes)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@clientID", clientID);
                    cmd.Parameters.AddWithValue("@tableNum", tableNum);
                    cmd.Parameters.AddWithValue("@dateRes", dateRes);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal ObtenirChiffreAffairesHebdo(DateTime dateDebut)
        {
            DateTime dateFin = dateDebut.AddDays(7);
            string query = @"SELECT SUM(p.Prix * c.Quantite) 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     JOIN Reservations r ON c.ResID = r.ResID 
                     WHERE r.DateRes BETWEEN @debut AND @fin";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@debut", dateDebut);
                    cmd.Parameters.AddWithValue("@fin", dateFin);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

    }
}
