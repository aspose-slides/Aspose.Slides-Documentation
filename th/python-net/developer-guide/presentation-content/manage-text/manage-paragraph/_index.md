---
title: จัดการย่อหน้าข้อความ PowerPoint ใน Python
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/python-net/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อสัญลักษณ์
- เยื้องย่อหน้า
- เยื้องแขวน
- หัวข้อสัญลักษณ์ย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อสัญลักษณ์
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—เพิ่มประสิทธิภาพการจัดแนว, ระยะห่างและสไตล์ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อดึงดูดผู้ชม."
---
## **บทนำ**

Aspose.Slides มีคลาสต่าง ๆ ที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint ใน Python.

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) สำหรับสร้างวัตถุ text frame. วัตถุ `TextFrame` สามารถประกอบด้วยหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าจะแยกด้วยการขึ้นบรรทัดใหม่).
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สำหรับสร้างวัตถุย่อหน้า. วัตถุ `Paragraph` สามารถมีหนึ่งหรือหลายส่วนของข้อความ.
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สำหรับสร้างวัตถุส่วนข้อความและกำหนดคุณสมบัติการจัดรูปแบบของมัน.

วัตถุ `Paragraph` สามารถจัดการข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านวัตถุ `Portion` ที่อยู่ภายใน.

## **เพิ่มหลายย่อหน้าที่ประกอบด้วยหลายส่วนข้อความ**

ขั้นตอนเหล่านี้แสดงวิธีการเพิ่ม text frame ที่ประกอบด้วยสามย่อหน้า แต่ละย่อหน้ามีสามส่วนข้อความ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. รับอ้างอิงไปยังสไลด์เป้าหมายโดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์.
1. รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
1. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) จำนวนสองอันและเพิ่มเข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) (พร้อมกับย่อหน้าเริ่มต้น จะได้สามย่อหน้า).
1. สำหรับแต่ละย่อหน้า ให้สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) จำนวนสามอันและเพิ่มเข้าไปในคอลเลกชันส่วนของย่อคนั้น.
1. กำหนดข้อความสำหรับแต่ละส่วน.
1. ใช้คุณสมบัติของ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) เพื่อกำหนดการจัดรูปแบบที่ต้องการสำหรับแต่ละส่วนข้อความ.
1. บันทึกการนำเสนอที่แก้ไขแล้ว.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

#    สร้างอินสแตนซ์ของคลาส Presentation เพื่อสร้างไฟล์ PPTX ใหม่.
with slides.Presentation() as presentation:

    #    เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    #    เพิ่ม AutoShape รูปสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    #    เข้าถึง TextFrame ของ AutoShape.
    text_frame = shape.text_frame

    #    สร้างย่อหน้าและส่วนข้อความ; การจัดรูปแบบจะถูกนำไปใช้ด้านล่าง.
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
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    #    บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการหัวข้อสัญลักษณ์ของย่อหน้า**

รายการหัวข้อสัญลักษณ์ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีหัวข้อสัญลักษณ์มักอ่านง่ายและเข้าใจได้ง่ายกว่า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/).
1. ตั้งค่าประเภทหัวข้อสัญลักษณ์ของย่อหน้าเป็น `SYMBOL` และระบุอักขระหัวข้อ.
1. กำหนดข้อความของย่อหน้า.
1. ตั้งค่าการเยื้องหัวข้อสัญลักษณ์สำหรับย่อหน้า.
1. ตั้งค่าสีหัวข้อสัญลักษณ์.
1. ตั้งค่าขนาดหัวข้อสัญลักษณ์ (ความสูง).
1. เพิ่มย่อหน้าไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนที่ 7‑12.
1. บันทึกการนำเสนอ.

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

    # กำหนดรูปแบบหัวข้อสัญลักษณ์และอักขระของย่อหน้า.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # กำหนดข้อความของย่อหน้า.
    paragraph.text = "Welcome to Aspose.Slides"

    # กำหนดการเยื้องหัวข้อสัญลักษณ์.
    paragraph.paragraph_format.indent = 25

    # กำหนดสีหัวข้อสัญลักษณ์.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # กำหนดความสูงของหัวข้อสัญลักษณ์.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph)

    # สร้างย่อหน้าที่สอง.
    paragraph2 = slides.Paragraph()

    # กำหนดประเภทและสไตล์หัวข้อสัญลักษณ์ของย่อหน้า.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # กำหนดข้อความของย่อหน้า.
    paragraph2.text = "This is numbered bullet"

    # กำหนดการเยื้อนหัวข้อสัญลักษณ์.
    paragraph2.paragraph_format.indent = 25

    # กำหนดสีหัวข้อสัญลักษณ์.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # กำหนดความสูงของหัวข้อสัญลักษณ์.
    paragraph2.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph2)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการหัวข้อสัญลักษณ์รูปภาพ**

รายการหัวข้อสัญลักษณ์ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อสัญลักษณ์รูปภาพอ่านง่ายและเข้าใจได้ง่าย.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/).
1. โหลดรูปภาพเข้าไปในอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).
1. ตั้งค่าประเภทหัวข้อสัญลักษณ์เป็น [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) และกำหนดรูปภาพให้.
1. กำหนดข้อความของย่อหน้า.
1. ตั้งค่าการเยื้องหัวข้อสัญลักษณ์สำหรับย่อหน้า.
1. ตั้งค่าสีหัวข้อสัญลักษณ์.
1. ตั้งค่าความสูงของหัวข้อสัญลักษณ์.
1. เพิ่มย่อหน้าใหม่ไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนที่ 8‑12.
1. บันทึกการนำเสนอ.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # โหลดรูปภาพหัวข้อสัญลักษณ์.
    image = draw.Bitmap("bullets.png")
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

    # ตั้งค่าประเภทหัวข้อสัญลักษณ์ของย่อหน้าเป็น Picture และกำหนดรูปภาพ.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # ตั้งค่าความสูงของหัวข้อสัญลักษณ์.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # บันทึกการนำเสนอเป็นไฟล์ PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **จัดการหัวข้อสัญลักษณ์หลายระดับ**

รายการหัวข้อสัญลักษณ์ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อสัญลักษณ์หลายระดับอ่านง่ายและเข้าใจได้ง่าย.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
1. เข้าถึง [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ของรูปร่างและ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 0.
1. สร้างย่อหน้าที่สองโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 1.
1. สร้างย่อหน้าที่สามโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 2.
1. สร้างย่อหน้าใหม่ที่สี่โดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 3.
1. เพิ่มย่อหน้าใหม่เหล่านั้นไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. บันทึกการนำเสนอ.

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
    text_frame = auto_shape.text_frame
    
    # ลบย่อหน้าเริ่มต้น.
    text_frame.paragraphs.clear()

    # Add the first paragraph.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับหัวข้อสัญลักษณ์.
    paragraph1.paragraph_format.depth = 0

    # Add the second paragraph.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับหัวข้อสัญลักษณ์.
    paragraph2.paragraph_format.depth = 1

    # Add the third paragraph.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับหัวข้อสัญลักษณ์.
    paragraph3.paragraph_format.depth = 2

    # Add the fourth paragraph.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับหัวข้อสัญลักษณ์.
    paragraph4.paragraph_format.depth = 3

    # เพิ่มย่อหน้าไปยังคอลเลกชัน.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการย่อหน้ากับรายการลำดับเลขแบบกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/) มีคุณสมบัติ `numbered_bullet_start_with` (และอื่น ๆ) เพื่อควบคุมการจัดลำดับเลขและการจัดรูปแบบแบบกำหนดเองสำหรับย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. เข้าถึงสไลด์ที่จะบรรจุย่อหน้า.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. สร้าง [Paragraph] แรกและตั้งค่า `numbered_bullet_start_with` เป็น 2.
1. สร้าง [Paragraph] ที่สองและตั้งค่า `numbered_bullet_start_with` เป็น 3.
1. สร้าง [Paragraph] ที่สามและตั้งค่า `numbered_bullet_start_with` เป็น 7.
1. เพิ่มย่อหน้าเหล่านั้นไปยังคอลเลกชันของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. บันทึกการนำเสนอ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # เพิ่มและเข้าถึง AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = shape.text_frame

    # ลบย่อหน้าเริ่มต้นที่มีอยู่.
    text_frame.paragraphs.remove_at(0)

    # สร้างรายการลำดับเลขแรก (เริ่มที่ 2, ระดับความลึก 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # สร้างรายการลำดับเลขที่สอง (เริ่มที่ 3, ระดับความลึก 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # สร้างรายการลำดับเลขที่สาม (เริ่มที่ 7, ระดับความลึก 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการเยื้องบรรทัดแรกของย่อหน้า**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกสัมพันธ์กับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดอื่นจะยังคงเรียงตามตัวเนื้อหาย่อหน้า.

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) หากต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) หากต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่า `indent` ที่แตกต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างเปล่าไปยังรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าหลายอันและกำหนดค่า [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ที่แตกต่างกันสำหรับแต่ละอัน.
6. เพิ่มย่อหน้าเหล่านั้นเข้าไปใน text frame.
7. บันทึกการนำเสนอที่แก้ไขแล้ว.

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่าการเยื้องแขวนสำหรับย่อหน้า**

การเยื้องแขวนคือรูปแบบย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสามารถสร้างเอฟเฟกต์นี้โดยใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/). ตั้งค่า `indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า.

โดยปฏิบัติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบนั้น เพื่อสร้างการเยื้องแขวน ให้ตั้งค่า `margin_left` เป็นค่าบวกและ `indent` เป็นค่าลบ.

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม และย่อหน้าอื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดแนวอยู่ใต้เนื้อหาย่อหน้า แทนที่ตำแหน่งอักขระแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างเปล่าไปยังรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า [margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เป็นค่าบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์การเยื้องแขวน.
7. เพิ่มย่อหน้าเหล่านั้นเข้าไปใน text frame.
8. บันทึกการนำเสนอที่แก้ไขแล้ว.

```py
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

![การเยื้องแขวนของย่อหน้า](hanging_indent.png)

## **จัดการรูปแบบส่วนท้ายของย่อหน้า**

เมื่อคุณต้องการควบคุมการจัดรูปแบบของ “ส่วนท้าย” ของย่อหน้า (การจัดรูปแบบที่ใช้หลังส่วนข้อความสุดท้าย) ให้ใช้คุณสมบัติ `end_paragraph_portion_format` ตัวอย่างด้านล่างใช้แบบอักษร Times New Roman ขนาดใหญ่สำหรับส่วนท้ายของย่อหน้าที่สอง.

1. สร้างหรือเปิดไฟล์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. รับสไลด์เป้าหมายโดยระบุดัชนี.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปสี่เหลี่ยมไปยังสไลด์.
1. ใช้ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและสร้างย่อหน้าสองอัน.
1. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) ที่กำหนดเป็น Times New Roman ขนาด 48 pt แล้วกำหนดเป็นรูปแบบส่วนท้ายของย่อหน้า.
1. กำหนดให้กับ `end_paragraph_portion_format` ของย่อหน้า (ใช้กับส่วนท้ายของย่อหน้าที่สอง).
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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

Aspose.Slides มีการสนับสนุนที่เพิ่มขึ้นสำหรับการนำเข้าข้อความ HTML ไปยังย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์.
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/).
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. อ่านไฟล์ HTML ต้นฉบับ.
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/).
1. เพิ่มเนื้อหา HTML ไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
1. บันทึกการนำเสนอที่แก้ไขแล้ว.

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ Presentation ว่าง.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรกของการนำเสนอ.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่ม.
    shape.text_frame.paragraphs.clear()

    # โหลดไฟล์ HTML.
    with open("file.html", "rt") as html_stream:
        # เพิ่มข้อความจากไฟล์ HTML ไปยัง TextFrame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # บันทึกการนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนที่เพิ่มขึ้นสำหรับการส่งออกข้อความเป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดการนำเสนอเป้าหมาย.
1. เข้าถึงสไลด์ที่ต้องการโดยระบุดัชนี.
1. เลือกรูปร่างที่มีข้อความที่จะส่งออก.
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง.
1. เปิดสตรีมไฟล์เพื่อเขียนผลลัพธ์ HTML.
1. ระบุดัชนีเริ่มต้นและส่งออกย่อหน้าที่ต้องการ.

```python
import aspose.slides as slides

# โหลดไฟล์การนำเสนอ.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # เข้าถึงสไลด์แรกของการนำเสนอ.
    slide = presentation.slides[0]

    # ดัชนีรูปร่างเป้าหมาย.
    index = 0

    # เข้าถึงรูปร่างโดยใช้ดัชนี.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่จะส่งออก.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีการบันทึกย่อความข้อความที่แสดงโดยคลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) เป็นภาพ ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่บรรจุย่อหน้าด้วยเมธอด `get_image` จากคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/), การคำนวณขอบเขตของย่อหน้าในรูปร่าง, และการส่งออกเป็นภาพบิตแมพ วิธีเหล่านี้ช่วยให้คุณดึงส่วนเฉพาะของข้อความจากการนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์สำหรับการใช้งานต่อในหลายสถานการณ์.

สมมติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**Example 1**

ในตัวอย่างนี้ เราดึงย่อหน้าที่สองเป็นภาพ โดยดึงภาพของรูปร่างจากสไลด์แรกของการนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน text frame ของรูปร่างนั้น จากนั้นวาดย่อหน้านั้นลงบนบิตแมพใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้เหมาะสำหรับการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงมิติและการจัดรูปแบบเดิมของข้อความ.

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

![ภาพของย่อหน้า](paragraph_to_image_output.png)

**Example 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงออกจากการนำเสนอและบันทึกเป็นภาพโดยใช้สเกล `2` ซึ่งทำให้ได้เอาต์พุตความละเอียดสูงขึ้นเมื่อส่งออกรูปย่อหน้า จากนั้นคำนวณขอบเขตของย่อหน้าพิจารณาตามสเกล การสเกลอาจมีประโยชน์เมื่อต้องการภาพละเอียดมากขึ้น เช่น สำหรับวัสดุพิมพ์คุณภาพสูง.

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

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน text frame อย่างสมบูรณ์ได้หรือไม่?**  
ได้. ใช้การตั้งค่าการตัดบรรทัดของ text frame ([wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/)) เพื่อปิดการตัดบรรทัด sehingga บรรทัดจะไม่ตัดที่ขอบของกรอบ.

**ฉันจะรับขอบเขตที่แน่นอนบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**  
คุณสามารถดึงสี่เหลี่ยมขอบเขตของย่อหน้า (หรือแม้แต่ของส่วนข้อความเดียว) เพื่อทราบตำแหน่งและขนาดที่แน่นอนบนสไลด์.

**การจัดแนวย่อหน้า (ซ้าย/ขวา/กลาง/เต็ม) ถูกควบคุมที่ไหน?**  
[Alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/); มันจะใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของแต่ละส่วน.

**ฉันสามารถตั้งค่าภาษาเพื่อตรวจสอบการสะกดสำหรับส่วนหนึ่งของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?**  
ได้. ภาษาเป็นการตั้งค่าที่ระดับส่วน ([PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/)) ดังนั้นหลายภาษาอาจอยู่ร่วมกันในย่อหน้าเดียว.