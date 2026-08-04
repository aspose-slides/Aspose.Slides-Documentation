---
title: ฟอร์แมตรูปร่าง PowerPoint ใน Python
linktitle: การฟอร์แมตรูปร่าง
type: docs
weight: 20
url: /th/python-net/shape-formatting/
keywords:
- ฟอร์แมตรูปร่าง
- ฟอร์แมตเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- ฟอร์แมตสไตล์การเชื่อมต่อ
- การเติมไล่ระดับสี
- การเติมลาย
- การเติมรูปภาพ
- การเติมเทกเจอร์
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีฟอร์แมตรูปร่าง PowerPoint ด้วย Python โดยใช้ Aspose.Slides—ตั้งค่าการเติม, เส้นและสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP อย่างแม่นยำและควบคุมเต็มรูปแบบ"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบรูปร่างโดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปร่าง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python ให้คลาสและคุณสมบัติต่าง ๆ ที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกันกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[สไตล์เส้น](https://reference.aspose.com/slides/th/python-net/aspose.slides/linestyle/)ของรูปร่าง  
1. ตั้งค่าความกว้างของเส้น  
1. ตั้งค่า[dash style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linedashstyle/)ของรูปร่าง  
1. ตั้งค่าสีเส้นสำหรับรูปร่าง  
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีจัดรูปแบบ[AutoShape]สี่เหลี่ยมผืนผ้า:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # ตั้งค่าสีเติมให้กับรูปร่างสี่เหลี่ยม.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # ตั้งค่าสีให้กับเส้นของสี่เหลี่ยม.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์ Sketch กับเส้นของรูปร่าง**

เอฟเฟกต์ sketch ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้[Shape.line_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/line_format/)เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.sketch_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/lineformat/sketch_format/)เพื่อเข้าถึงการตั้งค่า sketch, และ[SketchFormat.sketch_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/sketchformat/sketch_type/)เพื่อเลือกค่าจากการ列舉[LineSketchType](https://reference.aspose.com/slides/th/python-net/aspose.slides/linesketchtype/)

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์[LineSketchType.CURVED](https://reference.aspose.com/slides/th/python-net/aspose.slides/linesketchtype/)อ่านค่าที่กำหนดอย่างชัดเจน และลบเอฟเฟกต์ด้วย[LineSketchType.NONE](https://reference.aspose.com/slides/th/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # เข้าถึงรูปแบบเส้นของรูปร่างและรูปแบบสเก็ตช์ของมัน.
    sketch_format = shape.line_format.sketch_format

    # ใช้เอฟเฟกต์สเก็ตช์.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปร่าง.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # ลบเอฟเฟกต์สเก็ตช์.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

ค่าที่ `SketchFormat.sketch_type` คืนมาจะเป็นการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้[LineFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/lineformat/get_effective/)เพื่อเข้าถึงคุณสมบัติ`sketch_format`ของอ็อบเจ็กต์ที่คืนค่าและอ่านค่า`sketch_type`ของมัน ค่าที่มีประสิทธิภาพจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกสไตล์การเชื่อมต่อ:

* กลม
* มิตเตอร์
* เบเวล

โดยค่าเริ่มต้น PowerPoint จะใช้สไตล์ **กลม** เมื่อเชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคม คุณอาจต้องการใช้ตัวเลือก **มิตเตอร์**  

![The join style in the presentation](join-style-powerpoint.png)

โค้ด Python ต่อไปนี้แสดงวิธีที่สามสี่เหลี่ยม (ตามรูปด้านบน) ถูกสร้างโดยใช้การตั้งค่าสไตล์การเชื่อมต่อ Miter, Bevel, และ Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

	# ดึงสไลด์แรก.
	slide = presentation.slides[0]

	# เพิ่มรูปร่างอัตโนมัติสามรูปประเภทสี่เหลี่ยมผืนผ้า.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยมแต่ละรูป.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# ตั้งค่าความกว้างของเส้น.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละรูป.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# ตั้งค่าสไตล์การเชื่อมต่อ.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# เพิ่มข้อความให้แต่ละสี่เหลี่ยม.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# บันทึกไฟล์ PPTX ลงในดิสก์.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **เติมสีไล่ระดับ (Gradient Fill)**

ใน PowerPoint, Gradient Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมสีต่อเนื่องลงบนรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยให้สีหนึ่งค่อย ๆ จางลงสู่สีถัดไป

วิธีการใช้ Gradient Fill กับรูปร่างด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/)ของรูปร่างเป็น`GRADIENT`  
1. ใช้วิธี`add`ของคอลเลกชัน`gradient_stops`ในคลาส[GradientFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/gradientformat/)เพื่อเพิ่มสีและตำแหน่งที่คุณต้องการสองสี  
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ Gradient Fill กับวงรี:

```python
import aspose.slides as slides

# สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภท Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # ใช้การจัดรูปแบบไล่ระดับสีกับวงรี.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # ตั้งค่าทิศทางของไล่ระดับสี.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # เพิ่มจุดหยุดไล่ระดับสีสองจุด.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

## **เติมลาย(pattern) Fill**

ใน PowerPoint, Pattern Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมลายสองสี—เช่น จุด, แถบ, กากบาท, หรือเช็กบอร์ด—ลงบนรูปร่าง คุณสามารถเลือกสีพื้นหน้าและพื้นหลังของลายได้ตามต้องการ

Aspose.Slides มีลายพรีเซ็ตมากกว่า 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อเพิ่มความสวยงามให้กับการนำเสนอ แม้จะเลือกลายพรีเซ็ตแล้ว คุณยังสามารถกำหนดสีที่ใช้ได้อย่างแม่นยำ

วิธีการใช้ Pattern Fill กับรูปร่างด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/)ของรูปร่างเป็น`PATTERN`  
1. เลือกสไตล์ลายจากตัวเลือกพรีเซ็ต  
1. ตั้งค่า[back_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/back_color/)ของลาย  
1. ตั้งค่า[fore_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/fore_color/)ของลาย  
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้ Pattern Fill กับสี่เหลี่ยม:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ตั้งค่า Fill Type เป็น Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # ตั้งค่าสไตล์ของแพทเทิร์น.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # ตั้งค่าสีพื้นหลังและสีพื้นหน้าของแพทเทิร์น.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

ใน PowerPoint, Picture Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่าง

วิธีใช้ Aspose.Slides เพื่อทำ Picture Fill กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/)ของรูปร่างเป็น`PICTURE`  
1. ตั้งค่าโหมด picture fill เป็น`TILE` (หรือโหมดที่ต้องการอื่น)  
1. สร้างอ็อบเจกต์[PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/)จากรูปภาพที่ต้องการใช้  
1. มอบหมายรูปภาพนี้ให้กับคุณสมบัติ`picture.image`ของ`picture_fill_format`ของรูปร่าง  
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

สมมติว่ามีไฟล์ "lotus.png" ที่มีรูปภาพดังต่อไปนี้:

![The lotus picture](lotus.png)

โค้ด Python ต่อไปนี้แสดงวิธีเติมรูปภาพลงบนรูปร่าง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # ตั้งค่า Fill Type เป็น Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ตั้งค่าโหมดการเติมรูปภาพ.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # โหลดภาพและเพิ่มลงในรีซอร์สของงานนำเสนอ.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # ตั้งค่ารูปภาพ.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งค่ารูปภาพแบบต่อกระเบื้องเป็นเท็กซ์เจอร์และปรับพฤติกรรมการต่อกระเบื้อง สามารถใช้คุณสมบัติต่อไปนี้ของคลาส[PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/picture_fill_mode/): กำหนดโหมดการเติมรูปภาพ—`TILE` หรือ `STRETCH`  
- [tile_alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_alignment/): ระบุตำแหน่งการจัดเรียงของกระเบื้องภายในรูปร่าง  
- [tile_flip](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_flip/): ควบคุมการพลิกรูปกระเบื้องในแนวนอน, แนวตั้ง หรือทั้งสองอย่าง  
- [tile_offset_x](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_offset_x/): ตั้งค่าออฟเซ็ตแนวนอนของกระเบื้อง (หน่วย points) จากตำแหน่งต้นของรูปร่าง  
- [tile_offset_y](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_offset_y/): ตั้งค่าออฟเซ็ตแนวตั้งของกระเบื้อง (หน่วย points) จากตำแหน่งต้นของรูปร่าง  
- [tile_scale_x](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_scale_x/): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [tile_scale_y](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_scale_y/): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปร่างสี่เหลี่ยมพร้อม picture fill แบบต่อกระเบื้องและกำหนดตัวเลือกการต่อกระเบื้อง:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    first_slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้า.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # ตั้งค่า Fill Type ของรูปร่างเป็น Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # โหลดภาพและเพิ่มลงในรีซอร์สของงานนำเสนอ.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # กำหนดภาพให้กับรูปร่าง.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อกระเบื้อง.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The tile options](tile-options.png)

## **Solid Color Fill**

ใน PowerPoint, Solid Color Fill เป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวลงบนรูปร่าง โดยไม่มีการไล่ระดับ, เท็กซ์เจอร์ หรือ ลายใด ๆ

เพื่อใช้ Solid Color Fill กับรูปร่างด้วย Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/)ของรูปร่างเป็น`SOLID`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง  
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python ต่อไปนี้แสดงวิธีใช้ Solid Color Fill กับสี่เหลี่ยมในสไลด์ PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ตั้งค่า Fill Type เป็น Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # ตั้งค่าสีเติม.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส (Set Transparency)**

ใน PowerPoint เมื่อคุณใช้สีเดียว, Gradient, Picture หรือ Texture Fill กับรูปร่าง คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม สีที่มีค่าความโปร่งใสสูงจะทำให้รูปร่างดูโปร่งแสงมากขึ้นและให้พื้นหลังหรืออ็อบเจกต์ที่อยู่ใต้เห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ของสีที่ใช้สำหรับการเติม วิธีทำมีดังนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า fill type เป็น`SOLID`  
1. ใช้`Color.from_argb`เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)  
1. บันทึกการนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้สีเติมแบบโปร่งใสกับสี่เหลี่ยม:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]
    
    # เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าแบบอัตโนมัติสีทึบ.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าแบบอัตโนมัติโปร่งแสงเหนือรูปร่างสีทึบ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปร่าง (Rotate Shapes)**

Aspose.Slides ให้คุณหมุนรูปร่างใน PowerPoint ได้ ซึ่งเป็นประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามการจัดเรียงหรือการออกแบบที่ต้องการ

วิธีหมุนรูปร่างบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่าคุณสมบัติ`rotation`ของรูปร่างเป็นมุมที่ต้องการ  
1. บันทึกการนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีหมุนรูปร่าง 5 องศา:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # หมุนรูปร่าง 5 องศา.
    shape.rotation = 5

    # บันทึกไฟล์ PPTX ลงในดิสก์.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์ bevel 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติของ[ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

วิธีเพิ่มเอฟเฟกต์ bevel 3 มิติให้กับรูปร่าง:

1. สร้างอ็อบเจ็กต์[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. กำหนดค่า[ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)ของรูปร่างเพื่อระบุการตั้งค่า bevel  
1. บันทึกการนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ bevel 3 มิติบนรูปร่าง:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # เพิ่มรูปร่างลงในสไลด์.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติของ[ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

วิธีใช้การหมุน 3 มิติบนรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ตามดัชนีของมัน  
1. เพิ่ม[AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)ลงในสไลด์  
1. ตั้งค่า[camera_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/camera/camera_type/)และ[light_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/lightrig/light_type/)ของรูปร่างเพื่อกำหนดการหมุน 3 มิติ  
1. บันทึกการนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่าง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

โค้ด Python ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน[LayoutSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/)กลับสู่ค่าเริ่มต้น:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์นำเสนอสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างเล็ก ภาพและสื่อที่ฝังอยู่เป็นส่วนใหญ่ของขนาดไฟล์ ส่วนพารามิเตอร์ของรูปร่างเช่น สี, เอฟเฟกต์, และไล่สีจะถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์เพียงน้อยนิด

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติกำหนดการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทุกอย่างตรงกัน ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปร่างเหล่านั้นแบบเชิงตรรกะ ซึ่งช่วยให้ง่ายต่อการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองลงไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปร่างตัวอย่างพร้อมสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์ .POTX เทมเพลต เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่ต้องการและนำการจัดรูปแบบของมันไปใช้ใหม่ตามต้องการ