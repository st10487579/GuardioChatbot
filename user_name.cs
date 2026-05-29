using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace GuardioChatbot
{
    // Handles usernames and chat messages
    public class UserName
    {
        // METHOD TO SAVE AND CHECK USERNAME
        public string SubmitName(TextBox userName, ListView chats)
        {
            // FILE NAME
            string filename = "user_names.txt";

            // CREATE FILE IF IT DOES NOT EXIST
            if (!File.Exists(filename))
            {
                File.AppendAllText(filename, "auto_create\n");
            }

            // GET USER NAME
            string name = userName.Text.Trim();

            // CHECK IF EMPTY
            if (string.IsNullOrWhiteSpace(name))
            {
                ErrorMethod(
                    "ChatBot",
                    "Please enter your name first.",
                    chats);

                return "";
            }

            // CHECK IF USER EXISTS
            bool found = CheckName(name);

            // NEW USER
            if (!found)
            {
                File.AppendAllText(filename, name + "\n");

                ErrorMethod(
                    "ChatBot",
                    "Hey " + name +
                    ", welcome to AI cybersecurity.",
                    chats);
            }
            else
            {
                // EXISTING USER
                ErrorMethod(
                    "ChatBot",
                    "Hey " + name +
                    ", welcome back! How can I help you today?",
                    chats);
            }

            return name;
        }

        // METHOD TO CHECK USERNAME
        private bool CheckName(string name)
        {
            string filename = "user_names.txt";

            // READ ALL NAMES
            string[] names =
                File.ReadAllLines(filename);

            // SEARCH FOR NAME
            foreach (string storedName in names)
            {
                if (storedName.ToLower() ==
                    name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        // DISPLAY CHAT MESSAGE
        private void ErrorMethod(
            string name,
            string message,
            ListView chats)
        {
            // MESSAGE BORDER
            Border messageBorder =
                new Border
                {
                    Margin =
                        new Thickness(0, 2, 0, 2),

                    Padding =
                        new Thickness(5, 3, 5, 3),

                    CornerRadius =
                        new CornerRadius(5),

                    BorderThickness =
                        new Thickness(1)
                };

            // BOT OR USER COLORS
            bool isBot =
                name.ToLower().Contains("chatbot") ||
                name.ToLower().Contains("chat");

            if (isBot)
            {
                // LIGHT BLUE
                messageBorder.Background =
                    new SolidColorBrush(
                        Color.FromRgb(240, 248, 255));

                messageBorder.BorderBrush =
                    new SolidColorBrush(
                        Color.FromRgb(173, 216, 230));
            }
            else
            {
                // LIGHT GRAY
                messageBorder.Background =
                    new SolidColorBrush(
                        Color.FromRgb(245, 245, 245));

                messageBorder.BorderBrush =
                    new SolidColorBrush(
                        Color.FromRgb(211, 211, 211));
            }

            // TEXTBLOCK
            TextBlock messageText =
                new TextBlock
                {
                    TextWrapping =
                        TextWrapping.Wrap,

                    Margin =
                        new Thickness(2)
                };

            // NAME COLOR
            Brush nameColor =
                isBot
                ? Brushes.DarkBlue
                : Brushes.DarkGreen;

            // NAME
            messageText.Inlines.Add(
                new Run
                {
                    Text = name + ": ",
                    Foreground = nameColor,
                    FontWeight = FontWeights.Bold
                });

            // MESSAGE
            messageText.Inlines.Add(
                new Run
                {
                    Text = message,
                    Foreground = Brushes.Black
                });

            // ADD TO BORDER
            messageBorder.Child =
                messageText;

            // ADD TO CHAT LIST
            chats.Items.Add(messageBorder);
        }
    }
}