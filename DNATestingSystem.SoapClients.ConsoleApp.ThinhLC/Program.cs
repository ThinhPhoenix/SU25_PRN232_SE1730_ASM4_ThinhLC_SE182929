using SampleThinhLCSoapWCFServiceReference;
using SampleTypeThinhLCSoapWCFServiceReference;
// Alias để tránh ambiguous reference
using SampleThinhLcModel = SampleThinhLCSoapWCFServiceReference.SampleThinhLc;
using SampleTypeThinhLcModel = SampleTypeThinhLCSoapWCFServiceReference.SampleTypeThinhLc;

class Program
{
    static async Task Main(string[] args)
    {
        var sampleClient = new SampleThinhLCSoapServiceClient();
        var sampleTypeClient = new SampleTypeThinhLCSoapServiceClient();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. SampleThinhLc CRUD");
            Console.WriteLine("2. SampleTypeThinhLc CRUD");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
            var mainChoice = Console.ReadLine();
            switch (mainChoice)
            {
                case "1":
                    await SampleThinhLcCrud(sampleClient);
                    break;
                case "2":
                    await SampleTypeThinhLcCrud(sampleTypeClient);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static async Task SampleThinhLcCrud(SampleThinhLCSoapServiceClient client)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- SampleThinhLC CRUD ---");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Get by ID");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var all = await client.GetSampleThinhLCsAsync();
                    foreach (var s in all)
                    {
                        Console.WriteLine($"ID: {s.SampleThinhLcid}, Notes: {s.Notes}, Count: {s.Count}, isProcessed: {s.IsProcessed}, CollectedAt: {s.CollectedAt}, CreatedAt: {s.CreatedAt}, UpdatedAt: {s.UpdatedAt}, DeletedAt: {s.DeletedAt}");
                    }
                    break;
                case "2":
                    Console.Write("Enter ID: ");
                    if (int.TryParse(Console.ReadLine(), out int gid))
                    {
                        var item = await client.GetSampleThinhLCByIdAsync(gid);
                        if (item != null && item.SampleThinhLcid != null)
                        {
                            Console.WriteLine($"ID: {item.SampleThinhLcid}, Notes: {item.Notes}, Count: {item.Count}, isProcessed: {item.IsProcessed}, CollectedAt: {item.CollectedAt}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}, DeletedAt: {item.DeletedAt}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "3":
                    var create = new SampleThinhLcModel();
                    Console.Write("ProfileThinhLcid: "); create.ProfileThinhLcid = int.TryParse(Console.ReadLine(), out int pid) ? pid : null;
                    Console.Write("SampleTypeThinhLcid: "); create.SampleTypeThinhLcid = int.TryParse(Console.ReadLine(), out int stid) ? stid : null;
                    Console.Write("AppointmentsTienDmid: "); create.AppointmentsTienDmid = int.TryParse(Console.ReadLine(), out int aid) ? aid : null;
                    Console.Write("Notes: "); create.Notes = Console.ReadLine();
                    Console.Write("IsProcessed (true/false): "); var isProc = Console.ReadLine(); create.IsProcessed = bool.TryParse(isProc, out bool ip) ? ip : null;
                    Console.Write("Count: "); create.Count = int.TryParse(Console.ReadLine(), out int c) ? c : null;
                    create.CollectedAt = DateTime.Now;
                    create.CreatedAt = DateTime.Now;
                    create.UpdatedAt = DateTime.Now;
                    create.DeletedAt = null;
                    var cr = await client.CreateSampleThinhLCAsync(create);
                    Console.WriteLine($"Created, result: {cr}");
                    break;
                case "4":
                    Console.Write("Enter ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int uid))
                    {
                        var up = await client.GetSampleThinhLCByIdAsync(uid);
                        if (up != null && up.SampleThinhLcid != null)
                        {
                            string pidStr, stidStr, aidStr, isProcStr, cntStr;
                            Console.Write($"ProfileThinhLcid ({up.ProfileThinhLcid}): "); pidStr = Console.ReadLine(); if (int.TryParse(pidStr, out int pidVal)) up.ProfileThinhLcid = pidVal; else if (!string.IsNullOrWhiteSpace(pidStr) && pidStr != up.ProfileThinhLcid?.ToString()) up.ProfileThinhLcid = null;
                            Console.Write($"SampleTypeThinhLcid ({up.SampleTypeThinhLcid}): "); stidStr = Console.ReadLine(); if (int.TryParse(stidStr, out int stidVal)) up.SampleTypeThinhLcid = stidVal; else if (!string.IsNullOrWhiteSpace(stidStr) && stidStr != up.SampleTypeThinhLcid?.ToString()) up.SampleTypeThinhLcid = null;
                            Console.Write($"AppointmentsTienDmid ({up.AppointmentsTienDmid}): "); aidStr = Console.ReadLine(); if (int.TryParse(aidStr, out int aidVal)) up.AppointmentsTienDmid = aidVal; else if (!string.IsNullOrWhiteSpace(aidStr) && aidStr != up.AppointmentsTienDmid?.ToString()) up.AppointmentsTienDmid = null;
                            Console.Write($"Notes ({up.Notes}): "); var n = Console.ReadLine(); if (!string.IsNullOrEmpty(n)) up.Notes = n;
                            Console.Write($"IsProcessed ({up.IsProcessed}): "); isProcStr = Console.ReadLine(); if (bool.TryParse(isProcStr, out bool ipVal)) up.IsProcessed = ipVal; else if (!string.IsNullOrWhiteSpace(isProcStr) && isProcStr != up.IsProcessed?.ToString()) up.IsProcessed = null;
                            Console.Write($"Count ({up.Count}): "); cntStr = Console.ReadLine(); if (int.TryParse(cntStr, out int cntVal)) up.Count = cntVal; else if (!string.IsNullOrWhiteSpace(cntStr) && cntStr != up.Count?.ToString()) up.Count = null;
                            up.UpdatedAt = DateTime.Now;
                            var ur = await client.UpdateSampleThinhLCAsync(up);
                            Console.WriteLine($"Updated, result: {ur}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int did))
                    {
                        var dr = await client.DeleteSampleThinhLCAsync(did);
                        Console.WriteLine($"Deleted, result: {dr}");
                    }
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static async Task SampleTypeThinhLcCrud(SampleTypeThinhLCSoapServiceClient client)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- SampleTypeThinhLC CRUD ---");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Get by ID");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var all = await client.GetSampleTypeThinhLCsAsync();
                    foreach (var s in all)
                    {
                        Console.WriteLine($"ID: {s.SampleTypeThinhLcid}, TypeName: {s.TypeName}, Description: {s.Description}, IsActive: {s.IsActive}, Count: {s.Count}, CreatedAt: {s.CreatedAt}, UpdatedAt: {s.UpdatedAt}, DeletedAt: {s.DeletedAt}");
                    }
                    break;
                case "2":
                    Console.Write("Enter ID: ");
                    if (int.TryParse(Console.ReadLine(), out int gid))
                    {
                        var item = await client.GetSampleTypeThinhLCByIdAsync(gid);
                        if (item != null && item.SampleTypeThinhLcid != null)
                        {
                            Console.WriteLine($"ID: {item.SampleTypeThinhLcid}, TypeName: {item.TypeName}, Description: {item.Description}, IsActive: {item.IsActive}, Count: {item.Count}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}, DeletedAt: {item.DeletedAt}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "3":
                    var create = new SampleTypeThinhLcModel();
                    Console.Write("TypeName: "); create.TypeName = Console.ReadLine();
                    Console.Write("Description: "); create.Description = Console.ReadLine();
                    Console.Write("IsActive (true/false): "); var isActive = Console.ReadLine(); create.IsActive = bool.TryParse(isActive, out bool ia) ? ia : null;
                    Console.Write("Count: "); create.Count = int.TryParse(Console.ReadLine(), out int c) ? c : null;
                    create.CreatedAt = DateTime.Now;
                    create.UpdatedAt = DateTime.Now;
                    create.DeletedAt = null;
                    var cr = await client.CreateSampleTypeThinhLCAsync(create);
                    Console.WriteLine($"Created, result: {cr}");
                    break;
                case "4":
                    Console.Write("Enter ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int uid))
                    {
                        var up = await client.GetSampleTypeThinhLCByIdAsync(uid);
                        if (up != null && up.SampleTypeThinhLcid != null)
                        {
                            string typeNameStr, descStr, isActiveStr, cntStr;
                            Console.Write($"TypeName ({up.TypeName}): "); typeNameStr = Console.ReadLine(); if (!string.IsNullOrEmpty(typeNameStr)) up.TypeName = typeNameStr;
                            Console.Write($"Description ({up.Description}): "); descStr = Console.ReadLine(); if (!string.IsNullOrEmpty(descStr)) up.Description = descStr;
                            Console.Write($"IsActive ({up.IsActive}): "); isActiveStr = Console.ReadLine(); if (bool.TryParse(isActiveStr, out bool iaVal)) up.IsActive = iaVal; else if (!string.IsNullOrWhiteSpace(isActiveStr) && isActiveStr != up.IsActive?.ToString()) up.IsActive = null;
                            Console.Write($"Count ({up.Count}): "); cntStr = Console.ReadLine(); if (int.TryParse(cntStr, out int cntVal)) up.Count = cntVal; else if (!string.IsNullOrWhiteSpace(cntStr) && cntStr != up.Count?.ToString()) up.Count = null;
                            up.UpdatedAt = DateTime.Now;
                            var ur = await client.UpdateSampleTypeThinhLCAsync(up);
                            Console.WriteLine($"Updated, result: {ur}");
                        }
                        else Console.WriteLine("Not found.");
                    }
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int did))
                    {
                        var dr = await client.DeleteSampleTypeThinhLCAsync(did);
                        Console.WriteLine($"Deleted, result: {dr}");
                    }
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
