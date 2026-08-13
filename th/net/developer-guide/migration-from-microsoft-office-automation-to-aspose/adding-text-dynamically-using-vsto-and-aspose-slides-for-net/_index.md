---
title: การเพิ่มข้อความแบบไดนามิกโดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: การเพิ่มข้อความแบบไดนามิก
type: docs
weight: 20
url: /th/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- เพิ่มข้อความ
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ดูวิธีการย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และเพิ่มข้อความแบบไดนามิกในไฟล์ PowerPoint (PPT, PPTX) ด้วย C#."
---
{{% alert color="info" %}} 
งานทั่วไปที่นักพัฒนาต้องทำคือการเพิ่มข้อความลงในสไลด์แบบไดนามิก บทความนี้แสดงตัวอย่างโค้ดสำหรับการเพิ่มข้อความแบบไดนามิกโดยใช้ [VSTO](/slides/th/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) และ [Aspose.Slides for .NET](/slides/th/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).
{{% /alert %}} 
## **การเพิ่มข้อความแบบไดนามิก**
Both methods follow these steps:

1. สร้างการนำเสนอ.
1. เพิ่มสไลด์เปล่า.
1. เพิ่มกล่องข้อความ.
1. ตั้งค่าข้อความ.
1. บันทึกการนำเสนอ.
## **ตัวอย่างโค้ด VSTO**
The code snippets below results in a presentation with a plain slide and a string of text on it.

**การนำเสนอที่สร้างด้วย VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//หมายเหตุ: PowerPoint คือเนมสเปซที่ได้กำหนดไว้ข้างต้นเช่นนี้
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//สร้างการนำเสนอ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//รับเค้าโครงสไลด์เปล่า
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//เพิ่มสไลด์เปล่า
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//เพิ่มข้อความ
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//ตั้งค่าข้อความ
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//บันทึกผลลัพธ์ลงดิสก์
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


## **ตัวอย่าง Aspose.Slides for .NET**
The code snippets below use Aspose.Slides to create a presentation with a plain slide and a string of text on it.

**การนำเสนอที่สร้างด้วย Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//สร้างการนำเสนอ
Presentation pres = new Presentation();

//สไลด์เปล่าจะถูกเพิ่มโดยอัตโนมัติเมื่อคุณสร้าง
//การนำเสนอจากคอนสตรัคเตอร์เริ่มต้น
//ดังนั้นเราไม่จำเป็นต้องเพิ่มสไลด์เปล่าใด ๆ
ISlide sld = pres.Slides[1];

//เพิ่มกล่องข้อความ
//เพื่อเพิ่มมันเราจะเพิ่มสี่เหลี่ยมผืนผ้าก่อน
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//ซ่อนเส้นของมัน
shp.LineFormat.Style = LineStyle.NotDefined;

//จากนั้นเพิ่มกรอบข้อความภายใน
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//ตั้งค่าข้อความ
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//บันทึกผลลัพธ์ลงดิสก์
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```