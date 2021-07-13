using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatStarterCommon;
using ChatStarterServer.Properties;

namespace ChatStarterServer
{
    public partial class Form_Server : Form
    {
        private enum Status { Initial, Listening, Error }
        private ChatServer _chatServer = null;
        bool _active = false;
        bool _listeningBlinkState = false;

        public Form_Server()
        {
            InitializeComponent();
            SetStatus(Status.Initial);
            GenerateIPAdress(chooseLocalIPAddress: true);
        }

        #region Common Methods
        private void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Initial:
                    _active = false;
                    Log("Server stopped.");
                    label_status.Text = "Stopped.";
                    label_status.ForeColor = Color.Gray;
                    label_status.Image = Resources.bullet_black;
                    label_localEndPoint.Text = string.Empty;
                    groupBox_localEndPoint.Enabled = true;
                    listBox_clients.Items.Clear();
                    button_start.Enabled = true;
                    button_stop.Enabled = false;
                    timer_listeningBlink.Stop();
                    textBox_ipAddress.Focus();
                    break;
                case Status.Listening:
                    _active = true;
                    Log("Server started listening.");
                    label_status.Text = "Listening...";
                    label_status.ForeColor = Color.Green;
                    label_status.Image = Resources.bullet_green;
                    groupBox_localEndPoint.Enabled = false;
                    button_start.Enabled = false;
                    button_stop.Enabled = true;
                    timer_listeningBlink.Start();
                    break;
                case Status.Error:
                    SetStatus(Status.Initial);
                    label_status.Text = "Error!";
                    label_status.ForeColor = Color.Red;
                    label_status.Image = Resources.bullet_red;
                    break;
                default:
                    break;
            }
        }

        private void ReceiveAsync()
        {
            Task.Factory.StartNew(() =>
            {
                while (_active)
                {
                    ChatUser user = _chatServer.AcceptUser();
                    string userNameAndClient = string.Format("{0}@{1}:{2}",
                            user.Name, user.ClientEndPoint.Address, user.ClientEndPoint.Port);
                    Invoke((MethodInvoker)delegate()
                    {
                        listBox_clients.Items.Add(userNameAndClient);
                        _chatServer.BroadcastText(string.Format("{0} joined the chat.", user.Name));
                        Log(string.Format("{0} joined the chat.", userNameAndClient));
                    });
                    Task.Factory.StartNew(() =>
                    {
                        while (_active)
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

        private void Log(string text)
        {
            textBox_log.AppendText(text);
            textBox_log.AppendText(Environment.NewLine);
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

        private void GenerateIPAdress(bool chooseLocalIPAddress = false)
        {
            if (chooseLocalIPAddress)
            {
                textBox_ipAddress.Text = Network.GetLocalIPAddress().ToString();
                return;
            }
            textBox_ipAddress.Text = Network.GenerateIPAddressString();
        }

        private void GeneratePort()
        {
            textBox_port.Text = Network.GeneratePort().ToString();
        }
        #endregion

        private void button_start_Click(object sender, EventArgs e)
        {
            bool inputHasErrors = false;
            IPAddress ipAddress;
            int port;

            SetError();
            if (!Network.TryParseIPAddress(textBox_ipAddress.Text, out ipAddress))
            {
                SetError(label_ipAddress, "Invalid IP Address");
                textBox_ipAddress.Focus();
                textBox_ipAddress.SelectAll();
                inputHasErrors = true;
            }
            if (!Network.TryParsePort(textBox_port.Text, out port))
            {
                SetError(label_port, "Invalid Port");
                textBox_ipAddress.Focus();
                textBox_port.SelectAll();
                inputHasErrors = true;
            }
            if (inputHasErrors)
            {
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
                Log(string.Format("Error: {0}", exception.Message));
                SetStatus(Status.Initial);
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            SetStatus(Status.Initial);
            _chatServer.Stop();
        }

        private void timer_listeningBlink_Tick(object sender, EventArgs e)
        {
            _listeningBlinkState = !_listeningBlinkState;

            if (_listeningBlinkState)
            {
                label_status.Image = Resources.bullet_black;
                label_status.ForeColor = Color.Gray;
            }
            else
            {
                label_status.Image = Resources.bullet_green;
                label_status.ForeColor = Color.Green;
            }
        }

        private void label_ipAddress_Click(object sender, EventArgs e)
        {
            GenerateIPAdress();
        }

        private void label_port_Click(object sender, EventArgs e)
        {
            GeneratePort();
        }
    }
}
