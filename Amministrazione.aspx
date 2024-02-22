<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Templates/BaseTemplate.Master" CodeBehind="Amministrazione.aspx.cs" Inherits="BuildWeekMattia.Amministrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Amministrazione</h2>
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
        Aggiungi Nuovo Articolo
    </button>
    <asp:Repeater ID="RepeaterBackoffice" runat="server">
        <ItemTemplate>
            <div class="row">
                <div class="d-flex">
                    <div class="col d-flex">
                        <img style="width: 100px; height: 120px;" src="<%# Eval("Immagine") %>" />
                        <textarea id="Nametxt" class="form-control" type="text"><%# Eval("Nome") %></textarea>
                    </div>
                    <div class="col">
                        <textarea style="height: 120px;" id="Desctxt" class="form-control" type="text"><%# Eval("Descrizione") %></textarea>
                    </div>
                    <div class="col">
                        <textarea style="height: 120px;" id="Detailstxt" class="form-control" type="text"><%# Eval("Dettagli") %></textarea>
                    </div>
                    <div class="col">
                        <textarea style="height: 120px;" id="Pricetxt" class="form-control" type="text"><%# Eval("Prezzo")+"€" %></textarea>
                    </div>
                    <div class="col">
                        <asp:Button ID="Mod" runat="server" Text="Modifica" UseSubmitBehavior="false" CommandName="Mod" CommandArgument='<%# Eval("Id") %>' OnClick="Mod_Click" />
                        <asp:Button ID="DelBtn" runat="server" Text="Rimuovi" UseSubmitBehavior="false" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="DelBtn_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>



    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Aggiungi Articolo</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="d-flex">
                        <p style="width: 120px;">Nome Prodotto:</p>
                        <asp:TextBox ID="TextBoxNome" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex">
                        <p style="width: 120px;">Descrizione:</p>
                        <asp:TextBox ID="TextBoxDescrizione" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex">
                        <p style="width: 120px;">Dettagli:</p>
                        <asp:TextBox ID="TextBoxDettagli" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex">
                        <p style="width: 120px;">Prezzo:</p>
                        <asp:TextBox ID="TextBoxPrezzo" runat="server"></asp:TextBox>
                    </div>
                    <div class="d-flex">
                        <p style="width: 120px;">Immagine:</p>
                        <asp:TextBox ID="TextBoxImg" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button runat="server" ID="SaveChanges" OnClick="SaveChanges_Click" class="btn btn-primary" Text="Save Changes"></asp:Button>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
