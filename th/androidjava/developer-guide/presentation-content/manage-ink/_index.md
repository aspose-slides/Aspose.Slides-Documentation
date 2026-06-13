---
title: จัดการวัตถุ Ink ของงานนำเสนอใน Android
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/androidjava/manage-ink/
keywords:
- หมึก
- วัตถุ Ink
- ร่องรอย Ink
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการวัตถุหมึกของ PowerPoint—สร้าง แก้ไข และออกแบบหมึกดิจิทัลด้วย Aspose.Slides สำหรับ Android รับตัวอย่างโค้ด Java สำหรับร่องรอย สีแปรง และขนาด."
---
## **แนะนำ**

PowerPoint มีฟังก์ชัน Ink เพื่อให้คุณวาดรูปทรงที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์  

Aspose.Slides มีประเภท Ink ทั้งหมด (เช่นคลาส [Ink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ink/)) ที่คุณต้องการในการสร้างและจัดการวัตถุ Ink  

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ PowerPoint มักจะแสดงด้วยวัตถุรูปทรง (shape) วัตถุรูปทรงในรูปแบบที่เรียบง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมกับคุณสมบัติต่าง ๆ ซึ่งรวมถึงขนาดพื้นที่คอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ เป็นต้น สำหรับข้อมูลเพิ่มเติม ดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/androidjava/shape-manipulations/#access-layout-formats-for-shape)  

อย่างไรก็ตาม เมื่อ PowerPoint ทำงานกับวัตถุ Ink จะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะกำหนดโดยค่ามาตรฐาน `width` และ `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace คือองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิทัล Trace คือการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดสุ่ม ตัวอย่างเมื่อเราวาดจุดเชื่อมต่อทั้งหมด จะได้ภาพดังนี้ :

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

คุณสามารถใช้ brush เพื่อวาดเส้นที่เชื่อมต่อจุดขององค์ประกอบ Trace ได้ Brush มีสีและขนาดของตนเอง ซึ่งสอดคล้องกับคุณสมบัติ `Brush.Color` และ `Brush.Size`  

### **Set Ink Brush Color**

โค้ด Java นี้แสดงวิธีตั้งค่าสีให้กับ brush :

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

โค้ด Java นี้แสดงวิธีตั้งค่าขนาดให้กับ brush :

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

โดยทั่วไป ความกว้างและความสูงของ brush ไม่ตรงกัน ทำให้ PowerPoint ไม่แสดงขนาดของ brush (ส่วนข้อมูลจะเป็นสีเทา) แต่เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดดังนี้ :

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุ Ink และตรวจสอบมิติที่สำคัญ :

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่พิจารณาขนาดของ brush — มันสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูภาพสุดท้าย)  

ดังนั้น เพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุ Ink ทั้งหมด เราต้องพิจารณาขนาดของ brush ของวัตถุ Trace ที่นี่ วัตถุเป้าหมาย (วัตถุ Trace ของข้อความที่เขียนด้วยมือ) ถูกสเกลให้ตรงกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนไป ขนาดของ brush ยังคงคงที่และกลับกันด้วย  

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint แสดงพฤติกรรมเดียวกันเมื่อทำงานกับข้อความ :

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* เพื่ออ่านเกี่ยวกับรูปร่างโดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/androidjava/powerpoint-shapes/)  
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าแบบมีประสิทธิภาพ ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/androidjava/shape-effective-properties/#getting-effective-font-height-value)  