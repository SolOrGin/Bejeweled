public class Match
{
    private List<Coordinates> _coords;
    private GemType _type;

    public Match(List<Coordinate> coords, GemType type)
    {
        _coords = coords;
        _type = type;
    }

    public int GetPoints()
    {
        int count = _coords.Count;
        if (count == 3) return 100;
        if (count == 4) return 150;
        if (count >= 5) return 200;
        return 0;
    }

    public int GetCount() => _coords.Count;
    public List<Coordinate> GetCoords() => _coords;
    public GemType GetGemType() => _type;


}