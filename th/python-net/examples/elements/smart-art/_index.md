---
title: SmartArt
type: docs
weight: 140
url: /th/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- เพิ่ม SmartArt
- เข้าถึง SmartArt
- ลบ SmartArt
- เค้าโครง SmartArt
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและแก้ไข SmartArt ใน Python ด้วย Aspose.Slides: เพิ่มโหนด, เปลี่ยนเค้าโครงและสไตล์, แปลงเป็นรูปร่างอย่างแม่นยำ, และส่งออกเป็น PPT, PPTX และ ODP."
---
แสดงวิธีการเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ, และเปลี่ยนเค้าโครงโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่ม SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเค้าโครงที่มาพร้อม.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึง SmartArt**

ดึงอ็อบเจกต์ SmartArt ตัวแรกบนสไลด์.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงรูปทรง SmartArt ตัวแรก.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **ลบ SmartArt**

ลบรูปทรง SmartArt จากสไลด์.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นอ็อบเจกต์ SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนเค้าโครง SmartArt**

อัปเดตประเภทเค้าโครงของกราฟิก SmartArt ที่มีอยู่.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นอ็อบเจกต์ SmartArt.
        smart_art = slide.shapes[0]

        # เปลี่ยนเค้าโครง SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```