using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string txt = "INSERT into Cont(Id_cont,Id_persoana,Banca,Sold,Unitate,Data_deschiderii) values (@idcont,@idpers,@banca,@sold,@unitate,@data)";
            // deschiderea conexiunii. Poate arunca Exceptie daca nu reuseste
            conn.Open();
            //crearea comenzi SQL
            SqlCommand cmd = new SqlCommand(txt, conn);
            cmd.Parameters.Add(new SqlParameter("@idcont", TypeCode.Int32));
            cmd.Parameters["@idcont"].Value = TextBox1.Text;
            cmd.Parameters.Add(new SqlParameter("@idpers", TypeCode.Int32));
            cmd.Parameters["@idpers"].Value = TextBox2.Text;
            cmd.Parameters.Add(new SqlParameter("@banca", TypeCode.Int32));
            cmd.Parameters["@banca"].Value = TextBox3.Text;
            cmd.Parameters.Add(new SqlParameter("@sold", TypeCode.Int32));
            cmd.Parameters["@sold"].Value = TextBox4.Text;
            cmd.Parameters.Add(new SqlParameter("@unitate", TypeCode.Int32));
            cmd.Parameters["@unitate"].Value = TextBox5.Text;
            cmd.Parameters.Add(new SqlParameter("@data", TypeCode.DateTime));
            cmd.Parameters["@data"].Value = DateTime.Parse(TextBox6.Text);
            
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("Show.aspx");
        }
        catch
        {
            //Better do something with the exception... but not now
        }
    }
}