---
title: Komentář
type: docs
weight: 230
url: /cs/net/examples/elements/comment/
keywords:
- komentář
- moderní komentář
- přidat komentář
- přístup k komentáři
- odstranit komentář
- odpovědět na komentář
- ukázkový kód
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Pracujte s komentáři snímků v Aspose.Slides pro .NET: přidávejte, odpovídejte, upravujte, řešte a exportujte komentáře v prezentacích PPT, PPTX a ODP pomocí ukázek kódu v C#."
---
Tento článek demonstruje přidávání, čtení, odstraňování a odpovídání na moderní komentáře pomocí **Aspose.Slides for .NET**.

## **Add a Modern Comment**
Vytvořte komentář se jménem uživatele a uložte prezentaci.

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

## **Access a Modern Comment**
Přečtěte si moderní komentář z existující prezentace.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Remove a Modern Comment**
Odstraňte komentář a uložte aktualizovaný soubor.

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

## **Reply to a Modern Comment**
Přidejte odpovědi k nadřazenému modernímu komentáři.

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