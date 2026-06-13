---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน PHP
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/php-java/paragraph/
keywords:
- ขอบเขตย่อหน้า
- ขอบเขตส่วนข้อความ
- พิกัดย่อหน้า
- พิกัดส่วน
- ขนาดย่อหน้า
- ขนาดส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อปรับตำแหน่งข้อความในงานนำเสนอ PowerPoint ให้มีประสิทธิภาพสูงสุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาด, และพิกัดของย่อหน้าและส่วนข้อความใน Aspose.Slides แสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` โดยใช้ `getRect()` วิธีการรับพิกัดของย่อหน้าและส่วนภายในกรอบข้อความของเซลล์ตาราง และเน้นรายละเอียดสำคัญเช่นหน่วยการวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าอย่างมีประสิทธิภาพ

## **รับพิกัดย่อหน้าและส่วนใน TextFrame**
โดยใช้ Aspose.Slides for PHP ผ่าน Java นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในคอลเลกชันของย่อหน้าใน TextFrame ได้แล้ว นอกจากนี้ยังให้คุณรับ [the coordinates of portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getCoordinates) ภายในคอลเลกชันของส่วนของย่อหน้า ในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างว่าวิธีการรับพิกัดสี่เหลี่ยมของย่อหน้า พร้อมตำแหน่งของส่วนภายในย่อหน้าอย่างไร

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**
โดยใช้วิธี [**getRect()**](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getRect) นักพัฒนาสามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **รับขนาดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง**
เพื่อรับขนาดและพิกัดของ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/Portion) หรือ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/Paragraph) ใน TextFrame ของเซลล์ตาราง คุณสามารถใช้วิธี [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getRect) และ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getRect) ได้

โค้ดตัวอย่างนี้จะแสดงการดำเนินการที่อธิบายไว้:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
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

**พิกัดที่ส่งคืนสำหรับย่อหน้าและส่วนข้อความวัดเป็นหน่วยใด?**  
ในหน่วยจุด (points) โดยที่ 1 นิ้ว = 72 จุด ใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**  
ใช่ หาก [wrapping](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setwraptext/) ถูกเปิดใช้งานใน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ซึ่งจะทำให้ขอบเขตจริงของย่อหน้าเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างแม่นยำหรือไม่?**  
ใช่ แปลงจุดเป็นพิกเซลโดยใช้: pixels = points × (DPI / 72) ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าแบบ "effective" โดยคำนึงถึงการสืบทอดสไตล์ได้อย่างไร?**  
ใช้ [effective paragraph formatting data structure](/slides/th/php-java/shape-effective-properties/) จะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL และอื่น ๆ