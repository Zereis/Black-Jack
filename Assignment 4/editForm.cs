using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4
{
    public partial class editForm : Form
    {
        public string name;
        public int amountOfDecks;

        public editForm()
        {
            InitializeComponent();
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox1.Text != string.Empty)
            {
                amountOfDecks = int.Parse(textBox1.Text);
                name = textBox2.Text;



                this.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
