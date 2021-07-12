namespace ChatStarterClient
{
    partial class Form_Client
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Client));
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.label_userName = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_localEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_arrow = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_remoteEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_send = new System.Windows.Forms.Button();
            this.statusStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_message
            // 
            this.textBox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_message.Location = new System.Drawing.Point(12, 355);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(279, 20);
            this.textBox_message.TabIndex = 0;
            // 
            // textBox_log
            // 
            this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log.Location = new System.Drawing.Point(12, 12);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.Size = new System.Drawing.Size(360, 336);
            this.textBox_log.TabIndex = 2;
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_userName,
            this.label_localEndPoint,
            this.label_arrow,
            this.label_remoteEndPoint});
            this.statusStrip_main.Location = new System.Drawing.Point(0, 390);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.ShowItemToolTips = true;
            this.statusStrip_main.Size = new System.Drawing.Size(384, 22);
            this.statusStrip_main.TabIndex = 3;
            // 
            // label_userName
            // 
            this.label_userName.Image = global::ChatStarterClient.Properties.Resources.user;
            this.label_userName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(187, 17);
            this.label_userName.Spring = true;
            this.label_userName.Text = "Anonymous";
            this.label_userName.ToolTipText = "User Name";
            // 
            // label_localEndPoint
            // 
            this.label_localEndPoint.Image = global::ChatStarterClient.Properties.Resources.computer;
            this.label_localEndPoint.Name = "label_localEndPoint";
            this.label_localEndPoint.Size = new System.Drawing.Size(83, 17);
            this.label_localEndPoint.Text = "0.0.0.0:8080";
            this.label_localEndPoint.ToolTipText = "Local Client";
            // 
            // label_arrow
            // 
            this.label_arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.label_arrow.Image = global::ChatStarterClient.Properties.Resources.arrow_right;
            this.label_arrow.Name = "label_arrow";
            this.label_arrow.Size = new System.Drawing.Size(16, 17);
            // 
            // label_remoteEndPoint
            // 
            this.label_remoteEndPoint.Image = global::ChatStarterClient.Properties.Resources.server;
            this.label_remoteEndPoint.Name = "label_remoteEndPoint";
            this.label_remoteEndPoint.Size = new System.Drawing.Size(83, 17);
            this.label_remoteEndPoint.Text = "0.0.0.0:7070";
            this.label_remoteEndPoint.ToolTipText = "Remote Server";
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Image = global::ChatStarterClient.Properties.Resources.email;
            this.button_send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_send.Location = new System.Drawing.Point(297, 354);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 1;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // Form_Client
            // 
            this.AcceptButton = this.button_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 412);
            this.Controls.Add(this.statusStrip_main);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_send);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "Form_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Starter";
            this.statusStrip_main.ResumeLayout(false);
            this.statusStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel label_userName;
        private System.Windows.Forms.ToolStripStatusLabel label_localEndPoint;
        private System.Windows.Forms.ToolStripStatusLabel label_remoteEndPoint;
        private System.Windows.Forms.ToolStripStatusLabel label_arrow;

    }
}

