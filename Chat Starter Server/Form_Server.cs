using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatStarterCommon;
using ChatStarterServer.Properties;

namespace ChatStarterServer
{
    public partial class Form_Server : Form
    {
        private enum Status { Stopped, Loading, Listening, Error }
        private ChatServer _chatServer = null;

        public Form_Server()
        {
            InitializeComponent();
            SetStatus(Status.Stopped);
        }

        private void Log(string value)
        {
            textBox_log.AppendText(value);
            textBox_log.AppendText(Environment.NewLine);
        }

        private void ReceiveAsync()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    ChatUser user = _chatServer.AcceptUser();
                    string userString = string.Format("{0}@{1}:{2}",
                            user.Name, user.ClientEndPoint.Address, user.ClientEndPoint.Port);
                    Invoke((MethodInvoker)delegate()
                    {
                        listBox_clients.Items.Add(userString);
                        _chatServer.BroadcastText(string.Format("{0} joined the chat.", user.Name));
                        Log(string.Format("{0} joined the chat.", userString));
                    });
                    Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            string message = _chatServer.ReceiveText(user.ID);
                            _chatServer.BroadcastText(string.Format("{0}: {1}", user.Name, message));
                            Invoke((MethodInvoker)delegate()
                            {
                                Log(string.Format("• {0}: {1}", user.Name, message));
                            });
                        }
                    });
                }
            });
        }

        private void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Stopped:
                    Log("Server stopped.");
                    label_status.Text = "Stopped.";
                    label_status.Image = Resources.bullet_black;
                    groupBox_localEndPoint.Enabled = true;
                    listBox_clients.Items.Clear();
                    button_start.Enabled = true;
                    button_stop.Enabled = false;
                    break;
                case Status.Loading:
                    label_status.Text = "Loading...";
                    label_status.Image = Resources.bullet_blue;
                    groupBox_localEndPoint.Enabled = false;
                    button_start.Enabled = false;
                    button_stop.Enabled = false;
                    break;
                case Status.Listening:
                    Log("Server started listening.");
                    label_status.Text = "Listening...";
                    label_status.Image = Resources.bullet_green;
                    groupBox_localEndPoint.Enabled = false;
                    button_start.Enabled = false;
                    button_stop.Enabled = true;
                    break;
                case Status.Error:
                    label_status.Text = "Error!";
                    label_status.Image = Resources.bullet_red;
                    break;
                default:
                    break;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            SetStatus(Status.Loading);

            IPAddress ipAddress;
            int port;

            errorProvider_main.Clear();
            if (!IPAddress.TryParse(textBox_ipAddress.Text.Trim(), out ipAddress))
            {
                errorProvider_main.SetError(textBox_ipAddress, "Invalid IP Address");
                return;
            }
            if (!int.TryParse(textBox_port.Text.Trim(), out port) || port < 0 || port > 65535)
            {
                errorProvider_main.SetError(textBox_port, "Invalid Port");
                return;
            }

            try
            {
                _chatServer = new ChatServer(ipAddress, port);
                Log(string.Format("Server created at {0}:{1}.", ipAddress.ToString(), port));
                label_localEndPoint.Text = string.Format("{0}:{1}",
                    _chatServer.EndPoint.Address, _chatServer.EndPoint.Port);

                _chatServer.Listen();
                SetStatus(Status.Listening);

                Log("Server started waiting for requests.");
                ReceiveAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Error: " + exception.Message);
                SetStatus(Status.Stopped);
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            _chatServer.Stop();
            label_localEndPoint.Text = string.Empty;
            SetStatus(Status.Stopped);
        }
    }
}
