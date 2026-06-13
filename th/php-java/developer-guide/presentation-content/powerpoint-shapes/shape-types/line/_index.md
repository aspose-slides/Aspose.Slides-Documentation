---
title: เพิ่มรูปทรงเส้นในงานนำเสนอด้วย PHP
linktitle: เส้น
type: docs
weight: 50
url: /th/php-java/Line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- ตั้งค่าเส้น
- ปรับแต่งเส้น
- รูปแบบเส้นประ
- หัวศร
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for PHP via Java. ค้นพบคุณสมบัติ เมธอด และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มรูปร่างเส้นในสไลด์ PowerPoint อย่างอัตโนมัติ บทความนี้แสดงวิธีสร้างเส้นธรรมดาและวิธีปรับแต่งเส้นให้เป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปร่างเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกการนำเสนอที่อัปเดต ตัวอย่างจะเน้นการตั้งค่าการจัดรูปแบบเส้นเชิงปฏิบัติ เช่น สไตล์ ความกว้าง รูปแบบเส้นประ ตัวเลือกหัวศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) class
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้งานโดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/)
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX
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

## **สร้างเส้นรูปศร**

Aspose.Slides for PHP via Java ยังอนุญาตให้ผู้พัฒนาตั้งค่าบางคุณสมบัติของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองกำหนดค่าบางอย่างของเส้นให้ดูคล้ายศรตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) class
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้งานโดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/)
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineStyle) เป็นหนึ่งในสไตล์ที่ Aspose.Slides for PHP via Java มีให้
- ตั้งค่าความกว้างของเส้น
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineDashStyle) ของเส้นเป็นหนึ่งในสไตล์ที่ Aspose.Slides for PHP via Java มีให้
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/php-java/aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดเส้น
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # ปรับการจัดรูปแบบบางอย่างบนเส้น
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

**ฉันสามารถแปลงเส้นปกติให้เป็นคอนเนคเตอร์เพื่อให้ “ล็อก” กับรูปร่างได้หรือไม่?**

ไม่ได้ เส้นปกติ (AutoShape ประเภท [Line](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/)) ไม่ได้กลายเป็นคอนเนคเตอร์โดยอัตโนมัติ หากต้องการให้ล็อกกับรูปร่าง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/) และ API ที่เกี่ยวข้อง (/slides/th/php-java/connector/) เพื่อทำการเชื่อมต่อ

**ถ้า属性ของเส้นถูกสืบทอดจากธีมและยากที่จะกำหนดค่าจากขั้นสุดท้าย ฉันควรทำอย่างไร?**

ให้ [อ่านคุณสมบัติเกิดผล](/slides/th/php-java/shape-effective-properties/) ผ่าน `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — ค่าต่าง ๆ นี้ได้คำนึงถึงการสืบทอดและสไตล์ของธีมแล้ว

**ฉันสามารถล็อกเส้นไม่ให้แก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่?**

ได้ รูปร่างมี [lock objects](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/getautoshapelock/) ที่ให้คุณปฏิเสธการทำงานแก้ไขต่าง ๆ 