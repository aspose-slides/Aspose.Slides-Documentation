---
title: Kelola Tabel Presentasi di .NET
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/net/manage-table/
keywords:
- tambah tabel
- buat tabel
- akses tabel
- rasio aspek
- rata teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk .NET. Temukan contoh kode C# sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint menyusun informasi ke dalam baris dan kolom, sehingga lebih mudah dibaca dan membandingkan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , kelas [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , antarmuka [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) , dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Buat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan menyisipkan teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan array lebar kolom dalam poin.
4. Tentukan array tinggi baris dalam poin.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) .
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabung melalui properti [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) .
9. Atur teks dalam sel yang digabung.
10. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada (100, 50) poin. Ia menerapkan batas merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel dimulai dari nol dan menggunakan urutan (kolom, baris). Sel pertama diindeks sebagai (0, 0).

Sebagai contoh, sel-sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang ditunjukkan di atas, dengan lebar kolom dan tinggi baris masing-masing 70 poin serta batas sel merah dengan lebar 5 poin. Koordinat menggambarkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Akses Tabel yang Ada**

Tabel disimpan dalam koleksi shape slide. Iterasi melalui shape untuk menemukan tabel, kemudian gunakan antarmuka [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) untuk membaca atau memperbarui sel-selnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi melalui objek [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) dan berhenti ketika tabel ditemukan. Jika slide berisi beberapa tabel, gunakan [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) untuk mengidentifikasi yang Anda butuhkan.
4. Perbarui teks dalam sel target.
5. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia mengatur sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi sebenarnya dapat melebihi minimum yang diminta, lihat [Kontrol Tinggi Baris](/slides/id/net/manage-rows-and-columns/#control-row-height).

## **Temukan Sel yang Memiliki Frame Teks**

Ketika kode pemrosesan teks umum menerima sebuah [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) dari tabel, gunakan properti [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) untuk mengambil [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) pemiliknya. Untuk frame teks sel tabel, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) diatur dan [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) bernilai `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui properti baca-saja [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) dan [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) juga baca-saja: ia menyediakan navigasi ke pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan bernilai `null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/net/search-and-replace-text/).

## **Ratakan Teks dalam Tabel**

Anda dapat mengontrol penambatan vertikal dan arah teks dari masing-masing sel tabel. Contoh dalam bagian ini menengahkan teks dalam sel pertama dan memutar teks sebesar 270 derajat.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ke slide.
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) dari tabel.
5. Akses [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) pertama dan atur teks serta warnanya.
6. Atur [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) dan [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) sel.
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks dalam sel (0, 0), menambahkan nilai ke sel-sel lainnya di baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Tabel**

Gunakan [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) untuk menerapkan pemformatan teks ke semua sel dalam tabel. Overload-nya menerima pemformatan bagian, paragraf, dan frame teks, sehingga Anda dapat mengatur properti tersebut tanpa iterasi melalui setiap sel.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) dari slide.
4. Atur [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) untuk teks.
5. Atur [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) .
6. Atur [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan paragraf ke kanan dengan margin kanan 20 poin, dan membuat teks menjadi vertikal. Presentasi yang diformat disimpan sebagai `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Dapatkan Properti Gaya Tabel**

Gunakan [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) untuk membaca atau menetapkan gaya preset tabel. Contoh ini menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) ke satu tabel, mencetak nama preset, dan menetapkan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

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

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan antara lebar dan tingginya. Gunakan [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) untuk mengunci rasio ini pada tabel.

Contoh di bawah ini membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`True`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca right-to-left (RTL) untuk seluruh tabel dan teks di sel-selnya?**

Ya. Tabel menyediakan properti [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) , dan paragraf memiliki [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) . Menggunakan keduanya memastikan urutan RTL yang benar dan render yang tepat di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel di file akhir?**

Gunakan [kunci shape](/slides/id/net/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) untuk sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).