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
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式化控制以及清晰的 C# 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language (OMML)。使用 Aspose.Slides for .NET，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常从 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡，已选择公式命令](powerpoint-math-equations_1.png)

结果是在幻灯片上出现可编辑的数学文本：

![PowerPoint 幻灯片包含可编辑的数学公式](powerpoint-math-equations_2.png)

Aspose.Slides 通过三种主要对象构建该数学文本：

- 一个数学形状，通过 [AddMathShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addmathshape/) 创建，用于包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathportion/) 将数学内容存储在形状的文字框中。
- [MathParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathematicaltext/) 和来自 [IMathElement](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/) 的流式方法，以保持代码简短易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in .NET](/slides/zh/net/exporting-math-equations/)。

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![c² = a² + b² 公式](powerpoint-math-equations_3.png)

```csharp
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

{{% alert color="primary" %}}
`AddMathShape` 创建一个已经包含数学段落的形状。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 `Divide` 创建分数。您可以通过 [MathFractionTypes](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathfractiontypes/) 选择分数样式。

![展示 1 ÷ x 的倾斜数学分数](powerpoint-math-equations_4.png)

```csharp
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
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **添加根式**

使用 `Radical` 创建平方根、立方根或其他根式。当前元素成为底数，参数成为指数。

![带有 x 在根号下的 n 次根表达式](powerpoint-math-equations_5.png)

```csharp
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

使用 `AsArgumentOfFunction` 或 `Function` 添加如 `sin(x)`、`log(x)` 等函数，或自定义函数名。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathlimit/) 或使用 `SetLowerLimit`。

![x 趋向无穷大时的极限](powerpoint-math-equations_8.png)

```csharp
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

对于自定义函数名，使函数名成为当前元素：

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **添加 N 元运算符和积分**

使用 `Nary` 添加求和、并集、交集等大运算符。使用 `Integral` 添加积分。两者都可以设置上下限。

![带有上下限的求和符号](powerpoint-math-equations_7.png)

```csharp
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

N 元运算符用于可选上下限的大运算符。像 `+`、`-`、`=` 这样的小运算符通常作为 `MathematicalText` 添加并拼接到表达式中。

对于积分，使用 `Integral`：

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/mathmatrix/) 定义行和列。矩阵默认不包含括号，如需括号、方括号或大括号，请自行包裹矩阵。

![一个包含空单元格的两行矩阵](powerpoint-math-equations_10.png)

```csharp
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

![x 在上方、y 在下方的垂直数学数组](powerpoint-math-equations_11.png)

```csharp
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

当参数是当前元素且函数名称已知时，使用 `AsArgumentOfFunction`。

![余弦函数作用于 2x](powerpoint-math-equations_6.png)

```csharp
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

使用下标和上标帮助方法添加索引和幂。当索引必须显示在基数的左侧时，使用 `SetSubSuperscriptOnTheLeft`。

![左侧带下标 1 和上标 n 的大写 Y](powerpoint-math-equations_9.png)

```csharp
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

![由竖线分隔的 x、y、z 的分隔符表达式](powerpoint-math-equations_13.png)

```csharp
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

## **添加边框框**

当公式本身需要被框住时，使用 `ToBorderBox`。

![显示 a² = b² + c² 的带框公式](powerpoint-math-equations_12.png)

```csharp
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

使用 `Group` 在表达式上方或下方放置分组字符。添加限制以为分组项标记标签。

![带有下方标签“任意文本”的 x + y 分组表达式](powerpoint-math-equations_15.png)

```csharp
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

仅在有助于澄清公式时使用格式化帮助方法。例如，`Overbar` 在数学元素上方添加横线。

![带有上划线的 ABC 表达式](powerpoint-math-equations_14.png)

```csharp
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
| 组合元素 | [IMathElement.Join](https://reference.aspose.com/slides/zh/net/aspose.slides.mathtext/imathelement/join/) |
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

可以。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，然后更新该段落中的数学块。

**公式会保存为可编辑的 PowerPoint 数学吗？**

会。保存为 PPTX 时，Aspose.Slides 将公式写入可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

Aspose.Slides 将数学公式导出为 MathML。如果需要 LaTeX，请先导出为 MathML，然后使用支持目标 LaTeX 方言的工具将 MathML 转换为 LaTeX。