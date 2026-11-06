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
- menambah komentar
- akses komentar
- sunting komentar
- balas komentar
- hapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk .NET: tambahkan, baca, sunting, balas, dan hapus komentar dalam presentasi PowerPoint secara cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides for .NET. Ini memperkenalkan tipe terkait komentar utama dan menunjukkan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih komentar menampilkan teksnya dan diskusi terkait.

Untuk meminta agar komentar ditampilkan atau disembunyikan saat presentasi dibuka tanpa mengubah komentar itu sendiri, lihat [Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi](/slides/id/net/presentation-view-properties/).

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan masukan dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides for .NET menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) yang menyediakan akses ke penulis komentar presentasi.
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) yang mewakili komentar yang terkait dengan seorang penulis.
* Antarmuka [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) yang menyediakan informasi tentang komentar, termasuk penulisnya, waktu pembuatan, posisi, dan teks.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh ini membuat dua slide dan mendaftarkan penulis komentar dengan [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Ia menggunakan [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) untuk menempatkan satu komentar pada setiap slide, lalu mengambil komentar slide pertama untuk penulis tersebut dengan [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Konsol menampilkan teks komentar pertama dua kali, menunjukkan akses melalui slide maupun penulis, dan presentasi yang disimpan berisi kedua komentar.

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

## **Temukan atau Buat Penulis Komentar**

Ketika tinjauan otomatis memproses presentasi yang sama berulang kali, cari koleksi [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) sebelum menambahkan penulis. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) mencocokkan nama dan inisial serta mengembalikan array penulis yang cocok, atau array kosong jika tidak ada yang cocok. Sebaliknya, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) mencari hanya berdasarkan nama, tanpa memperhatikan inisial. Memanggil [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) dengan nama dan inisial yang sudah ada dalam koleksi akan melempar pengecualian.

Contoh ini memerlukan file presentasi dengan setidaknya satu slide. Pada masing‑masing dari dua lintasan, ia kembali menggunakan penulis pertama yang cocok, atau membuat satu hanya ketika hasilnya kosong. Jika ada beberapa kecocokan, ia memilih elemen array pertama tanpa menggabungkan atau menghapus penulis lain. Kemudian ia memanggil [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) untuk penulis yang dipilih dan menyimpan presentasi. Lintasan kedua membuka output lintasan pertama dan mengulangi operasi.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

Lintasan kedua menambahkan komentar lain tanpa menambahkan penulis lain atau menghapus komentar yang ada. Berkas akhir, `review_pass_2.pptx`, berisi kedua komentar baru bersama komentar asli apa pun. Menggunakan kembali penulis tidak menduplikasi komentar: untuk menghindari penambahan komentar yang sama berulang kali, terapkan deteksi duplikat terpisah sebelum menambahkannya.

## **Mengakses Komentar Slide**

Contoh ini membuka presentasi yang ada dan membaca koleksi [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Untuk setiap penulis, ia mengiterasi [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) dan mencetak nomor slide, teks komentar, nama penulis, dan waktu pembuatan. Presentasi input harus berisi komentar agar menghasilkan output konsol.

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

Komentar induk adalah komentar asli di bagian atas hierarki balasan. Properti [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) dari antarmuka [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) memungkinkan Anda mendapatkan atau mengatur induk sebuah komentar.

Contoh ini membuat komentar dari dua penulis dan menggunakan [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) untuk membangun balasan, termasuk balasan ke balasan lain. Mem passing `null` ke [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) mengambil komentar dari semua penulis; konsol memberi indentasi tiap entri sesuai kedalamannya dalam hierarki balasan. Contoh menyimpan diskusi lengkap, memanggil [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) pada komentar akar pertama, dan menyimpan presentasi kedua dengan komentar tersebut dan balasannya dihapus.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Saat metode [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) dari antarmuka [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) digunakan untuk menghapus komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika properti [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) menerima argumen [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) selain slide dan koordinat penanda komentar.

Ketika `null` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, tetapi tidak terkait dengan bentuk tertentu, sehingga [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) mengembalikan `null`. Ketika sebuah [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) disediakan, komentar diikat ke bentuk tersebut. Koordinat masih mendefinisikan posisi penanda komentar pada slide, sementara asosiasi bentuk dapat diambil melalui [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Menambatkan Komentar Modern ke Bentuk**

Contoh ini memanggil [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) dua kali: sekali dengan shape `null` untuk komentar tingkat slide dan sekali dengan persegi panjang sebagai jangkar. Membaca [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) mencetak `True` untuk pemeriksaan null pada komentar tingkat slide dan `Revenue title` untuk komentar yang dijangkarkan. Kedua komentar disimpan bersama presentasi.

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

Setiap objek slide yang mengimplementasikan [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) dapat digunakan sebagai jangkar bentuk. Contoh umum meliputi [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), dan instansi [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) seperti bagan.

Contoh ini menggunakan [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) untuk mengaitkan komentar dengan masing‑masing lima jenis bentuk: sebuah AutoShape, bingkai gambar, grup, penyambung, dan bagan. Gambar menggunakan data gambar yang disematkan, jadi tidak memerlukan gambar eksternal. Setiap komentar memiliki posisi penanda masing‑masing, dan presentasi yang disimpan mempertahankan semua lima asosiasi bentuk.

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

### **Menambatkan Komentar ke Teks dan Mengatur Statusnya**

Untuk komentar modern yang terkait dengan sebuah [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) menentukan posisi awal teks yang dipilih dalam bingkai teks bentuk, sementara [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) menentukan panjang pemilihan. Bersama‑sama, properti ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Properti [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) dapat dibaca atau diperbarui dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern khusus yang didefinisikan.
- `Active` — komentar aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh ini menambatkan komentar modern ke kata “quarterly revenue” dalam teks sebuah persegi panjang. Ia menghitung [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) berbasis nol dari teks dan mengatur [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) ke jumlah karakter yang dipilih. Setelah mengatur [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) ke `Resolved`, ia menyimpan dan membuka kembali presentasi. Empat pemeriksaan konsol seharusnya masing‑masing mencetak `True`, mengonfirmasi bahwa jangkar bentuk, rentang teks, dan status tetap dipertahankan.

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

### **Memeriksa Komentar Modern yang Ada**

Contoh ini memerlukan presentasi yang ada berisi komentar modern dan mencetak teks, status, serta detail jangkarnya. Untuk memeriksanya, periksa komentar mana yang mengimplementasikan [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), lalu tinjau [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), dan [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Sebuah shape `null` menunjukkan komentar tingkat slide. Untuk jangkar [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), properti pilihan teks mengidentifikasi rentang terkait dalam bingkai teks bentuk.

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

Aspose.Slides for .NET memungkinkan Anda menghapus semua komentar dan penulisnya dari sebuah presentasi atau menghapus komentar tertentu sementara yang lain tetap ada. Contoh‑contoh berikut mendemonstrasikan kedua pendekatan dan menyimpan presentasi yang diperbarui.

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh ini membuka presentasi yang ada dan memanggil [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) untuk setiap penulis, lalu memanggil [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) untuk menghapus penulis itu sendiri. Presentasi yang disimpan tidak mengandung komentar maupun penulis komentar. Gunakan presentasi yang berisi komentar untuk melihat hasil penghapusan.

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

Contoh ini membuat dua komentar pada satu slide dan menggunakan [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) untuk menemukan komentar per penulis. Ia mengumpulkan komentar yang teksnya sama dengan “comment 1” sebelum memanggil [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), menghindari perubahan pada koleksi selama pemilihan. Presentasi yang disimpan hanya mempertahankan “comment 2”.

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

## **FAQ**

**Apakah Aspose.Slides mendukung status terselesaikan untuk komentar modern?**

Ya. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) dapat dibaca dan diatur dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berutas (rantai balasan) didukung, dan apakah ada batas penumpukan?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), memungkinkan rantai balasan. API tidak menetapkan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar pada slide didefinisikan?**

Posisi penanda didefinisikan oleh koordinat titik mengambang dalam sistem koordinat slide, memungkinkan penempatan yang tepat pada slide.