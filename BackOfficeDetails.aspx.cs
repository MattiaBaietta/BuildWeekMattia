using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildWeekMattia
{
    public partial class BackOfficeDetails : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idValue = Request.QueryString["id"];
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Prodotto WHERE idprodotto={idValue}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    imgurl.Src = reader["Immagine"].ToString();
                    Urltxt.Text = reader["Immagine"].ToString();
                    Nametxt.Text = reader["Nome"].ToString();
                    Desctxt.Text = reader["Descrizione"].ToString();
                    Dettxt.Text = reader["Dettagli"].ToString();
                    Pricetxt.Text = reader["Prezzo"].ToString();
                    Mod.CommandArgument = reader["idprodotto"].ToString();
                    DelBtn.CommandArgument = reader["idprodotto"].ToString();
                }

                conn.Close();
            }
        }

        protected void Mod_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            conn.Open();



            SqlCommand sql = new SqlCommand($"UPDATE Prodotto SET Descrizione='{Desctxt.Text}', Immagine='{Urltxt.Text}', Dettagli='{Dettxt.Text}', Prezzo={int.Parse(Pricetxt.Text)}, Nome='{Nametxt.Text}' WHERE idprodotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            conn.Close();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            conn.Open();
            SqlCommand sql = new SqlCommand($"DELETE FROM Prodotto WHERE idprodotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            Response.Redirect(Request.Url.AbsoluteUri);
            conn.Close();

        }
    }
}
