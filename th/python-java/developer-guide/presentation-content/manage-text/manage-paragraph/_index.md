---
title: จัดการย่อหน้าข้อความ PowerPoint ด้วย Python ผ่าน Java
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
- จัดการจุดหัวข้อ
- เยื้องย่อหน้า
- เยื้องห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
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

Aspose.Slides for Python via Java แสดงข้อความเป็นโครงสร้างชั้นของ text frame, paragraph และ portion:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) แสดงถึงคอนเทนเนอร์ของข้อความในรูปทรงและให้การเข้าถึงชุด paragraph ของมัน
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) แสดงถึงย่อหน้าเดียวใน text frame และให้การเข้าถึง portion และการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) แสดงถึงรันของข้อความภายในย่อหน้า แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์, สี, ขนาดและการจัดรูปแบบอื่น ๆ แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้สร้าง text frame ที่มีสามย่อหน้า แต่ละย่อหน้ามีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มอีกสองออบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ไปยัง text frame
6. เพิ่มออบเจ็กต์ [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) ให้เพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสาม portion ส่วนย่อหน้าเริ่มต้นมี portion ว่างเปล่าอยู่แล้วหนึ่งออบเจ็กต์
7. ตั้งค่าข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat)
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Python นี้ทำตามขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบมีหัวข้อและลำดับเลข**

### **สร้างรายการแบบมีหัวข้อหรือเลข**

หัวข้อและลำดับเลขทำให้รายการที่เกี่ยวข้องง่ายต่อการสแกน ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรง
5. ลบย่อหน้าเริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) สำหรับหัวข้อแบบสัญลักษณ์
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) และระบุอักขระหัวข้อ
8. ตั้งค่าข้อความย่อหน้า, การเยื้อง, สีหัวข้อและความสูงหัวข้อ
9. เพิ่มย่อหน้าไปยัง text frame
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered)
11. กำหนดสไตล์หัวข้อแบบลำดับเลขและเพิ่มย่อหน้าไปยัง text frame
12. บันทึกงานนำเสนอ

ตัวอย่าง Python นี้สร้างหัวข้อแบบสัญลักษณ์และหัวข้อแบบลำดับเลข:

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

### **ใช้หัวข้อรูปภาพ**

หัวข้อรูปภาพทำให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจาก text frame
5. โหลดภาพหัวข้อและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture)
8. กำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) และตั้งค่าความสูงหัวข้อ
9. เพิ่มย่อหน้าไปยัง text frame
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Python นี้สร้างหัวข้อรูปภาพ:

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

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางย่อหน้าที่ระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจาก text frame ของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อสำหรับแต่ละย่อหน้า
4. ตั้งค่าค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) เป็น `0`, `1`, `2` และ `3`
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame และบันทึกงานนำเสนอ

ตัวอย่าง Python นี้สร้างรายการหัวข้อระดับสี่:

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

### **เริ่มหมายเลขหัวข้อจากค่าที่กำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เพื่อกำหนดหมายเลขเริ่มต้นของย่อหน้าที่เป็นลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ลงในสไลด์
2. ลบย่อหน้าเริ่มต้นออกจาก text frame ของรูปทรง
3. สร้างย่อหน้าลำดับเลขสามออบเจ็กต์
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เป็น `2`, `3` และ `7` สำหรับย่อหน้าแต่ละออบเจ็กต์
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame และบันทึกงานนำเสนอ

ตัวอย่าง Python นี้กำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้แต่ละย่อหน้า:

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

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นแล้วแต่ระยะของย่อหน้าด้านซ้าย ค่าเป็นบวกจะทำให้บรรทัดแรกเลื่อนไปขวา ส่วนบรรทัดที่เหลือคงอยู่ตามตำแหน่งของเนื้อหาย่อหน้า

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) เมื่อจำเป็นต้องย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เมื่อต้องการย้ายเพียงบรรทัดแรก

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและใช้ค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) ที่แตกต่างกันเพื่อแสดงว่าเยื้องบรรทัดแรกส่งผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่าค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) ที่ต่างกันสำหรับแต่ละออบเจ็กต์
6. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องย่อหน้า:

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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

### **ตั้งค่าเยื้องห้อย**

เยื้องห้อยเป็นการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) ให้ค่าเป็นลบเพื่อย้ายบรรทัดแรกไปทางซ้ายของเนื้อหาย่อหน้า

โดยทั่วไป [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างเยื้องห้อย ให้กำหนดค่าเป็นบวกกับ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) และเป็นลบกับ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, อ้างอิง, รายการอภิธานศัพท์และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ย่อมงัดอยู่ใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและกำหนดค่าเป็นบวกกับ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) สำหรับแต่ละย่อหน้า
6. กำหนดค่าเป็นลบกับ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อสร้างเอฟเฟกต์เยื้องห้อย
7. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องห้อยสำหรับย่อหน้า:

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

![การเยื้องห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติ End ของย่อหน้า**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองออบเจ็กต์และเพิ่ม portion ของข้อความเข้าไป
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont)
6. นำฟอร์แมตไปใช้ด้วย [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) แล้วบันทึกงานนำเสนอ

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

## **นับบรรทัดที่แสดงผล**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่จุดสิ้นสุดบรรทัด ดูคำอธิบายที่ [ควบคุมการตัดบรรทัด](/slides/th/python-java/text-formatting/#control-line-breaking) และ [ควบคุมเครื่องหมายวรรคตอนที่ห้อย](/slides/th/python-java/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) เพื่อนับจำนวนบรรทัดที่ย่อหน้าครอบครองหลังจากจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อทำการตรวจสอบความยาวและการจัดวางข้อความในเทมเพลตของงานนำเสนอ

ย่อหน้าเป็นรายการหนึ่งรายการใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดโดยตรงภายในย่อหน้าจะทำให้เกิดบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกตัวอักษรการตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระการตัดบรรทัดจะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้น ผลการตัดบรรทัดเปิดอยู่และ autofit ปิดอยู่เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ได้ย่อข้อความหรือปรับขนาดรูปทรง ขนาดของรูปทรงเป็นหน่วยจุด สุดท้ายตัวอย่างเพิ่มย่อหน้าอีกหนึ่งออบเจ็กต์และรวมจำนวนบรรทัดทั้งหมดจาก text frame

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

ด้วยข้อความและขนาดนี้ การทำให้รูปทรงแคบลงจะเพิ่มจำนวนบรรทัด ส่วนการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามฟอนต์ที่มีและการทดแทน ขนาดฟอนต์, ขอบ, ระยะเยื้อง, การตัดบรรทัดและการตั้งค่า autofit ใช้ฟอนต์และการจัดวางที่ตั้งใจใช้ในสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นพื้นที่ของคอนเทนเนอร์หรือไม่ ความสูงที่มี, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็มีผลเช่นกัน; แม้แต่บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ข้อความเข้าสู่ย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) เพื่อแปลง markup ของ HTML เป็นย่อหน้าและ portion ใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. อ่านไฟล์ HTML แหล่งข้อมูล
5. ส่งสตริง HTML ให้กับ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Python นี้นำเข้า HTML ไปยัง text frame:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) เพื่อส่งออกช่วงของย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) แล้วโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ที่มีข้อความอยู่
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ของรูปทรง
4. เรียกใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) โดยระบุดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง Python นี้ส่งออกย่อหน้าทั้งหมดจากรูปทรงข้อความแรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) เรนเดอร์ย่อหน้าแต่ละออบเจ็กต์โดยตรงและคืนออบเจ็กต์ภาพ บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วยเมธอด `save` คุณไม่จำเป็นต้องเรนเดอร์รูปทรงทั้งหมดหรือครอบตัดบิทแมพด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) อาจคืนค่า `None` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมุติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่บรรจุสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปทรงข้อความทั่วไปที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG บล็อก `finally` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง

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

ใช้ overload ของ [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อกำหนดอัตราสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG

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

ค่าอัตราสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะสร้างภาพที่ความกว้างและความสูงประมาณสองเท่าของขนาดเริ่มต้น ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า อัตราสเกลที่ใหญ่กว่ามักให้ข้อความคมชัดยิ่งขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าอัตราสเกลต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้อัตราสเกลเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; อัตราสเกลแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกอย่างอิสระ

การเรนเดอร์รูปทรงทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ยังมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่น ๆ ของรูปทรง สำหรับภาพเฉพาะย่อหน้า ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดภายใน text frame ได้ทั้งหมดหรือไม่?**

ใช่ ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่แตกที่ขอบของ text frame

**ฉันจะรับพิกัดบนสไลด์ที่แม่นยำของย่อหน้าที่เฉพาะได้อย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) ให้ขอบเขตของ portion แต่ละออบเจ็กต์

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดชิด) ถูกควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ portion แยกบุคคล

เพื่อจัดแนวฟอนต์ที่มีขนาดต่างกันภายในบรรทัดเดียวกัน ดูที่ [Align Fonts Within a Line](/slides/th/python-java/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ใช่ ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ portion แต่ละออบเจ็กต์ เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาได้