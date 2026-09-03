---
title: Kelola Kotak Teks dalam Presentasi Menggunakan C++
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/cpp/manage-textbox/
keywords:
- kotak teks
- bingkai teks
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
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++."
---
## **Pendahuluan**

Dalam Aspose.Slides untuk C++, teks slide disimpan dalam bingkai teks yang dimiliki oleh bentuk. Antarmuka [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) mewakili bentuk yang paling umum membawa teks dan mengekspos teksnya melalui metode [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}
Setiap auto shape mengimplementasikan [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/), tetapi tidak setiap shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) sebelum mengakses teksnya.
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks persegi panjang:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Koordinat dan dimensi yang diberikan ke [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addautoshape/) diukur dalam poin. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa Bentuk Kotak Teks**

Gunakan metode [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_istextbox/) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika presentasi berisi baik auto shape yang membawa teks maupun auto shape yang hanya grafis.

![Kotak teks dan sebuah bentuk](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai ia berisi teks tidak kosong. Anda dapat memberikan teks tersebut melalui [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/addtextframe/) atau [ITextFrame::set_Text](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/set_text/). Menambahkan atau menetapkan string kosong membuat [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/get_istextbox/) mengembalikan `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Dua pemeriksaan pertama mengembalikan `true`; dua pemeriksaan terakhir mengembalikan `false`.

## **Temukan Bentuk yang Memiliki Bingkai Teks**

Kode pemrosesan teks umum mungkin menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan metode [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) untuk menavigasi kembali ke [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh auto shape atau bentuk lain yang membawa teks, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) mengembalikan pemiliknya dan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) mengembalikan `nullptr`. Kedua metode menyediakan navigasi read-only. Periksa nilai yang dikembalikan untuk `nullptr` sebelum mengaksesnya. Untuk mengidentifikasi pemilik shape dan sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/cpp/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Metode [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/set_columncount/) membagi bingkai teks menjadi kolom, sementara [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/set_columnspacing/) menentukan jarak antar kolom dalam poin. Kedua metode merupakan bagian dari [ITextFrameFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/) dan dapat dipanggil melalui bingkai teks dari kotak teks yang ada. Teks mengalir ulang di antara kolom dalam shape yang sama; tidak berlanjut ke shape lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca pengaturan yang disimpan kembali dari file output:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Ekstrak Teks dari Setiap Kolom**

Gunakan [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/splittextbycolumns/) untuk mengambil teks yang ditetapkan ke setiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan pembacaan berdasarkan kolom. Bingkai teks satu kolom menghasilkan array dengan satu elemen, dan kolom kosong direpresentasikan dengan string kosong. String tersebut hanya berisi teks biasa; pemformatan pada tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:

- Ekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Indeks atau bandingkan konten slide multi-kolom.
- Ekspor setiap kolom ke file terpisah, bidang basis data, atau tujuan lain.
- Periksa bagaimana teks didistribusikan ulang setelah mengatur jumlah kolom dengan [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/set_columncount/) atau jarak dengan [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/set_columnspacing/), atau mengubah font atau ukuran bingkai teks.

Metode ini melaporkan teks yang didistribusikan dalam [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) saat ini; tidak secara otomatis mengalirkan teks antara shape atau kotak teks terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang dibutuhkan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi-kolom pertama dengan bingkai teks pada slide pertama, membaca jumlah kolom yang dikonfigurasi, dan menulis teks dari setiap kolom ke file terpisah. Shape yang tidak menyediakan bingkai teks akan dilewati.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasi melalui slide dan shape, pilih auto shape, lalu edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah teks dan pemformatan karakter.

Contoh berikut menggantikan setiap kemunculan `years` dengan `months` dalam bagian teks auto-shape individual dan membuat setiap bagian yang terpengaruh menjadi tebal:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Travers ini memperbarui teks hanya pada auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau shape yang dikelompokkan memerlukan travers pada koleksi objek masing-masing.

## **Tambahkan Kotak Teks dengan Tautan**

Tautan dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks tersebut yang berfungsi sebagai tautan yang dapat diklik. Gunakan [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/id/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks yang ditautkan dan menyimpannya ke presentasi:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/cpp/manage-placeholder/) dapat mewarisi posisi dan formatnya dari sebuah [master slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika layout berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks dalam diagram, tabel, atau SmartArt?**

Batasi traversal hanya pada shape yang mengimplementasikan [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/), seperti yang ditunjukkan dalam contoh Perbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek masing-masing, sehingga tidak diubah oleh loop tersebut.