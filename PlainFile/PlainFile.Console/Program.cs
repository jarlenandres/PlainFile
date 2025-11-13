using PlainFile.Core;

Console.Write("Enter the list name: ");
var listName = Console.ReadLine();
var manualCsv = new ManualCsvHelper();
var poeple = manualCsv.ReadCsv($"{listName}.csv");
var option = string.Empty;

do
{
    switch(option)
    {
        case "1":
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter lastname: ");
            var lastName= Console.ReadLine();
            Console.Write("Entre age: ");
            var age = Console.ReadLine();
            poeple.Add(new string[] { name ?? string.Empty, lastName ?? string.Empty, age ?? string.Empty });
            break;
        case "2":
            Console.WriteLine("List of people:");
            Console.WriteLine($"Nombres | Apellidos | Edad");
            foreach (var person in poeple)
            {
                Console.WriteLine($"{person[0]} | {person[1]} | {person[2]}");
            }
            break;
        case "3":
            SaveFile(poeple, listName);
            Console.WriteLine("File saved.");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
    option = MyMenu();
} while (option != "0");

string MyMenu()
{
    Console.WriteLine("1. Add.");
    Console.WriteLine("2. Show.");
    Console.WriteLine("3. Save.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("Select an option: ");
    return Console.ReadLine() ?? string.Empty;
}

SaveFile(poeple, listName);

void SaveFile(List<string[]> poeple, string? listName)
{
    manualCsv.WriteCsv($"{listName}.csv", poeple);
}