namespace UserInterface
{
    internal class MrsClaus
    {

        public List<Elf> Elves { get; }

        public List<Task<string>> PackingTasks { get; }


        public MrsClaus()
        {
            Elves = new List<Elf>();
            PackingTasks = new List<Task<string>>();
        }

        public void AddElf(Elf elf)
        {
            Elves.Add(elf);
        }

        public Task<string> AllocatePackingTask(Present present)
        {
            Elf? firstAvailableElf = null;
            do
            {
                firstAvailableElf = Elves.FirstOrDefault(e => !e.Allocated);
            }while(firstAvailableElf == null);

            var task = new Task<string>(() =>
            {
                
                var result = firstAvailableElf.ReceivePresent(present);
                Console.WriteLine(result);
                return result;
            });
            PackingTasks.Add(task);
            return task;
        }

    }
}
