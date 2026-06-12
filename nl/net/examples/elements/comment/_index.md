---
title: Opmerking
type: docs
weight: 230
url: /nl/net/examples/elements/comment/
keywords:
- opmerking
- moderne opmerking
- opmerking toevoegen
- opmerking lezen
- opmerking verwijderen
- reageren op opmerking
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Werk met dia‑opmerkingen in Aspose.Slides for .NET: voeg toe, reageer, bewerk, los op en exporteer opmerkingen in PPT-, PPTX- en ODP‑presentaties met C#‑codevoorbeelden."
---
Dit artikel demonstreert het toevoegen, lezen, verwijderen en beantwoorden van moderne opmerkingen met **Aspose.Slides for .NET**.

## **Een moderne opmerking toevoegen**

Maak een opmerking aan die door een gebruiker is gemaakt en sla de presentatie op.

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

## **Toegang tot een moderne opmerking**

Lees een moderne opmerking uit een bestaande presentatie.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Een moderne opmerking verwijderen**

Verwijder een opmerking en sla het bijgewerkte bestand op.

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

## **Op een moderne opmerking reageren**

Voeg antwoorden toe aan een bovenliggende moderne opmerking.

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