using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace ResultSet
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=PRADEEP\\SQLEXPRESS;Initial Catalog=product;Integrated Security =true"))
            {
                SqlCommand cmd = new SqlCommand("select * from tblProductInventory; Select * from tblProductCatagories", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    while (rdr.NextResult())
                    {
                        GridView2.DataSource = rdr;
                        GridView2.DataBind();
                    }
                }

            }

        }
    }
}