namespace DustyPig.IMDB.Models;

public class TitlePrincipal
{
    public required string TConst { get; set; }

    public int Ordering { get; set; }

    public required string NConst { get; set; }

    public required string Category { get; set; }

    public string? Job { get; set; }

    public string? Character { get; set; }
}