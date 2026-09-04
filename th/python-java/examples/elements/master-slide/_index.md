---
title: สไลด์มาสเตอร์
type: docs
weight: 30
url: /th/python-java/examples/elements/master-slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์มาสเตอร์
- เพิ่มสไลด์มาสเตอร์
- เข้าถึงสไลด์มาสเตอร์
- ลบสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ด้วย Aspose.Slides สำหรับ Python ผ่าน Java: สร้าง, เข้าถึง, ลบ และทำความสะอาดมาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
สไลด์มาสเตอร์เป็นระดับสูงสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **สไลด์มาสเตอร์** กำหนดองค์ประกอบการออกแบบทั่วไปเช่นพื้นหลัง, โลโก้, และรูปแบบข้อความ. **สไลด์เลเอาท์** สืบทอดมาจากสไลด์มาสเตอร์, และ **สไลด์ปกติ** สืบทอดมาจากสไลด์เลเอาท์.

บทความนี้แสดงวิธีการสร้าง, แก้ไข, และจัดการสไลด์มาสเตอร์โดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายไว้ใน [การติดตั้ง](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะทำการนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มสไลด์มาสเตอร์**

ตัวอย่างนี้แสดงวิธีการสร้างสไลด์มาสเตอร์ใหม่โดยการโคลนสไลด์เริ่มต้น. จากนั้นจะเพิ่มแบนเนอร์ชื่อบริษัทไปยังสไลด์ทั้งหมดผ่านการสืบทอดเลเอาท์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # คัดลอกสไลด์มาสเตอร์เริ่มต้น.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของสไลด์มาสเตอร์.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # กำหนดสไลด์มาสเตอร์ใหม่ให้กับสไลด์เลเอาท์.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # กำหนดสไลด์เลเอาท์ให้กับสไลด์แรกในงานนำเสนอ.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
สไลด์มาสเตอร์ให้วิธีการนำเข้าการสร้างแบรนด์ที่สอดคล้องหรือองค์ประกอบการออกแบบที่ใช้ร่วมกันในทุกสไลด์. การเปลี่ยนแปลงที่ทำกับมาสเตอร์จะถูกสะท้อนโดยอัตโนมัติในสไลด์เลเอาท์และสไลด์ปกติที่ขึ้นอยู่.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
รูปร่างและการจัดรูปแบบที่เพิ่มในสไลด์มาสเตอร์จะถูกสืบทอดโดยสไลด์เลเอาท์และต่อด้วยสไลด์ปกติทั้งหมดที่ใช้เลเอาท์เหล่านั้น. ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มในสไลด์มาสเตอร์จะถูกแสดงโดยอัตโนมัติบนสไลด์สุดท้าย.
{{% /alert %}}

![ตัวอย่างการสืบทอดมาสเตอร์](master-slide-banner.png)

## **เข้าถึงสไลด์มาสเตอร์**

คุณสามารถเข้าถึงสไลด์มาสเตอร์ผ่านคอลเลกชันมาสเตอร์ของการนำเสนอ. ตัวอย่างนี้ดึงสไลด์มาสเตอร์แรกและเปลี่ยนประเภทพื้นหลังของมัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **ลบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถลบได้โดยใช้ดัชนีหรืออ้างอิงหลังจากไม่ถูกใช้แล้ว. ตัวอย่างนี้กำหนดสไลด์มาสเตอร์ที่โคลนให้กับการนำเสนอและจากนั้นลบมาสเตอร์ต้นฉบับโดยใช้ดัชนี.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # ลบสไลด์มาสเตอร์ต้นฉบับที่ไม่ได้ใช้โดยใช้ดัชนี.
    presentation.getMasters().removeAt(0)

    # หากต้องการ, ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้โดยอ้างอิง:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

การนำเสนอบางส่วนอาจมีสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน. การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```python
import jpway
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้ทั้งหมด รวมถึงสไลด์ที่ถูกทำเครื่องหมายเป็น Preserve.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```