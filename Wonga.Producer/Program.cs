using Wonga.Producer;

Console.WriteLine("Enter your name:");
var name = Console.ReadLine();
var message = $"Hello my name is, {name}";

try
{
    Console.WriteLine(message);
    Message.ProduceMessage(message);

    Console.WriteLine("Press the 'Enter Key' to exit.");
    Console.ReadLine();
}
//For this simple console app, I have used the broad catch exception: catch(Exception ex).
// In a real world app, it's a good practice to catch specific exceptions and handle them first
// before handling the more general and broad catch exception.
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong: {ex.Message}");
}

