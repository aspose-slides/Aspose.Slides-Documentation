---
title: จัดรูปแบบข้อความในการนำเสนอด้วย Python
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-net/text-formatting/
keywords:
- จัดย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การทำแท็บข้อความ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งแบบอักษร สี การจัดแนว และอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Python ผ่าน .NET. ครอบคลุมสีพื้นหลัง, ความโปร่งใส, การเว้นระยะอักษร, คุณสมบัติของแบบอักษร, การหมุน, การเว้นระยะย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา.

หากไม่มีการระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปทรงแรกบนสไลด์แรกเป็นกล่องข้อความ, และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง. ทั้งดัชนีของสไลด์และรูปทรงเริ่มจากศูนย์. ตัวอย่างที่เลือกส่วนข้อความหนาใช้การจัดรูปแบบที่มีผล, รวมถึงการจัดรูปแบบหนาที่สืบทอด:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือการจับคู่แบบ regular-expression, ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า, หรือใช้ [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างต่อไปนี้ตั้งค่าสีไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก. สีไฮไลต์ที่ระบุโดยตรงในแต่ละส่วนจะมีความสำคัญเหนือค่าดีฟอลต์นี้:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีไฮไลต์สำหรับย่อหน้าทั้งหมด.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) เพื่อตั้งค่าการจัดแนย่อหน้าในกรอบข้อความ. ค่าต่าง ๆ ได้แก่ กึ่งกลาง, จัดซ้าย, จัดขวา, จัดเต็ม, เป็นต้น.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้อยู่ **กึ่งกลาง**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการจัดแนวของย่อหน้าเป็นกึ่งกลาง.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **จัดแนวแบบอักษรภายในบรรทัด**

ใช้ [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) เพื่อจัดแนวแนวดิ่งของส่วนข้อความที่มีขนาดแบบอักษรต่างกันภายในบรรทัด. การตั้งค่านี้ใช้กับย่อหน้าเต็มและควบคุมการจัดแนวภายในแต่ละบรรทัดของมัน.

ตัวอย่างอิสระต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์เดียว. แต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36, และ 54 พอยต์, โดยมีการจัดแนวแบบอักษรที่แตกต่างกัน. ตัวอย่างใช้ Arial, ปิดการทำ autofit และการตัดบรรทัด, และทำให้กรอบข้อความกว้างพอสำหรับหนึ่งบรรทัด.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเปรียบเทียบการจัดแนวแบบอักษร Baseline, Top, Center, และ Bottom กับขนาดแบบอักษรผสม](font_alignment.png)

การจัดแนวแบบอักษรใช้เมตริกของแบบอักษร, ดังนั้นขอบที่มองเห็นของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างสมบูรณ์. ตัวอย่างรวมตัวอักษรพิมพ์ใหญ่และตัวค้ำบังคับเพื่อแสดงความแตกต่างระหว่างการจัดแนว baseline และ bottom. การใช้งานแบบอักษรและการแทนที่, ตัวอักษรที่ใช้, และความแตกต่างของขนาดแบบอักษรมีผลต่อผลลัพธ์. ขนาดกรอบ, ระยะขอบ, ระยะห่างบรรทัด, การบรรจบบรรทัด, และ autofit ก็มีผลต่อการจัดวาง; ใช้แบบอักษรและการตั้งค่าเดียวกันเมื่อเปรียบเทียบโหมด.

การตั้งค่านี้แตกต่างจาก [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), ซึ่งควบคุมการจัดแนวนอนของย่อหน้า, และ [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), ซึ่งกำหนดตำแหน่งบล็อกข้อความในแนวตั้งภายในรูปทรง. การจัดรูปแบบซูเปอร์สคริปต์และซับสคริปต์ผ่าน [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) จะย้ายส่วนข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดแนวแบบอักษรของบรรทัดย่อหน้า.

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วน alpha ของสีที่กำหนดให้กับ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). ในตัวอย่างด้านล่าง, `alpha = 50` เป็นค่าช่อง alpha ของ ARGB ในช่วง 0–255, ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีเติมสีดำกึ่งโปร่งใสสำหรับข้อความ.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าความโปร่งใสของส่วนข้อความ.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะอักษรสำหรับข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ. ตัวอย่างเพิ่มระยะห่าง 3 พอยต์; ค่าลบจะบีบข้อความ.

โค้ด Python ต่อไปนี้แสดงวิธีขยายการเว้นระยะอักขระใน **ย่อหน้าทั้งหมด**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างของอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างของอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเว้นระยะอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายการเว้นระยะอักขระใน **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างของอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างของอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเว้นระยะอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันใน PowerPoint. สิ่งนี้เกิดขึ้นเพราะ PowerPoint อาจละเว้นข้อมูล kerning ของแบบอักษรบางแบบ, แม้ว่าแบบอักษรนั้นจะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่า PowerPoint.

เพื่อทำให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้น, คุณสามารถปิดการใช้ kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบ. ตั้งค่า [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ให้เป็นค่าที่มากกว่าขนาดแบบอักษรจริง. ตัวอย่างนี้ต้องใช้ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก. ตัวอย่างตรวจสอบชื่อแบบอักษรที่มีผล, รวมถึงแบบอักษรที่สืบทอด, และตั้งค่าขีดจำกัด 100 พอยต์สำหรับส่วนที่ใช้ Roboto. การตั้งค่านี้จะปิดการใช้ kerning สำหรับส่วนที่ใช้ขนาดแบบอักษรต่ำกว่า 100 พอยต์:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับข้อความที่ตรงกับขีดจำกัด, การตั้งค่านี้จะป้องกันการใช้ kerning และช่วยให้การแสดงผลของ Aspose.Slides ใกล้เคียงกับผลลัพธ์ภาพของ PowerPoint สำหรับแบบอักษรที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าได้ระดับย่อหน้าโดยผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือบนส่วนข้อความแต่ละส่วนโดยผ่าน [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 พอยต์ พร้อมการตั้งค่าแบบหนา, หนังศีรษะเอียง, และขีดเส้นจุดใต้ข้อความ. การจัดรูปแบบที่ระบุโดยตรงในแต่ละส่วนจะมีความสำคัญเหนือค่าดีฟอลต์เหล่านี้:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 พอยต์, การจัดรูปแบบเอียง, และขีดเส้นจุดสำหรับส่วนที่การจัดรูปแบบมีผลเป็นแบบหนา:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำให้ความสูงข้อความเป็นมาตรฐาน**

ใช้ [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) เมื่อทำสำเนาแบบอักษรตามแบบเทมเพลตหรือสอบถามความแตกต่างของความสูงอักขระ. ใน PowerPoint, การเปิดใช้งานการทำให้เป็นมาตรฐานจะยืดหรือบีบอัดอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้สม่ำเสมอภายในส่วนข้อความ. การทำเช่นนี้ไม่ได้รับประกันว่าข้อความจากแบบอักษรต่าง ๆ จะมีความสูงเท่ากัน.

ตั้งคุณสมบัติเป็น [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำให้เป็นมาตรฐานอย่างชัดเจน. `NullableBool.NOT_DEFINED` ทำให้การตั้งค่าท้องถิ่นไม่ได้กำหนดค่า, ทำให้ส่วนข้อความสืบทอดค่าจากแหล่งอื่น, เช่น จาก [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ของย่อหน้า. ค่านี้ไม่เท่ากับ `False`. ใช้ [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) และอ่าน [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) เพื่อรับค่า Boolean ที่ได้สรุปแล้ว.

ตัวอย่างอิสระต่อไปนี้ต้องมี **Arial** ติดตั้ง. มันสร้างบล็อกข้อความสองบล็อกที่มีอักษรพิมพ์ใหญ่, พิมพ์เล็ก, ตัวค้ำบังคับ, และอักขระที่มีสำเนียงเดียวกันขนาด 54 พอยต์. ทั้งสองย่อหน้าเปิดใช้งานการทำให้เป็นมาตรฐานโดยค่าเริ่มต้น. ส่วนบนปิดการทำให้เป็นมาตรฐานโดยชัดเจน; ส่วนล่างสืบทอดการตั้งค่า. ขนาดกรอบ, ระยะขอบ, และระยะห่างย่อหน้ามีค่าเท่ากัน, พร้อมการตัดบรรทัดและ autofit ปิดเพื่อให้การเปรียบเทียบคงที่. ตัวอย่างพิมพ์ `FALSE: False` และ `NOT_DEFINED: True`, จากนั้นบันทึกเป็น "text_height_normalization.pptx".

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

การเปรียบเทียบด้านล่างถูกส่งออกจากงานนำเสนอที่บันทึกไว้. แถวบนมีการทำให้เป็นมาตรฐานปิด (`FALSE`); แถวล่างสืบทอดการตั้งค่าเปิด (`NOT_DEFINED` → `True`). ต้องติดตั้ง Arial เพื่อทำให้ภาพนี้แสดงได้.

![ข้อความ Arial ขนาด 54 พอยต์ที่มีการทำให้ความสูงเป็นมาตรฐานถูกปิดด้านบนและสืบทอดการเปิดด้านล่าง](text_height_normalization.png)

การทำให้เป็นมาตรฐานเปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) ที่ระบุขนาดแบบอักษรเป็นพอยต์. ย่อหน้า [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) ควบคุมระยะห่างบรรทัด, ขณะที่กรอบข้อความ [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ควบคุมวิธีที่ข้อความหรือคอนเทนเนอร์ปรับขนาดให้พอดี. การตั้งค่าเหล่านี้มีวัตถุประสงค์ที่แตกต่างกันและอาจส่งผลต่อการจัดวางโดยรวมแยกจากกัน. สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด, ดู [จัดการย่อหน้า](/slides/th/python-net/manage-paragraph/).

## **ใช้และลบการขีดฆ่า**

ใช้ [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความต้นฉบับ. ตั้งค่าเป็น [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) เพื่อขีดหนึ่งหรือสองเส้นผ่านข้อความ.

เพื่อเอาการขีดฆ่าออก, กำหนดค่า `TextStrikethroughType.NONE`. ค่านี้ปิดการทำงานอย่างชัดเจน, แม้ว่าการจัดรูปแบบโดยรอบจะระบุการขีดฆ่า. ตรงกันข้าม, `TextStrikethroughType.NOT_DEFINED` ทำให้การตั้งค่าท้องถิ่นไม่ได้กำหนดค่า, ทำให้ส่วนข้อความสืบทอดการจัดรูปแบบ, เช่น จากย่อหน้า. ค่านี้ไม่รับประกันว่าการขีดฆ่าจะถูกลบ. ใช้ [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) เพื่ออ่านการจัดรูปแบบที่ได้, รวมถึงค่าที่สืบทอด.

ตัวอย่างอิสระต่อไปนี้สร้างการเปรียบเทียบราคาสามรายการ. แต่ละย่อหน้ามีส่วนแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน, ดังนั้นจึงมีผลเฉพาะราคาก่อนหน้า. แถวแรกใช้การขีดฆ่าแล้วลบการขีดฆ่า; แถวอื่น ๆ คงการขีดฆ่าแบบเดียวและแบบสองเส้น. การเปลี่ยนคุณสมบัตินี้ทำให้ข้อความและการจัดรูปแบบอื่น ๆ คงไว้, รวมถึงส่วนข้อความหนาของราคาก่อนหน้า.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # ใช้การขีดฆ่า, แล้วลบอย่างเจาะจงจากราคาก่อนหน้าตัวแรก.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์จากบนลงล่าง: ไม่ขีดฆ่า, ขีดฆ่าแบบเดียว, และขีดฆ่าแบบสองเส้น.

![ราคาก่อนหน้าโดยไม่มีการขีดฆ่า, มีการขีดฆ่าแบบเดียว, และขีดฆ่าแบบสอง](strikethrough.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อตั้งค่าการกำหนดทิศทางข้อความที่มีไว้ล่วงหน้าในรูปทรง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการกำหนดทิศทางข้อความในรูปทรงเป็น [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), ซึ่งจะหมุนข้อความ **90 องศาในทิศทางทวนเข็มนาฬิกา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **แสดงตัวเลขต่อกันในข้อความแนวตั้ง**

เพื่อให้ตัวเลขสองหลักอยู่ด้วยกันในป้ายภาษาญี่ปุ่นแนวตั้ง, ใส่ตัวเลขทั้งสองในส่วนข้อความเดียวและตั้งค่า [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) ในส่วนนั้น. ตัวอย่างสร้างป้ายสองอันในงานนำเสนอใหม่โดยใช้ [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) และ MS Gothic ขนาด 40 พอยต์. ค่าที่กำหนดให้กับส่วนตัวเลขใน [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) คือสิ่งเดียวที่แตกต่างกัน:

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

ใน PowerPoint, ป้ายด้านซ้าย (`TRUE`) แสดงตัวเลขตั้งตรงและต่อกันระหว่าง 和 และ 年. ป้ายด้านขวา (`FALSE`) ตัวเลขถูกหมุน 90 องศาในทิศทางตามเข็มนาฬิกา. ตัวอักษรญี่ปุ่นรอบข้างยังคงตั้งตรงในทั้งสองป้าย.

![เปรียบเทียบใน PowerPoint ของป้ายวันที่แนวตั้งโดยมีตัวเลขตั้งตรงทางซ้ายและหมุนทางขวา](vertical_date.png)

## **ตั้งค่าการหมุนกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อตั้งค่ามุมการหมุนกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

โค้ดตัวอย่างต่อไปนี้หมุนกรอบข้อความ 3 องศาในทิศทางตามเข็มนาฬิกาภายในรูปทรง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนข้อความกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมการเว้นระยะย่อหน้า. การใช้คุณสมบัติเหล่านี้เป็นดังนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด.
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นพอยต์.

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นระยะภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (เว้นบรรทัดสองเท่า):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก. คุณสมบัติดังต่อไปนี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), ดังนั้นจึงใช้กับย่อหน้าเต็ม:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) ควบคุมกฎการตัดบรรทัดของละติน. ในข้อความผสม การเปลี่ยนค่านี้อาจเปลี่ยนตำแหน่งที่ข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนใกล้เคียงตัดบรรทัด.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก, รวมถึงข้อจำกัดของอักขระที่อยู่ต้นหรือท้ายบรรทัด.

กฎเหล่านี้ไม่ได้แทนที่ [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), ซึ่งเปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ. พวกมันมีผลต่อการจัดวางเมื่อมีการตัดบรรทัด; พวกมันไม่ได้แทรกอักขระการตัดบรรทัด. การตัดบรรทัดโดยเจตนาจะบังคับให้ขึ้นบรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่ใช้ได้.

ตัวอย่างอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่มีข้อความจีนและละติน. มันตั้งค่าคุณสมบัติกตัดบรรทัดทั้งสองอย่างอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx". เพื่อทดลองกับกฎใดกฎหนึ่ง, ให้เปลี่ยนค่าของคุณสมบัตินั้นในขณะที่คงการตั้งค่าอื่นไว้. ตัวอย่างใช้ Arial ขนาด 24 พอยต์และ SimSun พร้อมความกว้างกรอบ 160 พอยต์และระยะขอบแนวนอนเป็นศูนย์. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ตั้งเป็น [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของกรอบคงที่.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **ควบคุมเครื่องหมายวรรคตอนห้อย**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) อนุญาตให้เครื่องหมายวรรคตอนที่มีสิทธิ์ขยายออกเกินขอบขวาของบรรทัดข้อความแทนที่จะอยู่ในบรรทัดต่อไป. การตั้งค่านี้ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องห้อย.

ตัวอย่างอิสระต่อไปนี้เปิดใช้งานเครื่องหมายวรรคตอนห้อยในกรอบข้อความกว้าง 100 พอยต์และบันทึกเป็น "hanging_punctuation.pptx". ด้วย Arial ขนาด 24 พอยต์และระยะขอบแนวนอนเป็นศูนย์, จุดสุดท้ายของประโยคอยู่หลังคำว่า "sentence" และขยายเกินขอบขวาของข้อความ. ตั้งค่าเป็น [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) เพื่อตรวจสอบ: ด้วยการตั้งค่านี้, จุดสุดท้ายจะอยู่ในบรรทัดแยกต่างหาก. การตัดบรรทัดเปิดใช้งานและ autofit ปิดเพื่อคงความกว้างที่ใช้ได้คงที่.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

ไม่ใช่ทุกเครื่องหมายวรรคตอนจะสามารถห้อยได้. ผลลัพธ์ที่มองเห็นขึ้นอยู่กับ [font and layout conditions](#control-line-breaking): การเปลี่ยนแบบอักษร, ความกว้างที่ใช้ได้, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไป.

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดว่าเนื้อความจะแสดงอย่างไรเมื่อเกินขอบของคอนเทนเนอร์. ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปทรงอัตโนมัติหรือไม่. ตัวอย่างต่อไปนี้กำหนดให้รูปทรงปรับขนาดเพื่อให้พอดีกับข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อนับบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือรูปทรงเปลี่ยนผลลัพธ์หรือไม่, ดูที่ [นับบรรทัดที่แสดง](/slides/th/python-net/manage-paragraph/). จำนวนบรรทัดอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่.

## **ตั้งค่าจุดยึดของกรอบข้อความ**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดว่าข้อความจะวางในแนวตั้งภายในรูปทรงอย่างไร, เช่น ที่บน, กลาง, หรือล่าง. ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการทำแท็บข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า. ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 พอยต์และเพิ่มจุดหยุดแท็บซ้ายที่ 30 พอยต์. การตั้งค่าเหล่านี้ส่งผลต่อข้อความที่มีอักขระแท็บ.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) ซึ่งให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ. ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างต่อไปนี้ต้องมี "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า. มันแทนที่เนื้อหาของย่อหน้าแรกด้วย "1。", ตั้งค่าแบบอักษรเป็น SimSun, และกำหนดภาษาการตรวจสอบ Simplified Chinese (`zh-CN`). จากนั้นบันทึกผลลัพธ์เป็น "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # ตั้งค่าภาษาตรวจสอบเป็นภาษาจีนแบบ Simplified.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต, ให้รักษา [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) และ [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) ไว้. ตัวอย่างอิสระต่อไปนี้สร้างส่วนต้นทางที่มี US English เป็นภาษาหลักและ French เป็นภาษาทางเลือก, แล้วคัดลอกข้อความและตัวระบุไปยังส่วนในงานนำเสนอใหม่.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # หากแหล่งไม่มีภาษาทางเลือก, ค่า None จะล้างค่าที่ปลายทาง.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อทดลองกับแหล่งที่ไม่มีภาษาทางเลือก, ให้ละการกำหนดค่า `"fr-FR"`. ตัวระบุทางเลือกจะเป็น `None`, และคำสั่งคัดลอกเดียวกันจะรักษาการไม่มีค่านั้นโดยไม่สร้างค่าเริ่มต้น, แม้ว่าเป้าหมายอาจมีภาษาทางเลือกกำหนดไว้ก่อนหน้า.

ตัวระบุเหล่านี้ถูกเก็บเป็นเมตาดาต้าภาษา. การรักษาเมตาดาต้าเหล่านี้ไม่ได้กำหนดว่าพจนานุกรมใดของ PowerPoint จะถูกเลือกสำหรับการตรวจสอบการสะกดหรือไวยากรณ์.

## **ตั้งค่าภาษาดีฟอลต์**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อกำหนดภาษาดีฟอลต์สำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ. ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มี US English เป็นภาษาข้อความเริ่มต้น, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # ตรวจสอบภาษาของส่วนข้อความแรก.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **ตั้งค่าลักษณะข้อความดีฟอลต์**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นระดับงานนำเสนอ, ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรหนาขนาด 14 พอยต์เป็นค่าดีฟอลต์สำหรับย่อหน้าในระดับบนของงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx". ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้ ตราบใดที่การจัดรูปแบบที่เจาะจงมากกว่าจะไม่ทับซ้อน.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # ดึงรูปแบบย่อหน้าในระดับบนสุด.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint, การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้จะพิมพ์เป็นตัวพิมพ์เล็กเดิม. เมื่อดึงส่วนข้อความเช่นนี้ด้วย Aspose.Slides, ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้. เพื่อตรงกับข้อความที่แสดง, ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าคือ `ALL`.

ตัวอย่างนี้ต้องมี "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก. ส่วนแรกของย่อหน้าแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps, ดังที่แสดงด้านล่าง.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ที่ใช้:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์, ใช้ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ, ใช้ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.

[จัดรูปแบบข้อความในสไลด์](/slides/th/features/text-formatting/)