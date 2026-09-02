---
title: Kelola Tabel Presentasi dalam C++
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/cpp/manage-table/
keywords:
- tambah tabel
- buat tabel
- akses tabel
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

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (diatur dalam baris dan kolom) sederhana dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/), antarmuka [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/), kelas [Cell](https://reference.aspose.com/slides/id/cpp/aspose.slides/cell/), antarmuka [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/), dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam segala jenis presentasi. 

## **Membuat Tabel dari Awal**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array `columnWidth`.
4. Tentukan array `rowHeight`.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addtable/).
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/) milik sebuah [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/). 
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara membuat tabel dalam presentasi:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>();

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Menambahkan shape tabel ke slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Mengatur format batas untuk setiap sel
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Menggabungkan sel 1 dan 2 pada baris 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Menambahkan teks ke sel yang digabungkan
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Menyimpan presentasi ke Disk
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat sederhana dan dimulai dari nol. Sel pertama dalam tabel memiliki indeks 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel-sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode C++ ini menunjukkan cara menentukan penomoran untuk sel-sel dalam tabel:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>();

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Menambahkan shape tabel ke slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Mengatur format batas untuk setiap sel
for (const auto& row : tbl->get_Rows())
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

// Menyimpan presentasi ke disk
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Mengakses Tabel yang Ada**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).

2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 

3. Buat objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) dan setel menjadi null.

4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) hingga tabel ditemukan.

   Jika Anda menduga slide yang sedang Anda kerjakan hanya berisi satu tabel, Anda dapat memeriksa semua shape yang ada di dalamnya. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/). Namun jika slide yang sedang Anda kerjakan berisi beberapa tabel, lebih baik mencari tabel yang diperlukan melalui [set_AlternativeText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_alternativetext/).

5. Gunakan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) untuk bekerja dengan tabel. Pada contoh di bawah, kami menambahkan baris baru ke tabel.

6. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Membuat instance kelas Presentation yang mewakili file PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Mengakses slide pertama
auto sld = pres->get_Slides()->idx_get(0);

// Menginisialisasi Table null
System::SharedPtr<ITable> tbl;

// Mengiterasi shape dan menetapkan referensi ke tabel yang ditemukan
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Menetapkan teks untuk kolom pertama baris kedua
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Menyimpan presentasi yang dimodifikasi ke disk
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Temukan Sel yang Memiliki Text Frame**

Saat kode pemrosesan teks generik menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari tabel, gunakan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) untuk mengambil [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/) yang memilikinya. Untuk text frame sel tabel, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) mengembalikan pemiliknya dan [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) mengembalikan `nullptr`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui metode hanya-baca [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/get_firstcolumnindex/) dan [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) juga menyediakan navigasi hanya-baca: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `nullptr` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/cpp/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) ke slide. 
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) dari tabel. 
5. Akses [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) milik [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/).
6. Selaraskan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode C++ ini menunjukkan cara menyelaraskan teks dalam tabel:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();

// Mendapatkan slide pertama
auto slide = presentation->get_Slides()->idx_get(0);

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Menambahkan shape tabel ke slide
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Mengakses frame teks
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Membuat objek Paragraph untuk frame teks
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Membuat objek Portion untuk paragraf
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Menyelaraskan teks secara vertikal
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Menyimpan Presentation ke disk
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Mengatur Pemformatan Teks pada Tingkat Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) dari Slide.
4. Setel [set_FontHeight](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk teks. 
5. Setel [set_Alignment](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Setel [set_TextVerticalType](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Simpan presentasi yang telah dimodifikasi. 

Kode C++ ini menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Membuat instance kelas Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Anggap bahwa shape pertama pada slide pertama adalah tabel
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Mengatur tinggi font sel tabel
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Mengatur perataan teks sel tabel dan margin kanan dalam satu panggilan
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Mengatur tipe vertikal teks sel tabel
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode C++ ini menunjukkan cara mendapatkan properti gaya dari style prasetel tabel:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek sebuah shape geometrik adalah perbandingan ukuran dalam dimensi yang berbeda. Aspose.Slides menyediakan properti `AspectRatioLocked()` untuk memungkinkan Anda mengunci pengaturan rasio aspek bagi tabel dan shape lainnya. 

Kode C++ ini menunjukkan cara mengunci rasio aspek untuk tabel:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca right-to-left (RTL) untuk seluruh tabel dan teks di sel-selnya?**

Ya. Tabel menyediakan metode [set_RightToLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/table/set_righttoleft/), dan paragraf memiliki [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraphformat/set_righttoleft/). Menggunakan keduanya memastikan urutan RTL yang benar serta rendering di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/cpp/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/cpp/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).