---
title: กลุ่มรูป
type: docs
weight: 170
url: /th/python-net/examples/elements/group-shape/
keywords:
- กลุ่ม
- เพิ่มรูปกลุ่ม
- เข้าถึงรูปกลุ่ม
- ลบรูปกลุ่ม
- ยกเลิกการจัดกลุ่มรูป
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "ทำงานกับรูปกลุ่มใน Python โดยใช้ Aspose.Slides: สร้างและยกเลิกการจัดกลุ่ม, จัดเรียงรูปร่างลูก, ตั้งการแปลงและขอบเขตสำหรับ PowerPoint และ OpenDocument."
---
ตัวอย่างการสร้างกลุ่มของรูปทรง, การเข้าถึง, การยกเลิกการจัดกลุ่มและการลบโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มรูปกลุ่ม**

สร้างกลุ่มที่มีรูปร่างพื้นฐานสองรูป.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มรูปกลุ่ม.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงรูปกลุ่ม**

ดึงรูปกลุ่มแรกจากสไลด์.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงรูปกลุ่มแรกบนสไลด์.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **ลบรูปกลุ่ม**

ลบรูปกลุ่มจากสไลด์.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นรูปกลุ่ม.
        group = slide.shapes[0]

        # ลบรูปกลุ่ม.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ยกเลิกการจัดกลุ่มรูป**

ย้ายรูปออกจากคอนเทนเนอร์กลุ่ม.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นรูปกลุ่ม.
        group = slide.shapes[0]

        # ย้ายรูปร่างออกจากกลุ่ม.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```