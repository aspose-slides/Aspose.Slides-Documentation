---
title: 在 .NET 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/net/powerpoint-math-equations/
keywords:
- 数学等式
- 数学符号
- 数学公式
- 数学文本
- 添加数学等式
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 C# 示例代码。"
---

## **概述**

在 PowerPoint 中，您可以编写数学公式或等式并在演示文稿中显示。提供了各种数学符号，可添加到文本或公式中。数学公式构造器用于创建诸如：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建可在 PowerPoint 中显示的数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持广泛的数学符号用于创建公式。然而，在 PowerPoint 中生成复杂的数学公式往往无法得到精致、专业的效果。因此，经常制作数学演示文稿的用户通常会转向第三方解决方案，以获得更美观的数学公式。

使用[**Aspose.Slides API**](https://products.aspose.com/slides/net/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑已创建的表达式。对将数学结构导出为图像提供部分支持。

## **如何创建数学公式**

数学元素用于构建任何数学结构，无论嵌套层级如何。线性收集这些元素形成一个数学块，由[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)类表示。[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)类代表一个独立的数学表达式、公式或等式。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)用于保存数学文本（不同于常规的[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion)类），而[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)允许您操作一组[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)对象。这些类是通过 Aspose.Slides API 处理 PowerPoint 数学公式的关键。

让我们看看如何使用 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要向幻灯片添加数学表达式，首先添加一个将容纳数学文本的形状：
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


创建形状后，默认已经包含一个带有数学部分的段落。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)类表示包含数学文本的部分。要访问 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) 中的数学内容，请参考 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) 变量：
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)类允许您读取、添加、编辑和删除数学块（[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)），这些块由多个数学元素组合而成。例如，创建一个分数并将其放入演示文稿：
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


每个数学元素由实现[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)接口的类表示。该接口提供了大量方法，可轻松创建数学表达式，使您仅用一行代码即可构建相当复杂的公式。例如，勾股定理可以这样写：
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)接口的操作在每种元素类型中实现，包括[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)类。

下面是完整的示例代码：
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **数学元素类型**

数学表达式由一系列数学元素组成。数学块表示这样的序列，这些元素的参数形成嵌套的树状结构。

有许多种数学元素可用于构建数学块。每种元素都可以在另一元素内部聚合，形成树状结构。最简单的元素类型是不包含任何其他数学文本元素的。

每种数学元素都实现了[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)接口，使您能够对不同类型的数学元素使用统一的数学操作集。

### **MathematicalText 类**

[MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)类表示数学文本——所有数学构造的基础元素。数学文本可以表示操作数、运算符、变量或任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**

[MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction)类指定由分子和分母组成的分数对象，二者之间用分数线分隔。分数线可以是水平或对角线，取决于分数属性。该对象还用于表示堆叠函数，即在没有分数线的情况下将一个元素放在另一个元素之上。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**

[MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical)类指定根号函数（数学根），由基数和可选的指数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**

[MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)类指定带有参数的函数。它包含[Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name)属性（函数名）和[Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base)属性（函数参数）。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**

[MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator)类指定 N 元数学对象，例如求和或积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算符的例子包括求和、并集、交集和积分。

该类不包括加法、减法等简单运算符，它们由单个文本[MathicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**

[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)类用于创建上限或下限。它指定限值对象，由基线上的文本以及紧接其上方或下方的缩小文本组成。该元素本身不包括“lim”字样，而是允许您将文本放置在表达式的顶部或底部。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合[MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)和[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)元素实现的：
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

这些类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。[MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)还可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix)类指定矩阵对象，由子元素按一行或多行多列排列组成。需要注意的是，矩阵本身没有内置的分隔符。如需使用方括号将矩阵括起来，请使用分隔符对象[IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter)。可以使用空参数在矩阵中创建空格。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**

[MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray)类指定垂直排列的方程或任意数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素的格式化**

- **MathBorderBox** 类：在[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)周围绘制矩形或其他边框。

示例：

![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** 类：指定数学元素的逻辑包装。包装对象可作为运算符仿真器（有或没有对齐点），可用作换行点，或用于防止内部换行。例如，`==` 运算符应包装以防止换行。

- **MathDelimiter** 类：指定分隔符对象，由左、右字符（如圆括号、花括号、方括号或竖线）以及内部的一个或多个数学元素组成，元素之间可使用指定字符分隔。例如：(𝑥²); [𝑥²|𝑦²]。

示例：

![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** 类：指定重音符号，由基字符和组合变音符号组成。

示例：𝑎́。

- **MathBar** 类：指定上划线或下划线函数，由基参数和相应的上/下划线组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** 类：指定放置在表达式上方或下方的分组符号，通常用于强调元素之间的关系。

示例：

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**

每个数学元素以及通过[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)形成的每个数学表达式都实现了[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)接口。这样您可以对现有结构执行操作，构造更复杂的数学表达式。所有操作都有两组参数：可以是[IMathElement]或字符串。使用字符串参数时，会隐式创建[MathematicalText]类的实例。以下列出 Aspose.Slides 提供的数学操作。

### **Join 方法**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

这些方法将数学元素连接在一起，形成数学块。例如：
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Divide 方法**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

这些方法根据指定的分子和分母创建特定类型的分数。例如：
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Enclose 方法**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

这些方法使用指定字符（如圆括号或其他框定字符）将元素括起来。例如：
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Function 方法**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

这些方法使用当前对象作为函数名，将其作为参数的函数。例如：
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **AsArgumentOfFunction 方法**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

这些方法使用当前实例作为参数，调用指定函数。您可以：

- 使用字符串指定函数名，例如 `"cos"`；
- 选择枚举[MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument)或[MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments)中的预定义值，例如 `MathFunctionsOfOneArgument.ArcSin`；
- 传入[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)实例。

示例：
```cs
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

这些方法设置下标和上标。您可以在左侧或右侧同时设置两者，但单独的下标或上标仅在右侧受支持。**Superscript** 还可用于设置数字的数学指数。

示例：
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Radical 方法**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

这些方法根据指定的参数设定指定次数的数学根。

示例：
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **SetUpperLimit 与 SetLowerLimit 方法**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

这些方法设置上限或下限，其中“upper”和“lower”表示参数相对于基数的位置。

我们来看一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

此类表达式可通过组合[MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction)和[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit)类，以及[IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)接口的操作来创建，如下所示：
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Nary 与 Integral 方法**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

**Nary** 与 **Integral** 方法均创建并返回由[INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator)类型表示的 N 元运算符。**Nary** 方法中的[MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes)枚举指定运算符类型（如求和或并集），不包括积分。**Integral** 方法提供专用于积分的操作，使用[MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes)枚举。

示例：
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **ToMathArray 方法**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray)将元素放入垂直数组。如果对[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)实例调用此操作，所有子元素将被放入返回的数组中。

示例：
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- **Accent** 方法在元素顶部设置重音符号（字符）。
- **Overbar** 与 **Underbar** 方法在元素顶部或底部设置横线。
- **Group** 方法使用分组字符（如下方的大括号）将元素组合在一起。
- **ToBorderBox** 方法为元素添加边框框。
- **ToBox** 方法将元素放入非可视的逻辑盒（逻辑分组）。

示例：
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **常见问题解答**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，需创建 `MathShape` 对象，该对象默认包含一个数学部分。随后，从 `MathPortion` 中获取 `MathParagraph`，并向其添加 `MathBlock` 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 通过嵌套 MathBlocks 来创建复杂的数学表达式。每个数学元素实现 `IMathElement` 接口，您可以使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过 `MathParagraph` 访问已有的 MathBlocks。然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。