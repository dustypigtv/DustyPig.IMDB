namespace DustyPig.IMDB.Models;

public class TitleEpisode
{
    public required string TConst { get; set; }

    public required string ParentTConst { get; set; }

    public int? SeasonNumber { get; set; }

    public int? EpisodeNumber { get; set; }
}