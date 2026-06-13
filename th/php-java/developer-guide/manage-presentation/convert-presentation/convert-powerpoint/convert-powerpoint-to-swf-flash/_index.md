---
title: แปลงพรีเซนเทชัน PowerPoint เป็น SWF Flash ใน PHP
linktitle: PowerPoint ไปเป็น SWF
type: docs
weight: 80
url: /th/php-java/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงพรีเซนเทชัน
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น SWF
- พรีเซนเทชันเป็น SWF
- สไลด์เป็น SWF
- PPT เป็น SWF
- PPTX เป็น SWF
- PowerPoint เป็น Flash
- พรีเซนเทชันเป็น Flash
- สไลด์เป็น Flash
- PPT เป็น Flash
- PPTX เป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT เป็น SWF
- ส่งออก PPTX เป็น SWF
- PowerPoint
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ใน PHP ด้วย Aspose.Slides. ตัวอย่างโค้ดขั้นตอนต่อขั้นตอน, ผลลัพธ์คุณภาพสูงเร็ว, ไม่ต้องใช้การทำงานอัตโนมัติของ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงไฟล์พรีเซนเทชัน PowerPoint เป็น SWF ด้วยการใช้ Aspose.Slides มันแสดงวิธีบันทึกพรีเซนเทชันเป็นไฟล์ SWF ด้วยเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/save/) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/), รวมถึงการตั้งค่าผู้ชมและการจัดวางบันทึกย่อหรือคอมเมนต์

## **แปลงพรีเซนเทชันเป็น Flash**

เมธอด [save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/save/) ที่เปิดให้ใช้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) สามารถใช้เพื่อแปลงพรีเซนเทชันทั้งหมดเป็นเอกสาร **SWF** ตัวอย่างต่อไปนี้แสดงวิธีแปลงพรีเซนเทชันเป็นเอกสาร **SWF** โดยใช้ตัวเลือกที่จัดให้โดยคลาส [SWFOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/) คุณยังสามารถรวมคอมเมนต์ใน SWF ที่สร้างขึ้นโดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) ได้เช่นกัน.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # กำลังบันทึกพรีเซนเทชัน
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่. เปิดสไลด์ที่ซ่อนอยู่โดยใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/setshowhiddenslides/) ใน [SwfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/) โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก.

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้เมธอด [setCompressed](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/setcompressed/) และ [adjust JPEG quality](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/setjpegquality/) เพื่อปรับสมดุลระหว่างขนาดไฟล์และความคมชัดของภาพ.

**'setViewerIncluded' มีไว้เพื่ออะไร และควรปิดใช้งานเมื่อไหร่?**

[setViewerIncluded](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/setviewerincluded/) เพิ่ม UI ตัวเล่นฝังตัว (ควบคุมการนำทาง, แผง, การค้นหา) ปิดใช้งานหากคุณต้องการใช้ตัวเล่นของคุณเองหรือจำเป็นต้องมีเฟรม SWF เปล่าโดยไม่มี UI.

**จะเกิดอะไรขึ้นหากฟอนต์ต้นทางหายไปบนเครื่องที่ทำการส่งออก?**

Aspose.Slides จะทำการแทนที่ฟอนต์ที่คุณระบุผ่าน [setDefaultRegularFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [SwfOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/swfoptions/) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองโดยไม่ตั้งใจ.