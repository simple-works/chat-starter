using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatStarterCommon;
using System.Threading;

namespace ChatStarterClient
{
    public partial class Form_Client : Form
    {
        enum Status { Initial, Sending }
        private ChatClient _chatClient;
        private string _userName;

        public Form_Client(ChatClient chatClient, string userName)
        {
            InitializeComponent();
            _chatClient = chatClient;
            _userName = userName;
            DisplayClientInfos();
            SetStatus(Status.Initial);
            ReceiveAsync();
        }

        private void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Initial:
                    textBox_message.Clear();
                    textBox_message.Enabled = true;
                    button_send.Enabled = true;
                    textBox_message.Focus();
                    break;
                case Status.Sending:
                    textBox_message.Enabled = false;
                    button_send.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ReceiveAsync()
        {
            new Thread(() =>
            {
                while (true)
                {
                    string message = _chatClient.ReceiveText();
                    Invoke((MethodInvoker)delegate()
                    {
                        Log(message);
                    });
                }
            }).Start();
        }

        private void DisplayClientInfos()
        {
            label_userName.Text = _userName;
            label_localEndPoint.Text = string.Format("{0}:{1}",
                _chatClient.LocalEndPoint.Address, _chatClient.LocalEndPoint.Port);
            label_remoteEndPoint.Text = string.Format("{0}:{1}",
                _chatClient.RemoteEndPoint.Address, _chatClient.RemoteEndPoint.Port);
        }

        private void Log(string message)
        {
            textBox_log.AppendText(message);
            textBox_log.AppendText(Environment.NewLine);
        }

        private void button_send_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_message.Text))
            {
                return;
            }

            SetStatus(Status.Sending);

            try
            {
                _chatClient.SendText(textBox_message.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetStatus(Status.Initial);
        }
    }
}
