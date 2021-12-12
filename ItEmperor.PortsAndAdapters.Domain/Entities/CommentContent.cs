public record CommentContent
{
    public string Value { get; }

    public CommentContent()
    {
    }

    public CommentContent(string value)
    {
        Value = value;
    }
}