---
title: จัดรูปแบบข้อความการนำเสนอใน Python
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-net/text-formatting/
keywords:
- ไฮไลท์ข้อความ
- นิพจน์ปกติ
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างตัวอักษร
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การจัดแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งฟอนต์, สี, การจัดแนว และอื่นๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET ครอบคลุมการไฮไลท์, สีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรม autofit, การตั้งค่า anchor ของข้อความ, ตำแหน่งแท็บ, และการตั้งค่าภาษา

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![Sample text](sample_text.png)

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame.highlight_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_text/) เมื่อคุณต้องการไฮไลท์ข้อความที่ตรงกับตัวอย่างที่กำหนดใน TextFrame เมธอดจะใส่สีไฮไลท์ให้กับส่วนข้อความที่ตรงกันและสามารถใช้ร่วมกับ [TextSearchOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/textsearchoptions/) เพื่อควบคุมวิธีการค้นหา เช่น การจับคู่เฉพาะคำเต็ม

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # รับรูปร่างแรกจากสไลด์แรก.
    shape = presentation.slides[0].shapes[0]

    # ไฮไลท์คำว่า "try" ในรูปร่าง.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # ไฮไลท์คำว่า "to" ในรูปร่าง.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The highlighted text](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame.highlight_regex](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/highlight_regex/) จะไฮไลท์ข้อความที่ตรงกับการจับคู่จาก regular expression ใน Python API นี้จะเปิดให้ใช้บน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกคำที่มี **เจ็ดตัวอักษรหรือมากกว่า**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # ไฮไลท์ทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่า.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **กำหนดสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.highlight_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The gray paragraph](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The gray text portions](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เพื่อกำหนดการจัดแนวของย่อหน้าใน TextFrame ค่าที่ตั้งได้รวมถึงกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดเต็ม, เป็นต้น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการจัดแนวของย่อหน้าเป็นกึ่งกลาง.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The aligned paragraph](aligned_paragraph.png)

## **กำหนดความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วนประกอบ alpha ของสีที่กำหนดให้กับ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/). ในตัวอย่างต่อไปนี้ `alpha = 50` เป็นค่าช่อง alpha ของ ARGB บนสเกล 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

โค้ดตัวอย่างด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The transparent paragraph](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าความโปร่งใสของส่วนข้อความ.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The transparent text portions](transparent_text_portions.png)

## **กำหนดระยะห่างระหว่างอักขระของข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spacing/) เพื่อขยายหรือย่อระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด Python ด้านล่างแสดงวิธีขยายน้ำหนักอักขระใน **ย่อหน้าเต็ม**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าลบเพื่อลดระยะห่างของอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีขยายน้ำหนักอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **ปิดการทำงานของ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและได้เปิดใช้ในตั้งค่า PowerPoint

หากต้องการให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยกำหนดค่า [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ให้มากกว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับภาพที่ PowerPoint แสดงสำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถกำหนดได้ในระดับย่อหน้าผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือในแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับ **ย่อหน้าเต็ม**: จะกำหนดขนาดฟอนต์, หนา, เอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The font properties for the paragraph](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างนำคุณสมบัติคล้ายกันไปใช้กับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The font properties for text portions](font_properties_for_text_portions.png)

## **กำหนดการหมุนของข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อตั้งค่าการวางแนวข้อความที่กำหนดไว้ล่วงหน้าในรูปร่าง

โค้ดตัวอย่างต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปเป็น `VERTICAL270` ซึ่งจะหมุนข้อความ **90 องศาแบบทวนเข็มนาฬิกา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The text rotation](text_rotation.png)

## **กำหนดการหมุนแบบกำหนดเองสำหรับ Text Frames**

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างหมุน TextFrame 3 องศาแบบตามเข็มนาฬิกาในรูป:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The custom text rotation](custom_text_rotation.png)

## **กำหนดระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมระยะห่างระหว่างย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ระบุค่าบวกเพื่อกำหนดระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ระบุค่าลบเพื่อกำหนดระยะห่างเป็นจุด

โค้ดตัวอย่างต่อไปนี้แสดงวิธีกำหนดระยะห่างบรรทัดภายในย่อหน้า:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The line spacing within the paragraph](line_spacing.png)

## **กำหนดประเภท Autofit สำหรับ Text Frames**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดพฤติกรรมของข้อความเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนด Anchor ของ Text Frames**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปร่าง เช่น ด้านบน, กลาง, หรือด้านล่าง

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนด Tabulation ของข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/tabs/) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The paragraph tabs](paragraph_tabs.png)

## **กำหนดภาษาการตรวจสอบ (Proofing Language)**

Aspose.Slides มี [PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) ซึ่งให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบจะกำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # ตั้งค่า Id ของภาษาการตรวจสอบ.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดภาษาตั้งต้น**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อระบุภาษาตั้งต้นสำหรับข้อความที่สร้างระหว่างการโหลดหรือสร้างงานนำเสนอ

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # ตรวจสอบภาษาของส่วนข้อความแรก.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **กำหนดสไตล์ข้อความตั้งต้น**

เพื่อใช้การจัดรูปแบบข้อความตั้งต้นในระดับงานนำเสนอ ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/default_text_style/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # รับรูปแบบย่อหน้าในระดับบนสุด.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ดึงข้อความพร้อมเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่ทั้งหมดแม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความนั้นด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับข้อความที่แสดงบนสไลด์ ให้ตรวจสอบค่าใน [TextCapType](https://reference.aspose.com/slides/th/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าคือ `ALL`

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![The All Caps effect](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีดึงข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำไปใช้:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**วิธีแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) เลื่อนผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/text_frame/) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/paragraph_format/)

**วิธีใช้สี gradient กับข้อความในสไลด์ PowerPoint?**

เพื่อใช้สี gradient กับข้อความ ใช้ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/) ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) แล้วกำหนดจุดหยุด gradient, ทิศทาง, และความโปร่งใส