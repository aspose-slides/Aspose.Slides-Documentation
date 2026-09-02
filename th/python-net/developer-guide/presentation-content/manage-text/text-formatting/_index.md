---
title: จัดรูปแบบข้อความการนำเสนอใน Python
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-net/text-formatting/
keywords:
- จัดแนวย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- จุดยึดของกรอบข้อความ
- การจัดแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งแบบอักษร, สี, การจัดแนว และอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET ซึ่งครอบคลุมสีพื้นหลัง ความโปร่งใส ระยะห่างระหว่างอักขระ คุณสมบัติของแบบอักษร การหมุน ระยะห่างของย่อหน้า พฤติกรรม Autofit การกำหนดตำแหน่งข้อความ จุดหยุดแท็บ และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกโดยมีข้อความดังต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความโดยตรงหรือผลการจับคู่แบบ regular expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.highlight_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เพื่อกำหนดการจัดตำแหน่งย่อหน้าในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, จัดชิดซ้าย, จัดชิดขวา, จัดเรียงแบบเต็มแนว, เป็นต้น.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการจัดย่อหน้าให้อยู่ที่ **กึ่งกลาง**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการจัดตำแหน่งของย่อหน้าให้เป็นกึ่งกลาง.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วน alpha ของสีที่กำหนดให้กับ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/). ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าช่อง alpha ของ ARGB ในช่วง 0-255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

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

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะระหว่างอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spacing/) เพื่อขยายหรือบีบระยะห่างระหว่างอักขระในกล่องข้อความ.

โค้ด Python ต่อไปนี้แสดงวิธีการขยายระยะห่างระหว่างอักขระใน **ย่อหน้าทั้งหมด**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการขยายระยะห่างระหว่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบระยะห่างระหว่างอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่แสดงโดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint นี่อาจเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของแบบอักษรบางประเภท แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่าของ PowerPoint ก็ตาม.

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint ในกรณีดังกล่าว คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ ตั้งค่า [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

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

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติของแบบอักษรสามารถตั้งค่าได้ที่ระดับย่อหน้าผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือที่ส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/).

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับย่อหน้าทั้งหมด: จะกำหนดขนาดแบบอักษร, ตัวหนา, ตัวเอียง, เส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับส่วนข้อความทั้งหมดในย่อหน้า.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![คุณสมบัติแบบอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติที่คล้ายกันกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อกำหนดทิศทางข้อความที่กำหนดล่วงหน้าในรูปทรง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น `VERTICAL270` ซึ่งทำให้ข้อความ **หมุน 90 องศาตรงข้ามเข็มนาฬิกา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).

ตัวอย่างโค้ดด้านล่างทำการหมุนกรอบข้อความโดย 3 องศาตามเข็มนาฬิกาในรูปทรง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้งานดังต่อไปนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด.
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นหน่วยจุด.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการระบุการเว้นบรรทัดภายในย่อหน้า:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การเว้นบรรทัดในย่อหน้า](line_spacing.png)

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดว่าข้อความทำงานอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหดเล็กลง, ล้นออกมานอก, หรือปรับขนาดรูปทรงโดยอัตโนมัติ.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าจุดยึดของกรอบข้อความ**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปทรง เช่นอยู่ที่ด้านบน, กลาง, หรือด้านล่าง.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดแท็บของข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/tabs/) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า.

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

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษาตรวจสอบ**

Aspose.Slides มี [PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/), ซึ่งให้คุณตั้งค่าภาษาตรวจสอบสำหรับส่วนข้อความ ภาษาตรวจสอบจะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการตั้งค่าภาษาตรวจสอบสำหรับส่วนข้อความ:

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

    # ตั้งค่า Id ของภาษาตรวจสอบ.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # ตรวจสอบภาษาของส่วนข้อความแรก.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **ตั้งค่ารูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ให้ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/default_text_style/).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการตั้งค่าแบบอักษรหนาเริ่มต้นด้วยขนาด 14 pt สำหรับข้อความทั้งหมดในสไลด์ทั้งหมดของงานนำเสนอใหม่.

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

## **ดึงข้อความพร้อมเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กอยู่เดิม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนไว้เท่านั้น เพื่อตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่าคือ `ALL`.

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีการดึงข้อความที่มีเอฟเฟกต์ **All Caps** ถูกใช้:

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

## **คำถามที่พบบ่อย**

**วิธีแก้ไขข้อความในตารางบนสไลด์**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/text_frame/) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/paragraph_format/).

**วิธีใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/). ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) และกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.