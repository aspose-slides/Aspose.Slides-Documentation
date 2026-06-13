---
title: การจัดรูปแบบรูปร่าง PowerPoint ใน Python
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/python-net/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อม
- การเติมไล่สี
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย Python โดยใช้ Aspose.Slides — ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบโดยการแก้ไขหรือใช้เอฟเฟกต์กับโครงร่างของมันได้ นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยกำหนดค่าที่ควบคุมการเติมสีภายในได้

![การจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python มีคลาสและคุณสมบัติที่ช่วยให้คุณจัดรูปแบบรูปร่างด้วยตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [line style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linestyle/) ของรูปร่าง
5. ตั้งค่าความกว้างของเส้น
6. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/python-net/aspose.slides/linedashstyle/) ของรูปร่าง
7. ตั้งค่าสีของเส้นสำหรับรูปร่าง
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python ต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยมผืนผ้า.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยมผืนผ้า.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมผืนผ้า.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในการนำเสนอ](formatted-lines.png)

## **จัดรูปแบบการเชื่อมต่อ**

ต่อไปนี้เป็นตัวเลือกประเภทการเชื่อมต่อสามแบบ:

* รอบ
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้นเมื่อ PowerPoint เชื่อมต่อสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคมอาจต้องการใช้ตัวเลือก **Miter**

![สไตล์การเชื่อมต่อในการนำเสนอ](join-style-powerpoint.png)

โค้ด Python ต่อไปนี้แสดงวิธีสร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่าการเชื่อมต่อ Miter, Bevel, และ Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

	# ดึงสไลด์แรก.
	slide = presentation.slides[0]

	# เพิ่มอัตโนมัติรูปร่างสามรูปร่างแบบสี่เหลี่ยมผืนผ้า.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยมผืนผ้า.
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

	# ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยมผืนผ้า.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# ตั้งค่าสไตล์การเชื่อม.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# เพิ่มข้อความในแต่ละสี่เหลี่ยมผืนผ้า.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# บันทึกไฟล์ PPTX ลงดิสก์.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การผสมสีต่อเนื่องกับรูปร่าง ตัวอย่างเช่นคุณสามารถใช้สองสีหรือมากกว่าโดยให้สีหนึ่งค่อยๆ จางเข้ากับสีอีกสีหนึ่ง

นี่คือวิธีการเติมไล่สีให้กับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของรูปร่างเป็น `GRADIENT`
5. ใช้วิธี `add` ของคอลเลกชัน `gradient_stops` ในคลาส [GradientFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/gradientformat/) เพื่อเพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนด
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การเติมไล่สีกับวงรี:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบวงรี.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # ใช้การจัดรูปแบบไล่สีกับวงรี.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # ตั้งค่าทิศทางของไล่สี.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # เพิ่มจุดหยุดไล่สีสองจุด.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![วงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

## **การเติมลาย**

ใน PowerPoint การเติมลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่นจุด, ลายเส้น, ลายตากกากบาท หรือ ลายสี่เหลี่ยมจัตุรัส—กับรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าและพื้นหลังของลายได้

Aspose.Slides มีลายแบบที่กำหนดไว้ล่วงหน้าเกิน 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อเพิ่มความน่าสนใจให้กับการนำเสนอได้ แม้หลังจากเลือกลายแบบที่กำหนดไว้แล้วคุณก็ยังสามารถระบุสีที่ต้องการให้ใช้ได้

นี่คือวิธีการเติมลายให้กับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของรูปร่างเป็น `PATTERN`
5. เลือกสไตล์ลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
6. ตั้งค่า [back_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/back_color/) ของลาย
7. ตั้งค่า [fore_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/patternformat/fore_color/) ของลาย
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python ต่อไปนี้แสดงวิธีเติมลายให้กับสี่เหลี่ยมผืนผ้า:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ตั้งค่าประเภทการเติมเป็น Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # ตั้งค่าสไตล์ลาย.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![สี่เหลี่ยมผืนผ้าที่มีการเติมลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่าง

นี่คือวิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของรูปร่างเป็น `PICTURE`
5. ตั้งค่าโหมดการเติมรูปภาพเป็น `TILE` (หรือโหมดอื่นตามที่ต้องการ)
6. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) จากรูปภาพที่คุณต้องการใช้
7. กำหนดรูปภาพนี้ให้กับคุณสมบัติ `picture.image` ของ `picture_fill_format` ของรูปร่าง
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมุติว่ามีไฟล์ "lotus.png" ที่มีรูปภาพดังต่อไปนี้:

![รูปดอกบัว](lotus.png)

โค้ด Python ต่อไปนี้แสดงวิธีเติมรูปร่างด้วยรูปภาพ:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # ตั้งค่าประเภทการเติมเป็น Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ตั้งค่าโหมดการเติมรูปภาพ.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # โหลดภาพและเพิ่มเข้าไปในทรัพยากรของการนำเสนอ.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # ตั้งค่ารูปภาพ.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **ใช้รูปภาพเป็นพื้นผิวแบบกระเบื้อง**

หากต้องการตั้งค่ารูปภาพเป็นพื้นผิวแบบกระเบื้องและกำหนดพฤติกรรมการกระเบื้อง คุณสามารถใช้คุณสมบัติต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/picture_fill_mode/) : ตั้งค่าโหมดการเติมรูปภาพ—`TILE` หรือ `STRETCH`
- [tile_alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_alignment/) : ระบุตำแหน่งการจัดแนวของกระเบื้องภายในรูปร่าง
- [tile_flip](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_flip/) : ควบคุมว่ากระเบื้องจะถูกพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [tile_offset_x](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_offset_x/) : ตั้งค่าการเลื่อนแนวนอนของกระเบื้อง (หน่วยจุด) จากตำแหน่งต้นของรูปร่าง
- [tile_offset_y](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_offset_y/) : ตั้งค่าการเลื่อนแนวตั้งของกระเบื้อง (หน่วยจุด) จากตำแหน่งต้นของรูปร่าง
- [tile_scale_x](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_scale_x/) : กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [tile_scale_y](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/tile_scale_y/) : กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปร่างสี่เหลี่ยมที่มีการเติมรูปภาพแบบกระเบื้องและกำหนดตัวเลือกการกระเบื้อง:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    first_slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างสี่เหลี่ยมผืนผ้า.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # ตั้งค่าประเภทการเติมของรูปร่างเป็น Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # โหลดภาพและเพิ่มเข้าไปในทรัพยากรของการนำเสนอ.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # กำหนดภาพให้กับรูปร่าง.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ตัวเลือกการกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวอย่างสม่ำเสมอลงในรูปร่าง สีพื้นหลังเรียบนี้จะถูกนำมาใช้โดยไม่มีการไล่สี พื้นผิว หรือ ลายใดๆ

เพื่อเติมสีทึบให้กับรูปร่างโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของรูปร่างเป็น `SOLID`
5. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python ต่อไปนี้แสดงวิธีเติมสีทึบให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ตั้งค่าประเภทการเติมเป็น Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # ตั้งค่าสีเติม.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่สี, รูปภาพ หรือพื้นผิวลงในรูปร่าง คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม สีที่โปร่งใสมากขึ้นทำให้รูปร่างดูโปร่งใสกว่า ทำให้พื้นหลังหรือวัตถุด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ในสีที่ใช้สำหรับการเติม วิธีทำตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า FillType เป็น `SOLID`
5. ใช้ `Color.from_argb` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมระดับความโปร่งใส)
6. บันทึกการนำเสนอ

โค้ด Python ต่อไปนี้แสดงวิธีเติมสีโปร่งใสให้กับสี่เหลี่ยม:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]
    
    # เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้าแบบทึบ.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้าแบบโปร่งใสเหนือรูปร่างทึบ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides สามารถหมุนรูปร่างในงานนำเสนอ PowerPointได้ ซึ่งเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการออกแบบเฉพาะ

เพื่อหมุนรูปร่างบนสไลด์ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า properties `rotation` ของรูปร่างเป็นมุมที่ต้องการ
5. บันทึกการนำเสนอ

โค้ด Python ต่อไปนี้แสดงวิธีหมุนรูปร่างโดย 5 องศา:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มอัตโนมัติรูปร่างแบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # หมุนรูปร่างโดย 5 องศา.
    shape.rotation = 5

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์บีเวล 3 มิติบนรูปร่างโดยกำหนดค่าคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวล 3 มิติบนรูปร่างทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/) ของรูปร่างเพื่อระบุการตั้งค่าบีเวล
5. บันทึกการนำเสนอ

โค้ด Python ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์บีเวล 3 มิติบนรูปร่าง:

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

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่างโดยกำหนดค่าคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติบนรูปร่างทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
4. ตั้งค่า [camera_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/camera/camera_type/) และ [light_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/lightrig/light_type/) เพื่อกำหนดการหมุน 3 มิติ
5. บันทึกการนำเสนอ

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

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Python ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง ขนาด และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) ให้กลับเป็นค่าตั้งต้น:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # รีเซ็ตรูปทรงแต่ละอันในสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

มีผลเพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่เป็นส่วนใหญ่ของไฟล์ ขณะที่พารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์, และไล่สีถูกเก็บเป็นเมทาดาต้าและเพิ่มขนาดไฟล์เกือบไม่มี

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจะจัดกลุ่มได้อย่างไร?**

ให้เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—เช่นการเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกันถือว่าสไตล์เหมือนกันและสามารถจัดกลุ่มรูปร่างเหล่านั้นได้ ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองลงไฟล์แยกต่างหากเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ ควรเก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์ .POTX เทมเพลต เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลตนั้น คัดลอกรูปร่างที่ต้องการ และนำการจัดรูปแบบที่บันทึกไว้ไปใช้ใหม่ตามต้องการ