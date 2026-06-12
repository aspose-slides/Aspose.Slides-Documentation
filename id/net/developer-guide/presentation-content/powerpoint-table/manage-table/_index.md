---
title: Kelola Tabel Presentasi di .NET
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/net/manage-table/
keywords:
- menambah tabel
- membuat tabel
- mengakses tabel
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

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (disusun dalam baris dan kolom) bersifat jelas dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/net/aspose.slides/table/), antarmuka [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/), kelas [Cell](https://reference.aspose.com/slides/id/net/aspose.slides/cell/), antarmuka [ICell](https://reference.aspose.com/slides/id/net/aspose.slides/icell/) serta tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi. 

## **Buat Tabel dari Awal**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array `columnWidth`.
4. Tentukan array `rowHeight`.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addtable/).
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/id/net/aspose.slides/icell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) milik [ICell](https://reference.aspose.com/slides/id/net/aspose.slides/icell/). 
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Kode C# ini menunjukkan cara membuat tabel dalam sebuah presentasi:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();

// Mengakses slide pertama
ISlide sld = pres.Slides[0];

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Menambahkan shape tabel ke slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Mengatur format batas untuk setiap sel
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Menggabungkan sel 1 & 2 pada baris 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Menambahkan teks ke sel yang digabungkan
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Menyimpan presentasi ke Disk
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat sederhana dan berbasis nol. Sel pertama dalam tabel diindeks sebagai 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode C# ini menunjukkan cara menentukan penomoran untuk sel dalam sebuah tabel:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{

    // Mengakses slide pertama
    ISlide sld = pres.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan shape tabel ke slide
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

    // Menyimpan presentasi ke disk
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Akses Tabel yang Ada**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) dan atur menjadi null.
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) hingga tabel ditemukan.

   Jika Anda curiga slide yang Anda tangani hanya berisi satu tabel, Anda dapat memeriksa semua shape yang ada di dalamnya. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/net/aspose.slides/table/). Namun jika slide tersebut berisi beberapa tabel, sebaiknya cari tabel yang Anda butuhkan melalui properti [AlternativeText](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/alternativetext/).

5. Gunakan objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) untuk bekerja dengan tabel. Pada contoh di bawah, kami menambahkan baris baru ke tabel.
6. Simpan presentasi yang telah dimodifikasi.

Kode C# ini menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```c#
// Membuat instance kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Mengakses slide pertama
    ISlide sld = pres.Slides[0];

    // Menginisialisasi TableEx null
    ITable tbl = null;

    // Mengiterasi shape dan menetapkan referensi ke tabel yang ditemukan
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Menetapkan teks untuk kolom pertama baris kedua
    tbl[0, 1].TextFrame.Text = "New";

    // Menyimpan presentasi yang dimodifikasi ke disk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ratakan Teks dalam Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) ke slide. 
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) dari tabel. 
5. Akses [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) milik [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).
6. Ratakan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode C# ini menunjukkan cara meratakan teks dalam tabel:

```c#
// Membuat instance kelas Presentation
Presentation presentation = new Presentation();

// Mendapatkan slide pertama
ISlide slide = presentation.Slides[0];

// Mendefinisikan kolom dengan lebar dan baris dengan tinggi
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Menambahkan shape tabel ke slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Mengakses text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Membuat objek Paragraph untuk text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Membuat objek Portion untuk paragraf
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Meratakan teks secara vertikal
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Menyimpan presentasi ke disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) dari Slide.
4. Atur [FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontheight/) untuk teks. 
5. Atur [Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginright/). 
6. Atur [TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/textverticaltype/).
7. Simpan presentasi yang telah dimodifikasi. 

Kode C# ini menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```c#
// Membuat instance kelas Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Anggap bahwa shape pertama pada slide pertama adalah tabel

// Mengatur tinggi font sel tabel
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Mengatur perataan teks sel tabel dan margin kanan dalam satu pemanggilan
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Mengatur tipe vertikal teks sel tabel
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga detail tersebut dapat digunakan pada tabel lain atau di tempat lain. Kode C# ini menunjukkan cara mendapatkan properti gaya dari gaya tabel pra‑set:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ubah tema preset gaya default 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek sebuah bentuk geometris adalah perbandingan ukuran dalam dimensi yang berbeda. Aspose.Slides menyediakan properti `AspectRatioLocked` untuk memungkinkan Anda mengunci pengaturan rasio aspek pada tabel dan bentuk lainnya. 

Kode C# ini menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // balikkan

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel memiliki properti [RightToLeft](https://reference.aspose.com/slides/id/net/aspose.slides/table/righttoleft/), dan paragraf memiliki [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/id/net/aspose.slides/paragraphformat/righttoleft/). Menggunakan keduanya memastikan urutan RTL yang benar dan render yang tepat di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](/slides/id/net/applying-protection-to-presentation/) untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah penyisipan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).