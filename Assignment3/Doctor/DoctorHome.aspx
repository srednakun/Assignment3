<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorHome.aspx.cs" Inherits="Assignment3.Doctor.DoctorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Patient/Appointment.aspx" CssClass="auto-style2">Appointments</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Doctor/DoctorEmail.aspx" CssClass="auto-style2">Email</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style2" />
            <br />
        </p>
        <p>
            <span class="auto-style2">Welcome: <asp:LoginName ID="LoginName1" runat="server" />
            </span>
        </p>
        <p class="auto-style2">
            Doctor Name: <asp:Label ID="docNameLbl" runat="server" Text="Doc Name"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
        </p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>

