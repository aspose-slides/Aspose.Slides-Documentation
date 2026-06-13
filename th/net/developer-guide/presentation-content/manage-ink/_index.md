---
title: จัดการวัตถุ Ink ในการนำเสนอด้วย .NET
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/net/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการวัตถุ Ink ของ PowerPoint—สร้าง, แก้ไขและกำหนดสไตล์ให้กับหมึกดิจิทัลด้วย Aspose.Slides สำหรับ .NET. รับตัวอย่างโค้ดสำหรับรอย, สีแปรงและขนาด."
---
## **บทนำ**

PowerPoint มีฟังก์ชัน Ink เพื่อให้คุณวาดรูปที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์ได้  

Aspose.Slides ให้บริการอินเตอร์เฟส [Aspose.Slides.Ink](https://reference.aspose.com/slides/th/net/aspose.slides.ink/) ซึ่งมีประเภทที่คุณต้องการเพื่อสร้างและจัดการวัตถุ Ink  

## **ความแตกต่างระหว่างออบเจ็กต์ทั่วไปและออบเจ็กต์ Ink**

ออบเจ็กต์บนสไลด์ PowerPoint จะถูกแสดงโดยออบเจ็กต์รูปทรง (shape) โดยรูปทรงในรูปแบบง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของออบเจ็กต์เอง (กรอบ) พร้อมกับคุณสมบัติของมัน ซึ่งรวมถึงขนาดของคอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ ฯลฯ สำหรับข้อมูลเพิ่มเติม ดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/net/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตาม เมื่อ PowerPoint ทำงานกับออบเจ็กต์ Ink จะละเลยคุณสมบัติทั้งหมดของกรอบออบเจ็กต์ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์ถูกกำหนดโดยค่า `width` และ `height` มาตรฐาน:

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Inkshape**

รอย (Trace) เป็นองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิทัล รอยเป็นการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกเรนเดอร์ จะได้ภาพเช่นนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

คุณสามารถใช้ Brush เพื่อวาดเส้นเชื่อมจุดขององค์ประกอบรอย Brush มีสีและขนาดของเองโดยสอดคล้องกับคุณสมบัติ `Brush.Color` และ `Brush.Size`

### **ตั้งค่าสี Brush ของ Ink**

โค้ด C# นี้แสดงวิธีตั้งค่าสีของ Brush:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **ตั้งค่าขนาด Brush ของ Ink** 

โค้ด C# นี้แสดงวิธีตั้งค่าขนาดของ Brush:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

โดยทั่วไป ความกว้างและความสูงของ Brush ไม่ตรงกัน ดังนั้น PowerPoint จะแสดงขนาดของ Brush ไม่ได้ (ส่วนข้อมูลจะเป็นสีเทา) อย่างไรก็ตามเมื่อความกว้างและความสูงของ Brush ตรงกัน PowerPoint จะแสดงขนาดแบบนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อให้เห็นชัดเจน เราจะเพิ่มความสูงของออบเจ็กต์ Ink และตรวจสอบมิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่พิจารณาขนาดของ Brush — มันจะถือว่าความหนาของเส้นเป็นศูนย์เสมอ (ดูภาพสุดท้าย)  

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นได้ของออบเจ็กต์ Ink ทั้งหมด เราต้องพิจารณาขนาด Brush ของออบเจ็กต์รอย ที่นี่ออบเจ็กต์เป้าหมาย (ออบเจ็กต์รอยข้อความที่เขียนด้วยมือ) ถูกสเกลให้ตรงกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาด Brush ยังคงคงที่ และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint จะทำพฤติกรรมเดียวกันเมื่อทำงานกับข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

**การอ่านเพิ่มเติม**

* เพื่ออ่านเกี่ยวกับรูปทรงโดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/net/powerpoint-shapes/)  
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่า Effective ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/net/shape-effective-properties/#get-effective-font-height-value)  