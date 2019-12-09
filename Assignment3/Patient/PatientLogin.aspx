<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientLogin.aspx.cs" Inherits="Assignment3.Patient.PatientLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style1" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
    <form id="form1" runat="server">
        <div class="auto-style3">

            <br />
            <br />
            <span class="auto-style1">Patient Login <br />
            </span>
            <br />
            &nbsp;&nbsp;
           <br /><asp:Login ID="Login1" runat="server" TextLayout="TextOnTop">
            </asp:Login>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            *test username: patient1<br />
            *test password: patient1</div>
    </form>
</body>
</html>
