using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Txt
{
    public partial class Form1 : Form
    {
        public string fname = "";
        public bool issave = false;
        public bool tchange = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void save()
        {
            if (fname == "")
            {
                saveFileDialog1.Title = "保存";
                this.saveFileDialog1.Filter = "文本文件|*.txt;";
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        issave = true;
                    }
                }
            }
            else
            {
                richTextBox1.SaveFile(fname, RichTextBoxStreamType.PlainText);
                issave = true;
            }
        }

        private void open()
        {
            openFileDialog1.Title = "打开";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "文本文件|*.txt;";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog1.FileName;
                richTextBox1.LoadFile(fname, RichTextBoxStreamType.PlainText);
                issave = false;
                tchange = false;
            }
        }

        private void osave()
        {
            saveFileDialog1.Title = "另存为";
            this.saveFileDialog1.Filter = "文本文件|*.txt;";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    issave = true;
                }
            }
        }

        private void isbsave()
        {
            if (issave == false && tchange == true)
            {
                if (MessageBox.Show("是否保存数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    save();
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            osave();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isbsave();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isbsave();
            richTextBox1.ResetText();
            issave = false;
            tchange = false;
            fname = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            tchange = true;
            issave = false;
        }

        private int GetStringLen(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] > 255)
                        len++;
                }
                return len;
            }
            return 0;
        }

        private void scriptstatus()
        {
            int row = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            int start = richTextBox1.GetFirstCharIndexOfCurrentLine();
            string s = richTextBox1.Text.Substring(start, richTextBox1.SelectionStart - start);
            int col = GetStringLen(s) + 1;
            toolStripStatusLabel1.Text = "第 " + row + " 行, 第 " + col + " 列";
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            scriptstatus();
        }

        private void statusBar()
        {
            if (状态栏ToolStripMenuItem.Checked = !状态栏ToolStripMenuItem.Checked)
            {
                statusStrip1.Visible = true;
                scriptstatus();
            }
            else
            {
                statusStrip1.Visible = false;
            }
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar();
        }

        private void textWordWrap()
        {
            if (自动换行ToolStripMenuItem.Checked = !自动换行ToolStripMenuItem.Checked)
            {
                richTextBox1.WordWrap = true;
            }
            else
            {
                richTextBox1.WordWrap = false;
            }
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textWordWrap();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                save();
            }

            if (e.Control && e.KeyCode == Keys.O)
            {
                open();
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                isbsave();
                richTextBox1.ResetText();
                issave = false;
                tchange = false;
                fname = "";
            }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = "";
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 日期ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DateTime dt;
            dt = DateTime.Now;
            richTextBox1.AppendText(dt.Year.ToString() + "年 " + dt.Month.ToString() + "月 " + dt.Day.ToString() + "日" + dt.Hour.ToString() + "时 " + dt.Minute.ToString() + "分");
        }
        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void 关于记事本ToolStripMenuItem_Click(object sender ,EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void 帮助LToolStripButton_Click(object sender,EventArgs e)
        {
            关于记事本ToolStripMenuItem_Click(sender,e);
        }
        private void Form1_Load(object sender, EventArgs e){}

        private void toolStripStatusLabel2_Click(object sender, EventArgs e){}

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = System.DateTime.Now.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int n;
            n = toolStrip1.Items.IndexOf(e.ClickedItem);
            switch(n)
            {
                case 0:
                    新建ToolStripMenuItem_Click(sender, e);
                    break;
                case 1:
                    打开ToolStripMenuItem_Click(sender, e);
                    break;
                case 2:
                    保存ToolStripMenuItem_Click(sender, e);
                    break;
                case 3:
                    关于记事本ToolStripMenuItem_Click(sender, e);
                    break;
                case 4:
                    剪切ToolStripMenuItem_Click(sender, e);
                    break;
                case 5:
                    粘贴ToolStripMenuItem_Click(sender, e);
                    break;
                case 7:
                    关于记事本ToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
    }
}
