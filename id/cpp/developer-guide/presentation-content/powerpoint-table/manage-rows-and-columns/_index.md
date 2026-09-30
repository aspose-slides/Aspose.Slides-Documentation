---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan C++
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/cpp/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- gandakan baris
- gandakan kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan Aspose.Slides untuk C++ dan percepat pengeditan presentasi serta pembaruan data."
---
## **Pendahuluan**

Aspose.Slides for C++ memungkinkan Anda mengelola struktur tabel dan pemformatan dalam presentasi PowerPoint melalui kelas [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) dan antarmuka [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Anda dapat menentukan baris header, menggandakan atau menghapus baris dan kolom, serta menerapkan pemformatan teks ke seluruh baris atau kolom.

Artikel ini menjelaskan operasi ini dengan contoh C++. Ini juga menunjukkan cara mengambil preset gaya tabel sehingga Anda dapat menggunakannya kembali. Indeks baris dan kolom tabel dimulai dari nol.

## **Kontrol Tinggi Baris**

Gunakan [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) untuk menetapkan tinggi minimum baris dalam poin. Ini adalah batas bawah, bukan tinggi tetap. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) mengembalikan tinggi sebenarnya; nilai ini tidak dapat diatur secara langsung. Akses baris melalui [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Contoh ini memuat [row-height-input.pptx](row-height-input.pptx), yang memiliki tabel sebagai bentuk pertama pada slide pertama. Baris pertamanya dimulai pada 70 poin. Sel‑sel menggunakan teks Arial 18 poin, dengan pembungkusan, dan margin atas serta bawah 6 poin; teks yang lebih panjang pada kolom kedua terbungkus menjadi beberapa baris. Contoh ini meningkatkan minimum menjadi 100 poin, kemudian menurunkannya menjadi 20 poin, mencetak tinggi sebenarnya setelah setiap perubahan, dan menyimpan kedua hasilnya.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Dengan presentasi yang disediakan, meningkatkan minimum menambah ruang pada baris. Menurunkannya menghapus ruang tambahan tersebut, tetapi tinggi sebenarnya tetap lebih besar dari 20 poin karena teks dan margin sel membutuhkan lebih banyak ruang. Mengurangi minimum saja tidak dapat memaksa baris berada di bawah ruang yang dibutuhkan oleh kontennya.

Beberapa faktor memengaruhi tinggi sebenarnya:

- **Teks dan ukuran font:** teks yang lebih panjang, jeda baris eksplisit, atau font yang lebih besar dapat membutuhkan lebih banyak ruang vertikal.
- **Pembungkusan dan lebar kolom:** dengan pembungkusan diaktifkan, mengurangi lebar kolom dengan [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) dapat menghasilkan lebih banyak baris. Kolom yang lebih lebar dapat mengurangi ruang yang dibutuhkan secara vertikal.
- **Margin sel:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) dan [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) mengontrol margin yang menambah ruang vertikal. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) dan [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) mengontrol margin yang mengurangi lebar tersedia untuk teks dan dapat menyebabkan pembungkusan tambahan.

Untuk tabel ini tanpa sel yang digabung, sel yang memerlukan ruang vertikal terbanyak menentukan batas bawah yang dipengaruhi konten untuk seluruh baris. Untuk membuat baris lebih pendek, Anda mungkin juga perlu memendekkan teks, mengurangi ukuran font atau margin, atau memperlebar sebuah kolom.

Gambar di bawah memperlihatkan tabel yang sama dengan skala yang sama. Pada contoh .NET referensi yang ditampilkan di sini, tinggi sebenarnya adalah 70, 100, dan 55,2 poin: baris akhir tetap lebih tinggi daripada minimum 20 poin. Pengukuran teks yang tepat dapat bervariasi tergantung pada font yang tersedia di lingkungan Anda. Unduh hasil yang disimpan: [increased minimum](row-height-increased.pptx) dan [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Tabel asli dengan baris pertama 70 poin.](row-height-before.png) | ![Tabel setelah meningkatkan minimum baris pertama menjadi 100 poin.](row-height-increased.png) | ![Tabel setelah menurunkan minimum baris pertama menjadi 20 poin; teks terbungkus membuat baris lebih tinggi daripada minimum.](row-height-decreased.png) |

## **Atur Baris Pertama sebagai Header**

Gunakan metode [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) untuk menandai baris pertama agar diformat sebagai header. Penampilannya tergantung pada gaya tabel yang diterapkan pada tabel.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Akses slide pertama.
3. Akses tabel yang disimpan sebagai bentuk pertama pada slide.
4. Aktifkan pemformatan header untuk baris pertamanya.
5. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama. Contoh ini mengaktifkan pemformatan header untuk baris pertama dan menyimpan `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Menggandakan Baris atau Kolom Tabel**

Gandakan baris atau kolom untuk menggunakan kembali konten dan pemformatannya. Anda dapat menambahkan salinan ke akhir tabel atau menyisipkannya pada posisi tertentu.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Gandakan baris yang diperlukan.
6. Gandakan kolom yang diperlukan.
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `Test.pptx` dengan setidaknya satu slide. Contoh ini membuat tabel dengan tiga kolom dan lima baris, dengan dimensi dalam poin. Contoh ini menambahkan salinan baris pertama dan kolom pertama, kemudian menyisipkan salinan baris kedua dan kolom kedua pada indeks 3 (posisi keempat). Tabel yang dihasilkan memiliki tujuh baris dan lima kolom. Argumen `false` menonaktifkan penggandaan ke baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Menghapus Baris atau Kolom dari Tabel**

Hapus baris atau kolom yang tidak lagi diperlukan dalam sebuah tabel. Menghapus sebuah item menggeser indeks baris atau kolom yang mengikutinya.

1. Buat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Hapus baris kedua dan kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel tiga‑by‑tiga dan menghapus baris serta kolom pada indeks 1, menghasilkan tabel dua‑by‑dua dalam `TestTable_out.pptx`. Dimensi dalam poin. Argumen `false` menonaktifkan penghapusan baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Baris Tabel**

Terapkan pemformatan teks ke seluruh baris untuk menjaga konsistensi sel‑selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Atur tinggi font dengan [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk baris pertama.
4. Atur perataan dan margin paragraf kanan dengan [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) untuk baris pertama.
5. Atur arah teks dengan [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) untuk baris kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua baris. Contoh ini menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada baris pertama, kemudian mengatur teks vertikal pada baris kedua.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Kolom Tabel**

Terapkan pemformatan teks ke seluruh kolom untuk menjaga konsistensi sel‑selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Atur tinggi font dengan [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) untuk kolom pertama.
4. Atur perataan dan margin paragraf kanan dengan [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) dan [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) untuk kolom pertama.
5. Atur arah teks dengan [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) untuk kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua kolom. Contoh ini menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada kolom pertama, kemudian mengatur teks vertikal pada kolom kedua.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Dapatkan Properti Gaya Tabel**

Gunakan metode [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) untuk mengambil preset yang diterapkan pada sebuah tabel dan menggunakannya kembali pada tabel lain. Ini mengidentifikasi preset alih‑alih penggantian pemformatan sel individu.

Contoh ini membuat tabel, menerapkan [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), dan membaca kembali preset tersebut. Contoh ini mencetak `DarkStyle1` dan menyimpan tabel dalam `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Tanya Jawab**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda tetap dapat menimpa isian, batas, serta warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, kemudian isi kembali baris‑baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (berpola) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel‑sel tertentu dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.