using System;
using System.Threading;
using System.Windows.Forms;
using ChatStarterCommon;
using System.Threading.Tasks;

namespace ChatStarterClient
{
    public partial class Form_Client : Form
    {
        enum Status { Initial, Sending }
        private ChatClient _chatClient;
        private string _userName;

        public Form_Client()
        {
            InitializeComponent();
            if (Form_Connection.ShowAndTryGetInput(out _chatClient, out _userName, this))
            {
                SetStatus(Status.Initial);
                DisplayClientInfos();
                ReceiveTextAsync();
                return;
            }
            Load += (s, e) => Close();
        }

        #region Common Methods
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

        private void ReceiveTextAsync()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        string message = _chatClient.ReceiveText();
                        Invoke((MethodInvoker)delegate()
                        {
                            Log(message);
                        });
                    }
                }
                catch (Exception exception)
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        MessageBox.Show(exception.Message, Application.ProductName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _chatClient.Disconnect(true);
                        if (Owner != null) Owner.Show();
                        Close();
                    });
                }
            });
        }

        private void Log(string message)
        {
            textBox_log.AppendText(string.Format("[{0}] ", DateTime.Now.ToString("HH:mm:ss")));
            textBox_log.AppendText(message);
            textBox_log.AppendText(Environment.NewLine);
        }

        private void DisplayClientInfos()
        {
            label_userName.Text = _userName;
            label_localEndPoint.Text = string.Format("{0}:{1}",
                _chatClient.LocalEndPoint.Address, _chatClient.LocalEndPoint.Port);
            label_remoteEndPoint.Text = string.Format("{0}:{1}",
                _chatClient.RemoteEndPoint.Address, _chatClient.RemoteEndPoint.Port);
        }
        #endregion

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
