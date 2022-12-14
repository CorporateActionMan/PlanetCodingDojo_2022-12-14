namespace UserInterface
{

    internal class Elf
    {
        private readonly Sleigh _sleigh;

        public Elf(Sleigh sleigh)
        {
            _sleigh = sleigh;
        }

        public string ReceivePresent(Present present)
        {
            var rnd = new Random();
            var sleepMilliseconds = rnd.Next(500, 3000);
            Thread.Sleep(sleepMilliseconds);
            _sleigh.Pack(present);
            return $"Packed: {present.Name}";
        }
    }
}