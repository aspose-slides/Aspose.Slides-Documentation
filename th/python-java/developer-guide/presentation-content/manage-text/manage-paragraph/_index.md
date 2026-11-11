---
title: จัดการย่อหน้าข้อความ PowerPoint ใน Python ผ่าน Java
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการ bullet
- เยื้องย่อหน้า
- เยื้องห้อย
- bullet ย่อหน้า
- รายการลำดับเลข
- รายการ bullet
- คุณสมบัติของย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java แสดงข้อความเป็นลำดับชั้นของ text frames, paragraphs, และ portions:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) เป็นตัวเก็บข้อความในรูปร่างและให้เข้าถึงคอลเลกชันของ paragraph
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) แทนย่อหน้าหนึ่งใน text frame และให้เข้าถึง portions และการจัดรูปแบบระดับ paragraph
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) แทนการไหลของข้อความภายใน paragraph แต่ละ portion สามารถมีข้อความของตนเองและการจัดรูปแบบระดับอักขระได้

ดังนั้นย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าใน text frame ของรูปร่างและใช้ portion เพื่อจัดรูปแบบการไหลของข้อความแต่ละส่วน ส่วนนี้แสดงวิธีการรวมหลาย portion ภายในแต่ละย่อหน้าและใช้สี ฟอนต์ขนาด และสไตล์ที่แตกต่างกัน

### **สร้างย่อหน้าด้วยหลาย Portion**

ตัวอย่าง Python ด้านล่างสร้างย่อหน้า 3 ย่อหน้า แต่ละย่อหน้ามี portion 3 ส่วนในคอลเลกชันที่ส่งคืนโดย [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions) ตัวอย่างใช้ paragraph เริ่มต้นและ portion ว่างของมัน แล้วเพิ่ม paragraph และ portion ที่เหลือ การจัดรูปแบบทำผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat): portion แรกในแต่ละย่อหน้ามีสีแดง, ตัวหนา, ขนาด 15 pt; ส่วนที่สองมีสีน้ำเงิน, ตัวเอียง, ขนาด 18 pt; ส่วนที่สามคงการจัดรูปแบบเริ่มต้นไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()

    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())

    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)

    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")

            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างรายการแบบ Bulleted และ Numbered**

จัดข้อความย่อหน้าเป็นรายการที่มีสัญลักษณ์ ตัวเลข หรือภาพกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบ bullet, รายการหลายระดับ, และการกำหนดหมายเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการ Bulleted หรือ Numbered**

Bullet และการจัดลำดับทำให้การสแกนรายการที่เกี่ยวข้องง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/)

ตัวอย่าง Python นี้เพิ่ม bullet สัญลักษณ์และรายการเลขลำดับใน text frame เดียวกัน [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เลือกประเภท bullet, ขณะเดียวกัน [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) ระบุสัญลักษณ์และ [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) เลือกสไตล์การจัดลำดับ ทั้งสองรายการใช้ bullet สีดำ ความสูง 100% และการเยื้องย่อหน้าที่ 25 pt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)

    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่าง Python นี้เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) และใช้เป็น bullet ของ paragraph โดยเรียก [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เพื่อใช้ picture bullet และกำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) ตั้งเป็น 100% เพื่อกำหนดขนาด bullet ให้สัมพันธ์กับข้อความย่อหน้า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **สร้างรายการหลายระดับ**

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมี depth เป็น `0`

ตัวอย่าง Python นี้กำหนดค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) ตั้งแต่ 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า สร้างลำดับชั้นภายใน text frame เดียวกัน แต่ละย่อหน้าใช้ bullet สัญลักษณ์ โดย [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) สลับกันระหว่าง bullet แบบกลมและ hyphen เพื่อแยกระดับที่อยู่ติดกัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)

    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)

    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)

    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **กำหนดค่าเริ่มต้นของรายการ Numbered ให้เป็นค่ากำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบ numbered

ตัวอย่าง Python นี้ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) ให้ใช้การจัดลำดับสำหรับย่อหน้า 3 รายการและกำหนดค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เป็น 2, 3, และ 7 ค่าการเริ่มต้นตั้งค่าแยกต่างหากในแต่ละย่อหน้า ทำให้หมายเลขที่แสดงสามารถข้ามค่าได้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)

    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติ End**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ห่อหุ้ม คุณยังสามารถจัดรูปแบบเครื่องหมายจบย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่า Indent ของบรรทัดแรก**

ใช้เมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า การตั้งค่านี้ย้ายเฉพาะบรรทัดแรกเทียบกับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงตำแหน่งตามเนื้อหาย่อหน้า

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) เดียวกันที่ 20 pt และค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เป็น 0, 20, และ 40 pt บรรทัดแรกเริ่มที่ระยะห่างที่เพิ่มขึ้นเรื่อย ๆ ขณะที่บรรทัดที่ห่อหุ้มคงระยะขอบซ้ายเท่าเดิม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)

    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติการ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) กำหนดตำแหน่งของบรรทัดแรกเทียบกับระยะขอบนั้น เพื่อสร้าง hanging indent ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, อ้างอิง, บันทึกศัพท์, และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ห่อหุ้มเรียงใต้เนื้อหาย่อหน้า แทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

ตัวอย่าง Python ด้านล่างจับคู่ค่า [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) เป็น 40 และ 60 pt กับค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เป็น -20 และ -30 pt ในแต่ละย่อหน้า บรรทัดแรกของแต่ละย่อหน้าเริ่มอยู่ทางซ้ายของบรรทัดที่ห่อหุ้ม ย่อหน้าที่สองมี hanging indent ที่ลึกกว่าที่หนึ่ง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การเยื้องแบบ hanging ของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติ End Paragraph Run**

เมธอด [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) โดยตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) เป็น 48 pt และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) เป็น Times New Roman แล้วกำหนดฟอร์แมตนี้ให้กับเครื่องหมายจบของย่อหน้าที่สองโดยไม่กระทบส่วนข้อความที่มองเห็น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)

    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)

    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **นับจำนวนบรรทัดที่แสดงผล**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการห่อหุ้มอัตโนมัติและการวางเครื่องหมายจุลภาคที่จบบรรทัด ดูที่ [Control Line Breaking](/slides/th/python-java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/python-java/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) เพื่อคำนวณจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดวางข้อความ รวมการห่อหุ้มอัตโนมัติ ซึ่งเป็นประโยชน์เมื่อเช็คความยาวของข้อความและการจัดวางในเทมเพลตพรีเซนเทชัน

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่ line break แบบชัดเจนภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การห่อหุ้มอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรก line break ลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระ line‑break จะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้าง shape ของข้อความ, นับบรรทัด, ลดความกว้างของ shape, จากนั้นแทนข้อความด้วยสตริงที่สั้นลง ตัวอย่างเปิดใช้งานการห่อหุ้มด้วย [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) และปิดการ autofit ด้วย [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) เพื่อให้ความกว้างของ shape ควบคุมการห่อหุ้มโดยไม่ทำให้ข้อความหดหรือปรับขนาด shape ทุกการวัดใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) มิติของ shape อยู่ในหน่วย point สุดท้ายตัวอย่างเพิ่มย่อหน้าอีกหนึ่งบรรทัดและรวมจำนวนบรรทัดของทุกย่อหน้าใน text frame:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

ด้วยข้อความและมิติข้างต้น การลดความกว้างของ shape จะเพิ่มจำนวนบรรทัด ส่วนการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามการมีฟอนต์และการแทนที่, ขนาดฟอนต์, ระยะขอบ, การเยื้อง, การห่อหุ้ม, และการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างของย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็มีผลเช่นกัน; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการห่อหุ้ม

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่พรีเซนเทชันหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีการเรนเดอร์ย่อหน้าแต่ละอันเป็นภาพ รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML Text เข้าไปย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) เพื่อแปลง markup HTML เป็นย่อหน้าและ portion ใน text frame

ตัวอย่าง Python นี้อ่าน HTML จากไฟล์และส่ง markup ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) มันล้าง paragraph เริ่มต้นของ text frame เพื่อให้ frame มีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมจะเหลือมาร์จิน 10 pt ทุกด้านของสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)

        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) เพื่อส่งออกช่วงของย่อหน้าที่เลือกเป็น HTML เมื่อใช้ข้อความพรีเซนเทชันบนเว็บไซต์ คุณอาจต้องการรักษาการเน้นแบบ local โดยไม่ต้องพกฟอนต์, ขนาด หรือสไตล์ของกล่องข้อความของพรีเซนเทชัน ตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) เพื่อควบคุมว่าตัวส่งออกจะตามการสืบทอดการจัดรูปแบบไกลแค่ไหน

ดาวน์โหลด [ตัวอย่างพรีเซนเทชัน](text-inheritance.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมี shape ของข้อความหนึ่งอันที่มีข้อความ "Inherited text; explicit red 18pt" อินพุตใช้หลายระดับการจัดรูปแบบโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชันให้ฟอนต์ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของ text frame ให้สีฟ้าและตัวเอียง
- ย่อหน้ากำหนดตัวหนาอย่างชัดเจน
- Portion ที่สอง "explicit red 18pt" กำหนดสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง โดยส่งผ่าน [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและเขียนผลลัพธ์แต่ละอันเป็นไฟล์ HTML UTF‑8 แยกกัน:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

HTML ที่สร้างขึ้นมี CSS ต่อไปนี้สำหรับ portion แรก "Inherited text; " ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความกระจ่าง

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้า, ตัวหนา, ตัวเอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นมี |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้า, ตัวหนา, ตัวเอียง; ฟอนต์และขนาดจะมาจากหน้าเว็บหรือเบราว์เซอร์ |
| `ParagraphOnly.html` | `font-weight:bold` | ตัวหนา; ฟอนต์, ขนาด, สี, และสไตล์เอียงจะมาจากหน้าเว็บหรือเบราว์เซอร์ |

Portion ที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทั้งสามผลลัพธ์ นอกจากนี้ยังคงตัวเอียงใน `All` และ `TextBox` แต่ไม่คงใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ลบการจัดรูปแบบที่กำหนดให้กับย่อหน้าหรือ portion อย่างชัดเจน

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด CSS ที่ละเว้นจะถูกกำหนดโดยสไตล์ของหน้าเป้าหมายหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะสุดท้ายขึ้นกับที่ HTML ถูกใช้

### **สร้าง HTML Clipboard Fragment**

ใช้ [TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader) เพื่อเลือกรูปแบบผลลัพธ์ของ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) กำหนด `False` เมธอดจะคืน HTML ธรรมดา กำหนด `True` จะเพิ่มหัวส่วนคลิปบอร์ดของ Windows ฟิลด์ `StartHTML` และ `EndHTML` ให้ค่าออฟเซ็ตไบต์ของ HTML ฟิลด์ `StartFragment` และ `EndFragment` กำหนดส่วนที่ต้องวาง

ตัวอย่างนี้ส่งออกสองย่อหน้าที่จัดรูปแบบเป็น HTML ธรรมดา (`html`) และเป็นส่วนคลิปบอร์ด HTML (`clipboard_html`) แอปพลิเคชันสามารถเขียน fragment นี้ไปยังคลิปบอร์ดของระบบ หาก API ของคลิปบอร์ดคาดหวังไบต์ดิบ ให้ใช้ `clipboard_html.encode("utf-8")` เพื่อเข้ารหัส fragment โดยไม่ใส่ BOM

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextToHtmlConversionOptions

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 400, 100)
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    paragraphs.addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>")

    options = TextToHtmlConversionOptions()
    options.setAddClipboardFragmentHeader(False)
    html = str(paragraphs.exportToHtml(0, paragraphs.getCount(), options))

    options.setAddClipboardFragmentHeader(True)
    clipboard_html = str(paragraphs.exportToHtml(0, paragraphs.getCount(), options))
finally:
    presentation.dispose()
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) เรนเดอร์ย่อหน้าแต่ละอันโดยตรงและคืนอ็อบเจ็กต์ภาพ บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วยเมธอด `save` ไม่จำเป็นต้องเรนเดอร์ shape ที่บรรจุหรือครอปบิตแมพด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) อาจคืน `None` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนหลังการใช้งาน

#### **เรนเดอร์ย่อหน้าที่สเกลค่าเริ่มต้น**

ตัวอย่างใช้พรีเซนเทชันหนึ่งสไลด์ที่มี shape แรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ตำแหน่ง index 1 และเรียก [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) โดยไม่ระบุพารามิเตอร์สเกล ตรวจสอบว่า shape มีย่อหน้าที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียกเมธอด `save` เพื่อบันทึกเป็น PNG บล็อก `finally` ทำลายภาพหลังการใช้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()

            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อตั้งค่าสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลลัพธ์เป็น PNG

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])

    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")

    paragraph_image = paragraph.getImage(scale_x, scale_y)

    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

สเกลแฟกเตอร์ `1` คงแกนที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแฟกเตอร์จะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้มีพิกเซลสี่เท่า แฟกเตอร์ที่ใหญ่กว่าจะให้ข้อความคมชัดมากขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ แฟกเตอร์ที่ต่ำกว่า `1` จะให้ภาพที่เล็กลงและรายละเอียดน้อยลง ใช้แฟกเตอร์เท่ากันเพื่อคงอัตราส่วนของย่อหน้า; แฟกเตอร์แนวนอนและแนวตั้งที่แตกต่างกันจะยืดผลลัพธ์แยกจากกัน

การเรนเดอร์ shape ทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ยังมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของ shape สำหรับภาพเฉพาะย่อหน้า ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)

## **FAQ**

**สามารถปิดการห่อหุ้มบรรทัดใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) เพื่อปิดการห่อหุ้มให้บรรทัดไม่ตัดที่ขอบของ text frame

**จะรับค่าขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างแม่นยำอย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) ให้ขอบของ portion แยกแต่ละอัน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง, หรือเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ portion แยก

เพื่อจัดแนวแนวตั้งของ portion ที่มีขนาดฟอนต์ต่างกันภายในบรรทัดเดียวกัน ดูที่ [Align Fonts Within a Line](/slides/th/python-java/text-formatting/#align-fonts-within-a-line)

**สามารถตั้งค่าภาษา proofing ให้กับบางส่วนของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ portion แยก เพื่อให้ย่อหน้าสามารถมีข้อความหลายภาษาได้