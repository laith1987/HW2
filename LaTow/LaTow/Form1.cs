using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaTow
{
    public partial class Form1 : Form
    {
        TowLayer layer;
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
           layer = new TowLayer();//inta
            layer.username=txtusernae.ToString();
            layer.pass = txtpassword.ToString();
            layer.conopass = txtconpass.ToString();
            layer.add();
            MessageBox.Show("add successfully");

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            layer = new TowLayer();//inta
            layer.username = txtusernae.ToString();
            layer.del();
            MessageBox.Show("del successfully");
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {

            layer = new TowLayer();//inta
            layer.username = txtusernae.ToString();
            layer.pass = txtpassword.ToString();
            layer.conopass = txtconpass.ToString();
            layer.edit();
            MessageBox.Show("edit successfully");

        }
    }
    public class oneLayer
    {
        static SqlConnection Connection = new SqlConnection("data source = DESKTOP-DELL\\SQLEXPRESS; initial catalog=IM; persist security info=True; Integrated Security = SSPI;");
        public static void add(TowLayer lib)
        {

            SqlCommand cmd = new SqlCommand("insert into  [user] (,[User],[password],[conpassword])Values(@User,@password,@conpassword)", Connection);
            cmd.Parameters.AddWithValue("@User", lib.username);
            cmd.Parameters.AddWithValue("@password", lib.pass);
            cmd.Parameters.AddWithValue("@conpassword", lib.conopass);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public static void edit(TowLayer lib)
        {
            SqlCommand cmd = new SqlCommand("Update user set ,[password]=@password,[conpassword]=@conpassword where [User]=@User", Connection);
            
            cmd.Parameters.AddWithValue("@Name_User", lib.username);
            cmd.Parameters.AddWithValue("@Password_User", lib.pass);
            cmd.Parameters.AddWithValue("@Email_User", lib.conopass);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

        }
        public static void delete(TowLayer lib)
        {
            SqlCommand cmd = new SqlCommand("delete from [user] where [User]=@User", Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

        }
    }
    public class TowLayer
    {
        
        public string username { get; set; }
        public string pass { get; set; }
        public string conopass { get; set; }
        public void add()
        {
            oneLayer.add(this);
        }public void edit()
        {
            oneLayer.edit(this );
        }public void del()
        {
            oneLayer.delete(this);
        }
    }
}
