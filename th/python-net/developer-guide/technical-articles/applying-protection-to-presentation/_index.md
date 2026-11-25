---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน Python
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 70
url: /th/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Python via .NET เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via .NET คือการสร้าง, ปรับปรุงและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจไว้

บทความนี้อธิบายว่ารูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **องค์ประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น รูปอัตโนมัติ, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python via .NET แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 

แต่ละประเภทของรูปทรงจะมีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อกรูปทรง Aspose.Slides for Python via .NET มีคลาสล็อกต่อไปนี้:
- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ล็อกรูปอัตโนมัติ.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) ล็อกรูปแบบตัวเชื่อมต่อ.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) ล็อกรูปทรงกลุ่ม.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) ล็อกกรอบรูปภาพ.  

เพื่อใช้การล็อกในทั่วทั้ง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ให้วนซ้ำผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนแต่ละรูปทรงที่รองรับ

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่รองรับจะใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/python-net/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Python via .NET มีคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างตั้งค่า [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) และ [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) เป็น `True` สำหรับรูปอัตโนมัติ พร้อมด้วยการล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ใช้งาน รูปทรงที่ไม่อยู่ในสี่ประเภทที่รองรับจะถูกปล่อยให้คงอยู่เช่นเดิม ลูปจะไม่เดินทางไปยังรูปทรงลูกภายในกลุ่ม

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบการป้องกัน**

เพื่อยกเลิกการล็อกรูปทรง, ตั้งค่าค่าของมันเป็น `False` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) นอกจากนี้ยังล้าง [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่เช่นเดิม

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **เก็บรักษาการครอปรูปภาพ**

วางรูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการครอป 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วตั้งค่า [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) บนกรอบรูปภาพ การตั้งค่านี้จำกัดการครอปเพิ่มเติมและรักษาการครอปที่มีอยู่

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` เก็บล็อกการครอปเป็น `True`. ใน PowerPoint, คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ

### **รักษา Diagram ให้เป็นกลุ่ม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วตั้งค่า [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) บนกลุ่มเองเพื่อรักษาส่วนประกอบของ Diagram ให้อยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงสามารถทำได้

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` เก็บล็อกการแยกกลุ่มเป็น `True`. ใน PowerPoint, คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือก Diagram ทั้งหมด

### **รายงานการล็อกรูปทรงที่มีอยู่**

เพื่อรีวิวเทมเพลต, เปิดไฟล์และอ่านอ็อบเจ็กต์ล็อกสำหรับแต่ละรูปทรง [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) จะเป็น `True` เมื่อทุกฟล็กบนอ็อบเจ็กต์นั้นถูกปิดและ `False` เมื่อมีอย่างน้อยหนึ่งฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน, ดังนั้นควรตรวจสอบลูกแม้ว่าองค์กรกลุ่มจะไม่มีล็อก

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับรูปอัตโนมัติ, กรอบรูปภาพ, และกลุ่ม, การครอปสำหรับรูปภาพ, และการแยกกลุ่มสำหรับกลุ่ม มันจะรายงานฟล็กที่รับรู้และทำเครื่องหมายประเภทรูปทรงที่ไม่ได้ตรวจสอบ

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

สมมติว่า สไลด์ 1 ของ `Sample.pptx` มีกลุ่มชื่อ `Layout` ที่ล็อกการแยกกลุ่ม, รูปภาพชื่อ `Photo` ภายในที่ล็อกการครอป, และสี่เหลี่ยมที่ไม่ได้ล็อกชื่อ `Free`. รายงานจะข้าม `Free` และพิมพ์สองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

รายงานอ่านฟล็กการแก้ไขระดับรูปทรงที่บันทึกไว้โดยไม่เปลี่ยนแปลงหรือบันทึกงานนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหากและการบังคับใช้แต่ละฟล็กขึ้นอยู่กับโปรแกรมแก้ไข

### **สรุป**

Aspose.Slides for Python via .NET ทำให้คุณสามารถจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันทั่วทั้งหมดเลือกล็อกที่สนับสนุนโดยแต่ละประเภทของรูปทรง และตั้งค่าของมันเป็น `False` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [การป้องกันด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the group's [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) collection and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.