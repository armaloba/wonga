using System.Text;
using System.Text.RegularExpressions;

namespace Wonga.Consumer
{
    public class Message
    {
        public static void ProcessReceivedMessage(byte[] body)
        {
            var format = "Hello my name is,";
            var message = Encoding.UTF8.GetString(body);
            string receivedName;
            
            try
            {
                receivedName = ValidateReceivedMessage(format, message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"Hello {receivedName}, I am your father!");
        }
        public static string ValidateReceivedMessage(string format, string message)
        {
            var pattern = $@"^{format} (.+)$";
            var match = Regex.Match(message, pattern);

            if (!match.Success)
            {
                throw new ArgumentException($"Received invalid message format: {format}");
            }

            return match.Groups[1].Value;
        }
    }
}


