---
title: วิธีสร้างการนำเสนอ Hello World ใน .NET
linktitle: การนำเสนอ Hello World
type: docs
weight: 10
url: /th/net/how-to-create-hello-world-presentation-document/
keywords:
- การย้าย
- Hello World
- โค้ด legacy
- โค้ดสมัยใหม่
- วิธีการเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างการนำเสนอ PowerPoint PPT, PPTX และ ODP Hello World ใน .NET ด้วย Aspose.Slides โดยใช้ API แบบ legacy และ modern ในคู่มือแบบง่ายหนึ่งเล่ม."
---
{{% alert color="info" %}}

มีการเปิดตัว [Aspose.Slides for .NET API](/slides/th/net/) ใหม่แล้วและตอนนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่เริ่มต้นและแก้ไขเอกสารที่มีอยู่

{{% /alert %}}
## **การสนับสนุนโค้ด Legacy**
เพื่อใช้โค้ด legacy ที่พัฒนาด้วย Aspose.Slides for .NET รุ่นก่อนหน้า 13.x คุณต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเหมือนเดิม ทุกคลาสที่เคยอยู่ใน Aspose.Slides for .NET เก่า ภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ถูกรวมเป็นหนึ่งเนมสเปซ Aspose.Slides กรุณาดูตัวอย่างโค้ดง่ายต่อไปนี้สำหรับการสร้างเอกสารนำเสนอ Hello World ใน Aspose.Slides API รุ่น legacy และทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **แนวทาง Aspose.Slides for .NET รุ่น Legacy**
```c#
using System.Drawing;
using Aspose.Slides;

//สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์ PPT
Presentation pres = new Presentation();

//สร้างอ็อบเจกต์ License
License license = new License();

//ตั้งไลเซนส์ของ Aspose.Slides for .NET เพื่อหลีกเลี่ยงข้อจำกัดการประเมินผล
license.SetLicense("Aspose.Slides.lic");

//เพิ่มสไลด์เปล่าเข้าไปในการนำเสนอและรับอ้างอิงของ
//สไลด์เปล่านั้น
Slide slide = pres.AddEmptySlide();

//เพิ่มสี่เหลี่ยม (X=2400, Y=1800, Width=1000 & Height=500) ไปยังสไลด์
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//ซ่อนเส้นของสี่เหลี่ยม
rect.LineFormat.ShowLines = false;

//เพิ่มกรอบข้อความลงในสี่เหลี่ยมโดยใช้ "Hello World" เป็นข้อความเริ่มต้น
rect.AddTextFrame("Hello World");

//ลบสไลด์แรกของการนำเสนอที่โดยปกติจะถูกเพิ่มโดย
//Aspose.Slides for .NET โดยค่าเริ่มต้นขณะสร้างการนำเสนอ
pres.Slides.RemoveAt(0);

//เขียนการนำเสนอเป็นไฟล์ PPT
pres.Write("C:\\hello.ppt");
```

## **แนวทางใหม่ของ Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
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
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```