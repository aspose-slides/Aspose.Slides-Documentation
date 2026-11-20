---
title: จัดรูปแบบข้อความการนำเสนอใน Python
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-net/text-formatting/
keywords:
- จัดย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งแสงของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การทำแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและจัดสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งแบบอักษร, สี, การจัดแนว, และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Python via .NET ครอบคลุมสีพื้นหลัง, ความโปร่งแสง, ระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ยกเว้นจะระบุไว้เป็นอย่างอื่น ตัวอย่างทั้งหมดใช้ [sample.pptx](sample.pptx) รูปร่างแรกบนสไลด์แรกเป็นช่องข้อความ และย่อหน้าแรกมีข้อความตามที่แสดงด้านล่าง ดัชนีสไลด์และรูปแบบเริ่มจากศูนย์ ตัวอย่างที่เลือกส่วนหนาใช้การจัดรูปแบบที่มีประสิทธิผล รวมถึงการสืบทอดการจัดรูปแบบหนา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลต์ข้อความตามตัวอักษรหรือการจับคู่ด้วย regular-expression ดูที่ [Search and Replace Text](/slides/th/python-net/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อกำหนดสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้ตั้งค่าไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลต์เฉพาะส่วนที่กำหนดจะเหนือกว่าค่าเริ่มต้นนี้:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีไฮไลต์สำหรับย่อหน้าเต็ม
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าเทา](gray_paragraph.png)

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

## **จัดแนวย่อความข้อความ**

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) เพื่อกำหนดการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าอาจเป็น centered, left-aligned, right-aligned, justified ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **ตรงกลาง**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการจัดแนวของย่อหน้าเป็นตรงกลาง.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **จัดแนวแบบอักษรภายในบรรทัด**

ใช้ [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) เพื่อจัดแนวตามแนวตั้งของส่วนข้อความที่มีขนาดแบบอักษรต่างกันภายในบรรทัด การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของมัน

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับสี่กล่องบนสไลด์เดียวแต่ละย่อหน้ามีข้อความเดียวกันที่ 18, 36, และ 54 pt โดยมีการจัดแนวแบบอักษรที่แตกต่าง ใช้ Arial ปิดการทำ autofit และการห่อข้อความ และทำให้กรอบข้อความใหญ่พอสำหรับบรรทัดเดียว

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

![เปรียบเทียบการจัดแนว Baseline, Top, Center, Bottom กับขนาดแบบอักษรผสม](font_alignment.png)

การจัดแนวแบบอักษรใช้เมตริกของแบบอักษร ดังนั้นขอบของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างแม่นยำ ตัวอย่างประกอบด้วยอักษรพิมพ์ใหญ่และตัวลงเพื่อแสดงความแตกต่างระหว่าง baseline กับ bottom การมีแบบอักษรและการทดแทน, ตัวอักษรที่ใช้, และความแตกต่างของขนาดแบบอักษรส่งผลต่อผลลัพธ์ ขนาดกรอบ, ระยะห่าง, ระยะห่างบรรทัด, การห่อข้อความและ autofit ก็มีผลต่อการจัดเรียงเช่นกัน; ควรใช้แบบอักษรและการตั้งค่าเดียวกันเมื่อเปรียบเทียบโหมด

การตั้งค่านี้แตกต่างจาก [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า, และ [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ซึ่งกำหนดตำแหน่งบล็อกข้อความในแนวตั้งภายในรูปร่าง การจัดรูปแบบ superscript และ subscript ผ่าน [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) จะย้ายส่วนแยกตาม baseline แทนการตั้งค่า font_alignment สำหรับบรรทัดของย่อหน้า

## **ตั้งค่าความโปร่งแสงสำหรับข้อความ**

ความโปร่งแสงของข้อความควบคุมโดยส่วน alpha ของสีที่กำหนดให้กับ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) ตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่อง alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ย่อหน้าทั้งหมด**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการเติมสีดำกึ่งโปร่งแสงสำหรับข้อความ.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่ใช้แบบอักษรหนา**:

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
            # ตั้งค่าความโปร่งแสงของส่วนข้อความ.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) เพื่อขยายหรือบีบระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 pt; ค่าติดลบจะบีบข้อความ

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้แบบอักษรหนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแคบกว่าเมื่อเทียบกับ PowerPoint ซึ่งอาจเกิดจาก PowerPoint เพิกเฉยข้อมูล kerning ของแบบอักษรบางตัว แม้แบบอักษรจะมีข้อมูล kerning ที่ถูกต้องและเปิดการใช้ kerning ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้แบบอักษรนั้นได้ ตั้งค่า [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริง ตัวอย่างนี้ต้องการไฟล์ “presentation.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก มันตรวจสอบชื่อแบบอักษรที่มีประสิทธิผลรวมถึงแบบอักษรที่สืบทอดและกำหนดเกณฑ์ 100 pt สำหรับส่วนที่ใช้ Roboto การตั้งค่านี้จะปิด kerning สำหรับส่วนที่มีขนาดแบบอักษรต่ำกว่า 100 pt:

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

สำหรับข้อความที่ตรงกับเกณฑ์นี้ การตั้งค่านี้จะป้องกัน kerning และอาจช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าที่ระดับย่อหน้าผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือบนส่วนแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรเริ่มต้นของย่อหน้าแรกเป็น Times New Roman 12 pt พร้อมการจัดรูปแบบหนา, เอียง, และขีดเส้นใต้แบบจุด สิ่งที่กำหนดโดยเฉพาะบนส่วนแต่ละส่วนจะเหนือกว่าค่าเริ่มต้นเหล่านี้:

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

ตัวอย่างต่อไปนี้ใช้ Times New Roman 13 pt, การจัดรูปแบบเอียง, และขีดเส้นใต้แบบจุดกับส่วนที่มีการจัดรูปแบบที่มีประสิทธิผลเป็นหนา:

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

## **ควบคุมการทำ Normalization ของความสูงข้อความ**

ใช้ [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) เมื่อทำแบบอักษรตามเทมเพลตหรือสอบสวนความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดการทำ normalization จะยืดหรือบีบอักขระแต่ละตัวในแนวตั้งเพื่อให้มีความสูงที่มองเห็นได้เท่ากันภายในส่วนข้อความ แต่ไม่ได้รับประกันความสูงที่เท่ากันระหว่างแบบอักษรแตกต่างกัน

ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.TRUE หรือ FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) เพื่อเปิดหรือปิดการทำ normalization อย่างชัดเจน `NullableBool.NOT_DEFINED` จะปล่อยให้การตั้งค่าท้องถิ่นว่างเปล่าเพื่อให้ส่วนสืบทอดค่า เช่น จาก [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ของย่อหน้า ไม่ได้หมายถึง `False` ใช้ [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) และอ่าน [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) เพื่อรับค่า Boolean ที่ได้แก้ไขแล้ว

ตัวอย่างต่อไปนี้ต้องการ **Arial** ติดตั้ง มันสร้างสองบล็อกข้อความที่มีอักษรพิมพ์ใหญ่, พิมพ์เล็ก, ตัวลง, และอักขระที่มีสำเนียงที่เดียวกันที่ 54 pt ย่อหน้าทั้งสองเปิดการทำ normalization โดยค่าเริ่มต้น ส่วนบนปิดอย่างชัดเจน; ส่วนล่างสืบทอด การกำหนดขนาดกรอบ, ระยะห่าง, และระยะห่างย่อหน้าตรงกัน; ปิดการห่อและ autofit เพื่อให้การเปรียบเทียบสม่ำเสมอ ตัวอย่างพิมพ์ `FALSE: False` และ `NOT_DEFINED: True` จากนั้นบันทึกเป็น "text_height_normalization.pptx"

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

ผลลัพธ์ที่ส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนปิด normalization (`FALSE`) แถวล่างสืบทอดค่าที่เปิด (`NOT_DEFINED` → `True`) ควรติดตั้ง Arial เพื่อให้ได้ภาพนี้

![ข้อความ Arial 54‑pt ที่มี normalization ปิดอยู่ด้านบนและสืบทอดการเปิดอยู่ด้านล่าง](text_height_normalization.png)

Normalization ปรับความสูงอักขระโดยไม่เปลี่ยนค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) ที่ระบุขนาดแบบอักษรเป็น pt ย่อหน้า [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) ควบคุมระยะห่างบรรทัด ส่วน [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ของกรอบข้อความควบคุมว่าข้อความหรือคอนเทนเนอร์ปรับขนาดอย่างไร การตั้งค่าเหล่านี้มีจุดประสงค์ต่างกันและอาจส่งผลต่อการจัดวางโดยอิสระ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [Manage Paragraph](/slides/th/python-net/manage-paragraph/)

## **ใช้และลบ Strikethrough**

ใช้ [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความเดิม ตั้งค่าเป็น [TextStrikethroughType.SINGLE หรือ DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) เพื่อแสดงเส้นขีดหนึ่งหรือสองเส้นผ่านข้อความ

เพื่อลบ strikethrough ให้กำหนด `TextStrikethroughType.NONE` ซึ่งปิดผลอย่างชัดเจน แม้การจัดรูปแบบโดยรอบอาจระบุ strikethrough แตกต่างจาก `TextStrikethroughType.NOT_DEFINED` ที่ปล่อยให้ค่าท้องถิ่นไม่มีการกำหนด ทำให้ส่วนสืบทอดการจัดรูปแบบจากย่อหน้า ไม่ได้รับประกันว่าจะแก้ strikethrough ใช้ [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) เพื่อตรวจสอบผลลัพธ์รวมถึงค่าที่สืบทอด

ตัวอย่างต่อไปนี้สร้างการเปรียบเทียบราคา 3 แบบ ย่อหน้าแต่ละย่อหน้ามีส่วนแยกสำหรับป้าย, ราคาก่อน, และราคาปัจจุบัน ดังนั้นเฉพาะราคาก่อนเท่านั้นที่ได้รับผลกระทบ แถวแรกใช้และลบ strikethrough; แถวอื่นคงเส้นขีดเดี่ยวและคู่ การเปลี่ยนแปลงคุณสมบัตินี้จะรักษาข้อความและการจัดรูปแบบอื่นๆ รวมถึงความหนาของราคาก่อน

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

    # ใช้สไตล์ขีดเส้น, จากนั้นลบออกโดยชัดเจนจากราคาก่อนหน้าแรก.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์จากบนลงล่าง: ไม่มี strikethrough, strikethrough เดี่ยว, และ strikethrough คู่

![ราคาก่อนโดยไม่มี strikethrough, มี strikethrough เดี่ยว, และ strikethrough คู่](strikethrough.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อกำหนดแนวตั้งล่วงหน้าของข้อความภายในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) ซึ่งทำให้ข้อความ **หมุน 90 องศาตามเข็มนาฬิกาต้านทิศ**:

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

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)

ตัวอย่างโค้ดต่อไปนี้หมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการระยะห่างระหว่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมระยะห่างของย่อหน้า ใช้ตามนี้:

* ใช้ค่าบวกเพื่อระบุระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างเป็นจุด

ตัวอย่างต่อไปนี้ตั้งค่าระยะห่างภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (สองเท่า):

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

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการแบ่งบรรทัด**

กฎการแบ่งบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมผสานข้อความละตินและเอเชียตะวันออก คุณสมบัติเหล่านี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), ดังนั้นจึงใช้กับย่อหน้าเต็ม:

* [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) ควบคุมกฎการแบ่งบรรทัดของละติน ในข้อความผสม การเปลี่ยนแปลงอาจส่งผลต่อการห่อข้อความและเครื่องหมายวรรคตอนเอเชียตะวันออกที่อยู่ติดกัน
* [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ควบคุมกฎการแบ่งบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ตำแหน่งเริ่มต้นและสิ้นสุดบรรทัด

กฎเหล่านี้ไม่แทนที่ [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) ซึ่งเปิดการห่ออัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการห่อ; ไม่ได้เพิ่มอักขระการขึ้นบรรทัดใหม่ การขึ้นบรรทัดอย่างชัดเจนจะบังคับให้บรรทัดใหม่ในย่อหน้าโดยไม่สนใจความกว้างที่มี

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่มีจีนและละติน ตั้งค่าคุณสมบัติการแบ่งบรรทัดทั้งสองอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองกับกฎใดกฎหนึ่ง ให้เปลี่ยนค่าของคุณสมบัตินั้นขณะคงค่าของอีกอันไว้ ตัวอย่างใช้ Arial 24 pt และ SimSun พร้อมความกว้างกรอบ 160 pt และระยะขอบแนวนอนเป็นศูนย์ [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ตั้งเป็น [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติกรอบคงที่

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

## **ควบคุมการใช้เครื่องหมายวรรคตอนแบบ Hanging**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) อนุญาตให้เครื่องหมายวรรคตอนที่เหมาะสมต่อขอบขวาของบรรทัดข้อความแทนการย้ายไปบรรทัดถัดไป ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องแบบ hanging

ตัวอย่างต่อไปนี้เปิดใช้งาน hanging punctuation ในกรอบข้อความกว้าง 100 pt และบันทึกเป็น "hanging_punctuation.pptx" ด้วย Arial 24 pt และระยะขอบแนวนอนศูนย์ จุดสุดท้ายจะอยู่หลังคำว่า “sentence” และยื่นออกนอกขอบขวาของข้อความ ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ในการตั้งค่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยกออกมา เปิดการห่อและปิด autofit เพื่อให้ความกว้างคงที่

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

ไม่ใช่เครื่องหมายวรรคตอนทุกตัวที่จะทำ hanging ผลลัพธ์ที่มองเห็นขึ้นอยู่กับ [เงื่อนไขของแบบอักษรและการจัดวาง](#control-line-breaking): การเปลี่ยนแบบอักษร, ความกว้างที่มี, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไปได้

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดว่าข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้นออกขอบ, หรือทำให้รูปร่างปรับขนาดอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดให้รูปร่างปรับขนาดให้พอดีกับข้อความและบันทึกเป็น "autofit_type.pptx"

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อดูจำนวนบรรทัดหลังจากการห่ออัตโนมัติและสังเกตว่าขนาดข้อความหรือรูปร่างเปลี่ยนผลลัพธ์อย่างไร ดูที่ [Count Rendered Lines](/slides/th/python-net/manage-paragraph/) จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งค่าจุดยึดของกรอบข้อความ**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดว่าข้อความจะอยู่ในแนวตั้งของรูปร่างอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ทำให้ข้อความยึดลงด้านล่างของรูปร่างแรกและบันทึกเป็น "text_anchor.pptx"

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการทำ Tabulation ของข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) เพื่อกำหนดตำแหน่งหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าอินเทอร์วัลแท็บเริ่มต้นเป็น 100 pt และเพิ่มจุดหยุดแท็บซ้ายที่ 30 pt การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

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

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) ที่ให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษานี้กำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องการไฟล์ “presentation.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า มันแทนที่เนื้อหาในย่อหน้าแรกด้วย “1。” ตั้งค่าแบบอักษรเป็น SimSun และกำหนดภาษา proofing เป็นภาษาจีนตSimplified (`zh-CN`) แล้วบันทึกเป็น "proofing_language.pptx"

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

    # ตั้งค่าภาษา proofing เป็นภาษาจีนตัวย่อ.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **คัดลอก Metadata ของภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต ให้คงรักษา [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) และ [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) ตัวอย่างต่อไปนี้สร้างส่วนต้นทางที่มีภาษาอังกฤษสหรัฐเป็นภาษาและภาษาฝรั่งเศสเป็นภาษาใต้อีกหนึ่งภาษา แล้วคัดลอกข้อความและตัวระบุไปยังส่วนในงานนำเสนอใหม่

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
    # หากแหล่งไม่มีภาษาตัวเลือก ค่าที่เป็น None จะล้างค่าที่กำหนดในเป้าหมาย.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

หากต้องการลองแหล่งที่ไม่มีภาษาใต้อื่น ให้ละเว้นการกำหนด `"fr-FR"` ตัวระบุทางเลือกจะเป็น `None` และคำสั่งคัดลอกเดียวกันจะคงรักษาการไม่มีค่าโดยไม่สร้างค่าเริ่มต้นแม้ว่าปลายทางอาจเคยมีภาษาใต้อื่นกำหนดไว้

ตัวระบุเหล่านี้เป็น metadata ของภาษา การคงรักษามันไม่ได้กำหนดว่าพจนานุกรมใดของ PowerPoint จะถูกเลือกสำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อกำหนดภาษาข้อความเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีภาษาอังกฤษสหรัฐเป็นภาษาข้อความเริ่มต้น, เพิ่มกล่องข้อความ, แล้วพิมพ์ `en-US` สำหรับส่วนข้อความแรก

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปร่างสี่เหลี่ยมใหม่พร้อมข้อความ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # ตรวจสอบภาษาของส่วนข้อความแรก.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **ตั้งค่าการจัดรูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นระดับงานนำเสนอ ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรหนา 14 pt เป็นค่าเริ่มต้นสำหรับย่อหน้าระดับบนในงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้หากไม่มีการจัดรูปแบบที่เฉพาะเจาะจงที่เกินกว่า

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # รับรูปแบบย่อหน้าระดับบนสุด.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ดึงข้อความด้วยเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าต้นฉบับจะเป็นตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความแบบดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้เดิม เพื่อตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `ALL`

ตัวอย่างนี้ต้องการไฟล์ “sample2.pptx” ที่มีกล่องข้อความเป็นรูปร่างแรกบนสไลด์แรก ส่วนแรกของย่อหน้าแรกมี “Hello, Aspose!” พร้อมเอฟเฟกต์ All Caps ดังแสดงด้านล่าง

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ใช้:

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

## **FAQ**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) วนรอบเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)

**ฉันจะใส่สีไล่ระดับสีให้กับข้อความบนสไลด์ PowerPoint อย่างไร?**

เพื่อใส่สีไล่ระดับสีให้กับข้อความ ใช้ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) แล้วกำหนดหยุดไล่ระดับสี, ทิศทาง, และความโปร่งแสง

ฟีเจอร์ที่เกี่ยวข้อง: [Format text within slides](/slides/th/features/text-formatting/)