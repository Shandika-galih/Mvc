using Pmvc.Models;
namespace Pmvc.Views;

public class VCountry
{
    public void GetById(MCountry crnty)
    {
        Console.WriteLine("Id : " + crnty.Id + ", Name : " + crnty.Name + ", Id Region : " + crnty.regionId );
    }
    public void GetAll(List<MCountry> country)
    {
        foreach (MCountry crnty in country)
        {
            GetById(crnty);
        }
    }
    public void NotFound()
    {
        Console.WriteLine("Data not found");
    }
}
