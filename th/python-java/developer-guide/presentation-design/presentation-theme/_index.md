---
title: จัดการธีมการนำเสนอใน Python ผ่าน Java
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/python-java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- ธีมภายนอก
- THMX
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อสร้าง, ปรับแต่งและแปลงไฟล์ PowerPoint ให้มีการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสีแบบประสานกัน, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์. วัตถุที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการจัดเก็บคุณสมบัติภาพทุกอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตหลายวัตถุพร้อมกัน.

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าได้. Master สามารถแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), ขณะนั้น Layout หรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). ในทางปฏิบัติ, ธีมที่ใช้จริงสำหรับสไลด์จะถูกกำหนดผ่านโซ่การสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของ Master, การแทนที่ของ Layout, และการแทนที่ของสไลด์.

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานที่พบบ่อยของธีม: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลจริงหลังจากการสืบทอดและการแทนที่ถูกแก้ไขแล้ว.

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) เปิดเผยโครงสร้างสีของธีม, โครงสร้างแบบอักษร, และโครงสร้างรูปแบบผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่จัดเก็บไว้ในธีม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

หากไฟล์ใช้หลาย master, อย่าถือว่าทุกสไลด์มีธีมที่มีผลเท่ากัน. ตรวจสอบ master ที่เชื่อมโยงกับสไลด์, และใช้ขั้นตอนธีมที่มีผลตามที่แสดงต่อไปในบทความนี้เมื่อมีการแทนที่ที่ระดับ layout หรือสไลด์.

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจากรายการ [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่าที่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่มีผล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม. หากคุณแทนที่สีจากสคีมด้วยสีโดยตรงบนรูปทรง, การเปลี่ยนแปลงต่อ ๆ ไปของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและสีเข้มจากสีธีมโดยนำการแปลงสีมาใช้. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่านรายการ [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อนและสีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก.

**2** - เวอร์ชันสีอ่อนและสีเข้มที่สร้างจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อิงจาก `Accent4`, ประยุกต์การแปลงความสว่างให้กับห้ารูป, แล้วบันทึกผลลัพธ์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม. หาก `Accent4` เปลี่ยนในภายหลัง, สีที่แปลงจะถูกคำนวณใหม่จากค่าของ `Accent4` ใหม่.

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

รายการ [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง.

## **เปลี่ยนแบบอักษรธีม**

โครงสร้างแบบอักษรของธีมมีชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความตัว 본. วิธี [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) และ [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) เปิดเผยชุดเหล่านั้น.

ตัวระบุแบบอักษรธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรตัว본문 ละติน (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่อง ละติน (Major Latin Font)
* `+mn-ea` - แบบอักษรตัว본문 เอเชียตะวันออก (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่อง เอเชียตะวันออก (Major East Asian Font)
* `+mn-cs` - แบบอักษรตัว본문 สคริปต์ซับซ้อน (Minor Complex Script Font)
* `+mj-cs` - แบบอักษรหัวเรื่อง สคริปต์ซับซ้อน (Major Complex Script Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษรละตินหลักของธีมและบรรทัด正文หนึ่งที่ใช้แบบอักษรละตินรองของธีม. จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หัวเรื่องใช้แบบอักษรหลักและข้อความใช้แบบอักษรรอง. ข้อความที่มีชื่อแบบอักษรเฉพาะแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อโครงสร้างแบบอักษรธีมเปลี่ยน.

คอลเลกชันแบบอักษรหลักและรองยังสามารถบรรจุการแมปแบบอักษรสำหรับระบบเขียนเฉพาะ, เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. เพื่อทำการตรวจสอบ, เพิ่ม, แทนที่, หรือเอาการแมปเหล่านี้ออก, ดูที่ [Script-Specific Theme Fonts](/slides/th/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/python-java/powerpoint-fonts/).
{{% /alert %}}

### **แก้ไขการอ้างอิงแบบอักษรธีม**

เมื่อทำการตรวจสอบข้อความ, [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) อาจคืนค่าการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อแบบอักษร. เรียก [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) พร้อมข้อมูลธีมที่มีผลเพื่อแก้ไขการอ้างอิงนั้น. คำนำหน้า `+mj` และ `+mn` เลือกชุดแบบอักษรหลักและรอง; ส่วนต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกแบบอักษรละติน, เอเชียตะวันออก, และสคริปต์ซับซ้อนตามลำดับ.

รับธีมที่มีผลผ่าน [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) บนผู้จัดการธีมของวัตถุที่ธีมนั้นใช้กับข้อความที่ตรวจสอบ. สำหรับข้อความธรรมดาบนสไลด์, ใช้ผู้จัดการธีมของสไลด์เพื่อให้บริบทรวมธีมที่สืบทอดของสไลด์นั้นและการแทนที่ในระดับท้องถิ่น. เมื่อทำการตรวจสอบที่ layout หรือ master เอง, ใช้ธีมที่มีผลของมันเอง. อย่าถือว่าธีมของ master แรกใช้กับทุกสไลด์.

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงแบบอักษรละตินรองอย่างชัดเจน. มันเริ่มต้นโครงสร้างแบบอักษรสไลด์ผ่าน [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) และกำหนดแบบอักษรละตินหลักและรองเป็น `Arial` และ `Calibri`, ทำให้ผลลัพธ์ทำซ้ำได้โดยไม่ต้องใช้ไฟล์อินพุต:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

ผลลัพธ์คือ `+mn-lt -> Calibri` แล้วตามด้วย `Verdana -> Verdana`. การอ้างอิงที่เก็บไว้ยังคงไม่เปลี่ยน, ในขณะที่ชื่อแบบอักษรที่ระบุโดยตรงจะถูกส่งกลับตามเดิม. หากส่วนข้อความใช้ `+mj-lt`, มันจะแก้เป็น `Arial` ในธีมนี้.

การแก้ไขการอ้างอิงธีมบ่งบอกแบบอักษรที่ธีมระบุ. มันไม่ได้ตรวจสอบการพร้อมใช้ของแบบอักษรหรือกำหนดไฟล์แบบอักษรที่จะใช้จริงหลังการแทนที่หรือการ fallback ของ glyph ระหว่างการแสดงผล. ดูที่ [Font Selection Sequence](/slides/th/python-java/font-selection-sequence/) และ [Font Substitution](/slides/th/python-java/font-substitution/) สำหรับขั้นตอนเหล่านั้น.

## **คัดลอกหรือใช้ธีม**

ขั้นตอนต่อไปแก้ไขปัญหาเรื่องธีมที่แตกต่างกัน.

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับ Master**

ใช้ [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นอยู่กับ master เฉพาะ. เลือก master จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) ซึ่งเป็น [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), แล้วส่งเส้นทางไฟล์ธีมให้กับเมธอด.

เมธอดทำงานดังต่อไปนี้:

1. สร้าง master slide ใหม่บนพื้นฐานของ master ที่เลือก
1. ใช้ธีมภายนอกกับ master ใหม่
1. กำหนด master ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นอยู่กับ master ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับ master แรกและบันทึกการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). ตรวจสอบเส้นทางที่ผู้ใช้ป้อน, จัดการข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกการนำเสนอหลังจากธีมถูกใช้สำเร็จเท่านั้น.

เฉพาะสไลด์ที่ขึ้นอยู่กับ master ที่เลือกเท่านั้นที่ถูกกำหนดใหม่. สไลด์ที่เชื่อมกับ master อื่นจะคง master และธีมเดิม. สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟ็กต์ที่รับรู้ธีมจะได้รับการแก้ไขตามธีมภายนอก. สี, แบบอักษร, การเติม, และรูปแบบที่กำหนดโดยตรงอาจคงเดิม. การแทนที่ในระดับ layout และ slide ยังอาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจาก master ใหม่.

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมการรัน. เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง, ให้ติดตั้งแบบอักษรที่จำเป็น, ให้บริการผ่าน [custom font sources](/slides/th/python-java/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/python-java/font-substitution/).

นี่เป็นขั้นตอนระดับ master โดยตรง: เมธอดรับเส้นทางไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับ slide หรือ layout ด้วยตนเอง.

### **ใช้ธีมภายนอกที่แตกต่างกันในงานนำเสนอที่มีหลาย Master**

เมื่อไม่ทราบ master ที่เกี่ยวข้องล่วงหน้า, ดึงมันจากสไลด์ตัวแทนผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) และ [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). เก็บอ้างอิง master ดั้งเดิมก่อนทำการใช้ธีมใด ๆ เนื่องจากแต่ละการเรียกจะสร้าง master ใหม่ในงานนำเสนอ.

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหาค่ามาสเตอร์และใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเรียกครั้งแรกมีผลเฉพาะสไลด์ที่ขึ้นอยู่กับ `first_group_master`, ส่วนการเรียกครั้งที่สองมีผลเฉพาะสไลด์ที่ขึ้นอยู่กับ `second_group_master`. สไลด์ที่เชื่อมกับ master อื่นจะไม่ถูกปรับสไตล์.

### **คงธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม, ให้โคลน master ต้นฉบับไปยังงานนำหมายโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), จากนั้นโคลนสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) พร้อม master ที่โคลน. ขั้นตอนนี้จะนำ master, layout, และธีมที่เกี่ยวข้องไปด้วยกัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องการรูปลักษณ์เดียวกันในปลายทาง. การโคลนเนื้อหาไปยัง master ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟ็กต์ที่ขับเคลื่อนโดยธีมเปลี่ยนแปลงได้.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บน master และ layout ปัจจุบัน, ให้เริ่มการแทนที่ระดับสไลด์จากธีมต้นฉบับ. เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) คัดลอกสามส่วนหลักของธีมเข้าสู่การแทนที่.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

ขั้นตอนนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่เปลี่ยนธีมที่สืบทอดจากสไลด์อื่น. เพื่อลบการแทนที่ท้องถิ่นและกลับไปใช้ค่าที่สืบทอด, เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **ใช้การแทนที่ธีมกับ Layout**

การแทนที่ระดับ layout ใช้กับสไลด์ที่ใช้ layout นั้น, ยกเว้นกรณีสไลด์มีการแทนที่ของตัวเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

ใช้ธีมระดับ master หรือ presentation เมื่อหลาย layout และสไลด์ต้องการออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับ layout เมื่อกลุ่ม layout หนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การแทนที่ระดับสไลด์เฉพาะกรณีพิเศษเท่านั้น. การแทนที่ระดับสไลด์เกินจำนวนทำให้การเปลี่ยนธีมระดับทั่วโลกในภายหลังคาดเดาได้ยาก.

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*การแทนที่ layout ใช้กับสไลด์ที่ใช้ layout นั้น ยกเว้นสไลด์ที่มีการแทนที่ที่ระดับท้องถิ่นมากกว่า. ค่าที่อิงธีมจะตามสกีมที่แก้ไขแล้ว; วัตถุที่ฟอร์แมตโดยตรงอาจคงลักษณะท้องถิ่น. ให้การแทนที่แคบเท่าที่จำเป็นสำหรับข้อยกเว้นการออกแบบที่ตั้งใจ.*
<!-- visual-explanation:presentation-theme:end -->

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ.

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) ปัจจุบัน. ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมตามธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม. สิ่งนี้แตกต่างจากการอ้างอิงโดยตรงในคอลเลกชัน, ที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ. อย่าถือว่าทุกการนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่าเดิม.

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังตามธีมให้กับ master แรก, และบันทึกการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่ master อ้างอิงและการแทนที่พื้นหลังที่ระดับ layout หรือ slide. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนเฉพาะพื้นหลังของ master อาจไม่เปลี่ยนสไลด์นั้น. ใช้ [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดแล้ว.

{{% alert color="warning" title="Warning" %}}
อย่าใช้ดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มที่ศูนย์. หลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วถือว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นลักษณะเฉพาะของการนำเสนอ.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/python-java/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

โครงสร้างรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟ็กต์แยกกันที่เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). ธีมของ Office ส่วนใหญ่มักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับรูปแบบ Subtle, Moderate, และ Intense, แต่ควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานจำนวนคงที่.

![เอฟเฟ็กต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน Python ผ่าน Java, ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปเป็นแนวคิดแยก, เปิดเผยโดย [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะมีผลต่อรูปที่อ้างอิงสไตล์ธีมนั้น; รูปที่ฟอร์แมตโดยตรงอาจคงเดิม.

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดใช้เงานอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับรูปที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์การเติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงานอกระยะ 10 จุด. ผลลัพธ์ภาพสุดท้ายยังคงขึ้นกับว่ารูปใดอ้างอิงช่องสไตล์และว่าฟอร์แมตโดยตรงได้แทนที่ธีมหรือไม่.

![สไตล์เอฟเฟ็กต์ธีมหลังจากการเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูป**

รูปสามารถเลือกการเติมและขอบโดยอิสระผ่าน [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) และ [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). สำหรับแต่ละเมธอด, ดัชนี `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`get_Item(0)`), ดัชนี `2` เลือกรายการที่สอง (`get_Item(1)`).

ตัวอย่างต่อไปนี้ตั้งค่าสองสไตล์การเติม (ทองและสีฟ้าอทิม) และสองสไตล์เส้น (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่. มันบันทึกสไลด์ในสามช่วงเพื่อให้คุณสามารถเปรียบเทียบผลลัพธ์ใน PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| สไตล์เริ่มต้น | เปลี่ยนขอบด้านขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมทองและสีน้ำฟ้าแถบขอบสีน้ำเงินเข้มบาง](theme-style-initial.png) | ![สี่เหลี่ยมสีน้ำฟ้าตอนนี้มีขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมด้านซ้ายตอนนี้เป็นสีเขียวและขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนเฉพาะขอบของสี่เหลี่ยมด้านขวา. การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปที่ใช้มัน. ในตัวอย่างนี้, เฉพาะสี่เหลี่ยมด้านซ้ายจึงเปลี่ยนเป็นสีเขียว.

บนรูปที่มีอยู่, สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถแทนที่ส่วนของสไตล์ธีมนั้นได้. หากการเปลี่ยนดัชนีสไตล์ไม่มีผลที่มองเห็น, ตรวจสอบ [การฟอร์แมตโดยตรง](/slides/th/python-java/shape-formatting/) ของรูปนั้น.

## **ตรวจสอบว่าการเติมแบบ Solid ที่มีผลใช้สีธีมหรือไม่**

การเติมอาจจัดเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, layout, master, สไตล์ธีม, หรือระดับฟอร์แมตอื่น. เรียก [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) เพื่อแก้ลำดับชั้นนั้นเป็นข้อมูลการเติมที่ไม่เปลี่ยนแปลง. ก่อนอ่านคุณสมบัติการเติมแบบ Solid, ตรวจสอบ `getFillType` บนวัตถุข้อมูลที่มีผล. เฉพาะเมื่อเป็น `FillType.Solid` จึงควรอ่านคุณสมบัติการเติมแบบ Solid.

สำหรับการเติมแบบ Solid, `getSolidFillColor` คืนค่ารหัส RGB สุดท้ายหลังการสืบทอด, การค้นหาธีม, และการแปลงสี. `getSolidFillSchemeColor` คืนช่อง [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) ที่สอดคล้อง, เช่น `Text1` หรือ `Accent6`. ค่า `SchemeColor.NotDefined` หมายความว่าการเติมแบบ Solid ที่มีผลไม่ได้อ้างอิงจากสีสคีม. ในเวิร์กโฟลว์ที่การเติมเป็นสีธีมหรือสี RGB โดยตรง, ค่านี้บ่งบอกว่าเป็นการเติมสี RGB โดยตรง.

อย่าใช้ค่าท้องถิ่นของ [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) เพียงอย่างเดียวเพื่อจำแนกการเติม. ตัวอย่างเช่น, ส่วนของข้อความอาจไม่มีค่า SchemeColor ที่กำหนดท้องถิ่น, ดังนั้นค่าท้องถิ่นจะเป็น `NotDefined`, ในขณะที่การเติมที่มีผลสืบทอดจากธีมและแก้เป็น `Text1` หรือ `Accent6`. ในทางกลับกัน, `getSolidFillSchemeColor` บอกว่าช่องสคีมใดสร้างสีที่มีผล, แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, layout, master, หรือระดับอื่นใดของลำดับฟอร์แมต.

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของรูปและการเติมของส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสคีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมแบบ Solid ที่จะไม่ตามการเปลี่ยนสีธีม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

สาขา `NotDefined` ให้รายการการตรวจสอบของการเติมแบบ Solid ที่จะไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม. ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจำเป็นต้องปฏิบัติตามจานสีแบรนด์ใหม่. ค่า RGB ที่รายงานยังคงแสดงลักษณะปัจจุบัน, ส่วนค่าสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่.

วัตถุที่มีฟอร์แมตแบบมีผลเป็นภาพ snapshot. หลังจากเปลี่ยนธีมการนำเสนอ, การแทนที่ธีม, หรือฟอร์แมตที่สืบทอดใด ๆ, เรียก `getEffective` อีกครั้งและอ่านวัตถุข้อมูลการเติมที่มีผลใหม่ก่อนเปรียบเทียบหรือรายงานสี.

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใด. ค่าที่มีผลบอกว่าสไลด์หรือรูปใช้สิ่งใดหลังจากการสืบทอดและการแทนที่ท้องถิ่นถูกแก้ไขแล้ว. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme), คุณอาจพลาดการแทนที่ที่ระดับ master, layout, slide, หรือรูปที่เปลี่ยนลักษณะสุดท้าย.

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นอยู่กับ master ที่เลือก. สไลด์ที่ใช้ master อื่นจะคงธีมเดิมไว้.

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยน master ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ของมัน. การเปลี่ยนแปลงจะอยู่ภายในสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมที่มีอยู่.

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อนำสไลด์และคงลักษณะต้นฉบับ, โคลน master ต้นฉบับไปยังปลายทางและโคลนสไลด์พร้อม master นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) และ [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). วิธีนี้ทำให้ master, layout, และธีมคงอยู่ด้วยกัน.

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) สำหรับธีมของสไลด์หรือ layout และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับวัตถุฟอร์แมตเช่น [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) และ [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). API เหล่านี้คืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่.