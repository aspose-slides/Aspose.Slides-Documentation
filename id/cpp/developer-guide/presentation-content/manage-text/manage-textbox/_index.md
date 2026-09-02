---
title: Kelola Kotak Teks dalam Presentasi Menggunakan C++
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/cpp/manage-textbox/
keywords:
- kotak teks
- frame teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Aspose.Slides untuk C++ memudahkan pembuatan, penyuntingan, dan kloning kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pendahuluan**

Teks pada slide biasanya berada dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks dan kemudian memasukkan teks ke dalam kotak teks tersebut. Aspose.Slides untuk C++ menyediakan antarmuka [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}
Aspose.Slides juga menyediakan antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_shape) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui antarmuka `IShape` dapat memuat teks. Tetapi bentuk yang ditambahkan melalui antarmuka [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape) dapat berisi teks. 
{{% /alert %}}

{{% alert title="Catatan" color="warning" %}} 
Oleh karena itu, saat berurusan dengan sebuah bentuk yang ingin Anda tambahkan teks, Anda mungkin ingin memeriksa dan memastikan bahwa bentuk tersebut telah di-cast melalui antarmuka `IAutoShape`. Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame), yang merupakan properti di bawah `IAutoShape`. Lihat bagian [Update Text](https://docs.aspose.com/slides/id/cpp/manage-textbox/#update-text) pada halaman ini. 
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation). 
2. Dapatkan referensi ke slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_auto_shape) dengan [ShapeType](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) yang diatur sebagai `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi ke objek `IAutoShape` yang baru ditambahkan. 
4. Tambahkan properti `TextFrame` ke objek `IAutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks berikut: *Aspose TextBox*
5. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode C++ ini—implementasi dari langkah-langkah di atas—menunjukkan cara menambahkan teks ke slide:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Membuat instansi Presentation
auto pres = System::MakeObject<Presentation>();

// Mendapatkan slide pertama dalam presentasi
auto sld = pres->get_Slides()->idx_get(0);

// Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Menambahkan TextFrame ke Rectangle
ashp->AddTextFrame(u" ");

// Mengakses text frame
auto txtFrame = ashp->get_TextFrame();

// Membuat objek Paragraph untuk text frame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Membuat objek Portion untuk paragraf
auto portion = para->get_Portions()->idx_get(0);

// Mengatur Teks
portion->set_Text(u"Aspose TextBox");

// Menyimpan presentasi ke disk
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [get_IsTextBox](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_istextbox/) dari antarmuka [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Kotak teks dan bentuk](istextbox.png)

Kode C++ ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Perhatikan bahwa jika Anda hanya menambahkan sebuah autoshape menggunakan metode `AddAutoShape` dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/) , metode `get_IsTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `AddTextFrame` atau metode `set_Text`, metode `get_IsTextBox` akan mengembalikan `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() mengembalikan false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() mengembalikan true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() mengembalikan false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() mengembalikan true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() mengembalikan false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() mengembalikan false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() mengembalikan false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() mengembalikan false
```

## **Temukan Bentuk yang Memiliki Text Frame**

Dalam kode pemrosesan teks umum, Anda mungkin menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) pemiliknya.

Untuk sebuah text frame yang dimiliki oleh sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) atau bentuk lain yang berisi teks, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) mengembalikan pemilik dan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) mengembalikan `nullptr`. Kedua metode tersebut menyediakan navigasi baca-saja, sehingga memanggilnya tidak mengubah kepemilikan. Selalu periksa nilai yang dikembalikan untuk `nullptr` sebelum mengakses bentuk.

Untuk contoh lengkap yang mengidentifikasi pemilik bentuk dan sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/cpp/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan metode [set_ColumnCount](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) dan [set_ColumnSpacing](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format) dan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format)) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak dalam point antara kolom. 

Kode C++ ini menunjukkan operasi yang dijelaskan: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Mendapatkan slide pertama dalam presentasi
auto slide = presentation->get_Slides()->idx_get(0);

// Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Menambahkan TextFrame ke Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Mendapatkan format teks dari TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Menentukan jumlah kolom dalam TextFrame
format->set_ColumnCount(3);

// Menentukan jarak antar kolom
format->set_ColumnSpacing(10);

// Menyimpan presentasi
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Tambahkan Kolom ke Text Frame**

Aspose.Slides untuk C++ menyediakan metode [set_ColumnCount](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (dari antarmuka [ITextFrameFormat](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_text_frame_format)) yang memungkinkan Anda menambahkan kolom dalam text frame. Melalui metode ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah text frame. 

Kode C++ ini menunjukkan cara menambahkan kolom di dalam text frame:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Perbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks dalam sebuah presentasi. 

Kode C++ ini menunjukkan operasi di mana semua teks dalam sebuah presentasi diperbarui atau diubah:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    // Mengubah teks
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    // Mengubah format
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

// Menyimpan presentasi yang sudah diubah
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Tambahkan Kotak Teks dengan Tautan** 

Anda dapat menyisipkan tautan di dalam kotak teks. Saat kotak teks diklik, pengguna akan diarahkan untuk membuka tautan. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas `Presentation`. 
2. Dapatkan referensi ke slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` yang diatur sebagai `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi ke objek AutoShape yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks default. 
5. Instansiasikan kelas `IHyperlinkManager`. 
6. Tetapkan objek `IHyperlinkManager` ke metode [set_HyperlinkClick](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) yang terkait dengan bagian `TextFrame` pilihan Anda. 
7. Terakhir, tulis file PPTX melalui objek `Presentation`. 

Kode C++ ini—implementasi dari langkah-langkah di atas—menunjukkan cara menambahkan kotak teks dengan tautan ke slide:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Membuat instance kelas Presentation yang mewakili file PPTX
auto presentation = System::MakeObject<Presentation>();

// Mendapatkan slide pertama dalam presentasi
auto slide = presentation->get_Slides()->idx_get(0);

// Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Meng-cast shape menjadi AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Mengakses properti ITextFrame yang terkait dengan AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Menambahkan beberapa teks ke frame
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Menetapkan Hyperlink untuk teks portion
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Menyimpan presentasi PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/cpp/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/cpp/aspose.slides/layoutslide/), sedangkan kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah saat Anda beralih layout.

**Bagaimana cara melakukan penggantian teks secara massal di seluruh presentasi tanpa memengaruhi teks di dalam chart, table, dan SmartArt?**

Batasi iterasi Anda hanya pada auto-shape yang memiliki text frame dan kecualikan objek tersemat ([chart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/), [table](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewatkan tipe objek tersebut.