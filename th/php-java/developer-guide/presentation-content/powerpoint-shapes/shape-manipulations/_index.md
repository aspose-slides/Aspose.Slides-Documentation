---
title: จัดการรูปร่างการนำเสนอใน PHP
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/php-java/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนรูปร่าง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดตำแหน่งรูปร่าง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและเพิ่มประสิทธิภาพรูปร่างใน Aspose.Slides for PHP via Java และส่งมอบการนำเสนอ PowerPoint ที่มีประสิทธิภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับรูปร่างในงานนำเสนอด้วย Aspose.Slides แสดงวิธีค้นหารูปร่างบนสไลด์, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, รับ Interop shape ID, และตั้งค่า Alternative Text เพื่อระบุและประมวลผลต่อไป

นอกจากนี้ยังครอบคลุมการเข้าถึง Layout Formats ของรูปร่าง, การเรนเดอร์รูปร่างเป็น SVG, การจัดตำแหน่งรูปร่างบนสไลด์, และการใช้คุณสมบัติ Flip สำหรับการสะท้อนแนวนอนและแนวตั้ง อีกทั้งบทความยังมีคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับการรวมรูปร่าง, ลำดับการซ้อน, และการล็อครูปร่าง

## **ค้นหารูปร่างบนสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อช่วยนักพัฒนาให้ค้นหารูปร่างเฉพาะบนสไลด์ได้โดยไม่ต้องใช้ Id ภายในของมัน การรู้ว่ไฟล์ PowerPoint Presentation ไม่ได้มีวิธีระบุรูปร่างบนสไลด์นอกจาก Id ภายในที่เป็นเอกลักษณ์นั้นสำคัญมาก เนื่องจากนักพัฒนามักพบความยากลำบากในการหรูปร่างโดยใช้ Id ภายในที่เป็นเอกลักษณ์ ทุกรูปร่างที่เพิ่มเข้ามาในสไลด์จะมี Alt Text เราแนะนำให้นักพัฒนาใช้ Alternative Text เพื่อค้นหารูปร่างเฉพาะ คุณสามารถใช้ MS PowerPoint กำหนด Alternative Text ให้กับออบเจกต์ที่คุณอาจเปลี่ยนแปลงในอนาคตได้

หลังจากตั้งค่า Alternative Text ให้กับรูปร่างที่ต้องการแล้ว คุณสามารถเปิดงานนำเสนอด้วย Aspose.Slides for PHP via Java และวนผ่านรูปร่างทั้งหมดที่เพิ่มเข้ามาในสไลด์ ในแต่ละรอบคุณสามารถตรวจสอบ Alternative Text ของรูปร่าง และรูปร่างที่มี Alternative Text ตรงกันจะเป็นรูปร่างที่คุณต้องการ เพื่อสาธิตเทคนิคนี้อย่างชัดเจน เราได้สร้างเมธอด [findShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ที่ทำหน้าที่ค้นหารูปร่างเฉพาะในสไลด์และคืนค่ารูปร่างนั้นโดยตรง

```php
  # สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # ข้อความแทนของรูปร่างที่ต้องการค้นหา
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **คัดลอกรูปร่าง**
เพื่อคัดลอกรูปร่างไปยังสไลด์โดยใช้ Aspose.Slides for PHP via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์ต้นฉบับ
1. เพิ่มสไลด์ใหม่ไปยังงานนำเสนอ
1. คัดลอกรูปร่างจากคอลเลกชันรูปร่างของสไลด์ต้นฉบับไปยังสไลด์ใหม่
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่ม Group Shape ไปยังสไลด์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # บันทึกไฟล์ PPTX ไปยังดิสก์
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบรูปร่าง**
Aspose.Slides for PHP via Java อนุญาตให้นักพัฒนาลบรูปร่างใด ๆ เพื่อทำการลบรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText ที่ต้องการ
1. ลบรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```php
  # สร้างอ็อบเจกต์ Presentation
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # บันทึกงานนำเสนอไปยังดิสก์
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ซ่อนรูปร่าง**
Aspose.Slides for PHP via Java อนุญาตให้นักพัฒนาซ่อนรูปร่างใด ๆ เพื่อทำการซ่อนรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText ที่ต้องการ
1. ซ่อนรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # บันทึกงานนำเสนอไปยังดิสก์
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนลำดับรูปร่าง**
Aspose.Slides for PHP via Java อนุญาตให้นักพัฒนาเรียงลำดับรูปร่างใหม่ การเรียงลำดับรูปร่างบ่งบอกว่ารูปร่างใดอยู่ด้านหน้า หรือด้านหลัง เพื่อเปลี่ยนลำดับรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่าง
1. เพิ่มข้อความบางอย่างใน Text Frame ของรูปร่าง
1. เพิ่มรูปร่างอีกอันโดยใช้พิกัดเดียวกัน
1. เรียงลำดับรูปร่างใหม่
1. บันทึกไฟล์ลงดิสก์

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **รับ Interop Shape ID**
Aspose.Slides for PHP via Java อนุญาตให้นักพัฒนาได้รับตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับสไลด์ ซึ่งต่างจากเมธอด [getUniqueId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getuniqueid/) ที่ให้ค่าตัวระบุเอกลักษณ์ระดับงานนำเสนอ เมธอด [getOfficeInteropShapeId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getofficeinteropshapeid/) ถูกเพิ่มเข้าไปในคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ค่าที่ส่งกลับจากเมธอดนี้สอดคล้องกับ Id ของออบเจกต์ Microsoft.Office.Interop.PowerPoint.Shape ด้านล่างเป็นตัวอย่างโค้ด

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # การรับตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับสไลด์
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่า Alternative Text ให้กับรูปร่าง**
Aspose.Slides for PHP via Java อนุญาตให้นักพัฒนาตั้งค่า AlternateText ของรูปร่างใด ๆ รูปร่างในงานนำเสนอสามารถระบุได้ด้วย `Alternative Text` หรือเมธอด [Shape Name](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setname/) เมธอด [setAlternativeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setalternativetext/) และ [getAlternativeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getalternativetext/) สามารถอ่านหรือกำหนดค่าได้ด้วย Aspose.Slides รวมถึง Microsoft PowerPoint โดยใช้เมธอดนี้คุณสามารถแท็กรูปร่างและทำการดำเนินการต่าง ๆ เช่น การลบรูปร่าง, การซ่อนรูปร่าง หรือการเรียงลำดับรูปร่างบนสไลด์ เพื่อกำหนด AlternateText ของรูปร่าง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่างใด ๆ ลงสไลด์
1. ทำงานบางอย่างกับรูปร่างที่เพิ่มใหม่
1. วนผ่านรูปร่างเพื่อค้นหารูปร่างที่ต้องการ
1. ตั้งค่า AlternativeText
1. บันทึกไฟล์ลงดิสก์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # บันทึกงานนำเสนอไปยังดิสก์
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เข้าถึง Layout Formats ของรูปร่าง**
Aspose.Slides for PHP via Java มี API ง่าย ๆ สำหรับเข้าถึง Layout Formats ของรูปร่าง บทความนี้สาธิตวิธีเข้าถึง Layout Formats

ตัวอย่างโค้ดด้านล่าง

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เรนเดอร์รูปร่างเป็น SVG**
ตอนนี้ Aspose.Slides for PHP via Java รองรับการเรนเดอร์รูปร่างเป็น SVG เมธอด [writeAsSvg](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) (และ overload ของมัน) ถูกเพิ่มเข้าไปในคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) เมธอดนี้อนุญาตให้บันทึกเนื้อหาของรูปร่างเป็นไฟล์ SVG ตัวอย่างโค้ดต่อไปนี้แสดงวิธีส่งออกรูปร่างของสไลด์เป็นไฟล์ SVG

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **จัดตำแหน่งรูปร่าง**
Aspose.Slides อนุญาตให้จัดตำแหน่งรูปร่างได้ทั้งอิงตามขอบสไลด์หรืออิงตามรูปร่างอื่น ๆ สำหรับจุดนี้ได้มีการเพิ่มเมธอด overload [SlidesUtil::alignShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/alignshapes/) ส่วน enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapesalignmenttype/) กำหนดตัวเลือกการจัดตำแหน่งที่เป็นไปได้

**ตัวอย่างที่ 1**

โค้ดต้นฉบับด้านล่างจัดตำแหน่งรูปร่างที่มีดัชนี 1,2 และ 4 ไว้ที่ขอบบนของสไลด์

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**ตัวอย่างที่ 2**

ตัวอย่างด้านล่างแสดงวิธีจัดตำแหน่งคอลเลกชันของรูปร่างทั้งหมดอิงตามรูปร่างที่อยู่ด้านล่างสุดของคอลเลกชัน

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คุณสมบัติ Flip**

ใน Aspose.Slides คลาส [ShapeFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/) ให้การควบคุมการสะท้อนแนวนอนและแนวตั้งของรูปร่างผ่านคุณสมบัติ `flipH` และ `flipV` ทั้งสองเป็นชนิด [NullableBool](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/) ซึ่งรับค่า `True` เพื่อทำการพลิก, `False` เพื่อไม่พลิก, หรือ `NotDefined` เพื่อใช้ค่าพื้นฐาน ค่าเหล่านี้เข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getFrame) ของรูปร่าง

เพื่อแก้ไขการตั้งค่า flip เราจะสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปร่าง, ค่าที่ต้องการสำหรับ `flipH` และ `flipV`, รวมถึงมุมหมุน การกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getFrame) ของรูปร่างและบันทึกงานนำเสนอจะทำให้การสะท้อนถูกนำไปใช้และบันทึกลงไฟล์ผลลัพธ์

สมมติว่าเรามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปร่างเดียวที่มีการตั้งค่า flip ปกติ ตามตัวอย่างด้านล่าง

![รูปร่างที่ต้องการพลิก](shape_to_be_flipped.png)

โค้ดตัวอย่างต่อไปนี้จะดึงคุณสมบัติ flip ปัจจุบันของรูปร่างและพลิกทั้งแนวนอนและแนวตั้ง

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // ดึงคุณสมบัติการพลิกแนวนอนของรูปร่าง.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // ดึงคุณสมบัติการพลิกแนวตั้งของรูปร่าง.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // พลิกรูปแนวนอน.
    $flipV = NullableBool::True; // พลิกรูปแนวนอน.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่พลิกแล้ว](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมรูปร่าง (union/intersect/subtract) บนสไลด์เหมือนในโปรแกรมแก้ไขเดสก์ท็อปได้หรือไม่?**

ไม่มี API ทำงาน Boolean ในตัว คุณสามารถประมาณผลได้โดยสร้างรูปร่างใหม่ตามโครงร่างที่ต้องการเอง เช่น คำนวณเรขาคณิตที่ได้ (ผ่าน [GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/)) แล้วสร้างรูปร่างใหม่ด้วยคอนทัวร์นั้น พร้อมกับลบรูปร่างเดิมหากต้องการ

**ฉันจะควบคุมลำดับการซ้อน (z-order) เพื่อให้รูปร่างคงอยู่ด้านบนเสมอได้อย่างไรว์?**

เปลี่ยนลำดับการแทรกหรือย้ายภายในคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getShapes) ของสไลด์ สำหรับผลลัพธ์ที่คาดเดาได้ ให้สรุป z-order หลังจากทำการแก้ไขสไลด์ทั้งหมดเสร็จแล้ว

**ฉันสามารถ "ล็อค" รูปร่างเพื่อป้องกันไม่ให้ผู้ใช้แก้ไขใน PowerPoint ได้หรือไม่?**

ได้ คุณสามารถตั้งค่าธงการปกป้องระดับรูปร่าง (เช่น การล็อคการเลือก, การย้าย, การปรับขนาด, การแก้ไขข้อความ) หากจำเป็นยังสามารถตั้งข้อจำกัดบนมาสเตอร์หรือเลเอาต์ได้ โปรดทราบว่าเป็นการปกป้องระดับ UI ไม่ใช่ฟังก์ชันความปลอดภัย หากต้องการการปกป้องที่แข็งแรงขึ้น ควรใช้ข้อจำกัดระดับไฟล์เช่น [คำแนะนำอ่านอย่างเดียวหรือรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)