---
title: หมึก
type: docs
weight: 180
url: /th/python-net/examples/elements/ink/
keywords:
- หมึก
- เข้าถึงหมึก
- ลบหมึก
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการหมึกดิจิทัลบนสไลด์ใน Python ด้วย Aspose.Slides: เพิ่มเส้นปากกา, แก้ไขเส้นทาง, ตั้งค่าสีและความกว้าง, และส่งออกผลลัพธ์สำหรับ PowerPoint และ OpenDocument."
---
ให้ตัวอย่างของการเข้าถึงรูปร่างหมึกที่มีอยู่แล้วและการลบออกโดยใช้ **Aspose.Slides for Python via .NET**.

> ❗ **หมายเหตุ:** รูปร่างหมึกเป็นการป้อนข้อมูลจากอุปกรณ์เฉพาะทาง. Aspose.Slides ไม่สามารถสร้างเส้นหมึกใหม่โดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่ได้.

## **เข้าถึงหมึก**

รับรูปร่างหมึกแรกจากสไลด์.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **ลบหมึก**

ลบรูปร่างหมึกออกจากสไลด์.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นวัตถุ Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```