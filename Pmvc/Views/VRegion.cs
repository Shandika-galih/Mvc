using Pmvc.Models;

namespace Pmvc.Views;

public class VRegion
{
    public void GetById(MRegion region)
    {
        Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
    }
    public void GetAll(List<MRegion> regions)
    {
        foreach (MRegion region in regions)
        {
            GetById(region);
        }
    }
    public void NotFound()
    {
        Console.WriteLine("Data not found");
    }
}
