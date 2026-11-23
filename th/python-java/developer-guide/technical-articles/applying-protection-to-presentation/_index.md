---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน Python
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/python-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Python via Java เพื่อจำกัดการเลือก การเคลื่อนย้าย การปรับขนาดและการจัดกลุ่ม"
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via Java คือการสร้าง ปรับปรุง และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอนี้ การจำกัดการเปลี่ยนแปลงรูปทรงช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจไว้

บทความนี้อธิบายถึงวิธีการจัดรูปทรงบนสไลด์และวิธีการตั้งค่าและลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น รูปร่างอัตโนมัติ (autoshapes), ตาราง, วัตถุ OLE, รูปร่างที่จัดกลุ่ม, เฟรมรูปภาพ, เฟรมวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python via Java แต่ละองค์ประกอบบนสไลด์จะแทนด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 

แต่ละประเภทของรูปทรงมีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อกรูปทรง Aspose.Slides for Python via Java มีคลาสล็อกต่อไปนี้:
- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ล็อกรูปทรงอัตโนมัติ.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) ล็อกรูปทรงเชื่อมต่อ.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) ล็อกรูปทรงที่จัดกลุ่ม.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) ล็อกเฟรมรูปภาพ.  

เพื่อทำการล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละอัน

## **ตั้งค่าและลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละอัน การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/python-java/password-protected-presentation/) ที่แยกจากกัน

### **ตั้งค่าการป้องกันให้กับรูปทรง PPTX**

Aspose.Slides for Python via Java มีคลาส [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) โดยกำหนดค่า `True` สำหรับรูปทรงอัตโนมัติ พร้อมด้วยการล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และเฟรมรูปภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์ และบันทึกสำเนาที่มีการจำกัดเหล่านี้ตั้งค่าไว้ รูปร่างที่ไม่อยู่ในสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่ไล่ผ่านรูปทรงย่อยภายในกลุ่ม

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

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าของมันเป็น `False` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การเคลื่อนย้าย, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) อีกทั้งยังลบการจำกัดการจัดกลุ่มโดยส่งค่า `False` ไปยัง [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะไม่ถูกเปลี่ยนแปลง

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

### **คงสภาพการครอปรูปภาพ**

วางรูปภาพที่ชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างจะครอปรูป 12% จากด้านซ้ายและ 8% จากด้านขวา แล้วเรียกใช้ [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) ด้วยค่า `True` เพื่อคงการครอปไว้

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

ในไฟล์ `PictureLocked.pptx` PowerPoint จะปิดการใช้งานคำสั่ง **Crop** เมื่อคุณเลือกรูปภาพ

### **รักษาแผนภาพให้จัดกลุ่ม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร แล้วเรียกใช้ [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) ด้วยค่า `True` เพื่อให้สองรูปทรงอยู่ด้วยกัน คุณยังสามารถย้ายกลุ่มหรือเปลี่ยนสีเติมของส่วนประกอบได้

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

ในไฟล์ `DiagramLocked.pptx` PowerPoint จะปิดการใช้งานคำสั่ง **Ungroup** เมื่อคุณเลือกแผนภาพทั้งหมด

### **สรุป**

Aspose.Slides for Python via Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันบนสไลด์ทั้งหมด เลือกการล็อกที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าของมันเป็น `False` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจะจำกัดการดำเนินการแก้ไขเฉพาะส่วนหนึ่ง ในขณะเดียวกัน [password protection](/slides/th/python-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบต่อสไลด์อื่นได้หรือไม่?**

ได้ ให้ตั้งค่าการล็อกเฉพาะรูปทรงบนสไลด์ที่เลือกเท่านั้น การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะตั้งค่าการล็อกให้กับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชันที่เมธอด [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) ของกลุ่มคืนค่าและตั้งค่าการล็อกที่เหมาะสมให้กับรูปทรงย่อยแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละอัน