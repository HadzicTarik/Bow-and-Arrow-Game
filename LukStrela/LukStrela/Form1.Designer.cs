
namespace LukStrela
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
            this.components = new System.ComponentModel.Container();
            this.panIgra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrojPoena = new System.Windows.Forms.Label();
            this.TimerIgra = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panIgra
            // 
            this.panIgra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panIgra.Location = new System.Drawing.Point(0, 3);
            this.panIgra.Name = "panIgra";
            this.panIgra.Size = new System.Drawing.Size(1000, 400);
            this.panIgra.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(404, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj poena:";
            // 
            // lblBrojPoena
            // 
            this.lblBrojPoena.AutoSize = true;
            this.lblBrojPoena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojPoena.Location = new System.Drawing.Point(505, 414);
            this.lblBrojPoena.Name = "lblBrojPoena";
            this.lblBrojPoena.Size = new System.Drawing.Size(17, 18);
            this.lblBrojPoena.TabIndex = 2;
            this.lblBrojPoena.Text = "0";
            // 
            // TimerIgra
            // 
            this.TimerIgra.Interval = 40;
            this.TimerIgra.Tick += new System.EventHandler(this.TimerIgra_Event);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 445);
            this.Controls.Add(this.lblBrojPoena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panIgra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panIgra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrojPoena;
        private System.Windows.Forms.Timer TimerIgra;
    }
}

