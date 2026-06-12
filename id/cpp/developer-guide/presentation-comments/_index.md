---
title: Kelola Komentar Presentasi di C++
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/cpp/presentation-comments/
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
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasai komentar presentasi dengan Aspose.Slides untuk C++: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi di Aspose.Slides. Ini menampilkan tipe‑tipe utama yang berhubungan dengan komentar dan memperagakan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan, menggunakan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh‑contoh difokuskan pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca isi komentar dan metadata, membangun rantai balasan, serta membersihkan semua komentar atau menghapus komentar yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada sebuah slide. Ketika komentar diklik, isi atau pesan komentar akan ditampilkan.

### **Mengapa Menambahkan Komentar ke Presentasi?**

Anda mungkin ingin menggunakan komentar untuk memberikan umpan balik atau berkomunikasi dengan rekan kerja ketika meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides untuk C++ menyediakan

* Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) yang berisi koleksi penulis (dari metode [get_CommentAuthors()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Para penulis menambahkan komentar ke slide. 
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment_collection) yang berisi koleksi komentar untuk masing‑masing penulis. 
* Kelas [IComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment) yang menyimpan informasi tentang penulis dan komentar mereka: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll. 
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.comment_author) yang berisi informasi tentang masing‑masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll. 

## **Menambahkan Komentar Slide**
Kode C++ berikut menunjukkan cara menambahkan komentar ke sebuah slide dalam presentasi PowerPoint:

```cpp
// Menginisialisasi kelas Presentation
auto presentation = System::MakeObject<Presentation>();
// Menambahkan slide kosong
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Menambahkan penulis
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Menetapkan posisi untuk komentar
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Mengakses ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Mengakses ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Menambahkan komentar slide untuk penulis pada slide 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Menambahkan komentar slide untuk penulis pada slide 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Ketika null diberikan sebagai argumen, komentar dari semua penulis dibawa ke slide yang dipilih
auto comments = slide1->GetSlideComments(author);

// Mengakses komentar pada indeks 0 untuk slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Memilih koleksi komentar Penulis pada indeks 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Mengakses Komentar Slide**
Kode C++ berikut menunjukkan cara mengakses komentar yang sudah ada pada sebuah slide dalam presentasi PowerPoint:

```cpp
// Menginisialisasi kelas Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Balas Komentar**
Komentar induk adalah komentar teratas atau komentar asli dalam hierarki komentar atau balasan. Dengan menggunakan properti [ParentComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment)), Anda dapat menetapkan atau mengambil komentar induk. 

Kode C++ berikut menunjukkan cara menambahkan komentar dan memperoleh balasannya:

```cpp
auto pres = System::MakeObject<Presentation>();

// Mengakses ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Menambahkan komentar
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Menambahkan balasan ke comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Menambahkan balasan lain ke comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Menambahkan balasan ke balasan yang ada
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Menampilkan hirarki komentar di konsol
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Menghapus comment1 dan semua balasannya
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Ketika metode [Remove](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment)) digunakan untuk menghapus sebuah komentar, balasan‑balasan komentar tersebut juga akan dihapus. 
* Jika pengaturan [ParentComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) menghasilkan referensi melingkar, [PptxEditException](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) akan dilemparkan.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menambatkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah dibandingkan sebelumnya. 

Di [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/id/cpp/aspose-slides-for-cpp-21-11-release-notes/), kami menambahkan dukungan untuk komentar modern dengan menambahkan kelas [ModernComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.modern_comment). Metode [AddModernComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) dan [InsertModernComment](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.comment_collection).

Kode C++ berikut menunjukkan cara menambahkan komentar modern ke sebuah slide dalam presentasi PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Mengakses ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis**

Kode C++ berikut menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Menghapus semua komentar dari presentasi
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Menghapus semua penulis
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Menghapus Komentar Tertentu**

Kode C++ berikut menunjukkan cara menghapus komentar tertentu pada sebuah slide:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// menambahkan komentar...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// menghapus semua komentar yang mengandung teks "comment 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Komentar modern](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncomment/) menyediakan metode [get_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncomment/get_status/) dan [set_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncomment/set_status/); Anda dapat membaca dan menetapkan [status komentar](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncommentstatus/) (misalnya menandainya sebagai terselesaikan), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batasan kedalaman nesting?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/cpp/aspose.slides/comment/set_parentcomment/), memungkinkan rantai balasan secara arbitrer. API tidak menetapkan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar pada slide didefinisikan?**

Posisi disimpan sebagai titik floating‑point dalam sistem koordinat slide. Hal ini memungkinkan Anda menempatkan penanda komentar tepat pada lokasi yang diinginkan.