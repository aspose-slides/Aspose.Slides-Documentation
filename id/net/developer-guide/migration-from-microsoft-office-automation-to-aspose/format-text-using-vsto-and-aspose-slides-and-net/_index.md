---
title: Memformat Teks Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Format Teks
type: docs
weight: 30
url: /id/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- memformat teks
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasikan dari otomasi Microsoft Office ke Aspose.Slides untuk .NET dan format teks dalam presentasi PowerPoint (PPT, PPTX) dengan kontrol yang tepat."
---
{{% alert color="primary" %}} 

Kadang-kadang, Anda perlu memformat teks pada slide secara programatis. Artikel ini menunjukkan cara membaca contoh presentasi dengan beberapa teks pada slide pertama menggunakan [VSTO](/slides/id/net/format-text-using-vsto-and-aspose-slides-and-net/) dan [Aspose.Slides for .NET](/slides/id/net/format-text-using-vsto-and-aspose-slides-and-net/). Kode tersebut memformat teks dalam kotak teks ketiga pada slide sehingga terlihat seperti teks pada kotak teks terakhir.

{{% /alert %}} 
## **Formatting Text**
Baik metode VSTO maupun Aspose.Slides melakukan langkah-langkah berikut:

1. Buka presentasi sumber.
1. Akses slide pertama.
1. Akses kotak teks ketiga.
1. Ubah pemformatan teks di kotak teks ketiga.
1. Simpan presentasi ke disk.

Screenshot di bawah ini menunjukkan slide contoh sebelum dan setelah eksekusi kode VSTO dan Aspose.Slides untuk .NET.

**The input presentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **VSTO Code Example**
Kode di bawah ini menunjukkan cara memformat ulang teks pada slide menggunakan VSTO.

**The text reformatted with VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//Catatan: PowerPoint adalah namespace yang telah didefinisikan di atas seperti ini
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Buka presentasi
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Akses slide pertama
PowerPoint.Slide slide = pres.Slides[1];

//Akses shape ketiga
PowerPoint.Shape shp = slide.Shapes[3];

//Ubah font teksnya menjadi Verdana dan ukuran menjadi 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Buat menjadi tebal
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Buat menjadi miring
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ubah warna teks
txtRange.Font.Color.RGB = 0x00CC3333;

//Ubah warna latar belakang shape
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Pindahkan posisinya secara horizontal
shp.Left -= 70;

//Tulis output ke disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **Aspose.Slides for .NET Example**
Untuk memformat teks dengan Aspose.Slides, tambahkan font sebelum memformat teks.

**The output presentation created with Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //Buka presentasi
Presentation pres = new Presentation("c:\\source.ppt");

//Akses slide pertama
ISlide slide = pres.Slides[0];

//Akses shape ketiga
IShape shp = slide.Shapes[2];

//Ubah font teksnya menjadi Verdana dan ukuran menjadi 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//Buat menjadi tebal
port.PortionFormat.FontBold = NullableBool.True;

//Buat menjadi miring
port.PortionFormat.FontItalic = NullableBool.True;

//Ubah warna teks
//Atur warna font
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//Ubah warna latar belakang shape
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Tulis output ke disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```