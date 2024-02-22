<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.Dettaglio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container my-5 d-flex justify-content-around">
        <div>
            <h2 id="ttlProdotto" runat="server" class="text-center fw-bold fst-italic text-uppercase">Nome prodotto</h2>
            <div class="d-flex justify-content-center">
                <img id="img" src="" alt="" class="" runat="server" width="300"/>
            </div>
        </div>
        <div>
            <div>
                <p id="txtDescrizione" runat="server" class="text-center my-5"></p>
                <p id="txtPrezzo" runat="server" class="text-center mb-5"></p>
            </div>
            <div class="d-flex align-items-baseline">
                <asp:Button runat="server" Text="Aggiungi al carrello" OnClick="btnAcquista_Click" CssClass="btn btn-success" />
                <div class="d-flex align-items-center ms-3">
                    <div class="d-flex align-items-baseline">
                        <asp:TextBox ID="QuantitaTextBox" runat="server" CssClass="form-control" Text="1" type="number" Width="55px" />
                        <div class="input-group ms-3">
                            <div class="d-flex align-items-baseline">
                                <asp:Button runat="server" Text="➖" CssClass="btn btn-danger" OnClick="decrement" />
                                <asp:Button runat="server" Text="➕" CssClass="btn btn-success" OnClick="increment" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
