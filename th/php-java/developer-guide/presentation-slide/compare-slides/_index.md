---
title: เปรียบเทียบสไลด์การนำเสนอใน PHP
linktitle: เปรียบเทียบสไลด์
type: docs
weight: 50
url: /th/php-java/compare-slides/
keywords:
- เปรียบเทียบสไลด์
- การเปรียบเทียบสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เปรียบเทียบการนำเสนอ PowerPoint และ OpenDocument อย่างเป็นโปรแกรมด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ระบุความแตกต่างของสไลด์ในโค้ดอย่างรวดเร็ว."
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณเปรียบเทียบสไลด์, สไลด์เค้าโครง, และสไลด์แม่โดยใช้เมธอด `equals` ที่มาจากคลาส `BaseSlide`. เมธอดนี้จะคืนค่า `true` เมื่อสไลด์ที่เปรียบเทียบมีโครงสร้างและเนื้อหาคงที่ตรงกัน.

## **เปรียบเทียบสองสไลด์**

เมธอด Equals ได้เพิ่มเข้าไปในคลาส [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/BaseSlide) แล้ว. มันคืนค่า true สำหรับสไลด์/เค้าโครงและสไลด์/แม่ที่มีโครงสร้างและเนื้อหาคงที่เหมือนกัน.

สองสไลด์ถือว่าเท่ากันหากรูปแบบทั้งหมด, สไตล์, ข้อความ, แอนิเมชันและการตั้งค่าอื่น ๆ ฯลฯ เท่ากัน. การเปรียบเทียบจะไม่พิจารณาค่าตัวระบุที่เป็นเอกลักษณ์ เช่น SlideId และเนื้อหาแบบไดนามิก เช่น ค่าที่เป็นวันที่ปัจจุบันในตัวจัดเก็บวันที่.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **คำถามที่พบบ่อย**

**การที่สไลด์ถูกซ่อนไปมีผลต่อการเปรียบเทียบสไลด์เองหรือไม่?**

[Hidden status](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/gethidden/) เป็นคุณสมบัติระดับการนำเสนอ/การเล่น, ไม่ใช่เนื้อหาภาพ. ความเท่าเทียมของสองสไลด์เฉพาะจะกำหนดโดยโครงสร้างและเนื้อหาคงที่; การที่สไลด์ถูกซ่อนไปเพียงอย่างเดียวไม่ได้ทำให้สไลด์แตกต่างกัน.

**ไฮเปอร์ลิงก์และพารามิเตอร์ของมันถูกนำมาพิจารณาหรือไม่?**

ใช่. ลิงก์เป็นส่วนหนึ่งของเนื้อหาคงที่ของสไลด์. หาก URL หรือการกระทำของไฮเปอร์ลิงก์แตกต่างกัน, จะถือว่าเป็นความแตกต่างในเนื้อหาคงที่.

**หากแผนภูมิเกี่ยวข้องกับไฟล์ Excel ภายนอก, เนื้อหาในไฟล์นั้นจะถูกนำมาพิจารณาหรือไม่?**

ไม่. การเปรียบเทียบทำบนพื้นฐานของสไลด์เอง. แหล่งข้อมูลภายนอกส่วนใหญ่จะไม่ถูกอ่านในระหว่างการเปรียบเทียบ; มีเพียงสิ่งที่อยู่ในโครงสร้างและสถานะคงที่ของสไลด์เท่านั้นที่ถูกพิจารณา.