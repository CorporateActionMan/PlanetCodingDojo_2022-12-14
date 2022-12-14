namespace UserInterface
{

    internal class Elf
    {
        private readonly Sleigh _sleigh;
        private readonly String _name; // an elf should have a name
        private bool _allocated;
        private Queue<Present> _work;



        public Elf(Sleigh sleigh)
        {
            _work = new Queue<Present>();
            _allocated = false;
            _sleigh = sleigh;
            _name = getElfName();
            Console.WriteLine("Elf created: " + _name);
        }


        public string ReceivePresent(Present present)
        {
            _allocated = true;
            var rnd = new Random();
            var sleepMilliseconds = rnd.Next(3000, 20000);
            Thread.Sleep(sleepMilliseconds);
            _sleigh.Pack(present);
            _allocated = false;
            return $"{_name} has packed: {present.Name}";
        }



        private String getElfName()
        {
            var rnd = new Random();
            var nameIndex = rnd.Next(0, ElfNames.Count - 1);
            return ElfNames[nameIndex];
        }



        private static List<string> ElfNames = new List<string>()
        {
            "Bing",
            "Hoppity",
            "Zippity",
            "Arwen",
            "Elrond",
            "Legolas",
            "Dobby",
            "Pop",
            "Snap",
            "Crackle",
            "Merry",
            "Winky",
            "Snowflake",
            "Noel",
            "Hope",
            "Snowy",
            "Tom",
            "Jerry"
        };

        public bool Allocated => _allocated;
    }
}