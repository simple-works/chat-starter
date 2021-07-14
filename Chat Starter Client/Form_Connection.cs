using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatStarterClient.Properties;
using ChatStarterCommon;

namespace ChatStarterClient
{
    public partial class Form_Connection : Form
    {
        private enum Status { Initial, Connecting }
        private int _originalHeight;
        private bool _advancedSettingsVisible;

        public string UserName { get; private set; }
        public ChatClient ChatClient { get; private set; }

        public Form_Connection()
        {
            InitializeComponent();
            _originalHeight = Height;
            GenerateLocalIPAddress(chooseLocalIPAddress: true);
            GenerateRemoteIPAddress();
            GenerateUserName();
            HideAdvancedSettings();
        }

        public static bool ShowAndTryGetInput(out ChatClient chatClient, out string userName,
            IWin32Window owner = null)
        {
            Form_Connection form_connection = new Form_Connection();
            if (form_connection.ShowDialog(owner) == DialogResult.OK)
            {
                chatClient = form_connection.ChatClient;
                userName = form_connection.UserName;
                return true;
            }
            chatClient = null;
            userName = null;
            return false;
        }

        #region Common Methods
        private void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Initial:
                    Cursor = Cursors.Default;
                    textBox_userName.Enabled = true;
                    button_connect.Enabled = true;
                    groupBox_localEndPoint.Enabled = true;
                    groupBox_remoteEndPoint.Enabled = true;
                    textBox_userName.Focus();
                    break;
                case Status.Connecting:
                    Cursor = Cursors.AppStarting;
                    textBox_userName.Enabled = false;
                    button_connect.Enabled = false;
                    groupBox_localEndPoint.Enabled = false;
                    groupBox_remoteEndPoint.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ConnectAsync(IPAddress localIPAddress, int localPort,
            IPAddress remoteIPAddress, int remotePort)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    ChatClient = new ChatClient(localIPAddress, localPort);
                    ChatClient.Connect(remoteIPAddress, remotePort);
                    ChatClient.SendText(textBox_userName.Text);
                    Invoke((MethodInvoker)delegate()
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    });
                }
                catch (Exception exception)
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        MessageBox.Show(exception.Message, Application.ProductName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetStatus(Status.Initial);
                    });
                }
            });
        }

        private void SetError(Control control = null, string text = null)
        {
            if (control == null && text == null)
            {
                errorProvider_main.Clear();
                return;
            }
            errorProvider_main.SetError(control, text);
        }

        private void ToggleAdvancedSettings()
        {
            if (_advancedSettingsVisible) HideAdvancedSettings();
            else ShowAdvancedSettings();
        }

        private void ShowAdvancedSettings()
        {
            button_advancedSettings.Text = "Hide Advanced Settings";
            button_advancedSettings.Image = Resources.bullet_arrow_up;
            Height = _originalHeight;
            groupBox_localEndPoint.Visible = true;
            groupBox_remoteEndPoint.Visible = true;
            _advancedSettingsVisible = true;
        }

        private void HideAdvancedSettings()
        {
            button_advancedSettings.Text = "Show Advanced Settings";
            button_advancedSettings.Image = Resources.bullet_arrow_down;
            Height = _originalHeight - (groupBox_localEndPoint.Height
                + groupBox_remoteEndPoint.Height + 16);
            groupBox_localEndPoint.Visible = false;
            groupBox_remoteEndPoint.Visible = false;
            _advancedSettingsVisible = false;
        }

        private void GenerateLocalIPAddress(bool chooseLocalIPAddress = false)
        {
            if (chooseLocalIPAddress)
            {
                textBox_localIPAddress.Text = Network.GetLocalIPAddress().ToString();
                return;
            }
            textBox_localIPAddress.Text = Network.GenerateIPAddressString("127.x.x.x");
        }

        private void GenerateLocalPort()
        {
            textBox_localPort.Text = Network.GeneratePort(60000).ToString();
        }

        private void GenerateRemoteIPAddress()
        {
            textBox_remoteIPAddress.Text = Network.GetLocalIPAddress().ToString();
        }

        private void GenerateUserName()
        {
            textBox_userName.Text = string.Format("Anonymous{0}", new Random().Next(1111, 9999));
        }
        #endregion

        private void button_advancedSettings_Click(object sender, EventArgs e)
        {
            ToggleAdvancedSettings();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            bool inputHasErrors = false;
            IPAddress localIPAddress, remoteIPAddress;
            int localPort, remotePort;

            SetError();
            if (string.IsNullOrWhiteSpace(textBox_userName.Text))
            {
                SetError(label_userName, "Empty User Name");
                textBox_userName.Focus();
                textBox_userName.SelectAll();
                inputHasErrors = true;
            }

            UserName = textBox_userName.Text;

            if (!Network.TryParseIPAddress(textBox_localIPAddress.Text, out localIPAddress))
            {
                SetError(label_localIPAddress, "Invalid IP Address");
                textBox_localIPAddress.Focus();
                textBox_localIPAddress.SelectAll();
                inputHasErrors = true;
            }
            if (!Network.TryParseIPAddress(textBox_remoteIPAddress.Text, out remoteIPAddress))
            {
                SetError(label_remoteIPAddress, "Invalid IP Address");
                textBox_remoteIPAddress.Focus();
                textBox_remoteIPAddress.SelectAll();
                inputHasErrors = true;
            }
            if (!Network.TryParsePort(textBox_localPort.Text, out localPort))
            {
                SetError(label_localPort, "Invalid Port");
                textBox_localPort.Focus();
                textBox_localPort.SelectAll();
                inputHasErrors = true;
            }
            if (!Network.TryParsePort(textBox_remotePort.Text, out remotePort))
            {
                SetError(label_remotePort, "Invalid Port");
                textBox_remotePort.Focus();
                textBox_remotePort.SelectAll();
                inputHasErrors = true;
            }
            if (inputHasErrors)
            {
                return;
            }

            SetStatus(Status.Connecting);
            ConnectAsync(localIPAddress, localPort, remoteIPAddress, remotePort);
        }

        private void label_localIPAddress_Click(object sender, EventArgs e)
        {
            GenerateLocalIPAddress();
        }

        private void label_localPort_Click(object sender, EventArgs e)
        {
            GenerateLocalPort();
        }

        private void label_userName_Click(object sender, EventArgs e)
        {
            GenerateUserName();
        }
    }
}
