---
title: ส่วน
type: docs
weight: 90
url: /th/python-net/examples/elements/section/
keywords:
- ส่วน
- ส่วนสไลด์
- เพิ่มส่วน
- เข้าถึงส่วน
- ลบส่วน
- เปลี่ยนชื่อส่วน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการส่วนสไลด์ใน Python ด้วย Aspose.Slides: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่ได้ง่าย, ย้ายสไลด์ระหว่างส่วน, และควบคุมการมองเห็นสำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for Python via .NET** อย่างโปรแกรมเมติก

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มต้นที่สไลด์เฉพาะ

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มส่วนใหม่และระบุสไลด์ที่เป็นจุดเริ่มต้นของส่วน
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงส่วน**

รับส่วนจากงานนำเสนอ

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # เข้าถึงส่วนโดยใช้ดัชนี.
        section = presentation.sections[0]
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้านี้

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # ลบส่วน.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # เปลี่ยนชื่อส่วน.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```