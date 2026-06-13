---
title: รูปร่างการนำเสนอแบบกลุ่มใน PHP
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/php-java/group/
keywords:
- รูปร่างกลุ่ม
- กลุ่มรูปร่าง
- เพิ่มกลุ่ม
- ข้อความแทน
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การจัดกลุ่มและยกเลิกการจัดกลุ่มรูปในชุดสไลด์ PowerPoint ด้วย Aspose.Slides for PHP via Java — คู่มือที่รวดเร็วและเป็นขั้นตอนพร้อมโค้ดฟรี."
---
## **Overview**

บทความนี้อธิบายวิธีการทำงานกับรูปกลุ่ม (group shapes) ใน Aspose.Slides แสดงวิธีการเพิ่มรูปกลุ่มลงในสไลด์, วางรูปต่าง ๆ ภายในกลุ่ม, และบันทึกงานนำเสนอที่ปรับปรุงแล้ว อีกทั้งยังสาธิตวิธีการเข้าถึงรูปที่เก็บอยู่ในกลุ่มและอ่านค่า `AlternativeText` ของพวกมัน นอกจากนี้บทความยังสรุปความสามารถที่เกี่ยวข้องกับรูปกลุ่ม เช่น กลุ่มซ้อนกัน, การจัดลำดับ z-order, และตัวเลือกการล็อก

## **Add a Group Shape**
Aspose.Slides รองรับการทำงานกับรูปกลุ่มบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสร้างงานนำเสนอที่มีความสมบูรณ์มากขึ้น Aspose.Slides for PHP via Java รองรับการเพิ่มหรือเข้าถึงรูปกลุ่ม สามารถเพิ่มรูปลงในรูปกลุ่มที่เพิ่มแล้วเพื่อเติมข้อมูลหรือเข้าถึงคุณสมบัติใด ๆ ของรูปกลุ่มได้ เพื่อเพิ่มรูปกลุ่มลงในสไลด์โดยใช้ Aspose.Slides for PHP via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่มรูปกลุ่มลงในสไลด์
1. เพิ่มรูปต่าง ๆ ลงในรูปกลุ่มที่เพิ่มไว้
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มรูปกลุ่มลงในสไลด์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # รับสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เข้าถึงคอลเลกชันรูปร่างของสไลด์
    $slideShapes = $sld->getShapes();
    # เพิ่มรูปกลุ่มลงในสไลด์
    $groupShape = $slideShapes->addGroupShape();
    # เพิ่มรูปร่างภายในรูปกลุ่มที่เพิ่มไว้
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # เพิ่มกรอบรูปกลุ่ม
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access the AltText Property**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมโค้ดตัวอย่างสำหรับการเพิ่มรูปกลุ่มและการเข้าถึงคุณสมบัติ AltText ของรูปกลุ่มบนสไลด์ เพื่อเข้าถึง AltText ของรูปกลุ่มในสไลด์โดยใช้ Aspose.Slides for PHP via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่แทนไฟล์ PPTX
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เข้าถึงคอลเลกชันรูปของสไลด์
1. เข้าถึงรูปกลุ่ม
1. เข้าถึงคุณสมบัติ [Alternative Text](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getAlternativeText)

ตัวอย่างด้านล่างเข้าถึงข้อความทางเลือกของรูปกลุ่ม

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # รับสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # เข้าถึงคอลเลกชันรูปร่างของสไลด์
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # เข้าถึงรูปกลุ่ม.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # เข้าถึงคุณสมบัติ AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

ใช่ [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/) มีเมธอด [getParentGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getparentgroup/) ซึ่งบ่งชี้การสนับสนุนโครงสร้างลำดับชั้นโดยตรง (รูปกลุ่มสามารถเป็นลูกของรูปกลุ่มอื่นได้)

**How do I control the group’s z-order relative to other objects on the slide?**

ใช้เมธอด [getZOrderPosition](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getzorderposition/) ของ [GroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/) เพื่อตรวจสอบตำแหน่งของมันในสแต็คการแสดงผล

**Can I prevent moving/editing/ungrouping?**

ได้ ส่วนการล็อกของกลุ่มเปิดให้ใช้งานผ่าน [GroupShapeLock](https://reference.aspose.com/slides/th/php-java/aspose.slides/groupshape/getgroupshapelock/) ซึ่งช่วยจำกัดการดำเนินการต่าง ๆ กับอ็อบเจ็กต์นี้