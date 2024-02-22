using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Epicode_Buildweek
{
    public partial class Registrazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                RegistraUtente();
            }
        }

        protected void RegistraUtente()
        {
            string nome = Request.Form["nomeUtente"].Trim();
            string cognome = Request.Form["cognomeUtente"].Trim();
            string email = Request.Form["indirizzoEmail"].Trim();
            string password = Request.Form["passwordUtente"].Trim();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ConnectionString;

            string query = "INSERT INTO Utenti (Nome, Cognome, Email, Password, TipoUtente) VALUES (@Nome, @Cognome, @Email, @Password, 'user'); SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Cognome", cognome);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);
                            Session["UserId"] = userId;
                        }
                        Response.Redirect("HomePage.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Errore durante l'inserimento dell'utente: " + ex.Message);
                    }
                }
            }
        }
    }
}