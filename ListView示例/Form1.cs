using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView示例
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lv.View = View.Details;
            lv.Columns.Add("ID", 40, HorizontalAlignment.Center);
            lv.Columns.Add("姓名", 60,HorizontalAlignment.Center);
            lv.Columns.Add("性别", 40, HorizontalAlignment.Center);
            lv.Columns.Add("电话", 100, HorizontalAlignment.Center);
            lv.Columns.Add("籍贯", 50, HorizontalAlignment.Center);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定义新Item变量
            ListViewItem i_item = lv.Items.Add((lv.Items.Count + 1) + "");//这个特别好，实现功能值得学习
            i_item.SubItems.Add(tbxName.Text); //添加姓名 
            i_item.SubItems.Add(cbbSex.Text);  //添加性别
            i_item.SubItems.Add(tbxPhone.Text);
            i_item.SubItems.Add(tbxAdd.Text);
            i_item.EnsureVisible();
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                tbxName.Text = lv.SelectedItems[0].SubItems[1].Text;
                cbbSex.Text = lv.SelectedItems[0].SubItems[2].Text;
                tbxPhone.Text = lv.SelectedItems[0].SubItems[3].Text;
                tbxAdd.Text = lv.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void cbbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //修改选定行数据
        private void button2_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                lv.SelectedItems[0].SubItems[1].Text = tbxName.Text;
                lv.SelectedItems[0].SubItems[2].Text = cbbSex.Text;
                lv.SelectedItems[0].SubItems[3].Text = tbxPhone.Text;
                lv.SelectedItems[0].SubItems[4].Text = tbxAdd.Text;
            }
        }
        //删除某选定行数据
        private void button3_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0) //如果选择了某行数据
            {
                lv.SelectedItems[0].Remove();//删除选定行
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lv.Items.Clear();
        }
        //查询所有行数据
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lv.Items.Count > 0) //列表有数据
            {
                foreach (ListViewItem lt in lv.Items) //轮询列表数据
                {
                    if (lt.SubItems[1].Text == textBox1.Text)
                    {
                        MessageBox.Show("存在该姓名");
                        return;
                    }
                }
                MessageBox.Show("未找到技能");
            }
            else//列表数据为空
                MessageBox.Show("为输入列表数据");
        }
    }
}
