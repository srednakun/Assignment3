<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="Assignment3.Patient.Appointment" %>

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
        }
        .auto-style3 {
            font-size: large;
            color: #0099FF;
        }
        .auto-style4 {
            color: #0099FF;
        }
        .auto-style5 {
            font-size: large;
        }
        .auto-style6 {
            color: #0099FF;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style1" />
        <br />
    </p>
        <p>
            &nbsp;</p>
    <p class="auto-style2">
        <span class="auto-style4">Hello</span>,<span class="auto-style3"> </span>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Label"></asp:Label>
        </p>
    <p>
        Current Appointments:</p>
    <p>
        &nbsp;</p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None" DataKeyNames="AppointmentId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Purpose" HeaderText="Purpose" SortExpression="Purpose" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                <asp:BoundField DataField="VisitSummary" HeaderText="VisitSummary" SortExpression="VisitSummary" />
                <asp:CommandField ButtonType="Button" SelectText="Delete" ShowSelectButton="True" />
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
        <asp:Label ID="NoAppointmentMsg" runat="server" CssClass="auto-style6" Text="Label"></asp:Label>
    <p class="auto-style2">
        &nbsp;</p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            &nbsp;</p>
        <p class="auto-style2">
            &nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style5" Height="78px" PostBackUrl="~/Patient/ScheduleAppointment.aspx" Text="Schedule Appointment" Width="415px" />
        </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" SelectCommand="SELECT * FROM [AppointmentsTable] WHERE ([PaitentID] = @PaitentID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label3" DefaultValue="0" Name="PaitentID" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
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
