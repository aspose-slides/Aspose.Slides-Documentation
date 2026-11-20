---
title: เพิ่มสมการคณิตศาสตร์ลงในงานนำเสนอ PowerPoint ด้วย Python
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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน Java รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด Python ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides for Python via Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยโปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เป็นรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และวิธีการเชิงไหลจาก [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับกรณีการส่งออก MathML ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพื้นฐานของพีทาโกรัส:

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และเพิ่มบล็อกคณิตศาสตร์หรืออีลีเมนต์คณิตศาสตร์ลงไป
{{% /alert %}}

### **รวมบล็อกคณิตศาสตร์**

เมื่อส่วนของสมการสร้างแยกกันเป็นอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) ให้ใช้ [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) เพื่อรวมเข้าด้วยกัน ตัวอย่างสร้าง `c² =` ในบล็อกซ้ายและ `a² + b²` ในบล็อกขวา. [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) สร้างซุปเปอร์สคริปต์คณิตศาสตร์ที่แก้ไขได้สำหรับทั้งสามกำลัง

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

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) คืนค่า `left_block` เอง ซึ่งตอนนี้มีทั้งสองส่วนตามลำดับและทำให้ `right_block` ว่างเปล่า เพิ่มบล็อกที่รวมแล้วไปยัง [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) เพียงครั้งเดียว หลังจากเปิดไฟล์ `equation.pptx` ใหม่ ย่อหน้าจะมีบล็อกเดียวที่แสดง `c² = a² + b²` พร้อมกับซุปเปอร์สคริปต์ของทั้งสามกำลังที่คงไว้

การเรียก [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) ในรูปแบบ `left_block.add(right_block)` จะพยายามวางบล็อกหนึ่งภายในอีกบล็อกโดยตรงและทำให้เกิด `InvalidOperationException`

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกรูปแบบของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/)

![เศษส่วนคณิตศาสตร์เอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนซ้อน ให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **เพิ่มรากคณิตศาสตร์**

ใช้ [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ อีลีเมนต์ปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

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

### **แสดงหรือซ่อนดีกรีของรากกำลังสอง**

รากกำลังสองสามารถแสดงดีกรี 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามแบบดั้งเดิม วิธีการ [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่แสดง ทั้งสองรูปแบบยังคงดีกรี 2 และ radicand x อยู่ในสมการที่แก้ไขได้

![รากกำลังสองเดียวกันที่แสดงดีกรีบนซ้ายและซ่อนบนขวา](square-root-degree.png)

ตัวอย่างบันทึกรากกำลังสองเดียวกันสองครั้ง ใน `visible-degree.pptx` ดีกรี 2 แสดงอยู่ ใน `hidden-degree.pptx` ดีกรี 2 ถูกซ่อน

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชัน เช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขีดจำกัด ให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำชื่อฟังก์ชันเป็นอีลีเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) สำหรับผลบวก, ยูเนียน, อินเตอร์เซกชัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองวิธีให้คุณตั้งค่าขีดจำกัดล่างและบน

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

N-ary operators ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นตัวเลือก ตัวดำเนินการง่าย ๆ เช่น `+`, `-`, และ `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) และรวมเข้าในนิพจน์

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

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปริยายจะไม่มีวงเล็บ ดังนั้นให้ล้อมเมทริกซ์ด้วยวงเล็บ, วงกลม หรือวงโค้ดเมื่อจำเป็น

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

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์ค่าสัมประสิทธิ์ใน `matrix.pptx` ซึ่งบันทึกโดยตัวอย่างก่อนหน้า สำหรับแบบฝึกหัดต่อไป ให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสองสมการใหม่, และปรับชุดตัวแปร เปิดเมทริกซ์ที่มีอยู่ผ่าน [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) เพื่อคงค่าคัดสรรที่ยังใช้ได้

![เมทริกซ์ค่าสัมประสิทธิ์สองแถวเดิมที่มีค่า 1, x, และเซลล์ว่างในแถวแรก และ x, 2, และ y ในแถวที่สอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มจาก 0 และอ้างอิงเมทริกซ์ตามสภาพในแต่ละครั้ง การแทรกแถวก่อนดัชนี 1 จะย้ายแถวที่สองเดิมไปที่ดัชนี 2 การแทรกหลังดัชนี 2 จะเพิ่มแถวใหม่ การลบแถว 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มเข้ามาขึ้นหนึ่งตำแหน่ง คอลัมน์ก็จะเลื่อนแบบเดียวกัน

```python
import jpage
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

    # เซลล์ใหม่เริ่มต้นเป็นว่าง. ตั้งค่าค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน.
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

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) จัดแนวคอลัมน์แรกไปซ้าย [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) จัดแนวคอลัมน์ที่เหลือสามคอลัมน์ไปขวาโดยเริ่มที่ดัชนี 1 ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร ค่าสัมประสิทธิ์แถวแรก `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สามแล้ว

![เมทริกซ์สามแถวที่อัปเดตแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวหรือสแตกแนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x อยู่ด้านบน y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาเรย์กับอีลีเมนต์โดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาเรย์เทียบกับอีลีเมนต์คณิตศาสตร์ที่อยู่ข้างๆ ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปนี้สร้างอาเรย์ที่เหมือนกันสามชุด แต่ละชุดมีสามแถวและอีลีเมนต์ข้างเคียง `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ฟอนต์ Cambria Math ขนาด 24 จุด มีเพียงการจัดแนวอาเรย์ที่เปลี่ยน

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

การเปรียบเทียบต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint ให้สังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาเรย์

![อาเรย์สมการใน PowerPoint ที่มีการจัดแนวบนกลางล่างและอีลีเมนต์ข้างเคียงเดียวกัน](equation-array-alignment.png)

### **กำหนดระยะห่างระหว่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการเว้นระยะระหว่างแถวในอาเรย์ [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะแบบเจาะจงและจะถูกละเลยเมื่อใช้กฎตั้งต้น

สำหรับการเว้นระยะที่แม่นยำ ค่าจะวัดเป็นจุด สำหรับการเว้นระยะแบบสัดส่วน จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติเมื่อกำหนดค่าชัดเจน; การเปลี่ยนค่าตัวเลขอย่างเดียวจะไม่เลือกกฎการเว้นระยะ

ตัวอย่างด้านล่างบันทึกงานนำเสนอห้าไฟล์ที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน สามแรกใช้ค่าตั้งต้น สองสุดท้ายแสดงค่าชัดเจน

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

การเว้นระยะแถวของอาเรย์แยกจากการเว้นระยะของย่อหน้า [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะรอบย่อหน้าที่บรรจุ ไม่ได้ระหว่างแถวของอาเรย์ เช่นเดียวกับ [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) จัดตำแหน่งย่อหน้าคณิตศาสตร์ทั้งหมดในแนวนอน; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์คืออีลีเมนต์ปัจจุบันและชื่อฟังก์ชันทราบแล้ว

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

## **เพิ่มตัวห้อยและตัวบน**

ใช้ตัวช่วยการใส่ตัวห้อยและตัวบนสำหรับดัชนีและกำลัง เมื่อดัชนีต้องแสดงทางซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![ตัว Y ตัวพิมพ์ใหญ่ที่มีตัวห้อยด้านซ้าย 1 และตัวบน n](powerpoint-math-equations_9.png)

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

### **จัดแนวตัวห้อยและตัวบนทางขวา**

เมื่อตัวห้อยและตัวบนใช้ฐานเดียวกัน ให้ใช้ [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/) วิธีการ [setAlignScripts](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) ควบคุมตำแหน่งแนวนอนของสคริปต์ ด้วยค่าเริ่มต้น `False` สคริปต์แต่ละตัวจะตามโค้งของฐาน เมื่อเป็น `True` สคริปต์จะเริ่มจากตำแหน่งแนวนอนเดียวกัน

ตัวอย่างนี้วางสำเนาตัวเดียวกันสองชุดข้างกัน ทั้งสองใช้ตัวอักษรอิตาลิกคณิตศาสตร์ f (U+1D453) พร้อมตัวห้อย 1 และตัวบน 2 ขนาด 72‑point Cambria Math ความชันของ f ทำให้เห็นความแตกต่างใน PowerPoint ติดตั้ง Cambria Math ก่อนรันตัวอย่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathBlock, MathematicalText, MathRightSubSuperscriptElement
from asposeslides.api import PortionFormat, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(900, 250, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    text_format = PortionFormat()
    font = FontData("Cambria Math")
    text_format.setFontHeight(72)
    text_format.setLatinFont(font)

    for left, align_scripts in [(40, False), (480, True)]:
        shape = slide.getShapes().addMathShape(left, 75, 380, 150)
        base = MathematicalText("\U0001D453", text_format)
        subscript = MathematicalText("1", text_format)
        superscript = MathematicalText("2", text_format)
        scripts = MathRightSubSuperscriptElement(base, subscript, superscript)
        scripts.setAlignScripts(align_scripts)

        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(text_format.getFontHeight())
        portion.getPortionFormat().setLatinFont(font)
        block = MathBlock(scripts)
        portion.getMathParagraph().add(block)

    presentation.save("aligned-scripts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![สองนิพจน์ที่แก้ไขได้ใน PowerPoint โดยมี setAlignScripts ตั้งเป็น False ทางซ้ายและ True ทางขวา](aligned-scripts.png)

ทางด้านซ้าย ตัวห้อยเริ่มอยู่ซ้ายกว่าตัวบนตามโค้งของ f ด้านขวา ขอบซ้ายของสองสคริปต์จะตรงกัน

## **เพิ่มเครื่องหมายจำกัด**

ใช้ [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) เพื่อนำนิพจน์ใส่ในเครื่องหมายจำกัด คุณยังสามารถกำหนดอักขระคั่นสำหรับนิพจน์ที่มีหลายอีลีเมนต์

![นิพจน์เครื่องหมายจำกัดที่มี x, y, และ z คั่นด้วยเส้นตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวเครื่องหมายจำกัด**

กำหนด `True` ให้กับ [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามอุปกรณ์ที่สูง หรือกำหนด `False` เพื่อคงขนาดปกติ ใช้ [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) พร้อมค่าใดค่าหนึ่งจาก [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) `Centered` จะจัดวางวงเล็บตรงแกนคณิตศาสตร์ที่วิ่งผ่านสัญลักษณ์เท่ากัน `Match` จะจัดแนวกับเนื้อหาที่ล้อมรอบ ทั้งสองตั้งค่าจะมีผลต่อเครื่องหมายจำกัดเท่านั้น นิพจน์ภายในคงเดิม

ตัวอย่างนี้วางเศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ยืดขึ้นเหนือ baseline มากกว่าต่ำกว่า

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย แถวบนวงเล็บขยายเพื่อคลุมเลขชี้กำลังและดูเหมือนกันสำหรับทั้งสองรูปแบบ แถวล่างการขยายปิด วงเล็บเล็กกว่าทางซ้าย (`Centered`) จัดตรงกับสัญลักษณ์เท่ากัน ขณะที่ด้านขวา (`Match`) อยู่สูงกว่ารอบนิพจน์

![สมการสี่ชุดใน PowerPoint ที่เปิดใช้งานการขยายเครื่องหมายจำกัดด้านบนและปิดด้านล่าง, และ Centered ทางซ้าย, Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องกรอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อกรอบทั่วทั้งนิพจน์ [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) จะแสดงด้านสี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านแต่ละด้าน

ตัวอย่างนี้วางเศษส่วนเดียวกันหกชุดบนสไลด์เดียว เพื่อแสดงการยกเลิก ให้ซ่อนทุกด้านและกำหนด `True` ให้กับ [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อให้เส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อให้เส้นทแยงลง (↘) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับการแสดงด้านใดด้านหนึ่งได้

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นแนวนอน, เส้นแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นแนวนอนทับบาร์ของเศษส่วน เส้นแนวตั้งตัดตัวเศษและตัวส่วนพร้อมกรอบรอบ ๆ ยังคงมองเห็นได้ เส้นเหล่านี้ประดับทั้งหมดของนิพจน์ การขีดฆ่าแบบข้อความปกติใช้กับอักขระในรันข้อความ หลังจากเปิดงานนำเสนอใหม่ใน PowerPoint คุณยังแก้ไขตัวเศษและตัวส่วนได้แยกกัน

## **ควบคุมการมองเห็นและการจัดวางด้วย Phantom Elements**

ใส่นิพจน์ใน [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันให้กับสมการอย่างอิสระ วิธีการของ [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) ควบคุมตามนี้

| วิธี | ผล |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | กำหนด `False` เพื่อซ่อนนิพจน์ มิติของมันยังคงมีส่วนร่วมกับการจัดวางเว้นแต่เมธอดที่เกี่ยวข้องด้านล่างถูกกำหนดเป็น `True` |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | ปรับความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้อีลีเมนต์ข้างเคียงเคลื่อนที่เข้ามาใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | ปรับค่า ascent (ความสูงเหนือ baseline) ของนิพจน์เป็นศูนย์ เพื่อลดพื้นที่สำรองเหนืออีลีเมนต์ข้างเคียง |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | ปรับค่า descent (ความลึกต่ำกว่า baseline) ของนิพจน์เป็นศูนย์ ทำให้บาร์ของเศษส่วนหรือเนื้อหาอื่นใต้นิพจน์เคลื่อนที่ใกล้กับเพื่อนบ้านขึ้น |

Baseline คือเส้นอ้างอิงที่ตัวอักษรคณิตศาสตร์ปกติวางอยู่ การซ่อนเนื้อหาไม่ได้ลบมิติของมันออก และการกำหนดมิติเป็นศูนย์ไม่ได้ลบนิพจน์ออก นิพจน์พื้นฐานยังเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) กำหนด `True` ให้กับ [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติจะคงเดิม

ตัวอย่างด้านล่างสร้างห้ารูปแบบข้างเคียงกัน: เศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่ยังคงพื้นที่, และเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc หรือ ZeroDesc เปิดใช้งาน ทั้งหมดใช้นิพจน์รอบๆเดียวกันและฟอนต์ Cambria Math ขนาด 24 จุด รูปร่างสมการทั้งหมดมีตำแหน่งบนเดียวกันที่แสดงด้วยไกด์สีเทา การใส่ phantom ในตัวเศษของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งเห็นได้ง่ายขึ้น

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

![ห้าสมการใน PowerPoint ที่เปรียบเทียบเศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่ยังคงพื้นที่, และเศษส่วนที่ซ่อนด้วย ZeroWidth, ZeroAsc หรือ ZeroDesc](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) เพื่อใส่ตัวอักขระการจัดกลุ่มเหนือหรือใต้ นิพจน์ เพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายกำกับ any text ด้านล่าง](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยการจัดรูปแบบเท่าที่จำเป็นเพื่อให้สูตรชัดเจน ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) จะใส่บาร์เหนืออีลีเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นบาร์เหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่ ให้เดินผ่านต้นไม้ของอีลีเมนต์แต่ละบล็อกคณิตศาสตร์ [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) จะคืนค่าเฉพาะบุตรขั้นต้น ดังนั้นต้องเรียกแบบรีเคอร์ซีฟเพื่อเข้าถึงข้อความในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอีลีเมนต์ปัจจุบันและบุตรของมันเพื่อรวมอีลีเมนต์เริ่มต้นเมื่อตรงกับ [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้สมมติว่าไฟล์ `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` พร้อมเศษส่วนที่มีตัวห้อยในตัวเศษและรากในตัวส่วน การประมวลผลเฉพาะอีลีเมนต์ระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหาส่วนคณิตศาสตร์ในกรอบข้อความของสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งขนาดฟอนต์เป็น 28 จุดผ่านเมธอด [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละอีลีเมนต์ข้อความ

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

งานนำเสนอที่บันทึกมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล ทั้งยังคงเนื้อความและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| รวมอีลีเมนต์ | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| สร้างเศษส่วน | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| เพิ่มซุปเปอร์สคริปต์หรือซับสคริปต์ | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| เพิ่มรากคณิตศาสตร์ | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| เพิ่มเครื่องหมายจำกัด | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **คำถามที่พบบ่อย**

**สามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่ เปิดงานนำเสนอ ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) เรียก [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) แล้วอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่สามารถแก้ไขได้

**สามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่ ดึง [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง สำหรับตัวอย่างครบถ้วน ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python](/slides/th/python-java/exporting-math-equations/#export-math-equations-to-latex)