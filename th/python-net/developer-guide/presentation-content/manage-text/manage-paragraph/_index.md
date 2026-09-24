---
title: จัดการย่อหน้าข้อความ PowerPoint ใน Python
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - เพิ่มข้อความ
  - เพิ่มย่อหน้า
  - จัดการข้อความ
  - จัดการย่อหน้า
  - จัดการหัวข้อแบบ bullet
  - ย่อหน้าด้วยการเยื้อง
  - ย่อหน้าแบบ hanging
  - bullet ของย่อหน้า
  - รายการลำดับเลข
  - รายการแบบ bullet
  - คุณสมบัติของย่อหน้า
  - นำเข้า HTML
  - ข้อความเป็น HTML
  - ย่อหน้าเป็น HTML
  - ย่อหน้าเป็นภาพ
  - ข้อความเป็นภาพ
  - ส่งออกย่อหน้า
  - PowerPoint
  - งานนำเสนอ
  - Python
  - Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงข้อความเป็นลำดับขั้นของ text frame, paragraph, และ portion:

* [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) เป็นคอนเทนเนอร์ของข้อความในรูปร่างและให้เข้าถึงคอลเลกชันของ paragraph
* [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) แสดงถึง paragraph หนึ่งใน text frame และให้เข้าถึง portion และการจัดรูปแบบระดับ paragraph
* [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) แสดงถึงส่วนของข้อความภายใน paragraph แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น paragraph สามารถประกอบด้วยข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบ Paragraphs**

### **สร้าง Paragraphs ด้วยหลาย Portion**

ขั้นตอนต่อไปนี้จะสร้าง text frame ที่มีสาม paragraph โดยแต่ละ paragraph มีสาม portion:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape
5. ใช้ paragraph เริ่มต้นและเพิ่ม [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) อีกสองออบเจกต์ลงใน text frame
6. เพิ่ม [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) ให้พอสำหรับแต่ละ paragraph เพื่อให้มีสาม portion (paragraph เริ่มต้นมี portion ว่างหนึ่งออบเจกต์อยู่แล้ว)
7. ตั้งค่าข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/portion_format/)
9. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง Python ด้านล่างทำตามขั้นตอนเหล่านี้:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างรายการแบบ Bulleted และ Numbered**

### **สร้างรายการ Bulleted หรือ Numbered**

Bullets และ numbering ทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/)

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape
5. ลบ paragraph เริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สำหรับ bullet สัญลักษณ์
7. ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.SYMBOL](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/) และระบุอักขระ bullet
8. ตั้งค่าข้อความของ paragraph, ระยะเยื้อง, สี bullet, และความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. สร้าง paragraph ที่สองและตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.NUMBERED](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/)
11. กำหนดสไตล์ bullet แบบเลขและเพิ่ม paragraph ลงใน text frame
12. บันทึก presentation

ตัวอย่าง Python ด้านล่างสร้าง bullet สัญลักษณ์และ bullet แบบเลข:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของมัน
4. ลบ paragraph เริ่มต้นออกจาก text frame
5. โหลดรูปภาพ bullet และเพิ่มลงในคอลเลกชันรูปภาพของ presentation เป็น [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งข้อความของมัน
7. ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.PICTURE](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [BulletFormat.picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/picture/) และตั้งค่าความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง Python ด้านล่างสร้าง picture bullet:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **สร้าง Multilevel List**

ตั้งค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/depth/) เพื่อวาง paragraph ที่ระดับต่าง ๆ ของรายการ ระดับบนสุดมีค่า depth เป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และลบ paragraph เริ่มต้นจาก text frame ของมัน
3. สร้างสี่ paragraph และกำหนดสัญลักษณ์ bullet ของแต่ละอัน
4. ตั้งค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/depth/) ของพวกมันเป็น `0`, `1`, `2`, และ `3`
5. เพิ่ม paragraph ลงใน text frame และบันทึก presentation

ตัวอย่าง Python ด้านล่างสร้างรายการ bulleted สี่ระดับ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **กำหนดค่าเริ่มต้นของ Numbered List Items ให้เป็นค่าที่กำหนดเอง**

ใช้ [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เพื่อกำหนดหมายเลขเริ่มต้นสำหรับ paragraph ที่เป็น numbered

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ลงในสไลด์
2. ลบ paragraph เริ่มต้นจาก text frame ของ shape
3. สร้างสาม paragraph แบบ numbered
4. ตั้งค่า [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เป็น `2`, `3`, และ `7` สำหรับแต่ละ paragraph ตามลำดับ
5. เพิ่ม paragraph ลงใน text frame และบันทึก presentation

ตัวอย่าง Python ด้านล่างกำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละ paragraph:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **ควบคุมการจัดวาง Paragraph และคุณสมบัติ End**

### **ตั้งค่า First-Line Indent**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph ค่าที่กำหนดนี้จะย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของ paragraph ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดตำแหน่งตามเนื้อหา paragraph

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อคุณต้องการย้ายทั้ง paragraph ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลาย paragraph แล้วกำหนดค่าต่าง ๆ ของ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางอย่างไร

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape และลบ paragraph เริ่มต้น
5. สร้างหลาย paragraph และกำหนดค่าต่าง ๆ ของ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ให้มัน
6. เพิ่ม paragraph ลงใน text frame
7. บันทึก presentation ที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของ paragraph:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของ paragraph](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวาง paragraph ที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ตั้งค่า `indent` ให้เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหา paragraph

โดยปฏิบัติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph ส่วน [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้ายนั้น เพื่อสร้าง hanging indent ให้ตั้งค่า `margin_left` เป็นค่าบวกและ `indent` เป็นค่าลบ

รูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, แหล่งอ้างอิง, รายการพจนานุกรม และ paragraph อื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดชิดกับเนื้อหา paragraph แทนที่จะชิดกับอักขระแรกของบรรทัดแรก

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape และลบ paragraph เริ่มต้น
5. สร้าง paragraph และกำหนดค่า [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) ให้เป็นค่าบวกสำหรับแต่ละ paragraph
6. ตั้งค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์ hanging indent
7. เพิ่ม paragraph ลงใน text frame
8. บันทึก presentation ที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า hanging indent สำหรับ paragraph:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเยื้องแบบ hanging ของ paragraph](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

คุณสมบัติ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ควบคุมการจัดรูปแบบของเครื่องหมายจบ paragraph ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบของ paragraph ที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แล้วลบ paragraph เริ่มต้นของมัน
3. สร้าง paragraph สองออบเจกต์และเพิ่ม portion ของข้อความลงในแต่ละออบเจกต์
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของ paragraph ที่สอง
5. ตั้งค่า [PortionFormat.font_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/font_height/) และ [PortionFormat.latin_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/latin_font/)
6. กำหนดฟอร์แมตให้กับ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) แล้วบันทึก presentation

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **นับจำนวนบรรทัดที่เรนเดอร์แล้ว**

ใช้ [Paragraph.get_lines_count](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_lines_count/) เพื่อนับจำนวนบรรทัดที่ paragraph ใช้หลังจากการจัด layout ของข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ นี่เป็นประโยชน์เมื่อตรวจสอบความยาวและการจัด layout ของข้อความในเทมเพลต presentation

paragraph เป็นรายการหนึ่งใน [TextFrame.paragraphs](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/paragraphs/) และอาจใช้หลายบรรทัดที่เรนเดอร์ได้ การใส่ line break แบบชัดเจนภายใน paragraph จะบังคับให้เกิดบรรทัดใหม่โดยไม่สร้าง paragraph ใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่ต้องใส่ line break ลงในข้อความ ดังนั้นการนับจำนวน paragraph หรือตัวอักษร line‑break ไม่ได้ให้จำนวนบรรทัดที่เรนเดอร์จริง

ตัวอย่างต่อไปนี้สร้าง shape ที่เป็นข้อความ, นับบรรทัด, ทำให้ shape แคบลง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า การตัดบรรทัดเปิดใช้งานและ autofit ปิดอยู่เพื่อให้ความกว้างของ shape ควบคุมการตัดบรรทัดโดยไม่ให้ข้อความหดหรือเปลี่ยนขนาดอัตโนมัติ ขนาดของ shape วัดเป็น points สุดท้ายตัวอย่างเพิ่ม paragraph อีกอันและรวมจำนวนบรรทัดจาก text frame ทั้งหมด

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

ด้วยข้อความและขนาดเหล่านี้ การทำให้ shape แคบลงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นลงจะลดจำนวนบรรทัด จำนวนที่ได้อาจแตกต่างกันตามฟอนต์ที่ใช้งานและการทดแทน ฟอนต์, ขนาดฟอนต์, ระยะ margin, การเยื้อง, การตัดบรรทัดและการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่า layout ที่กำหนดสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่บอกว่าข้อความเกินขอบเขตหรือไม่ ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างระหว่าง paragraph และบรรทัด, และพฤติกรรม autofit มีผลเช่นกัน; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหา Paragraph**

### **นำเข้า HTML Text ไปยัง Paragraphs**

ใช้ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/add_from_html/) เพื่อแปลง markup HTML ให้เป็น paragraph และ portion ภายใน text frame

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape แล้วลบ paragraph เริ่มต้น
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ให้กับ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/add_from_html/)
6. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง Python นี้นำเข้า HTML เข้าไปใน text frame:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **ส่งออกข้อความ Paragraph ไปยัง HTML**

ใช้ [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/export_to_html/) เพื่อส่งออกช่วงของ paragraph ที่เลือกเป็น HTML

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลด presentation ที่ต้องการ
2. เข้าถึงสไลด์และหา [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มีข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ shape
4. เรียก [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/export_to_html/) พร้อมดัชนี paragraph เริ่มต้นและจำนวน paragraph ที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง Python นี้ส่งออก paragraph ทั้งหมดจาก shape ที่เป็นข้อความแรก:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **เรนเดอร์ Paragraph เป็นภาพ**

[Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) มีเมธอด `get_image` สำหรับเรนเดอร์ paragraph เดียวโดยตรง เมธอดนี้จะคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ที่คุณสามารถบันทึกเป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/save/) ไม่จำเป็นต้องเรนเดอร์ shape ทั้งหมดหรือครอปบิตแมพด้วยตนเอง

เมธอด `get_image` อาจคืนค่า `None` หากไม่พบ paragraph ในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและใช้ภาพที่คืนค่าด้วย context manager เพื่อปล่อยทรัพยากร

#### **เรนเดอร์ Paragraph ที่สเกลค่าเริ่มต้น**

สมมติว่ามีไฟล์ presentation ชื่อ sample.pptx มีสไลด์หนึ่งสไลด์ที่ shape แรกเป็น text box ที่มีสาม paragraph

![Text box ที่มีสาม paragraph](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ paragraph ที่สองใน shape ข้อความปกติที่สเกลค่าเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

ผลลัพธ์:

![ภาพของ paragraph](paragraph_to_image_output.png)

#### **เรนเดอร์ Paragraph ในเซลล์ตารางพร้อมสเกล**

ส่งค่าปัจจัยสเกลแนวนอนและแนวตั้งให้กับ `get_image` เพื่อควบคุมขนาดของ paragraph ที่เรนเดอร์ ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ paragraph ในเซลล์แรกโดยกว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

ค่าปัจจัยสเกล `1` จะรักษาขนาดพิกเซลเริ่มต้นของแกนนั้นไว้ ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของขนาดเริ่มต้น ส่งผลให้มีพิกเซลมากขึ้นสี่เท่า การใช้ปัจจัยสเกลใหญ่กว่าให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อคงอัตราส่วนของ paragraph; ปัจจัยแนวนอนและแนวตั้งที่แตกต่างกันจะยืดเอาต์พุตแยกกัน

การเรนเดอร์ shape ทั้งหมดด้วย [Shape.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่น ๆ ของ shape สำหรับภาพเฉพาะ paragraph ให้ใช้ `Paragraph.get_image`

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน text frame ได้หรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะดึงขอบเขตบนสไลด์ของ paragraph เฉพาะได้อย่างไร?**

ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_rect/) เพื่อดึงสี่เหลี่ยมขอบของ paragraph. [Portion.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_rect/) ให้ขอบเขตของ portion ทีละอัน

**การจัดแนวของ paragraph (ซ้าย, ขวา, กึ่งกลาง หรือเติมเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับ paragraph และใช้กับทั้ง paragraph ไม่ว่ามีการจัดรูปแบบ portion แยกต่างหากหรือไม่

**ฉันสามารถตั้งค่าภาษาการตรวจสอบสำหรับส่วนหนึ่งของ paragraph ได้หรือไม่?**

ได้. ตั้งค่า [PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) สำหรับ portion แต่ละออบเจกต์ ทำให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้.