using System;
using System.IO;

string filePath = "C:\\Users\\LEGION\\Downloads\\sampl (1) (1) (1).txt";
var lines = File.ReadLines(filePath).Skip(1);


// solution 1
{
    int count = 0;
    long sum = 0;
    int duplicate = 0;
    var set = new HashSet<(string accountNumber, string amount)>();
    foreach (string line in lines)
    {
        string[] columns = line.Split('\t'); // ','
        if (columns is [var accountNumber, var amount, var ssn, ..])
        {
            count++;
            sum += long.Parse(amount);
            if (!set.Add((accountNumber, amount)))
            {
                // found duplicate
                Console.WriteLine($"duplicate: " + line);
                duplicate++;
            }
        }
    }

    Console.WriteLine($"count: {count}");
    Console.WriteLine($"sum: {sum}");
    Console.WriteLine($"duplicates: {duplicate}");
}


// solution 2
{
    var q = from line in lines
        let split = line.Split('\t')
        group line by (split[0], split[1]);
    List<string> q2 = q.Where(x=>x.Count() > 1).SelectMany(x=>x).ToList();
    
    Console.WriteLine($"duplicates (groupby): {q2.Count()}");
}
