---
title: อัตโนมัติการแปลภาษาการนำเสนอใน PHP
linktitle: การแปลภาษาการนำเสนอ
type: docs
weight: 100
url: /th/php-java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจการสะกด
- รหัสภาษา
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "อัตโนมัติการแปลสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java โดยใช้ตัวอย่างโค้ดที่เป็นประโยชน์และเคล็ดลับเพื่อการเปิดตัวสู่ตลาดโลกที่เร็วขึ้น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการตั้งค่า `LanguageId` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการเปิดงานนำเสนอ, เพิ่มรูปทรงที่มีข้อความ, กำหนดตัวระบุภาษาต่อส่วนของข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับงานนำเสนอและข้อความของรูปร่าง**
- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ประเภท [Rectangle](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeType#Rectangle) ไปยังสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- ใช้ [Set Language Id](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) กับข้อความ
- เขียนงานนำเสนอเป็นไฟล์ PPTX

การดำเนินการของขั้นตอนข้างต้นแสดงตัวอย่างด้านล่าง

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**รหัสภาษา (Language ID) ทำให้เกิดการแปลข้อความโดยอัตโนมัติหรือไม่?**

ไม่. [Language ID](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) ใน Aspose.Slides จะเก็บภาษาสำหรับการตรวจสอบการสะกดและการพิสูจน์ไวยากรณ์, แต่ไม่ทำการแปลหรือเปลี่ยนแปลงเนื้อหาข้อความ. มันเป็นเมทาดาต้าที่ PowerPoint เข้าใจสำหรับการพิสูจน์.

**รหัสภาษา (Language ID) มีผลต่อการแยกพยางค์และการตัดบรรทัดระหว่างการเรนเดอร์หรือไม่?**

ใน Aspose.Slides, [language ID](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) ใช้สำหรับการพิสูจน์. คุณภาพการแยกพยางค์และการตัดบรรทัดขึ้นอยู่กับการมีอยู่ของ [แบบอักษรที่เหมาะสม](/slides/th/php-java/powerpoint-fonts/) และการตั้งค่า layout/line-break สำหรับระบบการเขียน. เพื่อให้การเรนเดอร์ถูกต้อง, ให้แน่ใจว่ามีแบบอักษรที่ต้องการ, ตั้งค่า [กฎการทดแทนแบบอักษร](/slides/th/php-java/font-substitution/), และ/หรือ [ฝังแบบอักษร](/slides/th/php-java/embedded-font/) ไปยังงานนำเสนอ.

**ฉันสามารถตั้งค่าภาษาต่างๆ ภายในย่อหน้าเดียวได้หรือไม่?**

ได้. [Language ID](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) จะถูกนำไปใช้ระดับส่วนของข้อความ, ดังนั้นย่อหน้าเดียวสามารถผสมหลายภาษาโดยมีการตั้งค่าการพิสูจน์ที่แตกต่างกัน.