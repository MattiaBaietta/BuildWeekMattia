using BuildWeekMattia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Epicode_Buildweek
{
    public partial class Carrello : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        List<Articolo> carrello = new List<Articolo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int totcarrello = 0;
            foreach (Quantity prodotti in HomePage.products)
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand($"SELECT * FROM Prodotto WHERE idprodotto={prodotti.Id}", conn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    Articolo articolo = new Articolo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));

                    carrello.Add(articolo);
                    int totale = articolo.Prezzo * prodotti.Quant;
                    totcarrello += totale;
                    Button btnRemove = new Button();

                    btnRemove.CssClass = "btn btn-primary";
                    btnRemove.Text = "Rimuovi";
                    btnRemove.CommandArgument = articolo.Id.ToString();
                    btnRemove.Click += RemoveFromCart;

                    form1.Controls.Add(new LiteralControl(
                        $@"
                <div class=""row"">
                    <div class=""d-flex"">
                        <div class=""col d-flex"">
                            <img style=""width: 100px; height: 120px;"" src=""{articolo.Immagine}"" />
                            <label id=""Nametxt"" class=""form-control"" type=""text"">{articolo.Nome}</label>
                        </div>
                        <div class=""col"">
                            <label style=""height: 120px;"" id=""Pricetxt"" class=""form-control"" type=""text"">Prezzo unitario: {articolo.Prezzo}</label>
                        </div>
                        <div class=""col"">
                            <label style=""height: 120px;"" id=""Quanttxt"" class=""form-control"" type=""text"">Quantità:{prodotti.Quant}</label>
                        </div>
                        <div class=""col"">
                            <label style=""height: 120px;"" id=""Tottxt"" class=""form-control"" type=""text"">Prezzo Tot:{totale}</label>
                        </div>
                        <div class=""col"">"
                    ));
                    form1.Controls.Add(btnRemove);


                    form1.Controls.Add(new LiteralControl(
                        @"</div>
                    </div>
                </div>"
                    ));
                }
                conn.Close();
            }
            form1.Controls.Add(new LiteralControl($"<div><p>Totale Carrello:{totcarrello}</p></div>"));
            Button confirmCart = new Button();
            confirmCart.CssClass = "btn btn-primary";
            confirmCart.Text = "Conferma Carrello";
            confirmCart.Click += ConfirmCart;
            form1.Controls.Add(confirmCart);

        }

        protected void RemoveFromCart(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int articoloId = Convert.ToInt32(btn.CommandArgument);
            for (int i = 0; i < HomePage.products.Count; i++)
            {
                if (HomePage.products[i].Id == articoloId)
                {
                    HomePage.products.RemoveAt(i);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
        protected void ConfirmCart(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string userId = Session["UserId"] as string;
            SqlCommand cmd2 = new SqlCommand($"INSERT INTO Carrello (idUtente) VALUES ({userId}); SELECT SCOPE_IDENTITY()", conn);
            int idcarrello = Convert.ToInt32(cmd2.ExecuteScalar());
            foreach (Quantity prodotti in HomePage.products)
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Carrello_Prodotto (idprodotto,idcarrello,quant) VALUES ({prodotti.Id},{idcarrello},{prodotti.Quant})", conn);
                cmd.ExecuteNonQuery();
            }


        }
        protected void Cronologia(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }
    }
}
