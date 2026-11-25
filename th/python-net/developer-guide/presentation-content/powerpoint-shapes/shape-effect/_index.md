---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/python-net/shape-effect
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แปลงไฟล์ PPT, PPTX และ ODP ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ขณะเดียวกันเอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปร่างโดดเด่นได้ แต่แตกต่างจาก [การเติมสี](/slides/th/python-net/shape-formatting/#gradient-fill) หรือ เส้นขอบ. การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง, กระจายแสงเรืองแสงของรูปร่าง, เป็นต้น.

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าอื่น ๆ ด้วยเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset โดยพื้นฐานคือการผสมผสานที่ดูดีของสองหรือมากกว่าหนึ่งเอฟเฟกต์ ด้วยวิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลา ทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมผสานที่ดี

Aspose.Slides มีคุณสมบัติและวิธีการภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Python via .NET รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทาง, และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลโดดเด่นต่อพื้นหลังของสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง สร้างความรู้สึกว่ารูปร่างยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทาง, และรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

ตัวอย่างโค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) กับสี่เหลี่ยม:

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

![Shadow effect](shadow_effect.png)

### **ใช้เงาภายใน**

เมื่อทำซ้ำสไตล์ภาพของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือพาเนลดูเป็นบานเลื่อนภายใน เงานอกขยายออกนอกรูปร่างทำให้ดูยกขึ้น ในขณะที่เงาภายในทำให้ขอบด้านในของรูปร่างมีเงา

เรียก [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), จากนั้นกำหนดค่า [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Python นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาดำและบันทึกเป็นไฟล์ PPTX:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายในสีเทาดำ](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) บนรูปแบบเอฟเฟกต์ของรูปร่าง

### **ใช้, เปลี่ยนแปลง, และลบ Preset Shadow**

เรียก [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) และตั้งค่าคุณสมบัติ [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) ของเงาเป็นค่า [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) เพื่อสลับสไตล์ ให้เปลี่ยน Preset บนรูปร่างเดียวกัน เรียก [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) เพื่อลบเงาโดยยังคงรักษาการเติมสีและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนข้างเคียงกันบนสไลด์เดียว มันจะทำการโคลนสี่เหลี่ยมก่อนแต่ละการเปลี่ยนแปลงเพื่อให้คุณเปรียบเทียบผลลัพธ์ ทั้งสองเงาถูกย้ายโดย 10 จุด ทิศทาง 225° จะวางเงาแรกเหนือและ左ของสี่เหลี่ยม, และ 45° จะวางเงาที่สองด้านล่างและขวา

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกด้านซ้ายบน](preset_shadow_top_left.png) | ![เงาตกด้านขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python via .NET, คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะทาง, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามของงานนำเสนอด้วยการให้รูปร่างดูเรียบหรูและเป็นมืออาชีพ ใช้ง่ายด้วยโค้ดแบบง่าย ทำให้สามารถประยุกต์ใช้งานได้อย่างรวดเร็วบนหลายองค์ประกอบเพื่อให้การออกแบบสอดคล้องกัน

ตัวอย่างโค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) กับรูปร่าง:

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

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปร่างใน Aspose.Slides for Python via .NET, คุณสามารถเพิ่มออร่าระบายแสงอ่อนรอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มความดึงดูดตาให้กับงานนำเสนอของคุณ ใช้ง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สไลด์ทั้งหมดดูมีชีวิตชีวาขึ้น

ตัวอย่างโค้ด Python นี้แสดงวิธีการใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) กับรูปร่าง:

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

![เอฟเฟกต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Python via .NET, คุณสามารถสร้างการเปลี่ยนแปลงราบรื่นและเบลอรอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะกับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับรัศมีได้ง่ายตามต้องการเพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

ตัวอย่างโค้ด Python นี้แสดงวิธีการใช้ [ขอบนุ่ม](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) กับรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้การเบลอรูปร่างเพื่อทำให้การเติมสีและเส้นขอบของรูปร่างนุ่มลงโดยยังคงให้รูปร่างสามารถแก้ไขได้ เรียก [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าไม่เป็นลบ, ค่ามากขึ้นจะให้ความเบลอที่แรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนรูปลักษณ์

การตั้งค่า [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) ควบคุมขอบที่มองเห็นของเอฟเฟกต์ เมื่อเป็น `False` เบลอจะถูกตัดให้พอดีกับขอบที่ทาด้วยสีรวมถึงเส้นขอบ เมื่อเป็น `True` เบลอสามารถขยายออกไปเกินขอบเหล่านั้นได้ ทั้งสองค่าไม่ได้เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้การเติมสี, เส้นขอบ, และขนาดรูปร่างเดียวกันทั่วทั้งตัวอย่าง แถวบนใช้ `grow = False`; แถวล่างใช้ `grow = True`.

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด, โดยมีการเปิด/ปิด grow](shape_blur_comparison.png)

ตัวอย่าง Python นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม, ใช้เบลอ 5 จุด, จากนั้นอัปเดตเป็นเบลอ 15 จุดโดยเรียก [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) อีกครั้ง บันทึกทั้งสองสถานะที่เบลอ แล้วเรียก [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) และบันทึกรูปร่างโดยไม่มีเบลอ

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

การเบลอรูปร่างส่งผลต่อการเติมสีและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มจะทำให้ขอบของรูปร่างจางลง, ในขณะที่เบลอเงาจะทำให้เงาเท่านั้นนุ่มลง. เอฟเฟกต์การแปลงรูปทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงบนรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ใช่, คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสง บนรูปร่างเดียวเพื่อให้ดูมีไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลายประเภท รวมถึงอัตโนมัติรูปร่าง, ชาร์ต, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่รวมกลุ่มกันได้หรือไม่?**

ใช่, คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่รวมกลุ่มกันได้ เอฟเฟกต์จะถูกใช้กับกลุ่มทั้งหมด.