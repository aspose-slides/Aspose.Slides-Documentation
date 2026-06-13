---
title: การจัดรูปแบบข้อความโดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: จัดรูปแบบข้อความ
type: docs
weight: 30
url: /th/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- จัดรูปแบบข้อความ
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และจัดรูปแบบข้อความในงานนำเสนอ PowerPoint (PPT, PPTX) ด้วยการควบคุมที่แม่นยำ."
---
{{% alert color="primary" %}} 

บางครั้งคุณอาจต้องจัดรูปแบบข้อความบนสไลด์โดยใช้โปรแกรม การแสดงนี้จะแสดงวิธีการอ่านงานนำเสนอแบบตัวอย่างพร้อมข้อความบนสไลด์แรกโดยใช้ทั้ง [VSTO](/slides/th/net/format-text-using-vsto-and-aspose-slides-and-net/) และ [Aspose.Slides for .NET](/slides/th/net/format-text-using-vsto-and-aspose-slides-and-net/) โค้ดจะจัดรูปแบบข้อความในกล่องข้อความที่สามบนสไลด์ให้คล้ายกับข้อความในกล่องข้อความสุดท้าย

{{% /alert %}} 
## **การจัดรูปแบบข้อความ**
ทั้งวิธีการของ VSTO และ Aspose.Slides จะทำตามขั้นตอนต่อไปนี้:

1. เปิดงานนำเสนอแหล่งที่มา
1. เข้าไปที่สไลด์แรก
1. เข้าไปที่กล่องข้อความที่สาม
1. เปลี่ยนการจัดรูปแบบของข้อความในกล่องข้อความที่สาม
1. บันทึกงานนำเสนอลงดิสก์

ภาพหน้าจอด้านล่างแสดงสไลด์ตัวอย่างก่อนและหลังการทำงานของโค้ด VSTO และ Aspose.Slides for .NET

**งานนำเสนออินพุต** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **ตัวอย่างโค้ด VSTO**
โค้ดด้านล่างแสดงวิธีการจัดรูปแบบข้อความใหม่บนสไลด์โดยใช้ VSTO

**ข้อความที่จัดรูปแบบใหม่ด้วย VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//หมายเหตุ: PowerPoint เป็นเนมสเปซที่ได้กำหนดไว้ข้างบนแบบนี้
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//Open the presentation
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//Access the first slide
PowerPoint.Slide slide = pres.Slides[1];

//Access the third shape
PowerPoint.Shape shp = slide.Shapes[3];

//Change its text's font to Verdana and height to 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//Bolden it
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Italicize it
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//Change text color
txtRange.Font.Color.RGB = 0x00CC3333;

//Change shape background color
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//Reposition it horizontally
shp.Left -= 70;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **ตัวอย่าง Aspose.Slides for .NET**
ในการจัดรูปแบบข้อความด้วย Aspose.Slides ให้เพิ่มฟอนต์ก่อนทำการจัดรูปแบบข้อความ

**งานนำเสนอผลลัพธ์ที่สร้างด้วย Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //เปิดงานนำเสนอ
Presentation pres = new Presentation("c:\\source.ppt");

//เข้าถึงสไลด์แรก
ISlide slide = pres.Slides[0];

//เข้าถึงรูปร่างที่สาม
IShape shp = slide.Shapes[2];

//เปลี่ยนฟอนต์ของข้อความเป็น Verdana และขนาดเป็น 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//ทำให้เป็นตัวหนา
port.PortionFormat.FontBold = NullableBool.True;

//ทำให้เป็นตัวเอียง
port.PortionFormat.FontItalic = NullableBool.True;

//เปลี่ยนสีข้อความ
//ตั้งค่าสีฟอนต์
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//เปลี่ยนสีพื้นหลังของรูปร่าง
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//บันทึกผลลัพธ์ลงดิสก์
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```