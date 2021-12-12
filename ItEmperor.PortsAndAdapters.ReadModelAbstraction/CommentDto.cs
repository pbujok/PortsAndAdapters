using System;

public record CommentDto(Guid Id, string Content, DateTime CreationDate, string AuthorName);