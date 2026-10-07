---
title: Kelola Sel Tabel dalam Presentasi di .NET
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/net/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus batas
- bagi sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di C#: identifikasi sel yang digabung, hapus batas, bagi sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah penggabungan atau pemisahan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari sebuah slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(column, row)`.

## **Mengidentifikasi Sel Tabel yang Digabung**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Diasumsikan bahwa slide dan bentuk ada serta bentuk tersebut adalah tabel. Kemudian iterasi melalui semua baris dan kolom dan menggunakan [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) untuk mengidentifikasi sel dalam wilayah yang digabung. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), dan koordinat awal wilayah, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) dan [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Menghapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur keempat batas sel menjadi [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), sehingga tidak terlihat.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Menggabungkan Sel Tabel**

Gunakan [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel di sudut kiri atas dan kanan bawah dari rentang tersebut. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang itu.

Contoh ini membuat tabel 4x4 dengan kolom dan baris berukuran 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara grid tabel tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau format sel yang digabung, gunakan posisi kiri atasnya: `table[1, 1]` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Membagi Sel Tabel**

Penggabungan sel pada contoh sebelumnya mempertahankan grid tabel. Membagi sebuah sel dapat memperkenalkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4x4 dengan kolom dan baris berukuran 70 poin dan memanggil [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) pada sel `(1, 1)`. Setengah lebar sel yang berukuran 70 poin digunakan untuk membuat dua sel dengan lebar sama.

Setelah pembagian ini, dua bagian dapat diakses sebagai `table[1, 1]` dan `table[2, 1]`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 pindah ke kolom 3 dan 4 masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pembagian.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Membagi Sel yang Digabung berdasarkan Rentang Baris atau Kolom**

Untuk menyiapkan sel templat yang digabung agar dapat diisi data, gunakan [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) untuk membagi sepanjang batas baris yang ada, atau [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) untuk membagi sepanjang batas kolom.

Argumen `index` menghitung baris di bagian atas atau kolom di bagian kiri dari pembagian; nilai ini relatif terhadap wilayah yang digabung:

- Pembagian baris: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Pembagian kolom: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Contoh ini mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Dimulai dari posisi bawah, ia menggunakan [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) dan [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) untuk menemukan asalnya dan memeriksa kedua rentang. `SplitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan horizontal dua kolom, gunakan `SplitByColSpan(1)` sebagai gantinya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Ambil sel yang dihasilkan dari tabel setelah pemisahan.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel yang dihasilkan berdasarkan koordinatnya; di sini, keduanya memiliki rentang 1 dan [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) menghasilkan `False`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pembagian.

Teks asli dan formatnya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi format sel seperti isian, batas, dan margin. Isi sel setelah pemisahan dan atur format teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan format sel templat tetap dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) untuk detail.

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom berukuran 150 poin dan baris berukuran 50 poin. Ia mengatur [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) menjadi solid dan [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) menjadi merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Menambahkan Gambar Di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Gambar dimuat dengan [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) dan ditambahkan ke koleksi gambar presentasi dengan [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Kemudian gambar tersebut diberikan ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dinyatakan dalam poin. Gambar yang dimuat dibuang secara otomatis oleh pernyataan `using`‑nya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) memiliki properti terpisah, sehingga ketebalan dan gaya tiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretching, gambar menyesuaikan dengan sel yang baru; dengan tiling, ubin‑ubin dihitung ulang.

**Apakah saya dapat menetapkan tautan hiper ke seluruh konten sebuah sel?**

[Hyperlinks](/slides/id/net/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam kerangka teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian tertentu atau ke semua teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Kerangka teks sel mendukung [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) dengan format independen—keluarga font, gaya, ukuran, dan warna.