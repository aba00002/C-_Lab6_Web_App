<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Registration</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
</head>
<body class ="body">
    <form id="form1" runat="server">
        <div>
            <h1>Algonquin College Course Registration</h1>

        </div>
        <p>
            Student Name:
            <asp:TextBox ID="TextBox1" runat="server" Class="input input:hover"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Program"  />
&nbsp;Full Time
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Program" />
&nbsp;Part Time
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Program" />
&nbsp;Co-op</p>
        <asp:Label ID="Label1" runat="server" Text="" Class="emphsis" ></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" Class=""></asp:Label>
        <br />
        <p> 
            <asp:Label ID="Label2" runat="server" Text="Following courses are available for registration"></asp:Label>
        </p>
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" onselectedindexchange="Addselected" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
        </asp:CheckBoxList>
        <asp:GridView ID="GridView1" runat="server" Height="225px" Width="599px" Class="table" GridLines="None">
        </asp:GridView>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" class="ViewCartButton ViewCartButton:hover"/>

    </form>
</body>
</html>
