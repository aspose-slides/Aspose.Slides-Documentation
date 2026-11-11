---
title: จัดการย่อหน้าข้อความ PowerPoint ด้วย Python
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
- จัดการจุดหัวข้อ
- การเยื้องย่อหน้า
- การเยื้องห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
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
description: "เรียนรู้วิธีการสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, จุดหัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วนข้อความ:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) เป็นตัวเก็บข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) แทนย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนข้อความและการจัดรูปแบบระดับย่อหน้า.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) แทนการไหลของข้อความภายในย่อหน้า. แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตัวเองได้.

ดังนั้นย่อหน้าจึงสามารถมีข้อความที่ใช้ฟอนต์, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วนข้อความได้.

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปร่างและใช้ส่วนข้อความเพื่อจัดรูปแบบการไหลของข้อความแต่ละส่วน. ส่วนนี้แสดงวิธีการรวมหลายส่วนข้อความในแต่ละย่อหน้าและใช้สี, ขนาดฟอนต์, และสไตล์ที่แตกต่างกัน.

### **สร้างย่อหน้าที่มีหลายส่วนข้อความ**

ตัวอย่าง Python ด้านล่างจะสร้างย่อหน้า 3 ย่อหน้า, แต่ละย่อหน้ามีส่วนข้อความ 3 ส่วนในคอลเลกชัน [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). ตัวอย่างจะใช้ย่อหน้าเริ่มต้นและส่วนข้อความว่าง, แล้วเพิ่มย่อหน้าและส่วนข้อความที่เหลือ. การจัดรูปแบบทำผ่าน [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): ส่วนแรกของแต่ละย่อหน้าเป็นสีแดง, หนา, ขนาด 15 จุด; ส่วนที่สองเป็นสีน้ำเงิน, เอนเอียง, ขนาด 18 จุด. ส่วนที่สามจะรักษาการจัดรูปแบบเริ่มต้นไว้:

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

## **สร้างรายการแบบมี bullet และหมายเลข**

จัดข้อความย่อหน้าเป็นรายการด้วยสัญลักษณ์, ตัวเลข, หรือรูปภาพที่กำหนดเอง. ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบ bullet, รายการหลายระดับ, และหมายเลขเริ่มต้นแบบกำหนดเอง.

### **สร้างรายการแบบ Bullet หรือ Numbered**

Bullet และการตั้งหมายเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น. ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยผ่าน [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

ตัวอย่าง Python นี้เพิ่ม bullet แบบสัญลักษณ์และรายการที่มีหมายเลขในกรอบข้อความเดียวกัน. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เลือกประเภทของ bullet, ส่วน [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) ระบุสัญลักษณ์และ [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) เลือกสไตล์การตั้งหมายเลข. รายการทั้งสองใช้ bullet สีดำ ความสูง 100 เปอร์เซ็นต์และการเยื้องย่อหน้า 25 จุด:

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

Picture bullets ทำให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข.

ตัวอย่างต้องการไฟล์ `bullets.png` อยู่ในไดเรกทอรีทำงาน. ตัวอย่าง Python นี้เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) และใช้เป็น bullet ของย่อหน้า. มันตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) ให้ใช้ picture bullet และกำหนดรูปภาพผ่าน [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) ตั้งเป็น 100 เปอร์เซ็นต์เพื่อกำหนดขนาด bullet ให้สัมพันธ์กับข้อความย่อหน้า:

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

### **สร้างรายการหลายระดับ**

ตั้งค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ. ระดับบนสุดมีความลึก `0`.

ตัวอย่าง Python นี้กำหนดค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) ตั้งแต่ 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า, สร้างลำดับชั้นภายในกรอบข้อความเดียว. แต่ละย่อหน้าใช้ bullet แบบสัญลักษณ์, โดย [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) สลับระหว่าง bullet กลมและ hyphen เพื่อแยกระดับที่ติดกัน:

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

### **ตั้งค่าเริ่มต้นของรายการที่มีหมายเลขตามค่ากำหนดเอง**

ใช้ [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าที่มีหมายเลข.

ตัวอย่าง Python นี้ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) ให้ใช้การตั้งหมายเลขสำหรับย่อหน้า 3 ย่อหน้าและกำหนดค่า [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เป็น 2, 3, และ 7. ค่าการเริ่มต้นถูกตั้งแยกตามแต่ละย่อหน้า, ทำให้หมายเลขที่แสดงข้ามค่าได้:

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

## **ควบคุมการจัดวางและคุณสมบัติ End ของย่อหน้า**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่พับ. คุณยังสามารถจัดรูปแบบสัญลักษณ์ End ของย่อหน้าแยกต่างหากจากส่วนข้อความที่มองเห็นได้.

### **ตั้งค่า Indent ของบรรทัดแรก**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมการเยื้องของบรรทัดแรกของย่อหน้า. คุณสมบัตินี้ย้ายเฉพาะบรรทัดแรกโดยสัมพันธ์กับระยะขอบซ้ายของย่อหน้า. ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา, ส่วนบรรทัดที่เหลือคงตำแหน่งตามเนื้อหาย่อหน้า.

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด. ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) เท่ากับ 20 จุดและค่าของ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เป็น 0, 20, และ 40 จุด. บรรทัดแรกเริ่มที่ระยะที่เพิ่มขึ้นอย่างต่อเนื่อง, ขณะที่บรรทัดที่พับยังคงระยะซ้ายเดียวกัน:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ. ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). ตั้งค่า `indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า.

โดยปกติ, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, และ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับระยะนั้น. เพื่อสร้าง hanging indent, ตั้งค่า `margin_left` เป็นบวกและ `indent` เป็นลบ.

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม, และย่อหน้าอื่น ๆ ที่บรรทัดที่พับต้องเรียงชิดกับเนื้อหาย่อหน้าแทนที่จะชิดกับอักขระแรกของบรรทัดแรก.

ตัวอย่าง Python ด้านล่างจับคู่ค่า [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) ที่เป็น 40 และ 60 จุดกับค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ที่เป็น -20 และ -30 จุด. ในแต่ละย่อหน้า, บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่พับ; ย่อหน้าที่สองมี hanging indent ที่ลึกกว่า:

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

![การเยื้องแบบ hanging ของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติ End ของย่อหน้า**

คุณสมบัติ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ควบคุมการจัดรูปแบบของสัญลักษณ์ End ย่อหน้า. ตัวอย่างนี้โหลด `Test.pptx` ซึ่งต้องมีสไลด์อย่างน้อยหนึ่งสไลด์, แล้วสร้าง [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) โดยตั้งค่า [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) เป็น 48 จุดและ [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) เป็น Times New Roman. จากนั้นกำหนดรูปแบบนี้ให้กับสัญลักษณ์ End ของย่อหน้าที่สอง, ทำให้ส่วนข้อความที่มองเห็นไม่เปลี่ยนแปลง:

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

## **นับจำนวนบรรทัดที่เรนเดอร์**

สำหรับกฎของย่อหน้าที่มีผลต่อการพับอัตโนมัติและเครื่องหมายวรรคตอนที่ท้ายบรรทัด, ดู [Control Line Breaking](/slides/th/python-net/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/python-net/text-formatting/#control-hanging-punctuation).

ใช้ [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) เพื่อเก็บจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดวางข้อความ, รวมถึงการพับอัตโนมัติ. ฟังก์ชันนี้มีประโยชน์เมื่อคุณต้องตรวจสอบความยาวและการจัดวางข้อความในแม่แบบงานนำเสนอ.

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์. การใส่การขึ้นบรรทัดใหม่ภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่. การพับอัตโนมัติเสมียนบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรก character ขึ้นบรรทัดใหม่ลงในข้อความ. ดังนั้นการนับย่อหน้าหรืออักขระขึ้นบรรทัดใหม่จึงไม่ได้ให้จำนวนบรรทัดที่เรนเดอร์จริง.

ตัวอย่างต่อไปนี้สร้างรูปร่างข้อความ, นับบรรทัด, ลดความกว้างของรูปร่าง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า. ตัวอย่างเปิดใช้ [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) และปิด [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) เพื่อให้ความกว้างของรูปร่างควบคุมการพับโดยไม่ให้ข้อความหดหรือลดขนาดรูปร่างโดยอัตโนมัติ. การวัดแต่ละครั้งใช้ [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). มิติของรูปร่างเป็นหน่วยจุด. สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดของกรอบข้อความ:

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

ด้วยข้อความและมิติเหล่านี้, การทำให้รูปร่างแคบลงจะเพิ่มจำนวนบรรทัด, ส่วนการเปลี่ยนข้อความเป็นสตริงสั้นจะลดจำนวนบรรทัด. จำนวนที่ได้อาจแตกต่างตามฟอนต์ที่มี, การแทนที่ฟอนต์, ขนาดฟอนต์, ระยะขอบ, ระยะเยื้อง, การพับ, และการตั้งค่า autofit. ควรใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทดสอบแม่แบบ.

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่. ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างของย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็มีผลเช่นกัน; แม้บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อปิดการพับ.

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่การนำเสนอหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอก. ส่วนนี้ยังแสดงวิธีการเรนเดอร์ย่อหน้าแต่ละย่อมาเป็นภาพ, รวมถึงย่อหน้าในเซลล์ตาราง.

### **นำเข้า HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) เพื่อแปลงเครื่องหมาย HTML ให้เป็นย่อหน้าและส่วนข้อความในกรอบข้อความ.

ตัวอย่าง Python นี้อ่าน HTML จาก `file.html` ที่อยู่ในไดเรกทอรีทำงานและส่ง markup ให้กับ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). มันลบย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบข้อความมีเฉพาะเนื้อหาที่นำเข้า. รูปร่างสี่เหลี่ยมจะเว้นระยะขอบ 10 จุดแต่ละด้านของสไลด์:

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

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML. เมื่อใช้ข้อความจากงานนำเสนอบนเว็บ, คุณอาจต้องการเก็บการเน้นเฉพาะโดยไม่ต้องนำฟอนต์, ขนาด, หรือสไตล์กล่องข้อความของงานนำเสนอไปด้วย. ตั้งค่า [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) เพื่อควบคุมความลึกที่ตัวส่งออกจะตามการสืบทอดการจัดรูปแบบ.

ดาวน์โหลด [งานนำเสนอตัวอย่าง](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน. สไลด์แรกของมันมีรูปร่างข้อความหนึ่งรูปที่มีข้อความ “Inherited text; explicit red 18pt”. อินพุตตั้งใจใช้หลายระดับการจัดรูปแบบ:

- สไตล์ข้อความเริ่มต้นของงานนำเสนอใช้ฟอนต์ Calibri ขนาด 28 pt.
- สไตล์ข้อความระดับแรกของกรอบข้อความใช้สีฟ้าและตัวเอียง.
- ย่อหน้าตั้งค่าข้อความหนาโดยเฉพาะ.
- ส่วนที่สอง, “explicit red 18pt”, ตั้งค่าสีแดงและขนาด 18 pt โดยเฉพาะ.

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าที่เดียวกันสามครั้ง. มันส่งอ็อบเจ็กต์ [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและเขียนผลลัพธ์แต่ละอันเป็นไฟล์ HTML UTF‑8 แยกไฟล์:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

HTML ที่สร้างมี CSS ต่อไปนี้สำหรับส่วนแรก, “Inherited text; ”. ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความกระจ่าง.

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, เอนเอียง ขนาด 28 pt ใน Calibri, หากฟอนต์นั้นมีอยู่ |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, เอนเอียง; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์, ขนาด, สี, และสไตล์เอนเอียง |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทั้งสามผลลัพธ์. ส่วนนี้ยังคงเป็นตัวเอียงใน `ALL` และ `TEXT_BOX`, แต่ไม่ใช่ใน `PARAGRAPH_ONLY`. การจำกัดการสืบทอดจึงไม่ลบการจัดรูปแบบที่กำหนดโดยตรงให้กับย่อหน้าหรือส่วนข้อความ.

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ. ในสองโหมดที่จำกัด, คุณสมบัติ CSS ที่ละเว้นจะถูกแก้โดยสไตล์ของหน้าเป้าหมายหรือค่าเริ่มต้นของเบราว์เซอร์, ดังนั้นลักษณะที่แสดงผลจะแตกต่างตามที่ HTML ถูกใช้.

### **สร้างส่วน HTML Clipboard Fragment**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) คืนสตริง HTML. ตั้งค่า [TextToHtmlConversionOptions.add_clipboard_fragment_header](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/add_clipboard_fragment_header/) เป็น `False` เพื่อรับ HTML ปกติหรือ `True` เพื่อรวมส่วนหัวของคลิปบอร์ด Windows. ส่วนหัวให้ข้อมูลออฟเซ็ตไบต์ UTF‑8 ของ HTML รอบ ๆ (`StartHTML` และ `EndHTML`) และส่วนของข้อความที่ต้องวาง (`StartFragment` และ `EndFragment`).

ตัวอย่างนี้ส่งออกย่อหน้าที่จัดรูปแบบสองย่อหน้าเป็น HTML ปกติ (`html`) และเป็น HTML Clipboard Fragment (`clipboard_html`). การเขียนส่วนนี้ไปยังคลิปบอร์ดของระบบเป็นขั้นตอนแอปพลิเคชันแยกต่างหาก. หาก API ของคลิปบอร์ดคาดหวังไบต์ดิบ, ใหเข้ารหัสส่วนนี้เป็น UTF‑8 โดยไม่มี BOM.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 400, 100)
    paragraphs = shape.text_frame.paragraphs
    paragraphs.clear()
    paragraphs.add_from_html("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>")

    options = slides.export.TextToHtmlConversionOptions()
    options.add_clipboard_fragment_header = False
    html = paragraphs.export_to_html(0, paragraphs.count, options)

    options.add_clipboard_fragment_header = True
    clipboard_html = paragraphs.export_to_html(0, paragraphs.count, options)
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). สามารถบันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). คุณไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือครอบตัดบิตแมพด้วยตนเอง.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) อาจคืนค่า `None` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้. ตรวจสอบผลลัพธ์ก่อนบันทึกและลบอ็อบเจ็กต์ภาพที่คืนค่าหลังการใช้งาน.

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

ตัวอย่างใช้ `sample.pptx`, งานนำเสนอที่มีสไลด์หนึ่งสไลด์ที่รูปร่างแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปเลือกย่อหน้าที่สองที่ตำแหน่งดัชนี 1 และเรียก [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) โดยไม่มีพารามิเตอร์สเกล. มันตรวจสอบว่ารูปร่างมีย่อหน้าที่ต้องการและว่าการเรนเดอร์ตอบสนองด้วยภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) เพื่อบันทึกเป็นรูป PNG. ตัวจัดการบริบทจะปล่อยทรัพยากรภาพหลังการใช้งาน.

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

![ภาพของย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อกำหนดปัจจัยสเกลแนวนอนและแนวตั้ง. ตัวอย่างต่อไปสร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG.

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

ค่าปัจจัยสเกล `1` รักษาขนาดพิกเซลเริ่มต้นของแกนนั้น. ตัวอย่างเช่น `2` สำหรับทั้งสองค่า จะสร้างภาพที่ความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น, ส่งผลให้มีพิกเซลมากกว่าตัวเดิมสี่เท่า. ปัจจัยที่ใหญ่กว่าจะให้ข้อความคมชัดขึ้นสำหรับการซูมหรือการส่งออกความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์. ปัจจัยที่น้อยกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง. ควรใช้ปัจจัยเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่แตกต่างกันจะทำให้ภาพยืดออกตามแต่ละแกน.

การเรนเดอร์รูปร่างทั้งหมดด้วย [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของรูปร่าง. สำหรับภาพที่มีเพียงย่อหน้า, ให้ใช้ [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการพับบรรทัดภายในกรอบข้อความได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) ให้ปิดการพับเพื่อให้บรรทัดไม่ตัดที่ขอบกรอบข้อความ.

**ฉันจะดึงขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) เพื่อรับสี่เหลี่ยมขอบของย่อหน้า. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) ให้ขอบของส่วนข้อความแต่ละส่วน.

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง, หรือเต็ม) ถูกควบคุมที่ใด?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนข้อความแต่ละส่วน.

เพื่อจัดแนวส่วนข้อความที่มีขนาดฟอนต์ต่างกันในแต่ละบรรทัด, ดู [Align Fonts Within a Line](/slides/th/python-net/text-formatting/#align-fonts-within-a-line).

**ฉันสามารถตั้งค่าภาษา proofing ให้กับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) สำหรับส่วนข้อความแต่ละส่วน, ทำให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้.