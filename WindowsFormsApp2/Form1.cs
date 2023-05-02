using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        class MyEA : EventArgs
        {
            public char ch;
            public int htw;
        }
        
        class MyEH
        {
            public event EventHandler <MyEA> Ez;
            public void OnEz(MyEA c)
            {
                if (Ez != null) 
                    Ez(this, c);
                
            }
        }
        public static bool flag = false;
        char[] symb = { 'R', 'G', 'B', 'Y' };
        int[] height = { 150, 200, 250, 300 };
        public Form1()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyEH met = new MyEH();
            int i = comboBox1.SelectedIndex;
            MyEA e1 = new MyEA();
            e1.ch = symb[i];
            e1.htw = height[i];
            if (flag)
                met.Ez += BackColorChanged;
            else
                met.Ez -= BackColorChanged;
            met.OnEz(e1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                button1.Text = "Изменение цвета формы разрешить!";
            }
            else
            {
                flag = true;
                button1.Text = "Изменение цвета формы запретить!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyEH met = new MyEH();
            MyEA e2 = new MyEA();
            e2.ch = 'Y';
            e2.htw = height[3];
            met.Ez += BackColorChanged;
            met.OnEz(e2);
        }

        private void BackColorChanged(object sender, MyEA e)
        {
            switch(e.ch)
            {
                case 'R':
                    {
                        this.BackColor = Color.Red;
                        this.Height = height[0];
                        this.Width = 350 + height[0];
                        break;
                    }
                case 'G':
                    {
                        this.BackColor= Color.Green;
                        this.Height = height[1];
                        this.Width = 350 + height[1];
                        break;
                    }
                case 'B':
                    {
                        this.BackColor= Color.Blue;
                        this.Height = height[2];
                        this.Width = 350 + height[2];
                        break;
                    }
                case 'Y':
                    {
                        this.BackColor= Color.Yellow;
                        this.Height = height[3];
                        this.Width = 350 + height[3];
                        break;
                    }
                default:
                    break;
            }
        }
        
    }
}
