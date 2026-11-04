---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/python-net/shape-effect
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟ็กต์การสะท้อน
- เอฟเฟกต์แสงเรืองแสง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลงไฟล์ PPT, PPTX และ ODP ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides for Python—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถทำให้รูปร่างโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [fills](/slides/th/python-net/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงสว่างของรูปร่าง ฯลฯ

![เอฟเฟ็กต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างหนึ่งรูปได้

บางการผสมผสานของเอฟเฟกต์ดูดีมากกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset พื้นฐานคือการผสมผสานที่ดูดีของสองหรือมากกว่าเอฟเฟกต์ ด้วยวิธีนี้ เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มอบคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) ที่ให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Python via .NET รองรับเงานอกและเงาด้านในสำหรับรูปร่าง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงแสดงออกมาชัดเจนต่อพื้นหลังของสไลด์ เงาจะขยายออกไปนอกขอบของรูปร่างสร้างความรู้สึกว่ารูปร่างยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Python นี้แสดงวิธีการใช้ [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) กับสี่เหลี่ยม:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![เอฟเฟกต์เงา](shadow_effect.png)

### **ใช้เงาด้านใน**

เมื่อคัดสำเนาการออกแบบภาพของเทมเพลต ให้ใช้เงาด้านในเพื่อให้การ์ดหรือแผงดูมีลักษณะหย่อนลง เงานอกจะขยายออกนอกรูปร่างทำให้ดูเหมือนยกขึ้น ส่วนเงาด้านในจะทำให้ขอบภายในมืดลง

เรียก [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), จากนั้นกำหนดค่า [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). ค่า blur-radius ที่ใหญ่กว่าจะให้ขอบนุ่มขึ้น

ตัวอย่าง Python นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาด้านในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาด้านใน](inner_shadow_effect.png)

เพื่อเอาเงาด้านในออก ให้เรียก [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) บน EffectFormat ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python via .NET คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปร่าง ปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสงและขนาด เอฟเฟกต์นี้ช่วยยกระดับความสวยงามของงานนำเสนอโดยทำให้รูปร่างดูเรียบหรูและทันสมัย ใช้งานง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สามารถประยุกต์อย่างรวดเร็วกับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Python นี้แสดงวิธีการใช้ [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) กับรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรืองแสง**

เพื่อใช้เอฟเฟ็กต์แสงเรืองแสงกับรูปร่างใน Aspose.Slides for Python via .NET คุณสามารถเพิ่มแสงเรืองแสงรอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดจำนวนเล็กน้อย ทำให้ภาพรวมของสไลด์ดูสวยงามยิ่งขึ้น

โค้ด Python นี้แสดงวิธีการใช้ [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) กับรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![เอฟเฟกต์แสงเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบอ่อน**

เพื่อใช้เอฟเฟกต์ขอบอ่อนใน Aspose.Slides for Python via .NET คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะกับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ตามต้องการสำหรับรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

โค้ด Python นี้แสดงวิธีการใช้ [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) กับรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![เอฟเฟกต์ขอบอ่อน](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้ Blur ของรูปทรงเพื่อทำให้ส่วนเติมและเส้นขอบของรูปร่างนุ่มนวลลงโดยยังคงให้รูปทรงแก้ไขได้ เรียก [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) บน EffectFormat ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อ `False` เบลอจะถูกตัดให้พอดีกับขอบเขตที่ทาดังเดิมรวมถึงเส้นขอบ เมื่อ `True` เบลออาจขยายออกไปนอกขอบเขตดังกล่าว การตั้งค่าใด ๆ จะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้การเติม, เส้นขอบและขนาดของรูปร่างเดียวกันทั้งหมด แถวบนใช้ `grow = False`; แถวล่างใช้ `grow = True`.

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อม grow ปิดและเปิด](shape_blur_comparison.png)

ตัวอย่าง Python นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีฟ้าเข้ม ใช้เบลอ 5 จุดแล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียก [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) อีกครั้ง บันทึกทั้งสองสถานะที่เบลอแล้ว จากนั้นเรียก [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) และบันทึกรูปร่างที่ไม่มีเบลอ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Blur ของรูปทรงกระทบต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบอ่อนจะทำให้ขอบของรูปร่างจางหายไป ขณะที่เบลอของเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงรูปภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงกับ EffectFormat ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ใช่ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและแสงเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่มีความไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดบ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลายประเภท รวมถึงออโตช์เชป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้ เอฟเฟกต์จะถูกนำไปใช้กับทั้งกลุ่มโดยรวม.