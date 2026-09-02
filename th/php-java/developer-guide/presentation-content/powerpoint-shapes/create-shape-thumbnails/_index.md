---
title: สร้างภาพตัวอย่างของรูปร่างในงานนำเสนอด้วย PHP
linktitle: ภาพตัวอย่างรูปร่าง
type: docs
weight: 70
url: /th/php-java/create-shape-thumbnails/
keywords:
- ภาพตัวอย่างของรูปร่าง
- รูปภาพของรูปร่าง
- การเรนเดอร์รูปร่าง
- การแสดงผลรูปร่าง
- ขอบเขตภาพจริง
- ขอบเขตของรูปร่าง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างภาพตัวอย่างของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for PHP via Java – สร้างและส่งออกรูปตัวอย่างของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้เพื่อสร้างไฟล์งานนำเสนอซึ่งแต่ละหน้าจะเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกออกในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides ช่วยคุณสร้างภาพตัวอย่างของรูปร่างในสไลด์ วิธีการใช้คุณลักษณะนี้จะอธิบายในบทความนี้  
บทความนี้อธิบายวิธีการสร้างภาพตัวอย่างสไลด์ในรูปแบบต่าง ๆ:

- สร้างภาพตัวอย่างของรูปร่างภายในสไลด์
- สร้างภาพตัวอย่างของรูปร่างสำหรับรูปร่างสไลด์โดยกำหนดขนาดตามผู้ใช้
- สร้างภาพตัวอย่างของรูปร่างในขอบเขตของการปรากฏของรูปร่าง

## **สร้างภาพตัวอย่างของรูปร่างจากสไลด์**
เพื่อสร้างภาพตัวอย่างของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for PHP via Java ทำตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)  
1. ดึงอ้างอิงของสไลด์ใด  ๆ ด้วย ID หรือดัชนีของมัน  
1. รับภาพตัวอย่างของรูปร่าง [Get the shape thumbnail image](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) ของสไลด์ที่อ้างถึงด้วยสเกลเริ่มต้น  
1. บันทึกภาพตัวอย่างในรูปแบบภาพที่คุณต้องการ  

ตัวอย่างโค้ดนี้แสดงวิธีการสร้างภาพตัวอย่างของรูปร่างจากสไลด์:

```php
  # สร้างคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพขนาดเต็ม
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

## **สร้างภาพตัวอย่างด้วยอัตราสเกลกำหนดโดยผู้ใช้**
เพื่อสร้างภาพตัวอย่างของรูปร่างจากสไลด์ด้วย Aspose.Slides for PHP via Java ทำตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)  
1. ดึงอ้างอิงของสไลด์ใด  ๆ ด้วย ID หรือดัชนีของมัน  
1. รับภาพตัวอย่างของรูปร่าง [Get the shape thumbnail image](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) ของสไลด์ที่อ้างถึงโดยกำหนดขนาดตามผู้ใช้  
1. บันทึกภาพตัวอย่างในรูปแบบภาพที่คุณต้องการ  

ตัวอย่างโค้ดนี้แสดงวิธีการสร้างภาพตัวอย่างของรูปร่างโดยอิงจากอัตราสเกลที่กำหนด:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพขนาดเต็ม
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

## **สร้างภาพตัวอย่างรูปร่างตามขอบเขตของการปรากฏ**
วิธีนี้ช่วยให้ผู้พัฒนาสามารถสร้างภาพตัวอย่างภายในขอบเขตของการปรากฏของรูปร่างได้โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพตัวอย่างที่สร้างจะถูกจำกัดโดยขอบของสไลด์ เพื่อสร้างภาพตัวอย่างของรูปร่างสไลด์ในขอบเขตของการปรากฏ ทำตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)  
1. ดึงอ้างอิงของสไลด์ใด  ๆ ด้วย ID หรือดัชนีของมัน  
1. รับภาพตัวอย่างของสไลด์ที่อ้างถึงโดยใช้ขอบเขตของรูปร่างเป็นการปรากฏ  
1. บันทึกภาพตัวอย่างในรูปแบบภาพที่คุณต้องการ  

ตัวอย่างโค้ดนี้อิงตามขั้นตอนข้างต้น:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # สร้างภาพขนาดเต็ม
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

## **รับค่าขอบเขตภาพจริงของรูปร่าง**

คุณสมบัติกรอบของ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, และ `Shape::getHeight()` — รายงานสี่เหลี่ยมที่เก็บไว้ในโมเดลงานนำเสนอ เนื้อหาที่ถูกเรนเดอร์จริงอาจขยายออกไปนอกกรอบนั้นหรืออยู่ในสี่เหลี่ยมที่มีแนวแกนอิงต่างกัน การหมุน, เส้นกรอบ, ปลายลูกศร, การจัดวางและการล้นของข้อความ, รูปทรง SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ครอบคลุมได้

ใช้ [Shape::getVisualBounds](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getVisualBounds) เพื่อคำนวณพื้นที่ที่ครอบคลุมโดยไม่ต้องสร้างภาพ วิธีนี้จะคืนค่าเป็น [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ในพิกัดสไลด์ สี่เหลี่ยมที่คืนมาจะไม่ถูกคลิปกับสไลด์ ดังนั้นพิกัดอาจเป็นค่าลบเมื่อเนื้อหาขยายเกินจุดกำเนิดของสไลด์

ตัวอย่างต่อไปนี้รับและเปรียบเทียบกรอบและขอบเขตภาพจริง:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) เดียวกันสามารถใช้จัดตำแหน่งรูปร่างใกล้เคียงให้อยู่ด้านซ้าย, ด้านขวา, ด้านบน หรือด้านล่าง; จองพื้นที่เพียงพอในเลย์เอาต์ที่สร้างขึ้น; หรือตรวจจับเนื้อหานอกพื้นที่ที่อนุญาต ขอบเขตภาพจริงมีประโยชน์โดยเฉพาะสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่างเมื่อกรอบที่เก็บไว้ไม่แสดงผลลัพธ์ที่เรนเดอร์ทั้งหมด

ใช้ [Shape::getVisualBounds](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getVisualBounds) เมื่อคุณต้องการพิกัดสำหรับการจัดวางหรือการตรวจสอบและไม่ต้องการบิตแมพ ใช้ [Shape::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) เมื่อคุณต้องการเรนเดอร์รูปร่าง กับ [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds::Shape` กำหนดขนาดภาพจากขอบเขตของรูปร่างรวมถึงการตั้งค่าเส้นกรอบขณะ `ShapeThumbnailBounds::Appearance` กำหนดขนาดจากการปรากฏของรูปร่างและจำกัดผลลัพธ์ให้อยู่ภายในขอบของสไลด์ ในทางตรงกันข้าม `Shape::getVisualBounds` จะคืนค่าเฉพาะสี่เหลี่ยมที่คำนวณและไม่คลิปกับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้ได้เมื่อบันทึกภาพตัวอย่างของรูปร่าง?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [exported as vector SVG](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์ภาพตัวอย่างคืออะไร?**  
`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [visual effects](/slides/th/php-java/shape-effect/) (เงา, แสงสว่าง ฯลฯ)

**ถ้ารูปร่างถูกทำเครื่องหมายว่าเป็น hidden จะยังคงเรนเดอร์เป็นภาพตัวอย่างหรือไม่?**  
รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปร่าง

**รองรับกลุ่มรูปร่าง, แผนภูมิ, SmartArt และอ็อบเจ็กต์ซับซ้อนอื่น ๆ หรือไม่?**  
ใช่. อ็อบเจ็กต์ใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/)) สามารถบันทึกเป็นภาพตัวอย่างหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพตัวอย่างสำหรับรูปรูปข้อความหรือไม่?**  
ใช่. คุณควร [provide the required fonts](/slides/th/php-java/custom-font/) (หรือ [configure font substitutions](/slides/th/php-java/font-substitution/)) เพื่อลดการคืนค่า fallback ที่ไม่ต้องการและการจัดเรียงข้อความใหม่