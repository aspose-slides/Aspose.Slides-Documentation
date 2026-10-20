---
title: จำกัดการแก้ไขการนำเสนอด้วยการล็อกรูปทรงใน Python
linktitle: จำกัดการแก้ไขการนำเสนอ
type: docs
weight: 70
url: /th/python-net/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกจากการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีล็อคและปลดล็อกรูปทรงในไฟล์นำเสนอ PPTX ด้วย Aspose.Slides for Python via .NET เพื่อจำกัดการเลือก, การย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Python via .NET คือการสร้าง, อัปเดต และบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจไว้

บทความนี้อธิบายว่า รูปร่างถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการนำและลบการล็อกรูปทรงในไฟล์ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูป

## **ส่วนประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปร่างที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for Python via .NET แต่ละองค์ประกอบบนสไลด์จะแทนด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)  

ประเภทของรูปทรงต่าง ๆ แสดงตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อกรูปทรง Aspose.Slides for Python via .NET มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) ล็อก autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) ล็อก connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) ล็อก graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) ล็อก group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) ล็อก picture frames.  

เพื่อใช้การล็อกกับ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), ให้วนลูปผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรูป

## **นำไปใช้และลบการป้องกัน**

การล็อกรูปทรงจำกัดการดำเนินการเช่น การเลือก, การย้าย, และการปรับขนาดรูปทรง พวกมันไม่ได้ทำให้การนำเสนอทั้งหมดไม่สามารถแก้ไขได้

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Python via .NET มีคลาส [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์  

ตัวอย่างตั้งค่า [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), และ [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) เป็น `True` สำหรับ autoshapes, พร้อมกับการล็อกที่เทียบเท่าสำหรับกลุ่มรูปทรง, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) เพื่อจำกัดการจัดกลุ่ม  

ตัวอย่างโหลดการนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปร่างที่ไม่อยู่ในสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่เดินทางผ่านรูปทรงลูกภายในกลุ่ม  

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

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าของมันเป็น `False` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก การเคลื่อนที่ และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) นอกจากนี้ยังล้าง [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) และบันทึกสำเนาของการนำเสนอ การตั้งค่าล็อกอื่น ๆ จะไม่ถูกเปลี่ยนแปลง  

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

### **บทสรุป**

Aspose.Slides for Python via .NET ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าของมันเป็น `False` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะส่วนหนึ่ง ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขการนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้  

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่น ๆ ได้หรือไม่?**

ใช่ ให้นำการล็อกไปใช้เฉพาะกับรูปทรงบนสไลด์ที่เลือกเท่านั้น สิ่งนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น ๆ  

**ฉันจะนำการล็อกไปใช้กับรูปทรงแต่ละรูปภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชัน [รูปทรง](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของกลุ่มและนำการล็อกที่เหมาะสมไปใช้กับรูปทรงลูกแต่ละรูป ทำซ้ำสำหรับกลุ่มที่ซ้อนอยู่ ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละตัว