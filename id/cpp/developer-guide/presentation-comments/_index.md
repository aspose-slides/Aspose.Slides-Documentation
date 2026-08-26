---
title: Kelola Komentar Presentasi dalam C++
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
- menambah komentar
- mengakses komentar
- mengedit komentar
- membalas komentar
- menghapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk C++: tambahkan, baca, edit, balas, dan hapus komentar dalam presentasi PowerPoint dengan cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk C++. Artikel ini memperkenalkan tipe utama yang berhubungan dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario ulasan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar ke penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teks dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides untuk C++ menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang memberikan akses ke penulis komentar presentasi.
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/icommentcollection/) yang mewakili komentar yang terkait dengan satu penulis.
* Antarmuka [IComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/) yang menyediakan informasi tentang sebuah komentar, termasuk penulis, waktu pembuatan, posisi, dan teks.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/cpp/aspose.slides/commentauthor/) yang memberikan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Mengakses Komentar Slide**

Contoh berikut menunjukkan cara mengakses komentar yang ada dalam presentasi PowerPoint:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Membalas Komentar**

Komentar induk adalah komentar asli di bagian atas hierarki balasan. Metode [get_ParentComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/get_parentcomment/) dan [set_ParentComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/set_parentcomment/) dari antarmuka [IComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/) memungkinkan Anda mendapatkan atau menetapkan induk sebuah komentar.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}

* Ketika metode [Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/remove/) dari antarmuka [IComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika metode [set_ParentComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/set_parentcomment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/cpp/aspose.slides/pptxeditexception/) akan dilempar.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan sebuah shape tertentu, atau dengan rentang teks di dalam AutoShape. Metode [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icommentcollection/addmoderncomment/) menerima argumen [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) selain slide dan koordinat penanda komentar.

Ketika `nullptr` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, tetapi tidak terkait dengan shape tertentu, sehingga [IModernComment::get_Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_shape/) mengembalikan `nullptr`. Ketika sebuah [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) disediakan, komentar diikat ke shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [IModernComment::get_Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_shape/).

### **Menambatkan Komentar Modern ke sebuah Shape**

Contoh berikut membuat komentar modern tingkat slide dan komentar modern yang ditambatkan ke sebuah AutoShape tertentu. Kemudian contoh tersebut membaca shape yang terkait dari masing‑masing komentar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Menambatkan Komentar ke Berbagai Tipe Shape**

Setiap objek slide yang mengimplementasikan [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) dapat digunakan sebagai penambat shape. Contoh umum meliputi [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/), dan instance [IGraphicalObject](https://reference.aspose.com/slides/id/cpp/aspose.slides/igraphicalobject/) seperti grafik.

Contoh berikut membuat beberapa tipe shape umum dan mengaitkan komentar modern dengan masing‑masingnya.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");
auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Menambatkan Komentar ke Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/), metode [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_textselectionstart/) dan [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/set_textselectionstart/) mengontrol posisi awal teks yang dipilih dalam frame teks shape. Demikian pula, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_textselectionlength/) dan [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/set_textselectionlength/) mengontrol panjang seleksi. Bersama‑sama, metode‑metode ini mengaitkan komentar dengan rentang teks spesifik di dalam AutoShape.

Metode [IModernComment::get_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_status/) dan [IModernComment::set_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/set_status/) menggunakan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern yang spesifik.
- `Active` — komentar aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh berikut membuat komentar modern yang ditambatkan ke shape, mengaitkannya dengan seleksi teks, menandainya sebagai diselesaikan, menyimpan presentasi, dan memverifikasi nilai setelah membuka kembali file.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Memeriksa Komentar Modern yang Ada**

Untuk memeriksa presentasi yang ada, cek komentar mana yang mengimplementasikan [IModernComment](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/), lalu periksa [IModernComment::get_Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_textselectionlength/), dan [IModernComment::get_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_status/). Sebuah shape `nullptr` menunjukkan komentar tingkat slide. Untuk penambat [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/), metode seleksi teks mengidentifikasi rentang yang terkait dalam frame teks shape.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Menghapus Komentar Tertentu**

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah Aspose.Slides mendukung status selesai untuk komentar modern?**

Ya. [IModernComment::get_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/get_status/) dan [IModernComment::set_Status](https://reference.aspose.com/slides/id/cpp/aspose.slides/imoderncomment/set_status/) menggunakan nilai [ModernCommentStatus](https://reference.aspose.com/slides/id/cpp/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/cpp/aspose.slides/icomment/set_parentcomment/)-nya, memungkinkan rantai balasan. API tidak menentukan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.