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
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน Java รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) ด้วย Aspose.Slides for Python via Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันโดยใช้โปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านออบเจ็กต์หลักสามตัว:

- รูปคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เป็นรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายออบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับการส่งออก MathML ให้ดูที่ [ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปคณิตศาสตร์และเพิ่มทฤษฎีปิทาโกรัส:

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), แล้วเพิ่ม MathBlock หรือ MathElement ลงในนั้น.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/)

![เศษส่วนคณิตศาสตร์เอียงแสดงหนึ่งหาร x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อน, ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ. อีลีเมนต์ปัจจุบันจะกลายเป็นฐานและอากิวเมนต์จะเป็นดีกรี.

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันกำหนดเอง สำหรับขีดจำกัด, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)

![ขีดจำกัดของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันกำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นอีลีเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) พร้อมอากิวเมนต์ของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) สำหรับการบวกจำนวน, ยูเนียน, อินเตอร์เซกชัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองวิธีให้คุณตั้งค่าขีดจำกัดล่างและบน

![ผลบวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นออปชั่น ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะถูกเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และรวมเข้ากับนิพจน์

สำหรับอินทิגרัล, ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

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

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติจะไม่มีวงเล็บ จึงต้องใส่วงเล็บเมื่อคุณต้องการวงโค้ง, วงเหลี่ยม, หรือวงปีกก.

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

ใช้ [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือกองแนวตั้งของนิพจน์

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

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออากิวเมนต์เป็นอีลีเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ที่นำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวบน**

ใช้ตัวช่วย subscript และ superscript สำหรับดัชนีและเลขชี้กำลัง เมื่อดัชนีต้องปรากฏทางด้านซ้ายของฐาน, ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![ตัวอักษร Y ตัวใหญ่พร้อมตัวห้อยซ้าย 1 และตัวบน n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่ง**

ใช้ [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ภายในตัวแบ่ง คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ตัวแบ่งที่มีหลายองค์ประกอบ

![นิพจน์ตัวแบ่งที่มี x, y, และ z คั่นด้วยบาร์แนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดตำแหน่งตัวแบ่ง**

ส่ง `True` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามความสูงของออเปอแรนด์ที่สูง, หรือส่ง `False` เพื่อให้คงขนาดปกติ ใช้ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) พร้อมค่าหนึ่งของสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) `Centered` จะจัดศูนย์วงเล็บบนแกนคณิตศาสตร์ที่ผ่านกลางเครื่องหมายเท่ากับ `Match` จะจัดให้สอดคล้องกับเนื้อหาที่ล้อมรอบ ทั้งสองการตั้งค่าส่งผลเฉพาะตัวแบ่ง ส่วนนิพจน์ภายในคงเดิม

ตัวอย่างวางเศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ขยายสูงกว่าตำแหน่งฐานด้านบน ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบน วงเล็บจะขยายเพื่อคลอบคลุมเลขชี้กำลังและดูเหมือนกันสำหรับรูปร่างทั้งสอง ในแถวล่าง การขยายปิดไว้ วงเล็บขนาดเล็กทางซ้าย (`Centered`) จัดให้ตรงกับเครื่องหมายเท่ากับ ส่วนด้านขวา (`Match`) จะอยู่สูงกว่ารอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิดใช้งานการขยายตัวแบ่งด้านบนและปิดการทำงานด้านล่าง, และ Centered ทางซ้ายและ Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องกรอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) ที่คืนค่าจะเป็นการแสดงสี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) และ [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านเฉพาะ

ตัวอย่างวางสำเนาเดียวกันของเศษส่วนหกชุดบนสไลด์เดียว เพื่อแสดงการขีดลบ, ซ่อนทั้งสี่ด้านและส่ง `True` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อเส้นทแยงลง (↘) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับการตั้งค่าด้านที่มองเห็นได้

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นทแยงแนวนอน, เส้นทแยงแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นขีดแนวนอนทับบาร์ของเศษส่วน เส้นขีดแนวตั้งตัดผ่านเศษและส่วนอย่างทั้งสองขณะที่กรอบรอบ ๆ ยังคงมองเห็นได้ เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด การขีดเส้นทับข้อความปกติใช้กับอักขระในรันข้อความ หลังจากเปิดไฟล์นำเสนอใหม่ใน PowerPoint คุณยังสามารถแก้ไขเศษและส่วนแยกกันได้

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อทำป้ายกำกับให้เทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบอีลีเมนต์คณิตศาสตร์**

ใช้ตัวช่วยจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) วางบาร์เหนืออีลีเมนต์คณิตย์

![นิพจน์คณิตศาสตร์ ABC ที่มี overbar](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่ ให้เดินทางผ่านต้นไม้ของอีลีเมนต์ในแต่ละ MathBlock. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) คืนค่าเฉพาะลูกโดยตรง ดังนั้นเรียกใช้แบบเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอีลีเมนต์ปัจจุบันและลูกของมันเพื่อรวมอีลีเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` ที่มีเศษส่วนที่มีตัวห้อยในเศษและรากในส่วน การประมวลผลเฉพาะอีลีเมนต์ระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งขนาดฟอนต์เป็น 28 จุดผ่านเมธอด [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละอีลีเมนต์ข้อความ

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

ไฟล์นำเสนอที่บันทึกจะมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล พร้อมคงเนื้อหาข้อความและโครงสร้างคณิตศาสตร์

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| รวมอีลีเมนต์ | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| สร้างเศษส่วน | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| เพิ่มตัวบนหรือ ตัวห้อย | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| เพิ่มราก | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| เพิ่มตัวแบ่ง | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| เพิ่มแถบและกรอบ | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดพรีเซนเทชัน, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และอัปเดต MathBlock ในพารากราฟนั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อคุณบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. ดึง [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง. สำหรับตัวอย่างเต็ม, ดูที่ [ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/#export-math-equations-to-latex).