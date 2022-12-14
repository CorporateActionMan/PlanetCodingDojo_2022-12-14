// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using UserInterface;

public class Program
{
    private static int numberOfElves = 5; 

    public static async Task Main(String[] args)
    {
        Console.WriteLine("Welcome to Santa's Delivery Pipeline!");

        ToyMachine machine = new ToyMachine();
        Sleigh sleigh = new Sleigh();
        MrsClaus mrsClaus = new MrsClaus();

        ConcurrentQueue<Present> toyStore = new ConcurrentQueue<Present>();
        Parallel.For(0, 50, index =>
        {
            var present = machine.Generate();

            toyStore.Enqueue(present);
        });

        // generate some random Elves

        for (int i = 0; i < numberOfElves; i++)
        {
            mrsClaus.Elves.Add(new Elf(sleigh));
        }

        

        Parallel.For(0, toyStore.Count, (presentIndex) =>
        {
            var didDequeue = toyStore.TryDequeue(out Present? present);
            if (present != null)
            {
                var task = mrsClaus.AllocatePackingTask(present);
                task.Start();
            }
        });

        Console.WriteLine($"Number of tasks { mrsClaus.PackingTasks.Count }");

        var results = await Task.WhenAll(mrsClaus.PackingTasks);

        Console.WriteLine($"Done! Toystore Count: { toyStore.Count } Sleigh Count: { sleigh.Presents.Count }");

        Console.ReadLine();
    }
}


