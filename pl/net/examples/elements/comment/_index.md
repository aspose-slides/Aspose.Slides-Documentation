---
title: Komentarz
type: docs
weight: 230
url: /pl/net/examples/elements/comment/
keywords:
- komentarz
- nowoczesny komentarz
- dodaj komentarz
- uzyskaj dostęp do komentarza
- usuń komentarz
- odpowiedz na komentarz
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Pracuj z komentarzami slajdów w Aspose.Slides dla .NET: dodawaj, odpowiadaj, edytuj, rozwiązuj i eksportuj komentarze w prezentacjach PPT, PPTX i ODP przy użyciu przykładów kodu C#."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie oraz odpowiadanie na nowoczesne komentarze przy użyciu **Aspose.Slides for .NET**.

## **Dodaj nowoczesny komentarz**

Utwórz komentarz napisany przez użytkownika i zapisz prezentację.

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

## **Uzyskaj dostęp do nowoczesnego komentarza**

Odczytaj nowoczesny komentarz z istniejącej prezentacji.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Usuń nowoczesny komentarz**

Usuń komentarz i zapisz zaktualizowany plik.

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

## **Odpowiedz na nowoczesny komentarz**

Dodaj odpowiedzi do nadrzędnego nowoczesnego komentarza.

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