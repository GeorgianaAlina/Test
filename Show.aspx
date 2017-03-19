<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
                    <asp:TableHeaderCell> Nume </asp:TableHeaderCell> 
                    <asp:TableHeaderCell> Adresa </asp:TableHeaderCell> 
                    <asp:TableHeaderCell> Banca </asp:TableHeaderCell>  
                    <asp:TableHeaderCell> Sold</asp:TableHeaderCell>  
                    <asp:TableHeaderCell> Unitate </asp:TableHeaderCell>  
                    <asp:TableHeaderCell> Data_deschiderii </asp:TableHeaderCell>  
       </asp:TableHeaderRow>
     
</asp:Table>
</asp:Content>


