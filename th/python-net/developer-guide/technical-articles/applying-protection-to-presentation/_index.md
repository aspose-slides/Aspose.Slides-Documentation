---
title: จำกัดการแก้ไขงานนำเสนอด้วยล็อกรูปทรงใน Python
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
description: "เรียนรู้วิธีล็อคและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Python via .NET เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via .NET คือการสร้าง, ปรับปรุงและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้

บทความนี้อธิบายว่า รูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการเพิ่มและลบล็อกรูปทรงในงานนำเสนอ PPTX ล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรายการ

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น รูปร่างอัตโนมัติ (autoshapes), ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python via .NET แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 

แต่ละประเภทของรูปทรงจะมีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับล็อกรูปทรง Aspose.Slides for Python via .NET มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ล็อกรูปทรงอัตโนมัติ.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) ล็อกรูปทรงเชื่อมต่อ.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) ล็อกรูปทรงที่จัดกลุ่ม.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) ล็อกกรอบภาพ.  

เพื่อใช้ล็อกในทั้งหมดของ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), ให้วนซ้ำผ่านสไลด์ของมันและตั้งค่าล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรายการ

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่รองรับใช้ล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าการป้องกันงานนำเสนอที่แยกออกจากกัน [presentation protection settings](/slides/th/python-net/password-protected-presentation/).

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Python via .NET มีคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์.

ตัวอย่างตั้งค่า [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), และ [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) เป็น `True` สำหรับรูปทรงอัตโนมัติ พร้อมล็อกที่เทียบเท่าสำหรับรูปทรงที่จัดกลุ่ม, ตัวเชื่อมต่อ, และกรอบภาพ ตัวเชื่อมต่อใช้ [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) เพื่อจำกัดการจัดกลุ่ม.

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการใช้ข้อจำกัดเหล่านี้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปนี้ไม่ได้วนผ่านรูปทรงลูกภายในกลุ่ม.

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

เพื่อลบล็อกรูปทรง, ให้ตั้งค่าของมันเป็น `False` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีล็อกรูปทรกและลบข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). มันยังลบ [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะไม่ได้เปลี่ยนแปลง

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

### **รักษาการครอปภาพ**

วางภาพชื่อ `photo.jpg` ในไดเรกทอรีทำงาน ตัวอย่างจะครอป 12% จากด้านซ้ายและ 8% จากด้านขวา, จากนั้นตั้งค่า [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) บนกรอบภาพเพื่อรักษาการครอป

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

`PictureLocked.pptx` บันทึกล็อกการครอปเป็น `True`. ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ.

### **รักษาไดอะแกรมเป็นกลุ่ม**

ตัวอย่างทำการจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วตั้งค่า [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) บนกลุ่มเองเพื่อรักษาองค์ประกอบของไดอะแกรมให้คงอยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมขององค์ประกอบยังคงใช้ได้

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

`DiagramLocked.pptx` บันทึกล็อกการยกเลิกการจัดกลุ่มเป็น `True`. ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกไดอะแกรมทั้งหมด

### **สรุป**

Aspose.Slides for Python via .NET ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรายการหรือใช้ข้อจำกัดเดียวกันบนสไลด์ทั้งหมด เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปทรง, และตั้งค่าของมันเป็น `False` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้. ล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ, ในขณะที่ [password protection](/slides/th/python-net/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองในไฟล์เดียวกันได้.

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้. ใช้ล็อกเฉพาะบนรูปทรงของสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนแปลงการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใช้ล็อกกับรูปทรงแต่ละตัวภายในกลุ่มได้อย่างไร?**

วนผ่านคอลเลกชัน [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของกลุ่มและตั้งค่าล็อกที่เหมาะสมให้กับแต่ละรูปทรงลูก ทำซ้ำสำหรับกลุ่มที่ซ้อนอยู่ ตัวอย่างข้างต้นดำเนินการเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าล็อกบนสมาชิกกลุ่มแต่ละตัว