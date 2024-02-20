<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackOffice.aspx.cs" Inherits="BuildWeekMattia.BackOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        BACKOFFICE
        <asp:Button ID="Button3" runat="server" Text="Aggiungi" />
        <asp:Repeater ID="RepeaterBackoffice" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="d-flex">
                        <div class="col d-flex">
                            <img style="width: 100px; height: 120px;" src="<%# Eval("Immagine") %>" />
                            <textarea id="Nametxt" class="form-control" type="text"><%# Eval("Nome") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Desctxt" class="form-control" type="text" style="word-wrap: break-word;"><%# Eval("Descrizione") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Detailstxt" class="form-control" type="text" style="word-wrap: break-word;"><%# Eval("Dettagli") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Pricetxt" class="form-control" type="text"><%# Eval("Prezzo")+"€" %></textarea>
                        </div>
                        <%--<a href='<%# "Dettagli.aspx/" + Eval("Idoggetto") %>' class="btn btn-primary">Dettagli</a>--%>
                        <div class="col">
                            <asp:Button ID="Mod" runat="server" Text="Modifica" UseSubmitBehavior="false" CommandName="Mod" CommandArgument='<%# Eval("Id") %>' OnClick="Mod_Click" />
                            <asp:Button ID="DelBtn" runat="server" Text="Rimuovi" UseSubmitBehavior="false" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="DelBtn_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>



    </form>
</body>
</html>
