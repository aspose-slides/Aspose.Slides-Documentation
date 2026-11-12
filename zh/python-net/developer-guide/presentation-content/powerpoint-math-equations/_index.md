---
title: 在 Python 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/python-net/powerpoint-math-equations/
keywords:
- 数学等式
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 Python 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for Python via .NET，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常从 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡，已选择公式命令](powerpoint-math-equations_1.png)

结果是幻灯片上的可编辑数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 数学形状，由 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 创建，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 在形状文本框内部存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 以及来自 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 的流畅方法，以保持代码简短且易读。

对于 MathML 导出场景，请参见 [从演示文稿导出数学公式（Python via .NET）](/slides/zh/python-net/exporting-math-equations/)。

## **创建公式**

此示例使用 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 创建数学形状，并添加勾股定理：

![c 的平方等于 a 的平方加 b 的平方](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 创建的形状已经包含一个数学段落。访问第一个 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)，获取其 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) 选择分数样式。

![一个倾斜的数学分数，显示 1 除以 x](powerpoint-math-equations_4.png)

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

对于堆叠式分数，使用 [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)：

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **添加根式**

使用 [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) 创建平方根、立方根或其他根式。当前元素成为底数，参数成为指数。

![在根号下带有 x 的 n 次根表达式](powerpoint-math-equations_5.png)

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

使用 [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 或 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) 处理诸如 `sin(x)`、`log(x)` 或自定义函数名的函数。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 中，或使用 [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)。

![x 趋于无穷大的极限](powerpoint-math-equations_8.png)

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

对于自定义函数名，将函数名设为当前元素，并使用其参数调用 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/)：

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **添加 N 元运算符和积分**

使用 [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) 处理求和、并集、交集以及其他大型运算符。使用 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) 处理积分。这两种方法都可以设置上下限。

![带上下限的求和](powerpoint-math-equations_7.png)

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

N 元运算符用于带可选上下限的大型运算符。诸如 `+`、`-`、`=` 等简单运算符通常作为 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 添加并组合到表达式中。

对于积分，使用 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)：

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) 定义行和列。矩阵默认不包含括号，因此在需要圆括号、方括号或大括号时请自行将矩阵包裹起来。

![一个包含两个行且有一个空单元格的数学矩阵](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # 矩阵本身没有括号，因此用圆括号将其包裹。
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` 构建行列网格，设置它们之间的间隙并对齐列，但 Aspose.Slides for Python via .NET 未公开对单个矩阵单元格的访问器。因此，在代码中创建的矩阵会保留空单元格；从现有演示文稿中得到的矩阵的单元格可通过 `get_children` 读取。需要在代码中填充行时，请使用公式数组。
{{% /alert %}}

## **添加公式数组**

当需要对齐的公式或垂直堆叠的表达式时，请使用 [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/)。

![一个垂直的数学数组，x 在 y 上方](powerpoint-math-equations_11.png)

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

### **对齐数组与周围元素**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) 控制数组相对于其旁边数学元素的垂直对齐方式。下面的示例比较了第一行、数组中心和最后一行的对齐情况。

以下示例创建了三个相同的数组，每个数组有三行，并在旁边放置元素 `A=` 和 `=B`。所有数学文本使用 24 磅 Cambria Math。仅更改数组对齐方式。

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

下面的比较展示了在 PowerPoint 中保存的演示文稿。注意每个数组旁边的 `A=` 和 `=B` 的位置。

![PowerPoint 中的公式数组，分别采用顶部、居中和底部对齐，且相邻元素相同](equation-array-alignment.png)

### **配置行间距**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) 选择数组中行的间距规则。[row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) 为显式间距规则提供数值，并在使用预设规则时被忽略。

对于精确间距，数值以磅为单位。对于比例间距，数值以半行计：示例中值 `3` 表示 1.5 行。当指定显式值时，需要同时设置这两个属性；仅更改数值而不设置规则不会生效。

下面的示例保存了五个演示文稿，使用相同的公式、对齐和字体设置。前三个使用预设，后两个显示显式数值。

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

数组行间距独立于段落间距。[space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) 和 [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) 为包含段落的上下添加空间，而不是在数组行之间添加。同样，[IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) 水平定位整个数学段落；它不替代数组的垂直对齐设置。

## **添加三角函数**

当参数是当前元素且函数名称已知时，使用 [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

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

使用下标和上标辅助方法来处理索引和幂。当索引必须出现在基数的左侧时，使用 [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)。

![字母 Y 的左侧下标 1 与上标 n](powerpoint-math-equations_9.png)

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

使用 [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) 将表达式放入分界符中。对于包含多个元素的分界符表达式，还可以设置分隔字符。

![包含 x、y、z 并以竖线分隔的分界符表达式](powerpoint-math-equations_13.png)

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

### **大小与对齐分界符**

将 [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) 设置为 `True`，使括号随较高的操作数而增大；设置为 `False` 则保持常规大小。[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) 采用两种 [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) 值之一。`CENTERED` 将括号在数学轴上居中，对应等号的中线。`MATCH` 将括号与所包围的内容对齐。这两个设置仅影响分界符本身，内部表达式保持不变。

示例将分数放在 `x` 的指数位置，使表达式在基线上方的延伸超过下方。所有四个公式使用相同的括号和字体设置。

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

在 PowerPoint 中，比较各行可见增长效果。顶部行的括号随指数增长并在两种形状下表现相同。底部行关闭增长。左侧的较小括号（`CENTERED`）与等号对齐，而右侧（`MATCH`）则在表达式上方更高。

![PowerPoint 中的四个公式，括号在上方启用增长、下方禁用，左侧为 CENTERED，右侧为 MATCH](delimiter-sizing.png)

## **添加边框盒**

在分数上调用 [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) 可为整个表达式加框。返回的 [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) 默认显示四条边。使用 [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)、[hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)、[hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/) 和 [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) 可去除个别边。

示例在同一幻灯片上放置了同一分数的六个副本。为了显示取消线，隐藏四条边，并使用 [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) 显示从左下到右上的对角线 (↗)，或使用 [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) 显示从左上到右下的对角线 (↘)。还可以使用 [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) 或 [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/)，并结合任意可见边的组合。

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

![PowerPoint 中的六个可编辑分数。顶部行：完整边框、底部和左侧边框、上升对角线。底部行：下降对角线、水平划线、垂直划线并带完整边框。](border-box-fractions.png)

在此分数上，水平划线与分数线重叠。垂直划线穿过分子和分母，同时保留外围边框可见。这些线装饰整个表达式。普通文本的删除线仅作用于文本运行中的字符。重新在 PowerPoint 中打开演示文稿后，仍可分别编辑分子和分母。

## **分组项**

使用 [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) 在表达式上方或下方放置分组字符。添加上下限以标记分组的项。

![表达式 x 加 y，使用标签任意文本在下方进行分组](powerpoint-math-equations_15.png)

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

仅在有助于阐明公式时使用格式化辅助方法。例如，[overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) 在数学元素上方添加横线。

![带有上横线的数学表达式 ABC](powerpoint-math-equations_14.png)

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

### **在现有公式中格式化文本**

要在现有公式中格式化文本，请遍历每个数学块的元素树。[IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) 只返回直接子元素，因此需要递归调用以访问分数、上下标、根式和其他嵌套结构中的文本。检查当前元素及其子元素，以在它是 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 时也包含起始元素。

此示例假设 `input.pptx` 包含类似 `z = xᵢ / ∛y` 的公式，其中分子包含下标，分母包含根式。仅处理块的顶层元素会遗漏分数内部的文本。示例在幻灯片文本框中查找数学片段，通过 [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) 访问其块，并通过每个文本元素的 [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) 属性将 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 设置为 28 磅。

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

保存的演示文稿在每个处理过的公式的各层级都更新了文本格式，同时保留了文本内容和数学结构。

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 组合元素 | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| 创建分数 | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 添加上标或下标 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 添加函数 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 添加根式 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 添加极限 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 添加左侧脚本 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 添加公式数组 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 添加分界符 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 分组项 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **常见问题**

**我可以编辑现有的 PowerPoint 公式吗？**

是的。打开演示文稿，找到包含 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 的形状，获取其 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)，并更新该段落中的数学块。

**公式是否以可编辑的 PowerPoint 数学格式保存？**

是的。保存为 PPTX 时，Aspose.Slides 将公式写入可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

是的。从其 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 获取公式的 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)，然后调用 [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) 直接导出。完整示例请参见 [从演示文稿导出数学公式（Python via .NET）](/slides/zh/python-net/exporting-math-equations/#export-math-equations-to-latex)。