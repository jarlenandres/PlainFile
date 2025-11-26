using PlainFile.Core;

Console.Write("Enter the list name (Defaul 'people'): ");
var listName = Console.ReadLine();
if (string.IsNullOrEmpty(listName))
{
    listName = "people";
}

var helper = new NugetCsvHelper();
var poeple = helper.Read($"{listName}.csv").ToList();
var option = string.Empty;

do
{
    option = MyMenu();
    Console.WriteLine();
    Console.WriteLine();
    switch (option)
    {
        case "1":
            Add();
            break;
        case "2":
            ListPeople();
            break;
        case "3":
           // SaveFile(poeple, listName);
            Console.WriteLine("File saved.");
            break;
        case "4":
            Console.Write("Enter the name of the person to delete: ");
            var nameToDelete = Console.ReadLine();
           //// var personToDelete = poeple.Find(p => p[0].Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));
           // if (personToDelete != null)
           // {
           //     poeple.Remove(personToDelete);
           //     Console.WriteLine("Person deleted.");
           // }
           // else
           // {
           //     Console.WriteLine("Person not found.");
           // }
            break;
        case "5":
            //poeple.Sort((a, b) => string.Compare(a[0], b[0], StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("List ordered by name.");
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

} while (option != "0");

void ListPeople()
{
    Console.WriteLine("List of people:");
    Console.WriteLine($"Nombres | Apellidos | Edad");
    foreach (var person in poeple)
    {
        Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Age: {person.Age}");
    }
}

void Add()
{
    Console.Write("Enter Id: ");
    if (int.TryParse(Console.ReadLine(), out var id))
    {
        return;
    }
    else
    {
        Console.WriteLine("Invalid Id. It must be a number.");
        return;
    }
    Console.Write("Enter name: ");
    var name = Console.ReadLine();
    Console.Write("Enter lastname: ");
    var lastName = Console.ReadLine();
    Console.Write("Entre age: ");
    Console.Write("Enter Id: ");
    if (int.TryParse(Console.ReadLine(), out var age))
    {
        return;
    }
    else
    {
        Console.WriteLine("Invalid Id. It must be a number.");
        return;
    }
    poeple.Add(new Person { Id = id, Name = name, Age = age });
}

string MyMenu()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("1. Add.");
    Console.WriteLine("2. Show.");
    Console.WriteLine("3. Save.");
    Console.WriteLine("4. Delete.");
    Console.WriteLine("5. Order.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("Select an option: ");
    return Console.ReadLine() ?? string.Empty;
}

//SaveFile(poeple, listName);

void SaveFile(IEnumerable<Person> poeple)
{
   // NugetCsvHelper.Write(poeple);
}