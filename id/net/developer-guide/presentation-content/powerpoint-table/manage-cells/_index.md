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
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di C#: identifikasi sel yang digabungkan, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah penggabungan atau pemisahan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(kolom, baris)`.

## **Identifikasi Sel Tabel yang Digabungkan**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Asumsinya slide dan bentuk tersebut ada serta bentuknya berupa tabel. Kemudian contoh ini mengiterasi semua baris dan kolom serta menggunakan [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) untuk mengidentifikasi sel dalam wilayah yang digabungkan. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), dan koordinat awal wilayah, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) dan [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Hapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan tambahkan tabel ke slide pertama dengan [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur keempat batas sel menjadi [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), sehingga tidak terlihat.

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

## **Tambah Batas Sel Diagonal**

Gunakan [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) untuk menggambar garis dari sudut kiri atas ke sudut kanan bawah, dan [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) untuk menggambar garis dari sudut kiri bawah ke sudut kanan atas. Sebuah diagonal dapat menandai header sudut; kedua diagonal dapat membentuk X untuk menandai sel tidak berlaku.

Masing‑masing diagonal adalah [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). Dalam [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), atur [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) ke [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) dan pilih [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Atur [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) garis dalam poin.

Contoh ini membuat tiga sel dalam satu baris: diagonal merah menurun, diagonal biru naik, dan kedua diagonal. Batas atas, bawah, kiri, kanan sel dibiarkan tidak berubah.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

A diagonal adalah properti pemformatan, bukan pemisahan sel. Setiap sel mempertahankan satu [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); wilayah di kedua sisi diagonal tidak dapat diedit secara independen.

tabel yang disimpan, dirender di Microsoft PowerPoint:

![Tiga sel tabel yang menampilkan diagonal merah dari kiri atas ke kanan bawah, diagonal biru dari kiri bawah ke kanan atas, dan kedua diagonal membentuk X.](diagonal-cell-borders.png)

*Kiri ke kanan: diagonal menurun (merah, 3 pt), diagonal naik (biru, 5 pt), dan kedua diagonal.*

## **Gabungkan Sel Tabel**

Gunakan [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel pada sudut kiri atas dan kanan bawah rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh ini membuat tabel 4x4 dengan kolom dan baris 70 poin, lalu menggabungkan empat sel tengah dari `(1, 1)` sampai `(2, 2)`. Sel hasil menguasai dua kolom dan dua baris, sementara kisi tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau format sel yang digabungkan, gunakan posisi kiri atasnya: `table[1, 1]` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari kisi tabel, sehingga indeks sel di luar rentang tidak berubah.

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

## **Pisahkan Sel Tabel**

Menggabungkan sel dalam contoh sebelumnya mempertahankan kisi tabel. Memisahkan sel dapat menambahkan kolom kisi baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model kisi tabel PowerPoint.

Contoh ini membuat tabel 4x4 dengan kolom dan baris 70 poin dan memanggil [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, dua bagian dapat diakses sebagai `table[1, 1]` dan `table[2, 1]`. Kisi tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pemisahan.

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

### **Pisahkan Sel yang Digabungkan berdasarkan Baris atau Kolom**

Untuk menyiapkan sel templat yang digabungkan untuk pengisian data, gunakan [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) untuk memisahkan sepanjang batas baris yang ada, atau [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris di bagian atas atau kolom di bagian kiri pemisahan; itu relatif terhadap wilayah yang digabungkan:

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Contoh mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabungkan secara vertikal. Mulai dari posisi bawah, ia menggunakan [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) dan [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) untuk menemukan asal dan memeriksa kedua rentang. `SplitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom horizontal, gunakan `SplitByColSpan(1)` sebagai gantinya.

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

    // Ambil sel hasil dari tabel setelah pemisahan.
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

Kisi tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel hasil dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) mencetak `False`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pemisahan.

Teks asli dan formatnya tetap di sel atas (atau kiri); sel baru kosong tetapi mewarisi format sel seperti isi, batas, dan margin. Isi sel setelah pemisahan dan atur format teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel "Product A" dan "Product B" terpisah dengan format sel templat yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) untuk detail.

<!-- visual-explanation:manage-cells:start -->
[![Sel yang digabungkan pada kolom 1, baris 2 dan 3 terpisah menjadi Product A dan Product B dengan indeks kisi yang sama.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Pemecahan baris-spans menggunakan batas yang ada. Product A dan Product B menempati (1, 2) dan (1, 3), masing‑masing.*
<!-- visual-explanation:manage-cells:end -->

### **Pisahkan Sel pada Tinggi Tertentu**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) menerima tinggi bagian atas dalam poin. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) menerima jumlah baris kisi yang ada di bagian atas. Untuk menempatkan sel 40 poin di tengah kolom kanan, kurangi 40 dari tinggi sebenarnya sel dan bagi sisa ruang secara merata di atas dan di bawahnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Pemisahan pertama menambahkan baris kisi, meninggalkan 90 poin di bagian bawah pada `[1, 1]`. Pemisahan kedua menargetkan sel itu dan menambahkan baris lagi di bawahnya. Kolom kanan kini berisi `[1, 0]` pada 50 poin (`margin`), `[1, 1]` pada 40 poin, dan `[1, 2]` pada 50 poin (`margin`). Sel kiri mencakup ketiga baris dengan tinggi asli 140 poin.

![Sel kiri mencakup seluruh tinggi tabel di samping tiga sel dengan Middle di tengah.](split-by-height.png)

## **Ubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia mengatur [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) ke solid dan [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) ke merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

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

## **Tambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar masukan di direktori kerja sebelum menjalankan contoh ini. Itu memuat gambar dengan [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) dan menambahkannya ke koleksi gambar presentasi dengan [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Kemudian gambar tersebut diberikan ke isian gambar (picture fill) sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang secara otomatis oleh deklarasi using‑nya.

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

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk masing‑masing sisi sel tunggal?**

Ya. Batas [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Dengan memperluas, gambar menyesuaikan dengan sel baru; dengan menempel, ubin‑ubin dihitung ulang.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/net/manage-hyperlinks/) ditetapkan pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.