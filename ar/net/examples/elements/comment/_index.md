---
title: تعليق
type: docs
weight: 230
url: /ar/net/examples/elements/comment/
keywords:
- مثال على التعليق
- تعليق حديث
- إضافة تعليق
- الوصول إلى تعليق
- إزالة تعليق
- الرد على التعليق
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة تعليقات الشرائح في C# باستخدام Aspose.Slides: إضافة، قراءة، رد، تحرير، حذف، والعمل مع التعليقات المتسلسلة لباوربوينت ومستند مفتوح."
---

يظهر إضافة وقراءة وإزالة والرد على التعليقات الحديثة باستخدام **Aspose.Slides for .NET**.

## إضافة تعليق حديث

إنشاء تعليق من مؤلفه مستخدم وحفظ العرض التقديمي.
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


## الوصول إلى تعليق حديث

قراءة تعليق حديث من عرض تقديمي موجود.
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## إزالة تعليق حديث

إزالة التعليق وحفظ الملف المحدث.
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


## الرد على تعليق حديث

إضافة ردود إلى تعليق حديث رئيسي.
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
