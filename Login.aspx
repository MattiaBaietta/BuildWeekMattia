<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/LoginRegistrazioneTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="mb-3">
    <label for="indirzzoEmail" class="form-label">E-mail</label>
    <input type="email" class="form-control" id="indirizzoEmail" name="indirizzoEmail">
  </div>
  <div class="mb-3">
    <label for="passwordUtente" class="form-label">Password</label>
    <input type="password" class="form-control" id="passwordUtente" name="passwordUtente">
  </div>
    <div class="mb-2 d-flex">
        <p class="me-2">Non hai un'account?</p>
        <a class="link-opacity-100" href="Registrazione.aspx">Registrati ora</a>
    </div>
  <button type="submit" class="btn btn-success">Login</button>

</asp:Content>
