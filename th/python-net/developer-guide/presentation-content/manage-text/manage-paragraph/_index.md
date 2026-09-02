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
- จัดการหัวข้อย่อย
- ย่อหน้าการเยื้อง
- ระยะเยื้องแบบห้อย
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัตีย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออวย่อหน้า
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, หัวข้อย่อย, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML และภาพย่อหน้า ด้วย Aspose.Slides for Python via .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วน:

* [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) แสดงถึงคอนเทนเนอร์ข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า.
* [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) แสดงย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนต่าง ๆ รวมถึงการจัดรูปแบบระดับย่อหน้า.
* [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) แสดงส่วนของข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักษรของตนเองได้.

ดังนั้นย่อหน้าจึงสามารถบรรจุข้อความที่มีแบบอักษร, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วน.

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วน**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีสามย่อหน้า, แต่ละย่อหน้ามีสามส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) อีกสองอันไปยังกรอบข้อความ.
6. เพิ่มวัตถุ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) จำนวนเพียงพอสำหรับแต่ละย่อหน้าให้มีสามส่วน ย่อหน้าเริ่มต้นมีส่วนว่างหนึ่งส่วนอยู่แล้ว.
7. กำหนดข้อความของแต่ละส่วน.
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/portion_format/).
9. บันทึกการนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python นี้ดำเนินขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบมีสัญลักษณ์และลำดับเลข**

### **สร้างรายการแบบสัญลักษณ์หรือเลขลำดับ**

สัญลักษณ์และการลำดับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/).

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สำหรับสัญลักษณ์ bullet.
7. ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.SYMBOL](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/) และระบุอักขระของสัญลักษณ์ bullet.
8. ตั้งค่าข้อความย่อหน้า, ระยะเยื้อง, สีของ bullet, และความสูงของ bullet.
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.NUMBERED](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/).
11. กำหนดสไตล์ของ bullet ที่เป็นเลขลำดับและเพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
12. บันทึกการนำเสนอ.

ตัวอย่าง Python นี้สร้างสัญลักษณ์ bullet และ bullet แบบลำดับเลข:

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

### **ใช้รูปภาพเป็น Bullet**

รูปภาพ bullet ให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
5. โหลดภาพ bullet และเพิ่มเข้ากับคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดข้อความของมัน.
7. ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.PICTURE](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/).
8. กำหนดภาพผ่าน [BulletFormat.picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/picture/) และตั้งค่าความสูงของ bullet.
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
10. บันทึกการนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python นี้สร้างรูปภาพ bullet:

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

ตั้งค่า [ParagraphFormat.depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีค่า depth เป็น `0`.

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน.
3. สร้างย่อหน้า 4 รายการและกำหนดสัญลักษณ์ bullet ของพวกมัน.
4. ตั้งค่าของ [ParagraphFormat.depth] เป็น `0`, `1`, `2`, และ `3`.
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ.

ตัวอย่าง Python นี้สร้างรายการสัญลักษณ์สี่ระดับ:

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

### **เริ่มรายการเลขลำดับด้วยค่าที่กำหนดเอง**

ใช้ [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เพื่อตั้งค่าตัวเลขเริ่มต้นที่แสดงสำหรับย่อหน้าที่เป็นเลขลำดับ.

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปร่าง.
3. สร้างย่อหน้าเลขลำดับสามรายการ.
4. ตั้งค่า [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เป็น `2`, `3`, และ `7` สำหรับย่อหน้าแต่ละอัน.
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ.

ตัวอย่าง Python นี้กำหนดตัวเลขเริ่มต้นแบบกำหนดเองให้แต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติส่วนท้าย**

### **ตั้งระยะเยื้องบรรทัดแรก**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมระยะเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกเทียบกับระยะบรรทัดซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตรงกับเนื้อหาย่อหน้า

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เมื่อเพียงต้องการย้ายบรรทัดแรก

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและกำหนดค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ที่แตกต่างกันเพื่อแสดงผลของระยะเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและตั้งค่าต่าง ๆ ของ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ให้กับแต่ละรายการ.
6. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
7. บันทึกการนำเสนอที่แก้ไขแล้ว.

โค้ดนี้แสดงวิธีตั้งระยะเยื้องย่อหน้า:

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

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งระยะเยื้องแบบห้อย**

ระยะเยื้องแบบห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสามารถสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ตั้งค่า `indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, และ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ margin นั้น เพื่อสร้างระยะเยื้องแบบห้อยให้ตั้งค่า `margin_left` เป็นค่าบวกและ `indent` เป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม, และย่อหน้าอื่น ๆ ที่ต้องให้บรรทัดต่อเนื่องอยู่ใต้เนื้อหาย่อหน้าแทนการอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) ให้เป็นค่าบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ให้เป็นค่าลบเพื่อสร้างเอฟเฟกต์ระยะเยื้องแบบห้อย.
7. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
8. บันทึกการนำเสนอที่แก้ไขแล้ว.

โค้ดนี้แสดงวิธีตั้งระยะเยื้องแบบห้อยให้กับย่อหน้า:

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

![ระยะเยื้องแบบหอยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันของย่อหน้าสิ้นสุด**

คุณสมบัติ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นของมัน.
3. สร้างย่อหน้า 2 รายการและเพิ่มส่วนข้อความเข้าไป.
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง.
5. ตั้งค่า [PortionFormat.font_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/font_height/) และ [PortionFormat.latin_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/latin_font/).
6. นำรูปแบบไปกำหนดให้กับ [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) แล้วบันทึกการนำเสนอ.

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้าข้อความ HTML ลงในย่อหน้า**

ใช้ [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/add_from_html/) เพื่อแปลงโค้ด HTML ให้เป็นย่อหน้าและส่วนในกรอบข้อความ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์แล้วเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
4. อ่านไฟล์ HTML ต้นทาง.
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. บันทึกการนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python นี้นำเข้า HTML ไปยังกรอบข้อความ:

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

ใช้ [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/export_to_html/) เพื่อส่งออกช่วงของย่อหน้าเป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ.
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มีข้อความ.
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
4. เรียก [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphcollection/export_to_html/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก.
5. เขียนสตริง HTML ที่ได้ลงไฟล์.

ตัวอย่าง Python นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

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

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) มีเมธอด `get_image` สำหรับการเรนเดอร์ย่อหน้าเดี่ยวโดยตรง เมธอดจะคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ที่คุณสามารถบันทึกเป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/save/). ไม่จำเป็นต้องเรนเดอร์รูปร่างทั้งหมดหรือครอบตัดบิตแมปด้วยตนเอง

เมธอด `get_image` อาจคืนค่า `None` หากย่อหน้าไม่พบในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและใช้ภาพที่ได้รับเป็น context manager เพื่อปล่อยทรัพยากร

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมติว่ามีไฟล์การนำเสนอชื่อ sample.pptx มีสไลด์เดียว โดยรูปแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG:

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

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการปรับสเกล**

ส่งค่าอัตราส่วนแนวนอนและแนวตั้งไปยัง `get_image` เพื่อควบคุมขนาดของย่อหน้าที่เรนเดอร์ ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลลัพธ์เป็นภาพ PNG:

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

อัตราส่วน `1` จะรักษาขนาดพิกเซลของแกนนั้นตามค่าเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ความกว้างและความสูงของภาพประมาณสองเท่าของขนาดเดิม, ส่งผลให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ค่าอัตราส่วนที่ใหญ่กว่าจะทำให้ข้อความคมชัดยิ่งขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ส่วนค่าอัตราส่วนที่ต่ำกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดลดลง ใช้อัตราส่วนที่เท่ากันเพื่อรักษาอัตราส่วนภาพของย่อหน้า; ค่าอัตราส่วนแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกตามแต่ละแกน

การเรนเดอร์รูปทั้งหมดด้วย [Shape.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/) ยังคงมีประโยชน์เมื่อต้องการรวมฟิล, เส้นขอบ หรือบริบทภาพอื่น ๆ ของรูปร่างไว้ในเอาต์พุต สำหรับภาพที่มีเพียงย่อหน้าเดียวให้ใช้ `Paragraph.get_image`.

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้ทั้งหมดหรือไม่?**

ใช่. ตั้งค่า [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ.

**ฉันจะรับขอบเขตที่แม่นยำบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_rect/) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า. [Portion.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/get_rect/) ให้ขอบเขตของส่วนแต่ละส่วน.

**ตำแหน่งการจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง หรือ ชิดขอบ) ถูกควบคุมที่ไหน?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อย.

**ฉันสามารถตั้งค่าภาษาการตรวจสอบสำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) สำหรับส่วนแต่ละส่วน, ทำให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษา.