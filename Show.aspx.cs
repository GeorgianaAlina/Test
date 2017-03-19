using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Show : System.Web.UI.Page
{
    /* afisati toate conturile */
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            // string txt = string.Format("select * from Cont");
            string txt = string.Format("select Persoana.Id_persoana,Cont.Id_cont,Persoana.Nume , Persoana.Adresa,Cont.Banca,Cont.Sold,Cont.Unitate,Cont.Data_deschiderii from Persoana  inner join Cont on Cont.id_persoana = Persoana.id_persoana");
            //0 id_persoana si 1-id_cont
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(txt, conn);
      
            //diferenta este ca folosim ExecuteReader()
            SqlDataReader reader = cmd.ExecuteReader();
        
            //si acum trebuie sa facem ceva cu datele obtinute. Trebuie sa generam cod HTML
            FillTable(reader);
       
            conn.Close();
        }
        catch
        { }
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

            TableCell nume = new TableCell();
            nume.Text = reader.GetValue(2).ToString();

            row.Cells.Add(nume);

            TableCell adresa = new TableCell();
            adresa.Text = reader.GetValue(3).ToString();
            row.Cells.Add(adresa);

            TableCell banca = new TableCell();
            banca.Text = reader.GetValue(4).ToString();
            row.Cells.Add(banca);

            TableCell sold = new TableCell();
            sold.HorizontalAlign = HorizontalAlign.Center;
            sold.Text = reader.GetValue(5).ToString();
            row.Cells.Add(sold);

            TableCell unitate = new TableCell();
            unitate.HorizontalAlign = HorizontalAlign.Center;
            unitate.Text = reader.GetValue(6).ToString();
            row.Cells.Add(unitate);

            TableCell data_deschiderii = new TableCell();
            data_deschiderii.HorizontalAlign = HorizontalAlign.Center;
            data_deschiderii.Text = reader.GetValue(7).ToString();
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
}