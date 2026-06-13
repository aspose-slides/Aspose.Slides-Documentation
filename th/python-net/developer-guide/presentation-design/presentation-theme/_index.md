---
title: จัดการธีมการนำเสนอ PowerPoint ด้วย Python
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/python-net/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมการแบรนด์ที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีม คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติต่าง ๆ ที่สอดคล้องกัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/python-net/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/python-net/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีที่กำหนดสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่พอใจกับค่าเริ่มต้น คุณสามารถเปลี่ยนสีได้โดยการใช้สีธีมใหม่ เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides มีค่าที่ให้ใน enumeration [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/)

โค้ด Python นี้แสดงวิธีเปลี่ยนสีสำเนียงของธีม:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

คุณสามารถกำหนดค่าที่ใช้ได้ของสีที่ได้ดังต่อไปนี้:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# ผลลัพธ์ตัวอย่าง:
#
# ff8086a2 (สี [A=255, R=128, G=100, B=162])
```

เพื่อแสดงการเปลี่ยนสีเพิ่มเติม เราสร้างองค์ประกอบอื่นหนึ่ง กำหนดสีสำเนียงจากขั้นตอนแรก แล้วอัปเดตสีธีม

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติกับทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเล็ตเพิ่ม**

เมื่อคุณปรับการแปลงระดับสว่างให้กับสีธีมหลัก (1) จะสร้างสีจากพาเล็ตเพิ่มเติม (2) คุณจึงสามารถตั้งค่าและดึงสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** — สีธีมหลัก  
**2** — สีจากพาเล็ตเพิ่มเติม

โค้ด Python นี้แสดงวิธีที่สีจากพาเล็ตเพิ่มถูกสรุปจากสีธีมหลักและนำไปใช้ในรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # สีเน้น 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # สีเน้น 4, สว่างขึ้น 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # สีเน้น 4, สว่างขึ้น 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # สีเน้น 4, สว่างขึ้น 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # สีเน้น 4, มืดขึ้น 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # สีเน้น 4, มืดขึ้น 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **แมป `SchemeColor` ไปยังสี `ColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้: `BACKGROUND1`, `BACKGROUND2`, `TEXT1` และ `TEXT2`.

อย่างไรก็ตาม `Presentation.master_theme.color_scheme` คืนค่า [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องเป็น: `dark1`, `dark2`, `light1` และ `light2`.

ความแตกต่างนี้เป็นเพียงในชื่อเท่านั้น ค่เหล่านี้อ้างอิงถึงช่องสีธีมเดียวกันและการแมปคงที่:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `TEXT`/`BACKGROUND` กับ `dark`/`light` พวกมันเป็นเพียงชื่อทางเลือกสำหรับสีธีมเดียวกัน

ความแตกต่างด้านชื่อมาจากคำศัพท์ของ Microsoft Office เวอร์ชันเก่าของ Office ใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วนเวอร์ชัน UI ใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและการใช้งานอื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับใน PowerPoint):

- **+mn-lt** — ฟอนต์ตัวอักษรลาตินสำหรับเนื้อหา (Minor Latin Font)
- **+mj-lt** — ฟอนต์ตัวอักษรลาตินสำหรับหัวข้อ (Major Latin Font)
- **+mn-ea** — ฟอนต์ตัวอักษรเอเชียตะวันออกสำหรับเนื้อหา (Minor East Asian Font)
- **+mj-ea** — ฟอนต์ตัวอักษรเอเชียตะวันออกสำหรับหัวข้อ (Major East Asian Font)

โค้ด Python นี้แสดงวิธีกำหนดฟอนต์ลาตินให้กับองค์ประกอบธีม:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

ตัวอย่าง Python นี้แสดงวิธีเปลี่ยนแบบอักษรธีมของการนำเสนอ:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

กล่องข้อความทั้งหมดจะถูกอัปเดตเป็นฟอนต์ใหม่

{{% alert color="primary" title="TIP" %}}
สำหรับข้อมูลเพิ่มเติม โปรดดูที่ [Master PowerPoint Fonts with Python](/slides/th/python-net/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังของธีม**

โดยค่าเริ่มต้น PowerPoint มีพื้นหลังที่กำหนดไว้ล่วงหน้า 12 แบบ แต่การนำเสนอทั่วไปจะเก็บไว้เพียง 3 แบบเท่านั้น

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากบันทึกการนำเสนอใน PowerPoint คุณสามารถเรียกใช้โค้ด Python ต่อไปนี้เพื่อกำหนดว่ามีพื้นหลังที่กำหนดไว้ล่วงหน้าเท่าไหร่:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
โดยใช้คุณสมบัติ `background_fill_styles` จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint
{{% /alert %}}

ตัวอย่าง Python นี้แสดงวิธีตั้งค่าพื้นหลังของการนำเสนอ:

```python
presentation.masters[0].background.style_index = 2  # 0 หมายถึงไม่มีการเติม; การจัดทำดัชนีเริ่มจาก 1.
```

{{% alert color="primary" title="TIP" %}}
สำหรับข้อมูลเพิ่มเติม โปรดดูที่ [Manage Presentation Backgrounds in Python](/slides/th/python-net/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติจะมีค่า 3 ค่าในแต่ละอาร์เรย์สไตล์ อาร์เรย์เหล่านี้รวมเป็นระดับเอฟเฟกต์ 3 ระดับ: เบา, ปานกลาง, และเข้ม ตัวอย่างเช่น นี่คือตัวอย่างผลลัพธ์เมื่อเอฟเฟกต์เหล่านั้นถูกใช้กับรูปร่างเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้คุณสมบัติสามอย่าง—`FillStyles`, `LineStyles`, และ `EffectStyles`—จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/) คุณสามารถแก้ไของค์ประกอบธีม (ยืดหยุ่นกว่าที่ PowerPoint ทำได้)

โค้ด Python นี้แสดงวิธีเปลี่ยนเอฟเฟกต์ธีมโดยการปรับส่วนต่าง ๆ ขององค์ประกอบเหล่านั้น:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

การเปลี่ยนแปลงที่ได้รวมถึงการอัปเดตสีเติม, ประเภทการเติม, เอฟเฟกต์เงา, และคุณสมบัติอื่น ๆ:

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนแปลงมาสเตอร์ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะท้องถิ่นกับสไลด์นั้นโดยไม่กระทบธีมมาสเตอร์ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

[Clone slides](/slides/th/python-net/clone-slides/) พร้อมกับมาสเตอร์ของมันเข้าสู่การนำเสนอเป้าหมาย วิธีนี้จะรักษามาสเตอร์, เลเอาต์, และธีมที่เชื่อมโยงไว้เดิมไว้ ดังนั้นรูปลักษณ์จึงคงที่

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้ “effective” view ของ API [/slides/th/python-net/shape-effective-properties/] สำหรับธีม/สี/ฟอนต์/เอฟเฟกต์ ค่าที่คืนมาจะเป็นคุณสมบัติที่ได้สรุปและสอดคล้องหลังจากใช้มาสเตอร์พร้อมการแทนที่ระดับท้องถิ่น  