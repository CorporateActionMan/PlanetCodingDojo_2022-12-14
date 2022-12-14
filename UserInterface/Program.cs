// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using UserInterface;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Welcome to Santa's Delivery Pipeline!");

        ToyMachine machine = new ToyMachine();
        Sleigh sleigh = new Sleigh();

        ConcurrentQueue<Present> toyStore = new ConcurrentQueue<Present>();
        Parallel.For(0, 10, index =>
        {
            var present = machine.Generate();

            toyStore.Enqueue(present);
        });

        Elf elf = new Elf(sleigh);

        Parallel.For(0, toyStore.Count, (presentIndex) =>
        {
            var didDequeue = toyStore.TryDequeue(out Present? present);
            if (present != null)
            {
                Console.WriteLine(elf.ReceivePresent(present));
            }
        });

        Console.WriteLine($"Done! Toystore Count: { toyStore.Count } Sleigh Count: { sleigh.Presents.Count }");

        Console.ReadLine();
    }
}


