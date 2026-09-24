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
- จัดการหัวข้อแบบสัญลักษณ์
- การเยื้องย่อหน้า
- การเยื้องแบบห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อแบบสัญลักษณ์
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนข้อความ หัวข้อ รายการลำดับเลข การเยื้อง เนื้อหา HTML และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วน:

* [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) แสดงถึงคอนเทนเนอร์ของข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) แสดงถึงย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนและการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) แสดงถึงรันของข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้นย่อหน้าจึงสามารถมีข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ที่ต่างกันได้โดยใช้หลายส่วน

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วน**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีสามย่อหน้า แต่ละย่อหน้ามีสามส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) สี่เหลี่ยมรูปแบบลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) เพิ่มอีกสองอันลงในกรอบข้อความ
6. เพิ่มวัตถุ [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) ให้เพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสามส่วน ย่อหน้าเริ่มต้นมีส่วนว่างหนึ่งส่วนอยู่แล้ว
7. กำหนดข้อความของแต่ละส่วน
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getPortionFormat)
9. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Python นี้ทำตามขั้นตอนเหล่านั้น:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
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

## **สร้างรายการแบบหัวข้อและลำดับเลข**

### **สร้างรายการแบบหัวข้อหรือแบบลำดับเลข**

หัวข้อและลำดับเลขทำให้การสแกนรายการที่เกี่ยวข้องง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Symbol) และระบุอักขระหัวข้อ
8. ตั้งค่าข้อความย่อหน้า ระยะเยื้อง สีหัวข้อ และความสูงหัวข้อ
9. เพิ่มย่อหน้าเข้ากรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Numbered)
11. กำหนดรูปแบบหัวข้อเป็นลำดับเลขและเพิ่มย่อหน้าเข้ากรอบข้อความ
12. บันทึกการนำเสนอ

ตัวอย่าง Python นี้สร้างหัวข้อสัญลักษณ์และหัวข้อเป็นลำดับเลข:

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

หัวข้อรูปภาพทำให้คุณสามารถใช้ภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลขได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดภาพหัวข้อและเพิ่มลงในคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) และกำหนดข้อความของมัน
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Picture)
8. กำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#getPicture) และตั้งค่าความสูงหัวข้อ
9. เพิ่มย่อหน้าเข้ากรอบข้อความ
10. บันทึกการนำเสนอที่แก้ไขแล้ว

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

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อให้แต่ละย่อหน้า
4. ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setDepth) ของพวกมันเป็น `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเข้ากรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง Python นี้สร้างรายการหัวข้อสี่ระดับ:

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

### **เริ่มรายการที่มีลำดับเลขด้วยค่าที่กำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เพื่อตั้งค่าตัวเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ลงในสไลด์หนึ่งสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง
3. สร้างย่อหน้าลำดับเลขสามย่อหน้า
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) ให้เป็น `2`, `3`, และ `7` สำหรับย่อหน้าแต่ละอัน
5. เพิ่มย่อหน้าเข้ากรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง Python นี้กำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติตอนจบ**

### **ตั้งระยะเยื้องบรรทัดแรก**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อควบคุมระยะเยื้องของบรรทัดแรกของย่อหน้า วิธีนี้จะเลื่อนบรรทัดแรกเท่านั้นเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามตำแหน่งของย่อหน้า

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) เมื่อจำเป็นต้องเลื่อนย่อหน้าเต็มบรรทัด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เมื่อต้องการเลื่อนเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและใช้ค่าต่าง ๆ ของ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อแสดงผลว่าระยะเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) สี่เหลี่ยมรูปแบบลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่าระยะเยื้องบรรทัดแรกที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเข้ากรอบข้อความ
7. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งระยะเยื้องย่อหน้า:

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

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งระยะเยื้องแบบห้อย**

ระยะเยื้องแบบห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) โดยใส่ค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า

ในทางปฏิบัติ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบซ้ายนั้น เพื่อตั้งระยะเยื้องแบบห้อยให้ใส่ค่าบวกใน [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) และค่าลบใน [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent)

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม การอ้างอิง รายการศัพท์ และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ต่อเนื่องอยู่ใต้เนื้อหาย่อหน้าไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) สี่เหลี่ยมรูปแบบลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและใส่ค่าบวกใน [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) สำหรับแต่ละย่อหน้า
6. ใส่ค่าลบใน [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อสร้างเอฟเฟ็กต์ระยะเยื้องแบบห้อย
7. เพิ่มย่อหน้าเข้ากรอบข้อความ
8. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งระยะเยื้องแบบห้อยสำหรับย่อหน้า:

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

![ระยะเยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติรันของย่อหน้าสิ้นสุด**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองย่อหน้าและเพิ่มส่วนข้อความลงในแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLatinFont)
6. กำหนดรูปแบบด้วย [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) แล้วบันทึกการนำเสนอ

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

ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getLinesCount) เพื่อนับบรรทัดที่ย่อหน้าครอบครองหลังจากการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อทำการตรวจสอบความยาวข้อความและการจัดวางในเทมเพลตการนำเสนอ

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParagraphs) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดโดยตรงในย่อหน้าจะบังคับให้เกิดบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีให้โดยไม่แทรกอักขระการตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดจึงไม่ได้ให้จำนวนบรรทัดที่แสดงผลจริง

ตัวอย่างต่อไปนี้สร้างรูปข้อความ นับจำนวนบรรทัด ลดความกว้างของรูป แล้วแทนที่ข้อความด้วยสตริงสั้น การตัดบรรทัดเปิดใช้งานและการปรับขนาดอัตโนมัติปิดเพื่อให้ความกว้างของรูปควบคุมการตัดบรรทัดโดยไม่ย่อข้อความหรือปรับขนาดรูป มิติของรูปเป็นจุด สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ

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

ด้วยข้อความและมิตินี้ การทำให้รูปแคบลงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัดจำนวนที่แน่นอนอาจแตกต่างกันตามฟอนต์ที่ใช้ การทดแทน ฟอนต์ขนาด, ขอบ, ระยะเยื้อง, การตัดบรรทัด และการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้กำหนดว่าข้อความจะล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้, ความสูงบรรทัด, ระยะห่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็สำคัญ; แม้แต่บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้าข้อความ HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#addFromHtml) เพื่อแปลงมาร์กอัป HTML เป็นย่อหน้าและส่วนในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ไปที่ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#addFromHtml)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Python นี้นำเข้า HTML ไปยังกรอบข้อความ:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#exportToHtml) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ที่มีข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปทรง
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#exportToHtml) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้รับกลับไปยังไฟล์

ตัวอย่าง Python นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

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

[Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนออบเจ็กต์ภาพ บันทึกผลลัพธ์ไปยังไฟล์หรือสตรีมด้วยเมธอด `save` ไม่จำเป็นต้องเรนเดอร์รูปที่บรรจุหรือครอบภาพด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) อาจคืนค่า `None` หากไม่พบย่อหน้าในคอลเลกชันแม่ ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำความสะอาดภาพที่ได้รับหลังการใช้งาน

#### **เรนเดอร์ย่อหน้าในสเกลเริ่มต้น**

สมมุติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG บล็อก `finally` รับประกันว่าภาพจะถูกทำความสะอาดอย่างถูกต้อง

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

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อกำหนดค่าสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง เรนเดอร์ย่อหน้าในเซลล์แรกโดยเพิ่มขนาดตรวกรูปสองเท่าของความกว้างและความสูงเริ่มต้น แล้วบันทึกผลเป็นภาพ PNG

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

ค่าสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น เช่น `2` สำหรับทั้งสองค่า จะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ส่งผลให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า การใช้ค่าสเกลที่ใหญ่กว่าจะทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าสเกลต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้ค่าสเกลเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ค่าสเกลแนวนอนและแนวตั้งที่แตกต่างกันจะยืดผลลัพธ์อย่างอิสระ

การเรนเดอร์รูปทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) ยังมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสีของรูป ขอบ หรือบริบทภาพอื่น ๆ สำหรับภาพที่มีแต่ย่อหน้าอย่างเดียว ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน TextFrame ได้อย่างสมบูรณ์หรือไม่?**

ใช่ ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setWrapText) เพื่อปิดการตัดบรรทัด เพื่อให้บรรทัดไม่ตัดที่ขอบของ TextFrame

**ฉันจะทำอย่างไรให้ได้ขอบเขตบนสไลด์ที่แม่นยำของย่อหน้าเฉพาะ?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getRect) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [Portion.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getRect) ให้ขอบของส่วนแต่ละส่วน

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง, หรือ จัดเต็ม) ควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนแต่ละส่วน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้ ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับส่วนแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาควบคู่กันได้