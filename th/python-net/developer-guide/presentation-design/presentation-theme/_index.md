---
title: จัดการธีมการนำเสนอ PowerPoint ใน Python
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/python-net/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- กำหนดธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี ฟอนต์ รูปแบบพื้นหลัง การเติม สีเส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงการกำหนดร่วมเหล่านี้แทนการเก็บคุณสมบัติวิสัยทั้งหมดเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถปรับหลายวัตถุพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) อีกทั้งการนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่า มาสเตอร์สามารถเขียนทับธีมการนำเสนอผ่าน [MasterThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/masterthememanager/override_theme/), เลย์เอาต์สามารถเขียนทับธีมที่สืบทอดได้ผ่าน [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), และสไลด์แต่ละสไลด์ก็ทำเช่นเดียวกัน ในทางปฏิบัติ ธีมที่ใช้จริงสำหรับสไลด์จะถูกแก้ไขผ่านลำดับการสืบทอดนี้: ธีมการนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบมากที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับถูกแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/) เปิดเผยคุณสมบัติของธีม ได้แก่ [color_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/font_scheme/), และ [format_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/format_scheme/) การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงนั้นมีประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าเพิกเฉยว่าทุกสไลด์มีธีมที่เท่ากัน ให้ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้กระบวนการทำงานกับธีมที่มีผลตามที่แสดงต่อไปนี้เมื่ออาจมีการเขียนทับจากเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) ของธีม วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้ทำการสร้างรูปร่างที่ใช้ `ACCENT4`, เปลี่ยนสี `accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, แล้วพิมพ์สีเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมต่อกับ `ACCENT4` สีที่มองเห็นจึงเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันอ่อนและเข้มของสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/python-net/aspose.slides/colortransformoperation/)

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - เวอร์ชันอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อิงจาก `ACCENT4`, ใช้การแปลงความสว่างกับห้ารูป แล้วบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่าของ `accent4` ที่ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) ใช้ `TEXT1`, `BACKGROUND1`, `TEXT2`, และ `BACKGROUND2` ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `dark1`, `light1`, `dark2`, และ `light2` การแมปนี้คงที่:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งแบบไดนามิก

## **เปลี่ยนฟอนต์ธีม**

สกีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความทั่วไป คุณสมบัติ [FontScheme.major](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.minor](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความ:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้ฟอนต์หลักและข้อความทั่วไปจะใช้ฟอนต์รอง ข้อความที่กำหนดชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่เปลี่ยนโดยอัตโนมัติเมื่อสกีมฟอนต์ธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองยังสามารถมีการแมปฟอนต์สำหรับระบบเขียนแต่ละระบบ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/python-net/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/python-net/powerpoint-fonts/)

{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานที่พบบ่อยและแก้ไขปัญหาที่แตกต่างกัน

### **คงธีมต้นฉบับเมื่อนำสไลด์ไปยังการนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและคงการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับลงในเป้าหมายด้วย [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/), แล้วโคลนสไลด์ด้วย [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) และมาสเตอร์ที่โคลนไว้ สิ่งนี้จะพามาสเตอร์, เลย์เอาต์, และธีมที่เชื่อมโยงมาด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องอยู่บนมาสเตอร์และเลย์เอาต์เดิม ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ วิธี `OverrideTheme.init_color_scheme_from`, `OverrideTheme.init_font_scheme_from`, และ `OverrideTheme.init_format_scheme_from` จะคัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การเขียนทับ

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

วิธีนี้จะเปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอด หากต้องการลบการเขียนทับท้องถิ่นและกลับสู่ค่าที่สืบทอด ให้เรียก `OverrideTheme.clear`

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น เว้นแต่สไลด์ใดมีการเขียนทับของตนเอง วิธีเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/layoutslidethememanager/) ของเลย์เอาต์ได้:

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรแชร์การออกแบบพื้นฐานเดียวกัน ใช้การเขียนทับระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์หนึ่งต้องการสไตล์ที่ต่างออกไป และใช้การเขียนทับระดับสไลด์เฉพาะกรณีพิเศษเท่านั้น การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดเติมที่จัดเก็บจริงในคอลเลกชันนี้ เนื่องจาก UI สามารถผสมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและคุณสมบัติ [Background.style_index](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/style_index/) ปัจจุบัน `style_index` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าเป็นบวกหมายถึงการอ้างอิงสไตล์พื้นหลังของธีม นี้แตกต่างจากการทำดัชนีคอลเลกชันของ Python โดยตรงที่ `[0]` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์เติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, แล้วบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่อาจมีที่เลย์เอาต์หรือระดับสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์เพียงอย่างเดียวอาจไม่ได้เปลี่ยนสไลด์นั้น ใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) เมื่อต้องการทราบพื้นหลังสุดท้ายหลังจากสืบทอดแล้ว

{{% alert color="warning" title="Warning" %}}

อย่าเข้าใจ `style_index` เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ และห้ามกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วคาดว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นลักษณะเฉพาะของการนำเสนอแต่ละไฟล์

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/python-net/presentation-background/)

{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเลกชันแยกต่างหากสำหรับ [FormatScheme.fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/line_styles/), และ [FormatScheme.effect_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/effect_styles/) โดยทั่วไปธีม Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบที่ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Python ดัชนีของคอลเลกชันเริ่มจาก 0: `[0]` คือสไตล์แรกที่จัดเก็บและ `[2]` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก ที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่ใช้การจัดรูปแบบโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกด้วยระยะ 10 จุด ผลลัพธ์ที่เห็นยังคงขึ้นอยู่กับว่ารูปร่างแต่ละอันอ้างอิงช่องใดและการจัดรูปแบบโดยตรงอาจเขียนทับธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกคุณว่าอะไรถูกกำหนดไว้ที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าหนังสือหรือรูปร่างใช้จริงหลังจากแก้ไขการสืบทอดและการเขียนทับแล้ว สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับพื้นหลังใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) และสำหรับการเติมใช้ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปร่างแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวิเคราะห์การเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเพียง [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปร่างที่เปลี่ยนลappearanceสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดี่ยวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นธีมที่เขียนทับ การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นยังคงสืบทอดธีมเดิมต่อไป

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และคงลักษณะของต้นฉบับ ให้โคลนมาสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/) และ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับสไลด์หรือธีมเลย์เอาต์และใช้เมธอดข้อมูลที่มีผลที่สอดคล้องกันสำหรับอ็อบเจ็กต์ฟอร์แมต เช่น [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) และ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำไปใช้