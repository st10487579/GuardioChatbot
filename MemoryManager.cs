using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardioChatbot
{
    // Stores chatbot memory and user information
    public class MemoryManager
    {
        // User name
        public string UserName { get; set; }

        // Favourite cybersecurity topic
        public string FavouriteTopic { get; set; }

        // Last discussed topic
        public string LastTopic { get; set; }

        // Last detected emotion
        public string LastEmotion { get; set; }

        // Stores previous conversation topics
        public List<string> PreviousTopics =
            new List<string>();
        public string lastEmotion { get; set; }

        // Number of messages sent
        public int ConversationCount { get; set; }
    }
}