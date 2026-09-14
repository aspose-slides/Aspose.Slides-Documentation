---
title: เปลี่ยนขนาดสไลด์ของงานนำเสนอใน Python ผ่าน Java
linktitle: ขนาดสไลด์
type: docs
weight: 70
url: /th/python-java/slide-size/
keywords:
- ขนาดสไลด์
- อัตราส่วนภาพ
- มาตรฐาน
- แบบจอกว้าง
- 4:3
- 16:9
- ตั้งค่าขนาดสไลด์
- เปลี่ยนขนาดสไลด์
- ขนาดสไลด์กำหนดเอง
- ขนาดสไลด์พิเศษ
- ขนาดสไลด์เอกลักษณ์
- สไลด์เต็มขนาด
- ประเภทหน้าจอ
- ห้ามปรับขนาด
- ทำให้พอดี
- ขยายเต็ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการปรับขนาดสไลด์อย่างรวดเร็วในไฟล์ PPT, PPTX และ ODP ด้วย Python ผ่าน Java และ Aspose.Slides, และปรับแต่งงานนำเสนอให้เหมาะกับหน้าจอใดก็ได้โดยไม่สูญเสียคุณภาพ."
---
## **บทนำ**

Aspose.Slides มีเครื่องมือครบวงจรสำหรับปรับขนาดสไลด์และอัตราส่วนภาพในงานนำเสนอ PowerPoint ซึ่งสำคัญทั้งสำหรับการพิมพ์และการแสดงบนหน้าจอ

ขนาดสไลด์และอัตราส่วนภาพที่นิยม:

- **Standard (4:3 Aspect Ratio)**: เหมาะสำหรับหน้าจอและอุปกรณ์รุ่นเก่า
- **Widescreen (16:9 Aspect Ratio)**: แนะนำสำหรับโปรเจกเตอร์และจอแสดงผลสมัยใหม่

ควรรักษาความสม่ำเสมอตลอดงานนำเสนอ เนื่องจากขนาดสไลด์และอัตราส่วนภาพเดียวกันจะใช้กับสไลด์ทั้งหมด เพื่อผลลัพธ์ที่ดีที่สุด ให้ตั้งขนาดสไลด์ตั้งแต่เริ่มต้นกระบวนการสร้างงานนำเสนอเพื่อหลีกเลี่ยงปัญหา

{{% alert color="info" title="Note" %}}
โดยค่าเริ่มต้น งานนำเสนอที่สร้างด้วย Aspose.Slides จะใช้อัตราส่วนภาพมาตรฐาน 4:3
{{% /alert %}}

## **เปลี่ยนขนาดสไลด์ในงานนำเสนอ**

ตัวอย่างโค้ดนี้แสดงวิธีการเปลี่ยนขนาดสไลด์ในงานนำเสนอโดยใช้ Python ผ่าน Java กับ Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ระบุขนาดสไลด์ที่กำหนดเองในงานนำเสนอ**

หากขนาดสไลด์ทั่วไป (4:3 และ 16:9) ไม่เหมาะกับงานของคุณ คุณอาจต้องการใช้ขนาดสไลด์เฉพาะหรือไม่ซ้ำใคร ตัวอย่างเช่น หากคุณต้องการพิมพ์สไลด์เต็มขนาดจากงานนำเสนอบนรูปแบบหน้ากระดาษที่กำหนดเอง หรือหากต้องการแสดงงานนำเสนอบนประเภทหน้าจอบางประเภท คุณจะได้ประโยชน์จากการตั้งค่าขนาดสไลด์ที่กำหนดเองสำหรับงานนำเสนอของคุณ

ตัวอย่างโค้ดนี้แสดงวิธีการใช้ Aspose.Slides for Python via Java เพื่อระบุขนาดสไลด์ที่กำหนดเองสำหรับงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **จัดการเนื้อหาสไลด์หลังการปรับขนาด**

หลังจากที่คุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ เนื้อหาสไลด์ (เช่น รูปภาพหรือวัตถุต่าง ๆ) อาจเกิดการบิดเบี้ยว โดยค่าเริ่มต้นวัตถุจะถูกปรับขนาดอัตโนมัติเพื่อให้พอดีกับขนาดสไลด์ใหม่ อย่างไรก็ตามเมื่อเปลี่ยนขนาดสไลด์ของงานนำเสนอคุณสามารถกำหนดการตั้งค่าที่บ่งบอกว่า Aspose.Slides จะจัดการกับเนื้อหาในสไลด์อย่างไร

ขึ้นอยู่กับสิ่งที่คุณต้องการทำหรือบรรลุ คุณสามารถใช้การตั้งค่าเหล่านี้ได้:

- [DoNotScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  หากคุณ **ไม่** ต้องการให้วัตถุในสไลด์ถูกปรับขนาด ให้ใช้การตั้งค่านี้

- [EnsureFit](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  หากคุณต้องการย่อขนาดสไลด์ลงและต้องการให้ Aspose.Slides ปรับขนาดวัตถุให้พอดีบนสไลด์ (เพื่อหลีกเลี่ยงการสูญเสียเนื้อหา) ให้ใช้การตั้งค่านี้

- [Maximize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  หากคุณต้องการขยายขนาดสไลด์และต้องการให้ Aspose.Slides ขยายวัตถุให้สัดส่วนกับขนาดสไลด์ใหม่ ให้ใช้การตั้งค่านี้

ตัวอย่างโค้ดนี้แสดงวิธีการใช้การตั้งค่า [Maximize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#Maximize) เมื่อต้องการเปลี่ยนขนาดสไลด์ของงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าขนาดสไลด์ที่กำหนดเองโดยใช้หน่วยอื่นนอกจากนิ้ว (เช่น จุดหรือมิลลิเมตร) ได้หรือไม่?**

ได้ Aspose.Slides ใช้หน่วยจุดภายในระบบ โดย 1 จุดเท่ากับ 1/72 นิ้ว คุณสามารถแปลงหน่วยใด ๆ (เช่น มิลลิเมตรหรือเซนติเมตร) เป็นจุดและใช้ค่าที่แปลงแล้วกำหนดความกว้างและความสูงของสไลด์ได้

**ขนาดสไลด์ที่กำหนดเองขนาดใหญ่มากจะส่งผลต่อประสิทธิภาพและการใช้หน่วยความจำระหว่างการเรนเดอร์หรือไม่?**

ใช่ การเพิ่มขนาดสไลด์ (เป็นจุด) ร่วมกับสเกลการเรนเดอร์ที่สูงขึ้นจะทำให้การใช้หน่วยความจำเพิ่มขึ้นและระยะเวลาประมวลผลยาวนานขึ้น ควรเลือกขนาดสไลด์ที่เหมาะสมและปรับสเกลการเรนเดอร์ตามความจำเป็นเพื่อให้ได้คุณภาพผลลัพธ์ที่ต้องการ

**ฉันสามารถกำหนดขนาดสไลด์ที่ไม่เป็นมาตรฐานหนึ่งขนาดแล้วรวมสไลด์จากงานนำเสนอที่มีขนาดต่างกันได้หรือไม่?**

คุณไม่สามารถ [merge presentations](/slides/th/python-java/merge-presentation/) ได้ขณะสไลด์มีขนาดแตกต่างกัน — ต้องปรับขนาดงานนำเสนอหนึ่งให้ตรงกับอีกงานหนึ่งก่อน เมื่อเปลี่ยนขนาดสไลด์คุณสามารถเลือกวิธีจัดการเนื้อหาเดิมผ่านตัวเลือก [SlideSizeScaleType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/) หลังจากจัดขนาดให้ตรงกันแล้วคุณจึงสามารถรวมสไลด์พร้อมคงรูปแบบไว้ได้

**ฉันสามารถสร้างภาพย่อสำหรับรูปทรงเดี่ยวหรือพื้นที่เฉพาะของสไลด์ได้หรือไม่ และภาพย่อจะเคารพขนาดสไลด์ใหม่หรือไม่?**

ได้ Aspose.Slides สามารถเรนเดอร์ภาพย่อสำหรับ [entire slides](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) รวมถึง [selected shapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) ด้วย ภาพที่ได้จะสะท้อนขนาดสไลด์และอัตราส่วนภาพปัจจุบัน ทำให้กรอบและเรขาคณิตคงที่อย่างสม่ำเสมอ