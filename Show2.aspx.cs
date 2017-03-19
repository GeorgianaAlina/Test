using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Show2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get_id_persoana();
        }
        vizualizare_inregistrare();
    }

    protected void get_id_persoana()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select distinct Id_persoana from Cont", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        DropDownList1.DataSource = dr;
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("--Please select item --");
        DropDownList1.DataTextField = "Id_persoana";
        DropDownList1.DataValueField = "Id_persoana";
        DropDownList1.DataBind();
        conn.Close();
    }

    protected void vizualizare_inregistrare()
    {
        
        string txt = string.Format("select Cont.Id_cont,Cont.Banca,Cont.Sold,Cont.Unitate,Cont.Data_deschiderii from  Cont where Cont.id_persoana = '" + DropDownList1.SelectedValue + "' ");
        //0 id_persoana si 1-id_cont
        conn.Open();
        SqlCommand cmd = new SqlCommand(txt, conn);
        //diferenta este ca folosim ExecuteReader()
        SqlDataReader reader = cmd.ExecuteReader();

        //si acum trebuie sa facem ceva cu datele obtinute. Trebuie sa generam cod HTML
        FillTable(reader);

        conn.Close();
    }

    private void FillTable(SqlDataReader reader)
    {
        // clear but keep the header . Am folosit un ASP table cu numele Table1.
        TableRow th = Table1.Rows[0];
        Table1.Rows.Clear();
        Table1.Rows.Add(th);
        //adaugam liniile pe rand
        while (reader.Read())
        {
            TableRow row = new TableRow();

            TableCell banca = new TableCell();
            banca.Text = reader.GetValue(1).ToString();
            row.Cells.Add(banca);

            TableCell sold = new TableCell();
            sold.HorizontalAlign = HorizontalAlign.Center;
            sold.Text = reader.GetValue(2).ToString();
            row.Cells.Add(sold);

            TableCell unitate = new TableCell();
            unitate.HorizontalAlign = HorizontalAlign.Center;
            unitate.Text = reader.GetValue(3).ToString();
            row.Cells.Add(unitate);

            TableCell data_deschiderii = new TableCell();
            data_deschiderii.HorizontalAlign = HorizontalAlign.Center;
            data_deschiderii.Text = reader.GetValue(4).ToString();
            row.Cells.Add(data_deschiderii);

            TableCell modifica = new TableCell();
            HyperLink mod = new HyperLink();
            mod.Text = "Modifica";
            mod.NavigateUrl = string.Format("Modifica.aspx?id_cont={0}", reader.GetValue(1));
            modifica.Controls.Add(mod);
            row.Cells.Add(modifica);

            TableCell delete = new TableCell();
            HyperLink del = new HyperLink();
            del.Text = "Sterge";
            del.NavigateUrl = string.Format("Delete.aspx?id_cont={0}", reader.GetValue(1));
            delete.Controls.Add(del);
            row.Cells.Add(delete);

            Table1.Rows.Add(row);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        vizualizare_inregistrare();
    }
}