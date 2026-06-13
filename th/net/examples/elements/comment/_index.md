---
title: ความคิดเห็น
type: docs
weight: 230
url: /th/net/examples/elements/comment/
keywords:
- ความคิดเห็น
- ความคิดเห็นสมัยใหม่
- เพิ่มความคิดเห็น
- เข้าถึงความคิดเห็น
- ลบความคิดเห็น
- ตอบกลับความคิดเห็น
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับความคิดเห็นสไลด์ใน Aspose.Slides for .NET: เพิ่ม, ตอบกลับ, แก้ไข, แก้ปัญหา, และส่งออกความคิดเห็นในงานนำเสนอ PPT, PPTX, และ ODP ด้วยตัวอย่างโค้ด C#."
---
บทความนี้สาธิตการเพิ่ม, การอ่าน, การลบ, และการตอบกลับความคิดเห็นสมัยใหม่โดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มความคิดเห็นสมัยใหม่**

สร้างความคิดเห็นโดยผู้ใช้และบันทึกงานนำเสนอ

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

## **เข้าถึงความคิดเห็นสมัยใหม่**

อ่านความคิดเห็นสมัยใหม่จากงานนำเสนอที่มีอยู่

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **ลบความคิดเห็นสมัยใหม่**

ลบความคิดเห็นและบันทึกไฟล์ที่อัปเดต

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

## **ตอบกลับความคิดเห็นสมัยใหม่**

เพิ่มการตอบกลับให้กับความคิดเห็นสมัยใหม่ที่เป็นพาเรนต์

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