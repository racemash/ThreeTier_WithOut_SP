using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace myfirstApp.App_Code
{
    public class StudDalcs
    {

        StudProp p = new StudProp();
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        DataSet ds;

        public StudDalcs()
        {
            //
            // TODO: Add constructor logic here
            //
            cn = new SqlConnection(@"Data Source=TRUPTI-PC\SQLEXPRESS;Initial Catalog=crud;Integrated Security=True");
        }
        public void insert(StudProp data)
        {
            cmd = new SqlCommand("insert into student (name) values (@nm)", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@nm", data.name);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void update(StudProp data)
        {
            cmd = new SqlCommand("update student set name=@nm where id= @id", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id",data.id);
            cmd.Parameters.AddWithValue("@nm", data.name);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void delete(StudProp data)
        {
            cmd = new SqlCommand("delete from student where id=@id", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", data.id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public DataTable select()
        {
            adp = new SqlDataAdapter("Select * from student ", cn);
            adp.SelectCommand.CommandType = CommandType.Text;
            dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }



    }
}