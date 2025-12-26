namespace DustyPig.IMDB.Models;

public class TitleBasic
{
    public required string TConst { get; set; }

    public required string TitleType { get; set; }

    public required string PrimaryTitle { get; set; }

    public required string OriginalTitle { get; set; }

    public bool IsAdult { get; set; }

    public ushort? StartYear { get; set; }

    public ushort? EndYear { get; set; }

    public uint? RuntimeMinutes { get; set; }

    public List<string>? Genres { get; set; }
}