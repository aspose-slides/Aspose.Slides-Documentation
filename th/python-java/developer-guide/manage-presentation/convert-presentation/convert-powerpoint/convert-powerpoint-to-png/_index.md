---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน Python
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/python-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Python
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint เป็นภาพ PNG ใน Python ผ่าน Java. ส่งออกงานนำเสนอ PPT, PPTX และ ODP ด้วยสเกลที่กำหนดหรือขนาดภาพที่แม่นยำ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็นรูปภาพ PNG ด้วย Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถโหลดไฟล์ PPT, PPTX และ ODP, เรนเดอร์สไลด์แต่ละหน้าและบันทึกเป็นไฟล์ PNG แยกกันได้

ตัวอย่างยังแสดงวิธีควบคุมขนาดผลลัพธ์โดยใช้สเกลแฟกเตอร์หรือระบุความกว้างและความสูงที่แน่นอน ตัวอย่างแต่ละอันจะเริ่มเครื่องเสมือน Java หากจำเป็นและจะปล่อยทรัพยากรของงานนำเสนอและภาพหลังการใช้งาน

## **แปลง PowerPoint เป็น PNG**

1. โหลดไฟล์อินพุตด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. ดึงสไลด์โดยใช้เมธอด [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides)  
3. เรนเดอร์สไลด์แต่ละหน้าโดยใช้เมธอด [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage)  
4. บันทึกรูปภาพที่เรนเดอร์ด้วย [ImageFormat.Png](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/#Png) แล้วปล่อยทรัพยากรของมัน

ตัวอย่าง Python ต่อไปนี้ส่งออกสไลด์ทั้งหมดด้วยขนาดเริ่มต้นของแต่ละสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PNG ด้วยสเกลที่กำหนดเอง**

ส่งค่าสเกลแนวนอนและแนวตั้งไปยังเมธอด [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) เพื่อเพิ่มหรือ ลดขนาดผลลัพธ์ ตัวอย่างเช่น สไลด์ขนาด 720 × 540 จุด ที่เรนเดอร์ด้วยสเกลแฟกเตอร์ 2 ทั้งสองแกนจะได้ภาพ 1440 × 1080 พิกเซล

ใช้ค่าสเกลที่เท่ากันเพื่อรักษาอัตราส่วนภาพของสไลด์ ค่าสเกลที่ต่างกันจะทำให้สไลด์ถูกขยายในแนวนอนหรือแนวตั้ง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

เพื่อระบุขนาดพิกเซลที่แม่นยำ ให้ส่งอ็อบเจกต์ Java `Dimension` ที่มีความกว้างและความสูงที่ต้องการไปยังเมธอด [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) เลือกขนาดที่มีอัตราส่วนเดียวกับสไลด์ต้นฉบับเพื่อหลีกเลี่ยงการบิดเบือน

ตัวอย่างต่อไปนี้บันทึกสไลด์แต่ละหน้าเป็นไฟล์ PNG ขนาด 960 × 720 พิกเซล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกรูปร่างเดี่ยว เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกรายการสไลด์ทั้งหมดได้หรือไม่?**

ใช่ Aspose.Slides รองรับการ[สร้างภาพย่อสำหรับรูปร่างเดี่ยว](/slides/th/python-java/create-shape-thumbnails/) ซึ่งคุณสามารถบันทึกเป็นไฟล์ PNG ได้

**ฉันสามารถแปลงงานนำเสนอแบบขนานบนเซิร์ฟเวอร์ได้หรือไม่?**

ใช้อินสแตนซ์ Presentation แยกกันสำหรับแต่ละเธรดหรือโพรเซส และใช้เส้นทางออกที่ไม่ซ้ำกันเพื่อป้องกันไฟล์จากการถูกเขียนทับ อย่าแชร์อินสแตนซ์ Presentation ระหว่างเธรด ดูหัวข้อ[Multithreading](/slides/th/python-java/multithreading/)

**ข้อจำกัดของรุ่นทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะใส่ลายน้ำบนภาพผลลัพธ์และใช้[ข้อจำกัดอื่น](/slides/th/python-java/licensing/) ให้ทำการประยุกต์ใช้ลิขสิทธิ์เพื่อเอาข้อจำกัดเหล่านี้ออก