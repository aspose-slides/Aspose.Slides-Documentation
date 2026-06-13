---
title: نظر
type: docs
weight: 230
url: /fa/net/examples/elements/comment/
keywords:
- نظر
- نظر مدرن
- افزودن نظر
- دسترسی به نظر
- حذف نظر
- پاسخ به نظر
- مثال کد
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با نظرات اسلاید در Aspose.Slides برای .NET: افزودن، پاسخ، ویرایش، حل کردن و خروجی گرفتن نظرات در ارائه‌های PPT، PPTX و ODP با مثال‌های کد C#."
---
این مقاله نشان می‌دهد که چگونه نظرات مدرن را با استفاده از **Aspose.Slides for .NET** اضافه، خوانده، حذف و پاسخ دهی کنید.

## **اضافه کردن یک نظر مدرن**

یک نظر توسط کاربر ایجاد کنید و ارائه را ذخیره کنید.

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

## **دسترسی به یک نظر مدرن**

یک نظر مدرن را از یک ارائه موجود بخوانید.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **حذف یک نظر مدرن**

یک نظر را حذف کنید و فایل به‌روزشده را ذخیره کنید.

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

## **پاسخ به یک نظر مدرن**

پاسخ‌هایی به یک نظر مدرن والد اضافه کنید.

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