// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows;

namespace SerialCommunicationApp
{
    public partial class MainWindow : Window
    {
        private SerialPort serialPort;
        private readonly List<string> receivedMessages = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeSerialPorts();
            DataContext = this;

        }

        // public List<string> ReceivedMessages => receivedMessages;

        private void InitializeSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            //--If you already create connection with another desktop 

            foreach (var port in ports)
            {
                comPortComboBox.Items.Add(port);
            }

            if (comPortComboBox.Items.Count > 0)
            {
                comPortComboBox.SelectedIndex = 0;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                string selectedPort = comPortComboBox.SelectedItem as string;
                int baudRate = int.Parse(baudRateTextBox.Text);

                serialPort = new SerialPort(selectedPort, baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort.Open();

                MessageBox.Show($"Connected to {selectedPort} at {baudRate} baud rate.", "Connection Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                string receivedHex = BitConverter.ToString(buffer).Replace("-", " ");

                receivedMessages.Add($"Received: {receivedHex}");

                Dispatcher.Invoke(() =>
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var stg in receivedMessages)
                    {
                        stringBuilder.AppendLine(stg);
                    }

                    receivedTextBox.Text = stringBuilder.ToString();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while receiving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    string hexMessage = sendTextBox.Text.Replace(" ", "");
                    byte[] bytes = new byte[hexMessage.Length / 2];

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = Convert.ToByte(hexMessage.Substring(i * 2, 2), 16);
                    }

                    serialPort.Write(bytes, 0, bytes.Length);

                    if (hexMessage != "")
                    {
                        receivedMessages.Add($"Sent: {hexMessage}");

                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (var stg in receivedMessages)
                        {
                            stringBuilder.AppendLine(stg);
                        }
                        receivedTextBox.Text = stringBuilder.ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Serial port is not open. Connect first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while sending data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            receivedMessages.Clear();
            receivedTextBox.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            comPortComboBox.Items.Clear();
            InitializeSerialPorts();
        }

    }
}
