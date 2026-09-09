---
title: จัดรูปแบบข้อความงานนำเสนอใน Python ผ่าน Java
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-java/text-formatting/
keywords:
- จัดตำแหน่งย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดกรอบข้อความ
- การแท็บข้อความ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java ปรับแต่งแบบอักษร สี การจัดตำแหน่ง และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via Java โดยครอบคลุมสีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของแบบอักษร, การหมุน, ระยะห่างของย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกรอบข้อความเดียวในสไลด์แรกพร้อมข้อความดังต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือการจับคู่ regular-expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-java/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อตั้งค่าสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

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

    # ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีแบบอักษรหนา**:

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

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) เพื่อตั้งค่าการจัดตำแหน่งย่อหน้าในกรอบข้อความ ค่าอาจเป็น centered, left-aligned, right-aligned, justified ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าให้ **กึ่งกลาง**:

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

    # ตั้งค่าการจัดตำแหน่งของย่อหน้าให้กึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าจัดตำแหน่งกึ่งกลาง](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความถูกควบคุมผ่านส่วนประกอบ alpha ของสีที่กำหนดให้กับ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/). ในตัวอย่างด้านล่าง `alpha = 50` คือค่าช่อง alpha ของ ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

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

    # ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้ามีความโปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีแบบอักษรหนา**:

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

![ส่วนข้อความมีความโปร่งใส](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [PortionFormat.setSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกรอบข้อความ

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ย่อหน้าเต็ม**:

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

    # หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีขยายระยะห่างระหว่างอักขระใน **ส่วนข้อความที่มีแบบอักษรหนา**:

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
            # หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            portion.getPortionFormat().setSpacing(3) # ขยายระยะห่างระหว่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันใน PowerPoint นี่อาจเกิดจาก PowerPoint เพิกเฉยข้อมูล kerning สำหรับแบบอักษรบางตัว แม้ว่าแบบอักษรจะมีข้อมูล kerning ที่ถูกต้องและได้เปิดใช้งาน kerning ในการตั้งค่า PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิด kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบ ตั้งค่า [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ให้เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริงอย่างมีนัยสำคัญ:

```python
import jpype
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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การตั้งค่านี้จะป้องกันการใช้ kerning กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติแบบอักษรสามารถตั้งค่าได้ระดับย่อหน้าผ่าน [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือบนส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับย่อหน้าเต็ม: ใช้ขนาดแบบอักษร, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และแบบอักษร Times New Roman กับทุกส่วนในย่อหน้า

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

    # ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
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

![คุณสมบัติแบบอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่มีแบบอักษรหนา**:

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
            # ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
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

![คุณสมบัติแบบอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดทิศทางข้อความที่กำหนดไว้ล่วงหน้าในรูปร่าง

โค้ดต่อไปนี้ตั้งค่าการกำหนดทิศทางข้อความในรูปร่างเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาต้านเข็มนาฬิกา**:

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

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับ TextFrame**

ใช้ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/)

ตัวอย่างโค้ดด้านล่างหมุน TextFrame ไป 3 องศาตามเข็มนาฬิกาภายในรูปร่าง:

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

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceBefore), และ [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้:

* ใช้ค่าเป็นบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าเป็นลบเพื่อระบุระยะห่างบรรทัดเป็นพอยต์

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุระยะห่างบรรทัดภายในย่อหน้า:

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

## **ตั้งค่าชนิด Autofit สำหรับ TextFrame**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAutofitType) กำหนดวิธีที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

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

## **ตั้งค่า Anchor ของ TextFrame**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดวิธีที่ข้อความถูกจัดตำแหน่งแนวตั้งภายในรูปร่าง เช่น ที่ด้านบน, กลาง, หรือด้านล่าง

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

## **ตั้งค่าการแท็บของข้อความ**

ใช้ [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat.getTabs](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getTabs) เพื่อกำหนดตำแหน่งแท็บในย่อหน้า

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

Aspose.Slides มี [PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษานี้กำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา proofing สำหรับส่วนข้อความ:

```python
import jpapi
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

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาดีฟอลต์สำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

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

    # เพิ่มรูปสี่เหลี่ยมผืนผ้าพร้อมข้อความ.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # ตรวจสอบภาษาของส่วนข้อความแรก.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ให้ใช้ [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDefaultTextStyle)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าแบบอักษรหนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # ดึงรูปแบบย่อหน้าระดับบนสุด.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นอักษรพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าตรงต้นจะพิมพ์เป็นตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความเช่นนั้นด้วย Aspose.Slides ไลบรารีจะส่งคืนข้อความตามที่ป้อนไว้ เพื่อให้ตรงกับข้อความที่แสดง ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textcaptype/) และแปลงสตริงที่ได้เป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

สมมุติว่าเรามีกรอบข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ใช้:

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

## **FAQ**

**จะทำอย่างไรให้แก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ใช้ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/). วนผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.getTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getParagraphFormat)

**จะทำอย่างไรให้ใช้สีไล่ระดับสำหรับข้อความบนสไลด์ PowerPoint?**

เพื่อใช้สีไล่ระดับบนข้อความ ใช้ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/). ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/#Gradient) และกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส