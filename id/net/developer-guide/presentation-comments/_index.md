---
title: Kelola Komentar Presentasi di .NET
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/net/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- menambahkan komentar
- mengakses komentar
- mengedit komentar
- membalas komentar
- menghapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk .NET: tambahkan, baca, edit, balas, dan hapus komentar dalam presentasi PowerPoint dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk .NET. Artikel ini memperkenalkan tipe utama yang terkait dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih komentar menampilkan teksnya dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides untuk .NET menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang menyediakan akses ke penulis komentar presentasi.
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icommentcollection) yang mewakili komentar yang terkait dengan seorang penulis tertentu.
* Antarmuka [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment) yang menyediakan informasi tentang sebuah komentar, termasuk penulis, waktu pembuatan, posisi, dan teksnya.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/net/aspose.slides/commentauthor) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**
Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Mengakses Komentar Slide**
Contoh berikut menunjukkan cara mengakses komentar yang ada dalam presentasi PowerPoint:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Membalas Komentar**
Komentar induk adalah komentar asli di puncak hierarki balasan. Properti [ParentComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/properties/parentcomment) dari antarmuka [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment) memungkinkan Anda mendapatkan atau mengatur komentar induk.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Perhatian" %}} 

* Ketika metode [Remove](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/methods/remove) dari antarmuka [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika properti [ParentComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/properties/parentcomment) menciptakan referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception) akan dilemparkan.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/id/net/aspose.slides/icommentcollection/addmoderncomment/) menerima argumen [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) selain slide dan koordinat penanda komentar.

Ketika `null` diberikan untuk argumen shape, komentar tersebut adalah komentar tingkat slide. Penanda ditempatkan berdasarkan koordinat yang diberikan, tetapi tidak terkait dengan shape tertentu, sehingga [IModernComment.Shape](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/shape/) mengembalikan `null`. Ketika sebuah [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) disediakan, komentar tersebut diancahkan pada shape itu. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [IModernComment.Shape](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/shape/).

### **Menambatkan Komentar Modern pada Bentuk**

Contoh berikut membuat komentar modern tingkat slide dan komentar modern yang diancahkan pada AutoShape tertentu. Kemudian contoh tersebut membaca shape yang terkait dari masing‑masing komentar.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Menambatkan Komentar ke Berbagai Jenis Bentuk**

Setiap objek slide yang mengimplementasikan [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) dapat digunakan sebagai anchor shape. Contoh umum termasuk [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/id/net/aspose.slides/iconnector/), dan instance [IGraphicalObject](https://reference.aspose.com/slides/id/net/aspose.slides/igraphicalobject/) seperti diagram.

Contoh berikut membuat beberapa tipe shape umum dan mengaitkan komentar modern dengan masing‑masing.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Menambatkan Komentar pada Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/textselectionstart/) menentukan posisi awal teks yang dipilih dalam bingkai teks shape, sedangkan [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/textselectionlength/) menentukan panjang pilihan. Kedua properti ini bersama‑sama mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Properti [IModernComment.Status](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/status/) dapat dibaca atau diperbarui dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/id/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern yang spesifik didefinisikan.
- `Active` — komentar aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh berikut membuat komentar modern yang diancahkan pada shape, mengaitkannya dengan pilihan teks, menandainya sebagai terselesaikan, menyimpan presentasi, dan memverifikasi nilai setelah file dibuka kembali.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Menyelidiki Komentar Modern yang Ada**

Untuk memeriksa presentasi yang ada, periksa komentar mana yang mengimplementasikan [IModernComment](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/), kemudian tinjau [IModernComment.Shape](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/textselectionlength/), dan [IModernComment.Status](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/status/). Sebuah shape `null` menunjukkan komentar tingkat slide. Untuk anchor [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/), properti pilihan teks mengidentifikasi rentang yang terkait dalam bingkai teks shape.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Menghapus Komentar Tertentu**

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Tanya Jawab**

**Apakah Aspose.Slides mendukung status terselesaikan untuk komentar modern?**

Ya. [IModernComment.Status](https://reference.aspose.com/slides/id/net/aspose.slides/imoderncomment/status/) dapat dibaca dan diatur dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/id/net/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [komentar induk](https://reference.aspose.com/slides/id/net/aspose.slides/comment/parentcomment/), memungkinkan rantai balasan. API tidak menentukan batas kedalaman tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya dengan tepat pada slide.