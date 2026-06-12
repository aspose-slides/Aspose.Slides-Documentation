---
title: Menambahkan Teks Secara Dinamis Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Menambahkan Teks Secara Dinamis
type: docs
weight: 20
url: /id/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- menambahkan teks
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Lihat cara memigrasikan dari otomatisasi Microsoft Office ke Aspose.Slides untuk .NET dan menambahkan teks dinamis ke presentasi PowerPoint (PPT, PPTX) dalam C#."
---
{{% alert color="primary" %}} 

Tugas umum yang harus dilakukan pengembang adalah menambahkan teks ke slide secara dinamis. Artikel ini menunjukkan contoh kode untuk menambahkan teks secara dinamis menggunakan [VSTO](/slides/id/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) dan [Aspose.Slides for .NET](/slides/id/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Kedua metode mengikuti langkah‑langkah berikut:

1. Buat presentasi.
1. Tambahkan slide kosong.
1. Tambahkan kotak teks.
1. Atur teks.
1. Simpan presentasi.
## **VSTO Code Example**
Cuplikan kode di bawah menghasilkan presentasi dengan slide polos dan satu baris teks di atasnya.

**Presentasi yang dibuat di VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//Catatan: PowerPoint adalah namespace yang telah didefinisikan di atas seperti ini
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Buat presentasi
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Dapatkan tata letak slide kosong
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Tambahkan slide kosong
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Tambahkan teks
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Atur teks
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Simpan output ke disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides for .NET Example**
Cuplikan kode di bawah menggunakan Aspose.Slides untuk membuat presentasi dengan slide polos dan satu baris teks di atasnya.

**Presentasi yang dibuat menggunakan Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//Buat presentasi
Presentation pres = new Presentation();

//Slide kosong ditambahkan secara default, ketika Anda membuat
//presentasi dari konstruktor default
//Jadi, kita tidak perlu menambahkan slide kosong apa pun
ISlide sld = pres.Slides[1];

//Tambahkan kotak teks
//Untuk menambahkannya, kita akan terlebih dahulu menambahkan persegi panjang
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Sembunyikan garisnya
shp.LineFormat.Style = LineStyle.NotDefined;

//Kemudian tambahkan bingkai teks di dalamnya
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Atur teks
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Tulis output ke disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```