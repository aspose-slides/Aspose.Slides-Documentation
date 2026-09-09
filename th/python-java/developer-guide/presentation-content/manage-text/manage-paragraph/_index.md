---
title: "จัดการย่อหน้าข้อความ PowerPoint ใน Python ผ่าน Java"
linktitle: "จัดการย่อหน้า"
type: docs
weight: 40
url: /th/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- "เพิ่มข้อความ"
- "เพิ่มย่อหน้า"
- "จัดการข้อความ"
- "จัดการย่อหน้า"
- "จัดการสัญลักษณ์หัวข้อย่อย"
- "เยื้องย่อหน้า"
- "เยืึงแบบห้อย"
- "สัญลักษณ์หัวข้อย่อหน้า"
- "รายการลำดับเลข"
- "รายการสัญลักษณ์หัวข้อย่อย"
- "คุณสมบัติย่อหน้า"
- "นำเข้า HTML"
- "ข้อความเป็น HTML"
- "ย่อหน้าเป็น HTML"
- "ย่อหน้าเป็นภาพ"
- "ข้อความเป็นภาพ"
- "ส่งออกย่อหน้า"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Java"
- "Aspose.Slides"
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, สัญลักษณ์หัวข้อย่อย, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java แสดงข้อความเป็นลำดับชั้นของ text frames, paragraphs, และ portions:

* [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) เป็นตัวบรรจุข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) เป็นย่อหน้าใน text frame หนึ่งรายการและให้การเข้าถึง portions และการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) เป็นช่วงข้อความภายในย่อหน้า แต่ละ Portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่ใช้แบบอักษร สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยการใช้หลาย Portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้จะสร้าง text frame ที่มีสามย่อหน้า แต่ละย่อหน้ามีสาม Portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่าง  
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) เพิ่มอีกสองรายการไปยัง TextFrame  
6. เพิ่มวัตถุ [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) ให้เพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสาม Portion. ย่อหน้าเริ่มต้นมี Portion ว่างหนึ่งรายการอยู่แล้ว  
7. กำหนดข้อความของแต่ละ Portion  
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getPortionFormat)  
9. บันทึกการนำเสนอที่แก้ไข  

ตัวอย่าง Python นี้ทำตามขั้นตอนข้างต้น:

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

## **สร้างรายการแบบสัญลักษณ์หัวข้อย่อยและลำดับเลข**

### **สร้างรายการแบบสัญลักษณ์หัวข้อย่อยหรือรายการลำดับเลข**

สัญลักษณ์หัวข้อย่อยและการนับเลขช่วยให้การสแกนรายการที่เกี่ยวข้องทำได้ง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/)  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่าง  
5. ลบย่อหน้าเริ่มต้นออกจาก TextFrame  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) สำหรับสัญลักษณ์หัวข้อย่อย  
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Symbol) และระบุตัวอักษรสัญลักษณ์หัวข้อย่อย  
8. ตั้งค่าข้อความย่อหน้า ระยะเยื้อง สีหัวข้อย่อย และความสูงหัวข้อย่อย  
9. เพิ่มย่อหน้าลงใน TextFrame  
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Numbered)  
11. กำหนดสไตล์หัวข้อย่อยแบบลำดับเลขและเพิ่มย่อหน้าลงใน TextFrame  
12. บันทึกการนำเสนอ  

ตัวอย่าง Python นี้สร้างสัญลักษณ์หัวข้อย่อยและหัวข้อย่อยแบบลำดับเลข:

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

### **ใช้รูปภาพเป็นหัวข้อย่อย**

รูปภาพหัวข้อย่อยทำให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือเลขได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของมัน  
4. ลบย่อหน้าเริ่มต้นออกจาก TextFrame  
5. โหลดภาพหัวข้อย่อยและเพิ่มลงในคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/)  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน  
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/bullettype/#Picture)  
8. กำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#getPicture) และตั้งค่าความสูงหัวข้อย่อย  
9. เพิ่มย่อหน้านั้นลงใน TextFrame  
10. บันทึกการนำเสนอที่แก้ไข  

ตัวอย่าง Python นี้สร้างหัวข้อย่อยรูปภาพ:

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

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`  

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์  
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจาก TextFrame ของมัน  
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อย่อยให้แต่ละอัน  
4. ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setDepth) ของพวกมันเป็น `0`, `1`, `2` และ `3` ตามลำดับ  
5. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame แล้วบันทึกการนำเสนอ  

ตัวอย่าง Python นี้สร้างรายการหัวข้อย่อยสี่ระดับ:

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

### **กำหนดค่าการเริ่มต้นของรายการลำดับเลขด้วยเลขที่กำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เพื่อกำหนดเลขเริ่มต้นที่แสดงสำหรับย่อหน้าที่เป็นลำดับเลข  

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ไปยังสไลด์หนึ่งสไลด์  
2. ลบย่อหน้าเริ่มต้นออกจาก TextFrame ของรูปร่าง  
3. สร้างย่อหน้าลำดับเลขสามรายการ  
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เป็น `2`, `3` และ `7` สำหรับย่อหน้าแต่ละอันตามลำดับ  
5. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame แล้วบันทึกการนำเสนอ  

ตัวอย่าง Python นี้กำหนดเลขเริ่มต้นที่กำหนดเองให้แต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติส่วนสิ้นสุด**

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อควบคุมการเยื้องของบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ในแนวเดียวกับเนื้อหาย่อหน้า  

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก  

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและกำหนดค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) ที่แตกต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น  
5. สร้างหลายย่อหน้าและกำหนดค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) ที่แตกต่างกันสำหรับแต่ละย่อหน้า  
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame  
7. บันทึกการนำเสนอที่แก้ไข  

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

### **ตั้งค่าเยื้องแบบห้อย**

เยื้องแบบห้อยคือการจัดวางย่อหน้าโดยบรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) โดยใส่ค่าเป็นลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า  

โดยปกติ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้าและ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้ายนั้น หากต้องการเยื้องแบบห้อย ให้ใส่ค่าเป็นบวกกับ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) แล้วใส่ค่าลบกับ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent)  

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, อ้างอิง, รายการพจนานุกรม และย่อหน้าอื่น ๆ ที่บรรทัดที่หักต้องอยู่ใต้เนื้อหาย่อหน้า แทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น  
5. สร้างย่อหน้าและใส่ค่าเป็นบวกกับ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setMarginLeft) สำหรับแต่ละย่อหน้า  
6. ใส่ค่าลบกับ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setIndent) เพื่อสร้างเอฟเฟกต์เยื้องแบบห้อย  
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame  
8. บันทึกการนำเสนอที่แก้ไข  

โค้ดนี้แสดงวิธีตั้งค่าเยื้องแบบห้อยสำหรับย่อหน้า:

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

![การเยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติส่วนสิ้นสุดของย่อหน้า**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์  
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน  
3. สร้างย่อหนสองรายการและเพิ่ม Portion ของข้อความลงในแต่ละย่อหน้า  
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง  
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLatinFont)  
6. กำหนดรูปแบบด้วย [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) และบันทึกการนำเสนอ  

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#addFromHtml) เพื่อแปลงมาร์กอัป HTML เป็นย่อหน้าและ Portion ใน text frame  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)  
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น  
4. อ่านไฟล์ HTML ต้นฉบับ  
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#addFromHtml)  
6. บันทึกการนำเสนอที่แก้ไข  

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#exportToHtml) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ  
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ที่มีข้อความ  
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ของรูปร่าง  
4. เรียกใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphcollection/#exportToHtml) พร้อมระบุดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก  
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

### **แสดงย่อหน้าเป็นรูปภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) แสดงย่อหน้าเดี่ยวโดยตรงและคืนออบเจกต์รูปภาพ บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วยเมธอด `save` คุณไม่จำเป็นต้องแสดงรูปร่างที่บรรจุหรือครอปบิตแมพด้วยตนเอง  

[Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) อาจคืนค่า `None` หากไม่พบย่อหน้าในคอลเลกชันแม่ มีขอบเขตการเรนเดอร์ที่ไม่ถูกต้อง หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายออบเจกต์รูปภาพหลังการใช้  

#### **แสดงย่อหน้าที่สเกลเริ่มต้น**

สมมติว่ามีไฟล์การนำเสนอชื่อ sample.pptx มีสไลด์หนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า  

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดงย่อหน้าที่สองในรูปทรงข้อความปกติที่สเกลเริ่มต้นและบันทึกรูปภาพที่ได้ในรูปแบบ PNG บล็อก `finally` จะทำให้แน่ใจว่ารูปภาพถูกทำลายอย่างถูกต้อง  

```python
import jpime
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

![รูปภาพย่อหน้า](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/) ที่รับพารามิเตอร์ `scale_x` และ `scale_y` เพื่อกำหนดปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง แสดงย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น แล้วบันทึกผลลัพธ์เป็นรูป PNG  

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

ค่าปัจจัยสเกล `1` จะรักษาขนาดพิกเซลเริ่มต้นของแกนนั้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของขนาดเริ่มต้น ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่ใหญ่กว่าจะทำให้ข้อความคมชัดขึ้นสำหรับการขยายหรือเอาท์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยต่ำกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดลดลง ใช้ปัจจัยเท่ากันเพื่อรักษาส่วนสัดส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกตามอิสระ  

การแสดงรูปทรงทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อเอาท์พุตต้องรวมการเติมสี เส้นขอบ หรือบริบทภาพอื่น ๆ ของรูปทรง สำหรับภาพที่มีแต่ย่อหน้าเท่านั้น ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/)  

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setWrapText) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะได้ขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างแม่นยำอย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/#getRect) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า [Portion.getRect](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getRect) ให้ขอบเขตของ Portion รายบุคคล

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraphformat/#setAlignment) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบ Portion แยกต่างหาก

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ Portion แต่ละอัน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาควบคู่กันได้.