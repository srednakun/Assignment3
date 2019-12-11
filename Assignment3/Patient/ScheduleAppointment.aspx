<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleAppointment.aspx.cs" Inherits="Assignment3.Patient.ScheduleAppointment" %>
<%@ Reference VirtualPath="~/Patient/Appointment.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #333333;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            font-size: x-large;
            color: #0099FF;
        }
        .auto-style4 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="homeLink" runat="server" CssClass="auto-style4" NavigateUrl="~/Patient/PatentHome.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Patient/Appointment.aspx" CssClass="auto-style4">Appointments</asp:HyperLink>
        &nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style4" LogoutAction="Redirect" LogoutPageUrl="~/Home.aspx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </p>
        <p>
            &nbsp;</p>
    <p>
        <span class="auto-style4">Hello,</span>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
    </p>
        <p>
            Your Doctor:
            <asp:Label ID="docLbl" runat="server" Text="Label"></asp:Label>
        <br />
    </p>
    <p>
        &nbsp;</p>
        <p>
            Select Department<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Department" DataValueField="Department" Width="121px" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            Select Doctor:<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" DataKeyNames="DoctorsId,FirstName,LastName,Location">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="DoctorsId" HeaderText="DoctorsId" InsertVisible="False" ReadOnly="True" SortExpression="DoctorsId" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p class="auto-style1">
            Select Date<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/newCalendar.png" OnClick="ImageButton1_Click" Width="48px" />
        </p>
        <p>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="330px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
        </p>
        <p class="auto-style1">
            Select Time<asp:DropDownList ID="DropDownListHour" runat="server" AutoPostBack="True" CssClass="auto-style2">
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListMin" runat="server" AutoPostBack="True">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListAMPM" runat="server" AutoPostBack="True" Width="94px">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="TimeLabel" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="NotificationLabel" runat="server" Text="Label" style="font-size: large; color: #FF3300"></asp:Label>
        </p>
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\Copy of Hospital.mdf&quot;;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" OnSelecting="SqlDataSource1_Selecting" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Department FROM DoctorsTable"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" OnSelecting="SqlDataSource2_Selecting" SelectCommand="SELECT FirstName, LastName, Location, Department, Email, DoctorsId FROM DoctorsTable WHERE (Department = @param)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="param" PropertyName="SelectedValue"/>
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Purpose of visit"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="AppointmentErrMsg" runat="server" style="text-align: center; color: #FF3300; font-size: x-large" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Make Appointment" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>
