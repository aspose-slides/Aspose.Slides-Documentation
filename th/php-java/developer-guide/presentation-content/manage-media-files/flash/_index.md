---
title: ดึงวัตถุ Flash จากงานนำเสนอใน PHP
linktitle: แฟลช
type: docs
weight: 10
url: /th/php-java/flash/
keywords:
- ดึง flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีดึงวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมตัวอย่างโค้ดเต็มและแนวทางปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีดึงวัตถุ Flash จากงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีค้นหา Flash control ตามชื่อในคอลเลกชันของคอนโทรลบนสไลด์และทำงานกับข้อมูลวัตถุ SWF ที่ฝังอยู่

## **ดึงวัตถุ Flash จากงานนำเสนอ**

Aspose.Slides สำหรับ PHP ผ่าน Java มีฟีเจอร์สำหรับการดึงวัตถุ flash จากงานนำเสนอ คุณสามารถเข้าถึง flash control ตามชื่อและดึงออกจากงานนำเสนอรวมถึงจัดเก็บข้อมูลวัตถุ SWF

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**รูปแบบไฟล์งานนำเสนอที่รองรับเมื่อดึงเนื้อหา Flash คืออะไร?**

[Aspose.Slides supports](/slides/th/php-java/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึงคอนโทรลของมัน รวมถึงองค์ประกอบ ActiveX ที่เกี่ยวข้องกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash เป็น HTML5 และรักษาการโต้ตอบของ Flash ไว้ได้หรือไม่?**

ไม่. Aspose.Slides ไม่ดำเนินการเนื้อหา SWF หรือแปลงการโต้ตอบของมัน ในขณะที่การส่งออกเป็น [HTML](/slides/th/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/th/php-java/export-to-html5/) ได้รับการสนับสนุน แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากการยุติการสนับสนุน แนวทางที่แนะนำคือเปลี่ยน Flash เป็นทางเลือกอื่นเช่นวิดีโอหรือแอนิเมชัน HTML5 ก่อนการส่งออก

**จากมุมมองด้านความปลอดภัย Aspose.Slides จะดำเนินการไฟล์ SWF ขณะอ่านงานนำเสนอหรือไม่?**

ไม่. Aspose.Slides ถือว่า Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และจะไม่ดำเนินการเนื้อหา SWF ระหว่างการประมวลผล

**ฉันควรจัดการงานนำเสนอที่มี Flash ร่วมกับไฟล์ฝังอื่นผ่าน OLE อย่างไร?**

Aspose.Slides supports [extracting embedded OLE objects](/slides/th/php-java/manage-ole/), ดังนั้นคุณจึงสามารถประมวลผลเนื้อหาที่ฝังทั้งหมดที่เกี่ยวข้องในขั้นตอนเดียว โดยจัดการ Flash control และเอกสารที่ฝังด้วย OLE อื่น ๆ พร้อมกัน