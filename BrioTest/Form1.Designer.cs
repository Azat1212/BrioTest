
using System;

namespace BrioTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveAsInput = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewX = new System.Windows.Forms.TextBox();
            this.NewY = new System.Windows.Forms.TextBox();
            this.AddNewTransmitterPoit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveAsOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(31, 415);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveAsInput
            // 
            this.SaveAsInput.Location = new System.Drawing.Point(112, 415);
            this.SaveAsInput.Name = "SaveAsInput";
            this.SaveAsInput.Size = new System.Drawing.Size(83, 23);
            this.SaveAsInput.TabIndex = 2;
            this.SaveAsInput.Text = "Save as input";
            this.SaveAsInput.UseVisualStyleBackColor = true;
            this.SaveAsInput.Click += new System.EventHandler(this.SaveAsInputButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 409);
            this.panel1.TabIndex = 3;
            // 
            // NewX
            // 
            this.NewX.AccessibleDescription = "";
            this.NewX.Location = new System.Drawing.Point(432, 418);
            this.NewX.Name = "NewX";
            this.NewX.Size = new System.Drawing.Size(100, 20);
            this.NewX.TabIndex = 4;
            this.NewX.Tag = "";
            // 
            // NewY
            // 
            this.NewY.Location = new System.Drawing.Point(561, 418);
            this.NewY.Name = "NewY";
            this.NewY.Size = new System.Drawing.Size(100, 20);
            this.NewY.TabIndex = 5;
            // 
            // AddNewTransmitterPoit
            // 
            this.AddNewTransmitterPoit.Location = new System.Drawing.Point(667, 418);
            this.AddNewTransmitterPoit.Name = "AddNewTransmitterPoit";
            this.AddNewTransmitterPoit.Size = new System.Drawing.Size(121, 23);
            this.AddNewTransmitterPoit.TabIndex = 6;
            this.AddNewTransmitterPoit.Text = "Add transmitter point";
            this.AddNewTransmitterPoit.UseVisualStyleBackColor = true;
            this.AddNewTransmitterPoit.Click += new System.EventHandler(this.AddNewTransmitterPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(405, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(538, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y:";
            // 
            // SaveAsOutput
            // 
            this.SaveAsOutput.Location = new System.Drawing.Point(201, 415);
            this.SaveAsOutput.Name = "SaveAsOutput";
            this.SaveAsOutput.Size = new System.Drawing.Size(94, 23);
            this.SaveAsOutput.TabIndex = 9;
            this.SaveAsOutput.Text = "Save as output";
            this.SaveAsOutput.UseVisualStyleBackColor = true;
            this.SaveAsOutput.Click += new System.EventHandler(this.SaveAsOutput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveAsOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddNewTransmitterPoit);
            this.Controls.Add(this.NewY);
            this.Controls.Add(this.NewX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SaveAsInput);
            this.Controls.Add(this.OpenButton);
            this.Name = "Form1";
            this.Text = "MyForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveAsInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NewX;
        private System.Windows.Forms.TextBox NewY;
        private System.Windows.Forms.Button AddNewTransmitterPoit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveAsOutput;
    }
}

