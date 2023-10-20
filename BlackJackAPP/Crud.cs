using GameCardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackAPP
{
    public partial class Crud : Form
    {
        RegisterPlayer registerPlayer;
        public Crud()
        {
            InitializeComponent();
            registerPlayer = new RegisterPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update player info in database
            registerPlayer.callUpdate(int.Parse(textBox1.Text), textBox2.Text);
            MessageBox.Show("Successfully Updated player info");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Register player info in database
            registerPlayer.callRegister(int.Parse(textBox1.Text), textBox2.Text);
            MessageBox.Show("Successfully Registered player into database");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete player info in database
            registerPlayer.callDelete(int.Parse(textBox1.Text));
            MessageBox.Show("Successfully Deleted player from database");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // ID
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Name
        }
    }
}
