---
title: จัดการรายการที่มีจุดหัวข้อและลำดับเลขในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/python-java/manage-lists/
keywords:
- จุดหัวข้อ
- รายการที่มีจุดหัวข้อ
- รายการลำดับเลข
- จุดหัวข้อสัญลักษณ์
- จุดหัวข้อรูปภาพ
- จุดหัวข้อกำหนดเอง
- รายการหลายระดับ
- สร้างจุดหัวข้อ
- เพิ่มจุดหัวข้อ
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการที่มีจุดหัวข้อ, จุดหัวข้อรูปภาพ, รายการหลายระดับ, และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ช่วยให้คุณสร้างและจัดรูปแบบรายการที่มีจุดหัวข้อและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการแต่ละรายการคือย่อหน้าที่การตั้งค่าจุดหัวข้อถูกควบคุมผ่านการจัดรูปแบบย่อหน้า

ใช้เมธอด [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) ซึ่งส่งคืนอ็อบเจ็กต์ [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าประเภทของจุดหัวข้อ สัญลักษณ์ รูปภาพ สี ขนาด รูปแบบการนับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธี:

- สร้างรายการที่มีจุดหัวข้อด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างจุดหัวข้อรูปภาพ
- สร้างรายการหลายระดับโดยกำหนดความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนแปลงการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านเครื่องหมายรายการและหมายเลขจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการที่มีจุดหัวข้อ**

เพื่อสร้างรายการที่มีจุดหัวข้อ ให้เพิ่มอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) ไปยัง [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) และตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) จากนั้นคุณสามารถใช้ [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) และ [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) เพื่อควบคุมลักษณะของจุดหัวข้อได้

โค้ด Python ต่อไปนี้แสดงวิธีสร้างรายการที่มีจุดหัวข้อบนสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![จุดหัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) คุณยังสามารถเลือกรูปแบบการนับเลขด้วย [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) หรือใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เมื่อรายการควรเริ่มที่ค่าที่ไม่ใช่ 1

โค้ด Python ต่อไปนี้แสดงวิธีสร้างรายการลำดับเลขบนสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![จุดหัวข้อแบบลำดับเลข](numbered_bullets.png)

## **สร้างจุดหัวข้อรูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์จุดหัวข้อปกติด้วยรูปภาพ จุดหัวข้อรูปภาพทำงานได้ดีที่สุดกับรูปภาพที่เรียบง่ายและอ่านได้ที่ขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งแสงขนาดเล็ก

{{% alert color="info" title="Note" %}}
หากคุณวางแผนที่จะแทนที่สัญลักษณ์จุดหัวข้อปกติด้วยรูปภาพ ให้เลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง รูปภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์จุดหัวข้อแบบกำหนดเอง

ควรจำไว้ว่ารูปภาพจะถูกย่อขนาดลงเป็นขนาดที่ใหญ่มาก ดังนั้นเราขอแนะนำให้เลือกรูปภาพที่ยังคงชัดเจนและมีประสิทธิภาพทางสายตาเมื่อนำไปใช้เป็นจุดหัวข้อในรายการ
{{% /alert %}}

เพื่อสร้างจุดหัวข้อรูปภาพ ให้เพิ่มรูปภาพไปยัง [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) แล้วกำหนดอ็อบเจ็กต์รูปภาพที่ได้ให้กับ [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) เป็น [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) ก่อนกำหนดรูปภาพ

สมมติเรามีรูปภาพชื่อ "image.png":

![รูปภาพสำหรับจุดหัวข้อ](picture_for_bullets.png)

โค้ด Python ต่อไปนี้แสดงวิธีสร้างจุดหัวข้อรูปภาพบนสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![จุดหัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางรายการที่ระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านในของมัน และต่อไป

โค้ด Python ต่อไปนี้แสดงวิธีสร้างรายการที่มีจุดหัวข้อหลายระดับ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าเป้าหมายและอัปเดตการตั้งค่า [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) คุณสามารถใช้คุณสมบัติเหมายังเดียวกับที่ใช้สร้างรายการเพื่อตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP

โค้ด Python ต่อไปนี้เปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับเลข:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **อ่านค่าจุดหัวข้อจริง**

เมื่อต้องการสกัดเนื้อหางานนำเสนอ ให้เก็บเครื่องหมายรายการไว้เคียงกับข้อความย่อหน้า เรียก [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) แล้วเข้าถึง `getBullet` เพื่อรับรูปแบบจุดหัวข้อที่ใช้จริง ตรวจสอบ `getType` ก่อนอ่าน `getActualBulletValue`

สำหรับรายการลำดับเลข แยกค่าเหล่านี้สามค่า:

- `getNumberedBulletStyle` กำหนดรูปแบบ เช่น ตัวเลขอารบิกตามด้วยจุด หรืออักษรตัวเล็กตามด้วยจุด
- `getNumberedBulletStartWith` ระบุหมายเลขเริ่มต้นสำหรับกลุ่มย่อหน้าลำดับเลข
- `getActualBulletValue` ส่งคืนเครื่องหมายที่จัดรูปแบบสำหรับย่อหน้าเฉพาะ ตัวอย่างเช่น รายการที่สองในรายการที่เริ่มที่ 5 จะคืนค่า `6.`

ควรรักษา [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) กับแต่ละย่อหน้าเพื่อเก็บระดับการซ้อนกันของมัน เครื่องหมายจริงไม่ได้เข้ารหัสลำดับชั้นทั้งหมด: รายการที่ซ้อนอาจคืนค่า `c.` แทนที่จะเป็นป้ายรวมเช่น `6.c.`

ตัวอย่างอิสระต่อไปนี้สร้างรายการ บันทึกเป็นงานนำเสนอ แล้วโหลดงานนำเสนอใหม่เพื่อรายงานข้อความย่อหน้า ความลึก ประเภทจุดหัวข้อ และค่าจริง เครื่องหมายรูปภาพสีน้ำเงินเล็กถูกสร้างจาก SVG แบบอินไลน์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # สร้างเครื่องหมายรูปภาพโดยไม่ใช้ไฟล์รูปภาพภายนอก.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

รายการต้นแบบแสดงด้านล่าง

![รายการที่เริ่มที่ 5 รายการที่ซ้อนเป็นอักษรและโรมัน, เครื่องหมายสัญลักษณ์, ย่อหน้าไม่มีจุดหัวข้อ, และเครื่องหมายรูปภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานตรงกับเครื่องหมายที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

สำหรับ [BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/), `getActualBulletValue` คืนค่า `None` (Java `null`) ไม่ใช่สตริงว่างจัดการประเภทเหล่านี้แยกต่างหาก: ตัวแรกไม่มีเครื่องหมาย ส่วนตัวที่สองต้องสกัดรูปภาพจุดหัวข้อแยกต่างหาก จุดหัวข้อรูปภาพไม่สามารถจำลองได้โดยการสกัดเครื่องหมายข้อความอย่างเดียว

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการที่มีจุดหัวข้อและลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ใช่ Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อรูปแบบเป้าหมายรองรับการจัดวางข้อความและคุณลักษณะจุดหัวข้อที่สอดคล้อง

**สามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ใช่ โหลดงานนำเสนอ เข้าถึงย่อหน้าเป้าหมาย ตรวจสอบหรืออัปเดตการตั้งค่า [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) แล้วบันทึกงานนำเสนอ

**รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ใช่ ข้อความรายการสามารถมีอักขระ Unicode ได้ ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ