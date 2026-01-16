



while (true)
{ 
    PrintMainMenu();

    Console.Write("Tanlang (1-5): ");
    string choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            CrudMenu("School");
            break;
        case "2":
            CrudMenu("Student");
            break;
        case "3":
            CrudMenu("Teacher");
            break;
        case "4":
            CrudMenu("Subject");
            break;
        case "5":
            Console.WriteLine("Dastur yakunlandi.");
            return;
        default:
            Console.WriteLine("Noto'g'ri tanlov!");
            Pause();
            break;
    }
}

void PrintMainMenu()
{
    Console.WriteLine("====================================");
    Console.WriteLine("          ASOSIY MENU");
    Console.WriteLine("====================================");
    Console.WriteLine(" Qaysi Model ustida amaliyot bajarmoqchisiz.");
    Console.WriteLine("1. School");
    Console.WriteLine("2. Student");
    Console.WriteLine("3. Teacher");
    Console.WriteLine("4. Subject");
    Console.WriteLine("5. Exit");
    Console.WriteLine("====================================");
}

void CrudMenu(string modelName)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine($"      {modelName.ToUpper()} CRUD MENU");
        Console.WriteLine("====================================");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Get");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Back (Asosiy menuga qaytish)");
        Console.WriteLine("====================================");

        Console.Write("Tanlang (1-5): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Create();
                break;
            case "2":
                GetAll();
                break;
            case "3":
                Update();
                break;
            case "4":
                Delete();
                break;
            case "5":
                return; 
            default:
                Console.WriteLine("Noto'g'ri tanlov!");
                Pause();
                break;
        }
    }
}


void Create()
{
    
}

void GetAll()
{

}

void Update()
{

}

void Delete()
{

}

void Pause()
{
    Console.WriteLine();
    Console.Write("Davom etish uchun Enter bosing...");
    Console.ReadLine();
}
namespace Repository
{
    internal class T
    {

    }
}
