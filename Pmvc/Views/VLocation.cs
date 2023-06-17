using Pmvc.Models;

namespace Pmvc.Views;
public class VLocation
{
    public void GetAll(List<MLocation> locations)
    {
        foreach (MLocation loc in locations)
        {
            Console.WriteLine("ID: " + loc.id + ", Street Address: " + loc.streetAddress + ", Postal Code: " + loc.postalCode + ", City: " + loc.city + ", State Province: " + loc.stateProvince + ", Country ID: " + loc.countryId);
        }
    }
}
