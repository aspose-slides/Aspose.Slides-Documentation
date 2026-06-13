---
title: ดึงพื้นหลังสไลด์ทั้งหมดจากงานนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- พื้นหลังสไลด์
- พื้นหลังขั้นสุดท้าย
- ดึงพื้นหลัง
- พื้นหลังทั้งหมด
- พื้นหลังเป็นภาพ
- พื้นหลัง PPT
- พื้นหลัง PPTX
- พื้นหลัง ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์เต็มรูปแบบเป็นภาพจากงานนำเสนอ PowerPoint และ OpenDocumentด้วย Aspose.Slides for Java เพื่อทำให้กระบวนการทำงานด้านภาพล้วนสะดวกขึ้น"
---
## **ภาพรวม**

ในการนำเสนอ PowerPoint พื้นหลังสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงรูปภาพพื้นหลังสไลด์ ธีมการนำเสนอ โทนสี และวัตถุที่วางบนสไลด์มาสเตอร์หรือสไลด์เลย์เอาต์

บทความนี้แสดงวิธีการดึงพื้นหลังสไลด์ทั้งหมดออกเป็นภาพโดยใช้ Aspose.Slides for .NET เนื่องจากไม่มีวิธีเดียวสำหรับงานนี้ วิธีการจึงรวมถึงการโคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว ลบรูปทรงของสไลด์ และจากนั้นแปลงพื้นหลังสไลด์ที่ได้เป็นภาพ

## **ดึงพื้นหลังสไลด์ทั้งหมด**

Aspose.Slides for Java ไม่ได้ให้วิธีง่ายในการดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนต่อไปนี้ได้:
1. โหลดการนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. รับขนาดสไลด์จากการนำเสนอ
1. เลือกสไลด์
1. สร้างการนำเสนอชั่วคราว
1. ตั้งค่าขนาดสไลด์เดียวกันในการนำเสนอชั่วคราว
1. โคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว
1. ลบรูปทรงจากสไลด์ที่โคลน
1. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้จะดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**การไล่สีซับซ้อน พื้นผิวเท็กซ์เจอร์ หรือการเติมรูปภาพจากสไลด์มาสเตอร์จะถูกเก็บรักษาไว้ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์การไล่สี การเติมรูปภาพและการเติมพื้นผิวที่กำหนดบนสไลด์ เลย์เอาต์ หรือมาสเตอร์ หากคุณต้องการแยกลักษณะจากมาสเตอร์ที่สืบทอด [ตั้งค่าพื้นหลังของคุณเอง](/slides/th/java/presentation-background/) บนสไลด์ปัจจุบันก่อนส่งออก

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้หรือไม่?**

ใช่ คุณสามารถ [เพิ่มลายน้ำ](/slides/th/java/watermark/) เป็นรูปทรงหรือภาพบน [สำเนาของสไลด์](/slides/th/java/clone-slides/) ที่ทำงานอยู่ (วางอยู่ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก วิธีนี้ทำให้คุณสร้างภาพพื้นหลังที่มีลายน้ำฝังอยู่

**ฉันสามารถรับพื้นหลังสำหรับเลย์เอาต์หรือมาสเตอร์เฉพาะโดยไม่ต้องเชื่อมกับสไลด์ที่มีอยู่ได้หรือไม่?**

ใช่ เข้าถึงมาสเตอร์หรือเลย์เอาต์ที่ต้องการ ใช้งานกับ [สไลด์ชั่วคราว](/slides/th/java/clone-slides/) ที่มีขนาดตามต้องการ แล้วส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเลย์เอาต์หรือมาสเตอร์นั้น

**มีข้อจำกัดด้านลิขสิทธิ์ที่ส่งผลต่อการส่งออกภาพหรือไม่?**

คุณสมบัติการเรนเดอร์พร้อมใช้งานเต็มรูปแบบเมื่อติดตั้ง [ลิขสิทธิ์ที่ถูกต้อง](/slides/th/java/licensing/). ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นลายน้ำ เปิดใช้งานลิขสิทธิ์หนึ่งครั้งต่อกระบวนการก่อนทำการส่งออกเป็นชุด