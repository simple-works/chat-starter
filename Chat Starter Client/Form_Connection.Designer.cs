namespace ChatStarterClient
{
    partial class Form_Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Connection));
            this.groupBox_localEndPoint = new System.Windows.Forms.GroupBox();
            this.textBox_localPort = new System.Windows.Forms.TextBox();
            this.label_localPort = new System.Windows.Forms.Label();
            this.textBox_localIPAddress = new System.Windows.Forms.TextBox();
            this.label_localIPAddress = new System.Windows.Forms.Label();
            this.groupBox_remoteEndPoint = new System.Windows.Forms.GroupBox();
            this.textBox_remotePort = new System.Windows.Forms.TextBox();
            this.label_remotePort = new System.Windows.Forms.Label();
            this.textBox_remoteIPAddress = new System.Windows.Forms.TextBox();
            this.label_remoteIPAddress = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_advancedSettings = new System.Windows.Forms.Button();
            this.errorProvider_main = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox_localEndPoint.SuspendLayout();
            this.groupBox_remoteEndPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_main)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_localEndPoint
            // 
            this.groupBox_localEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_localEndPoint.Controls.Add(this.textBox_localPort);
            this.groupBox_localEndPoint.Controls.Add(this.label_localPort);
            this.groupBox_localEndPoint.Controls.Add(this.textBox_localIPAddress);
            this.groupBox_localEndPoint.Controls.Add(this.label_localIPAddress);
            this.groupBox_localEndPoint.Location = new System.Drawing.Point(22, 96);
            this.groupBox_localEndPoint.Name = "groupBox_localEndPoint";
            this.groupBox_localEndPoint.Size = new System.Drawing.Size(269, 82);
            this.groupBox_localEndPoint.TabIndex = 4;
            this.groupBox_localEndPoint.TabStop = false;
            this.groupBox_localEndPoint.Text = "Local End Point";
            // 
            // textBox_localPort
            // 
            this.textBox_localPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localPort.Location = new System.Drawing.Point(183, 39);
            this.textBox_localPort.Name = "textBox_localPort";
            this.textBox_localPort.Size = new System.Drawing.Size(70, 20);
            this.textBox_localPort.TabIndex = 3;
            this.textBox_localPort.Text = "60000";
            // 
            // label_localPort
            // 
            this.label_localPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_localPort.AutoSize = true;
            this.label_localPort.Location = new System.Drawing.Point(180, 23);
            this.label_localPort.Name = "label_localPort";
            this.label_localPort.Size = new System.Drawing.Size(31, 13);
            this.label_localPort.TabIndex = 2;
            this.label_localPort.Text = "Port:";
            // 
            // textBox_localIPAddress
            // 
            this.textBox_localIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localIPAddress.Location = new System.Drawing.Point(18, 39);
            this.textBox_localIPAddress.Name = "textBox_localIPAddress";
            this.textBox_localIPAddress.Size = new System.Drawing.Size(159, 20);
            this.textBox_localIPAddress.TabIndex = 1;
            this.textBox_localIPAddress.Text = "127.1.1.1";
            // 
            // label_localIPAddress
            // 
            this.label_localIPAddress.AutoSize = true;
            this.label_localIPAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_localIPAddress.Location = new System.Drawing.Point(15, 23);
            this.label_localIPAddress.Name = "label_localIPAddress";
            this.label_localIPAddress.Size = new System.Drawing.Size(63, 13);
            this.label_localIPAddress.TabIndex = 0;
            this.label_localIPAddress.Text = "IP Address:";
            this.label_localIPAddress.Click += new System.EventHandler(this.label_localIPAddress_Click);
            // 
            // groupBox_remoteEndPoint
            // 
            this.groupBox_remoteEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_remoteEndPoint.Controls.Add(this.textBox_remotePort);
            this.groupBox_remoteEndPoint.Controls.Add(this.label_remotePort);
            this.groupBox_remoteEndPoint.Controls.Add(this.textBox_remoteIPAddress);
            this.groupBox_remoteEndPoint.Controls.Add(this.label_remoteIPAddress);
            this.groupBox_remoteEndPoint.Location = new System.Drawing.Point(22, 184);
            this.groupBox_remoteEndPoint.Name = "groupBox_remoteEndPoint";
            this.groupBox_remoteEndPoint.Size = new System.Drawing.Size(269, 82);
            this.groupBox_remoteEndPoint.TabIndex = 5;
            this.groupBox_remoteEndPoint.TabStop = false;
            this.groupBox_remoteEndPoint.Text = "Remote End Point (Server)";
            // 
            // textBox_remotePort
            // 
            this.textBox_remotePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_remotePort.Location = new System.Drawing.Point(183, 39);
            this.textBox_remotePort.Name = "textBox_remotePort";
            this.textBox_remotePort.Size = new System.Drawing.Size(70, 20);
            this.textBox_remotePort.TabIndex = 3;
            this.textBox_remotePort.Text = "8080";
            // 
            // label_remotePort
            // 
            this.label_remotePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_remotePort.AutoSize = true;
            this.label_remotePort.Location = new System.Drawing.Point(180, 23);
            this.label_remotePort.Name = "label_remotePort";
            this.label_remotePort.Size = new System.Drawing.Size(31, 13);
            this.label_remotePort.TabIndex = 2;
            this.label_remotePort.Text = "Port:";
            // 
            // textBox_remoteIPAddress
            // 
            this.textBox_remoteIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_remoteIPAddress.Location = new System.Drawing.Point(18, 39);
            this.textBox_remoteIPAddress.Name = "textBox_remoteIPAddress";
            this.textBox_remoteIPAddress.Size = new System.Drawing.Size(159, 20);
            this.textBox_remoteIPAddress.TabIndex = 1;
            this.textBox_remoteIPAddress.Text = "127.0.0.1";
            // 
            // label_remoteIPAddress
            // 
            this.label_remoteIPAddress.AutoSize = true;
            this.label_remoteIPAddress.Location = new System.Drawing.Point(15, 23);
            this.label_remoteIPAddress.Name = "label_remoteIPAddress";
            this.label_remoteIPAddress.Size = new System.Drawing.Size(63, 13);
            this.label_remoteIPAddress.TabIndex = 0;
            this.label_remoteIPAddress.Text = "IP Address:";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(19, 12);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(63, 13);
            this.label_userName.TabIndex = 0;
            this.label_userName.Text = "User Name:";
            // 
            // textBox_userName
            // 
            this.textBox_userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_userName.Location = new System.Drawing.Point(22, 28);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(269, 20);
            this.textBox_userName.TabIndex = 1;
            this.textBox_userName.Text = "Anonymous";
            // 
            // button_connect
            // 
            this.button_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_connect.Image = global::ChatStarterClient.Properties.Resources.connect;
            this.button_connect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_connect.Location = new System.Drawing.Point(205, 54);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(86, 23);
            this.button_connect.TabIndex = 2;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_advancedSettings
            // 
            this.button_advancedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_advancedSettings.Image = global::ChatStarterClient.Properties.Resources.bullet_arrow_up;
            this.button_advancedSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_advancedSettings.Location = new System.Drawing.Point(22, 54);
            this.button_advancedSettings.Name = "button_advancedSettings";
            this.button_advancedSettings.Size = new System.Drawing.Size(177, 23);
            this.button_advancedSettings.TabIndex = 3;
            this.button_advancedSettings.Text = "Show Advanced Settings";
            this.button_advancedSettings.UseVisualStyleBackColor = true;
            this.button_advancedSettings.Click += new System.EventHandler(this.button_advancedSettings_Click);
            // 
            // errorProvider_main
            // 
            this.errorProvider_main.BlinkRate = 100;
            this.errorProvider_main.ContainerControl = this;
            this.errorProvider_main.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider_main.Icon")));
            // 
            // Form_Connection
            // 
            this.AcceptButton = this.button_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 279);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.groupBox_remoteEndPoint);
            this.Controls.Add(this.groupBox_localEndPoint);
            this.Controls.Add(this.button_advancedSettings);
            this.Controls.Add(this.button_connect);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Connection";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection - Chat Starter ";
            this.groupBox_localEndPoint.ResumeLayout(false);
            this.groupBox_localEndPoint.PerformLayout();
            this.groupBox_remoteEndPoint.ResumeLayout(false);
            this.groupBox_remoteEndPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.GroupBox groupBox_localEndPoint;
        private System.Windows.Forms.TextBox textBox_localPort;
        private System.Windows.Forms.Label label_localPort;
        private System.Windows.Forms.TextBox textBox_localIPAddress;
        private System.Windows.Forms.Label label_localIPAddress;
        private System.Windows.Forms.GroupBox groupBox_remoteEndPoint;
        private System.Windows.Forms.TextBox textBox_remotePort;
        private System.Windows.Forms.Label label_remotePort;
        private System.Windows.Forms.TextBox textBox_remoteIPAddress;
        private System.Windows.Forms.Label label_remoteIPAddress;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Button button_advancedSettings;
        private System.Windows.Forms.ErrorProvider errorProvider_main;
    }
}