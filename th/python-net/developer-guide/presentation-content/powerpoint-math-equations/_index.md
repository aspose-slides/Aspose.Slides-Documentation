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
- การนำเสนอ
- Python
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด Python ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการในรูปแบบ Office Math Markup Language (OMML) ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันโดยใช้โปรแกรมได้ เช่น เศษส่วน, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint, ผู้ใช้ทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจกต์หลัก:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [add_math_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_math_shape/), ซึ่งเป็นรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathblock/)

ตัวอย่างส่วนใหญ่ต่อไปนี้ใช้ [MathematicalText](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathematicaltext/) และเมธอดแบบ fluent จาก [IMathElement](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับกรณีการส่งออก MathML ดูที่ [Export Math Equations from Presentations in Python via .NET](/slides/th/python-net/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้สร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีธากอรัส:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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

`add_math_shape` สร้างรูปร่างที่มี math paragraph อยู่แล้ว. เข้าถึง `MathPortion` ตัวแรก, ดึง `MathParagraph` ของมัน, และเพิ่ม math block หรือ math element ลงในนั้น.

{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [`divide`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/divide/) เพื่อสร้างเศษส่วน. คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซับซ้อน, ใช้ `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **เพิ่มราก**

ใช้ [`radical`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/radical/) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ. อีลีเมนต์ปัจจุบันจะกลายเป็นฐาน, และอาร์กิวเมนต์จะเป็นดีกรี.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

ใช้ [`as_argument_of_function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) หรือ [`function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/function/) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขอบเขต, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathlimit/) หรือใช้ [`set_lower_limit`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นอีลีเมนต์ปัจจุบัน:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [`nary`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/nary/) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ. ใช้ [`integral`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/integral/) สำหรับอินทิกรัล. ทั้งสองเมธอดให้คุณตั้งค่าขอบเขตล่างและบน.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขอบเขตแบบเลือกได้. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะถูกเพิ่มเป็น `MathematicalText` และรวมเข้ากับนิพจน์.

สำหรับอินทิกรัล, ใช้ `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathmatrix/) สำหรับแถวและคอลัมน์. เมทริกซ์โดยปริยายจะไม่มีวงเล็บ, ดังนั้นให้ใส่วงเล็บ, กรอบหรือเครื่องหมายวงเล็บเมื่อจำเป็น.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

ใช้ [`to_math_array`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_math_array/) เมื่อคุณต้องการสมการที่จัดแนวหรือสแตคแนวตั้งของนิพจน์.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

ใช้ [`as_argument_of_function`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) เมื่ออาร์กิวเมนต์เป็นอีลีเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มคำล่างและคำบน**

ใช้ตัวช่วย subscript และ superscript สำหรับดัชนีและกำลัง. เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน, ใช้ [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่งส่วน**

ใช้ [`enclose`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/enclose/) เพื่อใส่นิพจน์ภายในตัวแบ่งส่วน. คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายอีลีเมนต์.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

## **เพิ่มกรอบสี่เหลี่ยม**

ใช้ [`to_border_box`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_border_box/) เมื่อสมการเองควรมีกรอบ.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

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

ใช้ [`group`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/group/) เพื่อตั้งอักขระการจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขอบเขตเพื่อทำป้ายกำกับให้เทอมที่จัดกลุ่ม.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบอีลีเมนต์คณิตศาสตร์**

ใช้ตัวช่วยจัดรูปแบบเฉพาะเมื่อช่วยทำให้สูตรชัดเจน. ตัวอย่างเช่น, [`overbar`](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/overbar/) จะวางบาร์เหนืออีลีเมนต์คณิตศาสตร์.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathematicaltext/) |
| รวมอีลีเมนต์ | [IMathElement.join](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/join/) |
| สร้างเศษส่วน | [IMathElement.divide](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/divide/) |
| เพิ่มซูเปอร์สคริปต์หรือซับสคริปต์ | [set_superscript](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/radical/) |
| เพิ่มขอบเขต | [set_lower_limit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| เพิ่มสคริปต์ด้านซ้าย | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| เพิ่มผลรวมและอินทิกรัล | [nary](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/integral/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [to_math_array](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| เพิ่มตัวแบ่งส่วน | [enclose](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/imathelement/group/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, หารูปร่างที่มี `MathPortion`, ดึง `MathParagraph` ของมัน, แล้วอัปเดต math block ในย่อหน้านั้น.

**สมการบันทึกเป็นคณิตศาสตร์ PowerPoint ที่สามารถแก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

Aspose.Slides ส่งออกสมการคณิตศาสตร์เป็น MathML. หากต้องการ LaTeX, ให้ส่งออกเป็น MathML ก่อนแล้วแปลง MathML ด้วยเครื่องมือที่รองรับไดอะล็อก LaTeX ที่ต้องการ.