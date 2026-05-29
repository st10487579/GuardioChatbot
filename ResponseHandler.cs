using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuardioChatbot
{
    // Handles chatbot responses
    public class ResponseHandler
    {
        private Random random =
            new Random();

        // ========================= RESPONSES =========================

        private Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>();

        // ========================= KEYWORD MAP =========================

        private Dictionary<string, string[]> keywordMap =
            new Dictionary<string, string[]>();

        // ========================= CONSTRUCTOR =========================

        public ResponseHandler()
        {
            // ================= GREETINGS =================

            responses["greeting"] =
                new List<string>()
            {
                "Hello! I'm here to help keep you safe online.",
                "Hi there! What cybersecurity topic would you like help with today?",
                "Hey! How can I assist you with cybersecurity today?"
            };

            // ================= PHISHING =================

            responses["phishing"] =
                new List<string>()
            {
                "Phishing is a scam where attackers pretend to be trusted sources to steal your information.",
                "Be careful of suspicious emails asking for passwords or banking details.",
                "Always verify links and email senders before clicking anything."
            };

            // ================= PASSWORD =================

            responses["password"] =
                new List<string>()
            {
                "Strong passwords should contain letters, numbers and symbols.",
                "Never reuse the same password across multiple accounts.",
                "Using a password manager can improve your online security."
            };

            // ================= FIREWALL =================

            responses["firewall"] =
                new List<string>()
            {
                "A firewall helps block unauthorised access to your network.",
                "Firewalls monitor incoming and outgoing traffic for threats.",
                "A firewall acts like a security guard for your device."
            };

            // ================= VPN =================

            responses["vpn"] =
                new List<string>()
            {
                "A VPN encrypts your internet connection for better privacy.",
                "VPNs help protect you when using public Wi-Fi.",
                "Using a VPN improves online security and anonymity."
            };

            // ================= MALWARE =================

            responses["malware"] =
                new List<string>()
            {
                "Malware is harmful software designed to damage devices or steal information.",
                "Viruses, worms and trojans are common types of malware.",
                "Always keep antivirus software updated to protect against malware."
            };

            // ================= RANSOMWARE =================

            responses["ransomware"] =
                new List<string>()
            {
                "Ransomware locks your files until payment is made.",
                "Always back up important files to protect against ransomware.",
                "Avoid downloading files from unknown sources."
            };

            // ================= 2FA =================

            responses["2fa"] =
                new List<string>()
            {
                "Two-factor authentication adds an extra layer of security.",
                "2FA helps protect accounts even if passwords are stolen.",
                "Authenticator apps are safer than SMS verification."
            };

            // ================= SOCIAL ENGINEERING =================

            responses["social engineering"] =
                new List<string>()
            {
                "Social engineering tricks people into giving away information.",
                "Attackers often pretend to be trusted people or companies.",
                "Always verify requests for personal information."
            };

            // ================= PUBLIC WIFI =================

            responses["public wifi"] =
                new List<string>()
            {
                "Public Wi-Fi networks can expose your personal data.",
                "Avoid banking or sensitive logins on public Wi-Fi.",
                "Using a VPN on public Wi-Fi is highly recommended."
            };

            // ================= WORRIED =================

            responses["worried"] =
                new List<string>()
            {
                "It's okay to feel worried. I'm here to help you stay safe online.",
                "Don't panic. Most cybersecurity issues can be solved safely.",
                "I understand your concern. Let's work through it together."
            };

            // ================= FRUSTRATED =================

            responses["frustrated"] =
                new List<string>()
            {
                "I understand this can feel frustrating.",
                "Cybersecurity issues can be stressful, but I'll help you.",
                "Let's solve the issue step by step together."
            };

            // ================= HAPPY =================

            responses["happy"] =
                new List<string>()
            {
                "That's great to hear!",
                "Awesome! I'm glad things are going well.",
                "It's good to hear you're feeling positive today."
            };

            // ================= SAD =================

            responses["sad"] =
                new List<string>()
            {
                "I'm sorry you're feeling this way.",
                "I hope things improve soon.",
                "Take things one step at a time."
            };

            // ================= CONFUSED =================

            responses["confused"] =
                new List<string>()
            {
                "That's okay, cybersecurity can be confusing at first.",
                "No worries, I'll explain it clearly.",
                "I'll help make it easier to understand."
            };

            // ================= DEFAULT =================

            responses["default"] =
                new List<string>()
            {
                "I'm not sure I understand. Could you rephrase that?",
                "Can you explain your question differently?",
                "Try asking another cybersecurity question."
            };

            // ================= KEYWORD MAP =================

            keywordMap["greeting"] =
                new string[]
            {
                "hello", "hi", "hey"
            };

            keywordMap["phishing"] =
                new string[]
            {
                "phishing",
                "fake email",
                "scam email",
                "suspicious email"
            };

            keywordMap["password"] =
                new string[]
            {
                "password",
                "passcode",
                "credentials",
                "login"
            };

            keywordMap["firewall"] =
                new string[]
            {
                "firewall",
                "security barrier"
            };

            keywordMap["vpn"] =
                new string[]
            {
                "vpn",
                "private network"
            };

            keywordMap["malware"] =
                new string[]
            {
                "malware",
                "virus",
                "trojan",
                "worm"
            };

            keywordMap["ransomware"] =
                new string[]
            {
                "ransomware",
                "locked files"
            };

            keywordMap["2fa"] =
                new string[]
            {
                "2fa",
                "two factor authentication",
                "verification code"
            };

            keywordMap["social engineering"] =
                new string[]
            {
                "social engineering",
                "manipulation"
            };

            keywordMap["public wifi"] =
                new string[]
            {
                "public wifi",
                "public wi-fi"
            };

            // ================= SENTIMENT KEYWORDS =================

            keywordMap["worried"] =
                new string[]
            {
                "worried",
                "scared",
                "afraid",
                "nervous"
            };

            keywordMap["frustrated"] =
                new string[]
            {
                "frustrated",
                "angry",
                "mad",
                "annoyed"
            };

            keywordMap["happy"] =
                new string[]
            {
                "happy",
                "excited",
                "great",
                "awesome"
            };

            keywordMap["sad"] =
                new string[]
            {
                "sad",
                "upset",
                "depressed"
            };

            keywordMap["confused"] =
                new string[]
            {
                "confused",
                "lost",
                "don't understand"
            };
        }

        // ========================= MAIN RESPONSE METHOD =========================

        public string GetResponse(string input,
                                  MemoryManager memory,
                                  string sentiment)
        {
            input = input.ToLower();

            // ================= PRIORITY 1: SENTIMENT RESPONSES =================

            if (sentiment == "worried")
            {
                return "It's okay to feel worried. I'm here to help you stay safe online. " +
                       "Most cybersecurity issues can be solved calmly and safely.";
            }

            if (sentiment == "frustrated")
            {
                return "I understand this can feel frustrating. Let's solve it step by step together.";
            }

            if (sentiment == "sad")
            {
                return "I'm sorry you're feeling this way. I'm here to support you.";
            }

            if (sentiment == "happy")
            {
                return "That's great to hear! 😊 Let's continue learning cybersecurity.";
            }

            if (sentiment == "confused")
            {
                return "No worries — I'll explain it in a simple way for you.";
            }

            // FOLLOW-UP QUESTIONS

            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(memory.LastTopic))
                {
                    return GetFollowUp(memory.LastTopic);
                }
            }

            // SEARCH KEYWORDS (FIXED PRIORITY SYSTEM)
            foreach (var topic in keywordMap.Keys)
            {
                foreach (var word in keywordMap[topic])
                {
                    if (input.Contains(word))
                    {
                        memory.LastTopic = topic;
                        memory.FavouriteTopic = topic;
                        memory.PreviousTopics.Add(topic);

                        return GetRandomResponse(topic);
                    }
                }
            }

            // DEFAULT

            return "I'm not sure I understand. Could you rephrase that?";
        }

        // ========================= RANDOM RESPONSE =========================

        private string GetRandomResponse(string topic)
        {
            List<string> possibleResponses =
                responses[topic];

            int index =
                random.Next(possibleResponses.Count);

            return possibleResponses[index];
        }

        // ========================= FOLLOW UPS =========================

        private string GetFollowUp(string topic)
        {
            if (topic == "phishing")
            {
                return "Another phishing tip is to avoid clicking unknown links.";
            }

            if (topic == "password")
            {
                return "Using two-factor authentication improves password security.";
            }

            if (topic == "vpn")
            {
                return "VPNs are especially useful when using public Wi-Fi.";
            }

            if (topic == "malware")
            {
                return "Updating your software helps protect against malware.";
            }

            return "Cybersecurity awareness helps keep your information safe online.";
        }
    }
}