---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint ด้วย Python
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/python-java/powerpoint-math-equations/
keywords:
- สมการคณิตศาสตร์
- สัญลักษณ์คณิตศาสตร์
- สูตรคณิตศาสตร์
- ข้อความคณิตศาสตร์
- เพิ่มสมการคณิตศาสตร์
- เพิ่มสัญลักษณ์คณิตศาสตร์
- เพิ่มสูตรคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน Java รองรับ OMML, ควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides for Python via Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยใช้โปรแกรมได้ เช่น เศษส่วน รากฟังก์ชัน ขอบเขต ตัวดำเนินการ N-ary เมทริกซ์ อาร์เรย์ และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แถบ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นโดยใช้วัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างโดยใช้ [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), เป็นรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) ประกอบด้วยหนึ่งหรือหลายวัตถุ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) เพื่อทำให้โค้ดสั้นและอ่านง่าย.

สำหรับสถานการณ์ส่งออก MathML, ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี Math paragraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) แรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และเพิ่มบล็อกคณิตศาสตร์หรือองค์ประกอบคณิตศาสตร์เข้าไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนได้ด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![เศษส่วนคณิตศาสตร์เอียงที่แสดง 1 หาร x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับเศษส่วนแบบ stacked ให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง รากที่สาม หรือรากอื่น ๆ ส่วนประกอบปัจจุบันจะเป็นฐาน และอาร์กิวเมนต์จะเป็นดีกรี.

![นิพจน์ราก n-th ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มฟังก์ชันและขอบเขต**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขอบเขต ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![ขอบเขตของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นส่วนประกอบปัจจุบันแล้วเรียก [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมินท์ของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชันและตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณตั้งค่าขอบล่างและบน.

![ผลบวกที่มีขอบเขตล่างและบน](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขอบเขตเป็นตัวเลือก ตัวดำเนินการแบบง่ายเช่น `+`, `-`, และ `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และรวมเข้าในนิพจน์.

สำหรับอินทิกรัล, ให้ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปริยายจะไม่มีวงเล็บ ดังนั้นให้ล้อมเมทริกซ์เมื่อคุณต้องการวงเล็บ, วงกต หรือปีกกา.

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มอาร์เรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือสแตกแนวตั้งของนิพจน์.

![อาร์เรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดแนวอาร์เรย์กับองค์ประกอบโดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาร์เรย์เทียบกับองค์ประกอบคณิตศาสตร์ที่อยู่ข้างๆ ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, กึ่งกลางของอาร์เรย์, และแถวสุดท้าย.

ตัวอย่างต่อไปนี้สร้างอาร์เรย์ที่เหมือนกันสามชุด, แต่ละชุดมีสามแถวและองค์ประกอบข้างเคียง `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ฟอนท์ Cambria Math ขนาด 24 pt. มีเพียงการจัดแนวอาร์เรย์ที่เปลี่ยนแปลง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปรียบเทียบต่อไปนี้แสดงการบันทึกงานนำเสนอใน PowerPoint. สังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาร์เรย์.

![อาร์เรย์สมการใน PowerPoint ที่มีการจัดแนวบน กลาง และล่าง พร้อมองค์ประกอบข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการเว้นระยะสำหรับแถวภายในอาร์เรย์. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะแบบเจาะจงและจะถูกละเลยเมื่อใช้กฎที่กำหนดไว้ล่วงหน้า.

สำหรับการเว้นระยะแบบเจาะจง, ค่าจะวัดเป็นจุด. สำหรับการเว้นระยะเชิงสัดส่วน, จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติโดยพร้อมกันเมื่อระบุค่าที่เจาะจง; การเปลี่ยนค่าเชิงตัวเลขเพียงอย่างเดียวจะไม่เลือกกฎการเว้นระยะ.

ตัวอย่างด้านล่างบันทึกงานนำเสนอห้าฉบับที่มีสมการ, การจัดแนวและการตั้งค่าฟอนท์เดียวกัน. สามฉบับแรกใช้ค่าที่กำหนดไว้ล่วงหน้า; สองฉบับสุดท้ายแสดงค่าที่เจาะจง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

ระยะห่างของแถวในอาร์เรย์แยกจากระยะห่างของย่อหน้าต่าง ๆ. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะห่างรอบย่อหน้าที่บรรจุ, ไม่ได้อยู่ระหว่างแถวของอาร์เรย์. เช่นเดียวกับนั้น, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) วางตำแหน่งของย่อหน้าคณิตศาสตร์ทั้งหมดในแนวนอน; มันไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาร์เรย์.

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์เป็นส่วนประกอบปัจจุบันและทราบชื่อฟังก์ชัน.

![ฟังก์ชันตรีโกณมิติ cos ที่ใช้กับ 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มตัวห้อยและยกกำลัง**

ใช้ตัวช่วยการห้อยและยกกำลังสำหรับดัชนีและกำลัง. เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน, ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![ตัวอักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อยด้านซ้าย 1 และตัวยกกำลัง n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มตัวจำกัด**

ใช้ [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ในตัวจำกัด. คุณยังสามารถตั้งค่าตัวอักษรคั่นสำหรับนิพจน์ตัวจำกัดที่มีหลายองค์ประกอบได้.

![นิพจน์ตัวจำกัดที่มี x, y และ z แยกด้วยเส้นตั้ง](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ขนาดและการจัดแนวตัวจำกัด**

ส่ง `True` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายรอบออปอแรนด์สูง, หรือส่ง `False` เพื่อให้คงขนาดปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) กับหนึ่งในสองค่า [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` จัดกลางวงเล็บบนแกนคณิตศาสตร์ ซึ่งวิ่งผ่านกลางเครื่องหมายเท่ากับ. `Match` จัดให้ตรงกับเนื้อหาที่อยู่ภายใน. ทั้งสองการตั้งค่าส่งผลต่อเฉพาะตัวจำกัด. นิพจน์ภายในคงเดิม.

ตัวอย่างวางเศษส่วนในดีกรีของ `x` ทำให้นิพจน์ยื่นเหนือเส้นฐานมากกว่าต่ำ. ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนท์เดียวกัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. ในแถวบน, วงเล็บขยายเพื่อห่อดีกรีและดูเหมือนกันสำหรับทั้งสองรูป. ในแถวล่าง, การขยายถูกปิด. วงเล็บเล็กด้านซ้าย (`Centered`) จัดกับเครื่องหมายเท่ากับ, ขณะที่ด้านขวา (`Match`) ยกสูงกว่าเหนือศูนย์ของนิพจน์.

![สี่สมการใน PowerPoint ที่เปิดการเติบโตของตัวจำกัดด้านบนและปิดด้านล่าง, พร้อม Centered ทางซ้ายและ Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกรอบขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อกำหนดกรอบให้กับนิพจน์ทั้งหมด. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) ที่คืนค่าแสดงสี่ด้านโดยปริยาย. ใช้ [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) และ [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) เพื่อซ่อนด้านแต่ละด้าน.

ตัวอย่างวางเศษส่วนเดียวกันหกสำเนาบนสไลด์หนึ่ง. เพื่อแสดงการยกเลิก, ซ่อนสี่ด้านทั้งหมดและส่ง `True` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) สำหรับเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) สำหรับเส้นทแยงลง (↘). คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับการแสดงด้านที่ต้องการได้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![หกเศษส่วนที่สามารถแก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและด้านซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นขีดแนวนอน, เส้นขีดแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้, เส้นขีดแนวนอนทับบาร์ของเศษส่วน. เส้นขีดแนวตั้งตัดส่วนบนและส่วนล่างพร้อมกรอบโดยรอบยังคงมองเห็นได้. เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด. การขีดเส้นลายมาตรฐานใช้กับอักขระในรันข้อความ. หลังจากเปิดงานนำเสนอใน PowerPoint อีกครั้ง, คุณยังคงแก้ไขส่วนบนและส่วนล่างได้อย่างอิสระ.

## **จัดกลุ่มเงื่อนไข**

ใช้ [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขอบเขตเพื่อทำป้ายกำกับให้กับกลุ่มเงื่อนไข.

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้ายกำกับข้อความใดก็ได้ด้านล่าง](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) จะวางแถบเหนือองค์ประกอบคณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC ที่มีแถบเหนือ](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั้งหมดในสมการที่มีอยู่, ให้เดินทางผ่านโครงสร้างต้นไม้ของแต่ละบล็อกคณิตศาสตร์. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) คืนค่าตัวลูกโดยตรงเท่านั้น, ดังนั้นให้เรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, สคริปต์, รากและโครงสร้างซ้อนอื่น ๆ. ตรวจสอบส่วนประกอบปัจจุบันและลูกของมันเพื่อรวมส่วนประกอบเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, ที่มีเศษส่วนที่มีตัวห้อยในส่วนบนและรากในส่วนล่าง. การประมวลผลเฉพาะส่วนประกอบระดับบนของบล็อกจะพลาดข้อความภายในเศษส่วน. ตัวอย่างนี้ค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งค่าขนาดฟอนท์เป็น 28 pt ผ่านเมธอด [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละองค์ประกอบข้อความ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

งานนำเสนอที่บันทึกไว้จะมีการจัดรูปแบบข้อความที่อัพเดตในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อหาและโครงสร้างคณิตศาสตร์ไว้.

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| สร้างเศษส่วน | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| เพิ่มตัวยกกำลังหรือห้อย | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| เพิ่มราก | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| เพิ่มขอบเขต | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| เพิ่มตัวจำกัด | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| เพิ่มแถบและกรอบ | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| จัดกลุ่มเงื่อนไข | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), แล้วอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. เรียก [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) ของมัน, แล้วใช้ [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง. ตัวอย่างเต็มดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/#export-math-equations-to-latex).