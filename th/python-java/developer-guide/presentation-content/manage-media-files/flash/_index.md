---
title: ดึงวัตถุ Flash จากงานนำเสนอใน Python
linktitle: Flash
type: docs
weight: 10
url: /th/python-java/flash/
keywords:
- ดึง flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีดึงวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ด้วย Python และ Aspose.Slides พร้อมตัวอย่างโค้ดครบถ้วนและแนวปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีดึงวัตถุ Flash จากงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีค้นหา Flash control ตามชื่อในคอลเลกชันของสไลด์และทำงานกับข้อมูลวัตถุ SWF ที่ฝังอยู่

## **ดึงวัตถุ Flash จากงานนำเสนอ**

Aspose.Slides for Python via Java มีฟีเจอร์สำหรับดึงวัตถุ flash จากงานนำเสนอ คุณสามารถเข้าถึง Flash control ตามชื่อและดึงออกจากงานนำเสนอ รวมถึงข้อมูลวัตถุ SWF ที่เก็บไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX.
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**รูปแบบงานนำเสนอใดบ้างที่รองรับเมื่อดึงเนื้อหา Flash?**

[ Aspose.Slides รองรับ](/slides/th/python-java/supported-file-formats/) รูปแบบ PowerPoint หลัก เช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึงคอนโทรลของมัน รวมถึงองค์ประกอบ ActiveX ที่เกี่ยวข้องกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash เป็น HTML5 และรักษาความโต้ตอบของ Flash ไว้ได้หรือไม่?**

ไม่. Aspose.Slides ไม่ทำการเรียกใช้เนื้อหา SWF หรือแปลงความโต้ตอบของมัน แม้ว่าการส่งออกไปยัง [HTML](/slides/th/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/th/python-java/export-to-html5/) จะได้รับการสนับสนุน แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากการยุติการสนับสนุน ทางที่แนะนำคือการแทนที่ Flash ด้วยทางเลือกอื่น เช่น วิดีโอหรือแอนิเมชัน HTML5 ก่อนการส่งออก

**จากมุมมองด้านความปลอดภัย Aspose.Slides ทำการเรียกใช้ไฟล์ SWF ระหว่างอ่านงานนำเสนอหรือไม่?**

ไม่. Aspose.Slides ถือว่า Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และไม่ทำการเรียกใช้เนื้อหา SWF ระหว่างการประมวลผล

**ฉันควรจัดการกับงานนำเสนอที่มี Flash รวมกับไฟล์ฝังอื่น ๆ ผ่าน OLE อย่างไร?**

Aspose.Slides รองรับการ[ดึงข้อมูลวัตถุ OLE ที่ฝังอยู่](/slides/th/python-java/manage-ole/), ดังนั้นคุณสามารถประมวลผลเนื้อหาที่ฝังที่เกี่ยวข้องทั้งหมดในขั้นตอนเดียว โดยจัดการคอนโทรล Flash และเอกสารที่ฝังผ่าน OLE อื่น ๆ พร้อมกัน