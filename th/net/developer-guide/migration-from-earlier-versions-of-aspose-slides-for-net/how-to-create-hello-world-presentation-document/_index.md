---
title: วิธีสร้างงานนำเสนอ Hello World ใน .NET
linktitle: งานนำเสนอ Hello World
type: docs
weight: 10
url: /th/net/how-to-create-hello-world-presentation-document/
keywords:
- การย้าย
- Hello World
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการแบบรุ่นเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
- description: "สร้างงานนำเสนอ PowerPoint PPT, PPTX และ ODP Hello World ใน .NET ด้วย Aspose.Slides โดยใช้ทั้ง API รุ่นเก่าและสมัยใหม่ในคู่มือแบบง่ายหนึ่งเล่ม."
---
{{% alert color="info" %}} 
มีการเปิดตัว [Aspose.Slides for .NET API](/slides/th/net/) รุ่นใหม่ และขณะนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่เริ่มต้นและแก้ไขเอกสารที่มีอยู่แล้ว
{{% /alert %}} 
## **Support for Legacy Code**
เพื่อใช้โค้ดรุ่นเก่าที่พัฒนาด้วย Aspose.Slides for .NET เวอร์ชันก่อนหน้า 13.x คุณต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเช่นเดิม คลาสทั้งหมดที่เคยอยู่ใน Aspose.Slides for .NET รุ่นเก่าภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ถูกรวมเข้าในเนมสเปซ Aspose.Slides เดียวกัน โปรดดูตัวอย่างโค้ดง่าย ๆ ด้านล่างสำหรับการสร้างเอกสารนำเสนอ Hello World ใน Aspose.Slides API รุ่นเก่า และทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **Legacy Aspose.Slides for .NET Approach**
```c#
using System.Drawing;
using Aspose.Slides;

//สร้างวัตถุ Presentation ที่แทนไฟล์ PPT
Presentation pres = new Presentation();

//สร้างวัตถุ License
License license = new License();

//กำหนดไลเซนส์ของ Aspose.Slides for .NET เพื่อหลีกเลี่ยงข้อจำกัดของการประเมินผล
license.SetLicense("Aspose.Slides.lic");

//เพิ่มสไลด์ว่างลงในงานนำเสนอและรับอ้างอิงของ
//สไลด์ว่างนั้น
Slide slide = pres.AddEmptySlide();

//เพิ่มสี่เหลี่ยม (X=2400, Y=1800, Width=1000 & Height=500) ลงในสไลด์
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//ซ่อนเส้นของสี่เหลี่ยม
rect.LineFormat.ShowLines = false;

//เพิ่มกรอบข้อความลงในสี่เหลี่ยมโดยใช้ "Hello World" เป็นข้อความเริ่มต้น
rect.AddTextFrame("Hello World");

//ลบสไลด์แรกของงานนำเสนอซึ่งโดยปกติจะถูกเพิ่มโดย
//Aspose.Slides for .NET โดยค่าเริ่มต้นเมื่อสร้างงานนำเสนอ
pres.Slides.RemoveAt(0);

//บันทึกงานนำเสนอเป็นไฟล์ PPT
pres.Write("C:\\hello.ppt");
```



## **New Aspose.Slides for .NET 13.x Approach**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างวัตถุ Presentation
Presentation pres = new Presentation();

// ดึงสไลด์แรก
ISlide sld = (ISlide)pres.Slides[0];

// เพิ่ม AutoShape ประเภท Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// เพิ่ม ITextFrame ไปยัง Rectangle
ashp.AddTextFrame("Hello World");

// เปลี่ยนสีข้อความเป็นสีดำ (ซึ่งโดยค่าเริ่มต้นคือสีขาว)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// เปลี่ยนสีเส้นของ rectangle เป็นสีขาว
ashp.ShapeStyle.LineColor.Color = Color.White;

// ลบการจัดรูปแบบการเติมสีใดๆ ในรูปร่าง
ashp.FillFormat.FillType = FillType.NoFill;

// บันทึกงานนำเสนอลงดิสก์
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```