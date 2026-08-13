---
title: 在 .NET 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 C# 示例代码。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for .NET，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡，已选择“公式”命令](powerpoint-math-equations_1.png)

结果是在幻灯片上可编辑的数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 使用 [AddMathShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addmathshape/) 创建的数学形状，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 在形状的文本框内存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathematicaltext/) 和来自 [IMathElement](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/) 的流式方法，以保持代码简短易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in .NET](/slides/zh/net/exporting-math-equations/)。

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![c 的平方等于 a 的平方加 b 的平方 公式](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" %}}
`AddMathShape` 创建一个已包含数学段落的形状。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其中添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 `Divide` 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathfractiontypes/) 选择分数样式。

![显示 1 除以 x 的倾斜分数](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

对于堆叠式分数，使用 `MathFractionTypes.Bar`：

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **添加根式**

使用 `Radical` 创建平方根、立方根或其他根式。当前元素成为底数，参数成为根指数。

![一个 n 次根式，x 位于根号下](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **添加函数和极限**

对 `sin(x)`、`log(x)` 等函数或自定义函数名使用 `AsArgumentOfFunction` 或 `Function`。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathlimit/) 中或使用 `SetLowerLimit`。

![当 x 趋于无穷大时的极限](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

对于自定义函数名，将函数名设为当前元素：

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **添加 N 元运算符和积分**

使用 `Nary` 进行求和、并集、交集以及其他大运算符。使用 `Integral` 进行积分。这两种方法都允许设置下限和上限。

![带有上下限的求和符号](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N 元运算符用于可选上下限的大运算符。像 `+`、`-`、`=` 这样的简单运算符通常使用 `MathematicalText` 添加并拼接到表达式中。

对于积分，使用 `Integral`：

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathmatrix/) 定义行和列。矩阵默认不包含括号，因此在需要圆括号、方括号或大括号时请自行包裹矩阵。

![一个两行的数学矩阵，其中有一个空单元格](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **添加公式数组**

当需要对齐的公式或垂直堆叠的表达式时，使用 `ToMathArray`。

![一个垂直的数学数组，x 位于 y 上方](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 `AsArgumentOfFunction`。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **添加下标和上标**

使用下标和上标帮助方法来添加索引和幂。当索引需要出现在基数的左侧时，使用 `SetSubSuperscriptOnTheLeft`。

![大写 Y，左侧下标 1，上标 n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **添加分隔符**

使用 `Enclose` 将表达式放入分隔符中。对于包含多个元素的分隔符表达式，还可以设置分隔字符。

![一个分隔符表达式，包含 x、y、z，之间用竖线分隔](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **添加带边框的框**

当公式本身需要加框时，使用 `ToBorderBox`。

![一个带框的公式，显示 a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **分组项**

使用 `Group` 在表达式上方或下方放置分组字符。添加上下限为分组项标记标签。

![表达式 x + y 被分组，下面带有标签任意文本](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **格式化数学元素**

仅在有助于阐明公式时使用格式化帮助方法。例如，`Overbar` 在数学元素上方加一条横线。

![带有上划线的数学表达式 ABC](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathematicaltext/) |
| 合并元素 | [IMathElement.Join](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/join/) |
| 创建分数 | [IMathElement.Divide](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/divide/) |
| 添加上标或下标 | [SetSuperscript](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 添加函数 | [Function](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 添加根式 | [IMathElement.Radical](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/radical/) |
| 添加极限 | [SetLowerLimit](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 添加左侧脚本 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 添加求和和积分 | [Nary](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/integral/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathmatrix/) |
| 添加公式数组 | [ToMathArray](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 添加分隔符 | [Enclose](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/enclose/) |
| 添加横线和边框 | [Overbar](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分组项 | [Group](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/group/) |

## **常见问题**

**我可以编辑已有的 PowerPoint 公式吗？**

是的。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，并在该段落中更新数学块。

**公式是否保存为可编辑的 PowerPoint 数学？**

是的。保存为 PPTX 时，Aspose.Slides 会将公式写入为可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

是的。通过其 [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 获取公式的 [IMathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/)，然后调用 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathparagraph/tolatex/) 直接导出。完整示例请参阅 [Export Math Equations from Presentations in .NET](/slides/zh/net/exporting-math-equations/#export-math-equations-to-latex)。