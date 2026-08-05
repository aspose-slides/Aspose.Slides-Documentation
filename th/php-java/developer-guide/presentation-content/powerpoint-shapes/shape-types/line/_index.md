---
title: เพิ่มรูปทรงเส้นให้กับการนำเสนอใน PHP
linktitle: เส้น
type: docs
weight: 50
url: /th/php-java/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่ารูปเส้น
- ปรับแต่งเส้น
- สไตล์เส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การจัดการรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint โดยโปรแกรมได้ บทความนี้แสดงวิธีสร้างเส้นธรรมดาและวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกการนำเสนอที่อัปเดต ตัวอย่างมุ่งเน้นการตั้งค่าการจัดรูปแบบเส้นที่ใช้งานจริง เช่น สไตล์ ความกว้าง รูปแบบเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาไปยังสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน 
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดเผยโดยอ็อบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) 
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดเส้น
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างเส้นรูปร่างลูกศร**

Aspose.Slides for PHP via Java ยังอนุญาตให้ผู้พัฒนาตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อทำให้ดูน่าสนใจขึ้น ลองกำหนดค่าคุณสมบัติบางอย่างของเส้นให้ดูเหมือนลูกศร โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน 
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดเผยโดยอ็อบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) 
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineStyle) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for PHP via Java มีให้ 
- ตั้งค่าความกว้างของเส้น 
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineDashStyle) ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for PHP via Java มีให้ 
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น 
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น 
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดเส้น
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # ปรับรูปแบบบางอย่างบนเส้น
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นทั่วไปเป็นคอนเน็กเตอร์เพื่อให้มัน "snap" เข้ากับรูปร่างได้หรือไม่?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/) type and the [corresponding APIs](/slides/th/php-java/connector/) for connections.

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดมาจากธีมและยากที่จะกำหนดค่าที่สุด?**

[Read the effective properties](/slides/th/php-java/shape-effective-properties/) through the `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—these already account for inheritance and theme styles.

**ฉันสามารถล็อคเส้นเพื่อป้องกันการแก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/getautoshapelock/) that let you disallow editing operations.