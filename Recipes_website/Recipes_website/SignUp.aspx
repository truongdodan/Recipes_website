<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Recipes_website.WebForm7" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/loginsignup.css" />
    <script src="./Script/loginsignup.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate></ContentTemplate>
        </asp:UpdatePanel>
    <main>
        <h2>Đăng ký</h2>
        <div class="user-name-wrapper">
            <label for="email">Tên người dùng</label>
            <input type="text" id="userName" name="UserName" value="" placeholder="Chúng tôi nên gọi bạn là gì" required>
        </div>
        <div class="email-wrapper">
            <label for="email">Email</label>
            <input type="email" id="email" name="email" value="" required>
        </div>
        <div class="password-wrapper">
            <label for="password">Mật khẩu</label>
            <input
            type="password" id="password"
            name="password"
            value=""
            pattern="^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\W).{8,}$"
            title="Mật khẩu cần chứa 8 ký tự trở lên, ít nhất 1 chữ hoa, 1 chữ thường, 1 ký tự đặc biệt và 1 số!"
            required>
        </div>
        <div class="password-wrapper">
            <label for="password">Nhập lại mật khẩu</label>
            <input type="password" id="passwordConfirm" value=""  required>
            <p class="error-message-signup">*Mật khẩu không trùng khớp với mật khẩu ban đầu!</p>   
            <div class="password-toggle-wrapper">
                <label for="togglePassword">Hiện mật khẩu</label>
                <input type="checkbox" id="togglePassword" onclick="showPassword()">
            </div>
        </div>
        <div class="sign-in-button">
            <asp:Button 
                runat="server" 
                ID="signInButton" 
                Text="Đăng tải" 
                OnClick="signUpButton_Click"
                OnClientClick="return checkConfirmPassword(event);" />
        </div>
        <div class="sign-up-wrapper">Bạn đã có tài khoản? <a href="./Login.aspx">Đăng nhập</a></div>
        <div class="signup-success-notification" runat="server" id="signUpSuccessFulNofitication">Tạo tài khoản thành công</div>

    </main>
</asp:Content>
