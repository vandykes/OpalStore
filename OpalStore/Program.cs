using OpalStore.Commands;
using OpalStore.DataContexts;
using OpalStore.Queries;
using System;

namespace OpalStore
{
    /// <summary>
    /// The main entry point for a console application that can store and retrieve key/value pairs.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Type a command to get started.");
            var inMemoryContext = new InMemoryContext(); // Dependency Injection would be nice.

            CommandBase command = null;

            var input = Console.ReadLine();
            command = Resolver.Parse(input);

            while (true)
            {
                if (command == null)
                    Console.WriteLine("Unrecognized command...");
                else if (!string.IsNullOrWhiteSpace(command.OutputMessage))
                    Console.WriteLine(command.OutputMessage);
                else if (command is IQuery)
                    Console.WriteLine(((IQuery)command).ExecuteQuery(inMemoryContext));
                else if (command is ICommand)
                {
                    ((ICommand)command).ExecuteCommand(inMemoryContext);
                    if (!string.IsNullOrWhiteSpace(command.OutputMessage))
                        Console.WriteLine(command.OutputMessage);
                }

                Console.Write($"{Environment.NewLine}> ");
                input = Console.ReadLine();
                command = Resolver.Parse(input);
            }
        }
    }
}
