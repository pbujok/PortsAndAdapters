public record Author
{
    public string Name { get; }

    public Author()
    {
    }

    public Author(string name)
    {
        Name = name;
    }
}