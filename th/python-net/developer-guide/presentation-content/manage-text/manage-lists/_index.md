---
title: จัดการรายการแบบมีจุดและลำดับเลขในงานนำเสนอด้วย Python
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
  - จุด
  - รายการแบบมีจุด
  - รายการลำดับเลข
  - จุดสัญลักษณ์
  - จุดภาพ
  - จุดกำหนดเอง
  - รายการหลายระดับ
  - สร้างจุด
  - เพิ่มจุด
  - เพิ่มรายการ
  - PowerPoint
  - OpenDocument
  - งานนำเสนอ
  - Python
  - Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบมีจุด, จุดภาพ, รายการหลายระดับ และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณสร้างและจัดรูปแบบรายการแบบมีจุดและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าจุดถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้คุณสมบัติ [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเข้าหลักคือ [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), ซึ่งจะส่งคืนอ็อบเจ็กต์ [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าชนิดของจุด สัญลักษณ์ ภาพ สี ขนาด รูปแบบการลำดับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:

- สร้างรายการแบบมีจุดด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างจุดภาพ
- สร้างรายการหลายระดับโดยกำหนดความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านเครื่องหมายรายการและหมายเลขจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการแบบมีจุด**

เพื่อสร้างรายการแบบมีจุด ให้เพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) ไปยัง [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) แล้วตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) จากนั้นคุณสามารถตั้งค่า [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/), และ [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) เพื่อควบคุมลักษณะของจุด

โค้ด Python ด้านล่างแสดงวิธีสร้างรายการแบบมีจุดในสไลด์:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![จุดสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการสำคัญ ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) คุณยังสามารถเลือกรูปแบบการลำดับเลขด้วย [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) หรือกำหนดค่า [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด Python ด้านล่างแสดงวิธีสร้างรายการลำดับเลขในสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![จุดลำดับเลข](numbered_bullets.png)

## **สร้างจุดภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์จุดทั่วไปด้วยภาพ จุดภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและยังคงอ่านได้เมื่อต่ำขนาด เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก

{{% alert color="info" title="Note" %}}
โดยทั่วไป หากคุณวางแผนจะแทนที่สัญลักษณ์จุดทั่วไปด้วยภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งใส ภาพประเภทนี้ทำงานได้ดีเป็นสัญลักษณ์จุดแบบกำหนดเอง

จำไว้ว่า ภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ด้วยเหตุนี้ เราขอแนะนำอย่างยิ่งให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพทางสายตาเมื่อนำไปใช้เป็นจุดในรายการ
{{% /alert %}}

เพื่อสร้างจุดภาพ ให้เพิ่มภาพลงใน [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) และกำหนดอ็อบเจ็กต์ภาพที่คืนค่าให้กับ [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) ก่อนกำหนดภาพ

สมมติว่าเรามีไฟล์ "image.png":

![ภาพสำหรับจุด](picture_for_bullets.png)

โค้ด Python ด้านล่างแสดงวิธีสร้างจุดภาพในสไลด์:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![จุดภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) เพื่อวางรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านล่างเป็นระดับย่อยต่อไป ฯลฯ ความลึกควบคุมการเว้นระยะเฉพาะ; ให้ตั้งค่า [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) ในแต่ละย่อหน้าเมื่อระดับต้องมีจุดด้วย

โค้ด Python ด้านล่างแสดงวิธีสร้างรายการหลายระดับ:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) คุณสมบัติเหมือนที่ใช้สร้างรายการสามารถใช้ตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

โค้ด Python ด้านล่างเปลี่ยนย่อหน้าแรกใน TextFrame ให้ใช้สไตล์รายการลำดับเลข:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **อ่านค่าจุดจริง**

เมื่อต้องดึงเนื้อหาจากงานนำเสนอ ควรเก็บเครื่องหมายรายการไว้พร้อมกับข้อความย่อหน้า เรียกใช้ [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) และเข้าถึง [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) เพื่อรับรูปแบบจุดที่มีผล ตรวจสอบ [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) ก่อนอ่าน [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/)

สำหรับรายการลำดับเลข ให้แยกค่าเหล่านี้สามค่า:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) กำหนดรูปแบบ เช่น ตัวเลขอาหรับที่ตามด้วยจุดหรืออักษรตัวพิมพ์เล็กที่ตามด้วยจุด
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) ระบุหมายเลขเริ่มต้นสำหรับกลุ่มย่อหน้าที่มีการลำดับเลข
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) ส่งคืนเครื่องหมายที่จัดรูปแบบสำหรับย่อหน้าหนึ่ง ตัวอย่าง รายการที่สองในรายการที่เริ่มที่ 5 จะคืนค่า `6.`

รักษา [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) ของแต่ละย่อหน้าเพื่อคงระดับการซ้อนกันของรายการ เครื่องหมายจริงไม่ได้เข้ารหัสลำดับขั้นตอนทั้งหมด: รายการที่ซ้อนกันอาจคืนค่า `c.` แทนที่จะเป็นป้ายรวมเช่น `6.c.`

ตัวอย่างอิสระต่อไปนี้สร้างรายการ, บันทึกลงในงานนำเสนอ, และโหลดงานนำเสนอใหม่เพื่อรายงานข้อความของแต่ละย่อหน้า, ความลึก, ชนิดของจุด, และค่าจริง เครื่องหมายภาพสีน้ำเงินขนาดเล็กถูกสร้างจาก SVG ในบรรทัดเดียว

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # สร้างเครื่องหมายภาพโดยไม่ใช้ไฟล์รูปภาพภายนอก.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

รายการต้นทางแสดงด้านล่าง

![รายการที่เริ่มที่ 5, รายการย่อยเป็นตัวอักษรและตัวเลขโรมัน, เครื่องหมายสัญลักษณ์, ย่อหน้าที่ไม่มีจุด, และเครื่องหมายภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานตรงกับเครื่องหมายที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

สำหรับ [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/), [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) จะคืนค่า `None` ไม่ใช่สตริงว่าง ให้จัดการประเภทเหล่านี้แยกกัน: ประเภทแรกไม่มีเครื่องหมาย, ขณะที่ประเภทหลังต้องดึงภาพจุดออกแยกต่างหาก จุดภาพไม่สามารถสร้างซ้ำได้โดยการดึงเครื่องหมายข้อความเท่านั้น

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการแบบมีจุดและรายการลำดับเลขเป็น PDF หรือภาพได้หรือไม่?**

ใช่ Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดเรียงข้อความและคุณลักษณะจุดที่สอดคล้องกัน

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ใช่ โหลดงานนำเสนอ, เข้าถึงย่อหน้าที่ต้องการ, ตรวจสอบหรืออัปเดตการตั้งค่า [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) และบันทึกงานนำเสนอ

**รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ใช่ ข้อความของรายการสามารถมีอักขระ Unicode ทำให้คุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำสนับสนุนอักขระที่ต้องการ