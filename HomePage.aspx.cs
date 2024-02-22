using Microsoft.SqlServer.Server;
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
    public class Articolo : IEquatable<Articolo>
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Dettagli { get; set; }
        public int Prezzo { get; set; }
        public string Nome { get; set; }
        public string Immagine { get; set; }



        public Articolo(int id, string descrizione, string dettagli, int prezzo, string nome, string immagine)
        {
            Immagine = immagine;
            Descrizione = descrizione;
            Dettagli = dettagli;
            Nome = nome;
            Id = id;
            Prezzo = prezzo;

        }

        public bool Equals(Articolo other)
        {
            if (other == null)
                return false;
            return this.Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Articolo))
                return false;

            return Equals(obj as Articolo);
        }

    }
    public class Quantity
    {
        public int Id { get; set; }
        public int Quant { get; set; }
        public Quantity(int id, int quant)
        {
            Id = id;
            Quant = quant;

        }

    }
    public partial class HomePage : System.Web.UI.Page
    {
        public static List<Articolo> allValues = new List<Articolo>();
        public static List<Quantity> products = new List<Quantity>();
        protected void Page_Load(object sender, EventArgs e)
        {
            allValues.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
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

        protected void AddToCart(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string productId = btn.CommandArgument;
            int prodId = int.Parse(productId);
            bool isinCart = false;
            if (Session["ProductID"] == null)
            {
                Session["ProductID"] = products;
            }
            else
            {
                products = (List<Quantity>)Session["ProductID"];
            }
            foreach (Quantity prodotto in products)
            {
                if (prodotto.Id == prodId)
                {
                    prodotto.Quant += 1;
                    isinCart = true;
                }
            }
            if (!isinCart)
            {
                products.Add(new Quantity(prodId, 1));
                Session["ProductID"] = products;
            }
        }
    }
}