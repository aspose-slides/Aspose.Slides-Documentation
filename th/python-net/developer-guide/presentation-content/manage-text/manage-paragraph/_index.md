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
- จัดการหัวข้อ
- การเยื้องย่อหน้า
- การเยื้อนห่วงจับ
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัตีย่อหน้า
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, จุดหัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วนย่อย:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) เป็นคอนเทนเนอร์ข้อความในรูปร่างและให้เข้าถึงคอลเลกชันย่อหน้าของมัน
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้เข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) เป็นส่วนของข้อความภายในย่อหน้า แต่ละส่วนอาจมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้น ย่อหน้าจึงสามารถรวมข้อความที่มีฟอนท์ สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าภายในกรอบข้อความของรูปร่างและใช้ส่วนย่อยเพื่อจัดรูปแบบแต่ละรันของข้อความ ส่วนนี้แสดงวิธีรวมหลายส่วนย่อยภายในแต่ละย่อหน้าและใช้สี ขนาดฟอนท์ และสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ตัวอย่าง Python ด้านล่างสร้างย่อหน้า 3 ย่อหน้า โดยแต่ละย่อหน้ามีรันข้อความ 3 รันในคอลเลกชัน [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) ของมัน ตัวอย่างใช้ย่อหน้าเริ่มต้นและส่วนย่อยเปล่าที่มีอยู่แล้ว แล้วเพิ่มย่อหน้าและส่วนย่อยที่เหลือ การจัดรูปแบบทำผ่าน [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) : ส่วนแรกในแต่ละย่อหน้าเป็นสีแดง หนา และขนาด 15 จุด; ส่วนที่สองเป็นสีน้ำเงิน ตัวเอียง และขนาด 18 จุด; ส่วนที่สามคงการจัดรูปแบบเริ่มต้นไว้:

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

## **สร้างรายการแบบหัวข้อและลำดับเลข**

จัดข้อความย่อหน้าเป็นรายการโดยใช้สัญลักษณ์ ตัวเลข หรือรูปภาพที่กำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบหัวข้อ รายการหลายระดับ และการกำหนดเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการแบบหัวข้อหรือเลขลำดับ**

หัวข้อและการนับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 

ตัวอย่าง Python นี้เพิ่มหัวข้อสัญลักษณ์และรายการเลขในกรอบข้อความเดียวกัน [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เลือกประเภทหัวข้อ, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) กำหนดสัญลักษณ์, และ [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) เลือกสไตล์การนับเลข ทั้งสองรายการใช้หัวข้อสีดำ ความสูง 100% และการเยื้องย่อหน้า 25 จุด:

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

### **ใช้หัวข้อรูปภาพ**

หัวข้อรูปภาพให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือเลข

ตัวอย่างต้องมีไฟล์ `bullets.png` อยู่ในไดเรกทอรีทำงาน ตัวอย่าง Python นี้เพิ่มรูปภาพไปยังคอลเลกชันรูปภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) แล้วใช้เป็นหัวข้อของย่อหน้า ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เพื่อใช้หัวข้อรูปภาพและกำหนดรูปภาพผ่าน [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) ตั้งเป็น 100% เพื่อกำหนดขนาดหัวข้อสัมพันธ์กับข้อความย่อหน้า:

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

ตั้งค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง Python นี้กำหนดค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) จาก 0 ถึง 3 ให้กับย่อสี่ย่อหน้า สร้างลำดับขั้นในกรอบข้อความเดียวแต่ละย่อหน้าใช้หัวข้อสัญลักษณ์ โดย [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) สลับระหว่างหัวข้อกลมและขีดเพื่อแยกระดับที่อยู่ติดกัน:

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

### **กำหนดค่าเริ่มต้นของรายการเลขแบบกำหนดเอง**

ใช้ [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เพื่อตั้งค่าตัวเลขเริ่มต้นที่แสดงสำหรับย่อหน้าที่เป็นเลข

ตัวอย่าง Python นี้ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) ให้ใช้การนับเลขสำหรับย่อหน้า 3 ย่อหน้าและกำหนดค่า [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เป็น 2, 3, และ 7 ค่าเริ่มต้นกำหนดแยกตามย่อหน้า ทำให้เลขที่แสดงข้ามค่าได้:

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

## **ควบคุมเลเอาต์และคุณสมบัติการสิ้นสุดของย่อหน้า**

ปรับระยะห่างและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งบรรทัดแรกและบรรทัดต่อเนื่อง คุณยังสามารถจัดรูปแบบเครื่องหมายสิ้นสุดของย่อหน้าแยกต่างหากจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้ย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับระยะขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงตำแหน่งเดิม

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เมื่อต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้กำหนดให้ย่อหน้า 3 ย่อหน้ามี [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) เท่าเดิมที่ 20 จุดและค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) เป็น 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ระยะที่เพิ่มขึ้นอย่างต่อเนื่อง ส่วนบรรทัดต่อเนื่องคงระยะขอบซ้ายเดียวกัน:

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

![บรรทัดแรกของย่อหน้าที่มีการเยื้อง](first_line_indent.png)

### **ตั้งค่าเยื้องห่วงจับ**

เยื้องห่วงจับคือการจัดเลเอาต์ที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดต่อเนื่อง ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วยคุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ตั้งค่า `indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปกติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้าและ [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับระยะขอบนั้น เพื่อสร้างเยื้องห่วงจับ ให้ตั้งค่า `margin_left` เป็นบวกและ `indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการศัพท์, และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดต่อเนื่องเรียงชิดภายใต้เนื้อหาย่อหน้าแทนที่จะชิดตัวอักษรแรกของบรรทัดแรก

ตัวอย่าง Python นี้จับคู่ค่า [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) ที่ 40 และ 60 จุดกับค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) ที่ -20 และ -30 จุด ในแต่ละย่อบรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดต่อเนื่อง; ย่อหน้าที่สองมีเยื้องห่วงจับลึกกว่า:

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

![เยื้องห่วงจับของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันตอนสิ้นสุดของย่อหน้า**

คุณสมบัติ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างโหลด `Test.pptx` ที่ต้องมีอย่างน้อยหนึ่งสไลด์และสร้าง [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) ที่ตั้งค่า [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) เป็น 48 จุดและ [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) เป็น Times New Roman จากนั้นกำหนดฟอร์แมตนี้ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง โดยไม่กระทบส่วนข้อความที่มองเห็น:

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

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและการวางเครื่องหมายวรรคตอนที่สิ้นสุดบรรทัด ดูที่ [Control Line Breaking](/slides/th/python-net/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/python-net/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) เพื่อคำนวณจำนวนบรรทัดที่ย่อหน้าครอบครองหลังการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อเช็กความยาวและการจัดวางของข้อความในแม่แบบงานนำเสนอ

ย่อหน้าเป็นหนึ่งรายการใน [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์ การขึ้นบรรทัดใหม่โดยเจตนาในย่อหน้าจะสร้างบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกอักขระขึ้นบรรทัดใหม่ลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระขึ้นบรรทัดใหม่จะไม่ได้ให้จำนวนบรรทัดที่เรนเดอร์

ตัวอย่างต่อไปนี้สร้างรูปร่างข้อความ, นับบรรทัด, ลดความกว้างของรูปร่าง, แล้วเปลี่ยนข้อความเป็นสตริงสั้นกว่า ตัวอย่างเปิดใช้งาน [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) และปิด [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) เพื่อให้ความกว้างของรูปร่างควบคุมการตัดบรรทัดโดยไม่ย่อหรือปรับขนาดข้อความโดยอัตโนมัติ การวัดแต่ละครั้งใช้ [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) มิติของรูปร่างเป็นจุด สุดท้ายตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดของกรอบข้อความ:

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

ด้วยข้อความและมิติที่กำหนด การลดความกว้างของรูปร่างจะเพิ่มจำนวนบรรทัด ส่วนการเปลี่ยนข้อความเป็นสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แม่นยำอาจแตกต่างตามฟอนท์ที่มีอยู่ การแทนที่, ขนาดฟอนท์, ระยะขอบ, การเยื้อง, การตัดบรรทัดและการตั้งค่า autofit ใช้ฟอนท์และการตั้งค่าที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อเช็กแม่แบบ

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความจะล้นคอนเทนเนอร์หรือไม่ ความสูงที่มี, ความสูงบรรทัด, ระยะห่างของย่อหน้าและบรรทัด, รวมถึงพฤติกรรม autofit ก็มีผลด้วย; แม้บรรทัดเดียวก็อาจเกินความกว้างที่ให้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่งานนำเสนอหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีเรนเดอร์ย่อหน้าแยกเป็นภาพ รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML เป็นย่อหน้า**

ใช้ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) เพื่อแปลง HTML ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ

ตัวอย่าง Python นี้อ่าน HTML จากไฟล์ `file.html` ในไดเรกทอรีทำงานและส่ง markup ไปที่ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) โดยล้างย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมผืนผ้าปล่อยช่องว่าง 10 จุดทุกด้านของสไลด์:

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

ใช้ [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อนำข้อความงานนำเสนอกลับไปใช้บนเว็บไซต์ คุณอาจต้องการเก็บการเน้นแบบท้องถิ่นโดยไม่ต้องนำฟอนท์ ขนาด หรือสไตล์กล่องข้อความของงานนำเสนอไปด้วย ตั้งค่า [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) เพื่อควบคุมระดับการสืบทอดรูปแบบที่ตัวส่งออกทำตาม

ดาวน์โหลด [ตัวอย่างงานนำเสนอ](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปร่างข้อความหนึ่งรูปร่างที่มีข้อความ “Inherited text; explicit red 18pt” อินพุตใช้หลายระดับการจัดรูปแบบอย่างเจตนา:

- สไตล์ข้อความเริ่มต้นของงานนำเสนอใช้ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของกรอบข้อความใช้สีฟ้าและเอียง
- ย่อหน้าตั้งค่าข้อความหนาอย่างชัดเจน
- ส่วนที่สอง “explicit red 18pt” ตั้งค่าสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มด้านล่างส่งออกย่อหน้าเดียวกันสามครั้ง โดยส่งค่าตัวเลือก [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและบันทึกผลแต่ละไฟล์เป็น HTML UTF‑8 แยกไฟล์:

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

HTML ที่สร้างขึ้นมี CSS ต่อไปนี้สำหรับส่วนแรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความกระชับ

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, เอียง ขนาด 28 pt ฟอนท์ Calibri หากฟอนท์นี้มี |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, เอียง; ฟอนท์และขนาดมาจากหน้าเว็บหรือเบราว์เซอร์ |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; ฟอนท์, ขนาด, สีและสไตล์เอียงมาจากหน้าเว็บหรือเบราว์เซอร์ |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทุกเอาต์พุต ทั้งยังคงเอียงใน `ALL` และ `TEXT_BOX` แต่ไม่ใน `PARAGRAPH_ONLY` การจำกัดการสืบทอดจึงไม่ได้ลบการจัดรูปแบบที่กำหนดโดยตรงให้กับย่อหน้าหรือส่วน

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในโหมดที่จำกัด การละเว้นคุณสมบัติ CSS จะถูกแก้โดยสไตล์ของหน้าเป้าหมายหรือค่าพื้นฐานของเบราว์เซอร์ ดังนั้นลักษณะการแสดงผลจะขึ้นกับที่ใช้ HTML

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) เรนเดอร์ย่อหน้าเดี่ยวแล้วคืนค่า [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ไม่ต้องเรนเดอร์รูปร่างที่บรรจุหรือครอปบิตแมปด้วยตนเอง

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) อาจคืนค่า `None` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

ตัวอย่างใช้ไฟล์ `sample.pptx` ที่มีสไลด์หนึ่งสไลด์และรูปร่างแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ตำแหน่งดัชนี 1 และเรียก [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) โดยไม่มีพารามิเตอร์สเกล ตรวจสอบว่ารูปร่างมีย่อหน้าที่ต้องการและการเรนเดอร์ได้ภาพ ก่อนเรียก [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) เพื่อบันทึกเป็น PNG ตัวจัดการบริบทจะปล่อยทรัพยากรภาพหลังการใช้

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

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อตั้งค่าตัวคูณสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงสองเท่าของขนาดเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG

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

ค่าตัวคูณสเกล `1` รักษาขนาดพิกเซลของแกนนั้นตามค่าเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น, ผลลัพธ์คือสี่เท่าของจำนวนพิกเซล ตัวคูณที่สูงกว่าจะให้ข้อความคมชัดขึ้นสำหรับการขยายหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าตัวคูณต่ำกว่า `1` จะให้ภาพที่เล็กลงและรายละเอียดน้อยลง ใช้ค่าตัวคูณเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ตัวคูณแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพแยกกัน

การเรนเดอร์รูปร่างทั้งหมดด้วย [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติม, เส้นขอบ หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพที่ต้องการเพียงย่อหน้า ให้ใช้ [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติในกรอบข้อความได้หรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) ให้ปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดเมื่อถึงขอบกรอบข้อความ

**ฉันจะดึงขอบเขตบนสไลด์ของย่อหน้าที่ระบุได้อย่างแม่นยำอย่างไร?**

ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) เพื่อรับสี่เหลี่ยมขอบของย่อหน้า [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) ให้ขอบของส่วนย่อยแต่ละส่วน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อยแต่ละส่วน

เพื่อจัดแนวแนวตั้งของส่วนย่อยที่มีขนาดฟอนท์ต่างกันในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/python-net/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing ให้กับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้