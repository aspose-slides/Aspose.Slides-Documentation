---
title: ดึงพื้นหลังสไลด์ทั้งหมดจากงานนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์ทั้งหมดเป็นภาพจากงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อปรับปรุงกระบวนการทำงานด้านภาพให้มีประสิทธิภาพ"
---
## **ภาพรวม**

ในงานนำเสนอ PowerPoint พื้นหลังของสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงภาพพื้นหลังของสไลด์ ธีมการนำเสนอ โครงการสี และวัตถุต่าง ๆ ที่วางบนสไลด์มาสเตอร์หรือสไลด์เลย์เอาต์

บทความนี้แสดงวิธีการดึงพื้นหลังของสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides เนื่องจากไม่มีวิธีเดียวสำหรับงานนี้ วิธีการจะทำการโคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว ลบรูปทรงของสไลด์ แล้วแปลงพื้นหลังของสไลด์ที่ได้เป็นภาพ

## **ดึงพื้นหลังของสไลด์ทั้งหมด**

Aspose.Slides for Node.js via Java ไม่ได้ให้วิธีง่าย ๆ สำหรับดึงพื้นหลังของสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนด้านล่างเพื่อทำได้:
1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับขนาดสไลด์จากงานนำเสนอ
3. เลือกสไลด์หนึ่ง
4. สร้างงานนำเสนอชั่วคราว
5. กำหนดขนาดสไลด์เดียวกันในงานนำเสนอชั่วคราว
6. โคลนสไลด์ที่เลือกไปยังงานนำเสนอชั่วคราว
7. ลบรูปทรงจากสไลด์ที่โคลน
8. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้ดึงพื้นหลังของสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**พื้นผิวไล่สีซับซ้อน, เทกซ์เจอร์, หรือการเติมภาพจากสไลด์มาสเตอร์จะถูกเก็บไว้ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์การไล่สี, การเติมภาพ, และเทกซ์เจอร์ที่กำหนดบนสไลด์, เลย์เอาต์ หรือมาสเตอร์ หากคุณต้องการแยกลักษณะจากมาสเตอร์ที่สืบทอดมา ให้[ตั้งค่าพื้นหลังของคุณเอง](/slides/th/nodejs-java/presentation-background/) บนสไลด์ปัจจุบันก่อนทำการส่งออก.

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้หรือไม่?**

ใช่ คุณสามารถ[เพิ่มลายน้ำ](/slides/th/nodejs-java/watermark/) รูปแบบหรือภาพบน[สำเนาของสไลด์](/slides/th/nodejs-java/clone-slides/)ที่ทำงาน (วางอยู่ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก วิธีนี้จะทำให้คุณสร้างภาพพื้นหลังที่มีลายน้ำฝังอยู่แล้ว.

**ฉันสามารถรับพื้นหลังสำหรับเลย์เอาต์หรือมาสเตอร์เฉพาะโดยไม่ต้องผูกกับสไลด์ที่มีอยู่ได้หรือไม่?**

ใช่ เข้าถึงมาสเตอร์หรือเลย์เอาต์ที่ต้องการ แล้วใช้กับ[สไลด์ชั่วคราว](/slides/th/nodejs-java/clone-slides/)ที่มีขนาดตามต้องการ จากนั้นส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเลย์เอาต์หรือมาสเตอร์นั้น.

**มีข้อจำกัดด้านการให้สิทธิ์ที่ส่งผลต่อการส่งออกภาพหรือไม่?**

ฟีเจอร์การเรนเดอร์พร้อมให้ใช้งานเต็มที่เมื่อมี[ใบอนุญาตที่ถูกต้อง](/slides/th/nodejs-java/licensing/) ในโหมดประเมินผล อาจมีข้อจำกัด เช่น ลายน้ำ ให้เปิดใช้งานใบอนุญาตหนึ่งครั้งต่อกระบวนการก่อนรันการส่งออกแบบแบตช์.