---
title: Kommentar
type: docs
weight: 230
url: /de/net/examples/elements/comment/
keywords:
- Kommentarbeispiel
- moderner Kommentar
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar entfernen
- Auf Kommentar antworten
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Folienkommentare in C# mit Aspose.Slides: Hinzufügen, Lesen, Antworten, Bearbeiten, Löschen und Arbeiten mit verschachtelten Kommentaren für PowerPoint und OpenDocument."
---

Demonstriert das Hinzufügen, Lesen, Entfernen und Antworten auf moderne Kommentare mit **Aspose.Slides for .NET**.

## Modernen Kommentar hinzufügen

Erstellen Sie einen von einem Benutzer verfassten Kommentar und speichern Sie die Präsentation.
```csharp
static void Add_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var author = pres.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    pres.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```


## Auf einen modernen Kommentar zugreifen

Lesen Sie einen modernen Kommentar aus einer vorhandenen Präsentation.
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## Modernen Kommentar entfernen

Entfernen Sie einen Kommentar und speichern Sie die aktualisierte Datei.
```csharp
static void Remove_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    pres.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```


## Auf einen modernen Kommentar antworten

Fügen Sie Antworten zu einem übergeordneten modernen Kommentar hinzu.
```csharp
static void Reply_To_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var author = pres.CommentAuthors.AddAuthor("User", "U1");

    var parent = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parent;
    reply2.ParentComment = parent;

    pres.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```
