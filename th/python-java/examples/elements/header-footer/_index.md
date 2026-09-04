---
title: ส่วนหัวและส่วนท้าย
type: docs
weight: 220
url: /th/python-java/examples/elements/header-footer/
keywords:
- ตัวอย่างโค้ด
- ส่วนหัว
- ส่วนท้าย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides for Python via Java: เพิ่มวันที่, หมายเลขสไลด์, และข้อความกำหนดเองในงานนำเสนอรูปแบบ PPT, PPTX, และ ODP."
---
บทความนี้สาธิตวิธีเพิ่มส่วนท้ายและอัปเดตตัวยึดวันและเวลาด้วย **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วค่อยนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความไปยังพื้นที่ส่วนท้ายของสไลด์และทำให้มองเห็นได้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวยึดวันที่และเวลาในสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```