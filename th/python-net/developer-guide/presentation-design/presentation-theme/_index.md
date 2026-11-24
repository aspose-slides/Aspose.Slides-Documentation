---
title: จัดการธีมงานนำเสนอ PowerPoint ด้วย Python
linktitle: ธีมงานนำเสนอ
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
- ธีมภายนอก
- THMX
- สีธีม
- พาเล็ตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมธีมงานนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่ทำงานร่วมกัน. วัตถุที่รับรู้ธีมอ้างอิงไปยังคำนิยามที่ใช้ร่วมเหล่านี้แทนการเก็บคุณสมบัติภาพแต่ละอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมจึงสามารถอัพเดตวัตถุปริมาณมากพร้อมกัน.

ใน Aspose.Slides, ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) . งานนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าได้เช่นกัน. Master สามารถแทนที่ธีมงานนำเสนอผ่าน [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), Layout สามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), และสไลด์แต่ละสไลด์ก็ทำเช่นเดียวกัน. โดยปฏิบัติ, ธีมที่มีผลสำหรับสไลด์จะถูกกำหนดผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ, การแทนที่ของ Master, การแทนที่ของ Layout, และการแทนที่ของสไลด์.

![ส่วนประกอบของธีม: สี, ตัวอักษร, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากสืบทอดและการแทนที่ถูกประมวลผลแล้ว.

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) เปิดเผยคุณสมบัติของธีม ได้แก่ [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/), และ [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) . การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อไฟล์งานนำมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานว่ามีสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์เท่าไหร่ที่เก็บไว้ในธีม:

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

หากไฟล์ใช้หลาย master, อย่าสมมติว่าทุกสไลด์มีธีมที่มีผลเดียวกัน. ตรวจสอบ master ที่เชื่อมโยงกับสไลด์, และใช้กระบวนการทำงานของธีมที่มีผลตามที่แสดงต่อไปนี้เมื่ออาจมีการแทนที่ที่ระดับ layout หรือสไลด์.

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจากการนับ [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) . เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) ของธีม, วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกประมวลผลใหม่กับค่าที่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `ACCENT4`, เปลี่ยนสี `accent4` ของธีมเป็นสีแดง, เซฟงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังเชื่อมโยงกับ `ACCENT4`, สีที่แสดงจะกลายเป็นสีแดงหลังจากเปลี่ยนธีม. หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปร่าง, การเปลี่ยนแปลงต่อ ๆ ไปของ `accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างเวอร์ชั่นสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่านการนับ [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) .

![สีธีมหลักและสีที่อ่อนและเข้มที่สร้างจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก.  
**2** - ชุดสีอ่อนและเข้มที่สร้างจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `ACCENT4`, ใส่การแปลงความสว่างให้กับห้ารูป, และบันทึกผลลัพธ์:

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

เวอร์ชั่นเหล่านี้ยังคงอิงจากสีธีม. หาก `accent4` เปลี่ยนในภายหลัง, สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `accent4` ที่ใหม่.

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

การนับ [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) ใช้ `TEXT1`, `BACKGROUND1`, `TEXT2`, และ `BACKGROUND2`, ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) เปิดเผยช่องของธีมเดียวกันเป็น `dark1`, `light1`, `dark2`, และ `light2`. การแมปคงที่ดังนี้:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง.

## **เปลี่ยนแบบอักษรของธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหา. คุณสมบัติ [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น.

ตัวระบุแบบอักษรของธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)
* `+mn-cs` - Body Font Complex Script (Minor Complex Script Font)
* `+mj-cs` - Heading Font Complex Script (Major Complex Script Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้แบบอักษร Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งบรรทัดที่ใช้แบบอักษร Latin รองของธีม. จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะตามตามแบบอักษรหลักและข้อความตามแบบอักษรรอง. ข้อความที่กำหนดชื่อแบบอักษรโดยชัดเจนแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสกีมแบบอักษรของธีมเปลี่ยน.

ชุดแบบอักษรหลักและรองอาจมีการแมปแบบอักษรสำหรับระบบเขียนแต่ละระบบ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. เพื่อดู, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออก, ดูหัวข้อ [Script-Specific Theme Fonts](/slides/th/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรในงานนำเสนอ, ดู [แบบอักษร PowerPoint](/slides/th/python-net/powerpoint-fonts/).
{{% /alert %}}

### **แก้ไขการอ้างอิงแบบอักษรของธีม**

เมื่อทำการตรวจสอบข้อความ, [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) อาจมีการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อแบบอักษร. เรียก [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) พร้อมกับ [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) ที่เหมาะสมเพื่อแก้ไขการอ้างอิงนั้น. คำนำหน้า `+mj` และ `+mn` เลือกชุดแบบอักษรหลักและรอง; คำต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกแบบอักษร Latin, East Asian, และ Complex Script ตามลำดับ.

รับธีมที่มีผลผ่าน [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) บนวัตถุที่ธีมของมันใช้กับข้อความที่ตรวจสอบ. สำหรับข้อความธรรมดาบนสไลด์, ใช้ `slide.create_theme_effective` เพื่อให้บริบทรวมถึงธีมที่สืบทอดของสไลด์นั้นและการแทนที่ในระดับท้องถิ่น. เมื่อทำการตรวจสอบ Layout หรือ Master เอง, ใช้ธีมที่มีผลของมันเอง. อย่าสมมติว่าธีมของ Master แรกใช้กับทุกสไลด์.

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงแบบอักษร Latin รองอย่างชัดเจน. มันเริ่มต้นสกีมแบบอักษรของสไลด์ผ่าน [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) และตั้งค่าแบบอักษร Latin หลักและรองเป็น `Arial` และ `Calibri`, ทำให้ผลลัพธ์สามารถทำซ้ำได้โดยไม่มีไฟล์อินพุต:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana`. การอ้างอิงที่จัดเก็บยังคงไม่เปลี่ยน, ในขณะที่ชื่อแบบอักษรที่ชัดเจนจะถูกส่งกลับตามเดิม. หากส่วนข้อความใช้ `+mj-lt`, มันจะถูกแก้เป็น `Arial` ในธีมนี้.

การแก้ไขการอ้างอิงธีมบอกแบบอักษรที่ธีมระบุ. มันไม่ได้ตรวจสอบว่ามีแบบอักษรนั้นในระบบหรือกำหนดไฟล์แบบอักษรที่ใช้จริงหลังการแทนที่หรือการ fallback ของ glyph ระหว่างการเรนเดอร์. ดูหัวข้อ [Font Selection Sequence](/slides/th/python-net/font-selection-sequence/) และ [Font Substitution](/slides/th/python-net/font-substitution/) สำหรับขั้นตอนแยกเหล่านั้น.

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาที่เกี่ยวกับธีมต่าง ๆ.

### **ใช้ธีมภายนอกกับสไลด์ที่พึ่งพา Master**

ใช้เมธอด [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่พึ่งพา Master เฉพาะ. เลือก Master จากคอลเลกชัน [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)), แล้วส่งพาธไฟล์ธีมให้เมธอด.

เมธอดทำงานดังต่อไปนี้:

1. สร้าง MasterSlide ใหม่โดยอิงจาก Master ที่เลือก
1. ใช้ธีมภายนอกกับ Master ใหม่
1. กำหนด Master ใหม่ให้กับสไลด์ทั้งหมดที่เคยพึ่งพา Master ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่พึ่งพา Master แรกและบันทึกงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) หรือคลาสย่อยที่เกี่ยวกับรูปแบบ. ตรวจสอบพาธที่ผู้ใช้ให้, จัดการข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกงานนำเสนอหลังจากธีมถูกใช้เรียบร้อยแล้ว.

เฉพาะสไลด์ที่พึ่งพา Master ที่เลือกเท่านั้นจะถูกกำหนดใหม่. สไลด์ที่เชื่อมโยงกับ Master อื่นจะคง Master และธีมเดิมไว้. สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟ็กต์ที่รับรู้ธีมจะถูกประมวลผลกับธีมภายนอก. สี, แบบอักษร, การเติม, และการฟอร์แมตที่กำหนดโดยตรงอาจคงเดิม. การแทนที่ในระดับ Layout หรือสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจาก Master ใหม่.

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมรันไทม์. เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง, ให้ติดตั้งแบบอักษรที่จำเป็น, จัดหาแบบอักษรผ่าน [custom font sources](/slides/th/python-net/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/python-net/font-substitution/).

นี่เป็นกระบวนการทำงานโดยตรงระดับ Master: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือ Layout ด้วยตนเอง.

### **ใช้ธีมภายนอกต่าง ๆ ในการนำเสนอที่มีหลาย Master**

เมื่อไม่ทราบ Master ที่เกี่ยวข้องล่วงหน้า, ให้ดึงมาจากสไลด์ตัวอย่างผ่าน [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) และ [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). เก็บอ้างอิง Master ดั้งเดิมไว้ก่อนทำการใช้ธีมใด ๆ เพราะแต่ละครั้งจะสร้าง Master ใหม่ในงานนำเสนอ.

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อตามหา Master ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

การเรียกครั้งแรกมีผลเฉพาะสไลด์ที่พึ่งพา `first_group_master`, ส่วนการเรียกครั้งที่สองมีผลเฉพาะสไลด์ที่พึ่งพา `second_group_master`. สไลด์ที่เชื่อมโยงกับ Master อื่นจะไม่ถูกเปลี่ยนสไตล์.

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม, ให้โคลน Master ต้นฉบับไปยังงานนำหมายด้วย [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), จากนั้นโคลนสไลด์ด้วย [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) พร้อม Master ที่โคลน. วิธีนี้จะคัดลอก Master, Layouts, และธีมที่เกี่ยวข้องทั้งหมดไปด้วยกัน.

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง. การโคลนเนื้อหาไปยัง Master ปลายทางที่ไม่มีความสัมพันธ์อาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟ็กต์ที่ขับโดยธีมเปลี่ยนไป.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงอยู่บน Master และ Layout ปัจจุบัน, เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ. เมธอด [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), และ [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การแทนที่.

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น. เพื่อลบการแทนที่ในระดับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด, ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **ใช้การแทนที่ธีมบน Layout**

การแทนที่ระดับ Layout มีผลต่อสไลด์ที่ใช้ Layout นั้น, ยกเว้นว่ามีการแทนที่เฉพาะสไลด์. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) ของ Layout:

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

ใช้ธีมระดับ Master หรือระดับงานนำเสนอเมื่อหลาย Layout และสไลด์ต้องการใช้การออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับ Layout เมื่อครอบครัวย่อยของ Layout ต้องการสไตล์ที่แตกต่าง, และใช้การแทนที่ระดับสไลด์เฉพาะสำหรับกรณีพิเศษเท่านั้น. การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดาได้ยากขึ้น.

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าที่มีการกำหนดการเติมในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ ได้.

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่เก็บไว้และค่า [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` ใช้ค่า `0` เพื่อไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังธีม. นี้แตกต่างจากการอ้างอิงดัชนีของคอลเลกชัน Python โดยตรงที่ `[0]` หมายถึงรายการแรกที่เก็บไว้. อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน.

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังธีมให้กับ Master แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่ Master อ้างอิงและการแทนที่พื้นหลังที่ระดับ Layout หรือสไลด์. หากสไลด์ใช้พื้นหลังของตัวเอง, การเปลี่ยนพื้นหลังของ Master เพียงอย่างเดียวอาจไม่กระทบสไลด์นั้น. ใช้ [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำมาใช้.

{{% alert color="warning" title="Warning" %}}
อย่าปฏิบัติ `style_index` เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์. อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามันจะมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นลักษณะเฉพาะของงานนำเสนอ.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการฟอร์แมตพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูหัวข้อ [Presentation Background](/slides/th/python-net/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเลกชันแยกต่างหากสำหรับ [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/), และ [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) . ธีมของ Office ส่วนใหญ่มีรายการสไตล์หลักสามรายการที่สอดคล้องกับการฟอร์แมตแบบ Subtle, Moderate, และ Intense, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่.

![เอฟเฟ็กต์ธีมแบบ Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Python, ดัชนีคอลเลกชันเริ่มจาก 0: `[0]` คือสไตล์แรกที่เก็บไว้และ `[2]` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะมีผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีฟอร์แมตโดยตรงอาจคงเดิม.

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้เงาภายนอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้, สไตล์เส้นแรกของธีมจะเป็นสีแดง, สไตล์เติมที่สามของธีมจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงาภายนอกที่ระยะ 10 จุด. ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปร่างแต่ละรูปอ้างอิงช่องใดและว่าฟอร์แมตโดยตรงแทนที่ธีมหรือไม่.

![สไตล์เอฟเฟ็กต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, การเติม, และเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปร่าง**

รูปร่างสามารถเลือกการเติมและขอบได้แยกกันผ่าน [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) และ [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). สำหรับทั้งสองคุณสมบัติ, ดัชนี `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`fill_styles[0]` หรือ `line_styles[0]`), และดัชนี `2` เลือกรายการที่สอง.

ตัวอย่างต่อไปนี้กำหนดการเติมสองแบบ (สีทองและสีฟ้าอากาศ) และเส้นขอบสองแบบ (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่. มันบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลใน PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| สไตล์เริ่มต้น | เปลี่ยนเส้นขอบด้านขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมสีทองและสีฟ้าอากาศที่มีขอบสีฟ้าเข้มบางตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมสีฟ้าอากาศตอนนี้มีขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมซ้ายเป็นสีเขียวและขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนแค่ขอบของสี่เหลี่ยมด้านขวา. การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปร่างที่ใช้มัน. ในตัวอย่างนี้, แค่สี่เหลี่ยมซ้ายเท่านั้นที่เปลี่ยนเป็นสีเขียว.

บนรูปร่างที่มีอยู่, การเติมสี, สีเส้น, หรือความหนาเส้นแบบท้องถิ่นสามารถแทนที่ส่วนของสไตล์ธีมนั้นได้. หากการเปลี่ยนดัชนีสไตล์ไม่มีผลที่มองเห็น, ตรวจสอบ [direct formatting](/slides/th/python-net/shape-formatting/) ของรูปร่าง.

## **กำหนดว่าการเติมแบบทึบที่มีผลใช้สีจากธีมหรือไม่**

การเติมสามารถเก็บโดยตรงบนวัตถุหรือสืบทอดมาจากย่อหน้า, Layout, Master, สไตล์ธีม, หรือระดับฟอร์แมตอื่น. เรียก [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) เพื่อประมวลผลลำดับชั้นนั้นให้เป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) ที่ไม่เปลี่ยนแปลง. ก่อนอื่นตรวจสอบ [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). เมื่อตรวจพบว่าเป็น `FillType.SOLID` เท่านั้นจึงอ่านคุณสมบัติการเติมแบบทึบได้.

สำหรับการเติมแบบทึบ, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) คืนค่ารหัส RGB สุดท้ายหลังจากสืบทอด, การค้นหาธีม, และการแปลงสี. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) คืนช่อง [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) ที่สอดคล้อง, เช่น `TEXT1` หรือ `ACCENT6`. ค่า `SchemeColor.NOT_DEFINED` หมายความว่าการเติมแบบทึบที่มีผลไม่ได้อิงบนสีสคีม. ในงานที่เติมเป็นสีธีมหรือสี RGB โดยตรง, ค่านี้บ่งบอกว่าการเติมเป็น RGB โดยตรง.

ห้ามใช้ค่า [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) ที่เป็นค่าในระดับท้องถิ่นเพียงอย่างเดียวเพื่อจำแนกการเติม. ตัวอย่างเช่น, ส่วนข้อความอาจไม่มีสีสคีมที่กำหนดในระดับท้องถิ่น, ดังนั้นค่าในระดับท้องถิ่นจะเป็น `NOT_DEFINED`, แต่การเติมที่มีผลอาจสืบทอดสีธีมและแสดงเป็น `TEXT1` หรือ `ACCENT6`. กลับกัน, `solid_fill_scheme_color` บอกว่าช่องสคีมใดสร้างสีที่มีผล, แต่ไม่ได้บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, Layout, Master หรือระดับอื่นของลำดับชั้นฟอร์แมต.

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของรูปร่างและส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสคีมที่สัมพันธ์, แล้วทำเครื่องหมายการเติมแบบทึบที่ไม่ติดตามการเปลี่ยนสีธีม:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

สาขา `NOT_DEFINED` ให้รายการตรวจสอบการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม. ตรวจสอบวัตถุเหล่านี้เมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเล็ตแบรนด์ใหม่. ค่ารหัส RGB ที่รายงานยังคงแสดงลักษณะปัจจุบัน, ส่วนค่าช่องสคีมอธิบายว่าการแสดงนั้นเชื่อมต่อกับธีมหรือไม่.

ออบเจ็กต์ที่เป็น snapshot ของฟอร์แมตที่มีผล. หลังจากเปลี่ยนธีมงานนำเสนอ, การแทนที่ธีมหรือฟอร์แมตที่สืบทอดใด ๆ, เรียก `get_effective` อีกครั้งและอ่านออบเจ็กต์ `IFillFormatEffectiveData` ใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี.

## **อ่านค่าธีมที่มีผล**

ออบเจ็กต์ธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง. ค่าที่มีผลบอกว่าสไลด์หรือรูปร่างใช้อะไรจริงหลังจากสืบทอดและการแทนที่ในระดับท้องถิ่นถูกประมวลผลแล้ว. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). สำหรับพื้นหลัง, ใช้ [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), และสำหรับการเติม, ใช้ [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเพียง [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), คุณอาจพลาดการแทนที่ที่ระดับ Master, Layout, Slide, หรือ Shape ที่เปลี่ยนลักษณะสุดท้าย.

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**  
ไม่. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) จะกำหนดสไลด์ใหม่เฉพาะสไลด์ที่พึ่งพา Master ที่เลือก. สไลด์ที่ใช้ Master อื่นจะคงธีมเดิมไว้.

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยน Master ได้หรือไม่?**  
ได้. ใช้เมธอด [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นธีมที่แทนที่. การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิมต่อไป.

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**  
เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ, ให้โคลน Master ต้นฉบับไปยังปลายทางแล้วโคลนสไลด์พร้อม Master นั้นโดยใช้ [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) และ [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). วิธีนี้ทำให้ Master, Layouts, และธีมอยู่ด้วยกัน.

**ฉันจะดูค่าที่มีผลหลังจากสืบทอดและการแทนที่ได้อย่างไร?**  
ใช้ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับธีมของสไลด์หรือ Layout และเมธอดที่ให้ข้อมูลที่มีผลสำหรับออบเจ็กต์ฟอร์แมต เช่น [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) และ [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). API เหล่านี้จะคืนค่าที่ได้จากการสืบทอดและการแทนที่.