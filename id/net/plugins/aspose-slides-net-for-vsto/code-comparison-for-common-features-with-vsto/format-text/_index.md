---
title: Format Teks
type: docs
weight: 110
url: /id/net/format-text/
---
Baik metode VSTO maupun Aspose.Slides melakukan langkah-langkah berikut:

- Buka presentasi sumber.
- Akses slide pertama.
- Akses kotak teks ketiga.
- Ubah pemformatan teks pada kotak teks ketiga.
- Simpan presentasi ke disk.
## **VSTO**
``` csharp

 //Buka presentasi

Presentation pres = new Presentation("source.ppt");

//Tambahkan font Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//Akses slide pertama

Slide slide = pres.GetSlideByPosition(1);

//Akses shape ketiga

Shape shp = slide.Shapes[2];

//Ubah font teksnya menjadi Verdana dan tinggi menjadi 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//Tebalkan

port.FontBold = true;

//Miringkan

port.FontItalic = true;

//Ubah warna teks

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//Ubah warna latar belakang shape

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//Tuliskan keluaran ke disk

pres.Write("outAspose.ppt");

```
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//Buka presentasi

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//Akses slide pertama

PowerPoint.Slide slide = pres.Slides[1];

//Akses shape ketiga

PowerPoint.Shape shp = slide.Shapes[3];

//Ubah font teksnya menjadi Verdana dan tinggi menjadi 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//Tebalkan

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Miringkan

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Ubah warna teks

txtRange.Font.Color.RGB = 0x00CC3333;

//Ubah warna latar belakang shape

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Pindahkan posisi secara horizontal

shp.Left -= 70;

//Tuliskan keluaran ke disk

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

```
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)