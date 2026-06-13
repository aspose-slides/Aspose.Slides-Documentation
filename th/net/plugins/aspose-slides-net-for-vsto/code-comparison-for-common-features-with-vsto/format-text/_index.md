---
title: จัดรูปแบบข้อความ
type: docs
weight: 110
url: /th/net/format-text/
---
ทั้งวิธีการของ VSTO และ Aspose.Slides จะดำเนินการตามขั้นตอนต่อไปนี้:

- เปิดงานนำเสนอต้นฉบับ
- เข้าถึงสไลด์แรก
- เข้าถึงกล่องข้อความที่สาม
- เปลี่ยนการจัดรูปแบบของข้อความในกล่องข้อความที่สาม
- บันทึกงานนำเสนอลงดิสก์
## **VSTO**
``` csharp

 //เปิดงานนำเสนอ

Presentation pres = new Presentation("source.ppt");

//เพิ่มฟอนต์ Verdana

FontEntity font = pres.Fonts[0];

FontEntity verdanaFont = new FontEntity(pres, font);

verdanaFont.FontName = "Verdana";

int verdanaFontIndex = pres.Fonts.Add(verdanaFont);

//เข้าถึงสไลด์แรก

Slide slide = pres.GetSlideByPosition(1);

//เข้าถึงรูปร่างที่สาม

Shape shp = slide.Shapes[2];

//เปลี่ยนฟอนต์ของข้อความเป็น Verdana และความสูงเป็น 32

TextFrame tf = shp.TextFrame;

Paragraph para = tf.Paragraphs[0];

Portion port = para.Portions[0];

port.FontIndex = verdanaFontIndex;

port.FontHeight = 32;

//ทำให้เป็นตัวหนา

port.FontBold = true;

//ทำให้เป็นตัวเอียง

port.FontItalic = true;

//เปลี่ยนสีข้อความ

port.FontColor = Color.FromArgb(0x33, 0x33, 0xCC);

//เปลี่ยนสีพื้นหลังของรูปร่าง

shp.FillFormat.Type = FillType.Solid;

shp.FillFormat.ForeColor = Color.FromArgb(0xCC, 0xCC, 0xFF);

//เขียนผลลัพธ์ลงดิสก์

pres.Write("outAspose.ppt");

``` 
## **Aspose.Slides**
``` csharp

 PowerPoint.Presentation pres = null;

//เปิดงานนำเสนอ

pres = Globals.ThisAddIn.Application.Presentations.Open("source.ppt",

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoFalse,

	Microsoft.Office.Core.MsoTriState.msoTrue);

//เข้าถึงสไลด์แรก

PowerPoint.Slide slide = pres.Slides[1];

//เข้าถึงรูปร่างที่สาม

PowerPoint.Shape shp = slide.Shapes[3];

//เปลี่ยนฟอนต์ของข้อความเป็น Verdana และความสูงเป็น 32

PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;

txtRange.Font.Name = "Verdana";

txtRange.Font.Size = 32;

//ทำให้เป็นตัวหนา

txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//ทำให้เป็นตัวเอียง

txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//เปลี่ยนสีข้อความ

txtRange.Font.Color.RGB = 0x00CC3333;

//เปลี่ยนสีพื้นหลังของรูปร่าง

shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//ย้ายตำแหน่งแนวนอน

shp.Left -= 70;

//เขียนผลลัพธ์ลงดิสก์

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Format.Text.using.VSTO.and.Aspose.Slides.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Format%20Text%20using%20VSTO%20and%20Aspose.Slides/)