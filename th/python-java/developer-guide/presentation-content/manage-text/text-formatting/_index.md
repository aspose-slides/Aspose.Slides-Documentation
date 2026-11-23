---
title: จัดรูปแบบข้อความการนำเสนอใน Python ผ่าน Java
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-java/text-formatting/
keywords:
- จัดย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติกำหนดแบบฟอนต์
- กลุ่มฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- ตำแหน่งยึดกรอบข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ปรับแต่งฟอนต์ สี การจัดแนว และอื่น ๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via Java รวมถึงสีพื้นหลัง, ความโปร่งใส, การเว้นระยะห่างอักขระ, คุณสมบัติกำหนดแบบอักษร, การหมุน, การเว้นบรรทัด, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ยกเว้นกรณีที่ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปทรงแรกบนสไลด์แรกเป็นกล่องข้อความ และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง ดัชนีของสไลด์และรูปทรงใช้เลขฐานศูนย์ ตัวอย่างที่เลือกส่วนที่เป็นตัวหนาจะใช้การจัดรูปแบบที่มีผลรวมรวมถึงการสืบทอดการทำให้เป็นตัวหนา:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือการจับคู่แบบ regular-expression ดูที่ [Search and Replace Text](/slides/th/python-java/search-and-replace-text/).

## **กำหนดสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อกำหนดสีพื้นหลังเริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างต่อไปนี้กำหนดสีไฮไลท์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก สีไฮไลท์ที่ระบุบนส่วนข้อความแต่ละส่วนจะมีลำดับความสำคัญเหนือค่าเริ่มต้นนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่เป็นตัวหนา**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้ [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) เพื่อกำหนดการจัดแนวของย่อหน้าภายในกรอบข้อความ ค่าที่กำหนดสามารถเป็น centered, left-aligned, right-aligned, justified ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้ **อยู่กึ่งกลาง**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ตั้งค่าการจัดแนวของย่อหน้าให้กึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนกกึ่งกลาง](aligned_paragraph.png)

## **จัดแนวอักขระในบรรทัด**

ใช้ [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) เพื่อจัดแนวแนวตั้งของส่วนข้อความที่มีขนาดอักษรต่างกันในบรรทัดเดียว การตั้งค่านี้ใช้กับย่อหน้าทั้งหมดและควบคุมการจัดแนวภายในแต่ละบรรทัดของย่อหน้า

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีการระบุชื่อสี่กล่องบนสไลด์เดียว แต่ละย่อหน้ามีข้อความเดียวกันที่ขนาด 18, 36 และ 54 pt โดยใช้การจัดแนวอักษรที่แตกต่างกัน ใช้ Arial ปิดการทำ autofit และการตัดบรรทัด และทำให้กรอบข้อความใหญ่พอที่จะใส่บรรทัดเดียวได้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การเปรียบเทียบการจัดแนว Baseline, Top, Center, Bottom กับขนาดอักษรผสม](font_alignment.png)

การจัดแนวอักษรใช้เมทริกซ์ของฟอนต์ ดังนั้นขอบเขตที่มองเห็นของตัวอักษรแต่ละตัวอาจไม่ตรงกันอย่างแม่นยำ ตัวอย่างรวมอักษรพิมพ์ใหญ่และอักษรที่มีส่วนล่าง (descender) เพื่อแสดงความแตกต่างระหว่าง baseline กับ bottom การใช้ฟอนต์และการทดแทนฟอนต์ ตัวอักษรที่ใช้ และความแตกต่างของขนาดฟอนต์จะส่งผลต่อผลลัพธ์ ความกว้างของกรอบ, ระยะขอบ, ระยะห่างระหว่างบรรทัด, การตัดบรรทัดและ autofit ก็มีผลต่อการจัดวางเช่นกัน; ควรใช้ฟอนต์และการตั้งค่าเลย์เอาต์เดียวกันเมื่อต้องการเปรียบเทียบโหมด

การตั้งค่านี้แตกต่างจาก [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) ซึ่งควบคุมการจัดแนวแนวนอนของย่อหน้า, และ [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) ที่กำหนดตำแหน่งบล็อกข้อความในแนวตั้งภายในรูปร่าง การจัดแนวตัวอักษรยกเว้นและตัวอักษรยกกำลังล่างโดยใช้ [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) จะย้ายส่วนข้อความแต่ละส่วนสัมพันธ์กับ baseline แทนการตั้งค่าการจัดแนวฟอนต์สำหรับบรรทัดของย่อหน้า

## **กำหนดความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความควบคุมโดยส่วนประกอบ alpha ของสีที่กำหนดให้กับ [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) ในตัวอย่างด้านล่าง `alpha = 50` คือค่าช่อง alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่เป็นตัวหนา**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # ตั้งค่าความโปร่งใสของส่วนข้อความ.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **กำหนดระยะห่างระหว่างอักขระของข้อความ**

ใช้ [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) เพื่อขยายหรือยุบระยะห่างระหว่างอักขระในกล่องข้อความ ตัวอย่างเพิ่มระยะห่าง 3 pt; ค่าติดลบจะทำให้ข้อความบีบแน่น

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าเต็ม**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่เป็นตัวหนา**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างของอักขระ.
            portion.getPortionFormat().setSpacing(3) # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณีข้อความที่แสดงโดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint ซึ่งเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและการตั้งค่า kerning ใน PowerPoint จะเปิดอยู่

เพื่อให้ผลลัพธ์ที่แสดงใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยตั้งค่า [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) ให้มีค่ามากกว่าขนาดฟอนต์จริง ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ตรวจสอบชื่อฟอนต์ที่มีผลรวมรวมถึงฟอนต์ที่สืบทอด และตั้งค่าเกณฑ์ 100 pt สำหรับส่วนที่ใช้ Roboto การตั้งค่านี้จะปิด kerning สำหรับส่วนที่มีขนาดฟอนต์ต่ำกว่า 100 pt:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับข้อความที่ตรงกับเกณฑ์นี้ การตั้งค่าส่วนนี้จะป้องกัน kerning และช่วยทำให้การแสดงผลของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติของฟอนต์ในข้อความ**

คุณสมบัติของฟอนต์สามารถกำหนดได้ระดับย่อหน้าผ่าน [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือบนส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)

ตัวอย่างต่อไปนี้กำหนดฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 pt พร้อมตัวหนา, ตัวเอียง และการขีดเส้นใต้แบบจุด จุดกำหนดการจัดรูปแบบโดยตรงบนส่วนข้อความจะมีลำดับความสำคัญเหนือค่าเริ่มต้นเหล่านี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 pt, ตัวเอียง, และการขีดเส้นใต้แบบจุด กับส่วนข้อความที่มีการจัดรูปแบบผลรวมเป็นตัวหนา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ควบคุมการทำ Normalisation ความสูงของข้อความ**

ใช้ [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) เมื่อต้องการทำ Normalisation ของตัวอักษรในเทมเพลตหรือเพื่อตรวจสอบความแตกต่างของความสูงอักขระ ใน PowerPoint การเปิดใช้งาน Normalisation จะยืดหรือบีบอักขระแต่ละตัวในแนวตั้งให้มีความสูงที่มองเห็นได้เท่ากันภายในส่วนข้อความ แต่ไม่รับประกันว่าความสูงของข้อความทั้งหมดจะเท่ากันในฟอนต์ที่แตกต่างกัน

ตั้งค่าคุณสมบัตินี้เป็น [NullableBool.True_ หรือ False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) เพื่อเปิดหรือปิด Normalisation อย่างชัดเจน `NullableBool.NotDefined` จะปล่อยให้การตั้งค่าท้องถิ่นไม่มีค่า ทำให้ส่วนข้อความสืบทอดค่าจากย่อหน้าโดยใช้ [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ซึ่งไม่ได้หมายความว่าเป็น `False` ใช้ [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) แล้วอ่าน `getNormaliseHeight` จากการจัดรูปแบบผลรวมเพื่อรับค่า Boolean ที่ได้สรุปแล้ว

ตัวอย่างต่อไปนี้ต้องการ **Arial** ติดตั้งไว้ สร้างบล็อกข้อความสองบล็อกที่มีอักษรตัวพิมพ์ใหญ่, ตัวพิมพ์เล็ก, ตัวลง (descender) และอักขระที่มีเครื่องหมายสำคัญที่ขนาด 54 pt ทั้งสองย่อหน้ามี Normalisation เปิดเป็นค่าเริ่มต้น ส่วนบนปิดโดยเจตนา ส่วนล่างสืบทอด การตั้งค่าขนาดกรอบ, ระยะขอบ, และระยะห่างย่อหน้าเท่ากัน ทั้งการตัดบรรทัดและ autofit ปิดเพื่อให้การเปรียบเทียบสอดคล้อง ตัวอย่างพิมพ์ `False: False` และ `NotDefined: True` แล้วบันทึกเป็น "text_height_normalization.pptx":

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปรียบเทียบด้านล่างถูกส่งออกจากงานนำเสนอที่บันทึกไว้ แถวบนมี Normalisation ปิด (`False`) แถวล่างสืบทอดการเปิด (`NotDefined` → `True`) โปรดติดตั้ง Arial เพื่อให้ได้ลักษณะเดียวกัน

![ข้อความ Arial ขนาด 54 pt ที่มี Normalisation ปิดด้านบนและสืบทอดการเปิดด้านล่าง](text_height_normalization.png)

Normalisation เปลี่ยนความสูงของอักขระโดยไม่เปลี่ยนค่า [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) ที่ระบุขนาดฟอนต์เป็น pt ย่อหน้า [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) ควบคุมระยะห่างบรรทัด ส่วน [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) ของ TextFrame ควบคุมการปรับขนาดข้อความหรือกรอบข้อความ การตั้งค่าเหล่านี้ทำงานแยกกันและอาจส่งผลต่อการจัดวางโดยรวม สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการจัดรูปแบบย่อหน้าและการสืบทอด ดูที่ [Manage Paragraph](/slides/th/python-java/manage-paragraph/).

## **ใช้และลบ Strikethrough**

ใช้ [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) บนส่วนข้อความเพื่อแสดงการแก้ไข, คำที่ยกเลิก, หรือราคาก่อนหน้าโดยไม่ลบข้อความต้นฉบับ ตั้งค่าเป็น [TextStrikethroughType.Single หรือ Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) เพื่อแสดงเส้นเดี่ยวหรือเส้นคู่ผ่านข้อความ

เพื่อลบ strikethrough ให้ใช้ [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) ซึ่งจะปิดผลอย่างชัดเจน แม้ฟอร์แมตโดยรอบจะกำหนด strikethrough ในทางตรงกันข้าม [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) จะปล่อยให้การตั้งค่าท้องถิ่นไม่กำหนด ทำให้ส่วนข้อความสืบทอดฟอร์แมตจากย่อหน้า เช่น ไม่รับประกันว่า strikethrough จะถูกลบ ใช้ [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) เพื่ออ่านฟอร์แมตที่ได้รวมถึงค่าที่สืบทอด

ตัวอย่างต่อไปนี้สร้างการเปรียบเทียบราคา 3 แบบ แต่ละย่อหน้ามีส่วนข้อความแยกสำหรับป้าย, ราคาก่อนหน้า, และราคาปัจจุบัน ดังนั้นจะมีผลกับส่วนราคาก่อนหน้าเท่านั้น แถวแรกใช้และลบ strikethrough; แถวอื่นคงไว้เป็น strikethrough แบบเดี่ยวและคู่ การเปลี่ยนการตั้งค่านี้ทำให้ข้อความและฟอร์แมตอื่นๆ เช่น ตัวหนาของราคาก่อนหน้าถูกเก็บไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # ใช้การขีดเส้น, แล้วลบออกอย่างชัดเจนจากราคาก่อนหน้าแรก.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์จากบนลงล่าง: ไม่มี strikethrough, strikethrough เดี่ยว, และ strikethrough คู่

![ราคาก่อนหน้าโดยไม่มี strikethrough, มี strikethrough เดี่ยว, และมี strikethrough คู่](strikethrough.png)

## **กำหนดการหมุนของข้อความ**

ใช้ [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดการวางแนวข้อความที่กำหนดล่วงหน้าในรูปทรง

ตัวอย่างโค้ดต่อไปนี้ตั้งการวางแนวข้อความในรูปทรงเป็น [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), ซึ่งทำให้ข้อความหมุน **90 องศาตรงทิศทางตามเข็มนาฬิกา**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การหมุนของข้อความ](text_rotation.png)

## **แสดงตัวเลขเรียงกันในข้อความแนวตั้ง**

เพื่อให้ตัวเลขของหมายเลขสองหลักอยู่เรียงกันในป้ายญี่ปุ่นแนวตั้ง ให้ใส่ตัวเลขทั้งสองในส่วนข้อความเดียวและเรียก [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) บนส่วนนั้น ทั้งสองป้ายในตัวอย่างนี้ใช้ [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) และ MS Gothic ขนาด 40 pt โดยค่าของ [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) สำหรับตัวเลขต่างกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใน PowerPoint ป้ายซ้าย (`True`) แสดงตัวเลขให้ตั้งตรงและเรียงกันระหว่าง 和 กับ 年 ส่วนป้ายขวา (`False`) ตัวเลขจะหมุน 90 องศาตามเข็มนาฬิกา ตัวอักษรญี่ปุ่นโดยรอบยังคงตั้งตรงในทั้งสองป้าย

![เปรียบเทียบป้ายวันที่แนวตั้งใน PowerPoint ที่ตัวเลขตั้งตรงด้านซ้ายและหมุนด้านขวา](vertical_date.png)

## **กำหนดการหมุนแบบกำหนดเองสำหรับ Text Frames**

ใช้ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)

ตัวอย่างโค้ดต่อไปนี้หมุน Text Frame 3 องศาตามเข็มนาฬิกาภายในรูปทรง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **กำหนดระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides ให้บริการ [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุระยะห่างเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างเป็นจุด

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นบรรทัดภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (สองเท่า):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและงานนำเสนอที่ผสมข้อความละตินและเอเชียตะวันออก วิธีต่อไปนี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) ดังนั้นจึงใช้กับย่อหน้าทั้งหมด

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) ควบคุมกฎการตัดบรรทัดของละติน ในข้อความผสม การเปลี่ยนค่านี้อาจส่งผลต่อการตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ติดกัน
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก รวมถึงข้อจำกัดของอักขระที่อยู่ต้นหรือปลายบรรทัด

กฎเหล่านี้ไม่ได้แทนที่ [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) ซึ่งเปิดการตัดบรรทัดอัตโนมัติภายใน Text Frame แต่ส่งผลต่อการจัดวางเมื่อมีการตัดบรรทัด; ไม่ได้แทรกอักขระการตัดบรรทัด การตัดบรรทัดโดยเจตนาจะบังคับให้ขึ้นบรรทัดใหม่ภายในย่อหน้าโดยไม่คำนึงถึงความกว้างที่ใช้ได้

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่มีภาษาจีนและละติน ตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองอย่างอย่างชัดเจนและบันทึกเป็น "line_breaking.pptx" เพื่อทดลองกับกฎใดกฎหนึ่ง ให้เปลี่ยนค่าที่สัมพันธ์กันในขณะที่รักษาการตั้งค่าอื่นคงที่ ตัวอย่างใช้ Arial 24 pt และ SimSun พร้อมความกว้างเฟรม 160 pt และระยะขอบ Text Frame แนวนอนเป็นศูนย์ [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) ถูกตั้งค่าเป็น [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและมิติของเฟรมคงที่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมการใช้เครื่องหมายวรรคตอนแบบ Hanging**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) อนุญาตให้เครื่องหมายวรรคตอนที่สามารถทำแบบ hanging ขยายออกนอกขอบขวาของบรรทัดแทนที่จะย้ายไปบรรทัดถัดไป ใช้ได้กับย่อหน้าทั้งหมดและแตกต่างจากการทำ hanging indent

ตัวอย่างต่อไปนี้เปิดใช้งาน Hanging Punctuation ใน Text Frame กว้าง 100 pt และบันทึกเป็น "hanging_punctuation.pptx" ด้วย Arial 24 pt และระยะขอบแนวนอนเป็นศูนย์ จุดเต็มที่สุดท้ายจะอยู่หลังคำว่า "sentence" และขยายออกนอกขอบด้านขวา ตั้งค่าเป็น [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: ด้วยการตั้งค่านี้ จุดเต็มจะอยู่บนบรรทัดแยกออก การตัดบรรทัดเปิดและ autofit ปิดเพื่อคงความกว้างที่ใช้ได้คงที่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ไม่ใช่เครื่องหมายวรรคตอนทุกตัวที่สามารถทำ hanging ได้ เงื่อนไขของฟอนต์และการจัดวางที่อธิบายไว้ในส่วน [ควบคุมการตัดบรรทัด](#control-line-breaking) จะใช้กับการเปรียบเทียบนี้: การเปลี่ยนฟอนต์, ความกว้างที่ใช้ได้, ระยะขอบ, หรือการตั้งค่า autofit สามารถทำให้ความแตกต่างที่มองเห็นหายไปได้

## **กำหนดประเภท Autofit สำหรับ Text Frames**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) กำหนดวิธีที่ข้อความทำงานเมื่อมีความยาวเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะย่อลด, ล้นออก, หรือปรับขนาดรูปร่างอัตโนมัติ ตัวอย่างต่อไปนี้กำหนดให้รูปร่างปรับขนาดให้พอดีกับข้อความและบันทึกผลลงใน "autofit_type.pptx"

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เพื่อดูจำนวนบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าการเปลี่ยนความกว้างของข้อความหรือรูปร่างทำให้ผลลัพธ์เปลี่ยนอย่างไร ดูที่ [Count Rendered Lines](/slides/th/python-java/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่แสดงว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **กำหนดตำแหน่งยึดของ Text Frames**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดว่าข้อความวางในแนวตั้งภายในรูปร่างอย่างไร เช่นที่บน, กลาง, หรือด้านล่าง ตัวอย่างต่อไปนี้ยึดข้อความที่ด้านล่างของรูปทรงแรกและบันทึกผลลงใน "text_anchor.pptx"

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนด Tabulation ของข้อความ**

ใช้ [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) เพื่อกำหนดตำแหน่งหยุดแท็บในย่อหน้า ตัวอย่างต่อไปนี้ตั้งค่าการเว้นระยะแท็บเริ่มต้นเป็น 100 pt และเพิ่มตำแหน่งหยุดแท็บแบบซ้ายที่ 30 pt การตั้งค่าเหล่านี้มีผลต่อข้อความที่มีอักขระแท็บ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษา Proofing**

Aspose.Slides ให้บริการ [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) ซึ่งช่วยกำหนดภาษาการตรวจสอบการสะกดและไวยากรณ์ของส่วนข้อความ ภาษาการ proofing จะบ่งชี้ภาษาที่ PowerPoint ใช้ตรวจสอบการสะกดและไวยากรณ์

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและมีอย่างน้อยหนึ่งย่อหน้า แทนที่เนื้อหาของย่อหน้าแรกด้วย "1。" ตั้งค่า SimSun เป็นฟอนต์และกำหนดภาษาการ proofing เป็น Simplified Chinese (`zh-CN`) แล้วบันทึกเป็น "proofing_language.pptx"

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # ตั้งค่า Id ของภาษาการตรวจสอบ.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **คัดลอกเมตาดาต้าภาษา**

เมื่อคัดลอกข้อความหลายภาษาจากเทมเพลต ให้คงไว้ทั้ง [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) และ [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) ตัวอย่างต่อไปนี้สร้างส่วนข้อความต้นฉบับที่มี US English เป็นภาษาและ French เป็นภาษาแทน แล้วคัดลอกข้อความและตัวระบุไปยังส่วนในงานนำเสนอใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # หากแหล่งที่ไม่มีภาษาทดแทน, None จะล้างค่าของปลายทาง.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากต้องการทดลองโดยไม่มีภาษาแทน ให้ละเว้นการกำหนด `"fr-FR"` ตัวระบุทางเลือกจะเป็น `None` และคำสั่งคัดลอกเดียวกันจะคงการไม่มีค่านั้นไว้โดยไม่เพิ่มค่าเริ่มต้น แม้ว่าปลายทางจะเคยมีภาษาแทนกำหนดไว้ก่อน

ตัวระบุเหล่านี้เป็นเมทาดาต้าภาษา การคงไว้ไม่ได้กำหนดว่าพจนานุกรมใดของ PowerPoint จะถูกเลือกสำหรับการตรวจสอบการสะกดหรือไวยากรณ์

## **กำหนดภาษาตั้งต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ ตัวอย่างต่อไปนี้สร้างงานนำเสนอโดยกำหนด US English เป็นภาษาข้อความเริ่มต้น เพิ่มกล่องข้อความและพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปสี่เหลี่ยมพร้อมข้อความ.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # ตรวจสอบภาษาของส่วนแรก.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **กำหนดสไตล์ข้อความตั้งต้น**

เพื่อใช้การจัดรูปแบบข้อความตั้งต้นในระดับงานนำเสนอ ให้ใช้ [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle)

ตัวอย่างต่อไปนี้กำหนดฟอนต์แบบตัวหนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนของงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx" ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้ เว้นแต่การจัดรูปแบบที่เฉพาะเจาะจงจะครอบคลุมทับ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # ดึงรูปแบบย่อหน้าในระดับบน.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สกัดข้อความด้วยเอฟเฟ็กต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟ็กต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์ แม้ว่าจะพิมพ์ด้วยตัวพิมพ์เล็กก็ตาม เมื่อคุณดึงส่วนข้อความแบบนั้นด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่ป้อนไว้ เพื่อให้ตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) แล้วแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก ย่อหน้าแรกของมันมีส่วนแรกที่มีข้อความ "Hello, Aspose!" พร้อมเอฟเฟ็กต์ All Caps ดังที่แสดงด้านล่าง

![เอฟเฟ็กต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความด้วยเอฟเฟ็กต์ **All Caps** ที่กำหนด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) เรียกดูเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat)

**ฉันจะใส่สีไล่ระดับให้กับข้อความใน PowerPoint อย่างไร?**

เพื่อใส่สีไล่ระดับให้กับข้อความ ให้ใช้ [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) แล้วกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส