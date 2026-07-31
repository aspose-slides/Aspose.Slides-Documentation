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
- จัดการรายการหัวข้อ
- การเยื้องย่อหน้า
- การเยื้องหอย
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
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—ปรับปรุงการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อดึงดูดผู้ชม."
---
## **บทนำ**

Aspose.Slides มีคลาสที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint ใน Python

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) สำหรับสร้างอ็อบเจ็กต์กรอบข้อความ `TextFrame` อาจมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกแยกด้วยการขึ้นบรรทัดใหม่)
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สำหรับสร้างอ็อบเจ็กต์ย่อหน้า `Paragraph` อาจมีหนึ่งหรือหลาย Portion
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สำหรับสร้างอ็อบเจ็กต์ Portion และกำหนดคุณสมบัติการจัดรูปแบบของมัน

อ็อบเจ็กต์ `Paragraph` สามารถจัดการข้อความที่มีการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจ็กต์ `Portion` พื้นฐานของมัน

## **เพิ่มหลายย่อหน้าที่มีหลาย Portion**

ขั้นตอนต่อไปนี้แสดงวิธีการเพิ่มกรอบข้อความที่มีสามย่อหน้า โดยแต่ละย่อหน้ามีสาม Portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์เป้าหมายโดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
1. รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)
1. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) สองอันและเพิ่มลงในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) (ร่วมกับย่อหน้าเริ่มต้น ทำให้มีสามย่อหน้า)
1. สำหรับแต่ละย่อหน้า สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) สามอันและเพิ่มลงในคอลเลกชัน Portion ของย่อนนั้น
1. ตั้งค่าข้อความสำหรับแต่ละ Portion
1. ใช้การจัดรูปแบบที่ต้องการกับแต่ละ Portion ผ่านคุณสมบัติของ [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/)
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ด Python ด้านล่างทำตามขั้นตอนเหล่านี้:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอ็อบเจ็กต์ Presentation เพื่อสร้างไฟล์ PPTX ใหม่.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape แบบสี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # เข้าถึง TextFrame ของ AutoShape.
    text_frame = shape.text_frame

    # สร้างย่อหน้าและ Portion; การจัดรูปแบบจะถูกกำหนดต่อไปด้านล่าง.
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

    # บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการ Bullet ของย่อหน้า**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มี Bullet มักอ่านและเข้าใจได้ง่ายกว่า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/)
1. ตั้งค่าชนิด Bullet ของย่อหน้าเป็น `SYMBOL` และระบุอักขระ Bullet
1. ตั้งค่าข้อความของย่อหน้า
1. ตั้งค่าการเยื้องของ Bullet สำหรับย่อหน้า
1. ตั้งค่าสีของ Bullet
1. ตั้งค่าขนาด (ความสูง) ของ Bullet
1. เพิ่มย่อหน้าไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอน 7 – 12
1. บันทึกพรีเซนเทชัน

โค้ด Python ด้านล่างแสดงวิธีการเพิ่มย่อหน้าที่มี Bullet:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ Presentation.
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

    # กำหนดรูปแบบ Bullet ของย่อหน้าและสัญลักษณ์.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # กำหนดข้อความย่อหน้า.
    paragraph.text = "Welcome to Aspose.Slides"

    # กำหนดการเยื้องของ Bullet.
    paragraph.paragraph_format.indent = 25

    # กำหนดสีของ Bullet.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # กำหนดความสูงของ Bullet.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph)

    # สร้างย่อหน้าที่สอง.
    paragraph2 = slides.Paragraph()

    # กำหนดประเภทและสไตล์ Bullet ของย่อหน้า.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # กำหนดข้อความย่อหน้า.
    paragraph2.text = "This is numbered bullet"

    # กำหนดการเยื้องของ Bullet.
    paragraph2.paragraph_format.indent = 25

    # กำหนดสีของ Bullet.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # กำหนดความสูงของ Bullet.
    paragraph2.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph2)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการ Picture Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Picture Bullet อ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/)
1. โหลดภาพเข้าไปใน [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/)
1. ตั้งค่าชนิด Bullet เป็น [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) และกำหนดภาพ
1. ตั้งค่าข้อความของย่อหน้า
1. ตั้งค่าการเยื้องของ Bullet สำหรับย่อหน้า
1. ตั้งค่าสีของ Bullet
1. ตั้งค่าความสูงของ Bullet
1. เพิ่มย่อหน้าใหม่ไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอน 8 – 12
1. บันทึกพรีเซนเทชัน

โค้ด Python ด้านล่างแสดงวิธีการเพิ่มและจัดการ Picture Bullet:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # โหลดภาพ Bullet.
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

    # กำหนดประเภท Bullet ของย่อหน้าเป็นรูปภาพและกำหนดภาพ.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # กำหนดความสูงของ Bullet.
    paragraph.paragraph_format.bullet.height = 100

    # เพิ่มย่อหน้าไปยัง TextFrame.
    text_frame.paragraphs.add(paragraph)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # บันทึกงานนำเสนอเป็นไฟล์ PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **จัดการ Multilevel Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Multilevel Bullet อ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์
1. เข้าถึง [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดระดับความลึกเป็น 0
1. สร้างย่อหน้าที่สองโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดระดับความลึกเป็น 1
1. สร้างย่อหน้าที่สามโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดระดับความลึกเป็น 2
1. สร้างย่อหน้าที่สี่โดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) และกำหนดระดับความลึกเป็น 3
1. เพิ่มย่อหน้าใหม่เหล่านี้ไปยังคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. บันทึกพรีเซนเทชัน

โค้ด Python ด้านล่างแสดงวิธีการเพิ่มและจัดการ Multilevel Bullet:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ Presentation.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]
    
    # เพิ่ม AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = auto_shape.text_frame
    
    # ลบย่อหน้าเริ่มต้น.
    text_frame.paragraphs.clear()

    # เพิ่มย่อหน้าแรก.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับ Bullet.
    paragraph1.paragraph_format.depth = 0

    # เพิ่มย่อหน้าที่สอง.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับ Bullet.
    paragraph2.paragraph_format.depth = 1

    # เพิ่มย่อหน้าที่สาม.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับ Bullet.
    paragraph3.paragraph_format.depth = 2

    # เพิ่มย่อหน้าที่สี่.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # กำหนดระดับ Bullet.
    paragraph4.paragraph_format.depth = 3

    # เพิ่มย่อหน้าเหล่านั้นเข้าสู่คอลเลกชัน.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการย่อหน้าด้วยรายการเลขกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/bulletformat/) มีคุณสมบัติ `numbered_bullet_start_with` (และอื่น ๆ) เพื่อควบคุมการกำหนดเลขและการจัดรูปแบบแบบกำหนดเองสำหรับย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์ที่จะบรรจุย่อหน้า
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) แรกและตั้งค่า `numbered_bullet_start_with` เป็น 2
1. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) ที่สองและตั้งค่า `numbered_bullet_start_with` เป็น 3
1. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) ที่สามและตั้งค่า `numbered_bullet_start_with` เป็น 7
1. เพิ่มย่อหน้าเหล่านี้ไปยังคอลเลกชันของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. บันทึกพรีเซนเทชัน

โค้ด Python ด้านล่างสาธิตวิธีการเพิ่มและจัดการย่อหน้าที่มีการกำหนดเลขแบบกำหนดเอง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # เพิ่มและเข้าถึง AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # เข้าถึง TextFrame ของ AutoShape ที่สร้าง.
    text_frame = shape.text_frame

    # ลบย่อหน้าเริ่มต้นที่มีอยู่.
    text_frame.paragraphs.remove_at(0)

    # สร้างรายการเลขลำดับแรก (เริ่มที่ 2, ระดับความลึก 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # สร้างรายการเลขลำดับที่สอง (เริ่มที่ 3, ระดับความลึก 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # สร้างรายการเลขลำดับที่สาม (เริ่มที่ 7, ระดับความลึก 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่า First-Line Indent สำหรับย่อหน้า**

ใช้คุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า คุณสมบัตินี้จะย้ายเฉพาะบรรทัดแรกเปรียบเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงตำแหน่งเดิม

ใช้ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างย่อหน้าหลายอันและกำหนดค่าต่าง ๆ ของ `indent` เพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางของย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างเปล่าให้กับรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าหลายอันและกำหนดค่า [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ที่แตกต่างกันให้กับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ
7. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องของย่อหน้า:

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

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่า Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือรูปแบบการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วยคุณสมบัติ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) ตั้งค่า `indent` เป็นค่าลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปกติ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้าและ [ParagraphFormat.indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ margin ดังนั้นการสร้าง Hanging Indent ต้องตั้งค่า `margin_left` เป็นบวกและ `indent` เป็นลบ

การจัดรูปแบบนี้เป็นประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม และย่อหน้าอื่น ๆ ที่บรรทัดที่ตัดต่อควรจัดชิดกับเนื้อหาย่อหน้าแทนที่บรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ว่างเปล่าให้กับรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า [margin_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/margin_left/) เป็นค่าบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [indent](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/indent/) เป็นค่าลบเพื่อสร้างเอฟเฟ็กต์ Hanging Indent
7. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ
8. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Hanging Indent สำหรับย่อหน้า:

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

ผลลัพธ์:

![การเยื้องแบบ Hanging ของย่อหน้า](hanging_indent.png)

## **จัดการรูปแบบ Portion ที่ส่วนท้ายของย่อหน้า**

เมื่อคุณต้องการควบคุมการจัดรูปแบบของ “ส่วนท้าย” ของย่อหน้า (รูปแบบที่ใช้หลัง Portion สุดท้าย) ให้ใช้คุณสมบัติ `end_paragraph_portion_format` ตัวอย่างด้านล่างตั้งค่าแบบอักษร Times New Roman ขนาดใหญ่ให้กับส่วนท้ายของย่อหน้าที่สอง

1. สร้างหรือเปิดไฟล์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับสไลด์เป้าหมายโดยใช้ดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
1. ใช้ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่างและสร้างย่อหน้าสองอัน
1. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) ตั้งค่าเป็น Times New Roman ขนาด 48 pt แล้วนำไปใช้เป็นรูปแบบ Portion ส่วนท้ายของย่อหน้า
1. กำหนดให้กับ `end_paragraph_portion_format` ของย่อหน้า (ใช้กับส่วนท้ายของย่อหน้าที่สอง)
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Python ด้านล่างแสดงวิธีตั้งค่าการจัดรูปแบบส่วนท้ายของย่อหน้าสำหรับย่อหน้าที่สอง:

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

## **นำเข้า HTML Text ลงในย่อหน้า**

Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการนำเข้า HTML Text ลงในย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เข้าถึงสไลด์เป้าหมายโดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ไปยังสไลด์
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)
1. ลบย่อหน้าเริ่มต้นออกจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. อ่านไฟล์ HTML ต้นทาง
1. สร้างย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/)
1. เพิ่มเนื้อหา HTML ลงในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ด Python ด้านล่างทำตามขั้นตอนเหล่านี้เพื่อนำเข้า HTML Text ลงในย่อหน้า:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ Presentation ว่างเปล่า.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรกของพรีเซนเทชัน.
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

    # บันทึกพรีเซนเทชัน.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการส่งออกข้อความเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดพรีเซนเทชันเป้าหมาย
1. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
1. เลือกรูปทรงที่บรรจุข้อความที่ต้องการส่งออก
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปทรง
1. เปิดสตรีมไฟล์เพื่อเขียนผลลัพธ์เป็น HTML
1. ระบุดัชนีเริ่มต้นและส่งออกย่อหน้าที่ต้องการ

ตัวอย่าง Python นี้แสดงวิธีส่งออกข้อความย่อหน้าเป็น HTML:

```python
import aspose.slides as slides

# โหลดไฟล์พรีเซนเทชัน.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # เข้าถึงสไลด์แรกของพรีเซนเทชัน.
    slide = presentation.slides[0]

    # ดัชนีรูปร่างเป้าหมาย.
    index = 0

    # เข้าถึงรูปร่างโดยใช้ดัชนี.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุตำแหน่งเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่ต้องการส่งออก.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจตัวอย่างสองตัวอย่างที่แสดงวิธีบันทึกย่อข้อความ ซึ่งเป็นอินสแตนซ์ของคลาส [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) เป็นภาพ ตัวอย่างทั้งสองใช้วิธีการดึงภาพของรูปร่างที่บรรจุย่อหน้าผ่านเมธอด `get_image` ของคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) คำนวณขอบเขตของย่อหน้าในรูปร่าง และส่งออกเป็นภาพบิตแมป วิธีเหล่านี้ช่วยให้คุณสกัดส่วนของข้อความจากพรีเซนเทชัน PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์สำหรับการใช้งานต่อในหลายสถานการณ์

สมมติว่าเรามีพรีเซนเทชันไฟล์ชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่าง 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ เราจะดึงภาพของรูปร่างจากสไลด์แรกของพรีเซนเทชันแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่างนั้น จากนั้นวาดย่อหน้านั้นลงบนบิตแมปใหม่แล้วบันทึกเป็น PNG วิธีนี้เหมาะเมื่อคุณต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยรักษาขนาดและการจัดรูปแบบเดิม

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # บันทึกรูปร่างในหน่วยความจำเป็นบิตแมป.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # สร้างบิตแมปของรูปร่างจากหน่วยความจำ.
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

    # ตัดบิตแมปของรูปร่างเพื่อให้ได้บิตแมปของย่อหน้าเท่านั้น.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่าง 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงจากพรีเซนเทชันและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าถูกคำนวณโดยคำนึงถึงสเกล การสเกลมีประโยชน์เมื่อต้องการภาพที่รายละเอียดสูง เช่น ในสื่อสิ่งพิมพ์คุณภาพสูง

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # บันทึกรูปร่างในหน่วยความจำเป็นบิตแมป.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # สร้างบิตแมปของรูปร่างจากหน่วยความจำ.
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

    # ตัดบิตแมปของรูปร่างเพื่อให้ได้บิตแมปของย่อหน้าเท่านั้น.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**สามารถปิดการตัดบรรทัดอัตโนมัติภายใน TextFrame ได้หรือไม่?**

ได้ — ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/)) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่ตัดที่ขอบของกรอบ

**ทำอย่างไรจึงจะได้ขอบเขตบนสไลด์ของย่อหน้าเฉพาะ?**

คุณสามารถดึงสี่เหลี่ยมเว้นขอบของย่อหน้า (หรือตำแหน่งของ Portion เดียว) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**ตำแหน่งการจัดข้อความของย่อหน้า (ซ้าย/ขวา/กลาง/ชิดขอบ) ควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/) ซึ่งส่งผลกับทั้งย่อหน้าโดยไม่คำนึงถึงรูปแบบของ Portion แต่ละอัน

**สามารถตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนหนึ่งของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?**

ได้ — ภาษาถูกตั้งค่าที่ระดับ Portion ([PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/)) ทำให้สามารถใช้หลายภาษาในย่อหน้าเดียวได้