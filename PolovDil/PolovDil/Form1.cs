using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolovDil
{
    public partial class Form1 : Form
    {
        double x,dx; int i, kmax;
          double f3(double x)
         {
             return x*x-Math.Pow((a*b)/2,b/2) ;
         }
         double f(double x)
        { 
             return Math.Pow(x, 2) - 4;
        }
         double f1(double x)
         {
             return Math.Sqrt(Math.Pow(x,4))-2;    
         }
         double f2(double x)
         {
             return 2*x-2;
         }     
        double fp(double x)
        {
            double ffp = (f(x + 0.0000001) - f(x)) / 0.0000001;
            return ffp;
        }
        double f2p(double x)
        {
            double ff2p = (fp(x + 0.0000001) - fp(x)) / 0.0000001;
            return ff2p;
        }
       
          double a = 0, b = 0, c = 0, fa,eps, fb, fc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
          try
          {
              a = Convert.ToDouble(textBox1.Text);
          }
          catch
          {

              MessageBox.Show(" Ви не ввели межу a! ", "Important Question", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
              textBox1.Clear();
          }
          try
          {
              b = Convert.ToDouble(textBox2.Text);
          }
          catch
          {
              MessageBox.Show(" Ви не ввели межу b! ", "Important Question", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
              textBox2.Clear();
          }
          try
          {
              eps = Convert.ToDouble(textBox3.Text);
          }
          catch
          {

              MessageBox.Show(" Ви не ввели точність eps! ", "Important Question", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
              textBox3.Clear();
          }
          try
          {
              if (comboBox1.SelectedIndex == 1)
              {
                  kmax = Convert.ToInt32(textBox4.Text);
              } 

          }
          catch
          {

              MessageBox.Show(" Ви не ввели кількість ітерацій kmax ! ", "Important Question", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
              textBox4.Clear();
              if (fa * fb > 0)
              {
                  MessageBox.Show("На цьому промiжку кореня не існує!!!  ERROR   ");
              }
          }
         textBox1.Clear();
          textBox2.Clear();
          textBox3.Clear();
          textBox4.Clear();
          label4.Text = "&X = ";
          if (comboBox1.SelectedIndex == 0)
          {
              label7.Text = "&N = ";
          }
          else
          {
              label7.Text = "&i = ";
          }
         this.BackColor = Color.MistyRose;
          groupBox2.Visible = true;
        } 
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Fa, Fb, Fc;  
           
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (comboBox2.SelectedIndex == 0)
                    {
                        int Lich = 0;
                        do
                        {
                            fa = Convert.ToDouble(f(a));
                            fb = Convert.ToDouble(f(b));
                            Fa = f(a);
                            Fb = f(b);
                            if (Math.Abs(Fa) <= eps)
                            {
                                c = a;
                                goto L_1;
                            }

                            if (Math.Abs(Fb) <= eps)
                            {
                                c = b;
                                goto L_1;
                            }
                            else
                            {
                                if (Lich > 2)
                                {
                                    MessageBox.Show("Протабулюйте функцію!GoodBye", "Important Question ", MessageBoxButtons.OK);
                                    Lich = Lich + 1;
                                }
                            }
                        }
                        while ((b < a) && (Fa * Fb > 0) && (eps < 0));
                        Lich = 0;
                        while ((b - a) > eps)
                        {
                            c = a + 0.5 * (b - a);
                            Lich++;
                            fc = Convert.ToDouble(f(c));
                            Fc = f(c);
                            if (Math.Abs(Fc) < eps)
                            {
                                goto L_1;
                            }
                            if (Fa * Fc > 0)
                            {
                                Fa = Fc; a = c;
                            }
                            else
                                b = c;
                        }
                        c = (a + 0.5 * (b - a)); 
                    L_1:
                    label4.Text = "&X = " + c.ToString();  
                    label7.Text = "&N = " + Lich.ToString();
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        int Lich = 0;
                        do
                        {
                            fa = Convert.ToDouble(f1(a));
                            fb = Convert.ToDouble(f1(b));
                            Fa = f1(a);
                            Fb = f1(b);
                            if (Math.Abs(Fa) <= eps)
                            {
                                c = a;
                                goto L_2;
                            }

                            if (Math.Abs(Fb) <= eps)
                            {
                                c = b;
                                goto L_2;
                            }
                            else
                            {
                                if (Lich > 2)
                                {
                                    MessageBox.Show("Протабулюйте функцію!GoodBye", "Important Question ", MessageBoxButtons.OK);
                                    Lich = Lich + 1;
                                }
                            }
                        }
                        while ((b < a) && (Fa * Fb > 0) && (eps < 0));
                        Lich = 0;
                        while ((b - a) > eps)
                        {
                            c = a + 0.5 * (b - a);
                            Lich++;
                            fc = Convert.ToDouble(f1(c));
                            Fc = f1(c);
                            if (Math.Abs(Fc) < eps)
                            {
                                goto L_2;
                            }
                            if (Fa * Fc > 0)
                            {
                                Fa = Fc; a = c;
                            }
                            else
                                b = c;
                        }
                        c = (a + 0.5 * (b - a));
                    L_2:
                        label4.Text = "&X = " + c.ToString();
                        label7.Text = "&N = " + Lich.ToString();
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        int Lich = 0;
                        do
                        {
                            fa = Convert.ToDouble(f2(a));
                            fb = Convert.ToDouble(f2(b));
                            Fa = f2(a);
                            Fb = f2(b);
                            if (Math.Abs(Fa) <= eps)
                            {
                                c = a;
                                goto L_3;
                            }

                            if (Math.Abs(Fb) <= eps)
                            {
                                c = b;
                                goto L_3;
                            }
                            else
                            {
                                if (Lich > 2)
                                {
                                    MessageBox.Show("Протабулюйте функцію!GoodBye", "Important Question ", MessageBoxButtons.OK);
                                    Lich = Lich + 1;
                                }
                            }
                        }
                        while ((b < a) && (Fa * Fb > 0) && (eps < 0));
                        Lich = 0;
                        while ((b - a) > eps)
                        {
                            c = a + 0.5 * (b - a);
                            Lich++;
                            fc = Convert.ToDouble(f2(c));
                            Fc = f2(c);
                            if (Math.Abs(Fc) < eps)
                            {
                                goto L_3;
                            }
                            if (Fa * Fc > 0)
                            {
                                Fa = Fc; a = c;
                            }
                            else
                                b = c;
                        }
                        c = (a + 0.5 * (b - a));
                    L_3:
                        label4.Text = "&X = " + c.ToString();
                        label7.Text = "&N = " + Lich.ToString();
                    }
                    if (comboBox2.SelectedIndex == 3)
                    {
                        int Lich = 0;
                        do
                        {
                            fa = Convert.ToDouble(f3(a));
                            fb = Convert.ToDouble(f3(b));
                            Fa = f3(a);
                            Fb = f3(b);
                            if (Math.Abs(Fa) <= eps)
                            {
                                c = a;
                                goto L_4;
                            }

                            if (Math.Abs(Fb) <= eps)
                            {
                                c = b;
                                goto L_4;
                            }
                            else
                            {
                                if (Lich > 2)
                                {
                                    MessageBox.Show("Протабулюйте функцію!GoodBye", "Important Question ", MessageBoxButtons.OK);
                                    Lich = Lich + 1;
                                }
                            }
                        }
                        while ((b < a) && (Fa * Fb > 0) && (eps < 0));
                        Lich = 0;
                        while ((b - a) > eps)
                        {
                            c = a + 0.5 * (b - a);
                            Lich++;
                            fc = Convert.ToDouble(f3(c));
                            Fc = f3(c);
                            if (Math.Abs(Fc) < eps)
                            {
                                goto L_4;
                            }
                            if (Fa * Fc > 0)
                            {
                                Fa = Fc; a = c;
                            }
                            else
                                b = c;
                        }
                        c = (a + 0.5 * (b - a));
                    L_4:
                        label4.Text = "&X = " + c.ToString();
                        label7.Text = "&N = " + Lich.ToString();
                    }
                    this.BackColor = Color.PaleTurquoise;
                    break;
                case 1:
                    
                    if (comboBox2.SelectedIndex == 0)
                    {   
                        x = b;
                        if (f(x) * f2p(x) < 0)
                    {
                        x = a;
                    }
                    if (f(x) * f2p(x) < 0)
                    {
                        MessageBox.Show("Для заданого рівняння збіжність методу Ньютона не гарантується", "Important Question ", MessageBoxButtons.OK);
                    }
                    for (i = 1; i < kmax; i++)
                    {
                        dx = f(x) / fp(x);
                        x = x - dx;
                        if (Math.Abs(dx) < eps)
                        {
                            label4.Text = "X=" + x.ToString();
                            label7.Text = "i=" + i.ToString();
                            return;
                        }
                    }
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        x = b;
                        if (f1(x) * f2p(x) < 0)
                        {
                            x = a;
                        }
                        if (f1(x) * f2p(x) < 0)
                        {
                            MessageBox.Show("Для заданого рівняння збіжність методу Ньютона не гарантується", "Important Question ", MessageBoxButtons.OK);
                        }
                        for (i = 1; i < kmax; i++)
                        {
                            dx = f1(x) / fp(x);
                            x = x - dx;
                            if (Math.Abs(dx) < eps)
                            {
                                label4.Text = "X=" + x.ToString();
                                label7.Text = "i=" + i.ToString();
                                return;
                            }
                        }
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        x = b;
                        if (f2(x) * f2p(x) < 0)
                        {
                            x = a;
                        }
                        if (f2(x) * f2p(x) < 0)
                        {
                            MessageBox.Show("Для заданого рівняння збіжність методу Ньютона не гарантується", "Important Question ", MessageBoxButtons.OK);
                        }
                        for (i = 1; i < kmax; i++)
                        {
                            dx = f2(x) / fp(x);
                            x = x - dx;
                            if (Math.Abs(dx) < eps)
                            {
                                label4.Text = "X=" + x.ToString();
                                label7.Text = "i=" + i.ToString();
                                return;
                            }
                        }
                    }
                    if (comboBox2.SelectedIndex == 3)
                    {
                        x = b;
                        if (f3(x) * f2p(x) < 0)
                        {
                            x = a;
                        }
                        if (f3(x) * f2p(x) < 0)
                        {
                            MessageBox.Show("Для заданого рівняння збіжність методу Ньютона не гарантується", "Important Question ", MessageBoxButtons.OK);
                        }
                        for (i = 1; i < kmax; i++)
                        {
                            dx = f3(x) / fp(x);
                            x = x - dx;
                            if (Math.Abs(dx) < eps)
                            {
                                label4.Text = "X=" + x.ToString();
                                label7.Text = "i=" + i.ToString();
                                return;
                            }
                        }
                    }
                   this.BackColor = Color.PaleTurquoise;
                    break;
                default:  
                    MessageBox.Show(" Метод не обраний! Будь-ласка оберіть метод! ", "Important Question", MessageBoxButtons.OK,
      MessageBoxIcon.Warning); 
      break;
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            if (comboBox1.SelectedIndex == 0)
            { 
                label8.Visible = false;
                textBox4.Visible = false;
                label4.Text = "&X = ";
                label7.Text = "&N = ";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label8.Visible = true;
                textBox4.Visible = true;
                label4.Text = "&X = ";
                label7.Text = "&i = ";
            }
            else {
                MessageBox.Show(" Метод не обраний! Будь-ласка оберіть метод! ", "Important Question", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning); 
            }
            groupBox1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }
    }
}
