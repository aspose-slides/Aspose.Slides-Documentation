---
title: จัดการธีมการนำเสน PowerPoint ใน Python
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
- ธีมนอก
- THMX
- สีธีม
- พาเล็ตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้าง, ปรับแต่งและแปลงไฟล์ PowerPoint ด้วยแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, รูปแบบพื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ประสานกัน ธีมที่รับรู้วัตถุจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณลักษณะภาพทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตหลายวัตถุพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) ธีมยังสามารถถูกแทนที่ได้ในระดับที่ต่ำกว่า มาสเตอร์สามารถแทนที่ธีมการนำเสนอได้ผ่าน [MasterThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/masterthememanager/override_theme/), เลย์เอาต์สามารถแทนที่ธีมที่สืบทอดได้ผ่าน [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), และสไลด์แต่ละสไลด์ก็ทำได้เช่นกัน ในทางปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกสรุปผ่านสายการสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, ตัวอักษร, รูปแบบพื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบมากที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตรูปแบบพื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่เสร็จสมบูรณ์

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/) เปิดเผย [color_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/font_scheme/), และ [format_scheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/mastertheme/format_scheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ถูกเก็บไว้ในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าสมมติว่าสไลด์ทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้ขั้นตอนการทำงานกับธีมที่มีผลตามที่อธิบายต่อไปนี้เมื่อมีการแทนที่ของเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจากการนับเป็น [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) ของธีม วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `ACCENT4`, เปลี่ยนสี `accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่, และพิมพ์สีเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `ACCENT4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณแทนที่สีสกินด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อ ๆ ไปของ `accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่านการนับเป็น [ColorTransformOperation](https://reference.aspose.com/slides/th/python-net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีที่อ่อนและเข้มที่สร้างจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีที่อ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `ACCENT4`, ทำการแปลงความสว่างบนห้ารูป, และบันทึกผลลัพธ์:

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

ตัวแปรเหล่านี้ยังคงอิงจากสีธีม หาก `accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

การนับเป็น [SchemeColor](https://reference.aspose.com/slides/th/python-net/aspose.slides/schemecolor/) ใช้ `TEXT1`, `BACKGROUND1`, `TEXT2`, และ `BACKGROUND2` ขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `dark1`, `light1`, `dark2`, และ `light2` การแมปคงที่ดังนี้:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่งโดยไดนามิก

## **เปลี่ยนแบบอักษรธีม**

สคีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความส่วนเนื้อหา คุณสมบัติ [FontScheme.major](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.minor](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรเนื้อหา Latin (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* `+mn-ea` - แบบอักษรเนื้อหา East Asian (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้แบบอักษรหลักและข้อความหลักจะใช้แบบอักษรรอง ข้อความที่กำหนดแบบอักษรอย่างชัดเจนแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสคีมแบบอักษรธีมเปลี่ยน

สคีมแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบเขียนแยกต่างหาก เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อทำการตรวจสอบ, เพิ่ม, แทนที่ หรือเอาออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/python-net/script-specific-font-mappings/)

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/python-net/powerpoint-fonts/) 
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

ขั้นตอนต่อไปนี้แก้ปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่อิงมาสเตอร์**

ใช้ [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) เมือคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการรีสไตล์ทุกสไลด์ที่อิงกับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation.masters](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/masters/) ซึ่งเป็น [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) และส่งพาธไฟล์ธีมให้เมธอด

เมธอดทำงานดังต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยอิงมาสเตอร์ที่เลือก
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterslide/)

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่อิงกับมาสเตอร์แรกและบันทึกการนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxexception/) หรือคลาสย่อยที่เกี่ยวกับรูปแบบ ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการกับความล้มเหลวของการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอหลังจากธีมถูกใช้เรียบร้อยแล้ว

เฉพาะสไลด์ที่อิงมาสเตอร์ที่เลือกเท่านั้นจะถูกกำหนดใหม่ สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิม สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, แบบอักษร, การเติม และการจัดรูปแบบที่กำหนดโดยตรงอาจคงเดิม การแทนที่ระดับเลย์เอาต์และระดับสไลด์ยังอาจครองลำดับเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมรันไทม์ สำหรับการเรนเดอร์และการส่งออกที่สม่ำเสมอ ให้ติดตั้งแบบอักษรที่ต้องการ, จัดหาแบบอักษรผ่าน [custom font sources](/slides/th/python-net/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/python-net/font-substitution/)

นี่เป็นขั้นตอนระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่จำเป็นต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกหลายธีมในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่ต้องการไม่ทราบล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์ตัวอย่างผ่าน [Slide.layout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/layout_slide/) และ [LayoutSlide.master_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/master_slide/) เก็บอ้างอิงมาสเตอร์เดิมก่อนใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหามาสเตอร์และใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกส่งผลต่อสไลด์ที่อิงกับ `first_group_master` เท่านั้น, การเรียกครั้งที่สองส่งผลต่อสไลด์ที่อิงกับ `second_group_master` เท่านั้น สไลด์ที่อ้างอิงมาสเตอร์อื่นจะไม่ถูกรีสไตล์

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำหน้าเป้าหมายด้วย [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/), แล้วคัดลอกสไลด์ด้วย [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะนำมาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องมาด้วย

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

นี่เป็นขั้นตอนที่แนะนำเมื่อต้องการให้สไลด์ต้นฉบับดูเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงมาสเตอร์และเลย์เอาต์เดิม ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), และ [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) จะคัดลอกสามองค์ประกอบหลักของธีมเข้าสู่การแทนที่

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

วิธีนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่เปลี่ยนธีมที่สืบทอดจากสไลด์อื่น ๆ หากต้องการลบการแทนที่ระดับท้องถิ่นและคืนค่าเป็นค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น เว้นแต่สไลด์บางสไลด์มีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/layoutslidethememanager/) ของเลย์เอาต์

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการการออกแบบฐานร่วมกัน ใช้การแทนที่เลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง และใช้การแทนที่สไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมโดยรวมในภายหลังคาดเดาได้ยาก

## **อัปเดตรูปแบบพื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าที่เก็บไว้จริงในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.style_index](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/style_index/) ปัจจุบัน `style_index` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกเป็นอ้างอิงสไตล์พื้นหลังของธีม นี่แตกต่างจากการใช้ดัชนีของคอลเลกชัน Python โดยตรงที่ `[0]` หมายถึงรายการแรกที่เก็บ อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังที่มีธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นจะขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่ระดับเลย์เอ็ตหรือสไลด์ หากสไลด์มีพื้นหลังของตนเอง การเปลี่ยนเฉพาะพื้นหลังของมาสเตอร์อาจไม่กระทบสไลด์นั้น ใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="คำเตือน" %}}
อย่าเทียบ `style_index` กับดัชนีคอลเลกชันแบบศูนย์ฐาน นอกจากนี้หลีกเลี่ยงการกำหนดเลขสไตล์แบบคงที่จากไฟล์หนึ่งและสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; นิยามสไตล์ธีมเป็นลักษณะเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/python-net/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สคีมรูปแบบของธีมประกอบด้วยคอลเลกชันแยกของ [FormatScheme.fill_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/line_styles/), และ [FormatScheme.effect_styles](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/formatscheme/effect_styles/) โดยทั่วไปธีมของ Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับรูปแบบ Subtle, Moderate, และ Intense อย่างไรก็ตามโค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติจำนวนคงที่

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Python ดัชนีคอลเลกชันเริ่มจาก 0: `[0]` คือสไตล์แรกที่เก็บและ `[2]` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/python-net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงอยู่โดยไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงาภายนอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะกลายเป็นสีเขียวป่าแซม, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงาภายนอกกับระยะ 10 จุด ผลลัพธ์ที่แน่นอนยังคงขึ้นกับสไตล์ที่แต่ละรูปทรงอ้างอิงและว่าการจัดรูปแบบโดยตรงจะครอบคลุมธีมหรือไม่

![สไตล์เอฟเฟกต์ธีมหลังจากเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าใดจริงหลังจากสืบทอดและการแทนที่ในพื้นที่เสร็จสมบูรณ์ สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับพื้นหลัง ใช้ [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/), และสำหรับการเติม ใช้ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปทรงแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.master_theme](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/master_theme/) คุณอาจพลาดการแทนที่ของมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย

## **FAQ**

**การใช้ธีมภายนอกจะกระทบต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) จะกำหนดสไลด์ที่อิงมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีมของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นจะยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/add_clone/) และ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) สำหรับธีมสไลด์หรือเลย์เอ็ตและใช้เมธอดข้อมูลที่มีผลที่สอดคล้องกันสำหรับอ็อบเจกต์รูปแบบ เช่น [Background.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/background/get_effective/) และ [FillFormat.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/get_effective/) API เหล่านี้จะคืนค่าที่สรุปหลังจากการสืบทอดและการแทนที่เรียบร้อยแล้ว