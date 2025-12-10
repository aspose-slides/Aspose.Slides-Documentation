---
title: 评论
type: docs
weight: 230
url: /zh/net/examples/elements/comment/
keywords:
- 评论示例
- 现代评论
- 添加评论
- 访问评论
- 删除评论
- 回复评论
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中管理幻灯片评论：添加、读取、回复、编辑、删除，并在 PowerPoint 和 OpenDocument 中使用线程式评论。"
---

演示如何使用 **Aspose.Slides for .NET** 添加、读取、删除和回复现代评论。

## **添加现代评论**

创建由用户撰写的评论并保存演示文稿。
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


## **访问现代评论**

从现有演示文稿中读取现代评论。
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## **删除现代评论**

删除评论并保存更新后的文件。
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


## **回复现代评论**

向父级现代评论添加回复。
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
