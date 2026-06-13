---
title: จัดการ Header และ Footer ของการนำเสนอใน PHP
linktitle: Header และ Footer
type: docs
weight: 140
url: /th/php-java/presentation-header-and-footer/
keywords:
- หัวเรื่อง
- ข้อความหัวเรื่อง
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งค่า header
- ตั้งค่า footer
- เอกสารประกอบ
- บันทึกย่อ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้ Aspose.Slides for PHP via Java เพื่อเพิ่มและปรับแต่ง header และ footer ในการนำเสนอ PowerPoint และ OpenDocument เพื่อให้ได้ลักษณะที่เป็นมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการการตั้งค่า Header และ Footer ในการนำเสนอ PowerPoint ได้ Header และ Footer จะถูกจัดการในระดับ Master ของการนำเสนอ และ API มีเมธอดสำหรับตั้งค่าข้อความ Footer, เปลี่ยนการมองเห็นของ Footer, และอัปเดตข้อความ Header บนสไลด์ Master Notes

คุณยังสามารถจัดการ Header และ Footer สำหรับสไลด์ Handout และ Notes ได้ ซึ่งรวมถึงการเปลี่ยนการมองเห็นและข้อความของ placeholder Header, Footer, หมายเลขสไลด์, และ Date‑Time สำหรับ Notes Master, สไลด์ Notes ทั้งหมดที่เป็น Child, หรือสไลด์ Notes แยกเดี่ยว

## **จัดการ Header และ Footer ใ​นการนำเสนอ**

โน้ตของสไลด์บางสไลด์อาจถูกลบตามที่แสดงในตัวอย่างด้านล่าง:

```php
  # โหลดการนำเสนอ
  $pres = new Presentation("headerTest.pptx");
  try {
    # ตั้งค่า Footer
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # เข้าถึงและอัปเดต Header
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # บันทึกการนำเสนอ
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **จัดการ Header และ Footer บนสไลด์ Handout และ Notes**
Aspose.Slides for PHP via Java รองรับ Header และ Footer ในสไลด์ Handout และ Notes โปรดทำตามขั้นตอนด้านล่าง:

- โหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีวิดีโอ
- เปลี่ยนการตั้งค่า Header และ Footer สำหรับ notes master และสไลด์ notes ทั้งหมด
- ทำให้ placeholder Footer ของ master notes slide และ child ทั้งหมดแสดงผล
- ทำให้ placeholder Date and time ของ master notes slide และ child ทั้งหมดแสดงผล
- เปลี่ยนการตั้งค่า Header และ Footer สำหรับสไลด์ notes แรกเท่านั้น
- ทำให้ placeholder Header ของสไลด์ notes แสดงผล
- ตั้งค่าข้อความให้กับ placeholder Header ของสไลด์ notes
- ตั้งค่าข้อความให้กับ placeholder Date-time ของสไลด์ notes
- เขียนไฟล์การนำเสนอที่ถูกแก้ไข

ตัวอย่างโค้ด snippet ถูกให้ไว้ในตัวอย่างด้านล่าง

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # เปลี่ยนการตั้งค่า Header และ Footer สำหรับ notes master และสไลด์ notes ทั้งหมด
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// ทำให้ master notes slide และ placeholder Footer ของ child ทั้งหมดแสดงผล

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// ทำให้ master notes slide และ placeholder Header ของ child ทั้งหมดแสดงผล

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// ทำให้ master notes slide และ placeholder SlideNumber ของ child ทั้งหมดแสดงผล

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// ทำให้ master notes slide และ placeholder Date and time ของ child ทั้งหมดแสดงผล

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// ตั้งค่าข้อความให้กับ master notes slide และ placeholder Header ของ child ทั้งหมด

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// ตั้งค่าข้อความให้กับ master notes slide และ placeholder Footer ของ child ทั้งหมด

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// ตั้งค่าข้อความให้กับ master notes slide และ placeholder Date and time ของ child ทั้งหมด

    }
    # เปลี่ยนการตั้งค่า Header และ Footer สำหรับสไลด์ notes แรกเท่านั้น
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// ทำให้ placeholder Header ของ notes slide นี้แสดงผล

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// ทำให้ placeholder Footer ของ notes slide นี้แสดงผล

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// ทำให้ placeholder SlideNumber ของ notes slide นี้แสดงผล

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// ทำให้ placeholder Date-time ของ notes slide นี้แสดงผล

      $headerFooterManager->setHeaderText("New header text");// ตั้งค่าข้อความให้กับ placeholder Header ของ notes slide

      $headerFooterManager->setFooterText("New footer text");// ตั้งค่าข้อความให้กับ placeholder Footer ของ notes slide

      $headerFooterManager->setDateTimeText("New date and time text");// ตั้งค่าข้อความให้กับ placeholder Date-time ของ notes slide

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม "header" ให้กับสไลด์ปกติได้หรือไม่?**

ใน PowerPoint, "Header" มีเฉพาะใน Notes และ Handouts; บนสไลด์ปกติจะมีเฉพาะ Footer, Date/Time, และ Slide Number เท่านั้น ใน Aspose.Slides ข้อจำกัดนี้เหมือนกัน: Header มีได้เฉพาะใน Notes/Handout, ส่วนสไลด์ทั่วไปมี Footer/DateTime/SlideNumber

**ถ้าเลย์เอาต์ไม่มีพื้นที่ Footer—ฉันสามารถ "เปิด" การมองเห็นได้หรือไม่?**

ได้ครับ ตรวจสอบการมองเห็นผ่าน Header/Footer manager และเปิดใช้งานหากจำเป็น API เหล่านี้และเมธอดถูกออกแบบมาเพื่อรองรับกรณีที่ placeholder หายไปหรือถูกซ่อนอยู่

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่า [first slide number](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/setfirstslidenumber/) ของการนำเสนอ; หลังจากนั้นหมายเลขทั้งหมดจะถูกคำนวณใหม่ ตัวอย่างเช่น คุณสามารถเริ่มที่ 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่อง

**เกิดอะไรขึ้นกับ Header/Footer เมื่อส่งออกเป็น PDF/รูปภาพ/HTML?**

พวกมันจะถูกแสดงเป็นองค์ประกอบข้อความทั่วไปของการนำเสนอ นั่นหมายความหากองค์ประกอบแสดงผลบนสไลด์/หน้าจ Notes พวกมันก็จะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ