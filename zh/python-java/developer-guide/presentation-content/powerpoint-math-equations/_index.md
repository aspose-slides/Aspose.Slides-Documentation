---
title: 在 Python 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 Python 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for Python via Java，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组和格式化的数学块。

在 PowerPoint 中，用户通常通过 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡选择了“公式”命令](powerpoint-math-equations_1.png)

结果是在幻灯片上出现可编辑的数学文本：

![包含可编辑公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过以下三个主要对象构建该数学文本：

- 使用 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 创建的数学形状，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 在形状文本框内部存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 和来自 [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) 的流式方法，以保持代码简洁易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in Python](/slides/zh/python-java/exporting-math-equations/)。

## **创建公式**

此示例使用 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 创建数学形状并添加勾股定理：

![公式 c² = a² + b² 的示意图](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 会创建一个已包含数学段落的形状。访问第一个 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)，调用 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) 选择分数样式。

![斜切分数示例，显示 1 除以 x](powerpoint-math-equations_4.png)

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

对于堆叠分数，使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **添加根式**

使用 [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) 创建平方根、立方根或其他根。当前元素成为底数，参数成为指数。

![含有 x 的 n 次根式示意图](powerpoint-math-equations_5.png)

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

## **添加函数和极限**

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) 来表示 `sin(x)`、`log(x)` 或自定义函数名称。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) 或使用 [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)。

![极限表达式 limₓ→∞](powerpoint-math-equations_8.png)

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

对于自定义函数名称，将函数名设为当前元素，然后使用其参数调用 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **添加 N 元运算符和积分**

使用 [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) 表示求和、并集、交集等大型运算符。使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) 表示积分。两者均可设置上下限。

![带上下限的求和符号示例](powerpoint-math-equations_7.png)

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

N 元运算符用于带可选上下限的大型运算符。像 `+`、`-`、`=` 这样的普通运算符通常使用 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 并直接加入表达式。

对于积分，使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral)：

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

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) 定义行列。矩阵默认不带括号，需要时自行在外部添加圆括号、方括号或大括号。

![两行矩阵，其中一个单元格为空](powerpoint-math-equations_10.png)

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

## **添加公式数组**

使用 [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) 可实现对齐的公式或垂直堆叠的表达式。

![垂直排列的数组，x 在上方，y 在下方](powerpoint-math-equations_11.png)

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

### **将数组与周围元素对齐**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) 控制数组相对于旁边数学元素的垂直对齐方式。下面的示例比较了以首行、数组中心和末行对齐的效果。

以下示例创建了三个相同的数组，每个数组有三行，并在其左右分别放置 `A=` 和 `=B`。所有数学文本均使用 Cambria Math，字号 24pt，仅更改数组对齐方式。

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

下面的比较显示了在 PowerPoint 中保存后的演示文稿。请留意每个数组旁边的 `A=` 与 `=B` 位置。

![PowerPoint 中的公式数组，分别展示顶部、居中和底部对齐，且相邻元素相同](equation-array-alignment.png)

### **配置行间距**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) 选择数组内部行的间距规则。 [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) 为显式间距规则提供数值，该数值在使用预设规则时会被忽略。

对于精确间距，数值以磅（points）为单位；对于比例间距，以半行（half‑lines）计数：示例中的数值 `3` 表示 1.5 行。设置显式值时需同时指定两项属性，仅更改数值不会自动选择间距规则。

下面的示例保存了五个演示文稿，公式、对齐方式和字体设置相同。前三采用预设，后两展示显式数值。

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

数组的行间距独立于段落间距。 [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) 作用于包含段落的上下留白，而不是数组行之间的间距。同样， [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) 负责整体数学段落的水平定位，并不替代数组的垂直对齐设置。

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

![三角函数 cos applied to 2x 的示例](powerpoint-math-equations_6.png)

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

## **添加下标和上标**

使用下标和上标辅助方法来表示索引和幂。当索引需要显示在基数左侧时，使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![左侧带下标 1 和上标 n 的大写字母 Y 示意图](powerpoint-math-equations_9.png)

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

## **添加分隔符**

使用 [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) 将表达式包裹在分隔符内。对于包含多个元素的分隔符表达式，还可以设置分隔字符。

![用竖线分隔 x、y、z 的分隔符表达式示意图](powerpoint-math-equations_13.png)

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

### **大小和对齐分隔符**

将 `True` 传递给 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) 可使括号随高操作数自动伸长，传 `False` 则保持正常大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) 并选择两种 [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) 之一。`Centered` 将括号在数学轴上居中（轴穿过等号中线），`Match` 则与包含内容对齐。两者仅影响分隔符本身，内部表达式保持不变。

示例在 `x` 的指数位置放置一个分数，使表达式在基线以上的伸展程度大于基线以下。四个公式使用相同的括号和字体设置。

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

在 PowerPoint 中对比上下两行可见效果。顶部行的括号随指数伸长且两种形状看起来相同；底部行关闭伸长功能。左侧的 `Centered` 括号与等号对齐，右侧的 `Match` 括号则在表达式上方更高。

![四个公式示例，分别展示分隔符伸长开启与关闭的对比，左侧使用 Centered，右侧使用 Match](delimiter-sizing.png)

## **添加边框框**

对分数调用 [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) 可为整个表达式添加边框。返回的 [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) 默认显示四条边。使用 [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) 和 [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) 可单独隐藏边。

示例在同一幻灯片上放置六个相同的分数。为了演示取消线，先隐藏所有四条边，然后将 `True` 传递给 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 生成左下到右上的对角线（↗），或调用 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) 生成右下到左上的对角线（↘）。也可以使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 并与任意可见边组合。

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

![六个可编辑分数的示例。上排：完整边框、仅保留下方和左侧边、升斜线。下排：降斜线、水平删除线、垂直删除线并保留完整边框](border-box-fractions.png)

在此分数上，水平删除线会与分数线重叠；垂直删除线会穿过分子和分母，而外部边框仍然可见。这些线装饰整个表达式。普通文本的删除线仅作用于文本运行中的字符。重新在 PowerPoint 中打开演示文稿后，仍可分别编辑分子和分母。

## **对项进行分组**

使用 [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) 可在表达式上方或下方放置分组符号。可以为分组添加极限以标注分组项。

![表达式 x + y 下面带有“任意文本”标签的分组示例](powerpoint-math-equations_15.png)

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

## **格式化数学元素**

仅在能够提升公式可读性时使用格式化辅助方法。例如，[overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) 可在数学元素上方添加一条横线。

![带有上横线的 ABC 公式示例](powerpoint-math-equations_14.png)

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

### **在已有公式中格式化文本**

要在已有公式中统一格式化文本，需要遍历每个数学块的元素树。 [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) 只返回直接子节点，需递归调用才能到达分数、上下标、根式及其他嵌套结构中的文本。检查当前元素以及其子元素，以便在当前元素是 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 时也能被处理。

本示例假设 `input.pptx` 中包含类似 `z = xᵢ / ∛y` 的公式，其中分子含有下标，分母含有根式。仅处理块的顶层元素会漏掉分数内部的文本。示例在幻灯片文本框中查找数学段落，获取其块，通过 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) 访问，并使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 将每个文本元素的字体大小设为 28 磅，调用其 [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) 方法。

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

保存后的演示文稿在每个已处理公式的所有层级中都应用了更新后的文本格式，同时保持了原始的文本内容和数学结构。

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| 合并元素 | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| 创建分数 | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| 添加上标或下标 | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| 添加函数 | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| 添加根式 | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| 添加极限 | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| 添加左侧上下标 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| 添加公式数组 | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| 添加分隔符 | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| 分组项 | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **常见问题**

**我可以编辑已有的 PowerPoint 公式吗？**

可以。打开演示文稿，找到包含 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 的形状，调用 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，并更新该段落中的数学块。

**公式会以可编辑的 PowerPoint 数学形式保存吗？**

会。保存为 PPTX 时，Aspose.Slides 会将公式写入可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

可以。先从其 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 获取 [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)，然后调用 [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) 直接导出。完整示例请参阅 [Export Math Equations from Presentations in Python](/slides/zh/python-java/exporting-math-equations/#export-math-equations-to-latex)。