using PlainFile.Core;


Console.Write("Enter the list name (Default 'people'): ");
var listName = Console.ReadLine();
if (string.IsNullOrEmpty(listName))
{
    listName = "people";
}

var filePath = $"{listName}.csv";
var helper = new NugetCsvHelper();
var people = helper.Read(filePath);
string option;

do
{
    option = ShowMenu();
    Console.WriteLine();

    switch (option)
    {
        case "1":
            AddPerson(people);
            break;
        case "2":
            ListPeople(people);
            break;
        case "3":
            helper.Write(filePath, people);
            Console.WriteLine("✅ File saved.");
            break;
        case "4":
            DeletePerson(people);
            break;
        case "5":
            people = people.OrderBy(p => p.Name).ToList();
            Console.WriteLine("✅ List ordered by name.");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("⚠️ Invalid option.");
            break;
    }

} while (option != "0");
    }

    static string ShowMenu()
{
    Console.WriteLine("\n=== MENU ===");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show");
    Console.WriteLine("3. Save");
    Console.WriteLine("4. Delete");
    Console.WriteLine("5. Order");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    return Console.ReadLine() ?? string.Empty;
}

static void ListPeople(List<Person> people)
{
    Console.WriteLine("\nList of people:");
    Console.WriteLine($"{"ID",-5}{"Name",-15}{"LastName",-15}{"Age",-5}");
    foreach (var person in people)
    {
        Console.WriteLine($"{person.Id,-5}{person.Name,-15}{person.LastName,-15}{person.Age,-5}");
    }
}

static void AddPerson(List<Person> people)
{
    Console.Write("Enter Id: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("⚠️ Invalid Id. It must be a number.");
        return;
    }

    Console.Write("Enter name: ");
    var name = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter lastname: ");
    var lastName = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter age: ");
    if (!int.TryParse(Console.ReadLine(), out var age))
    {
        Console.WriteLine("⚠️ Invalid age. It must be a number.");
        return;
    }

    people.Add(new Person { Id = id, Name = name, LastName = lastName, Age = age });
    Console.WriteLine("✅ Person added.");
}

static void DeletePerson(List<Person> people)
{
    Console.Write("Enter the name of the person to delete: ");
    var nameToDelete = Console.ReadLine();
    var personToDelete = people.FirstOrDefault(p => p.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

    if (personToDelete != null)
    {
        people.Remove(personToDelete);
        Console.WriteLine("✅ Person deleted.");
    }
    else
    {
        Console.WriteLine("⚠️ Person not found.");
    }
}
