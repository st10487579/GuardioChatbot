using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuardioChatbot
{
    // Detects user emotions
    public class SentimentAnalyzer
    {
        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            // WORRIED
            if (input.Contains("worried") ||
                input.Contains("scared") ||
                input.Contains("afraid") ||
                input.Contains("nervous"))
            {
                return "worried";
            }

            // FRUSTRATED / ANGRY
            if (input.Contains("frustrated") ||
                input.Contains("angry") ||
                input.Contains("mad") ||
                input.Contains("annoyed"))
            {
                return "frustrated";
            }

            // HAPPY
            if (input.Contains("happy") ||
                input.Contains("excited") ||
                input.Contains("great") ||
                input.Contains("awesome"))
            {
                return "happy";
            }

            // SAD
            if (input.Contains("sad") ||
                input.Contains("upset") ||
                input.Contains("depressed") ||
                input.Contains("unhappy"))
            {
                return "sad";
            }

            // CONFUSED
            if (input.Contains("confused") ||
                input.Contains("lost") ||
                input.Contains("don't understand") ||
                input.Contains("unsure"))
            {
                return "confused";
            }

            return "neutral";
        }
    }
}