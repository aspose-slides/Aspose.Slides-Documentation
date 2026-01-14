---
title: 在 Python 中向 PowerPoint 演示文稿添加数学方程
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
description: "了解如何使用 Aspose.Slides for Python（通过 .NET）在 PowerPoint 中处理数学方程。获取详细的操作指南、代码示例以及自动化创建和编辑演示文稿的技巧。"
---

## **概述**

在 PowerPoint 中，您可以编写数学公式或表达式并在演示文稿中显示它们。提供了各种数学符号，可添加到文本或公式中。数学公式构造器用于创建如下复杂公式：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建数学文本，可在 PowerPoint 中如下显示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持广泛的数学符号用于创建公式。但在 PowerPoint 中生成复杂的数学公式通常无法得到精致、专业的效果。因此，经常制作数学演示文稿的用户往往会转向第三方解决方案，以获得更美观的数学公式。

使用 [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/)，您可以在 Python 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑之前创建的表达式。对将数学结构导出为图像提供了部分支持。

## **如何创建数学公式**

数学元素用于构建任何数学结构，不论嵌套层级如何。这些元素的线性集合形成一个数学块，由 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类表示。[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类代表一个独立的数学表达式、公式或方程。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 用于保存数学文本（区别于常规的 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 类），而 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 允许您操作一组 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 对象。这些类是通过 Aspose.Slides API 处理 PowerPoint 数学公式的关键。

让我们看看如何使用 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要向幻灯片添加数学表达式，首先添加一个用于容纳数学文本的形状：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


创建形状后，默认已包含一个带有数学部分的段落。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 类表示包含数学文本的部分。要访问 [MathPortion] 中的数学内容，请参阅 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 变量：

```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 类允许您读取、添加、编辑和删除数学块（[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)），这些块由组合的数学元素构成。例如，创建一个分数并将其放入演示文稿中：

```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 类的操作在每种元素类型中都有实现，包括 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类。

下面是完整的源代码示例：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **数学元素类型**

数学表达式由一系列数学元素组成。数学块表示这种序列，这些元素的参数形成嵌套的树状结构。

有许多类型的数学元素可用于构建数学块。每个元素都可以聚合到另一个元素中，形成树状结构。最简单的元素类型是不包含任何其他数学文本元素的元素。

每种数学元素类型都实现了 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 类，使您可以对不同类型的数学元素使用通用的数学操作集合。

### **MathematicalText 类**

[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 类代表数学文本——所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量或任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**

[MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) 类指定由分子和分母组成、由分数线分隔的分数对象。分数线可以是水平的或对角的，取决于分数属性。该对象也用于表示堆叠函数，即在没有分数线的情况下将一个元素置于另一个元素之上。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**

[MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) 类指定根式函数（数学根），由基值和可选的次数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**

[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 类指定一个参数函数。它包含诸如 [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/)（表示函数名称）和 [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/)（表示函数参数）的属性。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**

[MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 类指定 N 元数学对象，例如求和或积分。它由运算符、基数（或操作数）以及可选的上限和下限组成。N 元运算符的例子包括求和、并集、交集和积分。

该类不包括加法、减法等简单运算符。这些由单个文本 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**

[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 类用于创建上限或下限。它指定限对象，由基线上的文本以及紧挨其上方或下方的缩小文本组成。该元素不包括单词 'lim'，但允许您在表达式的顶部或底部放置文本。因此，表达式 通过以下方式使用 [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 和 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 元素的组合来创建：

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

这些类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) 还可用于设置数字的数学次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) 类指定矩阵对象，由排列在一个或多个行和列中的子元素组成。需要注意的是，矩阵本身没有内置的定界符。若要在矩阵两侧添加括号，请使用定界符对象 [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/)。可以使用空参数在矩阵中创建空隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**

[MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) 类指定垂直排列的方程式或任意数学对象的数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**

- [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) 类：在 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 周围绘制矩形或其他边框。

示例：

![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) 类：指定数学元素的逻辑盒装（封装）。盒装对象可以用作运算符仿真（带或不带对齐点）、充当换行点，或分组以防止内部换行。例如，应该对 “==” 运算符进行盒装以防止换行。

- [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) 类：指定定界符对象，由左右括号字符（如圆括号、花括号、方括号或竖线）以及内部一个或多个数学元素组成，可通过指定字符分隔。例如：(𝑥2)；[𝑥2|𝑦2]。

示例：

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) 类：指定重音符函数，由基底和结合的变音符号组成。

示例：𝑎́.

- [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) 类：指定横线函数，由基参数以及上横线或下横线组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) 类：指定放置在表达式上方或下方的分组符号，通常用于突出元素之间的关系。

示例：

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学操作**

每个数学元素以及每个数学表达式（通过 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)）实现了 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 类。这使您能够对现有结构执行操作并形成更复杂的数学表达式。所有操作都有两组参数：要么是 [IMathElement]，要么是字符串参数。当使用字符串参数时，会隐式从指定的字符串创建 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 类的实例。Aspose.Slides 中可用的数学操作列在下面。

### **Join 方法**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

这些方法将数学元素连接起来并形成数学块。例如：

```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Divide 方法**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

这些方法根据指定的类型创建分数，并提供分子和指定的分母。例如：

```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose 方法**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

这些方法使用指定字符（如圆括号或其他围绕字符）将元素包裹起来。例如：

```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Function 方法**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

这些方法使用当前对象作为函数名称，对参数进行函数操作。例如：

```py
function = math.MathematicalText("sin").function("x")
```


### **AsArgumentOfFunction 方法**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

这些方法使用当前实例作为参数来调用指定的函数。您可以：

- 将字符串指定为函数名称，例如 “cos”；
- 选择枚举 [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) 或 [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) 中的预定义值，例如 `MathFunctionsOfOneArgument.ARC_SIN`；
- 选择 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 的实例。

例如：

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

这些方法设置下标和上标。您可以在参数的左侧或右侧同时设置下标和上标；但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的数学次数。

示例：

```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical 方法**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

这些方法根据指定的参数指定给定次数的数学根。

示例：

```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit 和 SetLowerLimit 方法**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

这些方法接受上限或下限，其中 “upper” 和 “lower” 表示参数相对于基数的位置。

让我们考虑一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

此类表达式可以通过结合 [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) 和 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) 类，以及 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 类的操作来创建，如下所示：

```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Nary 和 Integral 方法**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

`nary` 和 `integral` 方法都创建并返回由 [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 类型表示的 N 元运算符。在 `nary` 方法中，枚举 [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) 指定运算符的类型（如求和或并集），不包括积分。 在 `integral` 方法中，使用枚举 [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) 提供针对积分的专用操作。

示例：

```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray 方法**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) 将元素放入垂直数组中。如果在 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 实例上调用此操作，则其所有子元素都将放入返回的数组中。

示例：

```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) 方法：在元素顶部设置重音符号（字符）。
- [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) 和 [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) 方法：在顶部或底部设置横线。
- [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) 方法：使用分组字符（如下弯括号等）将元素放入组中。
- [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) 方法：放入边框盒中。
- [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) 方法：放入非可视盒（逻辑分组）中。

示例：

```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **常见问题**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，您需要 [create a math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 对象，该对象自动包含一个数学部分。然后，您从 [MathPortion] 中检索 [MathParagraph]，并向其添加 [MathBlock] 对象。

**是否可以创建复杂的嵌套数学表达式？**

是的，Aspose.Slides 允许通过嵌套 [MathBlocks] 来创建复杂的数学表达式。每个数学元素都可以使用操作（Join、Divide、Enclose 等）将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，您需要通过 [MathParagraph] 访问现有的 [MathBlock]。然后，使用 Join、Divide、Enclose 等方法，您可以修改公式的各个元素。编辑完成后，保存演示文稿以应用更改。