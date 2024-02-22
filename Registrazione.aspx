<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/LoginRegistrazioneTemplate.Master" AutoEventWireup="true" CodeBehind="Registrazione.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.Registrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <div class="col">
            <input type="text" class="form-control" placeholder="Nome" aria-label="Nome" name="nomeUtente">
        </div>
        <div class="col">
            <input type="text" class="form-control" placeholder="Cognome" aria-label="Cognome" name="cognomeUtente">
        </div>
    </div>
    <div class="mb-3">
        <label for="indirizzoEmail" class="form-label">E-mail</label>
        <input type="email" class="form-control" id="indirizzoEmail" name="indirizzoEmail">
    </div>
    <div class="mb-3">
        <label for="passwordUtente" class="form-label">Password</label>
        <input type="password" class="form-control" id="passwordUtente" name="passwordUtente">
    </div>
    <div class="mb-2 d-flex">
        <p class="me-2">Hai già un'account?</p>
        <a class="link-opacity-100" href="Login.aspx">Login</a>
    </div>
    <button type="submit" class="btn btn-success">Registrati</button>
</asp:Content>
