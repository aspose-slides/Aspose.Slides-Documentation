---
title: टिप्पणी
type: docs
weight: 230
url: /hi/net/examples/elements/comment/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी हटाएँ
- टिप्पणी का उत्तर दें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड टिप्पणियों के साथ काम करें: C# कोड उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों में टिप्पणियां जोड़ें, उत्तर दें, संपादित करें, हल करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for .NET** का उपयोग करके आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उनका उत्तर देने का प्रदर्शन करता है।

## **एक आधुनिक टिप्पणी जोड़ें**

उपयोगकर्ता द्वारा लिखी गई टिप्पणी बनाएं और प्रस्तुति को सहेजें।

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

## **एक आधुनिक टिप्पणी तक पहुँचें**

मौजूदा प्रस्तुति से एक आधुनिक टिप्पणी पढ़ें।

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **एक आधुनिक टिप्पणी हटाएँ**

टिप्पणी को हटाएँ और अद्यतन फ़ाइल को सहेजें।

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

## **एक आधुनिक टिप्पणी का उत्तर दें**

पैरेंट आधुनिक टिप्पणी के उत्तर जोड़ें।

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