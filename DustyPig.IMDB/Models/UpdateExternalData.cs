namespace DustyPig.IMDB.Models;


public class UpdateExternalData : ExternalData
{
    public required string TitleType { get; set; }
    
    public bool HasEpisodes { get; set; }
}
