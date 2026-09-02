---
title: เพิ่มสมการคณิตศาสตร์ลงในงานนำเสนอ PowerPoint ด้วย Python
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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides for Python via .NET รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint เก็บสมการเป็น Office Math Markup Language (OMML) ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยโปรแกรมเม็ต: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้โดยทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจกต์หลัก:

- รูปคณิตศาสตร์ที่สร้างด้วย [add_math_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_math_shape/), คือรูปที่ประกอบด้วยสมการ.
- [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูป.
- [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathematicaltext/) และเมธอด fluent จาก [IMathElement](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/) เพื่อให้โค้ดสั้นและอ่านง่าย.

สำหรับกรณีส่งออก MathML ดูที่ [Export Math Equations from Presentations in Python via .NET](/slides/th/python-net/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้สร้างรูปคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

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

{{% alert color="primary" %}}
`add_math_shape` สร้างรูปที่มีย่อหน้าคณิตศาสตร์อยู่แล้ว เข้าถึง `MathPortion` ตัวแรก, เรียก `MathParagraph` ของมัน, แล้วเพิ่มบล็อกคณิตศาสตร์หรือองค์ประกอบคณิตศาสตร์ลงไป.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [`divide`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนได้ด้วย [MathFractionTypes](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathfractiontypes/).

![เศษส่วนคณิตศาสตร์เอียงที่แสดง 1 หารด้วย x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อน, ใช้ `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **เพิ่มราก**

ใช้ [`radical`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ ส่วนประกอบปัจจุบันจะเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี.

![นิพจน์รากที่ n โดยมี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [`as_argument_of_function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) หรือ [`function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันกำหนดเอง สำหรับขีดจำกัด, ใส่ `lim` ลงใน [MathLimit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathlimit/) หรือใช้ [`set_lower_limit`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![ขีดจำกัดของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันกำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นส่วนประกอบปัจจุบัน:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิเกรต**

ใช้ [`nary`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/nary/) สำหรับการบวก, ยูเนียน, อินเตอร์เซคชัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [`integral`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิเกรต ทั้งสองเมธอดให้คุณกำหนดขีดจำกัดล่างและบน.

![การบวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นตัวเลือก ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น `MathematicalText` แล้วเชื่อมต่อเป็นนิพจน์.

สำหรับอินทิเกรต, ใช้ `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ ดังนั้นให้ล้อมเมทริกซ์ด้วยวงเล็บ, วงกลม, หรือเครื่องหมายครอบเมื่อจำเป็น.

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มอาเรย์สมการ**

ใช้ [`to_math_array`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_math_array/) เมื่อคุณต้องการสมการที่จัดแนวหรือสแต็กแนวตั้งของนิพจน์.

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

ใช้ [`as_argument_of_function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) เมื่ออาร์กิวเมนต์เป็นส่วนประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

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

ใช้ตัวช่วยสำหรับตัวห้อยและตัวยกสำหรับดัชนีและกำลัง เมื่อต้องการให้ดัชนีแสดงทางด้านซ้ายของฐาน, ใช้ [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![ตัวอักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อย 1 ทางซ้ายและตัวยก n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่ง**

ใช้ [`enclose`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ภายในตัวแบ่ง คุณยังสามารถกำหนดอักขระตัวแบ่งสำหรับนิพจน์ที่มีหลายส่วนประกอบ.

![นิพจน์ตัวแบ่งที่มี x, y, และ z แยกด้วยเส้นแนวตั้ง](powerpoint-math-equations_13.png)

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

## **เพิ่มกล่องกรอบ**

ใช้ [`to_border_box`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_border_box/) เมื่อสมการเองควรมีกรอบ.

![สมการในกล่องที่แสดง a กำลังสองเท่ากับ b กำลังสองบวก c กำลังสอง](powerpoint-math-equations_12.png)

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

ใช้ [`group`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/group/) เพื่อวางอักขระจัดกลุ่มเหนือหรือต่ำกว่านิพจน์ เพิ่มขีดจำกัดเพื่อทำป้ายให้กับเทอมที่จัดกลุ่ม.

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

ใช้ตัวช่วยจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรชัดเจน ตัวอย่างเช่น [`overbar`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/overbar/) วางเส้นบาร์เหนือองค์ประกอบคณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC ที่มีบาร์เหนือ](powerpoint-math-equations_14.png)

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

## **อ้างอิงด่วน**

| Task | Main API |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathematicaltext/) |
| รวมองค์ประกอบ | [IMathElement.join](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.divide](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มตัวยกหรือห้อย | [set_superscript](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขีดจำกัด | [set_lower_limit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| เพิ่มสคริปต์ด้านซ้าย | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| เพิ่มการบวกและอินทิเกรต | [nary](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [to_math_array](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| เพิ่มตัวแบ่ง | [enclose](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่ เปิดงานนำเสนอ, ค้นหารูปที่มี `MathPortion`, เรียก `MathParagraph` ของมัน, แล้วอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น.

**สมการจะถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่สามารถแก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่สามารถแก้ไขได้.

**ฉันสามารถส่งออกรูปสมการเป็น LaTeX ได้หรือไม่?**

ใช่ ดึง [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/), แล้วเรียก [MathParagraph.to_latex](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) เพื่อส่งออกโดยตรง สำหรับตัวอย่างครบถ้วน ดูที่ [Export Math Equations from Presentations in Python via .NET](/slides/th/python-net/exporting-math-equations/#export-math-equations-to-latex).