---
title: Kelola Sel Tabel dalam Presentasi di .NET
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/net/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisahkan sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan mudah menggunakan Aspose.Slides untuk .NET. Kuasai cara mengakses, memodifikasi, dan menata sel secara cepat untuk otomatisasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Identifikasi Sel Tabel yang Digabung**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Ambil tabel dari slide pertama. 
3. Iterasi melalui baris dan kolom tabel untuk menemukan sel yang digabung.
4. Cetak pesan ketika sel yang digabung ditemukan.

Kode C# ini menunjukkan cara mengidentifikasi sel tabel yang digabung dalam sebuah presentasi:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // asumsi bahwa Slide#0.Shape#0 adalah sebuah tabel
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Hapus Batas Sel Tabel**
1. Buat sebuah instance dari kelas `Presentation`.
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode `AddTable`.
6. Iterasi melalui setiap sel untuk menghapus batas atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara menghapus batas dari sel tabel:

```c#
// Menginstansiasi kelas Presentation yang merepresentasikan file PPTX
using (Presentation pres = new Presentation())
{
   // Mengakses slide pertama
    Slide sld = (Slide)pres.Slides[0];

    // Menentukan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Menambahkan bentuk tabel ke slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Menulis file PPTX ke disk
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Penomoran pada Sel yang Digabung**
Jika kita menggabungkan 2 pasang sel (1, 1) x (2, 1) dan (1, 2) x (2, 2), tabel yang dihasilkan akan bernomor. Kode C# ini mendemonstrasikan prosesnya:

```c#
 // Menginstansiasi kelas Presentation yang merepresentasikan file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama
    ISlide sld = presentation.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Kemudian kami menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabung di tengahnya: 

```c#
 // Menginstansiasi kelas Presentation yang merepresentasikan file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama
    ISlide slide = presentation.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Menggabungkan sel (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Menggabungkan sel (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Menggabungkan sel (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Menulis file PPTX ke disk
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Penomoran pada Sel yang Dipisah**
Pada contoh sebelumnya, ketika sel tabel digabung, penomoran atau sistem angka pada sel lain tidak berubah. 

Kali ini, kami menggunakan tabel biasa (tabel tanpa sel yang digabung) dan kemudian mencoba memisahkan sel (1,1) untuk mendapatkan tabel khusus. Anda mungkin perlu memperhatikan penomoran tabel ini, yang mungkin terlihat aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama. 

Kode C# ini mendemonstrasikan proses yang kami jelaskan:

```c#
// Menginstansiasi kelas Presentation yang merepresentasikan file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama
    ISlide slide = presentation.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Menggabungkan sel (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Menggabungkan sel (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Memisahkan sel (1, 1).
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Menulis file PPTX ke disk
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Ubah Warna Latar Belakang Sel Tabel**

Kode C# ini menunjukkan cara mengubah warna latar belakang sel tabel:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // buat tabel baru
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // atur warna latar belakang untuk sebuah sel
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Tambah Gambar di Dalam Sel Tabel**

1. Buat sebuah instance dari kelas `Presentation`.
2. Dapatkan referensi slide melalui indeksnya.
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode `AddTable`. 
6. Buat objek `Bitmap` untuk menampung file gambar.
7. Tambahkan gambar bitmap ke objek `IPPImage`.
8. Set `FillFormat` untuk Sel Tabel menjadi `Picture`.
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang telah dimodifikasi sebagai file PPTX

Kode C# ini menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```c#
// Menginstansiasi kelas Presentation yang merepresentasikan file PPTX
using (Presentation presentation = new Presentation())
{
    // Mengakses slide pertama
    ISlide slide = presentation.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Menambahkan bentuk tabel ke slide
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Memuat gambar dari file dan menambahkannya ke sumber daya presentasi
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Menambahkan gambar ke sel tabel pertama
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Menulis file PPTX ke disk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/id/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/id/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/id/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/id/net/aspose.slides/cellformat/borderright/) memiliki properti terpisah, sehingga ketebalan dan gaya pada setiap sisi dapat berbeda. Hal ini secara logis mengikuti kontrol batas per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel baru; dengan tile, ubin‑ubin dihitung ulang. Artikel ini menyebutkan mode tampilan gambar dalam sebuah sel.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/net/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam kerangka teks sel atau pada tingkat seluruh tabel/benda. Pada praktiknya, Anda menetapkan tautan ke bagian tertentu atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Kerangka teks sel mendukung [portions](https://reference.aspose.com/slides/id/net/aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.