using PlainFile.Core;

var textFile = new SimpleTextFile("data.txt");
var lines = textFile.ReadAllLines().ToList();
var opc = string.Empty;

using var logger = new LogWriter("app.log");
logger.WriteLog("INFO", "Application started.");

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.WriteLine("Contents:");
            logger.WriteLog("INFO", "The file was displayed.");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            break;
        case "2":
            Console.Write("Enter a new line: ");
            var newLine = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLine))
            {
                lines.Add(newLine);
                Console.WriteLine("Line added.");
                logger.WriteLog("INFO", $"A new line was added: {newLine}");
            }
            else
            {
                Console.WriteLine("No line added.");
                logger.WriteLog("WARNING", "Attempted to add an empty line.");
            }
            break;
        case "3":
            textFile.WriteAllLines(lines.ToArray());
            Console.WriteLine("File saved.");
            logger.WriteLog("INFO", "The file was saved.");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            logger.WriteLog("INFO", "Application exited.");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            logger.WriteLog("ERROR", $"Invalid menu option selected: {opc}");
            break;
    }
} while (opc != "0");
textFile.WriteAllLines(lines.ToArray());

string Menu()
{
    Console.WriteLine("1. Show");
    Console.WriteLine("2. Add");
    Console.WriteLine("3. Save");
    Console.WriteLine("0. Exit");
    Console.Write("Option: ");
    return Console.ReadLine() ?? string.Empty;
}