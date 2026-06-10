---
title: Megjegyzés
type: docs
weight: 230
url: /hu/net/examples/elements/comment/
keywords:
- megjegyzés
- modern megjegyzés
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés eltávolítása
- megjegyzésre válasz
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "A slide-megjegyzésekkel való munkavégzés az Aspose.Slides for .NET-ben: megjegyzések hozzáadása, válaszolás, szerkesztés, megoldás és exportálás PPT, PPTX és ODP prezentációkban C# kódpéldákkal."
---
Ez a cikk bemutatja a modern megjegyzések hozzáadását, olvasását, eltávolítását és válaszadást a **Aspose.Slides for .NET** használatával.

## **Modern megjegyzés hozzáadása**

Hozzon létre egy felhasználó által írt megjegyzést, és mentse el a prezentációt.

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

## **Modern megjegyzés elérése**

Olvassa be a modern megjegyzést egy meglévő prezentációból.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Modern megjegyzés eltávolítása**

Távolítson el egy megjegyzést, és mentse a frissített fájlt.

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

## **Modern megjegyzésre válasz**

Adjon válaszokat egy szülő modern megjegyzéshez.

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