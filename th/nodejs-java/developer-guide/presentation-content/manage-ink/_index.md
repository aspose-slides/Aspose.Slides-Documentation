---
title: จัดการวัตถุ Ink ของการนำเสนอใน JavaScript
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/nodejs-java/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการวัตถุหมึก PowerPoint—สร้าง, แก้ไขและออกแบบหมึกดิจิทัลด้วย Aspose.Slides สำหรับ Node.js. รับตัวอย่างโค้ด JavaScript สำหรับรอย, สีแปรงและขนาด."
---
## **บทนำ**

PowerPoint มีฟังก์ชัน ink ที่ช่วยให้คุณวาดรูปแบบที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์  

Aspose.Slides ให้ประเภท Ink ทั้งหมด (เช่นคลาส [Ink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ink/)) ที่คุณต้องการเพื่อสร้างและจัดการวัตถุ ink  

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ PowerPoint มักจะแสดงเป็นวัตถุรูปร่าง (shape objects) โดยวัตถุรูปร่างในรูปแบบที่ง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบของมัน) พร้อมกับคุณสมบัติต่าง ๆ ของมัน ซึ่งรวมถึงขนาดพื้นที่คอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ เป็นต้น สำหรับข้อมูลเพิ่มเติมดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)  

อย่างไรก็ตาม เมื่อ PowerPoint ทำงานกับวัตถุ ink มันจะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะกำหนดโดยค่ามาตรฐาน `width` และ `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Inkshape**

Trace คือองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียนหมึกดิจิทัล Trace เป็นการบันทึกที่อธิบายลำดับของจุดเชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกเรนเดอร์ จะได้รูปภาพดังนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

คุณสามารถใช้ brush เพื่อวาดเส้นที่เชื่อมโยงจุดขององค์ประกอบ trace ได้ Brush มีสีและขนาดของมันเอง ซึ่งสอดคล้องกับเมธอด `Brush.setColor` และ `Brush.setSize`  

### **ตั้งค่าสี Brush Ink**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าสีสำหรับ brush:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ตั้งค่าขนาด Brush Ink**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าขนาดสำหรับ brush:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

โดยทั่วไป ความกว้างและความสูงของ brush จะไม่ตรงกัน ทำให้ PowerPoint ไม่แสดงขนาดของ brush (ส่วนข้อมูลจะเป็นสีเทา) แต่เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดของมันดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน เราจะเพิ่มความสูงของวัตถุ ink และตรวจสอบมิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่คำนึงถึงขนาดของ brush -- มันจะถือว่าความหนาของเส้นเป็นศูนย์เสมอ (ดูรูปสุดท้าย)  

ดังนั้น เพื่อตรวจสอบพื้นที่ที่มองเห็นได้ของวัตถุ ink ทั้งหมด เราต้องคำนึงถึงขนาดของ brush ของวัตถุ trace ที่นี่ วัตถุเป้าหมาย (วัตถุ trace ของข้อความที่เขียนด้วยมือ) ถูกปรับสเกลไปตามขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์ (กรอบ) เปลี่ยนแปลง ขนาดของ brush จะคงที่และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint มีพฤติกรรมเดียวกันเมื่อทำงานกับข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

**อ่านต่อ**

* เพื่ออ่านเกี่ยวกับรูปทรงทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/nodejs-java/powerpoint-shapes/)
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าแบบมีประสิทธิภาพ ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).