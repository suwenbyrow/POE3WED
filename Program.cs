using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cybersecurity_Conversational_Chatbot
{
    class Program
    {
        // Stores the user's name
        static string studentName = "";

        // Random object for tips
        static Random random = new Random();

        // ---------------- Cybercrime Knowledge Base ----------------
        class CyberCrimeEntry
        {
            public string[] Keywords { get; set; } = Array.Empty<string>();
            public string Advice { get; set; } = "";
        }

        static List<CyberCrimeEntry> cyberCrimeDatabase = new List<CyberCrimeEntry>
        {
            new CyberCrimeEntry
            {
                Keywords = new string[] {"bank", "payment", "invoice", "money", "urgent"},
                Advice = "Bot: This sounds like a phishing or scam attempt. Banks usually do not demand immediate payments via email. Do not click links or provide personal info. Contact your bank directly using official channels."
            },
            new CyberCrimeEntry
            {
                Keywords = new string[] {"lottery", "winner", "prize"},
                Advice = "Bot: Be cautious! Emails claiming you won a lottery or prize are often scams. Never provide your bank info or pay fees to claim a prize."
            },
            new CyberCrimeEntry
            {
                Keywords = new string[] {"password", "account", "reset"},
                Advice = "Bot: If someone asks you to reset your password via email, verify the sender carefully. Do not click suspicious links; go to the official website directly."
            },
            new CyberCrimeEntry
            {
                Keywords = new string[] {"attachment", "malware", "virus"},
                Advice = "Bot: Be careful opening attachments from unknown sources. They may contain malware or viruses that can harm your system."
            },
            new CyberCrimeEntry
            {
                Keywords = new string[] {"social media", "profile", "hack"},
                Advice = "Bot: Protect your social media accounts with strong passwords and two-factor authentication. Be cautious of suspicious friend requests or messages."
            }
        };

        static void Main(string[] args)
        {
            PlayGreeting();
            DisplayAsciiArt();

            Console.WriteLine("--- Cybersecurity Conversational Assistant ---");
            Console.Write("Before we begin, what is your name? ");
            studentName = Console.ReadLine();

            ShowRandomTip();
            ChatLoop();
        }

        // ---------------- Multimedia / UI ----------------
        static void PlayGreeting()
        {
            Console.WriteLine("[System] Audio notification: 'Welcome to the Cybersecurity Portal.'");
        }

        static void DisplayAsciiArt()
        {
            string shieldArt = @"
               _________
              /         \
             |   SAFE    |
             |    [!]    |
              \_________/ ";
            Console.WriteLine(shieldArt);
            Console.WriteLine("Security Module Initialized.\n");
        }

        // ---------------- Conversation Loop ----------------
        static void ChatLoop()
        {
            Console.WriteLine($"\nHi {studentName}! You can ask me anything about cybersecurity.");
            Console.WriteLine("Type 'help' to see topics, 'exit' to quit.\n");

            while (true)
            {
                Console.Write($"{studentName}: ");
                string input = Console.ReadLine()?.ToLower() ?? "";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please type a question or topic.");
                    continue;
                }

                if (input.Contains("exit"))
                {
                    Console.WriteLine($"Bot: Stay safe, {studentName}! Goodbye.");
                    break;
                }
                else if (input.Contains("help"))
                {
                    ShowHelp();
                }
                else if (CheckCyberCrimeDatabase(input))
                {
                    // Handled inside CheckCyberCrimeDatabase
                }
                else if (input.Contains("password safety") || input.Contains("phishing"))
                {
                    ExplainPasswordAndPhishing();
                }
                else if (input.Contains("malware"))
                {
                    ExplainMalware();
                }
                else if (input.Contains("2fa") || input.Contains("two-factor") || input.Contains("authentication"))
                {
                    ExplainTwoFactorAuth();
                }
                else if (input.Contains("social engineering"))
                {
                    ExplainSocialEngineering();
                }
                else if (input.Contains("check password") || input.Contains("password strength"))
                {
                    PasswordStrengthChecker();
                }
                else if (input.Contains("quiz"))
                {
                    Quiz();
                }
                else if (input.Contains("tip") || input.Contains("advice"))
                {
                    ShowRandomTip();
                }
                else
                {
                    Console.WriteLine("Bot: I’m not sure about that. Try asking about phishing, passwords, malware, 2FA, social engineering, or say 'help' for options.");
                }
            }
        }

        // ---------------- Help ----------------
        static void ShowHelp()
        {
            Console.WriteLine("\nBot: Here are some things you can ask me about:");
            Console.WriteLine("- Password Safety & Phishing Tips");
            Console.WriteLine("- Malware Awareness");
            Console.WriteLine("- Two-Factor Authentication (2FA)");
            Console.WriteLine("- Social Engineering Awareness");
            Console.WriteLine("- Check Password Strength");
            Console.WriteLine("- Take Cybersecurity Quiz");
            Console.WriteLine("- Ask for a Tip or Advice");
            Console.WriteLine("- Type 'exit' to quit\n");
        }

        // ---------------- Cybercrime Knowledge Base ----------------
        static bool CheckCyberCrimeDatabase(string input)
        {
            foreach (var entry in cyberCrimeDatabase)
            {
                foreach (var keyword in entry.Keywords)
                {
                    if (input.Contains(keyword))
                    {
                        Console.WriteLine(entry.Advice + "\n");
                        return true;
                    }
                }
            }
            return false;
        }

        // ---------------- Educational Content ----------------
        static void ExplainPasswordAndPhishing()
        {
            Console.WriteLine("\nBot: --- Password Safety & Phishing Tips ---");

            Console.WriteLine("\nPassword Safety:");
            Console.WriteLine("- Use at least 12 characters with uppercase, lowercase, numbers, and symbols.");
            Console.WriteLine("- Avoid using the same password for multiple accounts.");
            Console.WriteLine("- Consider using a password manager.");

            Console.WriteLine("\nPhishing Awareness:");
            Console.WriteLine("- Phishing is when attackers pretend to be trusted sources to steal info.");
            Console.WriteLine("- Be cautious of emails asking for passwords or urgent actions.");
            Console.WriteLine("- Verify the sender and check for unusual links or attachments.\n");
        }

        static void ExplainMalware()
        {
            Console.WriteLine("\nBot: --- Malware Awareness ---");
            Console.WriteLine("Malware is malicious software that can harm your system or steal data.");
            Console.WriteLine("Types include viruses, ransomware, trojans, and spyware.\n");
        }

        static void ExplainTwoFactorAuth()
        {
            Console.WriteLine("\nBot: --- Two-Factor Authentication (2FA) ---");
            Console.WriteLine("2FA adds an extra layer of security by requiring a second verification step.");
            Console.WriteLine("Example: Entering a code sent to your phone after your password.\n");
        }

        static void ExplainSocialEngineering()
        {
            Console.WriteLine("\nBot: --- Social Engineering Awareness ---");
            Console.WriteLine("Social engineering tricks people into revealing sensitive info.");
            Console.WriteLine("Example: Someone pretending to be IT support asking for your password.\n");
        }

        // ---------------- Interactive Methods ----------------
        static void PasswordStrengthChecker()
        {
            Console.WriteLine("\nBot: --- Password Strength Checker ---");
            Console.Write("Enter a password to check: ");
            string password = Console.ReadLine() ?? "";

            int score = 0;
            if (password.Length >= 12) score++;
            if (Regex.IsMatch(password, @"[A-Z]")) score++;
            if (Regex.IsMatch(password, @"[a-z]")) score++;
            if (Regex.IsMatch(password, @"[0-9]")) score++;
            if (Regex.IsMatch(password, @"[\W_]")) score++;

            Console.WriteLine("Password Strength: " + (score switch
            {
                5 => "Very Strong",
                4 => "Strong",
                3 => "Moderate",
                2 => "Weak",
                _ => "Very Weak"
            }) + "\n");
        }

        static void Quiz()
        {
            Console.WriteLine("\nBot: --- Cybersecurity Quiz ---");
            int score = 0;

            // Question 1
            Console.WriteLine("1. What is a common sign of a phishing email?");
            Console.WriteLine("a) Familiar sender\nb) Generic greeting & urgent request\nc) Proper grammar");
            if ((Console.ReadLine() ?? "").ToLower() == "b") { score++; Console.WriteLine("Correct!"); }
            else Console.WriteLine("Incorrect. Correct answer: b");

            // Question 2
            Console.WriteLine("\n2. What is recommended for a strong password?");
            Console.WriteLine("a) 6 characters only\nb) Long, mix of letters, numbers, symbols\nc) Reuse old passwords");
            if ((Console.ReadLine() ?? "").ToLower() == "b") { score++; Console.WriteLine("Correct!"); }
            else Console.WriteLine("Incorrect. Correct answer: b");

            // Question 3
            Console.WriteLine("\n3. What does 2FA stand for?");
            Console.WriteLine("a) Two-Factor Authentication\nb) Two-Firewall Access\nc) Twice Failed Attempt");
            if ((Console.ReadLine() ?? "").ToLower() == "a") { score++; Console.WriteLine("Correct!"); }
            else Console.WriteLine("Incorrect. Correct answer: a");

            Console.WriteLine($"\nQuiz completed! You scored {score}/3.\n");
        }

        static void ShowRandomTip()
        {
            string[] tips = {
                "Tip: Never reuse passwords across accounts.",
                "Tip: Keep your software up to date to prevent vulnerabilities.",
                "Tip: Always verify sender emails before clicking links.",
                "Tip: Use a password manager to generate strong passwords."
            };
            int index = random.Next(tips.Length);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nBot: " + tips[index] + "\n");
            Console.ResetColor();
        }
    }
}