using System.ComponentModel;

namespace Compiler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextConsole = new System.Windows.Forms.RichTextBox();
            this.RunProgram = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorsBox = new System.Windows.Forms.ListBox();
            this.RPNs = new System.Windows.Forms.ListBox();
            this.LoadProgramCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.generatedCodeBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exportCode = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextConsole
            // 
            this.TextConsole.Location = new System.Drawing.Point(12, 54);
            this.TextConsole.Name = "TextConsole";
            this.TextConsole.Size = new System.Drawing.Size(275, 223);
            this.TextConsole.TabIndex = 0;
            this.TextConsole.Text = "";
            // 
            // RunProgram
            // 
            this.RunProgram.Location = new System.Drawing.Point(152, 12);
            this.RunProgram.Name = "RunProgram";
            this.RunProgram.Size = new System.Drawing.Size(135, 23);
            this.RunProgram.TabIndex = 1;
            this.RunProgram.Text = "Запустить";
            this.RunProgram.UseVisualStyleBackColor = true;
            this.RunProgram.Click += new System.EventHandler(this.runProgram_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(293, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(554, 376);
            this.dataGridView1.TabIndex = 2;
            // 
            // errorsBox
            // 
            this.errorsBox.FormattingEnabled = true;
            this.errorsBox.Location = new System.Drawing.Point(12, 449);
            this.errorsBox.Name = "errorsBox";
            this.errorsBox.Size = new System.Drawing.Size(835, 160);
            this.errorsBox.TabIndex = 3;
            // 
            // RPNs
            // 
            this.RPNs.FormattingEnabled = true;
            this.RPNs.Location = new System.Drawing.Point(12, 296);
            this.RPNs.Name = "RPNs";
            this.RPNs.Size = new System.Drawing.Size(275, 134);
            this.RPNs.TabIndex = 4;
            // 
            // LoadProgramCode
            // 
            this.LoadProgramCode.Location = new System.Drawing.Point(11, 12);
            this.LoadProgramCode.Name = "LoadProgramCode";
            this.LoadProgramCode.Size = new System.Drawing.Size(135, 23);
            this.LoadProgramCode.TabIndex = 5;
            this.LoadProgramCode.Text = "Загрузить код";
            this.LoadProgramCode.UseVisualStyleBackColor = true;
            this.LoadProgramCode.Click += new System.EventHandler(this.LoadProgramCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Код программы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Токены:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Постфиксные записи выражений:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ошибки:";
            // 
            // generatedCodeBox
            // 
            this.generatedCodeBox.Location = new System.Drawing.Point(853, 54);
            this.generatedCodeBox.Name = "generatedCodeBox";
            this.generatedCodeBox.Size = new System.Drawing.Size(170, 376);
            this.generatedCodeBox.TabIndex = 10;
            this.generatedCodeBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(850, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Сгенерированный код";
            // 
            // exportCode
            // 
            this.exportCode.Location = new System.Drawing.Point(853, 12);
            this.exportCode.Name = "exportCode";
            this.exportCode.Size = new System.Drawing.Size(170, 23);
            this.exportCode.TabIndex = 12;
            this.exportCode.Text = "Экспорт кода в файл";
            this.exportCode.UseVisualStyleBackColor = true;
            this.exportCode.Click += new System.EventHandler(this.exportCode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(853, 449);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(170, 159);
            this.outputBox.TabIndex = 13;
            this.outputBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(850, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Вывод:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 620);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.exportCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.generatedCodeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadProgramCode);
            this.Controls.Add(this.RPNs);
            this.Controls.Add(this.errorsBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RunProgram);
            this.Controls.Add(this.TextConsole);
            this.Name = "Form1";
            this.Text = "Компилятор";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button RunProgram;

        private System.Windows.Forms.RichTextBox TextConsole;

        private System.Windows.Forms.RichTextBox richTextBox1;

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox errorsBox;
        private System.Windows.Forms.ListBox RPNs;
        private System.Windows.Forms.Button LoadProgramCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox generatedCodeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button exportCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Label label6;
    }
}