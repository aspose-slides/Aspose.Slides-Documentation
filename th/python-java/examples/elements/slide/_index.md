---
title: สไลด์
type: docs
weight: 10
url: /th/python-java/examples/elements/slide/
keywords:
- ตัวอย่างโค้ด
- สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, เข้าถึง, คัดลอก, จัดลำดับใหม่, และลบสไลด์ด้วยตัวอย่างโค้ด Python สำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้ให้ตัวอย่างที่แสดงวิธีการเพิ่ม, เข้าถึง, คัดลอก, จัดลำดับใหม่, และลบสไลด์โดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มสไลด์**

เพื่อเพิ่มสไลด์ใหม่, ก่อนอื่นให้เลือกเค้าโครง. ตัวอย่างนี้ใช้เค้าโครงเปล่าเพื่อเพิ่มสไลด์ว่างลงในงานนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="หมายเหตุ" %}}
แต่ละเค้าโครงสไลด์สืบทอดมาจากสไลด์แม่ ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวล็อกข้อความ. รูปภาพด้านล่างแสดงวิธีที่สไลด์แม่และเค้าโครงที่เชื่อมโยงกันถูกจัดระเบียบใน PowerPoint.
{{% /alert %}}

![ความสัมพันธ์ระหว่างสไลด์แม่และเค้าโครง](master-layout-slide.png)

## **เข้าถึงสไลด์ตามดัชนี**

เข้าถึงสไลด์โดยใช้ดัชนีเริ่มจากศูนย์, หรือค้นหาดัชนีของสไลด์จากอ้างอิง. สิ่งนี้มีประโยชน์สำหรับการวนซ้ำหรือการแก้ไขสไลด์เฉพาะ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # เพิ่มสไลด์ว่างอีกหนึ่งสไลด์.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # เข้าถึงสไลด์ตามดัชนี.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # รับดัชนีของสไลด์จากอ้างอิง, จากนั้นเข้าถึงตามดัชนี.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **คัดลอกสไลด์**

คัดลอกสไลด์ที่มีอยู่. สไลด์ที่คัดลอกจะถูกเพิ่มโดยอัตโนมัติไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **จัดลำดับสไลด์ใหม่**

เปลี่ยนลำดับของสไลด์โดยย้ายสไลด์หนึ่งไปยังดัชนีใหม่. ตัวอย่างนี้ย้ายสไลด์ที่คัดลอกไปยังตำแหน่งแรก.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **ลบสไลด์**

ลบสไลด์โดยส่งอ้างอิงของสไลด์ให้กับคอลเลกชันสไลด์. ตัวอย่างนี้เพิ่มสไลด์ที่สองและจากนั้นลบสไลด์ต้นฉบับ, เหลือเพียงสไลด์ใหม่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```