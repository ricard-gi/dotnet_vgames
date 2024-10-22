public class VideoGame
{
    public int Rank { get; set; }
    public string? Name { get; set; }
    public string? Platform { get; set; }
    public int Year { get; set; }
    public string? Genre { get; set; }
    public string? Publisher { get; set; }
    public double NASales { get; set; }
    public double EUSales { get; set; }
    public double JPSales { get; set; }
    public double OtherSales { get; set; }
    public double GlobalSales { get; set; }

    public override string ToString()
    {
        return $"{Rank}: {Name} ({Platform}) - {Genre} - {GlobalSales}M Global";
    }
}
