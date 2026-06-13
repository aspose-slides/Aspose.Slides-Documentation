---
title: ใช้เอฟเฟกต์รูปทรงในการนำเสนอด้วย Python
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/python-net/shape-effect
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรือง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลงไฟล์ PPT, PPTX และ ODP ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในเวลาไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถใช้ทำให้รูปร่างโดดเด่นได้ แต่ก็แตกต่างจาก [fills](/slides/th/python-net/shape-formatting/#gradient-fill) หรือขอบ การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงเรืองของรูปร่าง เป็นต้น

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถนำไปใช้กับรูปร่างได้ คุณสามารถนำเอฟเฟกต์หนึ่งหรือหลายประเภทไปใช้กับรูปร่างได้  

* การผสมผสานเอฟเฟกต์บางอย่างดูดีกว่าบางอย่าง ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset นั้นเป็นการผสมผสานที่ดูดีของเอฟเฟกต์สองประเภทหรือมากกว่า ด้วยวิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/effectformat/) ที่อนุญาตให้คุณนำเอฟเฟกต์เดียวกันไปใช้กับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์เงานอก (`outer_shadow_effect`) กับสี่เหลี่ยมผืนผ้า:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปร่าง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เอฟเฟ็กต์แสงเรือง**

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟ็กต์แสงเรืองกับรูปร่าง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เอฟเฟ็กต์ขอบอ่อน**

โค้ด Python นี้แสดงวิธีการใช้ขอบอ่อนกับรูปร่าง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสานเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และแสงเรืองบนรูปร่างเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงออโตชเป้น, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด