---
title: Bình luận
type: docs
weight: 230
url: /vi/net/examples/elements/comment/
keywords:
- bình luận
- bình luận hiện đại
- thêm bình luận
- truy cập bình luận
- xóa bình luận
- trả lời bình luận
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Làm việc với bình luận trên slide trong Aspose.Slides cho .NET: thêm, trả lời, chỉnh sửa, giải quyết và xuất bình luận trong các bản trình chiếu PPT, PPTX và ODP với các ví dụ mã C#."
---
Bài viết này trình bày cách thêm, đọc, xóa và trả lời các bình luận hiện đại bằng **Aspose.Slides for .NET**.

## **Thêm bình luận hiện đại**

Tạo một bình luận do người dùng viết và lưu bản trình chiếu.

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

## **Truy cập bình luận hiện đại**

Đọc một bình luận hiện đại từ bản trình chiếu hiện có.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Xóa bình luận hiện đại**

Xóa một bình luận và lưu tệp đã cập nhật.

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

## **Trả lời bình luận hiện đại**

Thêm phản hồi vào một bình luận hiện đại cha.

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