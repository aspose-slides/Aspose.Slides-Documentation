---
title: 在 Python 中向 PowerPoint 演示文稿添加数学公式
linktitle: 数学公式
type: docs
weight: 80
url: /zh/python-net/powerpoint-math-equations/
keywords:
- 数学方程
- PowerPoint 数学方程
- 数学符号
- PowerPoint 数学符号
- 数学公式
- PowerPoint 数学公式
- 数学文本
- PowerPoint 数学文本
- 向 PowerPoint 添加数学方程
- 向 PowerPoint 添加数学符号
- 向 PowerPoint 添加数学公式
- 向 PowerPoint 添加数学文本
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用适用于 .NET 的 Aspose.Slides for Python 在 PowerPoint 中处理数学方程。获取详细说明、代码示例和技巧，以自动化创建和编辑演示文稿。"
---

## **概述**
在 PowerPoint 中，可以编写数学公式并在演示文稿中显示。为此，PowerPoint 中有多种数学符号，可以添加到文本或公式中。为此，PowerPoint 中使用数学公式构造函数，帮助创建复杂的公式，如：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N-元运算
- 矩阵
- 大型运算符
- 正弦和余弦函数

要在 PowerPoint 中添加数学公式，使用 *插入 -> 公式* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将创建一个可以在 PowerPoint 中显示的 XML 数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建数学公式。然而，在 PowerPoint 中创建复杂的数学公式通常不会产生好的和专业的效果。需要频繁创建数学演示文稿的用户，转向使用第三方解决方案来创建美观的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/)，您可以在 Python 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑先前创建的表达式。将数学结构导出为图像也部分支持。

## **如何创建数学公式**
数学元素用于构建任何具有任何嵌套层次的数学结构。数学元素的线性集合形成一个数学块，由 [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类表示。 [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类本质上是一个独立的数学表达式、公式或方程。 [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 是一个数学部分，用于保存数学文本（不要与 [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 混淆）。 [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

让我们看看如何通过 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将包含数学文本的形状：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

创建后，形状将默认包含一个带有数学部分的段落。 [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 类是一个包含内部数学文本的部分。要访问 [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 中的数学内容，请参考 [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 变量：

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

[**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 类允许读取、添加、编辑和删除数学块（[**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)），这些块由数学元素组合而成。例如，创建一个分数并将其放置在演示文稿中：

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

每个数学元素由一些实现 [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口的类表示。此接口提供了许多方法以便于创建数学表达式。您可以用一行代码创建相当复杂的数学表达式。例如，毕达哥拉斯定理可以这样表示：

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

[**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口的操作在任何类型的元素中实现，包括 [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)。

完整的源代码示例：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **数学元素类型**
数学表达式由数学元素的序列组成。数学元素的序列由数学块表示，数学元素的参数形成树状嵌套。

有很多数学元素类型可以用来构建数学块。每个这些元素都可以包含（聚合）在另一个元素中。也就是说，元素实际上是其他元素的容器，形成树状结构。最简单的元素类型是，不包含其他数学文本元素。

每种数学元素类型都实现 [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口，允许对不同类型的数学元素使用通用的数学操作集。
### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 类表示一个数学文本 - 所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量以及其他任何线性文本。

示例：𝑎=𝑏+𝑐
### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) 类指定分数对象，由分子和分母通过分数线分隔。分数线可以是水平或对角线，具体取决于分数属性。分数对象也用于表示堆叠函数，它将一个元素放在另一个元素上方，没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) 类指定根号函数（数学根），由一个底数和一个可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 类指定一个参数的函数。包含属性：[Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - 函数名和 [Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 类指定一个 N-元数学对象，如总和和积分。它由一个运算符、一个基数（或操作数）和可选的上限和下限组成。N-元运算符的例子有总和、并集、交集和积分。

此类不包括简单运算符，如加法、减法等。它们由一个单独的文本元素表示 - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 类创建上限或下限。它指定限值对象，由基线上的文本和紧接其上方或下方的小号文本构成。此元素不包括单词“lim”，但允许您将文本放置在表达式的顶部或底部。所以，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过结合 [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 和 [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 元素以这种方式创建的：

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

以下类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单个下标或上标仅在右侧支持。[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) 还可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) 类指定矩阵对象，由在一行或多行和列中排列的子元素组成。重要的是要注意，矩阵没有内置分隔符。要将矩阵放入括号中，您应该使用分隔符对象 - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/)。可以使用空参数在矩阵中创建间隔。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) 类指定一组数学对象或方程式的垂直数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) 类：在 [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 周围绘制一个矩形或其他边框。

示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) 类：指定数学元素的逻辑框（打包）。例如，框装的对象可以用作运算符仿真器，有或没有对齐点，也可以作为行断点，或分组以不允许行断裂。例如，“==” 运算符应该被框装以防止行断裂。
- [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) 类：指定分隔符对象，由打开和关闭字符（如括号、花括号、方括号和竖线）及一个或多个分隔开来的数学元素组成。示例： (𝑥2); [𝑥2|𝑦2]。

示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) 类：指定一个基数和一个组合的变音符号的重音功能。

示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) 类：指定一个由基数参数和一个上划线或下划线组成的条形功能。

示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) 类：指定一个表达式上方或下方的分组符号，通常用于突出显示元素之间的关系。

示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)）实现 [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口。它允许您在现有结构上使用操作并形成更复杂的数学表达式。所有操作都有两个参数集：[`IMathElement`](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 或字符串作为参数。使用字符串参数时，将隐式创建 [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 类的实例。Aspose.Slides 中提供的数学运算列在下面。
### **Join 方法**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

连接数学元素并形成数学块。例如：

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Divide 方法**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

创建指定类型的分数，使用此分子和指定的分母。例如：

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Enclose 方法**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

在指定的字符中封闭元素，如括号或其他字符作为框架。

```py
# 在括号中封闭数学元素
MathDelimiter enclose()

# 在指定的字符中封闭此元素，例如括号或其他字符作为框架
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

例如：

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Function 方法**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

使用当前对象作为函数名称获取一个参数的函数。

例如：

```py
func = math.MathematicalText("sin").function("x")
```
### **AsArgumentOfFunction 方法**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

使用当前实例作为参数获取指定的函数。您可以：

- 指定一个字符串作为函数名称，例如“cos”。
- 选择枚举 [_**MathFunctionsOfOneArgument** ](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/)或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) 的一个预定义值，例如 **MathFunctionsOfOneArgument.ArcSin.**
- 选择 [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 的实例。

例如：

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft 方法**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

设置下标和上标。您可以在参数的左侧或右侧同时设置下标和上标，但单个下标或上标仅在右侧支持。**上标** 还可用于设置数字的数学指数。

示例：

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Radical 方法**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

指定给定参数的特定指数的数学根。

示例：

```py
    radical = math.MathematicalText("x").radical("3")
```
### **SetUpperLimit 和 SetLowerLimit 方法**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

获取上限或下限。这里，上限和下限仅表示相对于基数的位置。

让我们考虑一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

这样的表达式可以通过结合类 [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) 和 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) 以及 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 的操作创建，如下所示：

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Nary 和 Integral 方法**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

**Nary** 和 **Integral** 方法创建并返回由 [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/) 类型表示的 N-元运算符。在 Nary 方法中，[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) 枚举指定运算符的类型：总和、并集等，但不包括积分。在积分方法中，有专门的积分运算以及 [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) 的积分类型枚举。

示例：

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **ToMathArray 方法**
[**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 将元素放置在一个垂直数组中。如果此操作针对 **MathBlock** 实例调用，则所有子元素将放置在返回的数组中。

示例：

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **格式化操作：Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 方法设置重音符号（在元素顶部的字符）。
- [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 和 [**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 方法在顶部或底部设置一条线。
- [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)方法使用分组字符（如底部花括号或其他）放置在一个组中。
- [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 方法放置在边框框中。
- [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 方法放置在一个非视觉的框（逻辑分组）中。

示例：

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```