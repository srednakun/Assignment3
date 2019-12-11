<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorEmail.aspx.cs" Inherits="Assignment3.Doctor.DoctorEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1207px;
        }
        .auto-style2 {
            width: 1207px;
            font-size: large;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            font-size: large;
            background-color: #99CCFF;
        }
        .auto-style5 {
            font-size: x-large;
        }
        .auto-style6 {
            width: 1207px;
            font-size: x-large;
            color: #3399FF;
        }
        .auto-style8 {
            width: 812px;
            font-size: large;
        }
        .auto-style9 {
            width: 812px;
            font-size: large;
            color: #000000;
        }
        .auto-style10 {
            width: 812px;
            font-size: large;
            height: 55px;
        }
        .auto-style11 {
            width: 1207px;
            font-size: large;
            height: 55px;
        }
        .auto-style12 {
            height: 55px;
        }
        .auto-style14 {
            width: 1207px;
            font-size: x-large;
            color: #000000;
        }
        .auto-style15 {
            width: 1207px;
            font-size: large;
            color: #000000;
        }
        .auto-style18 {
            width: 1207px;
            font-size: x-large;
            color: #3399FF;
            height: 17px;
        }
        .auto-style19 {
            width: 812px;
            font-size: large;
            color: #000000;
            height: 17px;
        }
        .auto-style20 {
            font-size: x-large;
            height: 17px;
        }
        .auto-style24 {
            width: 812px;
            font-size: large;
            height: 3px;
        }
        .auto-style25 {
            width: 1207px;
            font-size: large;
            height: 72px;
        }
        .auto-style26 {
            height: 72px;
        }
        .auto-style27 {
            width: 812px;
            font-size: large;
            height: 73px;
        }
        .auto-style28 {
            width: 1207px;
            font-size: large;
            height: 73px;
        }
        .auto-style29 {
            height: 73px;
        }
        .auto-style30 {
            width: 812px;
            font-size: x-large;
            height: 72px;
        }
        .auto-style31 {
            color: #0099FF;
            background-color: #FFFFFF;
        }
        .auto-style32 {
            width: 1207px;
            font-size: large;
            height: 3px;
        }
        .auto-style33 {
            height: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style5" NavigateUrl="~/Doctor/DoctorHome.aspx">Home</asp:HyperLink>
&nbsp;&nbsp; <span class="auto-style5">&nbsp;&nbsp; </span>
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style5" LogoutAction="Redirect" LogoutPageUrl="~/Home.aspx" />
            <br />
            <table style="width: 100%; height: 353px;">
                <tr>
                    <td class="auto-style9"><strong>You are logged in as:</strong>&nbsp;
                        <asp:LoginName ID="LoginName1" runat="server" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style19"><strong>Doctor Name:</strong>
                        <asp:Label ID="DocNameLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style20"></td>
                </tr>
                <tr>
                    <td class="auto-style9">View your messages</td>
                    <td class="auto-style15">View your sent messages</td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style14">
                        <asp:GridView ID="GridView2" runat="server" CssClass="auto-style3">
                        </asp:GridView>
                    </td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td class="auto-style30"><strong><span class="auto-style31">Send message to your Patient</span></strong></td>
                    <td class="auto-style25">&nbsp;</td>
                    <td class="auto-style26"><strong></strong></td>
                </tr>
                <tr>
                    <td class="auto-style24"><strong></strong></td>
                    <td class="auto-style32"></td>
                    <td class="auto-style33"><strong></strong></td>
                </tr>
                <tr>
                    <td class="auto-style8"><strong>From: </strong>
                        <asp:Label ID="fromDocNameLbl" runat="server" Text="Doctor Name"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong><span class="auto-style3">To</span></strong><span class="auto-style3">:&nbsp;
                        <asp:Label ID="toPatientLbl" runat="server" Text="Patient"></asp:Label>
                        </span></td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style8"><strong>Date: </strong>
                        <asp:Label ID="dateLbl" runat="server" Text="Date"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style27"><strong>Message</strong>:</td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="msgTxtBox" runat="server" CssClass="auto-style3" Height="286px" Width="375px"></asp:TextBox>
                    </td>
                    <td class="auto-style1"><strong>
                        <asp:Label ID="notificationLbl" runat="server" Text="Notification" CssClass="auto-style5"></asp:Label>
                        </strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="sendMsgBtn" runat="server" CssClass="auto-style4" Text="Send Message" Width="384px" OnClick="sendMsgBtn_Click" />
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>