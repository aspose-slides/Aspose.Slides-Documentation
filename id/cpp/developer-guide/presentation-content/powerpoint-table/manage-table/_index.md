---
title: Kelola Tabel Presentasi dalam C++
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/cpp/manage-table/
keywords:
- menambah tabel
- membuat tabel
- mengakses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk C++. Temukan contoh kode sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel dalam PowerPoint mengatur informasi ke dalam baris dan kolom, sehingga lebih mudah dibaca dan membandingkan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , kelas [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , antarmuka [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) , dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Membuat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan menyisipkan teks.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan array lebar kolom dalam poin.
4. Tentukan array tinggi baris dalam poin.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) .
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama di baris pertama tabel.
8. Akses sel yang digabungkan melalui metode [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) .
9. Atur teks di sel yang digabungkan.
10. Simpan presentasi yang dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada titik (100, 50) poin. Itu menerapkan batas merah dengan lebar 5 poin, menggabungkan dua sel pertama di baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel berbasis nol dan menggunakan urutan (kolom, baris). Sel pertama diindeks sebagai (0, 0).

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang diilustrasikan di atas, dengan lebar kolom dan tinggi baris 70 poin serta batas sel merah dengan lebar 5 poin. Koordinat menggambarkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Mengakses Tabel yang Ada**

Tabel disimpan dalam koleksi bentuk slide. Iterasi bentuk-bentuk untuk menemukan tabel, lalu gunakan antarmuka [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) untuk membaca atau memperbarui sel-selnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi objek [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) dan berhenti ketika tabel ditemukan. Jika slide berisi beberapa tabel, gunakan [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) untuk mengidentifikasi yang Anda perlukan.
4. Perbarui teks di sel target.
5. Simpan presentasi yang dimodifikasi.

Contoh di bawah membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia mengatur sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi sebenarnya dapat melampaui minimum yang diminta, lihat [Control Row Height](/slides/id/cpp/manage-rows-and-columns/#control-row-height).

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks generik menerima sebuah [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) dari tabel, gunakan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) untuk mengambil [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) pemiliknya. Untuk text frame sel tabel, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) mengembalikan pemilik dan [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) mengembalikan `nullptr`, meskipun tabel itu sendiri adalah sebuah bentuk.

Koordinat sel tersedia melalui metode read‑only [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) dan [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) juga menyediakan navigasi read‑only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa sel yang dikembalikan untuk `nullptr` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan bentuk, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/cpp/search-and-replace-text/).

## **Menjajarkan Teks dalam Tabel**

Anda dapat mengontrol penempatan vertikal dan arah teks sel tabel individu. Contoh pada bagian ini menengahkan teks di dalam sel pertama dan memutarnya 270 derajat.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ke slide.
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) dari tabel.
5. Akses [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) pertama dan atur teks serta warnanya.
6. Atur penempatan vertikal sel dan arah teks menggunakan [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) dan [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) .
7. Simpan presentasi yang dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks di sel (0, 0), menambahkan nilai ke sel‑sel lain di baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Mengatur Pemformatan Teks pada Tingkat Tabel**

Gunakan [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) untuk menerapkan pemformatan teks ke semua sel dalam tabel. Overload‑nya menerima pemformatan bagian, paragraf, dan frame teks, sehingga Anda dapat mengatur properti ini tanpa iterasi sel‑sel individu.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) dari slide.
4. Atur ukuran font menggunakan [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk teks.
5. Atur perataan paragraf dan margin kanan menggunakan [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Atur arah teks menggunakan [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Simpan presentasi yang dimodifikasi.

Contoh di bawah membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai bentuk pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan paragraf ke kanan dengan margin kanan 20 poin, dan membuat teks vertikal. Presentasi yang diformat disimpan sebagai `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) untuk membaca gaya preset tabel dan [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) untuk menugaskannya. Contoh ini menerapkan [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) ke satu tabel, mencetak nama preset, dan menugaskan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan antara lebar dan tingginya. Gunakan [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) untuk mengunci rasio ini pada tabel.

Contoh di bawah membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai bentuk pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`True`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel menyediakan metode [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) , dan paragraf memiliki [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Menggunakan keduanya memastikan urutan RTL yang benar dan render yang tepat di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [kunci bentuk](/slides/id/cpp/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah penyisipan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [isi gambar](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) untuk sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).