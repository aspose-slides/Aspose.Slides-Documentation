---
title: ป้องกันการแก้ไขงานนำเสนอด้วยการล็อกรูปร่าง
linktitle: ป้องกันการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/python-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันไม่ให้แก้ไข
- ล็อกรูปร่าง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides for Python via Java ล็อกหรือปลดล็อกรูปร่างในไฟล์ PPT, PPTX และ ODP เพื่อรักษาความปลอดภัยของงานนำเสนอพร้อมให้การแก้ไขที่ควบคุมได้และการส่งมอบที่เร็วขึ้น"
---
## **พื้นหลัง**

การใช้ Aspose.Slides อย่างทั่วไปคือการสร้าง, อัปเดต, และบันทึกงานนำเสนอ Microsoft PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ ผู้ใช้แอปพลิเคชันที่ใช้ Aspose.Slides ในลักษณะนี้จะเข้าถึงงานนำเสนอที่สร้างขึ้น ดังนั้นการปกป้องไม่ให้แก้ไขจึงเป็นข้อกังวลทั่วไป การที่งานนำเสนอที่สร้างอัตโนมัติยังคงรักษาการจัดรูปแบบและเนื้อหาต้นฉบับจึงเป็นสิ่งสำคัญ

บทความนี้อธิบายว่าการจัดโครงสร้างของงานนำเสนอและสไลด์เป็นอย่างไร และ Aspose.Slides for Python via Java สามารถใช้การปกป้องกับงานนำเสนอและถอดออกได้อย่างไร มันให้ผู้พัฒนาวิธีควบคุมวิธีการใช้งานนำเสนอที่แอปพลิเคชันของพวกเขาสร้างขึ้น

## **โครงสร้างของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python via Java แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) 

โครงสร้างของ PPTX คซับซ้อน ดังนั้นจึงต่างจาก PPT ที่สามารถใช้ล็อกทั่วไปกับรูปทรงทุกประเภทได้ ประเภทรูปทรงที่ต่างกันต้องการล็อกที่ต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseshapelock/) เป็นคลาสล็อกทั่วไปสำหรับ PPTX ประเภทล็อกต่อไปนี้ได้รับการสนับสนุนใน Aspose.Slides for Python via Java สำหรับ PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshapelock/)ล็อค autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/connectorlock/)ล็อค connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/graphicalobjectlock/)ล็อค graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshapelock/)ล็อค group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframelock/)ล็อค picture frames.  

การกระทำใด ๆ ที่ทำกับอ็อบเจ็กต์ shape ทั้งหมดในอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จะนำไปใช้กับงานนำเสนอทั้งหมด

## **ใช้และลบการปกป้อง**

การใช้การปกป้องทำให้มั่นใจว่างานนำเสนอไม่สามารถแก้ไขได้ ซึ่งเป็นเทคนิคที่มีประโยชน์สำหรับการปกป้องเนื้อหาของงานนำเสนอ

### **ใช้การปกป้องกับรูปร่าง PPTX**

Aspose.Slides for Python via Java มีคลาส [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตามที่กล่าวไปก่อนหน้านี้ แต่ละคลาสรูปร่างมีคลาสล็อกรูปทรงที่เกี่ยวข้องสำหรับการปกป้อง บทความนี้โฟกัสที่ล็อก NoSelect, NoMove, และ NoResize ล็อกเหล่านี้ทำให้รูปร่างไม่สามารถเลือกได้ (โดยการคลิกเมาส์หรือวิธีการเลือกอื่น) และไม่สามารถย้ายหรือปรับขนาดได้

ตัวอย่างโค้ดต่อไปนี้ใช้การปกป้องกับประเภทรูปร่างทั้งหมดในงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpole.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
presentation = Presentation("Sample.pptx")
try:
    # วนครั้งผ่านสไลด์ทั้งหมดในงานนำเสนอ
    for slide in presentation.getSlides():
        # วนครั้งผ่านรูปร่างทั้งหมดในสไลด์
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

    # บันทึกไฟล์งานนำเสนอ
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ลบการปกป้อง**

เพื่อปลดล็อกรูปร่าง ให้ตั้งค่าค่าล็อกที่ใช้เป็น `False` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อกรูปร่างในงานนำเสนอที่ถูกล็อก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
presentation = Presentation("ProtectedSample.pptx")
try:
    # วนครั้งผ่านสไลด์ทั้งหมดในงานนำเสนอ
    for slide in presentation.getSlides():
        # วนครั้งผ่านรูปร่างทั้งหมดในสไลด์
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

    # บันทึกไฟล์งานนำเสนอ
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สรุป**

Aspose.Slides มีตัวเลือกหลายอย่างสำหรับการปกป้องรูปร่างในงานนำเสนอ คุณสามารถล็อกรูปร่างเดี่ยวหรือวนผ่านรูปร่างทั้งหมดในงานนำเสนอและล็อกแต่ละรูปร่างเพื่อให้ไฟล์ทั้งหมดปลอดภัยอย่างมีประสิทธิภาพ คุณสามารถลบการปกป้องได้โดยตั้งค่าค่าล็อกเป็น `False`

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อครูปร่างและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

Yes. Locks limit editing of objects inside the file, while [password protection](/slides/th/python-java/password-protected-presentation/) controls access to opening and/or saving changes. These mechanisms complement each other and work together.

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่น ๆ ได้หรือไม่?**

Yes. Apply locks to the shapes on the selected slides; the remaining slides will stay editable.

**การล็อครูปร่างใช้กับวัตถุที่จัดกลุ่มและตัวเชื่อมต่อหรือไม่?**

Yes. Dedicated lock types are supported for groups, connectors, graphic objects, and other shape kinds.