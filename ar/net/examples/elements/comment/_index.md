---
title: تعليق
type: docs
weight: 230
url: /ar/net/examples/elements/comment/
keywords:
- تعليق
- تعليق حديث
- إضافة تعليق
- الوصول إلى التعليق
- إزالة تعليق
- الرد على التعليق
- مثال على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع تعليقات الشرائح في Aspose.Slides for .NET: إضافة، رد، تعديل، حل، وتصدير التعليقات في عروض PPT و PPTX و ODP باستخدام أمثلة كود C#."
---
يوضح هذا المقال كيفية إضافة وقراءة وإزالة والرد على التعليقات الحديثة باستخدام **Aspose.Slides for .NET**.

## **إضافة تعليق حديث**

أنشئ تعليقًا كتبه مستخدم واحفظ العرض التقديمي.

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

## **الوصول إلى تعليق حديث**

اقرأ تعليقًا حديثًا من عرض تقديمي موجود.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **إزالة تعليق حديث**

احذف تعليقًا واحفظ الملف المحدث.

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

## **الرد على تعليق حديث**

أضف ردودًا على التعليق الحديث الأصلي.

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