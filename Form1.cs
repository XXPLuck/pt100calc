using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pt100calc
{
    public partial class Form1 : Form
    {
        double a = 3.9083e-03;
        double b = -5.77500E-07;
        double c = -4.18300E-12;
        double r = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //电阻到温度
            if (resi.Text.Length < 2)
                resi.Text = "18.52"; ;
            double resie = double.Parse(resi.Text.Trim());
            double temper = 0,res1,res2;
            int i;
            if (resie < 18.52)
                resi.Text = "18.52";
            resie = double.Parse(resi.Text.Trim());
            if (resie > 100)
            {
                temper = (-a + System.Math.Sqrt(a * a - 4 * b * (1 - resie / 100))) / 2 / b;
            }
            else
            {
                temper = (-a + System.Math.Sqrt(a * a - 4 * b * (1 - resie / 100))) / 2 / b;
                res1 = r * (1 + a * temper + b * temper * temper + c * (temper - r) * temper * temper * temper);
                for (i = 1; i < 10000; i++)
                {
                    temper += 0.01;
                    res2 = r * (1 + a * temper + b * temper * temper + c * (temper - r) * temper * temper * temper);
                    if (res1 <= resie && res2 > resie)
                    {
                        if ((resie - res1) < (res2 - resie))
                        {
                            temper -= 0.01;
                        }
                        break;
                    }
                    res1 = res2;
                }
            }
            tempe.Text = temper.ToString("0.00");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tempe.Text == "")
                return;
            //温度到电阻
            double temper = double.Parse(tempe.Text.Trim());
            double resis = 0;
            if (temper < 0)
            {
                resis = r * (1 + a * temper + b * temper * temper + c * (temper - r) * temper * temper * temper);
            }
            else
                resis = r * (1 + a * temper + b * temper * temper );
            resi.Text = resis.ToString("0.00");

        }

        private void tempe_TextChanged(object sender, EventArgs e)
        {
            if (tempe.Text == "-" || tempe.Text == "")
                return;
            double temper = double.Parse(tempe.Text.Trim());
            if (temper > 850)
                tempe.Text = "850";
            if (temper < -200)
                tempe.Text = "-200";

        }

        private void tempe_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tsb = sender as TextBox;
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 0x2E)   //如果不是数字
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                if (tsb.Text.Length == 0)
                {
                    e.Handled = false;
                }
                else if (tsb.Text[0] == '-')
                {
                    tsb.Text = tsb.Text.Substring(1, tsb.Text.Length - 1);
                    e.Handled = true;
                    tsb.Select(tsb.Text.Length, 0);
                }
                else
                {
                    tsb.Text = '-' + tsb.Text;
                    e.Handled = true;
                    tsb.Select(tsb.Text.Length, 0);
                }
            }


            if (e.KeyChar == '.')
            {
                if (tsb.Text == "")
                {
                    tsb.Text = "0.";
                    tsb.Select(tsb.Text.Length, 0);   //将光标定位到textBox控件的末尾
                    e.Handled = true;
                }
                else if (tsb.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }


            if (tsb.Text.Length == 1 && tsb.Text[0] == '0' && (e.KeyChar != '.' || e.KeyChar != '-'))  //当出现连续数字时，去最前面的0
            {
                tsb.Text = e.KeyChar.ToString();
                e.Handled = true;
                tsb.Select(tsb.Text.Length, 0);
            }
            tsb.Focus();

            //光标定位到文本最后

            tsb.Select(tsb.TextLength, 0);
        }

        private void resi_TextChanged(object sender, EventArgs e)
        {
            if (resi.Text.Length < 3)
                return;
            double resie = double.Parse(resi.Text.Trim());
            if (resie > 390.48)
                resi.Text = "390.48";
            if (resie < 18.52)
                resi.Text = "18.52";
        }

        private void resi_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tsb = sender as TextBox;
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 0x2E)   //如果不是数字
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                e.Handled = true;              
            }


            if (e.KeyChar == '.')
            {
                if (tsb.Text == "")
                {
                    tsb.Text = "0.";
                    tsb.Select(tsb.Text.Length, 0);   //将光标定位到textBox控件的末尾
                    e.Handled = true;
                }
                else if (tsb.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }


            if (tsb.Text.Length == 1 && tsb.Text[0] == '0' && (e.KeyChar != '.' || e.KeyChar != '-'))  //当出现连续数字时，去最前面的0
            {
                tsb.Text = e.KeyChar.ToString();
                e.Handled = true;
                tsb.Select(tsb.Text.Length, 0);
            }
            tsb.Focus();

            //光标定位到文本最后

            tsb.Select(tsb.TextLength, 0);

        }
    }
}
