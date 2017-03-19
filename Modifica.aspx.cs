using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class Modifica : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string txt = "select * from Cont where Id_cont=@id";
            // deschiderea conexiunii. Poate arunca Exceptie daca nu reuseste
            conn.Open();
            //crearea comenzi SQL
            SqlCommand cmd = new SqlCommand(txt, conn);
            cmd.Parameters.Add(new SqlParameter("@id", TypeCode.Int32));
            cmd.Parameters["@id"].Value = int.Parse(Request.QueryString["id_cont"].ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = reader.GetValue(0).ToString();
                TextBox2.Text = reader.GetValue(1).ToString(); //id_persoana
                TextBox3.Text = reader.GetValue(2).ToString(); //banca
                TextBox4.Text = reader.GetValue(3).ToString(); //..
                TextBox5.Text = reader.GetValue(4).ToString();
                TextBox6.Text = reader.GetValue(5).ToString();
         

            }
            conn.Close();
        }
        catch { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string txt = "Update Cont set  Banca = @banca ,Sold = @sold,Unitate=@unitate,Data_deschiderii=@data_d where Id_cont=@id";
            // deschiderea conexiunii. Poate arunca Exceptie daca nu reuseste
            conn.Open();
            //crearea comenzi SQL
            SqlCommand cmd = new SqlCommand(txt, conn);
            cmd.Parameters.Add(new SqlParameter("@id", TypeCode.Int32));
            cmd.Parameters["@id"].Value = int.Parse(Request.QueryString["id_cont"].ToString());
            cmd.Parameters.Add(new SqlParameter("@banca", TypeCode.String));
            cmd.Parameters["@banca"].Value = TextBox3.Text;
            cmd.Parameters.Add(new SqlParameter("@sold", TypeCode.String));
            cmd.Parameters["@sold"].Value = TextBox4.Text;
            cmd.Parameters.Add(new SqlParameter("@unitate", TypeCode.String));
            cmd.Parameters["@unitate"].Value = TextBox5.Text;
            cmd.Parameters.Add(new SqlParameter("@data_d", TypeCode.String));
            cmd.Parameters["@data_d"].Value = TextBox6.Text;

            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Show.aspx");
        }
        catch { }
    }

}
