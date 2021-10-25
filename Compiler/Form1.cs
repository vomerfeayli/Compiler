using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        private string text;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lexer = new Lexer(TextConsole.Text);
                var tokens = lexer.LexAnalisis();

                var bindingList = new BindingList<Token>(tokens);
                dataGridView1.DataSource = new BindingSource(bindingList, null);
            }
            catch (CodeException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}