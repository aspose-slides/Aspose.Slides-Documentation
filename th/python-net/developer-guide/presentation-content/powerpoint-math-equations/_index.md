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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) กับ Aspose.Slides สำหรับ Python ผ่าน .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันได้โดยเขียนโปรแกรม: ส่วนขาตรง, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N‑ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปจะเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), เป็นรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) และเมธอดแบบ fluent จาก [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับสถานการณ์การส่งออก MathML ให้ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python ผ่าน .NET](/slides/th/python-net/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มสูตรพีทากอรัส:

![สมการ c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="หมายเหตุ" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) สร้างรูปร่างที่มี math paragraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ตัวแรก, รับ [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), และเพิ่มบล็อกคณิตศาสตร์หรืออิลิเมนต์คณิตศาสตร์เข้าไป
{{% /alert %}}

## **เพิ่มส่วนขาตรง**

ใช้ [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างส่วนขาตรง คุณสามารถเลือกสไตล์ส่วนขาตรงด้วย [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![ส่วนขาตรงเอียงแสดง 1 ÷ x](powerpoint-math-equations_4.png)

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

สำหรับส่วนขาตรงซ้อนกัน ใช้ [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ อิลิเมนต์ปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![สมการราก n‑th ที่มี x ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขอบเขต**

ใช้ [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) หรือ [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับขอบเขตให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) หรือใช้ [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![ขอบเขตของ x เมื่อ x ใกล้ค่าอนันต์](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับชื่อฟังก์ชันที่กำหนดเอง ให้ทำให้ชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) พร้อมอาร์กิวเมนต์ของมัน:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) สำหรับการบวก, การรวม, การตัดกัน ฯลฯ Use [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล ทั้งสองเมธอดให้กำหนดขอบเขตล่างและบน

![ผลบวกที่มีขอบเขตล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการใหญ่ที่มีขอบเขตเป็นตัวเลือก ตัวดำเนินการแบบง่ายเช่น `+`, `-`, `=` ส่วนใหญ่จะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) และต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ใช้ [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยปกติไม่มีวงเล็บ จึงต้องใส่วงเล็บเองเมื่อจำเป็น

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งเซลล์](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # เมทริกซ์ไม่มีวงเล็บของตัวเอง ดังนั้นให้ล้อมไว้ในวงเล็บ.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="คำเตือน" %}}
`MathMatrix` สร้างกริดแถวและคอลัมน์, ตั้งค่าช่องว่างระหว่างมัน, และจัดแนวคอลัมน์, แต่ Aspose.Slides for Python via .NET ไม่ได้เปิดให้เข้าถึงเซลล์เมทริกซ์แต่ละเซลล์ เมทริกซ์ที่สร้างจากโค้ดจึงอาจมีเซลล์ว่าง; เซลล์ของเมทริกซ์ที่มาจากงานนำเสนอที่มีอยู่สามารถอ่านได้ด้วย `get_children` ใช้อาเรย์สมการเมื่อจำเป็นต้องเติมแถวจากโค้ด
{{% /alert %}}

## **เพิ่มอาร์เรย์สมการ**

ใช้ [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) เมื่อจำเป็นต้องจัดสมการให้ตรงกันหรือต้องการเรียงแนวตั้งของนิพจน์

![อาร์เรย์คณิตศาสตร์แนวตั้งที่ x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

ใช้ [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) เมื่ออาร์กิวเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่รู้จัก

![ฟังก์ชันตรีโกณมิติ cos ที่นำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวยก**

ใช้เครื่องมือช่วยสร้างตัวห้อยและตัวยกสำหรับดัชนีและกำลัง เมื่อดัชนีต้องแสดงด้านซ้ายของฐาน ให้ใช้ [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![ตัว Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ด้านซ้ายและตัวยก n ด้านซ้าย](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวจำกัด**

ใช้ [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ไว้ในตัวจำกัด คุณยังสามารถตั้งค่าตัวอักษรคั่นสำหรับนิพจน์ที่มีหลายอิลิเมนต์ได้

![นิพจน์ตัวจำกัดที่ประกอบด้วย x, y, z คั่นด้วยบาร์แนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวตัวจำกัด**

ตั้งค่า [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) เป็น `True` เพื่อให้วงเล็บขยายตามความสูงของโอเปอแรนด์, หรือเป็น `False` เพื่อคงขนาดปกติ [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) รับค่าจาก [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) สองค่า `CENTERED` จะจัดศูนย์วงเล็บบนแกนคณิตศาสตร์, `MATCH` จะจัดให้ตรงกับเนื้อหาที่ล้อมไว้ ทั้งสองตั้งค่าส่งผลต่อเพียงตัวจำกัด นิพจน์ภายในคงเดิม

ตัวอย่างวางส่วนขาตรงในเลขชี้กำลังของ `x` ทำให้นิพจน์ขยายสูงกว่าฐานมากกว่าเดิม ทั้งสี่สมการใช้วงเล็บและการตั้งค่าแบบเดียวกัน

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

ใน PowerPoint เปรียบเทียบแถวเพื่อดูผลของการขยาย ในแถวบนวงเล็บขยายเพื่อคลุมเลขชี้กำลังและดูคล้ายกันสำหรับทั้งสองรูปร่าง ในแถวล่างการขยายปิด วงเล็บเล็กด้านซ้าย (`CENTERED`) จัดกับเครื่องหมายเท่ากับ, ส่วนด้านขวา (`MATCH`) อยู่สูงขึ้นรอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิดใช้งานการขยายตัวจำกัดด้านบนและปิดด้านล่าง, โดยด้านซ้ายใช้ Centered และด้านขวาใช้ Match](delimiter-sizing.png)

## **เพิ่มกรอบล้อม**

ใช้ [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) เมื่อสมการควรมีกรอบล้อม

![สมการที่ล้อมกรอบแสดง a² = b² + c²](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้ นิพจน์ แล้วใส่ขอบเขตเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มพร้อมฉลากข้อความใดก็ได้ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบอิลิเมนต์คณิตศาสตร์**

ใช้เครื่องมือจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) ใส่แถบเหนืออิลิเมนต์คณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีแถบเหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่ ให้เดินทางไปรอบๆ ต้นไม้ของอิลิเมนต์ในแต่ละ math block [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) จะคืนเฉพาะลูกโดยตรง จึงต้องเรียกแบบเรียกซ้ำเพื่อถึงข้อความภายในส่วนขาตรง, ตัวห้อย, ราก และโครงสร้างซ้อนอื่น ๆ ตรวจสอบอิลิเมนต์ปัจจุบันและลูกของมันเพื่อรวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` ที่ส่วนขาตรงมีตัวห้อยในตัวเศษและรากในตัวส่วน การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะพลาดข้อความในส่วนขาตรง ตัวอย่างค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), แล้วตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) ที่ 28 จุดให้กับแต่ละอิลิเมนต์ข้อความผ่านคุณสมบัติ [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/)

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

การบันทึกงานนำเสนอจะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อหาและโครงสร้างคณิตศาสตร์เดิม

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| สร้างส่วนขาตรง | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวยกหรือห้อย | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขอบเขต | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| เพิ่มสคริปต์ด้านซ้าย | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| เพิ่มตัวจำกัด | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มแถบและกรอบ | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), รับ [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), แล้วอัปเดตบล็อกคณิตศาสตร์ในพารากราฟนั้น

**สมการถูกบันทึกเป็น PowerPoint math ที่สามารถแก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. รับ [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), แล้วเรียก [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) เพื่อส่งออกโดยตรง สำหรับตัวอย่างเต็ม ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python ผ่าน .NET](/slides/th/python-net/exporting-math-equations/#export-math-equations-to-latex).