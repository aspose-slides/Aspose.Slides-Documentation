---
title: Σχόλιο
type: docs
weight: 230
url: /el/net/examples/elements/comment/
keywords:
- σχόλιο
- σύγχρονο σχόλιο
- προσθήκη σχολίου
- πρόσβαση σε σχόλιο
- αφαίρεση σχολίου
- απάντηση σε σχόλιο
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εργαστείτε με σχόλια διαφανειών στο Aspose.Slides for .NET: προσθήκη, απάντηση, επεξεργασία, επίλυση και εξαγωγή σχολίων σε παρουσιάσεις PPT, PPTX και ODP με παραδείγματα κώδικα C#."
---
Αυτό το άρθρο δείχνει την προσθήκη, ανάγνωση, διαγραφή και απάντηση σε σύγχρονα σχόλια χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη σύγχρονου σχολίου**

Δημιουργήστε ένα σχόλιο που έχει συνταχθεί από χρήστη και αποθηκεύστε την παρουσίαση.

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

## **Πρόσβαση σε σύγχρονο σχόλιο**

Διαβάστε ένα σύγχρονο σχόλιο από μια υπάρχουσα παρουσίαση.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Αφαίρεση σύγχρονου σχολίου**

Αφαιρέστε ένα σχόλιο και αποθηκεύστε το ενημερωμένο αρχείο.

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

## **Απάντηση σε σύγχρονο σχόλιο**

Προσθέστε απαντήσεις σε ένα γονικό σύγχρονο σχόλιο.

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