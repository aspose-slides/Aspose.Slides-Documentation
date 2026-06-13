---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน PHP
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/php-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- PHP
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint ให้เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงไฟล์งานนำเสนอ PowerPoint ให้เป็นภาพ PNG ด้วย Aspose.Slides แสดงวิธีโหลดไฟล์งานนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX และ ODP เรนเดอร์สไลด์เป็นภาพและบันทึกผลลัพธ์เป็นรูปแบบ PNG  

บทความยังแสดงวิธีปรับแต่งภาพ PNG ที่สร้างขึ้นโดยตั้งค่าการสเกลหรือระบุความกว้างและความสูงที่ต้องการ  

## **แปลง PowerPoint เป็น PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. ดึงอ็อบเจกต์สไลด์จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) ภายใต้คลาส [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/)  
3. ใช้วิธีการ [Slide.getImage()](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) เพื่อรับภาพย่อของแต่ละสไลด์  
4. ใช้วิธีการ [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save) เพื่อบันทึกภาพย่อสไลด์เป็นรูปแบบ PNG  

โค้ด PHP นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

หากต้องการไฟล์ PNG ที่มีสเกลเฉพาะ คุณสามารถตั้งค่าตัวแปร `desiredX` และ `desiredY` ซึ่งกำหนดมิติของภาพย่อที่ได้ผลลัพธ์  

โค้ดนี้สาธิตการทำงานที่อธิบายไว้:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

หากต้องการไฟล์ PNG ที่มีขนาดเฉพาะ คุณสามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `ImageSize`  

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG โดยระบุขนาดของภาพ:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปร่างที่กำหนด (เช่น แผนภูมิหรือรูปภาพ) แทนการส่งออกทั้งสไลด์ได้อย่างไร?**  

Aspose.Slides รองรับ [การสร้างภาพย่อสำหรับรูปร่างแต่ละอัน](/slides/th/php-java/create-shape-thumbnails/) คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG  

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**  

ได้ แต่ [อย่าแชร์](/slides/th/php-java/multithreading/) อินสแตนซ์งานนำเสนอเดียวระหว่างเธรด ควรใช้อินสแตนซ์แยกตามเธรดหรือกระบวนการ  

**ข้อจำกัดของเวอร์ชันทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**  

โหมดประเมินผลจะเพิ่มลายน้ำลงบนภาพที่ส่งออกและบังคับใช้ [ข้อจำกัดอื่น ๆ](/slides/th/php-java/licensing/) จนกว่าจะมีการใช้งานใบอนุญาต  