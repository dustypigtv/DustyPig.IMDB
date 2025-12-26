namespace DustyPig.IMDB.Models;

public class TitleSearchResult
{
    public required TitleBasic Basic { get; set; }

    public TitleRating? Rating { get; set; }

    public float Rank { get; set; }
}
