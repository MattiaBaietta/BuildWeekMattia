using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildWeekMattia
{
    public class Articolo
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Dettagli { get; set; }
        public decimal Prezzo { get; set; }
        public string Nome { get; set; }
        public string Immagine { get; set; }


        public Articolo(int id, string descrizione, string dettagli, decimal prezzo, string nome, string immagine)
        {
            Immagine = immagine;
            Descrizione = descrizione;
            Dettagli = dettagli;
            Nome = nome;
            Id = id;
            Prezzo = prezzo;
        }
    }
    public partial class BackOffice : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        public static List<Articolo> allValues = new List<Articolo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Prodotto", conn);
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Articolo articolo = new Articolo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
                allValues.Add(articolo);
            }
            if (!IsPostBack)
            {
                RepeaterBackoffice.DataSource = allValues;
                RepeaterBackoffice.DataBind();
            }
            conn.Close();
        }




        protected void DelBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            Response.Write(idProdotto.ToString());
            conn.Open();
            SqlCommand sql = new SqlCommand($"DELETE FROM Prodotto WHERE idprodotto = {idProdotto}", conn);
            sql.ExecuteNonQuery();
            Response.Redirect(Request.Url.AbsoluteUri);
            conn.Close();
        }

        protected void Mod_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"/BackOfficeDetails?id={idProdotto}");
        }
    }
}