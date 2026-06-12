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
- duplikasi baris
- duplikasi kolom
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
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan Aspose.Slides untuk .NET serta percepat penyuntingan presentasi dan pembaruan data."
---
## **Pengantar**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/net/aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) , dan banyak tipe lainnya. 

## **Set Baris Pertama sebagai Header**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi. 
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) dan setel ke null. 
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) untuk menemukan tabel yang relevan. 
5. Setel baris pertama tabel sebagai headernya. 

Kode C# ini menunjukkan cara menyetel baris pertama tabel sebagai headernya:

```c#
// Membuat instance kelas Presentation
Presentation pres = new Presentation("table.pptx");

// Mengakses slide pertama
ISlide sld = pres.Slides[0];

// Menginisialisasi TableEx null
ITable tbl = null;

// Melakukan iterasi pada shape-shape dan menyetel referensi ke tabel
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Menyetel baris pertama tabel sebagai headernya
tbl.FirstRow = true;

// Menyimpan presentasi ke disk
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Duplikat Baris atau Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addtable/). 
6. Duplikat baris tabel. 
7. Duplikat kolom tabel. 
8. Simpan presentasi yang telah dimodifikasi. 

Kode C# ini menunjukkan cara menggandakan baris atau kolom tabel PowerPoint:

```c#
 // Membuat instance kelas Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Mengakses slide pertama
    ISlide sld = presentation.Slides[0];

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Menambahkan shape tabel ke slide
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Menambahkan teks ke sel baris 1 kolom 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Menambahkan teks ke sel baris 1 kolom 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Menggandakan Baris 1 di akhir tabel
    table.Rows.AddClone(table.Rows[0], false);

    // Menambahkan teks ke sel baris 2 kolom 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Menambahkan teks ke sel baris 2 kolom 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Menggandakan Baris 2 sebagai baris ke-4 tabel
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Menggandakan kolom pertama di akhir
    table.Columns.AddClone(table.Columns[0], false);

    // Menggandakan kolom ke-2 di indeks kolom ke-4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Menyimpan presentasi ke disk 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Hapus Baris atau Kolom dari Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addtable/). 
6. Hapus baris tabel. 
7. Hapus kolom tabel. 
8. Simpan presentasi yang telah dimodifikasi. 

Kode C# ini menunjukkan cara menghapus baris atau kolom dari tabel:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) yang relevan dari slide. 
4. Setel [FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontheight/) sel baris pertama. 
5. Setel [Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginright/) sel baris pertama. 
6. Setel [TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/textverticaltype/) sel baris kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode C# ini mendemonstrasikan operasi tersebut.

```c#
// Membuat instance kelas Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Misalkan shape pertama pada slide pertama adalah tabel

// Mengatur tinggi font sel baris pertama
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Mengatur perataan teks dan margin kanan sel baris pertama
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Mengatur tipe vertikal teks sel baris kedua
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Menyimpan presentasi ke disk
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Atur Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/net/aspose.slides/itable/) yang relevan dari slide. 
4. Setel [FontHeight](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/fontheight/) sel kolom pertama. 
5. Setel [Alignment](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/alignment/) dan [MarginRight](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraphformat/marginright/) sel kolom pertama. 
6. Setel [TextVerticalType](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/textverticaltype/) sel kolom kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode C# ini mendemonstrasikan operasi tersebut: 

```c#
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Misalkan shape pertama pada slide pertama adalah tabel

// Mengatur tinggi font sel kolom pertama
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Mengatur perataan teks dan margin kanan sel kolom pertama dalam satu panggilan
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Mengatur tipe vertikal teks sel kolom kedua
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Menyimpan presentasi ke disk
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode C# ini menunjukkan cara mengambil properti gaya dari gaya tabel preset:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ubah tema preset gaya default
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isian, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, lalu isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel spesifik dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.