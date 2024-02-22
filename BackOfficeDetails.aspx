<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Templates/BaseTemplate.Master" CodeBehind="BackOfficeDetails.aspx.cs" Inherits="BuildWeekMattia.BackOfficeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex">

            <div class="col-2 d-flex align-items-center">
                <img id="imgurl" runat="server" style="width: 100px; height: 120px;" src="" />

            </div>
            <div class="col-10">
                <div class="row">
                    Url Immagine:<asp:TextBox ID="Urltxt" runat="server" Style="height: 50px;" Text='' />
                </div>
                <div class="row">
                    Descrizione:<asp:TextBox ID="Desctxt" runat="server" Style="height: 50px;" Text='' />
                </div>
                <div class="row">
                    Nome:<asp:TextBox ID="Nametxt" runat="server" Style="height: 50px;" Text='' />
                </div>
                <div class="row">
                    Dettagli:<asp:TextBox ID="Dettxt" runat="server" Style="height: 50px;" Text='' />
                </div>
                <div class="row">
                    Prezzo(in €):<asp:TextBox ID="Pricetxt" runat="server" Style="height: 50px;" Text='' />
                </div>

            </div>

        </div>



        <asp:Button ID="Mod" runat="server" Text="Modifica" CommandName="Mod" CommandArgument='' OnClick="Mod_Click" />
        <asp:Button ID="DelBtn" runat="server" Text="Rimuovi" UseSubmitBehavior="false" CommandName="Delete" CommandArgument='' OnClick="DelBtn_Click" />


    </div>
</asp:Content>
