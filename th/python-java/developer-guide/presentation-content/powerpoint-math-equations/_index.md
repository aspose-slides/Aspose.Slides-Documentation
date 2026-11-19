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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน Java รองรับ OMML, การควบคุมรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides for Python via Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยโปรแกรมได้: ส่วนเศษส่วน, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปจะเพิ่มสมการจาก **Insert > Equation**:

![แถบ Insert ของ PowerPoint ที่เลือกคำสั่ง Equation](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เป็นรูปที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปทรง
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML โปรดดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปคณิตศาสตร์และเพิ่มสูตรพีทากอรัส:

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปที่มี MathParagraph แล้วอยู่ภายในอยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และเพิ่ม MathBlock หรือ MathElement ลงไป
{{% /alert %}}

### **รวม Math Block**

เมื่อส่วนของสมการถูกสร้างแยกกันเป็นอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) ให้ใช้ [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) เพื่อรวมเข้าด้วยกัน ตัวอย่างสร้าง `c² =` ในบล็อกซ้ายและ `a² + b²` ในบล็อกขวา. [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) สร้างซูเปอร์สคริปต์คณิตศาสตร์ที่แก้ไขได้สำหรับทั้งสามพาวเวอร์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addMathShape(20, 20, 600, 100)
    math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    left_block = MathBlock()
    left_block.add(MathematicalText("c").setSuperscript("2"))
    left_block.add(MathematicalText("="))

    right_block = MathBlock()
    right_block.add(MathematicalText("a").setSuperscript("2"))
    right_block.add(MathematicalText("+"))
    right_block.add(MathematicalText("b").setSuperscript("2"))

    combined_block = left_block.joinBlock(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) คืนค่า `left_block` เองโดยตอนนี้บรรจุส่วนทั้งสองตามลำดับและทำให้ `right_block` ว่างเปล่า. เพิ่มบล็อกที่รวมแล้วลงใน [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) แค่ครั้งเดียว. หลังจากเปิด `equation.pptx` ใหม่ พารากราฟจะมีบล็อกเดียวที่แสดง `c² = a² + b²` พร้อมกับพาวเวอร์ทั้งสามที่คงไว้เป็นซูเปอร์สคริปต์

การเรียก [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) เป็น `left_block.add(right_block)` จะพยายามฝั่งบล็อกหนึ่งภายในอีกบล็อกหนึ่งโดยตรงและทำให้เกิด `InvalidOperationException`

## **เพิ่มส่วนเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างส่วนเศษส่วน คุณสามารถเลือกสไตล์ส่วนเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/)

![ส่วนเศษส่วนคณิตศาสตร์ที่เอียงแสดงหนึ่งหายไปด้วย x](powerpoint-math-equations_4.png)

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

สำหรับส่วนเศษส่วนแบบซ้อนให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากกำลังสอง, กำลังสาม หรือรากอื่น ๆ. องค์ประกอบปัจจุบันจะกลายเป็นฐาน และอาร์กิวเมนต์จะเป็นระดับ

![นิพจน์ราก n‑th ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนระดับของรากกำลังสอง**

รากกำลังสองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามปกติ. เมธอด [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่ปรากฏ. ทั้งสองรูปแบบยังคงมีระดับ 2 และฐาน x อยู่ในสมการที่แก้ไขได้

![รากกำลังสองเดียวกันด้านซ้ายแสดงระดับและด้านขวาซ่อนระดับ](square-root-degree.png)

ตัวอย่างบันทึกรากกำลังสองเดียวกันสองครั้ง. ใน `visible-degree.pptx` ตัวเลข 2 ปรากฏ. ใน `hidden-degree.pptx` ตัวเลข 2 ถูกซ่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มฟังก์ชันและขอบเขต**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขอบเขต ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) สำหรับผลรวม, ยูเนียน, อินเตอร์เซกชัน และตัวดำเนินการใหญ่รูปแบบอื่น ๆ. ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล. ทั้งสองเมธอดให้คุณตั้งค่าขอบเขตล่างและบน

![ผลรวมที่มีขอบเขตล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary ใช้กับตัวดำเนินการขนาดใหญ่ที่อาจมีขอบเขตได้. ตัวดำเนินการแบบง่ายเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) แล้วเชื่อมต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

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

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) เพื่อกำหนดแถวและคอลัมน์. เมทริกซ์โดยปกติจะไม่มีวงเล็บ จึงต้องใส่วงเล็บเองเมื่อจำเป็น

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

### **แก้ไขเมทริกซ์ที่มีอยู่**

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์係数ใน `matrix.pptx` ซึ่งได้บันทึกจากตัวอย่างก่อนหน้า. สำหรับแบบฝึกหัดต่อไป ให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสองสมการใหม่, และปรับชุดตัวแปร. เปิดเมทริกซ์ที่มีอยู่ผ่าน [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) เพื่อรักษา係数ที่ยังใช้ได้

![เมทริกซ์係数สองแถวต้นฉบับที่มีค่า 1, x และเซลล์ว่างในแถวแรก; x, 2, y ในแถวสอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มจากศูนย์และอ้างอิงเมทริกซ์ตามสภาพในแต่ละการเรียก. การแทรกแถวก่อนดัชนี 1 จะทำให้แถวที่สองเดิมย้ายไปเป็นดัชนี 2. การแทรกหลังดัชนี 2 แล้วจะเพิ่มแถวใหม่. การลบแถว 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มเข้ามาขึ้นหนึ่งตำแหน่ง. คอลัมน์ก็เลื่อนแบบเดียวกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # เซลล์ใหม่เริ่มต้นเป็นค่าว่าง ตั้งค่าค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) จัดแนวคอลัมน์แรกไปซ้าย. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) จัดแนวคอลัมน์ที่เหลือสามคอลัมน์ไปขวา เริ่มจากดัชนี 1. ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร. 係数เดิม `1` และ `x` ของแถวแรกปรากฏในคอลัมน์แรกและคอลัมน์ที่สาม

![เมทริกซ์สามแถวที่อัปเดตแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือสแตกแนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่แสดง x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาเรย์กับองค์ประกอบโดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาเรย์เมื่อเทียบกับองค์ประกอบคณิตศาสตร์ข้างเคียง ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์ของอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปสร้างอาเรย์สามอันที่เหมือนกัน โดยแต่ละอาเรย์มีสามแถวและองค์ประกอบข้างเคียง `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด. มีการเปลี่ยนแค่การจัดแนวของอาเรย์เท่านั้น

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

การเปรียบเทียบต่อไปนี้แสดงการนำเสนอที่บันทึกไว้ใน PowerPoint. สังเกตตำแหน่งของ `A=` และ `=B` ข้างอาเรย์แต่ละอัน

![อาเรย์สมการใน PowerPoint ที่จัดแนวบน, กลาง, และล่าง พร้อมองค์ประกอบข้างเคียงเดียวกัน](equation-array-alignment.png)

### **กำหนดการเว้นระยะแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะที่ชัดเจนและจะถูกละเลยเมื่อใช้กฎสำเร็จรูป

สำหรับการเว้นระยะที่เที่ยงตรง ค่าจะวัดเป็นจุด. สำหรับการเว้นระยะเชิงสัดส่วน จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติเมื่อกำหนดค่าชัดเจน; การเปลี่ยนค่าเลขเดียวอย่างเดียวจะไม่เลือกกฎการเว้นระยะ

ตัวอย่างด้านล่างบันทึกการนำเสนอห้าฉบับที่มีสมการ, การจัดแนว, และการตั้งค่าแบบอักษรเดียวกัน. สามฉบับแรกใช้กฎสำเร็จรูป; สองฉบับสุดท้ายแสดงค่าชัดเจน

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

การเว้นระยะแถวของอาเรย์แยกจากการเว้นระยะของพารากราฟ. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะห่างรอบพารากราฟที่บรรจุอาเรย์, ไม่ได้เพิ่มระยะห่างระหว่างแถวของอาเรย์. เช่นเดียวกัน, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) กำหนดตำแหน่งแนวนอนของพารากราฟคณิตศาสตร์ทั้งหมด; มันไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันทราบแล้ว

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

## **เพิ่มตัวห้อยและตัวสูง**

ใช้ตัวช่วยสำหรับตัวห้อยและตัวสูงเมื่อจัดทำดัชนีหรือพาวเวอร์. หากดัชนีต้องปรากฏทางด้านซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![อักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ทางซ้ายและตัวสูง n ทางซ้าย](powerpoint-math-equations_9.png)

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

## **เพิ่มเครื่องหมายวงเล็บ**

ใช้ [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ไว้ในเครื่องหมายวงเล็บ คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบได้

![นิพจน์ที่มีเครื่องหมายวงเล็บโดยมี x, y, และ z คั่นด้วยเส้นแนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวเครื่องหมายวงเล็บ**

ส่งค่า `True` ไปที่ [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามอ็อพอแรนด์สูง, หรือส่งค่า `False` เพื่อคงขนาดตามปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) กับค่าใดค่าหนึ่งของ [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) `Centered` จะทำให้วงเล็บกึ่งกลางตามแกนคณิตศาสตร์ (ที่ผ่านสัญลักษณ์เท่ากับ) ส่วน `Match` จะทำให้วงเล็บสอดคล้องกับเนื้อหาที่หุ้มไว้. การตั้งค่าสองอย่างนี้ส่งผลต่อวงเล็บเท่านั้น; นิพจน์ภายในคงเดิม

ตัวอย่างวางส่วนเศษส่วนเป็นส่วนยกกำลังของ `x` ทำให้นิพจน์ยื่นขึ้นเหนือฐานมากกว่าต่ำกว่า ทั้งสี่สมการใช้วงเล็บและการตั้งค่าแบบอักษรเดียวกัน

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

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. แถวบนวงเล็บขยายเพื่อห่อส่วนยกกำลังและดูเหมือนกันทั้งสองรูปร่าง. แถวล่างการขยายปิดอยู่. วงเล็บที่เล็กกว่าไปทางซ้าย (`Centered`) จัดแนวกับสัญลักษณ์เท่ากับ, ส่วนวงเล็บที่ขวา (`Match`) อยู่สูงกว่ารอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิด/ปิดการขยายวงเล็บบน/ล่าง, และจัดแนว Centered ทางซ้ายและ Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) บนส่วนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) ที่คืนค่าจะแสดงสี่ด้านโดยค่าเริ่มต้น. ใช้ [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) เพื่อซ่อนด้านแต่ละด้านตามต้องการ

ตัวอย่างวางสำเนาหกอันของส่วนเศษส่วนเดียวกันบนสไลด์เดียว เพื่อแสดงการลบ, ซ่อนสี่ด้านทั้งหมดและส่งค่า `True` ไปที่ [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อทำเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อทำเส้นทแยงลง (↘). คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) พร้อมการผสมผสานของด้านที่มองเห็นได้

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

![หกส่วนเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นข้ามแนวนอน, เส้นข้ามแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนส่วนเศษส่วนนี้ เส้นข้ามแนวนอนทับบาร์ส่วนเศษส่วน. เส้นข้ามแนวตั้งตัดผ่านทั้งเศษและส่วนล่างในขณะที่กรอบโดยรอบยังคงมองเห็นได้. เส้นเหล่านี้ประดับให้กับนิพจน์ทั้งหมด. การขีดเส้นทับตามปกติจะใช้กับอักขระในรันข้อความ. หลังจากเปิดไฟล์นำเสนอใหม่ใน PowerPoint คุณยังสามารถแก้ไขเศษและส่วนล่างแยกกันได้

## **ควบคุมการมองเห็นและการจัดวางด้วย Phantom Elements**

ใส่นิพจน์ใน [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันทำให้สมการขยายโดยอิสระ. เมธอดของ [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) ควบคุมดังต่อไปนี้:

| เมธอด | ผล |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | ส่งค่า `False` เพื่ซ่อนนิพจน์. มิติของมันยังคงมีผลต่อการจัดวางยกเว้นเมธอดต่อไปนี้รับค่า `True` |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | ปฏิบัติต่อความกว้างแนวนอนของนิพจน์เป็นศูนย์, ทำให้องค์ประกอบข้างเคียงย้ายเข้ามาใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | ปฏิบัติต่อส่วนขึ้นของมัน (ความสูงเหนือเส้นฐาน) เป็นศูนย์, ลดพื้นที่ที่สงวนไว้เหนือองค์ประกอบข้างเคียง |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | ปฏิบัติต่อส่วนลงของมัน (ความลึกต่ำกว่าเส้นฐาน) เป็นศูนย์, ทำให้บาร์ส่วนเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์ย้ายเข้าใกล้กับเพื่อนบ้าน |

เส้นฐานคือเส้นอ้างอิงที่อักขระคณิตศาสตร์ทั่วไปวางอยู่. การซ่อนเนื้อหาไม่ได้ลบมิติออก, และการตั้งมิติเป็นศูนย์ไม่ได้ลบนิพจน์ออก. นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). ส่งค่า `True` ไปที่ [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติจะคงเดิม

ตัวอย่างด้านล่างสร้างห้าตัวแปรข้างเคียง: เศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่ยังสงวนพื้นที่, และสามเศษส่วนที่ซ่อนโดยตั้งมิติหนึ่งเป็นศูนย์. แต่ละตัวแปรใช้นิพจน์รอบข้างเดียวกันและ Cambria Math ขนาด 24 จุด. รูปร่างสมการทั้งหมดมีตำแหน่งบนเดียวกันโดยมีไกด์สีเทา. การใส่ phantom ในเศษของส่วนเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งเห็นได้ชัดขึ้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![ห้าสมการใน PowerPoint ที่เปรียบเทียบเศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc, หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขอบเขตเพื่อป้ายกำกับเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้าย “any text” ใต้มัน](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรเข้าใจง่าย ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) วางเส้นเหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นเหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่ ให้เดินสำรวจต้นไม้ขององค์ประกอบแต่ละบล็อกคณิตศาสตร์. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) คืนเฉพาะลูกโดยตรง, ดังนั้นให้เรียกแบบลึกเพื่อเข้าถึงข้อความในส่วนเศษส่วน, ตัวล่างบน, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบองค์ประกอบปัจจุบันรวมถึงลูกของมัน เพื่อรวมองค์ประกอบเริ่มต้นเมื่อมันเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้ถือว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` ที่ส่วนเศษส่วนมีตัวห้อยในเศษและรากในส่วนล่าง. การประมวลผลเฉพาะองค์ประกอบระดับบนของบล็อกจะพลาดข้อความในส่วนเศษส่วน. ตัวอย่างค้นหา MathPortion ในกรอบข้อความของสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งขนาดฟอนต์เป็น 28 จุดผ่านเมธอด [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละองค์ประกอบข้อความ

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

การบันทึกการนำเสนอจะมีการอัปเดตการจัดรูปแบบข้อความที่ทุกระดับของสมการที่ประมวลผล, ในขณะที่ยังคงรักษาเนื้อหาและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| สร้างส่วนเศษส่วน | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| เพิ่มตัวสูงหรือห้อย | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| เพิ่มราก | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| เพิ่มขอบเขต | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| เพิ่มผลรวมและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| เพิ่มเครื่องหมายวงเล็บ | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| เพิ่มเส้นเหนือและขอบ | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้ไหม?**

ได้. เปิดงานนำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และอัปเดต MathBlock ในพารากราฟนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้ไหม?**

ใช่. รับ [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) ของมัน, แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง. ตัวอย่างสมบูรณ์ดูได้ที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/#export-math-equations-to-latex).