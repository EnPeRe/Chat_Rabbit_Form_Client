namespace Chat_Rabbit_Form_Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMessageSent = new System.Windows.Forms.TextBox();
            this.tbMessagesDisplay = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMessageSent
            // 
            this.tbMessageSent.Location = new System.Drawing.Point(44, 371);
            this.tbMessageSent.Name = "tbMessageSent";
            this.tbMessageSent.Size = new System.Drawing.Size(604, 22);
            this.tbMessageSent.TabIndex = 0;
            // 
            // tbMessagesDisplay
            // 
            this.tbMessagesDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.tbMessagesDisplay.Location = new System.Drawing.Point(44, 24);
            this.tbMessagesDisplay.Multiline = true;
            this.tbMessagesDisplay.Name = "tbMessagesDisplay";
            this.tbMessagesDisplay.ReadOnly = true;
            this.tbMessagesDisplay.Size = new System.Drawing.Size(604, 312);
            this.tbMessagesDisplay.TabIndex = 1;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(667, 371);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(121, 22);
            this.btSend.TabIndex = 2;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbMessagesDisplay);
            this.Controls.Add(this.tbMessageSent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMessageSent;
        private System.Windows.Forms.TextBox tbMessagesDisplay;
        private System.Windows.Forms.Button btSend;
    }
}

