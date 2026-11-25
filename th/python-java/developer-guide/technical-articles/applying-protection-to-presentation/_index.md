---
title: จำกัดการแก้ไขการนำเสนอด้วยการล็อกรูปทรงใน Python
linktitle: จำกัดการแก้ไขการนำเสนอ
type: docs
weight: 60
url: /th/python-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในไฟล์การนำเสนอ PPTX ด้วย Aspose.Slides for Python via Java เพื่อจำกัดการเลือก การเคลื่อนที่ การปรับขนาด และการจัดกลุ่ม"
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via Java คือการสร้าง, อัปเดตและบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายวิธีการจัดระเบียบรูปทรงบนสไลด์และวิธีการใช้และลบการล็อกรูปทรงในไฟล์ PPTX การล็อกเหล่านี้ทำให้คุณสามารถจำกัดการทำงานแก้ไขเฉพาะบนรูปทรงแต่ละรูปได้

## **ส่วนประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for Python via Java แต่ละองค์ประกอบบนสไลด์จะแสดงเป็นอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 

ประเภทรูปทรงที่แตกต่างกันจะเปิดเผยตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) เป็นคลาสพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for Python via Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ล็อก autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) ล็อก connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ล็อก graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) ล็อก group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) ล็อก picture frames.  

เพื่อใช้การล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรูปทรง

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขการนำเสนอที่รองรับจะใช้การล็อกรูปทรงเพื่อจำกัดการทำงานแก้ไขเฉพาะ รายการเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็น [การตั้งค่าการป้องกันการนำเสนอ](/slides/th/python-java/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Python via Java มีคลาส [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `True` สำหรับ autoshapes, พร้อมการล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames. Connectors ใช้ [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดไฟล์ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, แล้วบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่วนลูปผ่านรูปทรงย่อยภายในกลุ่ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ลบการป้องกัน**

เพื่อเอาการล็อกรูปทรงออก, ให้ตั้งค่ามันเป็น `False` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) นอกจากนี้ยังลบข้อจำกัดการจัดกลุ่มโดยส่งค่า `False` ให้กับ [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) แล้วบันทึกสำเนาของการนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงไว้ตามเดิม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **รักษาการครอบรูปภาพ**

วางรูปภาพชื่อ `photo.jpg` ในไดเรกทอรีทำงาน ตัวอย่างทำการครอบ 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วเรียกใช้ [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) ด้วยค่า `True` เพื่อรักษาการครอบนั้น

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใน `PictureLocked.pptx`, PowerPoint จะปิดการใช้งานคำสั่ง **Crop** เมื่อคุณเลือกรูปภาพ

### **รักษา Diagram ให้เป็นกลุ่ม**

ตัวอย่างทำการจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วเรียกใช้ [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) ด้วยค่า `True` เพื่อให้สองรูปทรงคงอยู่ด้วยกัน คุณยังสามารถย้ายกลุ่มหรือเปลี่ยนสีเติมของส่วนประกอบได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใน `DiagramLocked.pptx`, PowerPoint จะปิดการใช้งานคำสั่ง **Ungroup** เมื่อคุณเลือกไดอะแกรมทั้งหมด

### **รายงานการล็อกรูปทรงที่มีอยู่**

ในการตรวจสอบเทมเพลต, เปิดไฟล์และอ่านอ็อบเจ็กต์ล็อกสำหรับแต่ละรูปทรง วิธีการ [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) จะคืนค่า `True` เมื่อทุกแฟล็กบนอ็อบเจ็กต์นั้นถูกปิดและคืนค่า `False` เมื่ออย่างน้อยหนึ่งแฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน ดังนั้นให้ตรวจสอบลูกแม้ในขณะที่กลุ่มไม่มีล็อก

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับ autoshapes, picture frames, และ groups. นอกจากนี้ยังตรวจสอบการครอบสำหรับรูปภาพและการยกเลิกการจัดกลุ่มสำหรับกลุ่ม รายงานจะแสดงแฟล็กที่เปิดอยู่ที่มันรับรู้และทำเครื่องหมายประเภทรูปทรงที่ไม่ได้ตรวจสอบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

สมมติว่า สไลด์ 1 ของ `Sample.pptx` มีชุดชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` ภายในชุดที่ล็อกการครอบ, และสี่เหลี่ยมปลดล็อกชื่อ `Free`. รายงานจะข้าม `Free` และพิมพ์สองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านแฟล็กการแก้ไขระดับรูปทรงที่จัดเก็บไว้โดยไม่เปลี่ยนแปลงหรือบันทึกการนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหากและการบังคับใช้แต่ละแฟล็กขึ้นอยู่กับโปรแกรมแก้ไข

## **สรุป**

Aspose.Slides for Python via Java ให้คุณจำกัดการทำงานแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้ข้อจำกัดเดียวกันทั่วทั้งสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทรูปทรงและตั้งค่าเป็น `False` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในการนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรูปทรงจำกัดการทำงานแก้ไขเฉพาะในขณะที่ [password protection](/slides/th/python-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขการนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ใช่ ให้ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก วิธีนี้จะไม่เปลี่ยนแปลงการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละรูปภายในกลุ่มอย่างไร?**

ให้วนลูปผ่านคอลเลกชันที่ได้จากเมธอด [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) ของกลุ่มและใช้การล็อกที่เหมาะสมกับรูปทรงลูกแต่ละรูป ทำซ้ำสำหรับกลุ่มที่ซ้อนกันตามการเดินทางในตัวอย่างการรายงาน