---
title: 在 Python 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/python-net/powerpoint-math-equations/
keywords:
- 数学公式
- 数学符号
- 数学公式
- 数学文本
- 添加数学公式
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 Python 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for Python via .NET，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **Insert > Equation** 添加公式：

![PowerPoint Insert 选项卡中选中的 Equation 命令](powerpoint-math-equations_1.png)

结果是在幻灯片上出现可编辑的数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过以下三种主要对象构建该数学文本：

- 使用 [add_math_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_math_shape/) 创建的数学形状，即包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathportion/) 在形状的文本框中存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathematicaltext/) 和来自 [IMathElement](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/) 的流式方法，以保持代码简洁易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in Python via .NET](/slides/zh/python-net/exporting-math-equations/)。

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![公式 c² = a² + b² 的示意图](powerpoint-math-equations_3.png)

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
`add_math_shape` 创建的形状已包含一个数学段落。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其中添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 [`divide`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/divide/) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathfractiontypes/) 选择分数样式。

![一个倾斜的分数，显示 1 除以 x](powerpoint-math-equations_4.png)

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

对于堆叠式分数，使用 `MathFractionTypes.BAR`：

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **添加根式**

使用 [`radical`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/radical/) 创建平方根、立方根或其他根式。当前元素成为底数，参数成为指数。

![一个 n 次根式，x 位于根号下方](powerpoint-math-equations_5.png)

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

## **添加函数和极限**

使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 或 [`function`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/function/) 来表示 `sin(x)`、`log(x)` 或自定义函数名等函数。对于极限，可在 [MathLimit](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathlimit/) 中放置 `lim`，或使用 [`set_lower_limit`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)。

![极限表达式：x 趋于无穷大时的极限](powerpoint-math-equations_8.png)

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

对于自定义函数名，只需将函数名设为当前元素：

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **添加 N 元运算符和积分**

使用 [`nary`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/nary/) 可生成求和、并集、交集等大型运算符。使用 [`integral`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/integral/) 可生成积分。两者都允许设置上下限。

![带有上下限的求和符号示例](powerpoint-math-equations_7.png)

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

N 元运算符用于带可选上下限的大型运算符。像 `+`、`-`、`=` 这样的普通运算符通常作为 `MathematicalText` 添加并拼接到表达式中。

对于积分，使用 `integral`：

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathmatrix/) 定义行列。矩阵默认不包含括号，如需括号、方括号或大括号，请自行在矩阵外添加相应符号。

![一个两行矩阵，其中一个单元格为空](powerpoint-math-equations_10.png)

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

## **添加公式数组**

当需要对齐的公式或垂直堆叠的表达式时，使用 [`to_math_array`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/to_math_array/)。

![一个垂直排列的数学数组，x 在 y 上方](powerpoint-math-equations_11.png)

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

## **添加三角函数**

当函数名已知且参数为当前元素时，使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)。

![三角函数 cos 应用于 2x 的示例](powerpoint-math-equations_6.png)

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

## **添加下标和上标**

使用下标和上标助手添加指数和下标。当下标需要出现在基准左侧时，使用 [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)。

![字母 Y 左侧带下标 1、上标 n 的示例](powerpoint-math-equations_9.png)

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

## **添加分界符**

使用 [`enclose`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/enclose/) 将表达式包裹在分界符内。对于包含多个元素的分界符表达式，还可以设置分隔符字符。

![包含 x、y、z，并用竖线分隔的分界符表达式示例](powerpoint-math-equations_13.png)

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

## **添加边框盒**

使用 [`to_border_box`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/to_border_box/) 将整个公式框起来。

![一个带边框的公式，表示 a² = b² + c² 的示例](powerpoint-math-equations_12.png)

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

## **分组项**

使用 [`group`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/group/) 在表达式上方或下方放置分组字符。可以添加限制以标记分组项。

![表达式 x + y 之下带有“任意文本”标签的分组示例](powerpoint-math-equations_15.png)

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

## **格式化数学元素**

仅在有助于澄清公式时使用格式化助手。例如，[`overbar`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/overbar/) 在数学元素上方添加横线。

![带上划线的数学表达式 ABC 示例](powerpoint-math-equations_14.png)

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

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 合并元素 | [IMathElement.join](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/join/) |
| 创建分数 | [IMathElement.divide](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 添加上标或下标 | [set_superscript](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 添加函数 | [function](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 添加根式 | [radical](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 添加极限 | [set_lower_limit](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 添加左侧脚本 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 添加求和与积分 | [nary](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/mathmatrix/) |
| 添加公式数组 | [to_math_array](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 添加分界符 | [enclose](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 分组项 | [group](https://reference.aspose.com/slides/zh/python-net/aspose.slides.mathtext/imathelement/group/) |

## **常见问题解答**

**我可以编辑已有的 PowerPoint 公式吗？**

可以。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，并在该段落中更新数学块。

**公式会以可编辑的 PowerPoint 数学形式保存吗？**

会。保存为 PPTX 时，Aspose.Slides 会将公式写入可编辑的 Office 数学内容。

**我能将公式导出为 LaTeX 吗？**

Aspose.Slides 将公式导出为 MathML。如果需要 LaTeX，请先导出为 MathML，然后使用支持目标 LaTeX 方言的工具将 MathML 转换为 LaTeX。