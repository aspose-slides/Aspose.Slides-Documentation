---
title: Yorum
type: docs
weight: 230
url: /tr/net/examples/elements/comment/
keywords:
- yorum
- modern yorum
- yorum ekle
- yoruma erişim
- yorumu kaldır
- yoruma yanıtla
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt yorumları üzerinde çalışın: PPT, PPTX ve ODP sunumlarında yorum ekleme, yanıtlama, düzenleme, çözümleme ve dışa aktarma, C# kod örnekleriyle."
---
Bu makale, **Aspose.Slides for .NET** kullanarak modern yorum ekleme, okuma, kaldırma ve yanıtlama işlemlerini gösterir.

## **Modern Yorum Ekle**

Kullanıcı tarafından yazılmış bir yorum oluşturun ve sunumu kaydedin.

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

## **Modern Yorum Erişimi**

Mevcut bir sunumdan modern bir yorumu okuyun.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Modern Yorumu Kaldır**

Yorumu kaldırın ve güncellenmiş dosyayı kaydedin.

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

## **Modern Yoruma Yanıtla**

Ana modern yoruma cevaplar ekleyin.

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