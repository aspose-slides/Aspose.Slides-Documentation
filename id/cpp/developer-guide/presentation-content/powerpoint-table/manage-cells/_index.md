---
title: Kelola Sel Tabel dalam Presentasi dengan C++
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/cpp/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus batas
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di C++: identifikasi sel yang digabung, hapus batas, pisah sel, dan mengatur warna latar belakang serta gambar dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(column, row)`.

## **Identifikasi Sel Tabel yang Digabungkan**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Ia mengasumsikan bahwa slide dan bentuk tersebut ada serta bentuk tersebut adalah tabel. Kemudian ia mengiterasi semua baris dan kolom dan menggunakan [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) untuk mengidentifikasi sel dalam wilayah yang digabungkan. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), dan koordinat awal wilayah, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) dan [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Hapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur keempat batas sel menjadi [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), sehingga tidak terlihat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Gabungkan Sel Tabel**

Gunakan [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel di sudut kiri‑atas dan kanan‑bawah dari rentang tersebut. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang itu.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel hasil mencakup dua kolom dan dua baris, sementara kisi dasar tabel tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau format sel yang digabungkan, gunakan posisi kiri‑atasnya: `table->idx_get(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabungkan tetap menjadi bagian dari kisi tabel, sehingga indeks sel di luar rentang tidak berubah.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Pisahkan Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan kisi tabel. Memisahkan sebuah sel dapat memperkenalkan kolom kisi baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model kisi tabel PowerPoint.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin dan memanggil [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar yang sama.

Setelah pemisahan ini, dua bagian diakses sebagai `table->idx_get(1, 1)` dan `table->idx_get(2, 1)`. Kisi tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pemisahan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Pisahkan Sel yang Digabungkan berdasarkan Rentang Baris atau Kolom**

Untuk mempersiapkan sel templat yang digabungkan untuk pengisian data, gunakan [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) untuk memisahkan sepanjang batas baris yang ada, atau [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris di bagian atas atau kolom di bagian kiri dari pemisahan; ia relatif terhadap wilayah yang digabungkan:
- Pemisahan baris: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Pemisahan kolom: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Contoh ini mengharapkan sebuah presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Dimulai dari posisi bawah, ia menggunakan [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) dan [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) untuk menemukan asal dan memeriksa kedua rentang. `SplitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom secara horizontal, gunakan `SplitByColSpan(1)` sebagai gantinya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Ambil sel yang dihasilkan dari tabel setelah dipisah.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Kisi tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel hasil dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) mencetak `False`. Wilayah yang lebih besar dapat tetap sebagian tergabung setelah satu pemisahan.

Teks asli dan formatnya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi format sel seperti isian, batas, dan margin. Isi sel setelah pemisahan dan atur format teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel terpisah "Product A" dan "Product B" dengan format sel dari templat yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) untuk detail.

## **Ubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) untuk memilih isian padat dan [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) untuk mengakses warna isian dan mengaturnya menjadi merah untuk sel `(2, 3)`, pada kolom ketiga dan baris keempat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Tambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Ia memuat gambar dengan [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) dan menambahkannya ke koleksi gambar presentasi dengan [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Kemudian gambar tersebut diberikan ke isian gambar sel `(0, 0)`, sel pertama pada tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) memanjang gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang setelah ditambahkan ke presentasi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bisakah saya mengatur ketebalan garis dan gaya yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [atas](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bawah](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[kiri](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[kanan](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah mengatur gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/). Dengan peregangan, gambar menyesuaikan diri dengan sel baru; dengan penempatan ubin, ubin‑ubin tersebut dihitung ulang.

**Bisakah saya menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/cpp/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke suatu bagian atau ke seluruh teks dalam sel.

**Bisakah saya mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/).