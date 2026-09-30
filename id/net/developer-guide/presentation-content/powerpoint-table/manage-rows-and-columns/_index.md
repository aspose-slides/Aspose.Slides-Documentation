---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint di .NET
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/net/manage-rows-and-columns/
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
- .NET
- C#
- Aspose.Slides
description: "Kelola baris dan kolom tabel di PowerPoint dengan Aspose.Slides untuk .NET dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Pendahuluan**

Aspose.Slides untuk .NET memungkinkan Anda mengelola struktur tabel dan pemformatan dalam presentasi PowerPoint melalui kelas [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) dan antarmuka [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Anda dapat menetapkan baris header, menggandakan atau menghapus baris dan kolom, serta menerapkan pemformatan teks ke seluruh baris atau kolom.

Artikel ini menjelaskan operasi tersebut dengan contoh C#. Artikel ini juga menunjukkan cara mengambil preset gaya tabel sehingga Anda dapat menggunakannya kembali. Indeks baris dan kolom tabel dimulai dari nol.

## **Kontrol Tinggi Baris**

Gunakan [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) untuk menentukan tinggi minimum baris dalam poin. Ini adalah batas bawah, bukan tinggi tetap. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) mengembalikan tinggi sebenarnya dan bersifat read‑only. Akses baris melalui [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Contoh memuat [row-height-input.pptx](row-height-input.pptx), yang memiliki tabel sebagai shape pertama pada slide pertama. Baris pertamanya dimulai pada 70 poin. Sel menggunakan teks Arial 18 poin, wrapping, dan margin atas serta bawah 6 poin; teks yang lebih panjang pada kolom kedua terbungkus menjadi beberapa baris. Contoh meningkatkan minimum menjadi 100 poin, kemudian menurunkannya menjadi 20 poin, mencetak tinggi sebenarnya setelah setiap perubahan, dan menyimpan kedua hasilnya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Dengan presentasi yang disediakan, meningkatkan minimum menambahkan ruang ke baris. Menurunkannya menghapus ruang tambahan itu, namun tinggi sebenarnya tetap lebih besar dari 20 poin karena teks dan margin sel memerlukan ruang lebih. Mengurangi minimum saja tidak dapat memaksa baris berada di bawah ruang yang dibutuhkan oleh isinya.

Beberapa faktor memengaruhi tinggi sebenarnya:

- **Teks dan ukuran font:** teks yang lebih panjang, pemecahan baris eksplisit, atau font yang lebih besar dapat membutuhkan lebih banyak ruang vertikal.
- **Wrapping dan lebar kolom:** dengan wrapping diaktifkan, [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) yang lebih sempit dapat menghasilkan lebih banyak baris. Kolom yang lebih lebar dapat mengurangi ruang yang diperlukan secara vertikal.
- **Margin sel:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) dan [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) menambah ruang vertikal. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) dan [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) mengurangi lebar yang tersedia untuk teks dan dapat menyebabkan wrapping tambahan.

Untuk tabel ini tanpa sel yang digabung, sel yang membutuhkan ruang vertikal paling banyak menentukan batas bawah berbasis konten untuk seluruh baris. Untuk membuat baris lebih pendek, Anda mungkin juga perlu memendekkan teks, mengurangi ukuran font atau margin, atau memperlebar sebuah kolom.

Gambar di bawah menampilkan tabel yang sama pada skala yang sama. Pada percobaan ini, tinggi sebenarnya adalah 70, 100, dan 55,2 poin: baris terakhir tetap lebih tinggi daripada minimum 20 poin. Pengukuran teks yang tepat dapat bervariasi tergantung pada font yang tersedia di lingkungan Anda. Unduh hasil yang disimpan: [increased minimum](row-height-increased.pptx) dan [decreased minimum](row-height-decreased.pptx).

| Asli: minimum 70 pt, aktual 70 pt | Ditambah: minimum 100 pt, aktual 100 pt | Dikurangi: minimum 20 pt, aktual 55.2 pt |
| --- | --- | --- |
| ![Tabel asli dengan baris pertama 70 poin.](row-height-before.png) | ![Tabel setelah menambah minimum baris pertama menjadi 100 poin.](row-height-increased.png) | ![Tabel setelah mengurangi minimum baris pertama menjadi 20 poin; teks terbungkus membuat baris lebih tinggi daripada minimum.](row-height-decreased.png) |

## **Tetapkan Baris Pertama sebagai Header**

Gunakan properti [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) untuk menandai baris pertama sebagai header. Penampilannya bergantung pada gaya tabel yang diterapkan pada tabel.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Akses slide pertama.
3. Akses tabel yang disimpan sebagai shape pertama pada slide.
4. Aktifkan pemformatan header untuk baris pertamanya.
5. Simpan presentasi yang telah diubah.

Contoh memerlukan `table.pptx` dengan tabel sebagai shape pertama pada slide pertama. Contoh mengaktifkan pemformatan header untuk baris pertama dan menyimpan `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Gandakan Baris atau Kolom Tabel**

Gandakan baris atau kolom untuk menggunakan kembali konten dan pemformatannya. Anda dapat menambahkan salinan ke akhir tabel atau menyisipkannya pada posisi tertentu.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Gandakan baris yang diperlukan.
6. Gandakan kolom yang diperlukan.
7. Simpan presentasi yang telah diubah.

Contoh memerlukan `Test.pptx` dengan setidaknya satu slide. Contoh membuat tabel dengan tiga kolom dan lima baris, dengan dimensi dalam poin. Contoh menambahkan salinan baris pertama dan kolom pertama, lalu menyisipkan salinan baris kedua dan kolom kedua pada indeks 3 (posisi keempat). Tabel yang dihasilkan memiliki tujuh baris dan lima kolom. Argumen `false` menonaktifkan penggandaan ke baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Hapus Baris atau Kolom dari Tabel**

Hapus baris atau kolom yang tidak lagi diperlukan dalam sebuah tabel. Menghapus sebuah item menggeser indeks baris atau kolom yang berada di belakangnya.

1. Buat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Hapus baris kedua dan kolom kedua.
6. Simpan presentasi yang telah diubah.

Contoh ini membuat tabel tiga‑dari‑tiga dan menghapus baris serta kolom pada indeks 1, menyisakan tabel dua‑dari‑dua dalam `TestTable_out.pptx`. Dimensi dalam poin. Argumen `false` menonaktifkan penghapusan baris atau kolom yang berdekatan yang digabung; tabel ini tidak memiliki sel yang digabung.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Terapkan Pemformatan Teks pada Tingkat Baris Tabel**

Terapkan pemformatan teks ke seluruh baris untuk menjaga konsistensi sel. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Atur [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) untuk baris pertama.
4. Atur [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) untuk baris pertama.
5. Atur [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) untuk baris kedua.
6. Simpan presentasi yang telah diubah.

Contoh memerlukan `table.pptx` dengan tabel sebagai shape pertama pada slide pertama dan setidaknya dua baris. Contoh menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada baris pertama, lalu mengatur teks vertikal pada baris kedua.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Terapkan Pemformatan Teks pada Tingkat Kolom Tabel**

Terapkan pemformatan teks ke seluruh kolom untuk menjaga konsistensi sel. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Akses tabel pada slide pertama.
3. Atur [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) untuk kolom pertama.
4. Atur [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) untuk kolom pertama.
5. Atur [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) untuk kolom kedua.
6. Simpan presentasi yang telah diubah.

Contoh memerlukan `table.pptx` dengan tabel sebagai shape pertama pada slide pertama dan setidaknya dua kolom. Contoh menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada kolom pertama, lalu mengatur teks vertikal pada kolom kedua.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Dapatkan Properti Gaya Tabel**

Gunakan properti [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) untuk mengambil preset yang diterapkan pada tabel dan menggunakannya kembali pada tabel lain. Ini mengidentifikasi preset daripada penimpaan pemformatan sel individu.

Contoh membuat tabel, menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), dan membaca kembali preset tersebut. Contoh mencetak `DarkStyle1` dan menyimpan tabel dalam `table.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isian, border, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data di memori terlebih dahulu, kemudian isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (berpola) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel tertentu dengan pemformatan lokal; pemformatan pada level sel memiliki prioritas lebih tinggi daripada gaya tabel.