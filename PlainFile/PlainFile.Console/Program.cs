using PlainFile.Core;

var textFile = new SimpleTextFile("data.txt");
var lines = textFile.ReadAllLines().ToList();
var opc = string.Empty;

do
{
    opc = Menu();
    switch(opc)
    {
        case "1":
            Console.WriteLine("Contents:");
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
            }
            else
            {
                Console.WriteLine("No line added.");
            }
            break;
        case "3":
            textFile.WriteAllLines(lines.ToArray());
            Console.WriteLine("File saved.");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
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