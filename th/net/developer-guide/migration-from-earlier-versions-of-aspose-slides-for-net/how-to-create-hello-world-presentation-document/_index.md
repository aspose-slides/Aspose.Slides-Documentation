---
title: วิธีสร้างการนำเสนอ Hello World ใน .NET
linktitle: การนำเสนอ Hello World
type: docs
weight: 10
url: /th/net/how-to-create-hello-world-presentation-document/
keywords:
- การย้าย
- สวัสดี โลก
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการรุ่นเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างการนำเสนอ PowerPoint PPT, PPTX และ ODP Hello World ใน .NET ด้วย Aspose.Slides โดยใช้ API รุ่นเก่าและรุ่นใหม่ในหนึ่งคู่มือที่ง่าย."
---
{{% alert color="primary" %}} 
ได้มีการเปิดตัว [Aspose.Slides for .NET API](/slides/th/net/) เวอร์ชันใหม่แล้วและตอนนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่เริ่มต้นและแก้ไขเอกสารที่มีอยู่
{{% /alert %}} 
## **การสนับสนุนโค้ดรุ่นเก่า**
เพื่อใช้โค้ดรุ่นเก่าที่พัฒนาด้วย Aspose.Slides for .NET รุ่นก่อนหน้า 13.x คุณต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเช่นเดิม คลาสทั้งหมดที่เคยอยู่ใน Aspose.Slides for .NET รุ่นเก่าภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ได้ถูกรวมเป็นเนมสเปซ Aspose.Slides เพียงเดียว โปรดดูตัวอย่างโค้ดง่าย ๆ ด้านล่างสำหรับการสร้างเอกสารการนำเสนอ Hello World ใน API Aspose.Slides รุ่นเก่าและทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **วิธีการใช้ Aspose.Slides for .NET รุ่นเก่า**
```c#
//สร้างออบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPT
//สร้างออบเจกต์ License
//ตั้งค่าลิขสิทธิ์ของ Aspose.Slides for .NET เพื่อหลีกเลี่ยงข้อจำกัดการประเมินผล
//เพิ่มสไลด์ว่างลงในงานนำเสนอและรับอ้างอิงของ
//สไลด์ว่างนั้น
//เพิ่มสี่เหลี่ยมผืนผ้า (X=2400, Y=1800, Width=1000 & Height=500) ลงในสไลด์
//ซ่อนเส้นของสี่เหลี่ยมผืนผ้า
//เพิ่ม TextFrame ลงในสี่เหลี่ยมผืนผ้าด้วยข้อความเริ่มต้น "Hello World"
//ลบสไลด์แรกของงานนำเสนอซึ่งโดยปกติจะถูกเพิ่มโดย
//Aspose.Slides for .NET เป็นค่าเริ่มต้นขณะสร้างงานนำเสนอ
//เขียนงานนำเสนอเป็นไฟล์ PPT
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```

## **วิธีการใช้ Aspose.Slides for .NET 13.x รุ่นใหม่**
```c#
// สร้าง Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```