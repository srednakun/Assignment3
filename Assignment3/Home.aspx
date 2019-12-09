<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Assignment3.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style2">
    <span class="auto-style1">Hospital Online System</span></p>
<p class="auto-style2">
    &nbsp;</p>
<p class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Height="59px" Text="Patient" Width="299px" PostBackUrl="~/Patient/PatentHome.aspx" />
</p>
<p class="auto-style2">
                    <asp:Button ID="Button2" runat="server" Height="59px" Text="Doctor" Width="297px" PostBackUrl="~/Doctor/DoctorHome.aspx" />
                </p>
<p>
</p>
<p>
</p>
</asp:Content>
