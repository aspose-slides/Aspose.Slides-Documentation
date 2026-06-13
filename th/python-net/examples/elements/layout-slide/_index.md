---
title: สไลด์เลย์เอาต์
type: docs
weight: 20
url: /th/python-net/examples/elements/layout-slide/
keywords:
- สไลด์เลย์เอาต์
- เพิ่มสไลด์เลย์เอาต์
- เข้าถึงสไลด์เลย์เอาต์
- ลบสไลด์เลย์เอาต์
- สไลด์เลย์เอาต์ที่ไม่ได้ใช้
- ทำสำเนาสไลด์เลย์เอาต์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ใช้ Python เพื่อจัดการสไลด์เลย์เอาต์ด้วย Aspose.Slides: สร้าง, ใช้, ทำสำเนา, เปลี่ยนชื่อ และปรับแต่งตัวหยุดตำแหน่งและธีมในงานนำเสนอสำหรับ PPT, PPTX และ ODP."
---
บทความนี้แสดงวิธีการทำงานกับ **Layout Slides** ใน Aspose.Slides สำหรับ Python ผ่าน .NET. Layout slide กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, ทำสำเนา, และลบ layout slides, รวมถึงทำความสะอาดที่ไม่ได้ใช้เพื่อลดขนาดของงานนำเสนอได้

## **เพิ่ม Layout Slide**

คุณสามารถสร้าง layout slide แบบกำหนดเองเพื่อกำหนดรูปแบบที่นำกลับมาใช้ใหม่ได้

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # สร้างสไลด์เลย์เอาต์ด้วยประเภทและชื่อที่ระบุ.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Layout slides ทำหน้าที่เป็นแม่แบบสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปครั้งเดียวและนำกลับมาใช้ใหม่ในหลายสไลด์
> 💡 **Tip 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงใน layout slide, สไลด์ทั้งหมดที่อิงตามเลย์เอาต์นั้นจะทำการแสดงเนื้อหาที่แชร์นี้โดยอัตโนมัติ ภาพหน้าจอด้านล่างแสดงสองสไลด์ที่แต่ละอันสืบทอดกล่องข้อความจาก layout slide เดียวกัน

![สไลด์ที่สืบทอดเนื้อหา Layout](layout-slide-result.png)

## **เข้าถึง Layout Slide**

สามารถเข้าถึง Layout slides ได้โดยใช้ดัชนีหรือโดยประเภทของเลย์เอาต์ (เช่น `Blank`, `Title`, `SectionHeader`, เป็นต้น)

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # เข้าถึงโดยใช้ดัชนี.
        first_layout_slide = presentation.layout_slides[0]

        # เข้าถึงโดยประเภทเลย์เอาต์.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **ลบ Layout Slide**

คุณสามารถลบ layout slide เฉพาะได้หากไม่ต้องการใช้แล้ว

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # รับสไลด์เลย์เอาต์ตามประเภทและลบออก.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

เพื่อลดขนาดของงานนำเสนอ คุณอาจต้องการลบ layout slides ที่ไม่มีสไลด์ปกติใดใช้

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # ลบสไลด์เลย์เอาต์ทั้งหมดที่ไม่มีการอ้างอิงโดยสไลด์ใดโดยอัตโนมัติ.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **สำเนา Layout Slide**

คุณสามารถทำสำเนา layout slide ได้โดยใช้เมธอด `AddClone`

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # รับสไลด์เลย์เอาต์ที่มีอยู่ตามประเภท.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # ทำสำเนาสไลด์เลย์เอาต์ไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เลย์เอาต์.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **สรุป:** Layout slides เป็นเครื่องมือที่มีประสิทธิภาพสำหรับการจัดการรูปแบบที่สอดคล้องกันระหว่างสไลด์ Aspose.Slides ให้การควบคุมเต็มรูปแบบในการสร้าง, จัดการ, และปรับแต่ง layout slides