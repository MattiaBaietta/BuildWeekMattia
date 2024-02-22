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
    public partial class History : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Ecommerce"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string userId = Session["UserId"] as string;
            SqlCommand cmd = new SqlCommand($"SELECT Utenti.*, Prodotto.*,Carrello_Prodotto.Quant,Carrello.idcarrello FROM Utenti INNER JOIN Carrello ON Utenti.idUtente = Carrello.idUtente INNER JOIN Carrello_Prodotto ON Carrello.idCarrello = Carrello_Prodotto.idCarrello INNER JOIN Prodotto ON Carrello_Prodotto.idProdotto = Prodotto.idProdotto WHERE Utenti.idUtente = '{userId}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int temp = 0;
            while (reader.Read())
            {
                if (temp == reader.GetInt32(13))
                {
                    idordine.InnerHtml += "<div class=\"col-9\">\r\n\r\n" +
                        "<div class=\"row\">\r\n\r\n" +
                        "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetString(10)}" +
                        "</div>" +
                         "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetInt32(9)}" +
                        "</div>" +
                         "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetInt32(12)}" +
                        "</div>" +

                       "</ div >\r\n " +
                       "</ div >\r\n ";
                }
                else
                {
                    idordine.InnerHtml += $"<h1>ORDINI DELL'UTENTE: {reader.GetString(1)}{reader.GetString(2)}</h1>\r\n" +
                "                    <div class=\"row\">\r\n " +
                $"                       <p class=\"col-3\">NUMERO ORDINE: {reader.GetInt32(13)}</p>\r\n " +
                "                   </div>" +
                "<div class=\"col-9\">\r\n\r\n" +
                        "<div class=\"row\">\r\n\r\n" +
                        "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetString(10)}" +
                        "</div>" +
                         "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetInt32(9)}" +
                        "</div>" +
                         "<div class=\"col\">\r\n\r\n" +
                        $"{reader.GetInt32(12)}" +
                        "</div>" +

                       "</ div >\r\n " +
                       "</ div >\r\n ";
                    temp = reader.GetInt32(13);
                }

            }
            conn.Close();
        }
    }
}