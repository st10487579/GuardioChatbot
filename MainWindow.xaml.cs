using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuardioChatbot
{
    public partial class MainWindow : Window
    {//Start of class
        // Chatbot object
        private ChatbotManager chatbot =
            new ChatbotManager();

        // Stores username
        private string userName = "";


        public MainWindow()
        {
            InitializeComponent();

            // Play voice greeting
            try
            {
                SoundPlayer player =
                    new SoundPlayer("voice.wav");

                player.Play();
            }
            catch
            {
                //ignore if file not found or error occurs
            }
        }

        // make sure this is included

// Show typing effect for Guardio messages
private async Task DisplayBotMessage(string message)
    {
        // Add "Guardio is typing..." placeholder
        AddMessage("Guardio", "Typing...");

        await Task.Delay(1200); // simulate typing delay

        // Remove the placeholder
        RemoveLastMessage();

        // Add the actual message
        AddMessage("Guardio", message);
    }

    // Remove the last message block
    private void RemoveLastMessage()
    {
        var blocks = ChatBox.Document.Blocks;
        if (blocks.Count > 0)
        {
            blocks.Remove(blocks.LastBlock);
        }
    }

    // ========================= START BUTTON =========================

    private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomeGrid.Visibility =
                Visibility.Collapsed;

            UsernameGrid.Visibility =
                Visibility.Visible;
        }

        // ========================= USERNAME VALIDATION =========================

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string name =
                NameInputBox.Text.Trim();

            // EMPTY VALIDATION
            if (string.IsNullOrWhiteSpace(name))
            {
                ValidationMessage.Text =
                    "Please enter your name.";

                return;
            }

            // MINIMUM LENGTH VALIDATION
            if (name.Length < 3)
            {
                ValidationMessage.Text =
                    "Name must be at least 3 characters.";

                return;
            }

            // NUMBER VALIDATION
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    ValidationMessage.Text =
                        "Name cannot contain numbers.";

                    return;
                }
            }

            // SAVE USERNAME
            userName = name;

            chatbot.UserName = name;

            // SWITCH GRIDS
            UsernameGrid.Visibility =
                Visibility.Collapsed;

            ChatbotGrid.Visibility =
                Visibility.Visible;

            // ASCII welcome
            AddMessage("Guardio", @"
  ____ _   _   _    ____  ____ ___ ___
 / ___| | | | / \  |  _ \|  _ |_ _/ _ \
| |  _| | | |/ _ \ | |_) | | | | | | | |
| |_| | |_| / ___ \|  _ <| |_| | | |_| |
 \____|\___/_/   \_|_| \_|____|___\___/

Cybersecurity Awareness Assistant
");

        // CHATBOT GREETING
        AddMessage("Guardio",
                "Welcome " + userName +
                "! I'm here to provide information and assistance on all things cybersecurity.\n\nHow can I help you?");
        }

        // ========================= SEND BUTTON =========================

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            sendMessage();
        }

           // ========================= ENTER KEY =========================

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true; // Prevents mutiple triggers
                sendMessage();
            }
        }

        private void sendMessage()
        {
            string message =
                InputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
            {
                AddMessage("Guardio", "Please type a message before sending.");
                return;
            }
            // ADD USER MESSAGE
            AddMessage(userName, message);
            // CLEAR INPUT
            InputBox.Text = "";
            // GET BOT RESPONSE
            string response =
                chatbot.ProcessMessage(message);
            // DISPLAY BOT RESPONSE WITH TYPING EFFECT
            _ = DisplayBotMessage(response);
        }
        // ========================= CHAT DISPLAY =========================

        private void AddMessage(string sender, string message)
        {
            Paragraph paragraph =
                new Paragraph();

            // TIME
            Run timeRun =
                new Run("[" +
                DateTime.Now.ToShortTimeString() +
                "] ");

            timeRun.Foreground =
                Brushes.Gray;

            paragraph.Inlines.Add(timeRun);

            // SENDER
            Run senderRun =
                new Run(sender + ": ");

            senderRun.FontWeight =
                FontWeights.Bold;

            // BOT COLOR
            if (sender == "Guardio")
            {
                senderRun.Foreground =
                    Brushes.LightGreen;
            }

            // USER COLOR
            else
            {
                senderRun.Foreground =
                    Brushes.LightBlue;
            }

            paragraph.Inlines.Add(senderRun);

            // MESSAGE
            Run messageRun =
                new Run(message);

            messageRun.Foreground =
                Brushes.White;

            paragraph.Inlines.Add(messageRun);

            // ADD MESSAGE
            ChatBox.Document.Blocks.Add(paragraph);

            ChatBox.ScrollToEnd();
        }
    }
}