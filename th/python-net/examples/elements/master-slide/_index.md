---
title: มาสเตอร์สไลด์
type: docs
weight: 30
url: /th/python-net/examples/elements/master-slide/
keywords:
- มาสเตอร์สไลด์
- เพิ่มมาสเตอร์สไลด์
- เข้าถึงมาสเตอร์สไลด์
- ลบมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Python ด้วย Aspose.Slides: สร้าง, แก้ไข, ทำสำเนา, และจัดรูปแบบธีม, พื้นหลัง, ส่วนที่เป็นตัวยึดเพื่อทำให้สไลด์ใน PowerPoint และ OpenDocument มีความสอดคล้องกัน."
---
มาสเตอร์สไลด์เป็นระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **มาสเตอร์สไลด์** กำหนดองค์ประกอบการออกแบบทั่วไป เช่น พื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **สไลด์การจัดวาง** สืบทอดจากมาสเตอร์สไลด์, และ **สไลด์ปกติ** สืบทอดจากสไลด์การจัดวาง.

บทความนี้แสดงวิธีสร้าง, แก้ไข, และจัดการมาสเตอร์สไลด์โดยใช้ Aspose.Slides for Python via .NET.

## **เพิ่มมาสเตอร์สไลด์**

ตัวอย่างนี้แสดงวิธีสร้างมาสเตอร์สไลด์ใหม่โดยทำสำเนามาสเตอร์สไลด์เริ่มต้น.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # คัดลอกมาสเตอร์สไลด์เริ่มต้น.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** มาสเตอร์สไลด์ให้วิธีการใช้แบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันทั่วทั้งสไลด์ทั้งหมด การเปลี่ยนแปลงใดๆ ที่ทำในมาสเตอร์จะสะท้อนโดยอัตโนมัติบนสไลด์การจัดวางและสไลด์ปกติที่ขึ้นอยู่กับมัน.

> 💡 **Tip 2:** รูปร่างหรือการจัดรูปแบบใดๆ ที่เพิ่มในมาสเตอร์สไลด์จะถูกสืบทอดโดยสไลด์การจัดวางและต่อมาโดยสไลด์ปกติทั้งหมดที่ใช้การจัดวางเหล่านั้น.  
> ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มบนมาสเตอร์สไลด์จะถูกแสดงผลโดยอัตโนมัติบนสไลด์สุดท้าย.

![Master Inheritance Example](master-slide-banner.png)

## **เข้าถึงมาสเตอร์สไลด์**

คุณสามารถเข้าถึงมาสเตอร์สไลด์โดยใช้คอลเลกชัน `Presentation.masters`. ต่อไปนี้คือวิธีดึงและทำงานกับมัน:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # เข้าถึงมาสเตอร์สไลด์แรก.
        first_master_slide = presentation.masters[0]
```

## **ลบมาสเตอร์สไลด์**

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # ลบโดยดัชนี.
        presentation.masters.remove_at(0)

        # หรือ ลบโดยอ้างอิง.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้**

บางงานนำเสนอมีมาสเตอร์สไลด์ที่ไม่ได้ใช้ การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้งานทั้งหมด (แม้กระทั่งที่ทำเครื่องหมายว่า Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** ใช้ `remove_unused(True)` เพื่อล้างมาสเตอร์สไลด์ที่ไม่ได้ใช้และลดขนาดของการนำเสนอ.