---
title: PowerPoint 数学方程
type: docs
weight: 80
url: /net/powerpoint-math-equations/
keywords: " PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 数学方程、数学符号、公式和 C# 或 .NET 中的数学文本"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中表示了各种数学符号，可以将其添加到文本或方程中。为此，PowerPoint 中使用数学方程构造函数，帮助创建复杂的公式，例如：

- 数学分数
- 数学平方根
- 数学函数
- 极限和对数函数
- N-元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，使用 *插入 -> 方程* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将创建一个可以在 PowerPoint 中显示的 XML 数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持许多数学符号来创建数学方程。然而，在 PowerPoint 中创建复杂的数学方程往往没有带来良好和专业的效果。需要频繁创建数学演示文稿的用户会诉诸第三方解决方案来创建好看的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/net/)，您可以在 PowerPoint 演示文稿中以编程方式处理数学方程。创建新的数学表达式或编辑之前创建的表达式。数学结构导出为图像也部分支持。

## **如何创建数学方程**
数学元素用于构建任何嵌套级别的数学结构。数学元素的线性集合形成由 [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) 类表示的数学块。 [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) 类本质上是一个独立的数学表达式、公式或方程。 [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) 是一个数学部分，用于保存数学文本（与 [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion) 不要混淆）。 [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) 允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学方程的关键。

让我们看看如何通过 Aspose.Slides API 创建以下数学方程：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将包含数学文本的形状：

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

```

创建后，形状将默认包含一个带有数学部分的段落。[**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) 类是包含数学文本的部分。要访问 [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) 内的数学内容，请引用 [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) 变量：

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

```

[**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) 类允许读取、添加、编辑和删除由数学元素组合而成的数学块（[**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)）。例如，创建一个分数并将其放置在演示文稿中：

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

```

每个数学元素由实现 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) 接口的某个类表示。此接口提供了许多方法，以便轻松创建数学表达式。您可以用一行代码创建一个相当复杂的数学表达式。例如，勾股定理看起来像这样：

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

```

接口 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) 的操作在任何类型的元素中实现，包括 [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)。

完整示例代码：

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

   var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

   var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));

   var mathBlock = new MathematicalText("c")

        .SetSuperscript("2")

        .Join("=")

        .Join(new MathematicalText("a").SetSuperscript("2"))

        .Join("+")

        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    pres.Save("math.pptx", SaveFormat.Pptx);

}

```

## **数学元素类型**
数学表达式由数学元素的序列构成。数学元素的序列由数学块表示，数学元素的参数形成树状嵌套。

有许多数学元素类型可以用于构造数学块。每个元素可以包含（聚合）在另一个元素中。也就是说，元素实际上是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种类型的数学元素都实现了 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) 接口，允许在不同类型的数学元素上使用通用的数学操作。
### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) 类表示数学文本 - 所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量以及任何其他线性文本。

示例： 𝑎=𝑏+𝑐
### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) 类指定由分子和通过分数线分开的分母组成的分数对象。分数线可以是水平的或对角线的，这取决于分数的属性。分数对象还用于表示堆叠函数，该函数将一个元素放在另一个元素之上，而没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) 类指定包含基数和可选程度的根号函数（数学根）。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) 类指定一个参数的函数。包含属性：[Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - 函数名称、[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) 类指定一个 N-元数学对象，例如求和和积分。它由一个运算符、一个基数（或操作数）以及可选的上限和下限组成。 N-元运算符的示例包括求和、并、交、积分。

该类不包括简单运算符，如加法、减法等。它们由单个文本元素 - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) 类创建上限或下限。它指定了限对象，由基线上的文本和紧接其上下方的缩小文本组成。此元素不包括“lim”一词，但允许您将文本放在表达式的顶部或底部。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合 [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) 和 [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) 元素生成的：

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

```

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

以下类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单个下标或上标仅支持在右侧。 [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) 还可用于设置数字的数学级别。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) 类指定矩阵对象，由一个或多个行和列中排列的子元素组成。值得注意的是，矩阵没有内置的分隔符。要将矩阵放置在括号内，应使用分隔符对象 - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter)。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) 类指定一个垂直的方程组或任何数学对象的数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) 类：在 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) 周围绘制一个矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) 类：指定数学元素的逻辑框（包装）。例如，一个盒装对象可以作为操作者模拟器，带有或不带有对齐点，或者作为行断点分组，以不允许行内换行。在这种情况下，“==”运算符应该被盒装以防止换行。
- [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) 类：指定分隔符对象，由开闭字符（如括号、花括号、方括号和竖线）和一个或多个数学元素组成，中间用指定字符分隔。例如： (𝑥2); [𝑥2|𝑦2]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) 类：指定重音功能，由一个基数和一个组合的变音符号组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) 类：指定条形函数，由一个基数参数和一个上标或下标组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) 类：在表达式的上方或下方指定分组符号，通常用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)）实现了 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) 接口。它允许您对现有结构执行运算并形成更复杂的数学表达式。所有操作都有两组参数：要么是 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)，要么是字符串作为参数。当使用字符串参数时， [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) 类的实例会隐式从指定的字符串中创建。Aspose.Slides 中可用的数学操作列出如下。
### **Join 方法**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

将数学元素连接并形成数学块。例如：

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

```
### **Divide 方法**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

用此分子和指定的分母创建指定类型的分数。例如：

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

```
### **Enclose 方法**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

将元素放置在指定字符中，如括号或其他字符作为框架。

``` csharp

 /// <summary>

/// 将数学元素放入括号中

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// 将该元素放入指定字符中，如括号或其他字符作为框架

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

```

例如：

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

```
### **Function 方法**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

使用当前对象作为函数名获取一个参数的函数。

``` csharp

 /// <summary>

/// 使用此实例作为函数名获取一个参数的函数

/// </summary>

/// <param name="functionArgument">一个函数的参数</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

```

例如：

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

```
### **AsArgumentOfFunction 方法**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/methods/3)

使用当前实例作为参数获取指定函数。您可以：

- 指定一个字符串作为函数名称，例如“cos”。
- 选择枚举 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) 或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments) 的预定义值，例如 **MathFunctionsOfOneArgument.ArcSin.**
- 选择 [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) 的实例。

例如：

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);

var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");

var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")

```
### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

设置下标和上标。您可以在参数的左侧或右侧同时设置下标和上标，但单个下标或上标仅支持在右侧。**上标** 也可用于设置数字的数学级别。

示例：

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

```
### **Radical 方法**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

指定给定参数的指定程度的数学根。

示例：

``` csharp

 var radical = new MathematicalText("x").Radical("3");

```
### **SetUpperLimit 和 SetLowerLimit 方法**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

获取上限或下限。在这里，上限和下限仅指示参数相对于基数的位置。

让我们考虑一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

这种表达式可以通过将 [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) 和 [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) 类组合以及 [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) 的操作生成，如下所示：

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

```
### **Nary 和 Integral 方法**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

**Nary** 和 **Integral** 方法都创建并返回由 [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator) 类型表示的 N-元运算符。在 Nary 方法中，枚举 [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) 指定运算符的类型：求和、并等，不包括积分。在 Integral 方法中，有带有积分类型枚举 [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes) 的专门操作积分。

示例：

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

```
### **ToMathArray 方法**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) 将元素放入垂直数组中。如果对此 **MathBlock** 实例调用此操作，则所有子元素将放置在返回的数组中。

示例：

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

```
### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) 方法设置重音标记（元素顶部的字符）。
- [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) 和 [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) 方法分别在顶部或底部设置条形。
- [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) 方法使用分组字符（如底部花括号或其他）放入组中。
- [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) 方法放入边框框中。
- [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) 方法放入不可视盒中（逻辑分组）。

示例：

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

```