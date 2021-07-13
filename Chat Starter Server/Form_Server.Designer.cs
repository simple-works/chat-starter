namespace ChatStarterServer
{
    partial class Form_Server
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Server));
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.label_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_localEndPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_ipAddress = new System.Windows.Forms.Label();
            this.textBox_ipAddress = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.groupBox_localEndPoint = new System.Windows.Forms.GroupBox();
            this.groupBox_activity = new System.Windows.Forms.GroupBox();
            this.listBox_clients = new System.Windows.Forms.ListBox();
            this.label_log = new System.Windows.Forms.Label();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label_clients = new System.Windows.Forms.Label();
            this.errorProvider_main = new System.Windows.Forms.ErrorProvider(this.components);
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.timer_listeningBlink = new System.Windows.Forms.Timer(this.components);
            this.statusStrip_main.SuspendLayout();
            this.groupBox_localEndPoint.SuspendLayout();
            this.groupBox_activity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_main)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_status,
            this.label_localEndPoint});
            this.statusStrip_main.Location = new System.Drawing.Point(0, 390);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.ShowItemToolTips = true;
            this.statusStrip_main.Size = new System.Drawing.Size(484, 22);
            this.statusStrip_main.TabIndex = 4;
            // 
            // label_status
            // 
            this.label_status.ForeColor = System.Drawing.Color.Gray;
            this.label_status.Image = global::ChatStarterServer.Properties.Resources.bullet_black;
            this.label_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(422, 17);
            this.label_status.Spring = true;
            this.label_status.Text = "Stopped.";
            this.label_status.ToolTipText = "Server Status";
            // 
            // label_localEndPoint
            // 
            this.label_localEndPoint.Image = global::ChatStarterServer.Properties.Resources.server;
            this.label_localEndPoint.Name = "label_localEndPoint";
            this.label_localEndPoint.Size = new System.Drawing.Size(16, 17);
            this.label_localEndPoint.ToolTipText = "Local Server";
            // 
            // label_ipAddress
            // 
            this.label_ipAddress.AutoSize = true;
            this.label_ipAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_ipAddress.Location = new System.Drawing.Point(15, 23);
            this.label_ipAddress.Name = "label_ipAddress";
            this.label_ipAddress.Size = new System.Drawing.Size(63, 13);
            this.label_ipAddress.TabIndex = 0;
            this.label_ipAddress.Text = "IP Address:";
            this.label_ipAddress.Click += new System.EventHandler(this.label_ipAddress_Click);
            // 
            // textBox_ipAddress
            // 
            this.textBox_ipAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ipAddress.Location = new System.Drawing.Point(18, 39);
            this.textBox_ipAddress.Name = "textBox_ipAddress";
            this.textBox_ipAddress.Size = new System.Drawing.Size(342, 20);
            this.textBox_ipAddress.TabIndex = 1;
            this.textBox_ipAddress.Text = "0.0.0.0";
            // 
            // label_port
            // 
            this.label_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_port.AutoSize = true;
            this.label_port.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_port.Location = new System.Drawing.Point(363, 23);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(31, 13);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "Port:";
            this.label_port.Click += new System.EventHandler(this.label_port_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_port.Location = new System.Drawing.Point(366, 39);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(70, 20);
            this.textBox_port.TabIndex = 3;
            this.textBox_port.Text = "8080";
            // 
            // groupBox_localEndPoint
            // 
            this.groupBox_localEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_localEndPoint.Controls.Add(this.textBox_port);
            this.groupBox_localEndPoint.Controls.Add(this.label_port);
            this.groupBox_localEndPoint.Controls.Add(this.textBox_ipAddress);
            this.groupBox_localEndPoint.Controls.Add(this.label_ipAddress);
            this.groupBox_localEndPoint.Location = new System.Drawing.Point(16, 11);
            this.groupBox_localEndPoint.Name = "groupBox_localEndPoint";
            this.groupBox_localEndPoint.Size = new System.Drawing.Size(452, 82);
            this.groupBox_localEndPoint.TabIndex = 0;
            this.groupBox_localEndPoint.TabStop = false;
            this.groupBox_localEndPoint.Text = "Local End Point";
            // 
            // groupBox_activity
            // 
            this.groupBox_activity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_activity.Controls.Add(this.listBox_clients);
            this.groupBox_activity.Controls.Add(this.label_log);
            this.groupBox_activity.Controls.Add(this.textBox_log);
            this.groupBox_activity.Controls.Add(this.label_clients);
            this.groupBox_activity.Location = new System.Drawing.Point(16, 99);
            this.groupBox_activity.Name = "groupBox_activity";
            this.groupBox_activity.Size = new System.Drawing.Size(452, 252);
            this.groupBox_activity.TabIndex = 1;
            this.groupBox_activity.TabStop = false;
            this.groupBox_activity.Text = "Activity";
            // 
            // listBox_clients
            // 
            this.listBox_clients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_clients.FormattingEnabled = true;
            this.listBox_clients.Location = new System.Drawing.Point(19, 35);
            this.listBox_clients.Name = "listBox_clients";
            this.listBox_clients.Size = new System.Drawing.Size(155, 199);
            this.listBox_clients.TabIndex = 1;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(180, 19);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(28, 13);
            this.label_log.TabIndex = 2;
            this.label_log.Text = "Log:";
            // 
            // textBox_log
            // 
            this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log.Location = new System.Drawing.Point(183, 35);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(254, 199);
            this.textBox_log.TabIndex = 3;
            // 
            // label_clients
            // 
            this.label_clients.AutoSize = true;
            this.label_clients.Location = new System.Drawing.Point(16, 19);
            this.label_clients.Name = "label_clients";
            this.label_clients.Size = new System.Drawing.Size(43, 13);
            this.label_clients.TabIndex = 0;
            this.label_clients.Text = "Clients:";
            // 
            // errorProvider_main
            // 
            this.errorProvider_main.BlinkRate = 100;
            this.errorProvider_main.ContainerControl = this;
            this.errorProvider_main.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider_main.Icon")));
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.Image = global::ChatStarterServer.Properties.Resources.resultset_next;
            this.button_start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_start.Location = new System.Drawing.Point(393, 357);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_stop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_stop.Enabled = false;
            this.button_stop.Image = global::ChatStarterServer.Properties.Resources.stop;
            this.button_stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_stop.Location = new System.Drawing.Point(312, 357);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 3;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // timer_listeningBlink
            // 
            this.timer_listeningBlink.Interval = 1000;
            this.timer_listeningBlink.Tick += new System.EventHandler(this.timer_listeningBlink_Tick);
            // 
            // Form_Server
            // 
            this.AcceptButton = this.button_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_stop;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.statusStrip_main);
            this.Controls.Add(this.groupBox_activity);
            this.Controls.Add(this.groupBox_localEndPoint);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "Form_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Starter Server";
            this.statusStrip_main.ResumeLayout(false);
            this.statusStrip_main.PerformLayout();
            this.groupBox_localEndPoint.ResumeLayout(false);
            this.groupBox_localEndPoint.PerformLayout();
            this.groupBox_activity.ResumeLayout(false);
            this.groupBox_activity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel label_status;
        private System.Windows.Forms.Label label_ipAddress;
        private System.Windows.Forms.TextBox textBox_ipAddress;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.GroupBox groupBox_localEndPoint;
        private System.Windows.Forms.GroupBox groupBox_activity;
        private System.Windows.Forms.ListBox listBox_clients;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Label label_clients;
        private System.Windows.Forms.ErrorProvider errorProvider_main;
        private System.Windows.Forms.ToolStripStatusLabel label_localEndPoint;
        private System.Windows.Forms.Timer timer_listeningBlink;
    }
}

