---
title: ป้องกันการแก้ไขงานนำเสนอด้วยการล็อกรูปร่างใน Python
linktitle: ป้องกันการแก้ไขงานนำเสนอ
type: docs
weight: 70
url: /th/python-net/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันจากการแก้ไข
- ล็อกรูปร่าง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides for Python ผ่าน .NET ล็อกหรือปลดล็อกรูปร่างในไฟล์ PPT, PPTX และ ODP, ทำให้การนำเสนอดีขึ้นพร้อมการแก้ไขที่ควบคุมได้และการจัดส่งที่เร็วขึ้น."
---
## **พื้นหลัง**

การใช้ Aspose.Slides อย่างทั่วไปคือการสร้าง, อัปเดตและบันทึกงานนำเสนอ Microsoft PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ ผู้ใช้ของแอปพลิเคชันที่ใช้ Aspose.Slides ในลักษณะนี้จะเข้าถึงงานนำเสนอที่สร้างขึ้น ดังนั้นการปกป้องไม่ให้แก้ไขจึงเป็นข้อกังวลทั่วไป จำเป็นให้งานนำเสนอที่สร้างโดยอัตโนมัติคงรูปแบบและเนื้อหาเดิมไว้

บทความนี้อธิบายโครงสร้างของงานนำเสนอและสไลด์ และวิธีที่ Aspose.Slides for Python สามารถใช้การป้องกันต่อไฟล์งานนำเสนอและลบการป้องกันนั้นออกได้ในภายหลัง ให้วิธีการสำหรับนักพัฒนาในการควบคุมการใช้งานของงานนำเสนอที่แอปพลิเคชันของพวกเขาสร้างขึ้น

## **การประกอบส่วนของสไลด์**

สไลด์ของงานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Python แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) 

โครงสร้างของ PPTX มีความซับซ้อน ดังนั้นต่างจาก PPT ที่สามารถใช้ lock โดยรวมได้กับรูปแบบทั้งหมด, รูปแบบต่าง ๆ ใน PPTX จำเป็นต้องใช้ lock ประเภทต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseshapelock/) คือคลาสล็อกทั่วไปสำหรับ PPTX ประเภทของ lock ที่สนับสนุนใน Aspose.Slides for Python สำหรับ PPTX มีดังนี้

- [AutoShapeLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshapelock/) ล็อก autoshapes  
- [ConnectorLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/connectorlock/) ล็อก connector shapes  
- [GraphicalObjectLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/graphicalobjectlock/) ล็อก graphical objects  
- [GroupShapeLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshapelock/) ล็อก group shapes  
- [PictureFrameLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/) ล็อก picture frames  

การกระทำใด ๆ ที่ทำกับอ็อบเจ็กต์รูปแบบทั้งหมดในอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) จะถูกนำไปใช้กับงานนำเสนอทั้งหมด

## **การใช้และการลบการป้องกัน**

การใช้การป้องกันทำให้ไม่สามารถแก้ไขงานนำเสนอได้ ถือเป็นเทคนิคที่มีประโยชน์สำหรับการปกป้องเนื้อหาในงานนำเสนอ

### **ใช้การป้องกันกับรูปร่างใน PPTX**

Aspose.Slides for Python มีคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตามที่ได้กล่าวไว้ก่อนหน้า แต่ละคลาสรูปร่างมีคลาสล็อกที่สอดคล้องกันสำหรับการป้องกัน บทความนี้เน้นที่ล็อก NoSelect, NoMove และ NoResize ซึ่งล็อกเหล่านี้ทำให้ไม่สามารถเลือกรูปร่าง (ผ่านการคลิกเมาส์หรือวิธีการเลือกอื่น) และไม่สามารถย้ายหรือปรับขนาดรูปร่างได้

โค้ดตัวอย่างต่อไปนี้ใช้การป้องกันกับรูปแบบทุกประเภทในงานนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation("Sample.pptx") as presentation:
    # เขียนวนลูปผ่านสไลด์ทั้งหมดในงานนำเสนอ
    for slide in presentation.slides:
        # เขียนวนลูปผ่านรูปร่างทั้งหมดในสไลด์
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # กำลังบันทึกไฟล์งานนำเสนอ
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบการป้องกัน**

เพื่อปลดล็อกรูปร่าง ให้ตั้งค่าค่าล็อกที่ได้กำหนดไว้เป็น `False` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อกรูปร่างในงานนำเสนอที่ถูกล็อก

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # เขียนวนลูปผ่านสไลด์ทั้งหมดในงานนำเสนอ
    for slide in presentation.slides:
        # เขียนวนลูปผ่านรูปร่างทั้งหมดในสไลด์
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # กำลังบันทึกไฟล์งานนำเสนอ
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **สรุป**

Aspose.Slides มีตัวเลือกหลายอย่างสำหรับการป้องกันรูปร่างในงานนำเสนอ คุณสามารถล็อกรูปร่างเดียวหรือวนลูปผ่านรูปร่างทั้งหมดในงานนำเสนอและล็อกแต่ละรูปร่างเพื่อให้ไฟล์ทั้งหมดปลอดภัยได้ คุณสามารถลบการป้องกันได้โดยตั้งค่าค่าล็อกเป็น `False`

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมล็อกของรูปร่างและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่. ล็อกจำกัดการแก้ไขออบเจ็กต์ภายในไฟล์ ในขณะที่ [password protection](/slides/th/python-net/password-protected-presentation/) ควบคุมการเข้าถึงการเปิดหรือบันทึกการเปลี่ยนแปลง กลไกเหล่านี้ทำงานเสริมกันและทำงานร่วมกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ใช่. ใช้ล็อกกับรูปร่างบนสไลด์ที่เลือก; สไลด์ที่เหลือจะยังคงแก้ไขได้

**ล็อกของรูปร่างใช้กับออบเจ็กต์ที่รวมกลุ่มและคอนเนคเตอร์หรือไม่?**

ใช่. มีประเภทล็อกที่ออกแบบเฉพาะสำหรับกลุ่ม, คอนเนคเตอร์, graphic objects และรูปแบบอื่น ๆ ของรูปร่าง