<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show2.aspx.cs" Inherits="Show2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p> Alege id ul persoanei</p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
         <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
         
                    <asp:TableHeaderCell> Banca </asp:TableHeaderCell> 
                    <asp:TableHeaderCell> Sold </asp:TableHeaderCell> 
                    <asp:TableHeaderCell> Unitate</asp:TableHeaderCell>  
                    <asp:TableHeaderCell> Data_deschiderii</asp:TableHeaderCell>  
            
         </asp:TableHeaderRow>
     
</asp:Table>
</asp:Content>

