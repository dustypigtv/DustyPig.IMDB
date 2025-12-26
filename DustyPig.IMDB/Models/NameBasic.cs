namespace DustyPig.IMDB.Models;


public class NameBasic
{
    public required string NConst { get; set; }

    public required string PrimaryName { get; set; }

    public int? BirthYear { get; set; }

    public int? DeathYear { get; set; }

    public List<string>? PrimaryProfessions { get; set; }

    public List<string>? KnownForTitles { get; set; }
}