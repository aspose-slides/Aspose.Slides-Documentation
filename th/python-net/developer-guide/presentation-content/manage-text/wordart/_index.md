---
title: สร้างและใช้เอฟเฟ็กต์ WordArt ใน Python
linktitle: WordArt
type: docs
weight: 110
url: /th/python-net/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟ็กต์ WordArt
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การแสดงผล
- เอฟเฟ็กต์เรืองแสง
- การแปลง WordArt
- เอฟเฟ็กต์ 3D
- เอฟเฟ็กต์เงานอก
- เอฟเฟ็กต์เงาด้านใน
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งเอฟเฟ็กต์ WordArt ใน Aspose.Slides สำหรับ Python ผ่าน .NET คู่มือขั้นตอนนี้ช่วยให้นักพัฒนาปรับปรุงการนำเสนอด้วยข้อความที่มีสไตล์และเป็นมืออาชีพใน Python."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่สวยงามและมีสไตล์ให้กับงานนำเสนอ PowerPoint ของคุณได้อย่างมีเสน่ห์ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt ด้วยโปรแกรมได้เช่นเดียวกับใน Microsoft PowerPoint — โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมเกี่ยวกับการทำงานกับ WordArt รวมถึงวิธีการใช้การแปลงข้อความ, สไตล์การเติม, ขอบ, เงา, และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาการนำเสนอของคุณแสดงออกได้เต็มอิ่มและน่าสนใจ WordArt ทำให้คุณปฏิบัติต่อข้อความเหมือนเป็นวัตถุกราฟิก มันประกอบด้วยเอฟเฟกต์หรือการปรับเปลี่ยนพิเศษที่นำไปใช้กับข้อความเพื่อทำให้ดูน่าสนใจหรือโดดเด่นยิ่งขึ้น

**WordArt ใน Microsoft PowerPoint**

เพื่อใช้ WordArt ใน Microsoft PowerPoint คุณต้องเลือกหนึ่งในเทมเพลต WordArt ที่กำหนดไว้ล่วงหน้า เทมเพลต WordArt คือชุดของเอฟเฟกต์ที่นำไปใช้กับข้อความหรือรูปทรงของมัน

**WordArt ใน Aspose.Slides**

ใน Aspose.Slides for Python via .NET 20.10 เราได้เพิ่มการรองรับ WordArt และทำการปรับปรุงคุณลักษณะนี้ในรุ่นต่อ ๆ ไปของ Aspose.Slides for Python via .NET  

ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้างเทมเพลต WordArt ของคุณเอง (เอฟเฟกต์เดียวหรือการผสมผสานของหลายเอฟเฟกต์) ด้วย Python และนำไปใช้กับข้อความได้อย่างง่ายดาย  

## สร้างเทมเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความ

**ใช้ Aspose.Slides** 

ก่อนแรก เราจะสร้างข้อความง่าย ๆ ด้วยโค้ด Python นี้: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
ต่อมา เราตั้งค่าความสูงของฟอนต์ของข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์เด่นชัดขึ้นโดยใช้โค้ดนี้:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArt ใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดไว้ล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถระบุการตั้งค่าสำหรับ WordArt ใหม่ได้  

นี่คือตัวเลือกหรือพารามิเตอร์ที่มีให้เลือกบางส่วน:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เราจะใช้สีรูปแบบ SmallGrid กับข้อความและเพิ่มขอบข้อความสีดำความหนา 1 ด้วยโค้ดนี้:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

ผลลัพธ์ของข้อความ:

![todo:image_alt_text](image-20200930114108-4.png)

## การใช้เอฟเฟกต์ WordArt อื่น ๆ

**ใช้ Microsoft PowerPoint**

จากส่วนติดต่อของโปรแกรม คุณสามารถใช้เอฟเฟกต์เหล่านี้กับข้อความ, กล่องข้อความ, รูปร่าง หรือองค์ประกอบที่คล้ายกันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์เงา (Shadow), การสะท้อน (Reflection) และการเรืองแสง (Glow) สามารถใช้กับข้อความได้; เอฟเฟกต์รูปแบบ 3D (3D Format) และการหมุน 3D (3D Rotation) สามารถใช้กับกล่องข้อความได้; คุณสมบัติขอบมน (Soft Edges) สามารถใช้กับอ็อบเจ็กต์ Shape (ยังคงมีผลเมื่อไม่มีการตั้งค่า 3D Format)

### การใช้เอฟเฟกต์เงา

ที่นี่ เราตั้งค่าคุณสมบัติที่เกี่ยวข้องกับข้อความเท่านั้น เราใช้เอฟเฟกต์เงากับข้อความโดยใช้โค้ดนี้ใน Python:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides API รองรับเงา 3 ประเภท: OuterShadow, InnerShadow, และ PresetShadow.  
ด้วย PresetShadow คุณสามารถใช้เงากับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า)

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาชนิดเดียว นี่เป็นตัวอย่าง:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow.

**Notes:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะมีเพียงเอฟเฟกต์ OuterShadow เท่านั้นที่ถูกนำไปใช้
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่นำไปใช้จะขึ้นกับรุ่นของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะเพิ่มเป็นสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow

### การใช้ Display กับข้อความ

เราจะเพิ่มการแสดงผลให้กับข้อความโดยใช้ตัวอย่างโค้ดนี้ใน Python:

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### การใช้เอฟเฟกต์ Glow กับข้อความ

เราใช้เอฟเฟกต์ Glow กับข้อความเพื่อทำให้มันส่องแสงหรือเด่นออกมาด้วยโค้ดนี้:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
คุณสามารถเปลี่ยนพารามิเตอร์ของเงา, display, และ glow ได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าบนแต่ละส่วนของข้อความแยกกัน
{{% /alert %}} 

### การใช้การแปลงใน WordArt

เราจะใช้คุณสมบัติ Transform (ที่มีอยู่ในบล็อกข้อความทั้งหมด) ด้วยโค้ดนี้:

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
ทั้ง Microsoft PowerPoint และ Aspose.Slides for Python via .NET มีประเภทการแปลงที่กำหนดไว้ล่วงหน้าจำนวนหนึ่ง
{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดไว้ล่วงหน้า ให้ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ให้ใช้ enum TextShapeType

### การใช้เอฟเฟกต์ 3D กับข้อความและรูปร่าง

เราตั้งค่าเอฟเฟกต์ 3D ให้กับรูปร่างข้อความโดยใช้โค้ดตัวอย่างนี้:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3D ไปใช้กับข้อความด้วยโค้ด Python นี้:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปร่างของมันและการโต้ตอบระหว่างเอฟเฟกต์ต่าง ๆ จะอิงตามกฎบางข้อ  
พิจารณาฉาก (scene) สำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D ประกอบด้วยการแสดงวัตถุ 3D และฉากที่วัตถุถูกวางอยู่  

- เมื่อฉากถูกตั้งค่าสำหรับทั้งรูปและข้อความ ฉากของรูปจะมีลำดับความสำคัญสูงกว่า — ฉากของข้อความจะถูกละเลย
- เมื่อรูปไม่มีฉากของตนเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ
- ในกรณีอื่น — เมื่อรูปร่างเดิมไม่มีเอฟเฟกต์ 3D — รูปร่างจะเป็นแบนและเอฟเฟกต์ 3D จะถูกใช้กับข้อความเท่านั้น  

คำอธิบายนี้เชื่อมโยงกับคุณลักษณะ [ThreeDFormat.LightRig](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/) และ [ThreeDFormat.Camera](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/) 
{{% /alert %}} 

## **ใช้เอฟเฟกต์ Outer Shadow กับข้อความ**
Aspose.Slides for Python via .NET มีคลาส [**IOuterShadow**](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/ioutershadow/) และ [**IInnerShadow**](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/iinnershadow/) ที่ให้คุณสามารถใช้เอฟเฟกต์เงากับข้อความที่อยู่ใน TextFrame ได้ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม AutoShape ประเภท Rectangle ลงในสไลด์.
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape.
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill.
6. สร้างอินสแตนซ์ของคลาส OuterShadow.
7. ตั้งค่า BlurRadius ของเงา.
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา.
10. ตั้งค่า RectanglelAlign เป็น TopLeft.
11. ตั้งค่า PresetColor ของเงาเป็น Black.
12. บันทึกการนำเสนอเป็นไฟล์ PPTX.

โค้ดตัวอย่างนี้ใน Python — การดำเนินการตามขั้นตอนข้างต้น — แสดงวิธีการใช้เอฟเฟกต์ Outer Shadow กับข้อความ:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # รับอ้างอิงของสไลด์
    sld = pres.slides[0]

    # เพิ่ม AutoShape ประเภท Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # เพิ่ม TextFrame ไปยัง Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาของข้อความ
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # เพิ่มเงานอกและตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #บันทึกการนำเสนอลงดิสก์
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เอฟเฟกต์ Inner Shadow กับรูปร่าง**
ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงของสไลด์.
3. เพิ่ม AutoShape ประเภท Rectangle.
4. เปิดใช้งาน InnerShadowEffect.
5. ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด.
6. ตั้งค่า ColorType เป็น Scheme.
7. ตั้งค่าสี Scheme.
8. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .

โค้ดตัวอย่างนี้ (อ้างอิงจากขั้นตอนข้างต้น) แสดงวิธีการเพิ่มคอนเน็กเตอร์ระหว่างสองรูปร่างใน Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # รับอ้างอิงของสไลด์
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ประเภท Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # เพิ่ม TextFrame ไปยัง Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # เปิดใช้งาน inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # ตั้งค่าพารามิเตอร์ทั้งหมดที่จำเป็น
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ตั้งค่า ColorType เป็น Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # ตั้งค่าสี Scheme
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # บันทึกการนำเสนอ
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่างกัน (เช่น อาหรับ, จีน) ได้หรือไม่?**  
ใช่, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติมสี, และเส้นขอบสามารถใช้ได้ไม่ว่าจะเป็นภาษาใด แม้ว่าความพร้อมใช้งานของฟอนต์และการแสดงผลอาจขึ้นอยู่กับฟอนต์ของระบบ  

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบในสไลด์มาสเตอร์ได้หรือไม่?**  
ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปทรงบนสไลด์มาสเตอร์ได้ รวมถึงตัวระบุหัวเรื่อง, การเท้ายังล่าง, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะสะท้อนไปยังสไลด์ที่เชื่อมโยงทั้งหมด  

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์การนำเสนอหรือไม่?**  
เล็กน้อย เอฟเฟกต์ WordArt เช่น เงา, การเรืองแสง, และการเติมสีไล่ระดับสีอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาต้าการจัดรูปแบบที่เพิ่มเข้ามา แต่ส่วนต่างมักจะไม่สำคัญ  

**ฉันสามารถดูตัวอย่างผลของเอฟเฟกต์ WordArt โดยไม่บันทึกการนำเสนอได้หรือไม่?**  
ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `get_image` จากคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) หรือ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ซึ่งช่วยให้คุณดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกการนำเสนอเต็มรูปแบบ