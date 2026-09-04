---
title: เสียง
type: docs
weight: 70
url: /th/python-java/examples/elements/audio/
keywords:
- ตัวอย่างโค้ด
- เสียง
- เฟรมเสียง
- เพิ่มเสียง
- เข้าถึงเสียง
- ลบเสียง
- การเล่นเสียง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเพิ่ม, เข้าถึง, ลบ และกำหนดค่าเฟรมเสียงในงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้แสดงวิธีฝังเฟรมเสียงและควบคุมการเล่นโดยใช้ **Aspose.Slides for Python via Java** ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานกับเสียง

ติดตั้งแพ็กเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). แต่ละตัวอย่างจะทำการนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว

## **เพิ่มเฟรมเสียง**

แทรกเฟรมเสียงเปล่าที่สามารถเก็บข้อมูลเสียงที่ฝังไว้ได้ในภายหลัง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # สร้างเฟรมเสียงเปล่า (เสียงจะถูกฝังไว้ในภายหลัง)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้ดึงเฟรมเสียงแรกบนสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # เข้าถึงเฟรมเสียงแรกบนสไลด์.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่ได้เพิ่มไว้ก่อนหน้า

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # ลบเฟรมเสียง
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นอัตโนมัติเมื่อสไลด์ปรากฏ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # เล่นอัตโนมัติเมื่อสไลด์ปรากฏ
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```