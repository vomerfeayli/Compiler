using Compiler.Core;
using Compiler.Exceptions;
using Compiler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Compiler
{
    public partial class Form1 : Form
    {
        private string text;
        private List<string> generatedCode;

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            errorsBox.Items.Clear();
            RPNs.Items.Clear();
            generatedCodeBox.Clear();
            outputBox.Clear();
        }

        private void LoadProgramCode_Click(object sender, EventArgs e)
        {

        }

        private void runProgram_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();

                var lexer = new Lexer(TextConsole.Text.Trim()); ;

                lexer.Run();
                var tokens = lexer.GetTokens();

                if (tokens != null && tokens.Any())
                {
                    var syntacticAnalysis = new SyntacticAnalysis(tokens);
                    syntacticAnalysis.Run();

                    var rpns = syntacticAnalysis.GetRPNs();

                    foreach (var rpn in rpns)
                    {
                        RPNs.Items.Add(rpn);
                    }

                    var variables = syntacticAnalysis.GetVariablesList();

                    var codeGenerator = new CodeGenerator(rpns, variables);
                    codeGenerator.Run();

                    generatedCode = codeGenerator.GetGeneratedCode();

                    for (int i = 0; i < generatedCode.Count; i++)
                    {
                        if (i + 1 < generatedCode.Count)
                        {
                            generatedCodeBox.Text += $"{generatedCode[i]}\n";
                        }
                        else
                        {
                            generatedCodeBox.Text += $"{generatedCode[i]}";
                        }
                    }

                    outputBox.Text += codeGenerator.GetResult();

                    var bindingList = new BindingList<Token>(tokens);
                    dataGridView1.DataSource = new BindingSource(bindingList, null);
                }
            }
            catch (CodeException ex)
            {
                errorsBox.Items.Add(ex.Message);
            }
            catch (SyntaxException ex)
            {
                errorsBox.Items.Add(ex.Message);
            }
        }

        private void exportCode_Click(object sender, EventArgs e)
        {
            var filePath = "";

            

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                filePath = saveFileDialog1.FileName;
            }

            var SW = new StreamWriter(filePath);
            SW.Write(generatedCodeBox.Text.ToString());
            SW.Close();
        }
    }
}