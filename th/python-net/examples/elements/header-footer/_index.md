---
title: ส่วนหัวส่วนท้าย
type: docs
weight: 220
url: /th/python-net/examples/elements/header-footer/
keywords:
- ส่วนหัวส่วนท้าย
- เพิ่มส่วนหัวส่วนท้าย
- อัปเดตส่วนหัวส่วนท้าย
- ตั้งค่าวันที่และเวลา
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนใต้ใน Python ด้วย Aspose.Slides: เพิ่มหรือแก้ไขวันที่/เวลา, หมายเลขสไลด์, และข้อความส่วนท้าย, แสดงหรือซ่อนตัวยึดในไฟล์ PPT, PPTX และ ODP."
---
แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวยึดวันที่และเวลาที่ใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความในพื้นที่ส่วนท้ายของสไลด์และทำให้แสดงผล.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวยึดวันที่และเวลาบนสไลด์.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```