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
description: "Kuasai komentar presentasi dengan Aspose.Slides untuk .NET: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint dengan cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi pada Aspose.Slides. Artikel ini menampilkan tipe utama yang berhubungan dengan komentar dan memperagakan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan, menggunakan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh‑contohnya berfokus pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca isi dan metadata komentar, membangun rantai balasan, serta membersihkan semua komentar atau menghapus komentar yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada slide. Ketika komentar diklik, isi atau pesannya ditampilkan.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda mungkin ingin menggunakan komentar untuk memberikan umpan balik atau berkomunikasi dengan rekan kerja saat meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides untuk .NET menyediakan

* Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang berisi koleksi penulis (dari properti [CommentAuthorCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icommentauthorcollection/properties/index)). Penulis menambahkan komentar ke slide. 
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/id/net/aspose.slides/icommentcollection) yang berisi koleksi komentar untuk masing‑masing penulis. 
* Kelas [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment) yang berisi informasi tentang penulis dan komentarnya: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll. 
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/net/aspose.slides/commentauthor) yang berisi informasi tentang masing‑masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll. 

## **Menambahkan Komentar Slide**
Kode C# berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```c#
// Membuat instance kelas Presentation
using (Presentation presentation = new Presentation())
{
    // Menambahkan slide kosong
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Menambahkan penulis
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Menetapkan posisi untuk komentar
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Menambahkan komentar slide untuk penulis pada slide 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Menambahkan komentar slide untuk penulis pada slide 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Mengakses ISlide 1
    ISlide slide = presentation.Slides[0];

    // Ketika null diberikan sebagai argumen, komentar dari semua penulis akan dibawa ke slide yang dipilih
    IComment[] Comments = slide.GetSlideComments(author);

    // Mengakses komentar pada indeks 0 untuk slide 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Memilih koleksi komentar Penulis pada indeks 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Mengakses Komentar Slide**
Kode C# berikut menunjukkan cara mengakses komentar yang sudah ada pada slide dalam presentasi PowerPoint:

```c#
// Membuat instance kelas Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Membalas Komentar**
Komentar induk adalah komentar utama atau asli dalam hierarki komentar atau balasan. Dengan menggunakan properti [ParentComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/properties/parentcomment) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment)), Anda dapat mengatur atau mengambil komentar induk.

Kode C# berikut menunjukkan cara menambahkan komentar dan mengambil balasannya:

```c#
using (Presentation pres = new Presentation())
{
    // Menambahkan komentar
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Menambahkan balasan ke comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Menambahkan balasan lain ke comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Menambahkan balasan ke balasan yang ada
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Menampilkan hierarki komentar di konsol
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Menghapus comment1 dan semua balasannya
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Perhatian" %}} 

* Saat metode [Remove](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/methods/remove) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment)) digunakan untuk menghapus komentar, balasan terhadap komentar tersebut juga akan dihapus. 
* Jika pengaturan [ParentComment](https://reference.aspose.com/slides/id/net/aspose.slides/icomment/properties/parentcomment) menghasilkan referensi melingkar, [PptxEditException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxeditexception) akan dilemparkan.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menambatkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah dibandingkan sebelumnya. 

Dalam [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/id/net/aspose-slides-for-net-21-11-release-notes/), kami menambahkan dukungan untuk komentar modern dengan menambahkan kelas [ModernComment](https://reference.aspose.com/slides/id/net/aspose.slides/moderncomment). Metode [AddModernComment](https://reference.aspose.com/slides/id/net/aspose.slides/commentcollection/methods/addmoderncomment) dan [InsertModernComment](https://reference.aspose.com/slides/id/net/aspose.slides/commentcollection/methods/insertmoderncomment) ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/net/aspose.slides/commentcollection). 

Kode C# berikut menunjukkan cara menambahkan komentar modern ke slide dalam presentasi PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Menghapus Komentar**

### **Hapus Semua Komentar dan Penulis**

Kode C# berikut menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Menghapus semua komentar dari presentasi
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Menghapus semua penulis
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Hapus Komentar Tertentu**

Kode C# berikut menunjukkan cara menghapus komentar tertentu pada slide:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // menambahkan komentar...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // menghapus semua komentar yang berisi teks "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Komentar modern](https://reference.aspose.com/slides/id/net/aspose.slides/moderncomment/) menyediakan properti [Status](https://reference.aspose.com/slides/id/net/aspose.slides/moderncomment/status/); Anda dapat membaca dan mengatur [status komentar](https://reference.aspose.com/slides/id/net/aspose.slides/moderncommentstatus/) (misalnya menandainya sebagai selesai), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi beruntai (rantai balasan) didukung, dan apakah ada batasan kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/net/aspose.slides/comment/parentcomment/), memungkinkan rantai balasan yang arbitrer. API tidak menetapkan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi disimpan sebagai titik floating‑point dalam sistem koordinat slide. Hal ini memungkinkan Anda menempatkan penanda komentar dengan presisi di mana pun diperlukan.