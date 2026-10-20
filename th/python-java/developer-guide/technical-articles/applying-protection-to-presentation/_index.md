---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อครูปทรงใน Python
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/python-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อครูปทรง
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
description: "เรียนรู้วิธีการล็อคและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ Python via Java เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาดและการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via Java คือการสร้าง, ปรับปรุงและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาเค้าโครงและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อครูปทรงในงานนำเสนอ PPTX การล็อคเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **องค์ประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python via Java แต่ละองค์ประกอบบนสไลด์จะแทนด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [รูปทรง](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 

รูปทรงประเภทต่าง ๆ มีตัวเลือกการล็อคที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) เป็นคลาสพื้นฐานสำหรับการล็อครูปทรง Aspose.Slides for Python via Java มีคลาสล็อคต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) ล็อค autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) ล็อค connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) ล็อค graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) ล็อค group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) ล็อค picture frames.  

เพื่อใช้ล็อคทั่วทั้ง [การนำเสนอ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าล็อคที่เหมาะสมบนรูปทรงที่รองรับแต่ละประเภท

## **ใช้และลบการป้องกัน**

การล็อครูปทรงจำกัดการดำเนินการเช่นการเลือก, การย้ายและการปรับขนาดรูปทรง แต่ไม่ได้ทำให้ทั้งงานนำเสนอไม่สามารถแก้ไขได้

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Python via Java มีคลาส [รูปทรง](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `True` สำหรับ autoshapes, พร้อมด้วยล็อคที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames. Connectors ใช้ [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) สำหรับการย้าย; groups ยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงใน collection ของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ รูปทรงที่อยู่นอกสี่ประเภทที่รองรับจะไม่ถูกเปลี่ยนแปลง ลูปไม่ได้เดินทางผ่านรูปทรงย่อยภายในกลุ่ม

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

เพื่อเอาการล็อครูปทรงออก ให้ตั้งค่าตัวแปรเป็น `False` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อครูปทรงและล้างข้อจำกัดการเลือก, การย้ายและการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) และ [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) อีกทั้งยังลบข้อจำกัดการจัดกลุ่มโดยส่ง `False` ไปยัง [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อคอื่น ๆ จะคงอยู่เช่นเดิม

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

### **สรุป**

Aspose.Slides for Python via Java ทำให้คุณสามารถจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันทั่วสไลด์ทั้งหมด เลือกล็อคที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าตัวแปรเป็น `False` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อครูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อครูปทรงจำกัดการดำเนินการแก้ไขเฉพาะขณะ [การป้องกันด้วยรหัสผ่าน](/slides/th/python-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขในสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่นๆ ได้หรือไม่?**

ใช่ ใช้ล็อคเฉพาะกับรูปทรงบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าล็อคบนสไลด์อื่น ๆ

**ฉันจะใช้การล็อครูปทรงกับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่าน collection ที่คืนค่าจากเมธอด [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) ของกลุ่มและใช้ล็อคที่เหมาะสมกับแต่ละรูปทรงย่อย ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างด้านบนประมวลผลเฉพาะ collection ของสไลด์เท่านั้นจึงไม่ได้ตั้งค่าล็อคบนสมาชิกของกลุ่มแต่ละอัน