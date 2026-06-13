---
title: จัดการวัตถุมากลักใน PHP
linktitle: จัดการหมึก
type: docs
weight: 95
url: /th/php-java/manage-ink/
keywords:
- หมึก
- วัตถุมากลัก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการวัตถุมากลักของ PowerPoint — สร้าง, แก้ไขและจัดรูปแบบหมึกดิจิทัลด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รับตัวอย่างโค้ดสำหรับรอยหมึก, สีของแปรงและขนาด."
---
## **คำนำ**

PowerPoint มีฟังก์ชันหมึก (ink) ให้คุณวาดรูปที่ไม่ได้เป็นรูปแบบมาตรฐาน ซึ่งสามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและขั้นตอนต่าง ๆ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

Aspose.Slides มีชนิดของหมึกทั้งหมด (เช่น คลาส [Ink](https://reference.aspose.com/slides/th/php-java/aspose.slides/ink/)) ที่คุณต้องการเพื่อสร้างและจัดการวัตถุหมึก

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุมากลัก (Ink Objects)**

วัตถุบนสไลด์ PowerPoint โดยทั่วไปจะแทนด้วยวัตถุรูปทรง (shape) วัตถุรูปทรงในรูปแบบที่ง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุนั้นเอง (กรอบ) พร้อมคุณสมบัติต่าง ๆ ซึ่งรวมถึงขนาดของพื้นที่คอนเทนเนอร์, รูปร่างของคอนเทนเนอร์, พื้นหลังของคอนเทนเนอร์ เป็นต้น สำหรับข้อมูลเพิ่มเติมดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/php-java/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตามเมื่อ PowerPoint ทำงานกับวัตถุมากลัก (ink object) จะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะกำหนดโดยค่า `width` และ `height` มาตรฐาน:

![ink_powerpoint1](ink_powerpoint1.png)

## **ลายเส้น Inkshape (Inkshape Traces)**

Trace คือองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาขณะผู้ใช้เขียนหมึกดิจิทัล Trace เป็นการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุตำแหน่งพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกแสดงผลจะได้ภาพเช่นนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

คุณสามารถใช้แปรง (brush) เพื่อวาดเส้นเชื่อมจุดขององค์ประกอบ Trace แปรงมีสีและขนาดของตนเอง ซึ่งสอดคล้องกับคุณสมบัติ `Brush.Color` และ `Brush.Size`

### **ตั้งค่าสี Brush ของหมึก**

โค้ด PHP นี้แสดงวิธีตั้งค่าสีสำหรับแปรง:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ตั้งค่าขนาด Brush ของหมึก**

โค้ด PHP นี้แสดงวิธีตั้งค่าขนาดสำหรับแปรง:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

โดยทั่วไป ความกว้างและความสูงของแปรงไม่ตรงกัน ดังนั้น PowerPoint จะไม่แสดงขนาดของแปรง (ส่วนข้อมูลจะแสดงเป็นสีเทา) แต่เมื่อความกว้างและความสูงของแปรงตรงกัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุมากลักและตรวจสอบมิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่พิจารณาขนาดของแปรง—มันจะถือว่าความหนาของเส้นเป็นศูนย์ (ดูภาพสุดท้าย)

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุมากลักทั้งหมด เราต้องพิจารณาขนาดของแปรงในวัตถุ Trace ที่นี่วัตถุเป้าหมาย (วัตถุ Trace ของข้อความที่เขียนด้วยมือ) ถูกสเกลให้พอดีกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาดของแปรงจะคงที่และกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint แสดงพฤติกรรมเดียวกันเมื่อทำงานกับข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

**การอ่านต่อ**

* เพื่ออ่านเกี่ยวกับรูปทรงโดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/php-java/powerpoint-shapes/)
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าเชิงประสิทธิภาพ ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/php-java/shape-effective-properties/#getting-effective-font-height-value)