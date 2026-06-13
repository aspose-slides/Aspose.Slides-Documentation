---
title: สกัดวัตถุ Flash จากงานนำเสนอใน Python
linktitle: Flash
type: docs
weight: 10
url: /th/python-net/flash/
keywords:
- สกัด flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสกัดวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ด้วย Python และ Aspose.Slides พร้อมตัวอย่างโค้ดครบถ้วนและแนวทางปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการสกัดวัตถุ Flash จากงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการค้นหา Flash control ตามชื่อในคอลเลกชันของควบคุมในสไลด์และทำงานกับข้อมูลวัตถุ SWF ที่ฝังอยู่

## **สกัดวัตถุ Flash จากงานนำเสนอ**
Aspose.Slides for Python via .NET มีฟังก์ชันสำหรับสกัดวัตถุ flash จากงานนำเสนอ คุณสามารถเข้าถึง flash control ตามชื่อและสกัดออกจากงานนำเสนอรวมถึงจัดเก็บข้อมูลวัตถุ SWF

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```

## **คำถามที่พบบ่อย**

**รูปแบบงานนำเสนอใดบ้างที่รองรับการสกัดเนื้อหา Flash?**

[Aspose.Slides supports](/slides/th/python-net/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึงคอนโทรลของพวกมัน รวมถึงองค์ประกอบ ActiveX ที่เกี่ยวกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash ไปเป็น HTML5 และรักษาการโต้ตอบของ Flash ได้หรือไม่?**

ไม่. Aspose.Slides ไม่ดำเนินการเนื้อหา SWF หรือแปลงการโต้ตอบของมัน แม้ว่าการส่งออกเป็น [HTML](/slides/th/python-net/convert-powerpoint-to-html/)/[HTML5](/slides/th/python-net/export-to-html5/) จะรองรับ แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากการหยุดสนับสนุน แนะนำให้แทนที่ Flash ด้วยทางเลือกเช่นวิดีโอหรือแอนิเมชัน HTML5 ก่อนการส่งออก

**จากมุมมองด้านความปลอดภัย Aspose.Slides ดำเนินการไฟล์ SWF ระหว่างการอ่านงานนำเสนอหรือไม่?**

ไม่. Aspose.Slides ปฏิบัติกับ Flash เป็นข้อมูลไบเนรีที่ฝังอยู่ในไฟล์และไม่ดำเนินการเนื้อหา SWF ระหว่างการประมวลผล

**ฉันควรจัดการงานนำเสนอที่มี Flash ร่วมกับไฟล์ฝังอื่นผ่าน OLE อย่างไร?**

Aspose.Slides รองรับการ [extracting embedded OLE objects](/slides/th/python-net/manage-ole/) ดังนั้นคุณสามารถประมวลผลเนื้อหาฝังที่เกี่ยวข้องทั้งหมดในการทำงานหนึ่งครั้งโดยจัดการ Flash control และเอกสารที่ฝังด้วย OLE อื่น ๆ ร่วมกัน