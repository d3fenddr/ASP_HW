namespace MovieRazor.Pages;

public class MovieSearchByTitle
{
    public int Page { get; set; }
    public MovieSearchRes[] Results { get; set; }
    public int TotalPages { get; set; }
    
    public int TotalResults { get; set; }
}