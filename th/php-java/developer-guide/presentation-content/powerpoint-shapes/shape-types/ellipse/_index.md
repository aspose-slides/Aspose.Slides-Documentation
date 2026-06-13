---
title: เพิ่มวงรีลงในงานนำเสนอด้วย PHP
linktitle: วงรี
type: docs
weight: 30
url: /th/php-java/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่จัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้าง, จัดรูปแบบและจัดการรูปวงรีใน Aspose.Slides สำหรับ PHP ผ่าน Java สำหรับงานนำเสนอ PPT และ PPTX — รวมตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปวงรีลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides โดยครอบคลุมการสร้างวงรีแบบธรรมดา, การสร้างวงรีที่จัดรูปแบบ, และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังกล่าวถึงคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี, การควบคุมลำดับการซ้อนกัน, และการใช้เอฟเฟกต์แอนิเมชัน

## **สร้างวงรี**
เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
- รับการอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้โดยออบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) 
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีลงบนสไลด์แรก

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทน PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภท ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # เขียนไฟล์ PPTX ไปยังดิสก์
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สร้างวงรีที่จัดรูปแบบ**
เพื่อเพิ่มวงรีที่จัดรูปแบบดีขึ้นลงในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
- รับการอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้โดยออบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) 
- ตั้งค่า Fill Type ของวงรีเป็น Solid
- ตั้งค่าสีของวงรีโดยใช้เมธอด `SolidFillColor::setColor` ที่เปิดให้ใช้โดยออบเจกต์ [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) ที่เชื่อมกับออบเจกต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) 
- ตั้งค่าสีของเส้นของวงรี
- ตั้งค่าความกว้างของเส้นของวงรี
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีที่จัดรูปแบบไปยังสไลด์แรกของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทน PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภท ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # ใช้การจัดรูปแบบบางอย่างกับรูปร่างวงรี
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # ใช้การจัดรูปแบบบางอย่างกับเส้นของวงรี
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # เขียนไฟล์ PPTX ไปยังดิสก์
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งตำแหน่งและขนาดที่แน่นอนของวงรีโดยอิงหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดโดยปกติจะระบุเป็น **in points**. เพื่อให้ได้ผลลัพธ์ที่คาดการณ์ได้ ให้อิงการคำนวณของคุณกับขนาดสไลด์และแปลงมิลลิเมตรหรืออินช์ที่ต้องการเป็น points ก่อนกำหนดค่า.

**ฉันจะวางวงรีเหนือหรือใต้วัตถุอื่น ๆ (ควบคุมลำดับการซ้อน) อย่างไร?**

ปรับลำดับการวาดของวัตถุโดยนำไปข้างหน้าหรือส่งไปด้านหลัง วิธีนี้ทำให้วงรีทับซ้อนกับวัตถุอื่นหรือเปิดเผยวัตถุที่อยู่ด้านล่าง.

**ฉันจะทำให้การปรากฏหรือการเน้นของวงรีเคลื่อนไหวได้อย่างไร?**

[Apply](/slides/th/php-java/shape-animation/) เอฟเฟกต์ entrance, emphasis หรือ exit ไปยังรูปร่าง, และกำหนด trigger และ timing เพื่อจัดการว่าแอนิเมชันจะเริ่มเมื่อใดและอย่างไร.