---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/python-net/shape-effect
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แปลงไฟล์ PPT, PPTX และ ODP ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Python—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปทรงโดดเด่นได้ แต่พวกมันแตกต่างจาก [การเติม](/slides/th/python-net/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงเรืองแสงของรูปทรง ฯลฯ

![เอฟเฟ็กต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกชนิดที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้

บางการผสมของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมที่ดูดีแล้วของสองหรือหลายเอฟเฟกต์ ด้วยวิธีนี้ การเลือก Preset จะช่วยให้คุณไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides ให้คุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) ที่ช่วยให้คุณใส่เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใส่เอฟเฟกต์เงา**

Aspose.Slides for Python via .NET รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับสี ทิศทาง ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใส่เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบรูปทรง ทำให้ดูเหมือนรูปทรงลอยขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทางและรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของแม่แบบของคุณ

Python โค้ดนี้แสดงวิธีใส่ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) ให้กับสี่เหลี่ยมผืนผ้า:

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

#### **ควบคุมทิศทางเงาเมื่อรูปทรงหมุน**

โดยค่าเริ่มต้น [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) เป็น `True` ดังนั้นเงาจะหมุนตามรูปทรง เพื่อให้รูปทรงที่มีการหมุนต่างกันดูเหมือนได้รับแสงจากทิศทางเดียวกัน ให้ตั้งค่าคุณสมบัตินี้เป็น `False` และกำหนด [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) ของเงาให้เหมือนกัน

ตัวอย่างสร้างลูกศรสองอาญที่มีเงาสีเทาเลื่อนไปทางขวา 42 จุด (`direction = 0`) แล้วทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

บนสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงด้านล่าง ส่วนลูกศรขวายังคงทำเงาตกไปทางขวา ทิศทางที่กำหนดยังคงเป็น 0° สำหรับเงาทั้งสอง

![การแสดงผล PowerPoint ก่อนและหลังการหมุน 90° เงาทั้งสองเริ่มจากด้านขวา หลังจากหมุน เงาจะย้ายไปอยู่ใต้ลูกศรซ้ายและคงอยู่ทางด้านขวาของลูกศรขวา](arrow-shadow-rotation.png)

### **ใส่เงาภายใน**

เมื่อทำการจำลองสไตล์ภาพของแม่แบบ ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเป็นช่องรบกวน เงานอกขยายออกนอกรูปทรงทำให้ดูเหมือนยกขึ้น ส่วนเงาภายในจะทำให้ขอบภายในของรูปทรงเงา

เรียกใช้ [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) แล้วกำหนดค่า [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) ค่า blur-radius ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

Python ตัวอย่างนี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX:

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

![สี่เหลี่ยมสีฟ้าอ่อนกับเงาภายใน](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียกใช้ [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) บนรูปทรงที่ต้องการ

### **ใส่, เปลี่ยน, และลบเงา Preset**

เรียกใช้ [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) และตั้งค่าคุณสมบัติ [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) ของเงาเป็นค่าของ [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) เพื่อสลับสไตล์ ให้เปลี่ยน preset บนรูปทรงเดียวกัน เรียกใช้ [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนข้างกันบนสไลด์เดียว มันทำสำเนาสี่เหลี่ยมก่อนแต่ละการเปลี่ยนเพื่อให้คุณเปรียบเทียบผลลัพธ์ เงาทั้งสองเลื่อนออก 10 จุด ทิศทาง 225° จะทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม และ 45° จะทำให้เงาที่สองอยู่ด้านล่างขวา

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
| ![No shadow](preset_shadow_original.png) | ![Top-left drop shadow](preset_shadow_top_left.png) | ![Bottom-right drop shadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใส่เอฟเฟกต์การสะท้อน**

เพื่อใส่เอฟเฟกต์การสะท้อนใน Aspose.Slides for Python via .NET คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งใสและขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามของงานนำเสนอด้วยการทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพ ใช้ง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างสม่ำเสมอ

Python โค้ดนี้แสดงวิธีใส่ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) ให้กับรูปทรง:

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

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใส่เอฟเฟกต์แสงเรืองแสง**

เพื่อใส่เอฟเฟกต์แสงเรืองแสงให้กับรูปทรงใน Aspose.Slides for Python via .NET คุณสามารถเพิ่มออร่าอ่อนนุ่มรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่น่าสนใจให้กับการนำเสนอของคุณ ใช้ง่ายด้วยโค้ดเพียงเล็กน้อย ช่วยปรับรูปลักษณ์โดยรวมของสไลด์

Python โค้ดนี้แสดงวิธีใส่ [เอฟเฟกต์แสงเรืองแสง](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) ให้กับรูปทรง:

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

## **ใส่เอฟเฟกต์ขอบนุ่ม**

เพื่อใส่เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Python via .NET คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลักษณะที่ละเอียดอ่อนและปราณีต เหมาะกับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ

Python โค้ดนี้แสดงวิธีใส่ [ขอบนุ่ม](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) ให้กับรูปทรง:

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

## **ใส่เอฟเฟกต์เบลอ**

ใช้การเบลอรูปทรงเพื่อทำให้การเติมและเส้นขอบของรูปทรงนุ่มลงในขณะที่รักษาความสามารถในการแก้ไขรูปทรงไว้ เรียกใช้ [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) บนรูปทรงที่ต้องการ รัศมีวัดเป็นจุด (1/72 นิ้ว) ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) ควบคุมขอบที่มองเห็นของเอฟเฟกต์ หาก `False` เบลอจะถูกคลิปที่ขอบที่วาดเดิมรวมถึงเส้นขอบ หาก `True` เบลออาจขยายออกนอกขอบเหล่านั้น การตั้งค่าใด ๆ จะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติม เส้นขอบและขนาดรูปทรงเดียวกันทั้งหมด แถวบนใช้ `grow = False` แถวล่างใช้ `grow = True`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อมการปิดและเปิดการขยาย](shape_blur_comparison.png)

Python ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มที่มีเส้นขอบสีน้ำเงินเข้ม ใช้เบลอ 5 จุด แล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียกใช้ [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) อีกครั้ง บันทึกสถานะที่เบลอแล้วทั้งสอง แล้วเรียกใช้ [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) และบันทึกรูปทรงโดยไม่มีเบลอ

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

การเบลอรูปทรงส่งผลต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มจะทำให้ขอบรูปทรงจางหายไป ในขณะที่เบลอเงาจะทำให้เงานุ่มลง ผลการแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใส่เบลอโดยตรงบนฟอร์แมตเอฟเฟกต์ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่หลายเอฟเฟกต์ให้กับรูปทรงเดียวกันได้หรือไม่?**

ใช่ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และแสงเรืองแสงบนรูปทรงเดียวเพื่อให้ได้ลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใส่เอฟเฟกต์ให้กับรูปทรงใดได้บ้าง?**

คุณสามารถใส่เอฟเฟกต์ให้กับรูปทรงต่าง ๆ รวมถึงอัตตรูป แผนภูมิ ตาราง รูปภาพ วัตถุ SmartArt วัตถุ OLE และอื่น ๆ

**ฉันสามารถใส่เอฟเฟกต์ให้กับกลุ่มรูปทรงได้หรือไม่?**

ใช่ คุณสามารถใส่เอฟเฟกต์ให้กับกลุ่มรูปทรงได้ เอฟเฟกต์จะนำไปใช้กับทั้งกลุ่มโดยรวม