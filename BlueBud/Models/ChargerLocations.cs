

using BlueBud.Data;

namespace BlueBud.Models;

public class ChargerLocations
{
    public int Id { get; set; }
    

    public string ChargerName { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
    
    public int OccupationStatus { get; set; }
    
    public string ChargerType { get; set; }
    
    
    public List<ApplicationDbContext.BlueBudUser> BlueBudUsers { get; set; }

}