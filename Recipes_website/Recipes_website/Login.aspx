<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recipes_website.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/loginsignup.css" />
    <script src="./Script/loginsignup.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <main>
        <h2>Đăng nhập</h2>
        <div class="email-wrapper">
            <label for="email">Email</label>
            <input type="email" id="email" name="email" value="" placeholder="" required>
        </div>
        <div class="password-wrapper">
            <label for="password">Mật khẩu</label>
            <input type="password" id="password" name="password" placeholder="" value="" title="" required>
            <p class="error-message" runat="server" id="errorMessage">*Tài khoản hoặc mật khẩu không chính xác!</p>   
            <div class="password-toggle-wrapper">
                <label for="togglePassword">Hiện mật khẩu</label>
                <input type="checkbox" id="togglePassword" value="" onclick="showPassword()">
            </div>
        </div>
        <div class="sign-in-button">
            <asp:Button runat="server" ID="signInButton" Text="Đăng nhập" OnClick="signInButton_Click"/>
        </div>
        <div class="forget-password-wrapper"><a href="#">Quên mật khẩu?</a></div>
        <div class="sign-up-wrapper">Bạn chưa có tài khoản? <a href="SignUp.aspx">Tạo tài khoản</a></div>
    </main>
</asp:Content>
