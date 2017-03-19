using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            string txt = "delete from Cont where Id_cont=@id";
            // deschiderea conexiunii. Poate arunca Exceptie daca nu reuseste
            conn.Open();
            //crearea comenzi SQL
            SqlCommand cmd = new SqlCommand(txt, conn);
            cmd.Parameters.Add(new SqlParameter("@id", TypeCode.Int32));
            cmd.Parameters["@id"].Value = int.Parse(Request.QueryString["id_cont"].ToString());
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("Show.aspx");
        }
        catch { }
    }
}
