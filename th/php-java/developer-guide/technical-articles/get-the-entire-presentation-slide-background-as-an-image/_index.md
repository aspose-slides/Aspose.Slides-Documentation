---
title: ดึงพื้นหลังสไลด์ทั้งหมดจากการนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์เต็มเป็นภาพจากการนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for PHP via Java เพื่อทำให้กระบวนการทำงานด้านภาพง่ายขึ้น"
---
## **ภาพรวม**

ในการนำเสนอ PowerPoint พื้นหลังสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงภาพพื้นหลังสไลด์, ธีมการนำเสนอ, โทนสี, และวัตถุต่าง ๆ ที่วางบนสไลด์มาสเตอร์หรือสไลด์เลเอาต์

บทความนี้แสดงวิธีดึงพื้นหลังสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides เนื่องจากไม่มีวิธีเดียวที่ทำได้ งานนี้จึงทำโดยการโคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว, ลบรูปร่างบนสไลด์ที่โคลน, แล้วแปลงพื้นหลังสไลด์ที่ได้เป็นภาพ

## **ดึงพื้นหลังสไลด์ทั้งหมด**

Aspose.Slides for PHP via Java ไม่ได้ให้วิธีง่าย ๆ ในการดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนต่อไปนี้ได้:
1. โหลดการนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับขนาดสไลด์จากการนำเสนอ
1. เลือกสไลด์หนึ่ง
1. สร้างการนำเสนอชั่วคราว
1. ตั้งค่าขนาดสไลด์เดียวกันในการนำเสนอชั่วคราว
1. โคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว
1. ลบรูปร่างจากสไลด์ที่โคลน
1. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้ดึงพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **คำถามที่พบบ่อย**

**การไล่สีที่ซับซ้อน, เนื้อผิว, หรือการเติมรูปภาพจากสไลด์มาสเตอร์จะถูกเก็บรักษาในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์การไล่สี, รูปภาพ, และการเติมเนื้อผิวที่กำหนดบนสไลด์, เลเอาต์, หรือมาสเตอร์ หากต้องการแยกลักษณะออกจากมาสเตอร์ที่สืบทอดมา ให้ [ตั้งค่าพื้นหลังของตัวเอง](/slides/th/php-java/presentation-background/) บนสไลด์ปัจจุบันก่อนทำการส่งออก

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกหรือไม่?**

ใช่ คุณสามารถ [เพิ่มลายน้ำ](/slides/th/php-java/watermark/) รูปแบบหรือภาพบน [สำเนาสไลด์ที่ทำงานอยู่](/slides/th/php-java/clone-slides/) (วางไว้ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก วิธีนี้จะทำให้คุณสร้างภาพพื้นหลังที่มีลายน้ำรวมอยู่ในตัว

**ฉันสามารถดึงพื้นหลังสำหรับเลเอาต์หรือมาสเตอร์เฉพาะได้โดยไม่ต้องเชื่อมกับสไลด์ที่มีอยู่หรือไม่?**

ใช่ ใหเข้าถึงมาสเตอร์หรือเลเอาต์ที่ต้องการ นำไปใช้กับ [สไลด์ชั่วคราว](/slides/th/php-java/clone-slides/) ที่มีขนาดที่ต้องการ แล้วส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่มาจากเลเอาต์หรือมาสเตอร์นั้น

**มีข้อจำกัดด้านใบอนุญาตที่ส่งผลต่อการส่งออกภาพหรือไม่?**

ฟีเจอร์การเรนเดอร์พร้อมใช้งานเต็มที่เมื่อมี [ใบอนุญาตที่ถูกต้อง](/slides/th/php-java/licensing/). ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นลายน้ำ เปิดใช้งานใบอนุญาตหนึ่งครั้งต่อกระบวนการก่อนทำการส่งออกแบบชุด