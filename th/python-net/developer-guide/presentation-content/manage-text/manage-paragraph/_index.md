---
title: "จัดการย่อหน้าข้อความ PowerPoint ด้วย Python"
linktitle: "จัดการย่อหน้า"
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
- ระยะเยื้องย่อหน้า
- ระยะเยื้องล้อย
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
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
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—เพิ่มประสิทธิภาพการจัดแนว การเว้นระยะและสไตล์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อดึงดูดผู้ชม."
---
## **บทนำ**

Aspose.Slides มีคลาสที่คุณต้องการสำหรับทำงานกับข้อความ PowerPoint ใน Python.

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) สำหรับสร้างอ็อบเจ็กต์กรอบข้อความ ตัวอ็อบเจ็กต์ `TextFrame` สามารถประกอบด้วยย่อหน้าหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าจะแยกด้วยการขึ้นบรรทัดใหม่).
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สำหรับสร้างอ็อบเจ็กต์ย่อหน้า ตัวอ็อบเจ็กต์ `Paragraph` สามารถประกอบด้วยส่วนข้อความหนึ่งหรือหลายส่วน.
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สำหรับสร้างอ็อบเจ็กต์ส่วนข้อความและกำหนดคุณสมบัติการจัดรูปแบบของพวกมัน.

อ็อบเจ็กต์ `Paragraph` สามารถจัดการข้อความที่มีคุณสมบัติการจัดรูปแบบต่างกันผ่านอ็อบเจ็กต์ `Portion` ที่เป็นพื้นฐานของมัน.

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **เพิ่มหลายย่อหน้าที่มีหลายส่วนข้อความ**

ขั้นตอนต่อไปนี้แสดงวิธีการเพิ่มกรอบข้อความที่มีสามย่อหน้า แต่ละย่อหน้ามีสามส่วนข้อความ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. รับอ้างอิงของสไลด์เป้าหมายตามดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
5. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สองอันและเพิ่มเข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) (รวมกับย่อหน้าเริ่มต้น จะได้สามย่อหน้า).
6. สำหรับแต่ละย่อหน้า สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) จำนวนสามอันและเพิ่มเข้าไปในคอลเลกชันส่วนของย่อนนั้น.
7. กำหนดข้อความให้กับแต่ละส่วน.
8. ใช้คุณสมบัติที่เปิดเผยโดย [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) เพื่อกำหนดการจัดรูปแบบตามต้องการให้กับแต่ละส่วนข้อความ.
9. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python ต่อไปนี้ทำตามขั้นตอนเหล่านี้:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อสร้างไฟล์ PPTX ใหม่.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape รูปสี่เหลี่ยม.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # เข้าถึง TextFrame ของ AutoShape.
    text_frame = shape.text_frame

    # สร้างย่อหน้าและส่วนข้อความ; การจัดรูปแบบจะถูกนำไปใช้ด้านล่าง.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการหัวข้อย่อยของย่อหน้า**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีหัวข้อย่อยมักอ่านง่ายและเข้าใจได้ดีกว่า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมายตามดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
6. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/).
7. ตั้งค่าประเภทหัวข้อย่อยของย่อหน้าเป็น `SYMBOL` และระบุตัวอักษรหัวข้อย่อย.
8. กำหนดข้อความของย่อหน้า.
9. ตั้งค่าการเยื้องหัวข้อย่อยสำหรับย่อหน้า.
10. ตั้งค่าสีหัวข้อย่อย.
11. ตั้งค่าขนาดหัวข้อย่อย (ความสูง).
12. เพิ่มย่อหน้าเข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
13. เพิ่มย่อหน้าที่สองและทำขั้นตอนที่ 7–12 ซ้ำ.
14. บันทึกงานนำเสนอ.

โค้ด Python นี้แสดงวิธีการเพิ่มย่อหน้าที่มีหัวข้อย่อย:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของการนำเสนอ.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มและเข้าถึง AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = shape.text_frame

    # ลบย่อหน้าเริ่มต้น.
    text_frame.paragraphs.remove_at(0)

    # สร้างย่อหน้า.
    paragraph = slides.Paragraph()

    # ตั้งค่ารูปแบบหัวข้อย่อยและสัญลักษณ์ของย่อหน้า.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # ตั้งค่าข้อความของย่อหน้า.
    paragraph.text = "Welcome to Aspose.Slides"

    # ตั้งค่าการเยื้องหัวข้อย่อย.
    paragraph.paragraph_format.indent = 25

    # ตั้งค่าสีหัวข้อย่อย.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # ตั้งค่าสูงหัวข้อย่อย.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าเข้าไปใน TextFrame.
    text_frame.paragraphs.add(paragraph)

    # สร้างย่อหน้าที่สอง.
    paragraph2 = slides.Paragraph()

    # ตั้งค่าประเภทและรูปแบบหัวข้อย่อยของย่อหน้า.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # ตั้งค่าข้อความของย่อหน้า.
    paragraph2.text = "This is numbered bullet"

    # ตั้งค่าการเยื้องหัวข้อย่อย.
    paragraph2.paragraph_format.indent = 25

    # ตั้งค่าสีหัวข้อย่อย.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # ตั้งค่าสูงหัวข้อย่อย.
    paragraph2.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าเข้าไปใน TextFrame.
    text_frame.paragraphs.add(paragraph2)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการหัวข้อย่อยรูปภาพ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อย่อยรูปภาพง่ายต่อการอ่านและเข้าใจ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมายตามดัชนี.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
6. สร้างย่อหน้าโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดข้อความของมัน.
7. โหลดภาพและเพิ่มเข้าไปในคอลเลกชันภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).
8. ตั้งค่าประเภทหัวข้อย่อยเป็น `PICTURE` และกำหนด [PPImage] ให้กับหัวข้อย่อย.
9. ตั้งค่าความสูงของหัวข้อย่อย.
10. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
11. บันทึกงานนำเสนอ.

โค้ด Python นี้แสดงวิธีการเพิ่มและจัดการหัวข้อย่อยรูปภาพ:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # โหลดภาพหัวข้อย่อย.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # เพิ่มและเข้าถึง AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = auto_shape.text_frame

    # ลบย่อหน้าเริ่มต้น.
    text_frame.paragraphs.remove_at(0)

    # สร้างย่อหน้าใหม่.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # ตั้งค่าชนิดหัวข้อย่อยของย่อหน้าเป็นรูปภาพและกำหนดภาพ.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # ตั้งค่าสูงหัวข้อย่อย.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าเข้าไปใน TextFrame.
    text_frame.paragraphs.add(paragraph)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # บันทึกการนำเสนอเป็นไฟล์ PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **จัดการหัวข้อย่อยหลายระดับ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อย่อยหลายระดับง่ายต่อการอ่านและเข้าใจ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมายตามดัชนี.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
5. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
6. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 0.
7. สร้างย่อหน้าที่สองโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 1.
8. สร้างย่อหน้าที่สามโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 2.
9. สร้างย่อหน้าที่สี่โดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 3.
10. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
11. บันทึกงานนำเสนอ.

โค้ด Python ต่อไปนี้แสดงวิธีการเพิ่มและจัดการหัวข้อย่อยหลายระดับ:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของการนำเสนอ.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]
    
    # เพิ่ม AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = shape.text_frame
    
    # ลบย่อหน้าเริ่มต้น.
    text_frame.paragraphs.clear()

    # เพิ่มย่อหน้าแรก.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # ตั้งค่าระดับหัวข้อย่อย.
    paragraph1.paragraph_format.depth = 0

    # เพิ่มย่อหน้าที่สอง.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # ตั้งค่าระดับหัวข้อย่อย.
    paragraph2.paragraph_format.depth = 1

    # เพิ่มย่อหน้าที่สาม.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # ตั้งค่าระดับหัวข้อย่อย.
    paragraph3.paragraph_format.depth = 2

    # เพิ่มย่อหน้าที่สี่.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # ตั้งค่าระดับหัวข้อย่อย.
    paragraph4.paragraph_format.depth = 3

    # เพิ่มย่อหน้าเข้าไปในคอลเลกชัน.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการย่อหน้ากับรายการลำดับเลขกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/) มีคุณสมบัติ `numbered_bullet_start_with` (และอื่นๆ) เพื่อควบคุมการกำหนดเลขและการจัดรูปแบบแบบกำหนดเองสำหรับย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่จะบรรจุย่อหน้า.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
6. สร้าง [Paragraph] แรกและตั้งค่า `numbered_bullet_start_with` เป็น 2.
7. สร้าง [Paragraph] ที่สองและตั้งค่า `numbered_bullet_start_with` เป็น 3.
8. สร้าง [Paragraph] ที่สามและตั้งค่า `numbered_bullet_start_with` เป็น 7.
9. เพิ่มย่อหน้าเหล่านั้นเข้าไปในคอล렉ชันของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
10. บันทึกงานนำเสนอ.

โค้ด Python ต่อไปนี้แสดงวิธีการเพิ่มและจัดการย่อหน้ากับการกำหนดเลขและการจัดรูปแบบแบบกำหนดเอง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # เพิ่มและเข้าถึง AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = shape.text_frame

    # ลบย่อหน้าเริ่มต้นที่มีอยู่.
    text_frame.paragraphs.remove_at(0)

    # สร้างรายการลำดับที่หนึ่ง (เริ่มที่ 2, ระดับความลึก 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # สร้างรายการลำดับที่สอง (เริ่มที่ 3, ระดับความลึก 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # สร้างรายการลำดับที่สาม (เริ่มที่ 7, ระดับความลึก 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งระยะเยื้องบรรทัดแรกสำหรับย่อหน้า**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมระยะเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกเทียบกับระยะซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือจะคงการจัดชิดตามเนื้อย่อหน้า.

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าต่างๆ ของ `indent` เพื่อสาธิตว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างเปล่าให้กับรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและตั้งค่าต่างๆ ของ [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ให้กับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดนี้แสดงวิธีตั้งระยะเยื้องย่อหน้า:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งระยะเยื้องล้อยสำหรับย่อหน้า**

ระยะเยื้องล้อยคือการจัดย่อหน้าโดยบรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟคนี้โดยใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ตั้งค่า `indent` เป็นค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อย่อหน้า.

โดยปฏิบัติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้า ส่วน [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับระยะนั้น เพื่อสร้างระยะเยื้องล้อย ให้ตั้งค่า `margin_left` เป็นบวกและ `indent` เป็นลบ.

การจัดรูปแบบนี้เป็นประโยชน์สำหรับบรรณานุกรม, อ้างอิง, รายการพจนานุกรม, และย่อหน้าอื่นๆ ที่บรรทัดที่ตัดต่อควรจัดชิดใต้เนื้อย่อหน้าไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างให้กับรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า [margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เป็นค่าบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟคระยะเยื้องล้อย.
7. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ.
8. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ดนี้แสดงวิธีตั้งระยะเยื้องล้อยสำหรับย่อหน้า:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![ระยะเยื้องล้อยของย่อหน้า](hanging_indent.png)

## **จัดการรูปแบบส่วนท้ายของย่อหน้า**

เมื่อคุณต้องการควบคุมสไตล์ของ “ส่วนท้าย” ของย่อหน้า (การจัดรูปแบบที่ใช้หลังส่วนข้อความสุดท้าย) ให้ใช้คุณสมบัติ `end_paragraph_portion_format` ตัวอย่างด้านล่างใช้ฟอนต์ Times New Roman ขนาดใหญ่กับส่วนท้ายของย่อหน้าที่สอง.

1. สร้างหรือเปิดไฟล์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. รับสไลด์เป้าหมายตามดัชนี.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. ใช้ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและสร้างสองย่อหน้า.
5. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) ตั้งค่าเป็น Times New Roman ขนาด 48 pt และใช้เป็นรูปแบบส่วนท้ายของย่อหน้า.
6. กำหนดให้กับ `end_paragraph_portion_format` ของย่อหน้า (ใช้กับส่วนท้ายของย่อหน้าที่สอง).
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด Python นี้แสดงวิธีตั้งรูปแบบส่วนท้ายของย่อหน้าสำหรับย่อหน้าที่สอง:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# ลบย่อหน้าเริ่มต้น.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **นำเข้าข้อความ HTML ไปยังย่อหน้า**

Aspose.Slides มีการสนับสนุนที่ดีขึ้นสำหรับการนำเข้าข้อความ HTML ไปยังย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมายตามดัชนี.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
5. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
6. อ่านไฟล์ HTML ต้นฉบับ.
7. เพิ่มเนื้อหา HTML เข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
8. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด Python ต่อไปนี้ทำตามขั้นตอนเหล่านี้เพื่อการนำเข้าข้อความ HTML ไปยังย่อหน้า.

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ Presentation ว่างเปล่า.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรกของการนำเสนอ.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มเข้ามา.
    shape.text_frame.paragraphs.clear()

    # โหลดไฟล์ HTML.
    with open("file.html", "rt") as html_stream:
        # เพิ่มข้อความจากไฟล์ HTML ไปยัง TextFrame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # บันทึกการนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนที่ดีขึ้นสำหรับการส่งออกข้อความเป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอเป้าหมาย.
2. เข้าถึงสไลด์ที่ต้องการตามดัชนี.
3. เลือกรูปร่างที่มีข้อความที่ต้องการส่งออก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
5. เปิดสตรีมไฟล์เพื่อเขียนผลลัพธ์ HTML.
6. ระบุดัชนีเริ่มต้นและส่งออกย่อหน้าที่ต้องการ.

ตัวอย่าง Python นี้แสดงวิธีการส่งออกข้อความย่อหน้าเป็น HTML.

```python
import aspose.slides as slides

# โหลดไฟล์งานนำเสนอ.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # เข้าถึงสไลด์แรกของการนำเสนอ.
    slide = presentation.slides[0]

    # ดัชนีรูปทรงเป้าหมาย.
    index = 0

    # เข้าถึงรูปทรงโดยใช้ดัชนี.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่จะส่งออกทั้งหมด.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกย่อข้อความซึ่งเป็นอ็อบเจ็กต์ของคลาส [Paragraph] ให้เป็นภาพ ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่บรรจุย่อหน้าโดยใช้เมธอด `get_image` จากคลาส [Shape] การคำนวณขอบเขตของย่อหน้าในรูปร่าง และการส่งออกเป็นภาพบิตแม็พ วิธีเหล่านี้ทำให้คุณสามารถดึงส่วนเฉพาะของข้อความจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งเป็นประโยชน์สำหรับการใช้งานต่อในสถานการณ์ต่างๆ.

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่บรรจุสามย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่าง 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยดึงภาพของรูปร่างจากสไลด์แรกของงานนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองในกรอบข้อความของรูปร่าง ย่อหน้านั้นจะถูกวาดใหม่บนภาพบิตแม็พใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้เป็นประโยชน์เมื่อต้องบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงขนาดและการจัดรูปแบบของข้อความอย่างแม่นยำ.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพ.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # คำนวณขอบเขตของย่อหน้าที่สอง.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # ตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่าง 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงจากงานนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ผลลัพธ์ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าถูกคำนวณโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เมื่อต้องการภาพที่มีรายละเอียดสูง เช่น การใช้ในวัสดุพิมพ์คุณภาพสูง.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพ.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # คำนวณขอบเขตของย่อหน้าที่สอง.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # ตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

### ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้หรือไม่?

ได้. ใช้การตั้งค่าการตัดบรรทัดของกรอบข้อความ ([wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/)) เพื่อปิดการตัดบรรทัดดังนั้นบรรทัดจะไม่ตัดที่ขอบของกรอบ.

### ฉันจะรับขอบเขตที่แน่นอนบนสไลด์ของย่อหน้าที่กำหนดได้อย่างไร?

คุณสามารถดึงสี่เหลี่ยมขอบเขตของย่อหน้า (หรือแม้กระทั่งของส่วนข้อความหนึ่งส่วน) เพื่อรู้ตำแหน่งและขนาดที่แม่นยำบนสไลด์.

### ตำแหน่งการจัดแนวของย่อหน้า (ซ้าย/ขวา/ศูนย์/จัดเต็ม) ควบคุมที่ไหน?

[Alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/); มันจะใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบส่วนย่อย.

### ฉันสามารถตั้งภาษาตรวจสอบสะกดให้กับแค่ส่วนของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?

ได้. ภาษาถูกตั้งค่าที่ระดับส่วน ([PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/)) ดังนั้นภาษาหลายภาษาสามารถอยู่ร่วมกันในย่อหน้าเดียวได้.