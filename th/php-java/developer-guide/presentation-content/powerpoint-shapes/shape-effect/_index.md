---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย PHP
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/php-java/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เปลี่ยนแปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถทำให้รูปร่างโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [การเติม](/slides/th/php-java/shape-formatting/#gradient-fill) หรือเส้นขอบ โดยใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง, ทำให้แสงเรืองแสงของรูปร่างกระจาย, เป็นต้น

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายแบบกับรูปร่างหนึ่งรูปร่างได้  

* การผสมผสานของเอฟเฟกต์บางอย่างดูดีกว่าบางอย่าง สำหรับเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **ค่าที่กำหนดล่วงหน้า** ตัวเลือกค่าที่กำหนดล่วงหน้านั้นเป็นการผสมผสานที่ดูดีแล้วของเอฟเฟกต์สองแบบหรือมากกว่า ดังนั้นโดยการเลือกค่าที่กำหนดล่วงหน้า คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมผสานที่ดี  

Aspose.Slides มอบคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/EffectFormat) ที่ทำให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟกต์เงา**

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์เงานอก ([OuterShadowEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) กับสี่เหลี่ยมผืนผ้า:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้เอฟเฟกต์เรืองแสง**

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์เรืองแสงกับรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้เอฟเฟกต์ขอบอ่อน**

โค้ด PHP นี้แสดงวิธีการใช้ขอบอ่อนกับรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**  

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสง บนรูปร่างเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น  

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดบ้าง?**  

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงรูปร่างอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ  

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่รวมกลุ่มได้หรือไม่?**  

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่รวมกลุ่มได้ เอฟเฟกต์จะถูกใช้กับกลุ่มทั้งหมด  

