---
title: Membuat Tabel Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Membuat Tabel
type: docs
weight: 50
url: /id/net/creating-a-table-on-powerpoint-slide/
keywords:
- membuat tabel
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasi dari otomatisasi Microsoft Office ke Aspose.Slides untuk .NET dan buat tabel dalam slide PowerPoint (PPT, PPTX) dengan C# dengan format yang fleksibel."
---
{{% alert color="primary" %}} 

Tabel banyak digunakan untuk menampilkan data pada slide presentasi. Artikel ini menunjukkan cara membuat tabel 15 x 15 dengan ukuran font 10 secara programatis menggunakan pertama [VSTO 2008](/slides/id/net/creating-a-table-on-powerpoint-slide/) dan kemudian [Aspose.Slides for .NET](/slides/id/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Membuat Tabel**
#### **Contoh VSTO 2008**
Langkah-langkah berikut menambahkan tabel ke slide Microsoft PowerPoint menggunakan VSTO:

1. Buat presentasi.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan tabel 15 x 15 ke slide.
1. Tambahkan teks ke setiap sel tabel dengan ukuran font 10.
1. Simpan presentasi ke disk.

```c#
//Buat presentasi
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Tambahkan slide kosong
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Tambahkan tabel 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Iterasi semua baris
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Iterasi semua sel dalam baris
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Dapatkan bingkai teks setiap sel
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Tambahkan teks
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Setel ukuran font teks menjadi 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Simpan presentasi ke disk
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Contoh Aspose.Slides for .NET**
Langkah-langkah berikut menambahkan tabel ke slide Microsoft PowerPoint menggunakan Aspose.Slides:

1. Buat presentasi.
1. Tambahkan tabel 15 x 15 ke slide pertama.
1. Tambahkan teks ke setiap sel tabel dengan ukuran font 10.
1. Tuliskan presentasi ke disk.

```c#
Presentation pres = new Presentation();

//Akses slide pertama
ISlide sld = pres.Slides[0];

//Tentukan kolom dengan lebar dan baris dengan tinggi
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Tambahkan tabel
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Setel format batas untuk setiap sel
foreach (IRow row in tbl.Rows)
{
		foreach (ICell cell in row)
		{

			//Dapatkan bingkai teks setiap sel
			ITextFrame tf = cell.TextFrame;
			//Tambahkan teks
			tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
			//Setel ukuran font menjadi 10
			tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
			tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
		}
}

//Tuliskan presentasi ke disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```