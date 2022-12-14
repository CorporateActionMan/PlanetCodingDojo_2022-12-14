using System.Collections.Concurrent;

namespace UserInterface;

internal class Sleigh
{
    public Sleigh()
    {
        this.Presents = new ConcurrentBag<Present>();
    }

    public ConcurrentBag<Present> Presents { get;  }

    public void Pack(Present present)
    {
        Presents.Add(present);
    }
}