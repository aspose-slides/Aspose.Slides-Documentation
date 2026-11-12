---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint ด้วย Python
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "แสดงและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด Python ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยใช้โค้ด: ส่วนเศษส่วน, ราก, ฟังก์ชัน, ลิมิต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อคคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ถูกเลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจ็กต์หลัก:

- รูปร่างคณิตศาสตร์, สร้างด้วย [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), คือรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ภายในเฟรมข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) และเมธอด fluent จาก [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML, ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python via .NET](/slides/th/python-net/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) สร้างรูปร่างที่มีย่อหน้าคณิตศาสตร์อยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ตัวแรก, รับ [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), และเพิ่มบล็อคคณิตศาสตร์หรือองค์ประกอบคณิตศาสตร์ลงไป
{{% /alert %}}

## **เพิ่มส่วนเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างส่วนเศษส่วน. คุณสามารถเลือกสไตล์ส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![ส่วนเศษส่วนเอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับส่วนเศษส่วนแบบซ้อน, ใช้ [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม, หรือรากอื่น. องค์ประกอบปัจจุบันจะกลายเป็นฐาน, และอาร์กิวเมนต์จะเป็นดีกรี.

![นิพจน์ราก n ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มฟังก์ชันและลิมิต**

ใช้ [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) หรือ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันกำหนดเอง. สำหรับลิมิต, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) หรือใช้ [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![ลิมิตของ x เมื่อ x ใกล้อนันต์](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x→∞")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับชื่อฟังก์ชันกำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์ของมัน:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) สำหรับผลรวม, ยูเนียน, อินเตอร์เซคชัน, และตัวดำเนินการขนาดใหญ่อื่น. ใช้ [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล. ทั้งสองเมธอดให้คุณตั้งค่าลิมิตบนและล่างได้.

![ผลรวมที่มีลิมิตบนและล่าง](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N-ary operators เป็นตัวดำเนินการขนาดใหญ่ที่มีลิมิตเป็นตัวเลือก. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` ปกติจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) แล้วต่อเข้ากับนิพจน์

สำหรับอินทิกรัล, ใช้ [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์. เมทริกซ์โดยปกติจะไม่มีวงเล็บ, ดังนั้นให้ใส่วงเล็บ, โครงร่าง, หรือครอสเมื่อจำเป็น

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งเซลล์](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # เมทริกซ์ไม่มีวงเล็บของมันเอง, ดังนั้นให้ใส่ในวงเล็บ
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` สร้างกริดแถวและคอลัมน์, ตั้งค่าช่องว่างระหว่างแถวและคอลัมน์, และจัดแนวคอลัมน์, แต่ Aspose.Slides for Python via .NET ไม่ได้เปิดเผยตัวเข้าถึงเซลล์เมทริกซ์รายตัว. เมทริกซ์ที่สร้างด้วยโค้ดจึงมีเซลล์ว่าง; เซลล์ของเมทริกซ์ที่มาจากงานนำเสนอที่มีอยู่สามารถอ่านได้โดยใช้ `get_children`. ใช้อาเรย์สมการเมื่อคุณต้องการเติมแถวจากโค้ด
{{% /alert %}}

## **เพิ่มอาเรย์สมการ**

ใช้ [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) เมื่อคุณต้องการสมการที่จัดเรียงแนวนอนหรือสแต็กแนวตั้งของนิพจน์

![อาเรย์คณิตศาสตร์แนวตั้งที่ x อยู่เหนือ y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันทราบแล้ว

![ฟังก์ชันตรีโกณมิติ cos ถูกนำไปใช้กับ 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มซับสคริปต์และซูเปอร์สคริปต์**

ใช้ตัวช่วยซับสคริปต์และซูเปอร์สคริปต์สำหรับดัชนีและกำลัง. เมื่อดัชนีต้องอยู่ด้านซ้ายของฐาน, ใช้ [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)

![ตัวอักษร Y ใหญ่ที่มีซับสคริปต์ซ้าย 1 และซูเปอร์สคริปต์ n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มตัวคั่น**

ใช้ [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ไว้ภายในตัวคั่น. คุณยังสามารถตั้งค่าตัวคั่นคั่นหลายองค์ประกอบได้ด้วยอักขระคั่น

![นิพจน์ตัวคั่นที่มี x, y, และ z คั่นด้วยเส้นประแนวตั้ง](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **ขนาดและการจัดตำแหน่งตัวคั่น**

ตั้งค่า [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) เป็น `True` เพื่อให้วงเล็บขยายตามความสูงของโอเปอแรนด์, หรือเป็น `False` เพื่อคงขนาดปกติ. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) รับค่าจากสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` จะวางวงเล็บตรงกลางแกนคณิตศาสตร์, ซึ่งวิ่งผ่านกลางเครื่องหมายเท่ากับ. `MATCH` จะจัดตำแหน่งให้ตรงกับเนื้อหาที่ล้อมไว้. ทั้งสองการตั้งค่ามีผลต่อเฉพาะตัวคั่น; นิพจน์ภายในคงเดิม

ตัวอย่างวางส่วนเศษส่วนในดัชนีของ `x` ทำให้นิพจน์ยืดออกเหนือเส้นฐานมากกว่าที่อยู่ด้านล่าง. สี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย. แถวบนวงเล็บขยายเพื่อครอบดัชนีและดูเหมือนกันในทั้งสองรูป. แถวล่างการขยายปิด. วงเล็บเล็กด้านซ้าย (`CENTERED`) จัดตำแหน่งกับเครื่องหมายเท่ากับ, ส่วนด้านขวา (`MATCH`) อยู่สูงกว่าตามนิพจน์

![สี่สมการใน PowerPoint ที่มีการเปิดใช้งานการขยายตัวของตัวคั่นด้านบนและปิดการทำงานด้านล่าง, โดยด้านซ้ายใช้ CENTERED และด้านขวาใช้ MATCH](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) บนส่วนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด. [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) ที่คืนค่าจะแสดงสี่ด้านตามค่าเริ่มต้น. ใช้ [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), และ [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) เพื่อลบสายในแต่ละด้าน

ตัวอย่างวางหกสำเนาของส่วนเศษส่วนเดียวกันบนสไลด์เดียว. เพื่อแสดงการยกเลิก, ซ่อนสี่ด้านทั้งหมดและตั้งค่า [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) สำหรับเส้นทแยงขึ้น (↗) หรือ [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) สำหรับเส้นทแยงลง (↘). คุณยังสามารถใช้ [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) หรือ [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) ด้วยการผสมผสานด้านที่มองเห็น

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![หกส่วนเศษส่วนที่สามารถแก้ไขได้ใน PowerPoint. แถวบน: ขอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นทแยงแนวนอน, เส้นทแยงแนวตั้งพร้อมขอบเต็ม](border-box-fractions.png)

บนส่วนนี้ เส้นแนวนอนทับบาร์ส่วนเศษส่วน. เส้นแนวตั้งตัดส่วนเศษส่วนบนและล่างในขณะที่กรอบรอบนอกยังคงมองเห็นได้. เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด. การขีดเส้นกลางข้อความธรรมดาจะใช้กับอักขระในรันข้อความ. หลังจากเปิดไฟล์งานนำเสนอใน PowerPoint อีกครั้ง คุณยังสามารถแก้ไขตัวเศษและตัวส่วนแยกกันได้

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) เพื่อใส่ตัวอักษรจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มลิมิตเพื่อทำป้ายกำกับให้กับเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายข้อความใด ๆ ด้านล่าง](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อมันทำให้สูตรเข้าใจง่ายขึ้น. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) วางบาร์เหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นบาร์เหนือ](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความในสมการที่มีอยู่, ให้เดินทางผ่านต้นไม้ของแต่ละบล็อคคณิตศาสตร์. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) คืนค่าเฉพาะลูกโดยตรง, ดังนั้นเรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความภายในส่วนเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อมันเป็น [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, โดยส่วนเศษส่วนมีซับสคริปต์ในตัวเศษและรากในตัวส่วน. การประมวลผลเฉพาะองค์ประกอบระดับบนสุดของบล็อคจะพลาดข้อความภายในส่วนเศษส่วน. ตัวอย่างค้นหา MathPortion ในเฟรมข้อความของสไลด์, เข้าถึงบล็อคผ่าน [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), และตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) เป็น 28 จุดผ่าน property [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) ของแต่ละข้อความ

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

งานนำเสนอที่บันทึกไว้จะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล, โดยยังคงเนื้อหาและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงอย่างเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| รวมองค์ประกอบ | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| สร้างส่วนเศษส่วน | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มซูเปอร์สคริปต์หรือซับสคริปต์ | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มลิมิต | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| เพิ่มสคริปต์ด้านซ้าย | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| เพิ่มผลรวมและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| เพิ่มตัวคั่น | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และขอบ | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), รับ [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), และอัปเดตบล็อคคณิตศาสตร์ในย่อหน้านั้น

**สมการจะถูกบันทึกเป็น PowerPoint Math ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides เขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกรูปสมการเป็น LaTeX ได้หรือไม่?**

ใช่. รับ [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), แล้วเรียก [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) เพื่อส่งออกโดยตรง. สำหรับตัวอย่างเต็ม, ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python via .NET](/slides/th/python-net/exporting-math-equations/#export-math-equations-to-latex)