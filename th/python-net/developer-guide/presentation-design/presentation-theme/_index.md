---
title: จัดการธีมงานนำเสนอ PowerPoint ใน Python
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/python-net/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมงานนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการธีมงานนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี ฟอนต์ สไตล์พื้นหลัง การเติม สีเส้น และเอฟเฟกต์ที่สอดประสานกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณสมบัติภาพแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลาย ๆ ตัวพร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) งานนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่าได้ มาสเตอร์สามารถเขียนทับธีมงานนำเสนอผ่าน [MasterThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/masterthememanager/override_theme/), เลย์เอาต์สามารถเขียนทับธีมที่สืบทอดผ่าน [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), และสไลด์แต่ละสไลด์ก็สามารถทำเช่นเดียวกันได้ ในการปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกกำหนดผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้จะแสดงขั้นตอนทำงานที่พบบ่อยเกี่ยวกับธีม: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/) เปิดเผยคุณสมบัติ [color_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/font_scheme/), และ [format_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/format_scheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่องานนำมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่เก็บไว้ในธีม:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

หากไฟล์ใช้มาสเตอร์หลายชุด อย่านับทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้ขั้นตอนทำงานธีมที่มีผลที่แสดงต่อไปในบทความนี้เมื่ออาจมีการเขียนทับที่เลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) ของธีม วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับค่าที่อัปเดตใหม่ วัตถุที่ใช้สี RGB ตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้ทำงานตั้งแต่ต้นจนจบ: สร้างรูปร่างที่ใช้ `ACCENT4`, เปลี่ยนสี `accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `ACCENT4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณเปลี่ยนสีสกีมเป็นสีตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเฉดสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/python-net/aspose.slides/colortransformoperation/)

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – เฉดสีอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างหกสี่เหลี่ยมอิงจาก `ACCENT4`, ใช้การแปลงความสว่างกับห้าตัว และบันทึกผลลัพธ์:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

เฉพาะสีเหล่านี้ยังคงอิงจากสีธีม หาก `accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะคำนวนใหม่จากค่า `accent4` ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) ใช้ `TEXT1`, `BACKGROUND1`, `TEXT2`, และ `BACKGROUND2` ส่วน [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) เปิดเผยช่องของธีมเดียวกันเป็น `dark1`, `light1`, `dark2`, และ `light2` การแมพคงที่ดังนี้:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

เหล่านี้เป็นชื่ออื่นของช่องธีมเดียวกัน; ไม่ใช่ค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สกีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความหลัก คุณสมบัติ [FontScheme.major](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.minor](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` – ฟอนต์ลาตินของข้อความหลัก (Minor Latin Font)
* `+mj-lt` – ฟอนต์ลาตินของหัวเรื่อง (Major Latin Font)
* `+mn-ea` – ฟอนต์เอเชียตะวันออกของข้อความหลัก (Minor East Asian Font)
* `+mj-ea` – ฟอนต์เอเชียตะวันออกของหัวเรื่อง (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องที่ใช้ฟอนต์ลาตินหลักและบรรทัดข้อความหลักที่ใช้ฟอนต์ลาตินรอง จากนั้นเปลี่ยนฟอนต์ของธีมและบันทึกผลลัพธ์:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

หัวเรื่องอิงตามฟอนต์หลักและข้อความหลักอิงตามฟอนต์รอง ข้อความที่กำหนดชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติกับการเปลี่ยนสกีมฟอนต์ของธีม

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/python-net/powerpoint-fonts/) 
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีขั้นตอนทำงานทั่วไปสองแบบ ซึ่งแก้ไขปัญหาที่แตกต่างกัน

### **เก็บธีมต้นฉบับเมื่อนำสไลด์ไปย้าย**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับลงในงานนำหมายปลายทางด้วย [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/), แล้วโคลนสไลด์ด้วย [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) พร้อมมาสเตอร์ที่โคลนไว้ วิธีนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไปด้วย

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

นี่เป็นขั้นตอนทำงานที่แนะนำเมื่อสไลด์ต้นฉบับต้องแสดงผลเหมือนเดิมในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ วิธี [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), และ [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การเขียนทับ

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

วิธีนี้จะเปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น ๆ หากต้องการลบการเขียนทับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น เว้นแต่สไลด์บางสไลด์จะมีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/layoutslidethememanager/) ของเลย์เอาต์ได้:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อต้องการให้หลายเลย์เอาต์และสไลด์ใช้การออกแบบฐานเดียวกัน ใช้การเขียนทับเลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่ต่างออกไป และใช้การเขียนทับสไลด์เฉพาะเมื่อมีข้อยกเว้นจริง การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังทำนายยากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมเก็บไว้ใน [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าใน UI เพราะ UI สามารถรวมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บไว้และค่าปัจจุบันของ [Background.style_index](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/style_index/) `style_index` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกหมายถึงการอ้างอิงสไตล์พื้นหลังของธีม นี้ต่างจากการทำดัชนีคอลเลกชัน Python โดยตรงที่ `[0]` หมายถึงรายการแรก อย่านับว่าทุกงานนำเสนอมีจำนวนสไตล์เติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่พร้อมใช้งาน, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์ที่มองเห็นจะขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่เลย์เอ็ตหรือสไลด์ระดับ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เพียงอย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น ใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) เมื่อคุณต้องการรู้พื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="คำเตือน" %}}
อย่าใช้ `style_index` เป็นดัชนีคอลเลกชันที่นับตั้งแต่ศูนย์ นอกจากนี้ควรหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งและคาดว่ามันจะมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นแบบเจาะจ้างานนำเสนอ 
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/python-net/presentation-background/) 
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเลกชันแยกกันสำหรับ [FormatScheme.fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/line_styles/), และ [FormatScheme.effect_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/effect_styles/) ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Python ดัชนีของคอลเลกชันเริ่มจากศูนย์: `[0]` คือสไตล์แรกที่เก็บไว้และ `[2]` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจคงไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกโดยมีระยะ 10 จุด ผลลัพธ์ภาพสุดท้ายยังคงขึ้นกับแต่ละรูปร่างอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงเขียนทับธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกว่ามีการกำหนดอะไรไว้ที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าสไลด์หรือรูปร่างใช้ค่าอะไรจริง ๆ หลังจากการสืบทอดและการเขียนทับในระดับท้องถิ่นได้ถูกแก้ไขแล้ว สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับพื้นหลังให้ใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) และสำหรับการเติมให้ใช้ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปแบบแรกจากสไลด์หนึ่ง:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีม การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการยกธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อนำสไลด์ไปและต้องการรักษาลักษณะต้นฉบับ ให้โคลนมาสเตอร์ต้นฉบับเข้าสู่ปลายทางและโคลนสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/) และ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับสไลด์หรือธีมเลย์เอาต์และใช้เมธอดข้อมูลที่มีผลที่สอดคล้องกันสำหรับอ็อบเจกต์ฟอร์แมต เช่น [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) และ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำมาใช้