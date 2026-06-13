---
title: บันทึก
type: docs
weight: 240
url: /th/python-net/examples/elements/note/
keywords:
- บันทึก
- เพิ่มสไลด์บันทึกโน้ต
- เข้าถึงสไลด์บันทึกโนต
- ลบสไลด์บันทึกโนต
- อัปเดตข้อความบันทึกโนต
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, อ่าน, แก้ไข, และส่งออกบันทึกผู้พูดใน Python ด้วย Aspose.Slides: จัดรูปแบบข้อความ, จัดการบันทึกต่อสไลด์, และควบคุมการมองเห็นใน PowerPoint และ OpenDocument."
---
แสดงวิธีการเพิ่ม, อ่าน, ลบและอัปเดตสไลด์บันทึกโน้ตโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มสไลด์บันทึกโน้ต**

สร้างสไลด์บันทึกโน้ตและกำหนดข้อความให้กับมัน.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงสไลด์บันทึกโน้ต**

อ่านข้อความจากสไลด์บันทึกโน้ตที่มีอยู่.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **ลบสไลด์บันทึกโน้ต**

ลบสไลด์บันทึกโน้ตที่เชื่อมโยงกับสไลด์.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # ลบสไลด์บันทึกโน้ต.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตข้อความบันทึกโน้ต**

เปลี่ยนข้อความของสไลด์บันทึกโน้ต.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # อัปเดตข้อความบันทึกโน้ต.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```