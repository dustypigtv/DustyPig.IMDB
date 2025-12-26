namespace DustyPig.IMDB.Models;

public class Title
{
    public required TitleBasic Basic { get; set; }

    public TitleRating? Rating { get; set; }

    public List<TitleAka>? Akas { get; set; }

    public TitleCrew? Crew { get; set; }

    public List<TitlePrincipal>? Principals { get; set; }

    public List<TitleEpisode>? Episodes { get; set; }

    public ExternalData? ExternalData { get; set; }
}
