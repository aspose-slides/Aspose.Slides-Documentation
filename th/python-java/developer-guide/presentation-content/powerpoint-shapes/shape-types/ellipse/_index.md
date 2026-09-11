---
title: เพิ่มวงรีลงในงานนำเสนอใน Python ผ่าน Java
linktitle: วงรี
type: docs
weight: 30
url: /th/python-java/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่กำหนดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการสร้าง, กำหนดรูปแบบ, และจัดการรูปวงรีใน Aspose.Slides สำหรับ Python ผ่าน Java ในงานนำเสนอ PPT และ PPTX — รวมตัวอย่างโค้ด Python"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปวงรีลงในสไลด์ PowerPoint ด้วย Aspose.Slides ครอบคลุมการสร้างวงรีแบบง่าย การสร้างวงรีที่กำหนดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังอธิบายคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี การควบคุมลำดับการซ้อนกัน และการใช้เอฟเฟกต์แอนิเมชัน

## **สร้างวงรี**

เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ ให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
- รับอ้างอิงสไลด์ตามดัชนีของมัน
- เพิ่มวงรีโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ของอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/) 
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างต่อไปนี้เพิ่มวงรีลงในสไลด์แรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปวงรี
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างวงรีที่กำหนดรูปแบบ**

เพื่อเพิ่มวงรีที่กำหนดรูปแบบลงในสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
- รับอ้างอิงสไลด์ตามดัชนีของมัน
- เพิ่มวงรีโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ของอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/) 
- ตั้งค่าชนิดการเติมของวงรีเป็นแบบทึบ
- ตั้งค่าสีเติมของวงรีผ่าน [getSolidFillColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/#getSolidFillColor) บนอ็อบเจกต์ [FillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/) ที่เชื่อมโยงกับอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) 
- ตั้งค่าสีของขอบวงรี
- ตั้งค่าความกว้างของขอบวงรี
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างต่อไปนี้เพิ่มวงรีที่กำหนดรูปแบบลงในสไลด์แรกของการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
presentation = Presentation()
try:
    # ดึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปทรงวงรี
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # กำหนดรูปแบบการเติมของวงรี
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # กำหนดรูปแบบเส้นขอบของวงรี
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าตำแหน่งและขนาดที่แน่นอนของวงรีโดยอ้างอิงหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดโดยทั่วไปจะระบุ **in points**. เพื่อให้ได้ผลลัพธ์ที่คาดเดาได้ ให้คำนวณอิงจากขนาดของสไลด์และแปลงมิลลิเมตรหรืออินช์ที่ต้องการเป็นจุดก่อนกำหนดค่า

**ฉันจะวางวงรีเหนือหรือใต้วัตถุอื่น ๆ (ควบคุมลำดับการซ้อนกัน) ได้อย่างไร?**

ปรับลำดับการวาดของวัตถุโดยนำมันไปยังด้านหน้า หรือส่งไปยังด้านหลัง การทำเช่นนี้ทำให้วงรีทับซ้อนกับวัตถุอื่นหรือเผยให้เห็นวัตถุที่อยู่ด้านล่างได้

**ฉันจะทำแอนิเมชันให้วงรีปรากฏหรือเน้นอย่างไร?**

[นำไปใช้](/slides/th/python-java/shape-animation/) เอฟเฟกต์การเข้ามา, เน้น, หรือออกจากรูปทรง และกำหนดทริกเกอร์และเวลาเพื่อควบคุมว่าการแอนิเมชันจะดำเนินการเมื่อใดและอย่างไร