namespace DustyPig.IMDB.Models;

public class TitleRating
{
    public required string TConst { get; set; }

    public float AverageWeighting { get; set; }

    public int NumVotes { get; set; }
}