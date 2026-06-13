---
title: สร้างการนำเสนอใน PHP
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/php-java/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างการนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — สร้างไฟล์ PPT, PPTX, และ ODP และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้"
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides, เพิ่มเนื้อหาง่าย ๆ ลงในสไลด์, และบันทึกผลลัพธ์เป็นไฟล์ นอกจากนี้ยังสาธิตวิธีสร้างและบันทึกงานนำเสนอใหม่, เปิดงานนำเสนอที่มีอยู่ในรูปแบบที่สนับสนุน, และบันทึกไปยังรูปแบบอื่น นอกจากนี้บทความยังรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานแบบหลายเธรด, การให้ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA

## **สร้างงานนำเสนอ**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส Presentation
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่ม AutoShape ประเภท Line ด้วยเมธอด addAutoShape ที่เปิดให้ใช้โดยวัตถุ Shapes
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```php
  # สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดเส้น
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/php-java/save-presentation/) และส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/php-java/convert-powerpoint-to-xps/), [HTML](/slides/th/php-java/convert-powerpoint-to-html/), [SVG](/slides/th/php-java/convert-powerpoint-to-png/), และ [images](/slides/th/php-java/convert-powerpoint-to-png/) เป็นต้น

**ฉันสามารถเริ่มจากแม่แบบ (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ได้ โหลดแม่แบบและบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบคล้ายกัน [are supported](/slides/th/php-java/supported-file-formats/)

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนออย่างไร?**

ตั้งค่า [slide size](/slides/th/php-java/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกรูปแบบการขยายเนื้อหา

**หน่วยวัดของขนาดและพิกัดคืออะไร?**

เป็นจุด: 1 นิ้วเท่ากับ 72 หน่วย

**ฉันจะจัดการงานนำเสนอที่มีขนาดใหญ่มาก (มีไฟล์สื่อจำนวนมาก) เพื่อประหยัดหน่วยความจำอย่างไร?**

ใช้ [BLOB management strategies](/slides/th/php-java/manage-blob/), จำกัดการเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรใช้กระบวนการทำงานแบบไฟล์แทนสตรีมในหน่วยความจำอย่างเดียว

**ฉันสามารถสร้าง/บันทึกงานนำเสนอแบบขนานได้หรือไม่?**

คุณไม่สามารถดำเนินการกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เดียวจาก [multiple threads](/slides/th/php-java/multithreading/) ได้ ควรรันอินสแตนซ์แยกกันสำหรับแต่ละเธรดหรือกระบวนการ

**ฉันจะลบลายน้ำทดลองและข้อจำกัดได้อย่างไร?**

[Apply a license](/slides/th/php-java/licensing/) ครั้งเดียวต่อกระบวนการ XML ลิขสิทธิ์ต้องไม่ถูกแก้ไข และการตั้งค่าลิขสิทธิ์ควรทำให้สอดคล้องกันหากมีหลายเธรด

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

ได้ การ [Digital signatures](/slides/th/php-java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ได้รับการสนับสนุนสำหรับงานนำเสนอ

**แมโคร (VBA) ถูกสนับสนุนในงานนำเสนอที่สร้างหรือไม่?**

ได้ คุณสามารถ [create/edit VBA projects](/slides/th/php-java/presentation-via-vba/) และบันทึกไฟล์ที่มีแมโครเช่น PPTM/PPSM