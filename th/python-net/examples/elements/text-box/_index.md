---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/python-net/examples/elements/text-box/
keywords:
- กล่องข้อความ
- เพิ่มกล่องข้อความ
- เข้าถึงกล่องข้อความ
- ลบกล่องข้อความ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและจัดรูปแบบกล่องข้อความใน Python ด้วย Aspose.Slides: กำหนดฟอนต์, การจัดแนว, การตัดบรรทัด, การปรับอัตโนมัติ, และลิงก์เพื่อปรับปรุงสไลด์สำหรับ PowerPoint และ OpenDocument."
---
ใน Aspose.Slides, **กล่องข้อความ** จะถูกแทนด้วย `AutoShape` เกือบทุกรูปร่างสามารถบรรจุข้อความได้, แต่กล่องข้อความปกติจะไม่มีสีเติมหรือขอบและแสดงข้อความเท่านั้น.

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึง, และลบกล่องข้อความโดยโปรแกรม

## **เพิ่มกล่องข้อความ**

กล่องข้อความเพียงเป็น `AutoShape` ที่ไม่มีสีเติมหรือขอบและมีข้อความที่จัดรูปแบบบางส่วน นี่คือวิธีการสร้างหนึ่งรายการ:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # สร้างรูปสี่เหลี่ยมผืนผ้า (ค่าเริ่มต้นเติมสีพร้อมขอบและไม่มีข้อความ).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # ลบการเติมสีและขอบเพื่อให้ดูเหมือนกล่องข้อความทั่วไป.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # ตั้งค่าการจัดรูปแบบข้อความ.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # กำหนดเนื้อหาข้อความจริง.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **หมายเหตุ:** `AutoShape` ใด ๆ ที่มี `TextFrame` ไม่ว่างเปล่าสามารถทำหน้าที่เป็นกล่องข้อความได้.

## **เข้าถึงกล่องข้อความตามเนื้อหา**

เพื่อค้นหากล่องข้อความทั้งหมดที่มีคีย์เวิร์ดเฉพาะ (เช่น "Slide") ให้วนลูปผ่านรูปร่างและตรวจสอบข้อความของพวกมัน:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # เฉพาะ AutoShapes เท่านั้นที่สามารถบรรจุข้อความที่แก้ไขได้.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # ทำบางอย่างกับกล่องข้อความที่ตรงกัน.
                    pass
```

## **ลบกล่องข้อความตามเนื้อหา**

ตัวอย่างนี้ค้นหาและลบกล่องข้อความทั้งหมดบนสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # ค้นหารูปทรงที่ต้องลบซึ่งเป็น AutoShapes ที่มีคำว่า "Slide" อยู่ในข้อความ.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # ลบแต่ละรูปร่างที่ตรงกันออกจากสไลด์.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของคอลเลกชันรูปร่างเสมอก่อนทำการแก้ไขระหว่างการวนลูปเพื่อหลีกเลี่ยงข้อผิดพลาดการแก้ไขคอลเลกชัน