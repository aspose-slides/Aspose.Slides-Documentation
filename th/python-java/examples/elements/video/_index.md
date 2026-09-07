---
title: วิดีโอ
type: docs
weight: 80
url: /th/python-java/examples/elements/video/
keywords:
- ตัวอย่างโค้ด
- วิดีโอ
- กรอบวิดีโอ
- เพิ่มวิดีโอ
- เข้าถึงวิดีโอ
- ลบวิดีโอ
- การเล่นวิดีโอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเพิ่ม, เข้าถึง, ลบ และตั้งค่ากรอบวิดีโอในงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้แสดงวิธีการเพิ่มกรอบวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะนำเข้า `asposeslides` ก่อนเริ่ม JVM จากนั้นจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มกรอบวิดีโอ**

แทรกกรอบวิดีโอที่อ้างอิงไฟล์วิดีโอภายนอก.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มกรอบวิดีโอที่เชื่อมโยงกับไฟล์วิดีโอ.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **เข้าถึงกรอบวิดีโอ**

ดึงกรอบวิดีโอแรกที่เพิ่มเข้าไปในสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # เข้าถึงกรอบวิดีโอตัวแรกบนสไลด์.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **ลบกรอบวิดีโอ**

ลบกรอบวิดีโอออกจากสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # ลบกรอบวิดีโอ.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดให้วิดีโอเล่นอัตโนมัติเมื่อสไลด์แสดงผล.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # ตั้งค่าการเล่นวิดีโอให้ทำงานโดยอัตโนมัติ.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```