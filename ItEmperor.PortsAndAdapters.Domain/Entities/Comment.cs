using System;

public class Comment : IEntity
{
    public Guid Id { get; }

    public CommentContent Content { get; private set; }

    public DateTime CreationDate { get; private set; }

    public Author Author { get; private set; }

    protected Comment() { }

    public Comment(CommentContent content, Author author, IDateTimeProvider dateTimeProvider)
    {
        if (dateTimeProvider == null) throw new ArgumentNullException(nameof(dateTimeProvider));
        Id = Guid.NewGuid();
        Content = content ?? throw new ArgumentNullException(nameof(content));
        CreationDate = dateTimeProvider.GetCurrent();
        Author = author ?? throw new ArgumentNullException(nameof(author));
    }
}