using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChangeAccesionNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string prefixText = "'";
            string suffixText = "',";

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // 使用 Lines 屬性取得每一行的值
                string[] lines = textBox1.Lines;

                // 建立 StringBuilder 來儲存處理後的文字
                StringBuilder modifiedText = new StringBuilder();

                // 顯示每一行的值
                foreach (string line in lines)
                {
                    modifiedText.AppendLine(prefixText + line + suffixText);
                }

              
                // 刪除最後一行的 prefixText 和 suffixText
                if (modifiedText.Length >= prefixText.Length + suffixText.Length)
                {
                    modifiedText.Remove(modifiedText.Length - (prefixText.Length + suffixText.Length), prefixText.Length + suffixText.Length);
                }


                // 將處理後的文字輸出到 TextBox2
                textBox2.Text = modifiedText.ToString();

                // 取得 textBox2 目前的文字內容
                string text = textBox2.Text;
                int lastCommaIndex = text.LastIndexOf(',');

                if (lastCommaIndex >= 0)
                {
                    text = text.Substring(0, lastCommaIndex);
                }

                // 將修改後的文字輸出到 textBox2
                textBox2.Text = text;

                Clipboard.SetText(textBox2.Text);
                label3.Text = "流水號已複製!";
            }
            else
            {
                // TextBox 為空，顯示錯誤訊息                
                label3.Text = "請輸入流水號!";
                // 如果 TextBox1 沒有文字，則清空 TextBox2
                textBox2.Text = string.Empty;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label3.Text = "待轉換 ...";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




