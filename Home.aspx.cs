using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;



public partial class Home : System.Web.UI.Page
{
    // OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\SKP\Documents\Database1.mdb");
    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\SKP\Documents\Database1.mdb");
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        OleDbCommand cmd = new OleDbCommand("select * from Table1", con);
        OleDbDataAdapter olda = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();
        olda.Fill(dt);


        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        OleDbCommand cmd = con.CreateCommand();
        con.Open();
        cmd.CommandText = "Insert into Table1 (ENROLL_ID,MYNAME,MOBILE_NUMBER,AGE)Values('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + "," + TextBox4.Text + ")";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label1.Text = "Record Added Successfully";
        con.Close();   
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label1.Text = "";

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        OleDbCommand cmd = con.CreateCommand();
        con.Open();
        cmd.CommandText = "UPDATE Table1 set MYNAME = '" + TextBox2.Text + "',MOBILE_NUMBER = " + TextBox3.Text + ",AGE = " + TextBox4.Text + " where ENROLL_ID='" + TextBox1.Text + "'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label1.Text = "Record Changed Successfully";
        con.Close();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        OleDbCommand cmd = con.CreateCommand();
        con.Open();
        cmd.CommandText = "DELETE FROM Table1 where ENROLL_ID='" + TextBox1.Text + "'";
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label1.Text = "Record Deleted Successfully";
        con.Close();
    }
   
}