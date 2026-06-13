---
title: จัดการออบเจ็กต์ Ink ของงานนำเสนอใน Java
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/java/manage-ink/
keywords:
- หมึก
- ออบเจ็กต์หมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการออบเจ็กต์ Ink ของ PowerPoint — สร้าง แก้ไข และกำหนดรูปแบบหมึกดิจิทัลด้วย Aspose.Slides สำหรับ Java รับตัวอย่างโค้ดสำหรับรอย, สีแปรง & ขนาดแปรง."
---
## **บทนำ**

PowerPoint มีฟังก์ชัน ink เพื่อให้คุณวาดรูปที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์ได้  

Aspose.Slides ให้ประเภท Ink ทั้งหมด (เช่น [Ink](https://reference.aspose.com/slides/th/java/com.aspose.slides/ink/) class) ที่คุณต้องการเพื่อสร้างและจัดการวัตถุ ink  

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ PowerPoint โดยทั่วไปจะแสดงเป็นวัตถุ shape วัตถุ shape ในรูปแบบที่ง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมคุณสมบัติต่าง ๆ ซึ่งรวมถึงขนาดพื้นที่คอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ เป็นต้น สำหรับข้อมูลเพิ่มเติมดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/java/shape-manipulations/#access-layout-formats-for-shape)  

อย่างไรก็ตามเมื่อ PowerPoint ทำงานกับวัตถุ ink มันจะละเลยคุณสมบัติต่าง ๆ ของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์ถูกกำหนดโดยค่ามาตรฐาน `width` และ `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace คือองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน ink ดิจิทัล Trace คือการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อรันจุดทั้งหมดที่เชื่อมต่อกัน จะได้ภาพดังนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

คุณสามารถใช้ brush วาดเส้นที่เชื่อมจุดขององค์ประกอบ trace ได้ Brush มีสีและขนาดของตนเอง ซึ่งสอดคล้องกับคุณสมบัติ `Brush.Color` และ `Brush.Size`  

### **Set Ink Brush Color**

โค้ด Java นี้แสดงวิธีตั้งค่าสีสำหรับ brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set Ink Brush Size**

โค้ด Java นี้แสดงวิธีตั้งค่าขนาดสำหรับ brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

โดยทั่วไปความกว้างและความสูงของ brush ไม่ตรงกัน จึงทำให้ PowerPoint ไม่แสดงขนาดของ brush (ส่วนข้อมูลเป็นสีเทา) แต่เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุ ink และตรวจสอบมิติสำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่พิจารณาขนาดของ brush — มันถือว่าความหนาของเส้นเป็นศูนย์ (ดูภาพสุดท้าย)  

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุ ink ทั้งหมด เราต้องพิจารณาขนาด brush ของวัตถุ trace ที่นี่ วัตถุเป้าหมาย (วัตถุ trace ของข้อความที่เขียนด้วยมือ) ถูกยืดขนาดตามคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์ (กรอบ) เปลี่ยนแปลง ขนาดของ brush จะคงที่และกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint แสดงพฤติกรรมเดียวกันเมื่อตอบสนองต่อข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* เพื่ออ่านเกี่ยวกับ shape โดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/java/powerpoint-shapes/)
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีผล ดูที่ [Shape Effective Properties](https://docs.aspose.com/slides/th/java/shape-effective-properties/#getting-effective-font-height-value)