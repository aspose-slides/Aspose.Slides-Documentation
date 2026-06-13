---
title: ดึงพื้นหลังของสไลด์ทั้งหมดจากงานนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์เต็มเป็นภาพจากงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อทำให้กระบวนการทำงานด้านภาพเป็นระเบียบและรวดเร็วขึ้น."
---
## **ภาพรวม**

ในงานนำเสนอ PowerPoint พื้นหลังของสไลด์อาจประกอบด้วยหลายองค์ประกอบรวมกัน ได้แก่ รูปภาพพื้นหลังของสไลด์ ธีมการนำเสนอ แผนสี และออบเจ็กต์ที่วางบนสไลด์มาสเตอร์หรือสไลด์เค้าโครง

บทความนี้แสดงวิธีดึงพื้นหลังของสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides for .NET เนื่องจากไม่มีเมธอดเดียวที่ทำงานนี้ วิธีการจะทำการโคลนสไลด์ที่เลือกไปยังงานนำเสนอชั่วคราว ลบรูปร่างจากสไลด์ที่โคลน แล้วแปลงพื้นหลังของสไลด์ที่ได้เป็นภาพ

## **รับพื้นหลังของสไลด์ทั้งหมด**

Aspose.Slides for Android via Java ไม่ได้ให้เมธอดง่าย ๆ เพื่อดึงพื้นหลังของสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนต่อไปนี้ได้:
1. โหลดการนำเสนอโดยใช้คลาส [การนำเสนอ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
1. รับขนาดสไลด์จากการนำเสนอ.
1. เลือกสไลด์.
1. สร้างการนำเสนอชั่วคราว.
1. กำหนดขนาดสไลด์เดียวกันในการนำเสนอชั่วคราว.
1. โคลนสไลด์ที่เลือกเข้าสู่การนำเสนอชั่วคราว.
1. ลบรูปร่างจากสไลด์ที่โคลน.
1. แปลงสไลด์ที่โคลนเป็นภาพ.

ตัวอย่างโค้ดต่อไปนี้ดึงพื้นหลังของสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**จะมีการรักษาเกรเดียนต์ซับซ้อน, เทกเจอร์, หรือการเติมรูปภาพจากสไลด์มาสเตอร์ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่. Aspose.Slides แสดงการเติมแบบเกรเดียนต์, รูปภาพ, และเทกเจอร์ที่กำหนดบนสไลด์, เค้าโครง, หรือมาสเตอร์. หากคุณต้องการแยกรูปลักษณ์จากมาสเตอร์ที่สืบทอด, [ตั้งค่าพื้นหลังของตนเอง](/slides/th/androidjava/presentation-background/) บนสไลด์ปัจจุบันก่อนส่งออก.

**ฉันสามารถใส่น้ำโลโก้ลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้ไหม?**

ใช่. คุณสามารถ [เพิ่มน้ำโลโก้](/slides/th/androidjava/watermark/) เป็นรูปทรงหรือภาพบน [สำเนาของสไลด์](/slides/th/androidjava/clone-slides/) ที่ทำงาน (วางไว้ด้านหลังเนื้อหาอื่น) แล้วจึงส่งออก. วิธีนี้ทำให้คุณสร้างภาพพื้นหลังที่มีน้ำโลโก้ฝังอยู่.

**ฉันสามารถรับพื้นหลังสำหรับเค้าโครงหรือมาสเตอร์เฉพาะโดยไม่ต้องผูกกับสไลด์ที่มีอยู่ได้หรือไม่?**

ใช่. เข้าถึงมาสเตอร์หรือเค้าโครงที่ต้องการ, นำไปใช้กับ [สไลด์ชั่วคราว](/slides/th/androidjava/clone-slides/) ที่มีขนาดที่จำเป็น, และส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเค้าโครงหรือมาสเตอร์นั้น.

**มีข้อจำกัดด้านใบอนุญาตที่ส่งผลต่อการส่งออกภาพหรือไม่?**

ฟีเจอร์การเรนเดอร์พร้อมใช้งานเต็มที่ด้วย [ใบอนุญาตที่ถูกต้อง](/slides/th/androidjava/licensing/). ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นน้ำโลโก้. เปิดใช้งานใบอนุญาตหนึ่งครั้งต่อกระบวนการก่อนทำการส่งออกแบบชุด.