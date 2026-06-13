---
title: สไลด์
type: docs
weight: 10
url: /th/python-net/examples/elements/slide/
keywords:
- สไลด์
- เพิ่มสไลด์
- เข้าถึงสไลด์
- ดัชนีสไลด์
- คัดลอกสไลด์
- จัดลำดับสไลด์
- ลบสไลด์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการสไลด์ใน Python ด้วย Aspose.Slides: สร้าง, คัดลอก, จัดลำดับใหม่, ซ่อน, ตั้งค่าพื้นหลังและขนาด, ใช้การเปลี่ยนภาพ, และส่งออกสำหรับ PowerPoint และ OpenDocument."
---
บทความนี้นำเสนอชุดตัวอย่างที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for Python via .NET** คุณจะได้เรียนรู้วิธีเพิ่ม, เข้าถึง, คัดลอก, จัดลำดับใหม่, และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างจะรวมคำอธิบายสั้น ๆ ตามด้วยส่วนโค้ดใน Python.

## **เพิ่มสไลด์**

ในการเพิ่มสไลด์ใหม่ คุณต้องเลือกเลย์เอาต์ก่อน ในตัวอย่างนี้ เราใช้เลย์เอาต์ `Blank` และเพิ่มสไลด์เปล่าลงในพรีเซนเทชัน

```py
def add_slide():
    with slides.Presentation() as presentation:
        # สไลด์แต่ละอันอ้างอิงจากเลย์เอาต์ซึ่งเองก็อ้างอิงจากมาสเตอร์สไลด์.
        # ใช้เลย์เอาต์ Blank เพื่อสร้างสไลด์ใหม่.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # เพิ่มสไลด์เปล่าใหม่โดยใช้เลย์เอาต์ที่เลือก.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **เคล็ดลับ:** แต่ละเลย์เอาต์ของสไลด์มาจากมาสเตอร์สไลด์ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวจองที่วางไว้ ภาพด้านล่างแสดงให้เห็นว่ามาสเตอร์สไลด์และเลย์เอ็ทที่เกี่ยวข้องจัดระเบียบอย่างไรใน PowerPoint.

![ความสัมพันธ์ระหว่างมาสเตอร์และเลย์เอ็ท](master-layout-slide.png)

## **เข้าถึงสไลด์ตามดัชนี**

คุณสามารถเข้าถึงสไลด์โดยใช้ดัชนีของมัน ซึ่งเป็นประโยชน์สำหรับการวนผ่านหรือแก้ไขสไลด์เฉพาะ

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # เข้าถึงสไลด์ตามดัชนี.
        first_slide = presentation.slides[0]
```

## **คัดลอกสไลด์**

ตัวอย่างนี้แสดงวิธีคัดลอกสไลด์ที่มีอยู่ สไลด์ที่คัดลอกจะถูกเพิ่มโดยอัตโนมัติไปที่ท้ายของคอลเลกชันสไลด์

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # คัดลอกสไลด์; มันจะถูกเพิ่มที่ส่วนท้ายของพรีเซนเทชัน.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดลำดับสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์โดยย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ไปยังตำแหน่งแรก

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # ย้ายสไลด์ไปยังตำแหน่งแรก (สไลด์อื่นเลื่อนลง).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบสไลด์**

เพื่อจะลบสไลด์ เพียงอ้างอิงสไลด์นั้นและเรียก `remove` ตัวอย่างนี้ลบสไลด์แรก

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # ลบสไลด์.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```