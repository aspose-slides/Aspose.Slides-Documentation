---
title: จัดการวัตถุ Ink ในการนำเสนอด้วย Python
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/python-net/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการวัตถุหมึกของ PowerPoint - สร้าง, แก้ไขและออกแบบหมึกดิจิทัลด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. รับตัวอย่างโค้ดสำหรับรอย, สีแปรงและขนาดแปรง."
---
## **บทนำ**

PowerPoint มีฟังก์ชัน Ink ที่ช่วยให้คุณวาดรูปที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์ได้  

Aspose.Slides มีเนมสเปซ [aspose.slides.ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/) ซึ่งประกอบด้วยประเภทที่คุณต้องการเพื่อสร้างและจัดการวัตถุ Ink  

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ของ PowerPoint มักจะแสดงด้วยวัตถุรูปทรง (shape). วัตถุรูปทรงในรูปแบบที่ง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมกับคุณสมบัติของมัน. ส่วนต่อมารวมถึงขนาดพื้นที่คอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ เป็นต้น. สำหรับข้อมูลเพิ่มเติม ดู [Shape Layout Format](https://docs.aspose.com/slides/th/python-net/shape-manipulations/#access-layout-formats-for-shape)。  

อย่างไรก็ตาม เมื่อ PowerPoint จัดการกับวัตถุ Ink มันจะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน. ขนาดพื้นที่คอนเทนเนอร์กำหนดโดยค่า `width` และ `height` มาตรฐาน:

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Inkshape**

Trace คือองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิทัล. Trace เป็นการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง. เมื่อจุดทั้งหมดที่เชื่อมต่อกันถูกเรนเดอร์ จะได้ภาพเช่นนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติแปรงสำหรับการวาด**

คุณสามารถใช้แปรงเพื่อวาดเส้นที่เชื่อมต่อจุดขององค์ประกอบ Trace. แปรงมีสีและขนาดของตัวเอง ซึ่งสอดคล้องกับคุณสมบัติ `Brush.color` และ `Brush.size`  

### **ตั้งค่าสีแปรง Ink**

โค้ด Python นี้แสดงวิธีตั้งค่าสีสำหรับแปรง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **ตั้งขนาดแปรง Ink**

โค้ด Python นี้แสดงวิธีตั้งค่าขนาดสำหรับแปรง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

โดยทั่วไป ความกว้างและความสูงของแปรงไม่ตรงกัน ดังนั้น PowerPoint จะไม่แสดงขนาดของแปรง (ส่วนข้อมูลจะเป็นสีเทา). แต่เมื่อความกว้างและความสูงของแปรงตรงกัน PowerPoint จะแสดงขนาดแบบนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน เราจะเพิ่มความสูงของวัตถุ Ink และตรวจสอบมิติสำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่คำนึงถึงขนาดของแปรง—มันจะสมมติว่าความหนาของเส้นเป็นศูนย์เสมอ (ดูภาพสุดท้าย)。  

ดังนั้น เพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุ Ink ทั้งหมด เราต้องคำนึงถึงขนาดแปรงของวัตถุ Trace. ที่นี่ วัตถุเป้าหมาย (วัตถุ Trace ของข้อความที่เขียนด้วยมือ) ถูกสเกลให้พอดีกับขนาดของคอนเทนเนอร์ (กรอบ). เมื่อขนาดของคอนเทนเนอร์ (กรอบ) เปลี่ยน แปรงจะคงขนาดคงที่และในทางกลับกัน:

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint แสดงพฤติกรรมเดียวกันเมื่อจัดการกับข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

**อ่านเพิ่มเติม**

* เพื่ออ่านเกี่ยวกับรูปทรงโดยทั่วไป ดูส่วน [รูปร่าง PowerPoint](https://docs.aspose.com/slides/th/python-net/powerpoint-shapes/)  
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีประสิทธิภาพ ดู [คุณสมบัติรูปทรงที่มีประสิทธิภาพ](https://docs.aspose.com/slides/th/python-net/shape-effective-properties/#get-effective-font-height-value)  