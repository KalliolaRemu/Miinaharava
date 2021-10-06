using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17Miinaharava
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Helppo");
            comboBox1.Items.Add("Keskitaso");
            comboBox1.Items.Add("Vaikea");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Valitse vaikeustaso.");
            }
            else
            {
                Peli miinaharava = new Peli(comboBox1.Text);
                this.Hide();
                miinaharava.ShowDialog();
                this.Show();
            }
        }
    }
}
