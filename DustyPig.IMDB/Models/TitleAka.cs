namespace DustyPig.IMDB.Models;

public class TitleAka
{
    public required string TConst { get; set; }

    public int Ordering { get; set; }

    public required string Title { get; set; }

    public string? Region { get; set; }

    public string? Language { get; set; }

    public List<string>? Types { get; set; }

    public List<string>? Attributes { get; set; }

    public bool IsOriginalTitle { get; set; }
}