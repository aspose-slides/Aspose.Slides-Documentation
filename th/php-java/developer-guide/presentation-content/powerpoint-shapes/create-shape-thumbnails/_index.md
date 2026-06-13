---
title: สร้างภาพย่อของรูปร่างการนำเสนอใน PHP
linktitle: ภาพย่อของรูปร่าง
type: docs
weight: 70
url: /th/php-java/create-shape-thumbnails/
keywords:
- ภาพย่อของรูปร่าง
- ภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างภาพย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java – สร้างและส่งออกภาพย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้สำหรับสร้างไฟล์งานนำเสนอที่แต่ละหน้าเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตามบางครั้งนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกจากกันในโปรแกรมดูรูป ในกรณีดังกล่าว Aspose.Slides จะช่วยให้คุณสร้างภาพย่อของรูปร่างในสไลด์ วิธีการใช้คุณลักษณะนี้อธิบายไว้ในบทความนี้  
บทความนี้อธิบายวิธีสร้างภาพย่อของสไลด์ในรูปแบบต่าง ๆ:

- การสร้างภาพย่อของรูปร่างภายในสไลด์
- การสร้างภาพย่อของรูปร่างสไลด์โดยกำหนดมิติด้วยตนเอง
- การสร้างภาพย่อของรูปร่างภายในขอบเขตการแสดงผลของรูปร่าง

## **สร้างภาพย่อของรูปทรงจากสไลด์**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใดก็ได้โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใดก็ได้โดยใช้ ID หรือดัชนี
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) ของสไลด์ที่อ้างถึงโดยใช้สเกลค่าเริ่มต้น
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

ตัวอย่างโค้ดนี้แสดงวิธีสร้างภาพย่อของรูปร่างจากสไลด์:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพเต็มสเกล
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างภาพย่อด้วยอัตราส่วนสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพย่อของรูปร่างสไลด์โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใดก็ได้โดยใช้ ID หรือดัชนี
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) ของสไลด์ที่อ้างถึงพร้อมกำหนดมิติด้วยตนเอง
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

ตัวอย่างโค้ดนี้แสดงวิธีสร้างภาพย่อของรูปร่างโดยอิงจากอัตราส่วนสเกลที่กำหนด:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพเต็มสเกล
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างภาพย่อของรูปร่างโดยอิงจากขอบเขตการแสดงผล**
วิธีการสร้างภาพย่อของรูปร่างนี้ช่วยให้ผู้พัฒนาสามารถสร้างภาพย่อภายในขอบเขตการแสดงผลของรูปร่างได้ โดยจะคำนึงถึงเอฟเฟกต์ของรูปร่างทั้งหมด ภาพย่อของรูปร่างที่สร้างจะถูกจำกัดโดยขอบของสไลด์ เพื่อสร้างภาพย่อของรูปร่างสไลด์ภายในขอบการแสดงผลทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใดก็ได้
1. รับภาพย่อของสไลด์ที่อ้างถึงโดยใช้ขอบเขตรูปร่างเป็นการแสดงผล
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างนี้อิงตามขั้นตอนข้างต้น:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพเต็มสเกล
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/), และรูปแบบอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [เอฟเฟกต์การแสดงผล](/slides/th/php-java/shape-effect/) (เงา, เปล่งแสง เป็นต้น) ด้วย

**ถ้ารูปร่างถูกทำเครื่องหมายว่าเป็นซ่อน จะเกิดอะไรขึ้น? จะยังคงสร้างภาพย่อได้หรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนจะส่งผลต่อการแสดงผลสไลด์โชว์แต่ไม่ได้ป้องกันการสร้างภาพของรูปร่าง

**รองรับรูปร่างกลุ่ม แผนภูมิ SmartArt และอ็อบเจ็กต์ที่ซับซ้อนอื่น ๆ หรือไม่?**

ใช่ อ็อบเจ็กต์ใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้

**ฟอนท์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่ คุณควร [จัดเตรียมฟอนท์ที่ต้องการ](/slides/th/php-java/custom-font/) (หรือ [กำหนดการทดแทนฟอนท์](/slides/th/php-java/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนท์สำรองที่ไม่ต้องการและการจัดเรียงข้อความใหม่.