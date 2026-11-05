---
title: เปลี่ยนขนาดสไลด์การนำเสนอใน Python ผ่าน Java
linktitle: ขนาดสไลด์
type: docs
weight: 70
url: /th/python-java/slide-size/
keywords:
- ขนาดสไลด์
- อัตราส่วนภาพ
- มาตรฐาน
- จอกว้าง
- 4:3
- 16:9
- ตั้งค่าขนาดสไลด์
- เปลี่ยนขนาดสไลด์
- ขนาดสไลด์กำหนดเอง
- ขนาดสไลด์พิเศษ
- ขนาดสไลด์เอกลักษณ์
- สไลด์ขนาดเต็ม
- ประเภทหน้าจอ
- ไม่สเกล
- ให้พอดี
- ขยายเต็ม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีปรับขนาดสไลด์อย่างรวดเร็วในไฟล์ PPT, PPTX และ ODP ด้วย Python ผ่าน Java และ Aspose.Slides พร้อมปรับการนำเสนอให้เหมาะกับทุกหน้าจอโดยไม่เสียคุณภาพ."
---
## **บทนำ**

Aspose.Slides มีเครื่องมือครบวงจรสำหรับปรับขนาดสไลด์และอัตราส่วนภาพในงานนำเสนอ PowerPoint ซึ่งสำคัญสำหรับการพิมพ์และการแสดงบนหน้าจอ

ขนาดสไลด์และอัตราส่วนที่นิยม:

- **Standard (4:3 Aspect Ratio)**: เหมาะสำหรับหน้าจอและอุปกรณ์รุ่นเก่า.
- **Widescreen (16:9 Aspect Ratio)**: แนะนำสำหรับโปรเจคเตอร์และจอแสดงผลสมัยใหม่.

ควรตรวจสอบให้ความสอดคล้องตลอดการนำเสนอ เนื่องจากขนาดสไลด์และอัตราส่วนภาพเดียวกันจะใช้กับสไลด์ทั้งหมด เพื่อผลลัพธ์ที่ดีที่สุด ให้ตั้งค่าขนาดสไลด์ตั้งแต่เริ่มสร้างการนำเสนอเพื่อหลีกเลี่ยงปัญหา.

{{% alert color="info" title="Note" %}}
โดยค่าเริ่มต้น การนำเสนอที่สร้างด้วย Aspose.Slides จะใช้อัตราส่วน 4:3 มาตรฐาน.
{{% /alert %}}

หน้าโน้ตและหน้าแจกเอกสารมีขนาดแยกจากสไลด์ปกติ ดูที่ [ขนาดหน้าโน้ต](/slides/th/python-java/notes-size/) เพื่อเปลี่ยนขนาดและการจัดวางของพวกมัน.

## **เปลี่ยนขนาดสไลด์ในงานนำเสนอ**

ตัวอย่างโค้ดนี้แสดงวิธีการเปลี่ยนขนาดสไลด์ในงานนำเสนอโดยใช้ Python ผ่าน Java ด้วย Aspose.Slides:

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

## **ระบุขนาดสไลด์แบบกำหนดเองในงานนำเสนอ**

หากคุณพบว่าขนาดสไลด์ทั่วไป (4:3 และ 16:9) ไม่เหมาะกับงานของคุณ คุณอาจต้องการใช้ขนาดสไลด์ที่กำหนดเฉพาะหรือเป็นเอกลักษณ์ ตัวอย่างเช่น หากคุณต้องการพิมพ์สไลด์ขนาดเต็มจากงานนำเสนอของคุณบนรูปแบบหน้ากระดาษที่กำหนดเอง หรือหากคุณต้องการแสดงงานนำเสนอบนประเภทหน้าจอบางประเภท คุณจะได้รับประโยชน์จากการตั้งค่าขนาดสไลด์แบบกำหนดเองสำหรับงานนำเสนอของคุณ.

ตัวอย่างโค้ดนี้แสดงวิธีการใช้ Aspose.Slides for Python via Java เพื่อระบุขนาดสไลด์แบบกำหนดเองสำหรับงานนำเสนอ:

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

## **จัดการเนื้อหาสไลด์หลังจากปรับขนาด**

หลังจากที่คุณเปลี่ยนขนาดสไลด์ของงานนำเสนอ เนื้อหาสไลด์ (เช่น รูปภาพหรือวัตถุต่าง ๆ) อาจบิดเบี้ยวได้ โดยค่าเริ่มต้น วัตถุจะถูกปรับขนาดอัตโนมัติเพื่อให้พอดีกับขนาดสไลด์ใหม่ อย่างไรก็ตาม เมื่อเปลี่ยนขนาดสไลด์ของงานนำเสนอ คุณสามารถระบุการตั้งค่าที่กำหนดว่า Aspose.Slides จะจัดการกับเนื้อหาบนสไลด์อย่างไร

ขึ้นอยู่กับสิ่งที่คุณต้องการทำหรือบรรลุ คุณสามารถใช้การตั้งค่าใด ๆ ต่อไปนี้:

- [DoNotScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  หากคุณไม่ต้องการให้วัตถุบนสไลด์ถูกปรับขนาด ให้ใช้การตั้งค่านี้.

- [EnsureFit](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  หากคุณต้องการปรับขนาดให้สไลด์เล็กลงและต้องการให้ Aspose.Slides ปรับขนาดวัตถุของสไลด์ให้เล็กลงเพื่อให้วัตถุทั้งหมดพอดีบนสไลด์ (วิธีนี้จะช่วยป้องกันการสูญเสียเนื้อหา) ให้ใช้การตั้งค่านี้.

- [Maximize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#Maximize)

  หากคุณต้องการปรับขนาดให้สไลด์ใหญ่ขึ้นและต้องการให้ Aspose.Slides ขยายวัตถุของสไลด์เพื่อให้สัดส่วนตรงกับขนาดสไลด์ใหม่ ให้ใช้การตั้งค่านี้.

ตัวอย่างโค้ดนี้แสดงวิธีการใช้การตั้งค่า [Maximize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/#Maximize) เมื่อเปลี่ยนขนาดสไลด์ของงานนำเสนอ:

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

**ฉันสามารถตั้งค่าขนาดสไลด์แบบกำหนดเองโดยใช้หน่วยอื่นนอกจากนิ้ว (เช่น จุดหรือมิลลิเมตร) ได้หรือไม่?**

ใช่ Aspose.Slides ใช้หน่วยจุดเป็นหน่วยภายใน โดย 1 จุดเท่ากับ 1/72 นิ้ว คุณสามารถแปลงหน่วยใด ๆ (เช่น มิลลิเมตรหรือเซนติเมตร) ไปเป็นจุดและใช้ค่าที่แปลงแล้วกำหนดความกว้างและความสูงของสไลด์.

**ขนาดสไลด์แบบกำหนดเองที่ใหญ่มากจะส่งผลต่อประสิทธิภาพและการใช้หน่วยความจำระหว่างการเรนเดอร์หรือไม่?**

ใช่ ขนาดสไลด์ที่ใหญ่ขึ้น (เป็นจุด) พร้อมกับระดับสเกลการเรนเดอร์ที่สูงกว่าจะทำให้ใช้หน่วยความจำเพิ่มขึ้นและเวลาการประมวลผลนานขึ้น ควรเลือกขนาดสไลด์ที่เป็นประโยชน์และปรับระดับสเกลการเรนเดอร์เฉพาะเมื่อต้องการคุณภาพเอาต์พุตที่ต้องการ.

**ฉันสามารถกำหนดขนาดสไลด์ที่ไม่เป็นมาตรฐานหนึ่งขนาดแล้วรวมสไลด์จากงานนำเสนอที่มีขนาดต่างกันได้หรือไม่?**

คุณไม่สามารถ [merge presentations](/slides/th/python-java/merge-presentation/) ได้ขณะที่มีขนาดสไลด์ที่ต่างกัน — ก่อนอื่นให้ปรับขนาดงานนำเสนอหนึ่งให้ตรงกับอีกงานหนึ่ง เมื่อเปลี่ยนขนาดสไลด์ คุณสามารถเลือกวิธีการจัดการกับเนื้อหาที่มีอยู่ผ่านตัวเลือก [SlideSizeScaleType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/) หลังจากปรับขนาดให้ตรงกัน คุณสามารถรวมสไลด์โดยคงรูปแบบไว้ได้.

**ฉันสามารถสร้างภาพย่อสำหรับรูปทรงเดียวหรือบริเวณเฉพาะของสไลด์ได้หรือไม่ และภาพย่อเหล่านั้นจะเคารพขนาดสไลด์ใหม่หรือไม่?**

ใช่ Aspose.Slides สามารถสร้างภาพย่อสำหรับ [entire slides](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) รวมถึง [selected shapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) ได้ ภาพที่ได้จะแสดงขนาดสไลด์และอัตราส่วนภาพปัจจุบัน ทำให้กรอบและเรขาคณิตคงที่.