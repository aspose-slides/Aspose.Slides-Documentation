---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/python-net/examples/elements/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- เข้าถึงการเปลี่ยนสไลด์
- ลบการเปลี่ยนสไลด์
- ระยะเวลาการเปลี่ยนสไลด์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Python ด้วย Aspose.Slides: เลือกประเภท ความเร็ว เสียง และเวลา เพื่อปรับปรุงการนำเสนอในรูปแบบ PPT, PPTX และ ODP."
---
สาธิตการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการกำหนดเวลา ด้วย **Aspose.Slides for Python via .NET**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟกต์การเปลี่ยนแบบจางกับสไลด์แรก.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # ใช้การเปลี่ยนแบบจาง
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดไว้ในสไลด์ปัจจุบัน.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงประเภทการเปลี่ยนแปลง.
        transition_type = slide.slide_show_transition.type
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟกต์การเปลี่ยนใด ๆ โดยตั้งค่าประเภทเป็น `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # ลบการเปลี่ยนโดยตั้งค่าเป็นไม่มี.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าระยะเวลาการเปลี่ยนสไลด์**

ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเปลี่ยนต่อไปโดยอัตโนมัติ.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # ในหน่วยมิลลิวินาที.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```