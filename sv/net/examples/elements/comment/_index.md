---
title: Kommentar
type: docs
weight: 230
url: /sv/net/examples/elements/comment/
keywords:
- kommentar
- modern kommentar
- lägg till kommentar
- åtkomst till kommentar
- ta bort kommentar
- svara på kommentar
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Arbeta med bildkommentarer i Aspose.Slides för .NET: lägg till, svara, redigera, lösa och exportera kommentarer i PPT-, PPTX- och ODP-presentationer med C#-kodexempel."
---
Den här artikeln demonstrerar hur man lägger till, läser, tar bort och svarar på moderna kommentarer med **Aspose.Slides for .NET**.

## **Lägg till en modern kommentar**

Skapa en kommentar skriven av en användare och spara presentationen.

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **Åtkomst till en modern kommentar**

Läs en modern kommentar från en befintlig presentation.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Ta bort en modern kommentar**

Ta bort en kommentar och spara den uppdaterade filen.

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **Svara på en modern kommentar**

Lägg till svar på en föräldrakommentar.

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```