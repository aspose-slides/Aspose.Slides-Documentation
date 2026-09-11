---
title: เพิ่มสี่เหลี่ยมลงในงานนำเสนอด้วย Python ผ่าน Java
linktitle: สี่เหลี่ยม
type: docs
weight: 80
url: /th/python-java/rectangle/
keywords:
- เพิ่มสี่เหลี่ยม
- สร้างสี่เหลี่ยม
- รูปร่างสี่เหลี่ยม
- สี่เหลี่ยมง่าย
- สี่เหลี่ยมที่จัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมด้วย Aspose.Slides สำหรับ Python ผ่าน Java—ออกแบบและแก้ไขรูปร่างได้อย่างง่ายดายผ่านโปรแกรม."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปสี่เหลี่ยมลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมง่าย ๆ การสร้างสี่เหลี่ยมที่มีการจัดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX  

คุณจะได้เรียนรู้วิธีการใช้การจัดรูปแบบสี่เหลี่ยมพื้นฐาน เช่น สีพื้นเต็ม สีเส้น และความกว้างของเส้น นอกจากนี้ส่วน FAQ ของบทความยังชี้ไปยังงานที่เกี่ยวข้องกับสี่เหลี่ยม เช่น มุมโค้ง การเติมรูปภาพ เอฟเฟกต์ภาพลักษณ์ ลิงก์ไฮเปอร์เท็กซ์ การล็อกรูปร่าง ตัวเลือกการส่งออก และคุณสมบัติเชิงประสิทธิภาพ

## **เพิ่มสี่เหลี่ยมลงในสไลด์**

เพื่อเพิ่มสี่เหลี่ยมง่าย ๆ ไปยังสไลด์ที่เลือกของการนำเสนอ ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ประเภทสี่เหลี่ยมโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/)  
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมง่าย ๆ ไปยังสไลด์แรกของการนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างสี่เหลี่ยม.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # เขียนไฟล์ PPTX ไปยังดิสก์.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มสี่เหลี่ยมที่จัดรูปแบบลงในสไลด์**

เพื่อเพิ่มสี่เหลี่ยมที่จัดรูปแบบไปยังสไลด์ ให้ทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ประเภทสี่เหลี่ยมโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/)  
- ตั้งค่า [fill type](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/) ของสี่เหลี่ยมให้เป็นสีทึบ  
- ตั้งค่าสีของสี่เหลี่ยมโดยใช้เมธอด [setColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/colorformat/#setColor) บนสีเติมเต็มทึบของอ็อบเจ็กต์ [FillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/) ที่เชื่อมกับอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/)  
- ตั้งค่าสีของขอบสี่เหลี่ยม  
- ตั้งค่าความกว้างของขอบสี่เหลี่ยม  
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ขั้นตอนข้างต้นได้ทำการดำเนินการในตัวอย่างด้านล่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างสี่เหลี่ยม.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # จัดรูปแบบการเติมสีของสี่เหลี่ยม.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # จัดรูปแบบเส้นขอบของสี่เหลี่ยม.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # เขียนไฟล์ PPTX ไปยังดิสก์.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมที่มีมุมโค้งได้อย่างไร?**  
ใช้ [shape type](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/) ที่มีมุมโค้งและปรับค่ารัศมีของมุมในคุณสมบัติของรูปร่าง; สามารถกำหนดมุมโค้งแยกตามมุมได้ผ่านการปรับแต่งเรขาคณิต

**ฉันจะเติมสี่เหลี่ยมด้วยรูปภาพ (เทกเจอร์) ได้อย่างไร?**  
เลือก [fill type](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/) แบบภาพ, ระบุแหล่งที่มาของภาพ, และกำหนด [stretching/tiling modes](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillmode/)

**สี่เหลี่ยมสามารถมีเงาและแสงเรืองแสงได้หรือไม่?**  
ได้. มี [Outer/inner shadow, glow, and soft edges](/slides/th/python-java/shape-effect/) ให้เลือกพร้อมพารามิเตอร์ที่ปรับได้

**ฉันสามารถแปลงสี่เหลี่ยมให้เป็นปุ่มพร้อมลิงก์ได้หรือไม่?**  
ได้. สามารถ [Assign a hyperlink](/slides/th/python-java/manage-hyperlinks/) ให้กับการคลิกรูปร่าง (เชื่อมไปยังสไลด์, ไฟล์, ที่อยู่เว็บ หรืออีเมล)

**ฉันจะปกป้องสี่เหลี่ยมไม่ให้ย้ายหรือเปลี่ยนแปลงได้อย่างไร?**  
[Use shape locks](/slides/th/python-java/applying-protection-to-presentation/): สามารถห้ามการย้าย, การปรับขนาด, การเลือกหรือการแก้ไขข้อความเพื่อรักษาเลย์เอาต์

**ฉันสามารถแปลงสี่เหลี่ยมเป็นภาพเรสเตอร์หรือ SVG ได้หรือไม่?**  
ได้. สามารถ [render the shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) เป็นภาพด้วยขนาด/สเกลที่กำหนดหรือ [export it as SVG](/slides/th/python-java/create-shape-thumbnails/) สำหรับการใช้ในรูปแบบเวกเตอร์

**ฉันจะดึงคุณสมบัติจริง (effective) ของสี่เหลี่ยมอย่างรวดเร็วโดยคำนึงถึงธีมและการสืบทอดได้อย่างไร?**  
[Use the shape’s effective properties](/slides/th/python-java/shape-effective-properties/): API จะคืนค่าที่คำนวณแล้วซึ่งรวมสไตล์ธีม, เลย์เอาต์, และการตั้งค่าท้องถิ่น ทำให้ง่ายต่อการวิเคราะห์การจัดรูปแบบ