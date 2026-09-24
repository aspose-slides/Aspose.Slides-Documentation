---
title: จัดรูปแบบข้อความการนำเสนอใน Python
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-net/text-formatting/
keywords:
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนต์
- ฟอนต์ตระกูล
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติการปรับอัตโนมัติ
- ตำแหน่งยึดกรอบข้อความ
- การตั้งค่าตำแหน่งแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งฟอนต์ สี การจัดแนว และอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPointและ OpenDocument โดยใช้ Aspose.Slides for Python via .NET ครอบคลุมสีพื้นหลัง ความโปร่งแสง ระยะห่างระหว่างอักขระ คุณสมบัติของฟอนต์ การหมุน ระยะห่างระหว่างย่อหน้า พฤติกรรมการปรับอัตโนมัติ การยึดตำแหน่งข้อความ จุดแท็บ และการตั้งค่าภาษา

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:
![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและไฮไลท์ข้อความตามตัวอักษรหรือผลการจับคู่ regular-expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.highlight_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าสีไฮไลต์สำหรับย่อหน้าเต็ม.
    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เพื่อกำหนดการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าที่ตั้งได้สามารถเป็นการจัดกึ่งกลาง การจัดซ้าย การจัดขวา การจัดเต็มบรรทัด ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการจัดแนวของย่อหน้าให้อยู่กึ่งกลาง.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![ย่อหน้าที่จัดแนว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมโดยส่วนค่าอัลฟ่า (alpha) ของสีที่กำหนดให้กับ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/). ในตัวอย่างต่อไปนี้ `alpha = 50` เป็นค่าช่องอัลฟ่า ARGB ในช่วง 0-255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:
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

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา**:
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

## **ตั้งค่าการเว้นระยะอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spacing/) เพื่อขยายหรือย้อลดระยะห่างระหว่างอักขระในกล่องข้อความ.

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าเต็ม**:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint ซึ่งอาจเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์นั้นจะมีข้อมูล kerning ที่ถูกต้องและ kerning ถูกเปิดใช้งานในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีดังกล่าว คุณสามารถปิดการ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่า [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:
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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและสามารถช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติของฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือบนส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/).

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับย่อหน้าเต็ม: มันตั้งค่าขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า.
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
![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่มีฟอนต์หนา**:
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
![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อกำหนดการจัดแนวข้อความที่กำหนดไว้ล่วงหน้าในรูปร่าง.

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการจัดแนวข้อความในรูปร่างเป็น `VERTICAL270` ซึ่งหมุนข้อความ **90 องศาตรงกันข้ามกับเข็มนาฬิกา**:
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

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความโดย 3 องศาตามเข็มนาฬิกาในรูปร่าง:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังต่อไปนี้:
* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นหน่วยจุด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุระยะห่างบรรทัดภายในย่อหน้า:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:
![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดว่าข้อความทำงานอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อให้นับจำนวนบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าข้อความหรือความกว้างของรูปร่างเปลี่ยนแปลงผลลัพธ์อย่างไร ให้ดู [นับบรรทัดที่เรนเดอร์](/slides/th/python-net/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่.

## **ตั้งตำแหน่งยึดของกรอบข้อความ**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดว่าข้อความถูกจัดตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าตำแหน่งแท็บของข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/tabs/) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า.
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

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [PortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/language_id/) ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษ proofing จะกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา proofing สำหรับส่วนข้อความ:
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

    # ตั้งค่า Id ของภาษาการพิสูจน์.
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

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้รูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/default_text_style/).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าฟอนต์หนาเป็นค่าเริ่มต้นที่ขนาด 14 pt สำหรับข้อความทั้งหมดบนสไลด์ในงานนำเสนอใหม่.
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

## **ดึงข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนไว้ เพื่อตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่ามาเป็นตัวพิมพ์ใหญ่เมื่อค่ามีค่า `ALL`.

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx.
![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงข้อความที่มีเอฟเฟกต์ **All Caps** อยู่:
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

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/). วนซ้ำผ่านเซลล์และอัปเดตแต่ละเซลล์โดยใช้ [Cell.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/text_frame/) และการจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/paragraph_format/).

**วิธีใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [PortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/fill_format/). ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) และกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.