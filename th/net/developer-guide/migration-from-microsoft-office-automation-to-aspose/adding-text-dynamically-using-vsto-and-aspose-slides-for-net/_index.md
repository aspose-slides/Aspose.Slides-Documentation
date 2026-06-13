---
title: การเพิ่มข้อความแบบไดนามิกโดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: เพิ่มข้อความแบบไดนามิก
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
description: "ดูวิธีการย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และเพิ่มข้อความแบบไดนามิกลงในการนำเสนอ PowerPoint (PPT, PPTX) ด้วย C#."
---
{{% alert color="primary" %}} 

งานทั่วไปที่นักพัฒนามักต้องทำคือการเพิ่มข้อความลงในสไลด์แบบไดนามิก บทความนี้แสดงตัวอย่างโค้ดสำหรับการเพิ่มข้อความแบบไดนามิกโดยใช้ [VSTO](/slides/th/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) และ [Aspose.Slides for .NET](/slides/th/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **Adding Text Dynamically**
Both methods follow these steps:

1. สร้างพรีเซนเทชั่น
1. เพิ่มสไลด์เปล่า
1. เพิ่มกล่องข้อความ
1. ตั้งค่าข้อความบางส่วน
1. บันทึกพรีเซนเทชั่น
## **VSTO Code Example**
The code snippets below results in a presentation with a plain slide and a string of text on it.

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//หมายเหตุ: PowerPoint เป็นเนมสเปซที่ได้กำหนดไว้ข้างบนเช่นนี้
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//สร้างพรีเซนเทชั่น
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **Aspose.Slides for .NET Example**
The code snippets below use Aspose.Slides to create a presentation with a plain slide and a string of text on it.

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//สร้างพรีเซนเทชั่น
Presentation pres = new Presentation();

//Blank slide is added by default, when you create
//presentation from default constructor
//So, we don't need to add any blank slide
ISlide sld = pres.Slides[1];

//Add a textbox
//To add it, we will first add a rectangle
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//Hide its line
shp.LineFormat.Style = LineStyle.NotDefined;

//Then add a textframe inside it
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//Set a text
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```