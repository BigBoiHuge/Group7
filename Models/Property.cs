namespace HappyCitizens.Models;

public class Property
{
    public int Id { get; set; }
    public string? Owner { get; set; }
    public string? MailingAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public int YearBuilt { get; set; }
}
