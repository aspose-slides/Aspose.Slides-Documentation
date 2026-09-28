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
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- ตำแหน่งยึดกรอบข้อความ
- การจัดแท็บข้อความ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ปรับแต่งฟอนต์ สี การจัดแนว และอื่นๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET โดยครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติฟอนต์, การหมุน, ระยะห่างระยะย่อหน้า, พฤติกรรม autofit, การยึดตำแหน่งข้อความ, จุดแท็บ, และการตั้งค่าภาษา.

หากไม่ได้ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx) เนื้อหาในสไลด์แรกของรูปทรงแรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความดังแสดงด้านล่าง ดัชนีของสไลด์และรูปทรงเริ่มจากศูนย์ ตัวอย่างที่เลือกส่วนข้อความหนาใช้การจัดรูปแบบที่มีผลรวมถึงการจัดรูปแบบหนาที่สืบทอดมา:

![Sample text](sample_text.png)

เพื่อค้นหาและเน้นข้อความตัวอักษรหรือผลการจับคู่ด้วย regular‑expression โปรดดู [ค้นหาและแทนที่ข้อความ](/slides/th/python-net/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังข้อความ**

ใช้ [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) เพื่อตั้งค่าสีไฮไลต์เริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/highlight_color/) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างต่อไปนี้ตั้งค่าไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่กำหนดโดยตรงในส่วนข้อความแต่ละส่วนจะมีความสำคัญเหนือค่าที่ตั้งไว้:

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

![The gray paragraph](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

![The gray text portions](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [ParagraphFormat.alignment](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/alignment/) เพื่อตั้งค่าการจัดแนวย่อหน้าในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดบรรทัดเต็ม ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **กึ่งกลาง**:

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

![The aligned paragraph](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบ alpha ของสีที่กำหนดให้กับ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/fill_format/) ในตัวอย่างด้านล่าง `alpha = 50` เป็นค่าแชนแนล alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดด้านล่างแสดงวิธีกำหนดความโปร่งใสให้กับ **ย่อหน้าทั้งหมด**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าการเติมสีดำกึ่งโปร่งใสสำหรับข้อความ.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The transparent paragraph](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีกำหนดความโปร่งใสให้กับ **ส่วนข้อความที่มีฟอนต์หนา**:

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

![The transparent text portions](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat.spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/spacing/) เพื่อเพิ่มหรือย่อตัวอักษรระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 จุด; ค่าติดลบจะทำให้ข้อความกระชับขึ้น

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ย่อหน้าทั้งหมด**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างระหว่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            portion.portion_format.spacing = 3  # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **ปิดการใช้ Kerning สำหรับฟอนต์ที่ระบุ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันที่แสดงใน PowerPoint สิ่งนี้อาจเกิดจาก PowerPoint เพิกเฉยข้อมูล kerning ของฟอนต์บางตัว แม้ฟอนต์มีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีดังกล่าว คุณสามารถปิดการใช้ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยตั้งค่า [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ให้มีค่ามากกว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก จะตรวจสอบชื่อฟอนต์ที่มีผลรวมรวมถึงฟอนต์ที่สืบทอดมาและตั้งค่าเกณฑ์ 100 จุดสำหรับส่วนที่ใช้ Roboto ซึ่งจะปิดการใช้ kerning สำหรับส่วนที่มีขนาดฟอนต์ต่ำกว่า 100 จุด:

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

สำหรับข้อความที่ตรงกับเกณฑ์และขนาดต่ำกว่าเกณฑ์นี้ การตั้งค่านี้จะป้องกัน kerning และช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติกฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_portion_format/) หรือในแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/)

ตัวอย่างต่อไปนี้ตั้งค่าฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 จุด พร้อมการจัดรูปแบบหนา, เอียง, และขีดเส้นใต้เป็นจุดสี ดำ การจัดรูปแบบโดยตรงในแต่ละส่วนจะมีความสำคัญเหนือค่าพรีเซ็ตเหล่านี้:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The font properties for the paragraph](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 จุด, การจัดรูปแบบเอียง, และขีดเส้นใต้แบบจุดสำหรับส่วนที่มีการจัดรูปแบบที่มีผลรวมเป็นหนา:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/text_vertical_type/) เพื่อกำหนดการวางแนวข้อความที่กำหนดไว้ล่วงหน้าภายในรูปทรง

ตัวอย่างโค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/th/python-net/aspose.slides/textverticaltype/) ซึ่งจะหมุนข้อความ **90 องศาต้านเข็มนาฬิกา**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The text rotation](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)

ตัวอย่างโค้ดด้านล่างจะหมุนกรอบข้อความโดย 3 องศาในทิศทางตามเข็มนาฬิกาภายในรูปทรง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The custom text rotation](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.space_after](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_before/), และ [ParagraphFormat.space_within](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/space_within/) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้โดย:

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นหน่วยจุด

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นระยะภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (ระยะห่างสองเท่า):

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

![The line spacing within the paragraph](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อมีประโยชน์ในบล็อกข้อความแคบและการนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก คุณสมบัติดังต่อไปนี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/) ดังนั้นจึงใช้กับย่อหน้าเต็ม:

- [latin_line_break](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/latin_line_break/) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนค่านี้อาจทำให้ตำแหน่งการตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ใกล้เคียงเปลี่ยนแปลงด้วย
- [east_asian_line_break](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่ขึ้นต้นและลงท้ายบรรทัด

กฎเหล่านี้ไม่แทนที่ [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/) ซึ่งเปิดใช้งานการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ พวกมันมีผลต่อการจัดวางเมื่อเกิดการตัดบรรทัด; พวกมันไม่ได้ใส่อักขระการตัดบรรทัด การตัดบรรทัดแบบชัดเจนจะบังคับให้ย่อหน้าเริ่มบรรทัดใหม่โดยไม่คำนึงถึงความกว้างที่มีอยู่

ตัวอย่างอิสระต่อไปนี้สร้างบล็อกข้อความแคบที่ประกอบด้วยข้อความภาษาจีนและละติน ตั้งค่าคุณสมบัติการตัดบรรทัดทั้งสองอย่างอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" หากต้องการทดลองเปลี่ยนกฎใดกฎหนึ่ง ให้ปรับค่าของคุณสมบัตินั้นในขณะที่รักษาการตั้งค่าอื่นไว้ ตัวอย่างใช้ฟอนต์ Arial และ SimSun ขนาด 24 จุด ความกว้างกรอบ 160 จุด และขอบแนวนอนของกรอบเป็นศูนย์ [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/autofit_type/) ถูกตั้งค่าเป็น [TextAutofitType.NONE](https://reference.aspose.com/slides/th/python-net/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของกรอบคงที่

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

## **ควบคุมการวางเครื่องหมายวรรคตอนห้อย**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/hanging_punctuation/) ทำให้เครื่องหมายวรรคตอนที่รองรับสามารถยืดออกไปเกินขอบขวาของบรรทัดข้อความแทนที่จะอยู่บรรทัดถัดไป ใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องห้อย

ตัวอย่างอิสระต่อไปนี้เปิดใช้งานการวางเครื่องหมายวรรคตอนห้อยในกรอบข้อความกว้าง 100 จุดและบันทึกเป็น "hanging_punctuation.pptx" ด้วยฟอนต์ Arial ขนาด 24 จุดและขอบแนวนอนของกรอบเป็นศูนย์ จุดสุดท้ายของประโยคจะอยู่หลังคำ "sentence" และยืดเกินขอบขวาของข้อความ ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.FALSE](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดจะอยู่ในบรรทัดแยก การตัดบรรทัดเปิดใช้งานและ autofit ปิดเพื่อคงความกว้างที่มี

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

ไม่ใช่ทุกเครื่องหมายวรรคตอนที่สามารถห้อยได้ ผลลัพธ์ที่มองเห็นขึ้นอยู่กับฟอนต์และสภาพการจัดวาง: การเปลี่ยนฟอนต์, ความกว้างที่มี, ขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไป

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/autofit_type/) กำหนดพฤติกรรมของข้อความเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปทรงโดยอัตโนมัติ ตัวอย่างต่อไปนี้ตั้งค่ารูปทรงให้ปรับขนาดตามข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อคำนวณจำนวนบรรทัดหลังจากการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือรูปทรงเปลี่ยนแปลงผลอย่างไร โปรดดู [Count Rendered Lines](/slides/th/python-net/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่.

## **ตั้งค่าตำแหน่งยึดกรอบข้อความ**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/anchoring_type/) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปทรง เช่น ด้านบน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดแท็บข้อความ**

ใช้ [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/default_tab_size/) และ [ParagraphFormat.tabs](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/tabs/) เพื่อตั้งค่าจุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าช่วงแท็บเริ่มต้นเป็น 100 จุดและเพิ่มจุดแท็บชิดซ้ายที่ 30 จุด การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

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

![The paragraph tabs](paragraph_tabs.png)

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มี [BasePortionFormat.language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) ซึ่งให้คุณตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า จะเปลี่ยนเนื้อหาของย่อหน้าแรกเป็น "1。", ตั้งค่า SimSun เป็นฟอนต์ และกำหนดภาษาการตรวจสอบเป็นภาษาจีนตัวย่อ (`zh-CN`). จากนั้นบันทึกผลลัพธ์เป็น "proofing_language.pptx":

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

    # ตั้งค่าภาษาการตรวจสอบเป็นภาษาจีนตัวย่อ.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าภาษาดีฟอลต์**

ใช้ [LoadOptions.default_text_language](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/default_text_language/) เพื่อกำหนดภาษาดีฟอลต์สำหรับข้อความที่สร้างระหว่างการโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอโดยใช้ภาษาอังกฤษสหรัฐเป็นภาษาข้อความเริ่มต้น เพิ่มกล่องข้อความและพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน.

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

## **ตั้งค่าสไตล์ข้อความดีฟอลต์**

เพื่อใช้การจัดรูปแบบข้อความดีฟอลต์ในระดับงานนำเสนอ ใช้ [Presentation.default_text_style](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/default_text_style/)

ตัวอย่างต่อไปนี้ตั้งค่าแบบอักษรหนาขนาด 14 จุดเป็นค่าเริ่มต้นสำหรับย่อหน้าระดับบนในงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้เว้นแต่จะมีการจัดรูปแบบที่เจาะจงมากกว่าจะทับซ้อน

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

## **สกัดข้อความด้วยเอฟเฟ็กต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟ็กต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กเดิม ๆ ก็ตาม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้ เพื่อตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/python-net/aspose.slides/textcaptype/) และแปลงสตริงที่คืนเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `ALL`.

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ย่อหน้าแรกของมันส่วนแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟ็กต์ All Caps ตามที่แสดงด้านล่าง.

![The All Caps effect](all_caps_effect.png)

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

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/). วนรอบเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/text_frame/) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.paragraph_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/paragraph_format/).

**ฉันจะใช้สีไล่ระดับให้กับข้อความบนสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับกับข้อความ ให้ใช้ [BasePortionFormat.fill_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/fill_format/). ตั้งค่า [FillFormat.fill_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.GRADIENT](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) แล้วกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.