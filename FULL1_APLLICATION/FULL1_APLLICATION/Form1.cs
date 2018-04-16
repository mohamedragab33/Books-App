using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FULL1_APLLICATION
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("Server=DESKTOP-C7AP5JN; DataBase=library; Integrated Security =true ; ");
        SqlCommand cmd;
        SqlDataAdapter da;

        SqlDataReader dr;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            da = new SqlDataAdapter("Select * From BOOKS3 ", cn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    cmd = new SqlCommand("Select ID,NAME,AUTHOR,DATA_PUBLISH From BOOKS3 Where ID ='" + searchtxt + "' ", cn);
            //    cn.Open();
            //    dr = cmd.ExecuteReader();
            //    dr.Read();
            //    IDtxt.Text = dr["ID"].ToString();
            //    nameTXT.Text = dr["NAME"].ToString();
            //    authorTXT.Text = dr["AUTHOR"].ToString();
            //    datetxt.Text = dr["DATA_PUBLISH"].ToString();
            //}
            //catch (Exception ex1)
            //{
            //    MessageBox.Show("ERROR MESSAGE ", "ERROR");
            //}
            //finally {
            //    dr.Close();
            //    cn.Close();
            //           }
            try
            {
                cmd = new SqlCommand("Select ID, NAME , AUTHOR, DATA_PUBLISH From BOOKS3 Where ID='" + searchtxt.Text + "'; ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IDtxt.Text = dr["ID"].ToString();
                nameTXT.Text = dr["NAME"].ToString();
                authorTXT.Text = dr["AUTHOR"].ToString();
                datetxt.Text = dr["DATA_PUBLISH"].ToString();
            }
            catch
            {
                MessageBox.Show("ERROR this ID NOT Found please try again", "ERROR");
            }
            finally
            {

                dr.Close();
                cn.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            try
            {

                cmd = new SqlCommand("insert into BOOKS3 (ID,NAME,AUTHOR,DATA_PUBLISH) values ('" + IDtxt.Text + "','" + nameTXT.Text + "','" + authorTXT.Text + "','" + datetxt.Value + "')", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter("Select ID, NAME , AUTHOR, DATA_PUBLISH From BOOKS3 Where ID='" + IDtxt.Text + "' ", cn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                searchtxt.Text = "";
                authorTXT.Text = "";
                nameTXT.Text = "";
                IDtxt.Text = "";


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
            finally { cn.Close(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchtxt.Text = "";
            authorTXT.Text = "";
            nameTXT.Text = "";
            IDtxt.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Delete from BOOKS3 Where ID='" + searchtxt.Text + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter("Select ID, NAME , AUTHOR, DATA_PUBLISH From BOOKS3 Where ID='" + IDtxt.Text + "' ", cn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                searchtxt.Text = "";
                authorTXT.Text = "";
                nameTXT.Text = "";
                IDtxt.Text = "";

            }
            catch
            {
                MessageBox.Show("Massive Error", "Error");

            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Update BOOKS3 Set ID='" + IDtxt.Text + "', NAME='" + nameTXT.Text + "', AUTHOR='" + authorTXT.Text + "', DATA_PUBLISH='" + datetxt.Value + "' Where ID='" + searchtxt.Text + "' ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter("Select ID, NAME , AUTHOR, DATA_PUBLISH From BOOKS3 Where ID='" + IDtxt.Text + "' ", cn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                searchtxt.Text = "";
                authorTXT.Text = "";
                nameTXT.Text = "";
                IDtxt.Text = "";
            }
            catch
            {
                MessageBox.Show("ERROR", "ERROR");
            }
            finally
            {
                cn.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
