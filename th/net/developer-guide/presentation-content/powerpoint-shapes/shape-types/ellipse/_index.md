---
title: เพิ่มรูปวงรีลงในงานนำเสนอด้วย .NET
linktitle: วงรี
type: docs
weight: 30
url: /th/net/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่จัดรูปแบบ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้าง, จัดรูปแบบและจัดการรูปร่างวงรีใน Aspose.Slides สำหรับ .NET ในงานนำเสนอ PPT และ PPTX—รวมตัวอย่างโค้ด C#"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปร่างวงรีลงในสไลด์ PowerPoint ด้วยการใช้ Aspose.Slides. มันครอบคลุมการสร้างวงรีแบบง่าย, การสร้างวงรีที่มีการจัดรูปแบบ, และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX. นอกจากนี้ยังสัมผัสถึงคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี, การควบคุมลำดับการซ้อนกัน, และการใช้เอฟเฟกต์การเคลื่อนไหว.

## **สร้างวงรี**
เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ, โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ IShapes
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่างนี้ เราได้เพิ่มวงรีลงในสไลด์แรก

```c#
 // สร้างอินสแตนซ์ของคลาส Prseetation ที่แสดงถึง PPTX
 using (Presentation pres = new Presentation())
 {
 
     // รับสไลด์แรก
     ISlide sld = pres.Slides[0];
 
     // เพิ่ม AutoShape ประเภท Ellipse
     sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     //เขียนไฟล์ PPTX ไปยังดิสก์
     pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
 }
```

## **สร้างวงรีที่จัดรูปแบบ**
เพื่อเพิ่มวงรีที่จัดรูปแบบดีขึ้นลงในสไลด์, โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class.
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
1. เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ IShapes.
1. ตั้งค่า Fill Type ของวงรีเป็น Solid.
1. ตั้งค่าสีของวงรีโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้งานจากอ็อบเจกต์ FillFormat ที่เชื่อมโยงกับอ็อบเจกต์ IShape.
1. ตั้งค่าสีของเส้นของวงรี.
1. ตั้งค่าความกว้างของเส้นของวงรี.
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่างนี้ เราได้เพิ่มวงรีที่จัดรูปแบบลงในสไลด์แรกของการนำเสนอ

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
 using (Presentation pres = new Presentation())
 {
 
     // รับสไลด์แรก
     ISlide sld = pres.Slides[0];
 
     // เพิ่ม AutoShape ประเภท Ellipse
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // กำหนดการจัดรูปแบบบางอย่างให้กับรูปร่างวงรี
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // กำหนดการจัดรูปแบบบางอย่างให้กับเส้นของวงรี
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
 //เขียนไฟล์ PPTX ไปยังดิสก์
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าตำแหน่งและขนาดที่แน่นอนของวงรีสัมพันธ์กับหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดมักจะระบุเป็น **points**. เพื่อผลลัพธ์ที่คาดการณ์ได้, ให้อิงการคำนวณจากขนาดของสไลด์และแปลงมิลลิเมตรหรือ นิ้วที่ต้องการเป็น points ก่อนกำหนดค่า.

**ฉันจะวางวงรีเหนือหรือใต้วัตถุอื่น ๆ (ควบคุมลำดับการซ้อนกัน) ได้อย่างไร?**

ปรับลำดับการวาดของวัตถุโดยนำมันไปข้างหน้าหรือส่งไปด้านหลัง. วิธีนี้ทำให้วงรีซ้อนทับวัตถุอื่นหรือเปิดเผยวัตถุที่อยู่ด้านล่างได้.

**ฉันจะทำแอนิเมชันให้กับการปรากฏหรือการเน้นของวงรีได้อย่างไร?**

ใช้เอฟเฟกต์ [Apply](/slides/th/net/shape-animation/) การเข้าสู่, การเน้น, หรือการออกให้กับรูปร่าง, และกำหนดทริกเกอร์และเวลาเพื่อควบคุมว่าเมื่อใดและอย่างไรที่แอนิเมชันจะทำงาน.