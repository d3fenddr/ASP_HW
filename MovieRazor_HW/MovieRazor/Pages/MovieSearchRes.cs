namespace MovieRazor.Pages;

public class MovieSearchRes
{
    public bool Adult { get; set; }
    
    public string BackdropPath { get; set; }
    public int[] GenreIds { get; set; }
    
    public int Id { get; set; }
    
    public string OriginalLanguage { get; set; }
    
    public string OriginalTitle { get; set; }
    
    public string Overview { get; set; }
    
    public double Popularity { get; set; }
    public string PosterPath { get; set; }
    
    public string ReleaseDate { get; set; }
    public string Title { get; set; }
    
    public bool Video { get; set; }
    
    public double VoteAverage { get; set; }
    
    public int VoteCount { get; set; }
}