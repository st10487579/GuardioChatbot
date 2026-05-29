using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuardioChatbot
{
    // Delegate declaration
    public delegate string ResponseDelegate(string input);

    // Main chatbot manager
    public class ChatbotManager
    {

        private ResponseHandler responseHandler =
            new ResponseHandler();

        private SentimentAnalyzer sentimentAnalyzer =
            new SentimentAnalyzer();

        private MemoryManager memory =
            new MemoryManager();

        // USERNAME PROPERTY

        public string UserName
        {
            get { return memory.UserName; }
            set { memory.UserName = value; }
        }

        // ========================= MAIN CHATBOT LOGIC =========================

        public string ProcessMessage(string input)
        {

            input = input.ToLower();

            memory.ConversationCount++;

            string sentiment =
                sentimentAnalyzer.DetectSentiment(input);

            memory.LastEmotion = sentiment;

            // ONLY ONE SOURCE OF TRUTH
            string response =
                responseHandler.GetResponse(input, memory, sentiment);

            return response;
        }
    }
}


    