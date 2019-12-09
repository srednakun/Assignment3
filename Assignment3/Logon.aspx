<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="Assignment3.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            text-align: center;
            font-size: x-large;
            color: #0099FF;
        }
    </style>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
    <p class="auto-style2">
        WELCOME TO ASP HOSPITAL</p>
        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style1" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="432px" Width="943px" OnAuthenticate="Login1_Authenticate">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Copy of HospitalConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT PatientTable.PatientID FROM UsersTable CROSS JOIN PatientTable WHERE (UsersTable.UserLoginName = @param1) AND (UsersTable.UserLoginPass = @param2) AND (UsersTable.UserLoginType = N'patient')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Login1" DbType="String" Name="param1" PropertyName="UserName" />
                    <asp:ControlParameter ControlID="Login1" Name="param2" PropertyName="PasswordLabelText" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <div>
        </div>
    </form>
</body>
</html>
