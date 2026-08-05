---
title: จัดการรายการหัวข้อหมู่และลำดับเลขในงานนำเสนอด้วย Python
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- หัวข้อหมู่
- รายการหัวข้อหมู่
- รายการลำดับเลข
- หัวข้อหมู่สัญลักษณ์
- หัวข้อหมูรูปภาพ
- หัวข้อหมู่กำหนดเอง
- รายการหลายระดับ
- สร้างหัวข้อหมู่
- เพิ่มหัวข้อหมู่
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการสร้างและจัดรูปแบบรายการหัวข้อหมู่, รายการหัวข้อหมูรูปภาพ, รายการหลายระดับและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณสร้างและจัดรูปแบบรายการหัวข้อหมู่และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการแต่ละรายการคือย่อหน้าที่การตั้งค่าหัวข้อหมู่อยู่ภายใต้รูปแบบย่อหน้าของมัน

ใช้คุณสมบัติ [Paragraph.paragraph_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/paragraph_format/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [ParagraphFormat.bullet](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/bullet/) ซึ่งจะคืนค่าออบเจกต์ [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/) ด้วยออบเจกต์นี้คุณสามารถตั้งค่าประเภทหัวข้อหมู่ สัญลักษณ์ รูปภาพ สี ขนาด รูปแบบการตั้งเลข และเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:

- สร้างรายการหัวข้อหมู่ด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างหัวข้อหมู่รูปภาพ
- สร้างรายการหลายระดับโดยการตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการหัวข้อหมู่**

เพื่อสร้างรายการหัวข้อหมู่ ให้เพิ่มออบเจกต์ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) ลงใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) และตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.SYMBOL](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/) จากนั้นคุณสามารถตั้งค่า [BulletFormat.char](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/color/), และ [BulletFormat.height](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/height/) เพื่อควบคุมการแสดงผลของหัวข้อหมู่ได้

โค้ด Python ด้านล่างแสดงวิธีการสร้างรายการหัวข้อหมู่ในสไลด์:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
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

![หัวข้อหมู่สัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.NUMBERED](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/) คุณยังสามารถเลือกรูปแบบการตั้งเลขด้วย [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_style/) หรือกำหนดค่าเริ่มต้นด้วย [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) หากต้องการให้รายการเริ่มจากค่าที่ไม่ใช่ 1

โค้ด Python ด้านล่างแสดงวิธีการสร้างรายการลำดับเลขในสไลด์:

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

![หัวข้อหมู่ลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อหมู่รูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์หัวข้อหมู่ปกติด้วยภาพ หัวข้อหมู่รูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและอ่านได้เมื่อมีขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งแสงขนาดเล็ก

{{% alert color="primary" %}}
โดยแนวคิด หากคุณวางแผนจะเปลี่ยนสัญลักษณ์หัวข้อหมู่ปกติเป็นภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง ภาพแบบนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อหมู่แบบกำหนดเอง
{{% /alert %}}

เพื่อสร้างหัวข้อหมู่รูปภาพ ให้เพิ่มภาพลงใน [Presentation.images](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/images/) แล้วกำหนดออบเจกต์ภาพที่คืนค่ามาให้กับ [BulletFormat.picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/picture/) ตั้งค่า [BulletFormat.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/type/) เป็น [BulletType.PICTURE](https://reference.aspose.com/slides/th/python-net/aspose.slides/bullettype/) ก่อนการกำหนดภาพ

สมมติว่าเรามี "image.png":

![รูปภาพสำหรับหัวข้อหมู่](picture_for_bullets.png)

โค้ด Python ด้านล่างแสดงวิธีการสร้างหัวข้อหมู่รูปภาพในสไลด์:

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

![หัวข้อหมู่รูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [ParagraphFormat.depth](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/depth/) เพื่อวางรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ใต้ระดับนั้น และต่อไป

โค้ด Python ด้านล่างแสดงวิธีการสร้างรายการหัวข้อหมู่หลายระดับ:

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

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [ParagraphFormat.bullet](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/bullet/) คุณสมบัติเช่นเดียวกับที่ใช้สร้างรายการสามารถใช้ตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

โค้ด Python ด้านล่างเปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้รูปแบบรายการลำดับเลข:

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

## **FAQ**

**สามารถส่งออกรายการหัวข้อหมู่และลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ได้ Aspose.Slides รักษารูปแบบรายการไว้เมื่อรูปแบบเป้าหมายรองรับการจัดวางข้อความและคุณสมบัติหัวข้อหมู่ที่สอดคล้อง

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ได้ โหลดงานนำเสนอ เข้าถึงย่อเป้าหมาย ตรวจสอบหรืออัปเดตการตั้งค่า [ParagraphFormat.bullet](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/bullet/) แล้วบันทึกงานนำเสนอ

**รายการสามารถประกอบด้วยข้อความนอกลาตินได้หรือไม่?**

ได้ ข้อความรายการสามารถมีอักขระ Unicode ได้ ดังนั้นคุณจึงสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอรองรับอักขระที่คุณต้องการ