---
title: แอนิเมชัน
type: docs
weight: 100
url: /th/python-net/examples/elements/animation/
keywords:
- แอนิเมชัน
- เพิ่มแอนิเมชัน
- เข้าถึงแอนิเมชัน
- ลบแอนิเมชัน
- ลำดับแอนิเมชัน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมแอนิเมชันสไลด์ใน Python ด้วย Aspose.Slides: เพิ่ม แก้ไข และลบเอฟเฟกต์ เวลา และทริกเกอร์เพื่อสร้างการนำเสนอแบบไดนามิกในรูปแบบ PPT, PPTX และ ODP."
---
แสดงวิธีสร้างแอนิเมชันแบบง่ายและจัดการลำดับของมันโดยใช้ **Aspose.Slides for Python via .NET**.

## **Add an Animation**
สร้างรูปสี่เหลี่ยมและใช้เอฟเฟกต์ค่อยหายที่ทำงานเมื่อคลิก.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # เพิ่มเอฟเฟกต์ค่อยจาง.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Animation**
ดึงเอฟเฟกต์แอนิเมชันแรกจากไทม์ไลน์ของสไลด์.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงเอฟเฟกต์แอนิเมชันแรก.
        effect = slide.timeline.main_sequence[0]
```

## **Remove an Animation**
ลบเอฟเฟกต์แอนิเมชันออกจากลำดับ.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่าลำดับหลักมีอย่างน้อยหนึ่งเอฟเฟกต์.
        effect = slide.timeline.main_sequence[0]

        # ลบเอฟเฟกต์.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sequence Animations**
เพิ่มหลายเอฟเฟกต์และแสดงลำดับการเกิดของแอนิเมชัน.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```