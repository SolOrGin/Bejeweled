using System;

// In C#, enums are usually defined directly rather than inside a struct
public enum GemType
{
    Empty,
    Red,
    Blue,
    Green,
    Yellow
}

public class Gem
{
    // C# uses Properties for attributes (get/set) 
    // This replaces the private 'type' variable and getType/setType methods
    public GemType Type { get; set; }

    // Constructor: Default to Empty
    public Gem()
    {
        Type = GemType.Empty;
    }

    // Logic for comparing types
    public bool IsSameType(Gem other)
    {
        if (other == null) return false;
        return this.Type == other.Type;
    }

    // Check if empty
    public bool IsGemEmpty()
    {
        return this.Type == GemType.Empty;
    }

    // C# uses "override ToString()" to convert objects to strings
    public override string ToString()
    {
        // C# enums automatically convert their name to a string! 
        // No switch statement required.
        return Type.ToString();
    }
}