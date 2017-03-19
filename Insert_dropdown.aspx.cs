using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Insert_dropdown : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get_id_persoana();
        }
       
    }

    protected void get_id_persoana()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Id_persoana from Cont", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        DropDownList1.DataSource = dr;
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("--Please select item --");
        DropDownList1.DataTextField = "Id_persoana";
        DropDownList1.DataValueField = "Id_persoana";
        DropDownList1.DataBind();
        conn.Close();
    }



    protected void Button1_Click(object sender, EventArgs e)
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
        cmd.Parameters["@idpers"].Value = DropDownList1.SelectedValue;

        cmd.Parameters.Add(new SqlParameter("@banca", TypeCode.Int32));
        cmd.Parameters["@banca"].Value = TextBox2.Text;
        cmd.Parameters.Add(new SqlParameter("@sold", TypeCode.Int32));
        cmd.Parameters["@sold"].Value = TextBox3.Text;
        cmd.Parameters.Add(new SqlParameter("@unitate", TypeCode.Int32));
        cmd.Parameters["@unitate"].Value = TextBox4.Text;
        cmd.Parameters.Add(new SqlParameter("@data", TypeCode.DateTime));
        cmd.Parameters["@data"].Value = DateTime.Parse(TextBox5.Text);

        cmd.ExecuteNonQuery();

        conn.Close();
        Response.Redirect("Show.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }
}