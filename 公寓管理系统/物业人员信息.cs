﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 公寓管理系统
{
    public partial class 物业人员信息 : Form
    {
        private Panel panel1;
        private DataGridView dataGridView1;
        string nums =null;
        string names = null;
        string sexs =null;
        string flatnums = null;
        string companys = null;
        string con = null;
        DataGridViewTextBoxColumn s1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn s2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn s3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn s4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn s5 = new DataGridViewTextBoxColumn();
        public 物业人员信息(Panel panel1,DataGridView dataGridView,string con)
        {
            InitializeComponent();
            this.panel1 = panel1;
            this.dataGridView1 = dataGridView;
            this.con = con;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            panel1.Visible = true;
            dataGridView1.Visible = false;

            dataGridView1.EndEdit();
            dataGridView1.Columns.Remove(s1);
            dataGridView1.Columns.Remove(s2);
            dataGridView1.Columns.Remove(s3);
            dataGridView1.Columns.Remove(s4);
            dataGridView1.Columns.Remove(s5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void 物业人员信息_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            CenterToParent();

            button5.Enabled = false;
            dataGridView1.Visible = true;
            dataGridView1.Location = new Point(23, 24);
            dataGridView1.Size = new System.Drawing.Size(642, 300);

            //DataGridViewTextBoxColumn s1 = new DataGridViewTextBoxColumn();
            s1.HeaderText = "工作证号";
            dataGridView1.Columns.Add(s1);
           // DataGridViewTextBoxColumn s2 = new DataGridViewTextBoxColumn();
            s2.HeaderText = "姓名";
            dataGridView1.Columns.Add(s2);
           // DataGridViewTextBoxColumn s3 = new DataGridViewTextBoxColumn();
            s3.HeaderText = "性别";
            dataGridView1.Columns.Add(s3);
           // DataGridViewTextBoxColumn s4 = new DataGridViewTextBoxColumn();
            s4.HeaderText = "公寓号";
            dataGridView1.Columns.Add(s4);
            //DataGridViewTextBoxColumn s5 = new DataGridViewTextBoxColumn();
            s5.HeaderText = "物业公司";
            s5.Width = 200;
            dataGridView1.Columns.Add(s5);

            try
            {
                string connn = con;
                SqlConnection connec = new SqlConnection(connn);
                connec.Open();
                string sql2 = String.Format("select * from PMS order by 工作证号");
                SqlCommand command2 = new SqlCommand(sql2, connec);
                SqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    int i = dataGridView1.Rows.Add(Row);
                    this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                    this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                    this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                    this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                    this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                }
                reader.Close();
            }
            catch (Exception ss) { MessageBox.Show("数据库中缺少相应表！"); }
        }

        private void 物业人员信息_FormClosed(object sender, FormClosedEventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                int z = dataGridView1.RowCount - 1;
                dataGridView1.EndEdit();
                for (int s = 0; s < z; s++)
                {
                    if (dataGridView1.Rows[s].IsNewRow) break;
                    dataGridView1.Rows.RemoveAt(s--);
                }
                string connn = con;
                SqlConnection connec = new SqlConnection(connn);
                connec.Open();
                string num = textBox1.Text;
                string name = textBox2.Text;
                string sex = textBox3.Text;
                string flatnum = textBox4.Text;
                string company = textBox5.Text;

                string sqls = String.Format("select * from PMS where 工作证号='{0}'", num);
                SqlCommand commands = new SqlCommand(sqls, connec);
                SqlDataReader readers = commands.ExecuteReader();
                if (readers.Read())
                {
                    MessageBox.Show("工作证号不能重复！");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();

                }
                else if (num == "" || name == "" || sex == "" || flatnum == "" || company == "")
                {
                    MessageBox.Show("请输入完整信息！");
                    this.textBox1.Focus();
                }
                else
                {
                    readers.Close();
                    string sql = String.Format("insert into PMS values('{0}','{1}','{2}','{3}','{4}')", num, name, sex, flatnum, company);
                    SqlCommand command = new SqlCommand(sql, connec);
                    int s = command.ExecuteNonQuery();
                    if (s > 0)
                    {
                        MessageBox.Show("增加成功！");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                    }
                }
                readers.Close();

                string sql2 = String.Format("select * from PMS");
                SqlCommand command2 = new SqlCommand(sql2, connec);
                SqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    int i = dataGridView1.Rows.Add(Row);
                    this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                    this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                    this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                    this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                    this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                }
                reader.Close();
            }
            catch (Exception ee) { MessageBox.Show("数据库中缺少相应的表！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                button5.Enabled = true;

                string num = textBox1.Text;
                string name = textBox2.Text;

                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                string connn = con;
                SqlConnection connec = new SqlConnection(connn);
                if (num != "" && name == "")
                {
                    string sql = String.Format("select * from PMS where 工作证号='{0}'", num);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nums = String.Format("{0}", reader[0]);
                        names= String.Format("{0}", reader[1]);
                        sexs = String.Format("{0}", reader[2]);
                        flatnums= String.Format("{0}", reader[3]);
                        companys = String.Format("{0}", reader[4]);
                        textBox1.Text = String.Format("{0}", reader[0]);
                        textBox2.Text = String.Format("{0}", reader[1]);
                        textBox3.Text = String.Format("{0}", reader[2]);
                        textBox4.Text = String.Format("{0}", reader[3]);
                        textBox5.Text = String.Format("{0}", reader[4]);
                    }
                    reader.Close();
                }
                else if (num != "" && name != "")
                {
                    string sql = String.Format("select * from PMS where 工作证号='{0}' and 姓名='{1}'", num, name);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        nums = String.Format("{0}", reader[0]);
                        names = String.Format("{0}", reader[1]);
                        sexs = String.Format("{0}", reader[2]);
                        flatnums = String.Format("{0}", reader[3]);
                        companys = String.Format("{0}", reader[4]);
                        textBox1.Text = String.Format("{0}", reader[0]);
                        textBox2.Text = String.Format("{0}", reader[1]);
                        textBox3.Text = String.Format("{0}", reader[2]);
                        textBox4.Text = String.Format("{0}", reader[3]);
                        textBox5.Text = String.Format("{0}", reader[4]);
                    }
                    reader.Close();
                }
                else 
                {
                    MessageBox.Show("请输入(工作证号)或(工作证号+姓名)");
                    textBox1.Focus();
                }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;

            string num1 = textBox1.Text;
            string name1 = textBox2.Text;
            string sex1 = textBox3.Text;
            string flatnum1 = textBox4.Text;
            string company1 = textBox5.Text;

            string connn = con;
            SqlConnection connec = new SqlConnection(connn);
            connec.Open();
            string[] m = new string[5];
            if (!num1.Equals(nums)) { m[0] = textBox1.Text; } else m[0] = " ";
            if (!name1.Equals(names)) { m[1] = textBox2.Text; } else m[1] = " ";
            if (!sex1.Equals(sexs)) { m[2] = textBox3.Text; } else m[2] = " ";
            if (!flatnum1.Equals(flatnums)) { m[3] = textBox4.Text; } else m[3] = " ";
            if (!company1.Equals(companys)) { m[4] = textBox5.Text; } else m[4] = " ";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("请选择要修改的记录！");
            }
            else
            {
                for (int w = 0; w < m.Length; w++)
                {
                    if (m[w] != " ")
                    {
                        if (w == 0)
                        {
                            string sql = String.Format("update PMS set 工作证号='{0}' where 工作证号='{1}'", num1, nums);
                            SqlCommand command = new SqlCommand(sql, connec);
                            command.ExecuteNonQuery();
                            nums = num1;
                        }
                        else if (w == 1)
                        {
                            
                            string sql = String.Format("update PMS set 姓名='{0}' where 工作证号='{1}'", name1, nums);
                            SqlCommand command = new SqlCommand(sql, connec);
                            command.ExecuteNonQuery();
                        }
                        else if (w == 2)
                        {
                            string sql = String.Format("update PMS set 性别='{0}' where 工作证号='{1}'", sex1, nums);
                            SqlCommand command = new SqlCommand(sql, connec);
                            command.ExecuteNonQuery();
                        }
                        else if (w == 3)
                        {
                            string sql = String.Format("update PMS set 公寓号='{0}' where 工作证号='{1}'", flatnum1, nums);
                            SqlCommand command = new SqlCommand(sql, connec);
                            command.ExecuteNonQuery();
                        }
                        else if (w == 4)
                        {
                            string sql = String.Format("update PMS set 物业公司='{0}' where 工作证号='{1}'", company1, nums);
                            SqlCommand command = new SqlCommand(sql, connec);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            int i = dataGridView1.RowCount - 1;
            dataGridView1.EndEdit();
            for (int s = 0; s < i; s++)
            {
                if (dataGridView1.Rows[s].IsNewRow) break;
                dataGridView1.Rows.RemoveAt(s--);
            }

            string sql2 = String.Format("select * from PMS order by 工作证号");
            SqlCommand command2 = new SqlCommand(sql2, connec);
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                DataGridViewRow Row = new DataGridViewRow();
                int s = dataGridView1.Rows.Add(Row);
                this.dataGridView1.Rows[s].Cells[0].Value = String.Format("{0}", reader[0]);
                this.dataGridView1.Rows[s].Cells[1].Value = String.Format("{0}", reader[1]);
                this.dataGridView1.Rows[s].Cells[2].Value = String.Format("{0}", reader[2]);
                this.dataGridView1.Rows[s].Cells[3].Value = String.Format("{0}", reader[3]);
                this.dataGridView1.Rows[s].Cells[4].Value = String.Format("{0}", reader[4]);
            }
            reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int result;
            string connn = con;
            SqlConnection connec = new SqlConnection(connn); 
            connec.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("请选择要删除的记录！");
                textBox1.Focus();
            }
            else
            {
                string sql = String.Format("delete from PMS where 工作证号='{0}'", nums);
                SqlCommand command = new SqlCommand(sql, connec);
                result = command.ExecuteNonQuery();
                if (result > 0) MessageBox.Show("删除成功！");
            }
            int i = dataGridView1.RowCount - 1;
            dataGridView1.EndEdit();
            for (int s = 0; s < i; s++)
            {
                if (dataGridView1.Rows[s].IsNewRow) break;
                dataGridView1.Rows.RemoveAt(s--);
            }
            string sql2 = String.Format("select * from PMS order by 工作证号");
            SqlCommand command2 = new SqlCommand(sql2, connec);
            SqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                DataGridViewRow Row = new DataGridViewRow();
                int s = dataGridView1.Rows.Add(Row);
                this.dataGridView1.Rows[s].Cells[0].Value = String.Format("{0}", reader[0]);
                this.dataGridView1.Rows[s].Cells[1].Value = String.Format("{0}", reader[1]);
                this.dataGridView1.Rows[s].Cells[2].Value = String.Format("{0}", reader[2]);
                this.dataGridView1.Rows[s].Cells[3].Value = String.Format("{0}", reader[3]);
                this.dataGridView1.Rows[s].Cells[4].Value = String.Format("{0}", reader[4]);
            }
            reader.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

    }
}
