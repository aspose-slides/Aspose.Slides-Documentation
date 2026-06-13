---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/python-net/examples/elements/hyperlink/
keywords:
- ไฮเปอร์ลิงก์
- เพิ่มไฮเปอร์ลิงก์
- เข้าถึงไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, แก้ไขและลบไฮเปอร์ลิงก์ใน Python ด้วย Aspose.Slides: ข้อความลิงก์, รูปร่าง, สไลด์, URL และอีเมล; ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX และ ODP."
---
สาธิตการเพิ่ม, การเข้าถึง, การลบ, และการอัปเดตไฮเปอร์ลิงก์บนรูปร่างโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปร่างสี่เหลี่ยมผืนผ้าที่มีไฮเปอร์ลิงก์ชี้ไปยังเว็บไซต์ภายนอก.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูปร่าง.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **ลบไฮเปอร์ลิงก์**

ลบไฮเปอร์ลิงก์ออกจากข้อความของรูปร่าง.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่แล้ว ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งเลียนแบบการอัปเดตไฮเปอร์ลิงก์ของ PowerPoint อย่างปลอดภัย.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # การเปลี่ยนไฮเปอร์ลิงก์ภายในข้อความที่มีอยู่ควรทำผ่าน
        # HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
        # นี้เลียนแบบวิธีที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```