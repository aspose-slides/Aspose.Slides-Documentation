---
title: Komentar
type: docs
weight: 230
url: /id/net/examples/elements/comment/
keywords:
- komentar
- komentar modern
- menambahkan komentar
- akses komentar
- menghapus komentar
- membalas komentar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Bekerja dengan komentar slide di Aspose.Slides untuk .NET: menambahkan, membalas, mengedit, menyelesaikan, dan mengekspor komentar dalam presentasi PPT, PPTX, dan ODP dengan contoh kode C#."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan membalas komentar modern menggunakan **Aspose.Slides for .NET**.

## **Menambahkan Komentar Modern**

Buat komentar yang ditulis oleh pengguna dan simpan presentasi.

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

## **Mengakses Komentar Modern**

Baca komentar modern dari presentasi yang ada.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Menghapus Komentar Modern**

Hapus komentar dan simpan berkas yang diperbarui.

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

## **Membalas Komentar Modern**

Tambahkan balasan ke komentar modern induk.

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