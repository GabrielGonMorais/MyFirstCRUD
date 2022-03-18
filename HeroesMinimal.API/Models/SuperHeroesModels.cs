public class SuperHero
{
    public int ID { get; set; }
    public string Nick { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public string Info { get; set; } = string.Empty;

    public Comic Comic { get; set; }

    public int? ComicID { get; set; }
}
