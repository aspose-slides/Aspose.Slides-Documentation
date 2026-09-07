---
title: ส่วน
type: docs
weight: 90
url: /th/python-java/examples/elements/section/
keywords:
- ตัวอย่างโค้ด
- ส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการส่วนของงานนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน Java: เพิ่ม, เข้าถึง, ลบ, และเปลี่ยนชื่อส่วนด้วยตัวอย่างโค้ด Python."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ, และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for Python via Java** อย่างเป็นโปรแกรมมิ่ง

ติดตั้งแพคเกจตามที่อธิบายใน [การติดตั้ง](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM, แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มที่สไลด์เฉพาะ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # ระบุสไลด์ที่เป็นจุดเริ่มต้นของส่วน.
finally:
    presentation.dispose()
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # เข้าถึงส่วนโดยใช้ดัชนี.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **ลบส่วน**

ลบส่วนที่ได้เพิ่มไว้ก่อนหน้านี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # ลบส่วนแรก.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```