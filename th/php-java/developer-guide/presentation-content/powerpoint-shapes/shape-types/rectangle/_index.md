---
title: เพิ่มสี่เหลี่ยมผืนผ้าในงานนำเสนอด้วย PHP
linktitle: สี่เหลี่ยมผืนผ้า
type: docs
weight: 80
url: /th/php-java/rectangle/
keywords:
- เพิ่มสี่เหลี่ยมผืนผ้า
- สร้างสี่เหลี่ยมผืนผ้า
- รูปร่างสี่เหลี่ยมผืนผ้า
- สี่เหลี่ยมผืนผ้าง่าย
- สี่เหลี่ยมผืนผ้าจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มพลังให้การนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมผืนผ้าผ่าน Aspose.Slides สำหรับ PHP ผ่าน Java — ออกแบบและแก้ไขรูปร่างได้อย่างง่ายดายโดยใช้โปรแกรม"
---
## **ภาพรวม**

บทความนี้แสดงวิธีเพิ่มรูปร่างสี่เหลี่ยมผืนผ้าลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมผืนผ้าง่าย การสร้างสี่เหลี่ยมผืนผ้าจัดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX

คุณจะได้เห็นวิธีการปรับรูปแบบพื้นฐานของสี่เหลี่ยมผืนผ้า เช่น สีเติมแบบทึบ สีเส้น และความกว้างของเส้น นอกจากนี้ ส่วนคำถามที่พบบ่อยของบทความยังชี้ไปยังงานที่เกี่ยวข้องกับสี่เหลี่ยมผืนผ้า เช่น มุมโค้ง การเติมรูปภาพ เอฟเฟกต์ภาพเชิงวิชวล ไฮเปอร์ลิงก์ การล็อครูปร่าง ตัวเลือกการส่งออก และคุณสมบัติที่มีผล

## **เพิ่มสี่เหลี่ยมผืนผ้าลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมผืนผ้าง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ชนิด Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) จากออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/).
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมผืนผ้าง่ายลงในสไลด์แรกของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape แบบ ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # เขียนไฟล์ PPTX ไปยังดิสก์
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มสี่เหลี่ยมผืนผ้าจัดรูปแบบลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมผืนผ้าจัดรูปแบบลงในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation).
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ชนิด Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addAutoShape) จากออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/).
- ตั้งค่า [Fill Type](https://reference.aspose.com/slides/th/php-java/aspose.slides/FillType) ของ Rectangle เป็น Solid.
- ตั้งค่าสีของ Rectangle ด้วยเมธอด [ColorFormat::setColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorformat/#setColor) ที่เปิดให้ใช้งานโดยออบเจ็กต์ [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) ที่เชื่อมกับออบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/).
- ตั้งค่าสีของเส้นของ Rectangle.
- ตั้งค่าความกว้างของเส้นของ Rectangle.
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ขั้นตอนข้างต้นได้ทำในตัวอย่างด้านล่าง

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิด ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # ปรับรูปแบบบางอย่างให้กับรูปร่าง ellipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # ปรับรูปแบบบางอย่างให้กับเส้นของ Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # เขียนไฟล์ PPTX ไปยังดิสก์
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมผืนผ้าที่มีมุมโค้งได้อย่างไร?**

ใช้ประเภทรูปร่างที่มีมุมโค้ง [shape type](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapetype/) แล้วปรับค่ารัศมีของมุมในคุณสมบัติของรูปร่าง; สามารถกำหนดการโค้งแต่ละมุมได้ผ่านการปรับรูปทรงเรขาคณิต

**ฉันจะเติมสี่เหลี่ยมผืนผ้าด้วยรูปภาพ (เทกเจอร์) ได้อย่างไร?**

เลือก [fill type](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ประเภท picture, ระบุแหล่งที่มาของรูปภาพ, แล้วกำหนดโหมดการขยาย/การเรียงกระเบื้องตามที่ต้องการ

**สี่เหลี่ยมผืนฝ้าสามารถมีเงาและแสงเรืองแสงได้หรือไม่?**

ได้. [Outer/inner shadow, glow, and soft edges](/slides/th/php-java/shape-effect/) มีให้ใช้งานพร้อมพารามิเตอร์ที่ปรับได้

**ฉันสามารถเปลี่ยนสี่เหลี่ยมผืนผ้าเป็นปุ่มพร้อมไฮเปอร์ลิงก์ได้หรือไม่?**

ได้. [Assign a hyperlink](/slides/th/php-java/manage-hyperlinks/) ให้กับการคลิกรูปร่าง (กระโดดไปยังสไลด์, ไฟล์, ที่อยู่เว็บ หรืออีเมล)

**ฉันจะป้องกันสี่เหลี่ยมผืนผ้าไม่ให้ย้ายหรือเปลี่ยนแปลงได้อย่างไร?**

ใช้การล็อครูปร่าง: สามารถห้ามการย้าย, การปรับขนาด, การเลือก, หรือการแก้ไขข้อความ เพื่อรักษาเลย์เอาต์

**ฉันสามารถแปลงสี่เหลี่ยมผืนผ้าเป็นภาพเรสเตอร์หรือ SVG ได้หรือไม่?**

ได้. คุณสามารถ [render the shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) เป็นภาพโดยกำหนดขนาด/สเกล หรือ [export it as SVG](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) สำหรับการใช้งานแบบเวกเตอร์

**ฉันจะรับคุณสมบัติที่แท้จริง (effective) ของสี่เหลี่ยมผืนผ้าโดยพิจารณาธีมและการสืบทอดอย่างรวดเร็วได้อย่างไร?**

[Use the shape’s effective properties](/slides/th/php-java/shape-effective-properties/): API จะคืนค่าที่คำนวณแล้วซึ่งรวมถึงสไตล์ธีม, เลย์เอาต์, และการตั้งค่าท้องถิ่น ทำให้การวิเคราะห์รูปแบบง่ายขึ้น