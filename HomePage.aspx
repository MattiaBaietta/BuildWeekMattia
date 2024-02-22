<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.HomePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center fw-bold fst-italic text-uppercase mb-5">Market</h3>
    <div class="container">

        <div class="row">
            <a href="Carrello.aspx" class="btn btn-success">Dettaglio</a>
            <asp:Repeater ID="RepeaterBackoffice" runat="server">
                <ItemTemplate>
                    <div class="col-3 mb-3">
                        <div class="card h-100">
                            <div class="d-flex flex-column">
                                <div class="d-flex">
                                    <img style="width: 100px; height: 150px;" src='<%# Eval("Immagine") %>' class="card-img-top" alt='<%# Eval("Nome") %>' />
                                    <div class="card-body">
                                        <h5 class="card-title fw-bold"><%# Eval("Nome") %></h5>
                                        <p class="card-text"><%# Eval("Dettagli") %></p>
                                        <p class="card-text fw-bold fs-3"><%# Eval("Prezzo") %></p>
                                    </div>
                                </div>
                                <div class="d-flex justify-content-around align-items-center p-3">
                                    <asp:Button ID="AcquistaBtnHome" runat="server" Text="Aggiungi al carrello" CommandArgument='<%# Eval("Id") %>' OnClick="AddToCart" class="btn btn-success" />
                                    <a href='<%# "Dettaglio.aspx?product=" + Eval("Id") %>' class="btn btn-success">Dettaglio</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
