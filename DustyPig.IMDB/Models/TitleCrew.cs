namespace DustyPig.IMDB.Models;

public class TitleCrew
{
    public required string TConst { get; set; }

    public List<string>? Directors { get; set; }

    public List<string>? Writers { get; set; }

}