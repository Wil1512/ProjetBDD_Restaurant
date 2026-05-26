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
            // Ta superbe requête SQL bien structurée
            string query = @"SELECT ISNULL(SUM(p.Prix * c.Quantite), 0) 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     JOIN Reservations r ON c.ResID = r.ResID 
                     WHERE r.DateRes BETWEEN @debut AND @fin";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Sécurisation de la requête avec les paramètres attendus par le WHERE
                    cmd.Parameters.AddWithValue("@debut", debut);
                    cmd.Parameters.AddWithValue("@fin", fin);

                    conn.Open();

                    // ExecuteScalar() récupère la valeur unique renvoyée par le SUM
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
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
            // On force le début de la semaine à minuit pile (00:00:00)
            DateTime debutReel = dateDebut.Date;

            // On calcule la fin 7 jours plus tard, poussée jusqu'à la dernière seconde de la journée (23:59:59)
            DateTime finReelle = debutReel.AddDays(7).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            string query = @"SELECT ISNULL(SUM(p.Prix * c.Quantite), 0) 
                     FROM Commandes c 
                     JOIN Plats p ON c.PlatID = p.PlatID 
                     JOIN Reservations r ON c.ResID = r.ResID 
                     WHERE r.DateRes BETWEEN @debut AND @fin";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // On envoie les dates nettoyées
                    cmd.Parameters.AddWithValue("@debut", debutReel);
                    cmd.Parameters.AddWithValue("@fin", finReelle);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    return 0;
                }
            }
        }

        public DataTable ObtenirReservationsSemaine(DateTime dateDebut)
        {
            // .Date force l'heure à minuit pile (00:00:00) pour le début de la semaine
            DateTime debutSemaine = dateDebut.Date;

            // La fin de la semaine s'arrête 7 jours plus tard à 23h59:59
            DateTime finSemaine = debutSemaine.AddDays(7).AddHours(23).AddMinutes(59).AddSeconds(59);

            string query = @"SELECT r.ResID AS [N°], 
                            c.Nom + ' ' + c.Prenom AS [Client], 
                            r.TableNum AS [Table], 
                            r.DateRes AS [Date & Heure]
                     FROM Reservations r 
                     JOIN Clients c ON r.ClientID = c.ClientID 
                     WHERE r.DateRes BETWEEN @debut AND @fin";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // On passe les dates nettoyées de leurs heures parasites
                    cmd.Parameters.AddWithValue("@debut", debutSemaine);
                    cmd.Parameters.AddWithValue("@fin", finSemaine);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenirTousLesClients()
        {
            string query = "SELECT ClientID AS [ID], Nom, Prenom, Telephone AS [Téléphone] FROM Clients ORDER BY Nom, Prenom";
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable ObtenirEtatDesTables()
        {
            // Cette requête récupère la liste des tables actuellement associées à une réservation
            string query = @"SELECT r.TableNum AS [N° Table], 
                            c.Nom + ' ' + c.Prenom AS [Occupée par], 
                            r.DateRes AS [Date de Réservation]
                     FROM Reservations r
                     JOIN Clients c ON r.ClientID = c.ClientID
                     ORDER BY r.TableNum";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 1. Récupérer la liste des numéros de tables uniques qui ont une réservation
        public DataTable ObtenirTablesReservees()
        {
            string query = "SELECT DISTINCT TableNum FROM Reservations ORDER BY TableNum";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 2. Récupérer la liste de tous les plats pour le ComboBox
        public DataTable ObtenirTousLesPlats()
        {
            string query = "SELECT PlatID, Nom, Prix FROM Plats ORDER BY Categorie, Nom";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 3. Récupérer les plats déjà commandés par une table pour la grille
        public DataTable ObtenirCommandesParTable(int numTable)
        {
            // Correction de la requête avec tes vrais noms de colonnes :
            // CommandeID à la place de ComID, et liaison via r.TableNum et c.ResID
            string query = @"SELECT c.CommandeID AS [N° Ligne], 
                            p.Nom AS [Plat Commandé], 
                            p.Prix AS [Prix Unitaire (€)],
                            c.Quantite AS [Quantité]
                     FROM Commandes c
                     JOIN Plats p ON c.PlatID = p.PlatID
                     JOIN Reservations r ON c.ResID = r.ResID
                     WHERE r.TableNum = @tableNum";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tableNum", numTable);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int ObtenirResIDParTable(int numTable)
        {
            string query = "SELECT TOP 1 ResID FROM Reservations WHERE TableNum = @tableNum ORDER BY DateRes DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tableNum", numTable);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public decimal CalculerTotalTable(int numTable)
        {
            // On fait la somme des prix multipliés par leur quantité pour une table donnée
            string query = @"SELECT ISNULL(SUM(p.Prix * c.Quantite), 0)
                     FROM Commandes c
                     JOIN Plats p ON c.PlatID = p.PlatID
                     JOIN Reservations r ON c.ResID = r.ResID
                     WHERE r.TableNum = @tableNum";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tableNum", numTable);
                    conn.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }
    }
}
