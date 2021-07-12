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

        public Form_Connection()
        {
            InitializeComponent();
            _originalHeight = Height;
            GenerateLocalIPAdress();
            HideAdvancedSettings();
        }

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

        private void GenerateLocalIPAdress()
        {
            Random random = new Random();
            Func<int> getRandom = () => random.Next(1, 255);
            string localIPAdressString = string.Format("127.{0}.{1}.{2}",
                getRandom(), getRandom(), getRandom());
            textBox_localIPAddress.Text = localIPAdressString;
        }

        private bool TryParsePort(string portString, out int port)
        {
            try
            {
                port = int.Parse(portString);
                if (port < 0 || port > 65535) throw new Exception();
            }
            catch
            {
                port = -1;
                return false;
            }
            return true;
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

        private void button_advancedSettings_Click(object sender, EventArgs e)
        {
            ToggleAdvancedSettings();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            IPAddress localIPAddress, remoteIPAddress;
            int localPort, remotePort;

            errorProvider_main.Clear();
            if (string.IsNullOrWhiteSpace(textBox_userName.Text))
            {
                errorProvider_main.SetError(textBox_userName, "Empty User Name");
                return;
            }
            if (!IPAddress.TryParse(textBox_localIPAddress.Text.Trim(), out localIPAddress))
            {
                errorProvider_main.SetError(textBox_localIPAddress, "Invalid IP Address");
                return;
            }
            if (!IPAddress.TryParse(textBox_remoteIPAddress.Text.Trim(), out remoteIPAddress))
            {
                errorProvider_main.SetError(textBox_remoteIPAddress, "Invalid IP Address");
                return;
            }
            if (!TryParsePort(textBox_localPort.Text.Trim(), out localPort))
            {
                errorProvider_main.SetError(textBox_localPort, "Invalid Port");
                return;
            }
            if (!TryParsePort(textBox_remotePort.Text.Trim(), out remotePort))
            {
                errorProvider_main.SetError(textBox_remotePort, "Invalid Port");
                return;
            }

            try
            {
                SetStatus(Status.Connecting);
                ChatClient chatClient = new ChatClient(localIPAddress, localPort);

                Task task = Task.Factory.StartNew(() =>
                {
                    chatClient.Connect(remoteIPAddress, remotePort);
                    chatClient.SendText(textBox_userName.Text);
                });

                task.ContinueWith(t =>
                {
                    Hide();
                    new Form_Client(chatClient, textBox_userName.Text).Show();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus(Status.Initial);
            }
        }

        private void label_localIPAddress_Click(object sender, EventArgs e)
        {
            GenerateLocalIPAdress();
        }
    }
}
