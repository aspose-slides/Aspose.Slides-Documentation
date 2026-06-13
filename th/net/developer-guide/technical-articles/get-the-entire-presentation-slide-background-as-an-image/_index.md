---
title: รับพื้นหลังสไลด์ทั้งหมดจากการนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- พื้นหลังสไลด์
- พื้นหลังสุดท้าย
- ดึงพื้นหลัง
- พื้นหลังทั้งหมด
- พื้นหลังเป็นภาพ
- พื้นหลัง PPT
- พื้นหลัง PPTX
- พื้นหลัง ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์เต็มเป็นภาพจากการนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ .NET เพื่อทำให้กระบวนการทำงานด้านภาพเป็นระบบและรวดเร็วขึ้น"
---
## **ภาพรวม**

ในงานนำเสนอ PowerPoint พื้นหลังสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงภาพพื้นหลังสไลด์ ธีมการนำเสนอ โทนสี และวัตถุที่วางไว้บนสไลด์มาสเตอร์หรือสไลด์เลย์เอาต์

บทความนี้จะแสดงวิธีการดึงพื้นหลังสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides for .NET เนื่องจากไม่มีวิธีเดียวสำหรับงานนี้ วิธีการจึงรวมการโคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว, การลบรูปทรงของสไลด์, และจากนั้นแปลงพื้นหลังสไลด์ที่ได้เป็นภาพ

## **ดึงพื้นหลังสไลด์ทั้งหมด**

Aspose.Slides for .NET ไม่ได้มีวิธีง่าย ๆ ในการดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนด้านล่างเพื่อทำสิ่งนี้ได้:
1. โหลดการนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับขนาดสไลด์จากการนำเสนอ
1. เลือกสไลด์หนึ่ง
1. สร้างการนำเสนอชั่วคราว
1. ตั้งค่าขนาดสไลด์เดียวกันในการนำเสนอชั่วคราว
1. โคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว
1. ลบรูปทรงจากสไลด์ที่โคลน
1. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้จะแสดงการดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **คำถามที่พบบ่อย**

**การไล่สีที่ซับซ้อน, พื้นผิว, หรือการเติมรูปภาพจากสไลด์มาสเตอร์จะถูกเก็บไว้ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์การไล่สี, รูปภาพ, และพื้นผิวที่กำหนดบนสไลด์, เลย์เอาต์ หรือมาสเตอร์ หากคุณต้องการแยกลักษณะจากมาสเตอร์ที่สืบทอด, ให้ [set an own background](/slides/th/net/presentation-background/) บนสไลด์ปัจจุบันก่อนทำการส่งออก

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้หรือไม่?**

ใช่ คุณสามารถ [add a watermark](/slides/th/net/watermark/) รูปร่างหรือภาพบน [copy of the slide](/slides/th/net/clone-slides/) ที่ทำงานอยู่ (วางไว้ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก สิ่งนี้ทำให้คุณสร้างภาพพื้นหลังที่มีลายน้ำฝังอยู่

**ฉันสามารถดึงพื้นหลังของเลย์เอาต์หรือมาสเตอร์เฉพาะโดยไม่ต้องเชื่อมต่อกับสไลด์ที่มีอยู่ได้หรือไม่?**

ใช่ เข้าถึงมาสเตอร์หรือเลย์เอาต์ที่ต้องการ, นำไปใช้กับ [temporary slide](/slides/th/net/clone-slides/) ที่มีขนาดตามที่ต้องการ, แล้วส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเลย์เอาต์หรือมาสเตอร์นั้น

**มีข้อจำกัดด้านลิขสิทธิ์ที่ส่งผลต่อการส่งออกภาพหรือไม่?**

คุณลักษณะการเรนเดอร์พร้อมใช้งานเต็มรูปแบบเมื่อมี [valid license](/slides/th/net/licensing/). ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นลายน้ำ เปิดใช้งานลิขสิทธิ์หนึ่งครั้งต่อขั้นตอนก่อนทำการส่งออกเป็นชุด