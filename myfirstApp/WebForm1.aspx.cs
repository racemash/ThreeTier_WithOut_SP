using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myfirstApp.App_Code;

namespace myfirstApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        StdBBAL bal = new StdBBAL();
        StudProp prop = new StudProp();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillgrid();
            }
        }

        private void fillgrid()
        {
            GridView1.DataSource = bal.getStudents();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            prop.name = TextBox1.Text;
            bal.insertData(prop);
            fillgrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            prop.id = Convert.ToInt16(((TextBox)row.Cells[0].Controls[0]).Text);
            prop.name=((TextBox)row.Cells[1].Controls[0]).Text;
            bal.updateData(prop);
            GridView1.EditIndex = -1;
            fillgrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            fillgrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fillgrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            prop.id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value.ToString());
            bal.deleteData(prop);
            fillgrid();
        }
    }
}