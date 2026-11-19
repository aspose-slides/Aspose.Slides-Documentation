---
title: 用 Python 向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/python-java/powerpoint-math-equations/
keywords:
- 数学公式
- 数学符号
- 数学表达式
- 数学文本
- 添加数学公式
- 添加数学符号
- 添加数学表达式
- 添加数学文本
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 Python 示例代码。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for Python via Java，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **Insert > Equation** 添加公式：

![PowerPoint 插入选项卡，已选择“公式”命令](powerpoint-math-equations_1.png)

结果是幻灯片上的可编辑数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 一个数学形状，由 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 创建，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 在形状文本框内部存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 和来自 [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) 的流式方法，以保持代码简短且可读。

有关 MathML 导出场景，请参阅 [从演示文稿导出数学公式（Python）](/slides/zh/python-java/exporting-math-equations/)。

## **创建公式**

此示例使用 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 创建数学形状并添加勾股定理：

![公式 c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 创建一个已经包含数学段落的形状。访问第一个 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)，调用 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，并向其添加数学块或数学元素。
{{% /alert %}}

### **合并数学块**

当 equation parts are built independently as [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) 对象时，使用 [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) 将它们合并。示例在左块构建 `c² =`，在右块构建 `a² + b²`。[setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) 为这三个幂创建可编辑的数学上标。

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

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) 返回 `left_block` 本身，现在按顺序包含两个部分，并使 `right_block` 为空。仅将合并后的块添加一次到 [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)。重新打开 `equation.pptx` 后，段落包含一个表示 `c² = a² + b²` 的块，所有三个幂均以数学上标形式保留。

如果调用 [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) 形式 `left_block.add(right_block)`，则尝试将一个块直接嵌套在另一个块内部，会抛出 `InvalidOperationException`。

## **添加分数**

使用 [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) 选择分数样式。

![一个倾斜的数学分数，显示 1 除以 x](powerpoint-math-equations_4.png)

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

对于堆叠式分数，使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

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

![一个 n 次根式表达式，x 位于根号下](powerpoint-math-equations_5.png)

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

### **显示或隐藏平方根的指数**

平方根可以显示显式的 2，或使用常规的 √x 符号。[MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) 的 [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) 方法控制显示哪种形式。这两种形式在可编辑公式中均保留指数 2 和被开方数 x。

![相同的平方根，左侧显示指数，右侧隐藏指数](square-root-degree.png)

示例将相同的平方根保存两次。在 `visible-degree.pptx` 中，2 可见；在 `hidden-degree.pptx` 中，2 被隐藏。

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

## **添加函数和极限**

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) 来处理诸如 `sin(x)`、`log(x)` 或自定义函数名的函数。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) ，或使用 [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)。

![x 趋于无穷时的极限](powerpoint-math-equations_8.png)

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

对于自定义函数名，将函数名设为当前元素，然后使用其参数调用 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **添加 N 元运算符和积分**

使用 [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) 进行求和、并集、交集及其他大型运算符。使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) 进行积分。这两种方法均可设置上下限。

![带上下限的求和](powerpoint-math-equations_7.png)

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

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

N 元运算符用于带可选上下限的大型运算符。诸如 `+`、`-`、`=` 等简单运算符通常作为 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 添加并拼接到表达式中。

对于积分，使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

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

使用 [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) 来定义行和列。矩阵默认不包含括号，因此在需要圆括号、方括号或大括号时请自行包裹矩阵。

![一个两行的数学矩阵，其中一个单元格为空](powerpoint-math-equations_10.png)

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

### **编辑已有矩阵**

假设线性代数课程以 `matrix.pptx` 中的系数矩阵开始，该矩阵由前面的示例保存。对于后续练习，保留第一条公式，用两条新公式替换第二条，并修改变量集合。通过 [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) 打开现有矩阵，以保留仍适用的系数。

![原始两行系数矩阵，第一行包含 1、x 和空单元，第二行包含 x、2 和 y](matrix-before-edit.png)

行和列索引从零开始，并指向当时矩阵的状态。在索引 1 之前插入行会将原第二行移至索引 2。随后在索引 2 之后插入会追加一行。删除第 2 行会移除原第二条公式，并将追加的行上移一位。列的移动方式相同。

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

    # 新单元格最初为空。首先设置非零系数。
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

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) 将第一列左对齐。[setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) 将其余三列从索引 1 开始右对齐。在 `updated-matrix.pptx` 中，矩阵包含三个公式和四个变量。原第一行的系数 `1` 和 `x` 现在出现在第一列和第三列。

![更新后的三行矩阵，显示行 1,0,x,0；12,1,0,0；以及 0,0,10,1](matrix-after-edit.png)

## **添加方程数组**

当需要对齐的公式或垂直堆叠的表达式时，请使用 [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray)。

![垂直数学数组，x 位于 y 之上](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) 控制数组相对于其旁边数学元素的垂直对齐方式。下面的示例比较了与第一行、数组中心和最后一行的对齐情况。

下面的示例创建了三个相同的数组，每个数组有三行，并且相邻元素为 `A=` 和 `=B`。所有数学文本使用 24 磅的 Cambria Math。唯一变化的是数组的对齐方式。

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

下面的对比显示了在 PowerPoint 中保存的演示文稿。请注意每个数组旁边的 `A=` 和 `=B` 的位置。

![PowerPoint 中的方程数组，分别使用顶部、居中和底部对齐，且相邻元素相同](equation-array-alignment.png)

### **配置行间距**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) 为数组内的行选择间距规则。[setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) 为显式间距规则提供数值，对预设规则无效。

对于精确间距，数值以磅为单位。对于比例间距，数值以半行为单位：示例中的值 `3` 表示 1.5 行。指定显式数值时需要同时设置两个属性；仅更改数值而不设置规则不会生效。

下面的示例保存了五个演示文稿，使用相同的公式、对齐方式和字体设置。前三个使用预设，后两个显示显式数值。

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

数组行间距与段落间距分离。[setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) 为包含的段落四周添加空间，而不是数组行之间的空间。同样，[MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) 水平定位整个数学段落；它不替代数组的垂直对齐设置。

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

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

使用下标和上标辅助方法来处理索引和幂。当索引必须显示在基数的左侧时，使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![大写字母 Y，左侧下标 1 和上标 n](powerpoint-math-equations_9.png)

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

## **添加定界符**

使用 [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) 将表达式置于定界符内。对于包含多个元素的定界符表达式，还可以设置分隔字符。

![一个定界符表达式，包含 x、y、z，之间用竖线分隔](powerpoint-math-equations_13.png)

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

### **定界符的大小和对齐**

向 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) 传入 `True`，使括号随高操作数而增长；传入 `False` 则保持正常大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) 并选择两种 [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) 值之一。`Centered` 将括号居中于数学轴（穿过等号中线），`Match` 使其与包围的内容对齐。这两种设置仅影响定界符，内部表达式保持不变。

示例将分数放在 `x` 的指数中，使表达式在基线上方的延伸大于下方。四个公式均使用相同的括号和字体设置。

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

在 PowerPoint 中，对比各行即可看到增长效果。顶部行的括号会随指数扩大，两个形状看起来相同。底部行关闭了增长。左侧较小的括号（`Centered`）与等号对齐，而右侧（`Match`）则在表达式上方更高。

![PowerPoint 中的四个公式，上方启用定界符增长，下方关闭，左侧使用 Centered，右侧使用 Match](delimiter-sizing.png)

## **添加边框框**

对分数调用 [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) 以为整个表达式加上边框。返回的 [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) 默认显示四条边。使用 [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) 和 [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) 可去除单独的边。

示例在一张幻灯片上放置了相同分数的六个副本。为了显示抵消，隐藏四条边，并对 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 传入 `True` 以得到向上对角线 (↗)，或对 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) 传入 `True` 以得到向下对角线 (↘)。也可以使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 并结合任意可见的边。

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

![PowerPoint 中的六个可编辑分数。上排：完整边框、底部和左侧边、向上对角线。下排：向下对角线、水平划线、垂直划线并带完整边框。](border-box-fractions.png)

在此分数上，水平划线覆盖了分数线。垂直划线穿过分子和分母，而周围的边框仍然可见。这些线装饰了整个表达式。普通文本的删除线只作用于文本运行中的字符。重新在 PowerPoint 中打开演示文稿后，仍可以独立编辑分子和分母。

## **使用幻影元素控制可见性和布局**

将表达式包裹在 [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) 中，以独立控制其可见性以及对公式贡献的空间。[MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) 方法可控制以下内容：

| 方法 | 效果 |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | `False` 会隐藏表达式。其尺寸仍会影响布局，除非以下相应方法接收 `True`。 |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | 将表达式的水平宽度视为零，使相邻元素可以更靠近。 |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | 将其上升量（基线之上高度）视为零。这可以减少相邻元素上方预留的空间。 |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | 将其下降量（基线之下深度）视为零。这可以使分数线或表达式下方的其他内容更靠近相邻元素。 |

基线是普通数学字母所在的参考线。隐藏内容不会移除其尺寸，将维度视为零也不会删除表达式。底层表达式仍可通过 [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) 获取。对 [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) 传入 `True` 可再次显示，该维度设置保持不变。

下面的示例创建了五个并排的变体：一个可见分数、一个保留空间的隐藏分数，以及三个将某一维度设为零的隐藏分数。每个变体使用相同的周围表达式和 24 磅的 Cambria Math。所有公式形状的顶部位置相同，由灰色参考线标记。将幻影放置在外部分数的分子中，可更容易观察到垂直布局的变化。

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

![PowerPoint 中的五个公式，比较可见分数、保留空间的隐藏分数以及启用 ZeroWidth、ZeroAsc 或 ZeroDesc 的隐藏分数](math-phantom.png)

## **对项分组**

使用 [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) 在表达式上方或下方放置分组字符。添加上下限以为分组项加标签。

![表达式 x + y 被分组，下方带标签任意文本](powerpoint-math-equations_15.png)

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

仅在有助于澄清公式时使用格式化辅助方法。例如，[overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) 在数学元素上方添加一条横线。

![数学表达式 ABC 加上横线](powerpoint-math-equations_14.png)

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

### **格式化现有公式中的文本**

要在整个现有公式中格式化文本，需要遍历每个数学块的元素树。[MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) 仅返回直接子元素，因此需递归调用以访问分数、下/上标、根式等嵌套结构中的文本。既要检查当前元素，也要检查其子元素，以在起始元素为 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 时将其包含在内。

此示例假设 `input.pptx` 包含类似 `z = xᵢ / ∛y` 的公式，其中分子含有下标，分母含有根式。仅处理块的顶层元素会遗漏分数内部的文本。示例在幻灯片文本框中查找数学部分，通过 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) 访问其块，并使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 将每个文本元素的 [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) 字体大小设置为 28 磅。

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

保存的演示文稿在每个处理过的公式的每个层级上都包含更新后的文本格式，同时保持其文本内容和数学结构不变。

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
| 添加左侧脚本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| 添加方程数组 | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| 添加定界符 | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| 分组项 | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **常见问题**

**我可以编辑现有的 PowerPoint 公式吗？**

是的。打开演示文稿，找到包含 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 的形状，调用 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，并更新该段落中的数学块。

**公式是否以可编辑的 PowerPoint 数学形式保存？**

是的。保存为 PPTX 时，Aspose.Slides 会将公式写入为可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

是的。通过其 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 获取公式的 [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)，然后调用 [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) 直接导出。完整示例请参阅 [从演示文稿导出数学公式（Python）](/slides/zh/python-java/exporting-math-equations/#export-math-equations-to-latex)。