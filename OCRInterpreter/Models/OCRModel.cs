namespace OCRInterpreter.Models;

public class OCRModel
{
    public string Locale { get; set; }
    public string Description { get; set;}
    public BoundingPoly BoundingPoly { get; set;}
}

public class BoundingPoly
{
    public List<Coordinates> Vertices { get; set;}
}

public class Coordinates
{
    public int X { get;set; }
    public int Y { get; set;}
}