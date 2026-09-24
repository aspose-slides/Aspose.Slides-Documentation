---
title: จัดรูปแบบข้อความงานนำเสนอใน Python ผ่าน Java
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/python-java/text-formatting/
keywords:
- จัดย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งแสงของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- การยึดกรอบข้อความ
- การจัดแท็บข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ปรับแต่งฟอนต์, สี, การจัดแนวและอื่น ๆ อีกมาก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Python via Java ครอบคลุมสีพื้นหลัง, ความโปร่งแสง, การเว้นระยะอักขระ, คุณสมบัติฟอนต์, การหมุน, การเว้นบรรทัดของย่อหน้า, พฤติกรรม Autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความดังต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

หากต้องการค้นหาและไฮไลท์ข้อความลิขิตหรือผลการจับคู่ด้วย regular expression ให้ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/python-java/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด**:

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

    # ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

ใช้ [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) เพื่อกำหนดการจัดแนวย่อหน้าในกรอบข้อความ ค่าที่ใช้ได้อาจเป็นการจัดกึ่งกลาง, จัดซ้าย, จัดขวา, จัดเต็มบรรทัด, เป็นต้น

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดย่อหน้าให้อยู่ที่ **กึ่งกลาง**:

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

    # ตั้งค่าการจัดแนวของย่อหน้าให้อยู่กึ่งกลาง.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งแสงสำหรับข้อความ**

ความโปร่งแสงของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟาของสีที่กำหนดให้กับ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ในตัวอย่างด้านล่าง `alpha = 50` คือค่าช่องอัลฟา ARGB ในช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งแสง

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ย่อหน้าทั้งหมด**:

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

    # ตั้งค่าสีเติมของข้อความเป็นสีโปร่งแสง.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งแสง](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งแสงกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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
            # ตั้งค่าความโปร่งแสงของส่วนข้อความ.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งแสง](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้ [PortionFormat.setSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด Python ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

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

    # หมายเหตุ: ใช้ค่าลบเพื่อบีบระยะห่างอักขระ.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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
            # หมายเหตุ: ใช้ค่าลบเพื่อบีบระยะห่างอักขระ.
            portion.getPortionFormat().setSpacing(3) # ขยายระยะห่างอักขระ.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูคับแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint เนื่องจาก PowerPoint อาจละเว้นข้อมูล kerning ของฟอนต์บางตัว แม้ฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและการตั้งค่า kerning ถูกเปิดใน PowerPoint

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ โดยกำหนด [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ:

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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์การแสดงของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมนี้ของ PowerPoint

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือที่ระดับส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับย่อหน้า **ทั้งหมด**: จะกำหนดขนาดฟอนต์, หนา, เอียง, เส้นใต้จุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

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

ตัวอย่างโค้ดด้านล่างใช้คุณสมบัติเดียวกันกับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดการวางแนวข้อความที่กำหนดไว้ล่วงหน้าในรูปทรง

โค้ดต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปทรงเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาตามเข็มนาฬิกาทวน**:

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

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อกำหนดมุมการหมุนแบบกำหนดเองให้กับ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/)

โค้ดด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปทรง:

```python
import jpice
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

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมการเว้นบรรทัดของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นหน่วยจุด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุการเว้นบรรทัดภายในย่อหน้า:

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

![การเว้นบรรทัดในย่อหน้า](line_spacing.png)

## **ตั้งค่าประเภท Autofit สำหรับกรอบข้อความ**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAutofitType) กำหนดว่าข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, ล้น, หรือปรับขนาดรูปทรงโดยอัตโนมัติ

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

หากต้องการนับบรรทัดหลังการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือรูปทรงเปลี่ยนแปลงอย่างไร ให้ดูที่ [นับบรรทัดที่เรนเดอร์](/slides/th/python-java/manage-paragraph/) จำนวนบรรทัดอย่างเดียวไม่บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งค่า Anchor ของกรอบข้อความ**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดตำแหน่งแนวตั้งของข้อความภายในรูปทรง เช่น อยู่ด้านบน, กลาง, หรือด้านล่าง

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

## **ตั้งค่าการเว้นแท็บของข้อความ**

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

Aspose.Slides มี [PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ซึ่งช่วยให้คุณกำหนดภาษาตรวจสอบสำหรับส่วนข้อความ ภาษาตรวจสอบนี้ใช้กำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา Proofing สำหรับส่วนข้อความ:

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

    # กำหนด Id ของภาษาตรวจสอบ.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาที่ใช้เป็นค่าเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

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

    # เพิ่มรูปสี่เหลี่ยมผืนผ้าที่มีข้อความ.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # ตรวจสอบภาษาของส่วนแรก.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **ตั้งค่ารูปแบบข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นระดับงานนำเสนอ ให้ใช้ [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDefaultTextStyle)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีกำหนดฟอนต์หนาเป็นค่าเริ่มต้นขนาด 14 pt สำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # รับรูปแบบย่อหน้าระดับบนสุด.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สกัดข้อความด้วยเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้จะพิมพ์เป็นตัวพิมพ์เล็กเดิม เมื่อคุณดึงส่วนข้อความดังกล่าวด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าให้เป็นตัวพิมพ์ใหญ่เมื่อค่าที่ได้คือ `All`

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ถูกนำไปใช้:

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

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell.getTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getParagraphFormat)

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint ได้อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ ให้ใช้ [PortionFormat.getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/). ตั้งค่า [FillFormat.setFillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.Gradient](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/#Gradient) และกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งแสง.