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
    public partial class 住宿信息查询 : Form
    {
        private Panel panel;
        public string con = null;
        public 住宿信息查询(Panel panel,string con)
        {
            InitializeComponent();
            this.panel = panel;
            this.con = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            int z = dataGridView1.RowCount - 1;
            dataGridView1.EndEdit();
            for (int s = 0; s < z; s++)
            {
                if (dataGridView1.Rows[s].IsNewRow) break;
                dataGridView1.Rows.RemoveAt(s--);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            panel.Visible = true;
        }

        private void 住宿信息查询_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void 住宿信息查询_FormClosed(object sender, FormClosedEventArgs e)
        {
            panel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                string text = comboBox1.Text;
                string connn = con;
                SqlConnection connec = new SqlConnection(connn);
               
                if (text.Equals("学号"))
                {
                  
                    string sql = String.Format("select * from StudentMessage where 学号='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("姓名"))
                {
                    string sql = String.Format("select * from StudentMessage where 姓名='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("年级"))
                {
                    string sql = String.Format("select * from StudentMessage where 年级='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("班级"))
                {
                    string sql = String.Format("select * from StudentMessage where 班级='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("学院"))
                {
                    string sql = String.Format("select * from StudentMessage where 学院='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("系"))
                {
                    string sql = String.Format("select * from StudentMessage where 系='{0}'", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();                   
                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();
                }
                else if (text.Equals("专业"))
                {
                    string sql = String.Format("select * from StudentMessage where 专业='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }
                        reader.Close();

                }
                else if (text.Equals("寝室号"))
                {
                    string sql = String.Format("select * from StudentMessage where 寝室号='{0}' order by 学号", textBox1.Text);
                    SqlCommand command = new SqlCommand(sql, connec);
                    connec.Open();
                    int s = command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            DataGridViewRow Row = new DataGridViewRow();
                            int i = dataGridView1.Rows.Add(Row);                        
                            this.dataGridView1.Rows[i].Cells[0].Value = String.Format("{0}", reader[0]);
                            this.dataGridView1.Rows[i].Cells[1].Value = String.Format("{0}", reader[1]);
                            this.dataGridView1.Rows[i].Cells[2].Value = String.Format("{0}", reader[2]);
                            this.dataGridView1.Rows[i].Cells[3].Value = String.Format("{0}", reader[3]);
                            this.dataGridView1.Rows[i].Cells[4].Value = String.Format("{0}", reader[4]);
                            this.dataGridView1.Rows[i].Cells[5].Value = String.Format("{0}", reader[5]);
                            this.dataGridView1.Rows[i].Cells[6].Value = String.Format("{0}", reader[6]);
                            this.dataGridView1.Rows[i].Cells[7].Value = String.Format("{0}", reader[7]);
                            this.dataGridView1.Rows[i].Cells[8].Value = String.Format("{0}", reader[8]);
                            this.dataGridView1.Rows[i].Cells[9].Value = String.Format("{0}", reader[9]);
                            this.dataGridView1.Rows[i].Cells[10].Value = String.Format("{0}", reader[10]);
                        }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("请重新核对查询关键字！");
                    textBox1.Focus();
                }
            }
            catch (Exception ee) { MessageBox.Show("数据库中缺少相应的表！"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int z = dataGridView1.RowCount - 1;
            dataGridView1.EndEdit();
            for (int s = 0; s < z; s++)
            {
                if (dataGridView1.Rows[s].IsNewRow) break;
                dataGridView1.Rows.RemoveAt(s--);
            }
        }
    }
}
