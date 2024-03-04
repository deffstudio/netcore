// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, C#!");
Console.WriteLine(5/10);
string name = typeof(Program).Namespace ?? "None!";
Console.WriteLine($"Namespace: {name}");
throw new Exception();
