---
title: 在 Python 中为 PowerPoint 演示文稿添加数学公式
linktitle: 数学公式
type: docs
weight: 80
url: /zh/python-net/powerpoint-math-equations/
keywords:
- 数学等式
- PowerPoint 数学等式
- 数学符号
- PowerPoint 数学符号
- 数学公式
- PowerPoint 数学公式
- 数学文本
- PowerPoint 数学文本
- 将数学等式添加到 PowerPoint
- 将数学符号添加到 PowerPoint
- 将数学公式添加到 PowerPoint
- 将数学文本添加到 PowerPoint
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 PowerPoint 中使用 Aspose.Slides for Python（通过 .NET）处理数学公式。获取详细的操作指南、代码示例以及自动化创建和编辑演示文稿的技巧。"
---

## **概述**

在 PowerPoint 中，您可以编写数学公式或方程并在演示文稿中显示。提供了各种数学符号，可添加到文本或公式中。数学公式构造器用于创建诸如以下内容的复杂公式：

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

这将生成 XML 中的数学文本，PowerPoint 可显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持广泛的数学符号来创建公式。然而，在 PowerPoint 中生成复杂的数学公式通常无法得到精致、专业的效果。因此，频繁创建数学演示文稿的用户往往会转向第三方解决方案，以获得更好看的数学公式。

使用 [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/)，您可以在 Python 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑已创建的表达式。部分支持将数学结构导出为图像。

## **如何创建数学公式**

数学元素用于构建任何数学结构，无论嵌套层级如何。这些元素的线性集合形成一个数学块，由 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类表示。[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类代表一个独立的数学表达式、公式或方程。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 用于保存数学文本（区别于普通的 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 类），而 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 允许您操作一组 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 对象。这些类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建下图所示的数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要向幻灯片添加数学表达式，首先添加一个将容纳数学文本的形状：
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


创建形状后，默认已经包含一个带有数学段的段落。[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 类表示包含数学文本的段落。要访问 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 中的数学内容，请参考 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 变量：
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 类允许您读取、添加、编辑和删除数学块（[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)），这些块由一系列数学元素组合而成。例如，创建一个分数并将其放入演示文稿：
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
```


[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口的操作在每种元素类型中都有实现，包括 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 类。

下面是完整的源码示例：
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

数学表达式由一系列数学元素组成。数学块表示这样的序列，而这些元素的参数形成嵌套的树形结构。

可以用于构建数学块的元素类型很多。每种元素都可以嵌入另一个元素，形成树形结构。最简单的元素类型是不包含任何其他数学文本元素的元素。

每种数学元素都实现了 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口，使您能够对不同类型的数学元素使用统一的数学操作集合。

### **MathematicalText 类**

[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 类表示数学文本——所有数学结构的底层元素。数学文本可以表示操作数和运算符、变量或任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**

[MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) 类指定一个分数对象，由分子和分母组成，之间以分数线分隔。分数线可以是水平的也可以是对角的，取决于分数属性。该对象也用于表示堆叠函数，即将一个元素放在另一个元素之上而不使用分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**

[MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) 类指定根式函数（数学根），由基数和可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**

[MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 类指定一个带参数的函数。它包含如 [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/)（函数名）以及 [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/)（函数参数）等属性。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**

[MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 类指定一个 N 元数学对象，例如求和或积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算符的示例包括求和、并集、交集和积分。

该类不包括加法、减法等简单运算符。这些由单个文本 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**

[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 类用于创建上限或下限。它指定限对象，由基线文本以及位于其上方或下方的缩小文本组成。该元素本身不包含 “lim” 关键字，但允许您将文本放置在表达式的顶部或底部。例如，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合 [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) 和 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 元素实现的：
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

这些类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。[MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) 还可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) 类指定矩阵对象，由子元素按行列排列组成。需要注意的是，矩阵本身没有内置的分隔符。若要在括号中包围矩阵，请使用分隔符对象 [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/)。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**

[MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) 类指定垂直排列的方程或任意数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素的格式化**

- **MathBorderBox** 类：在 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 周围绘制矩形或其他边框。

示例：

![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** 类：指定数学元素的逻辑包装。包装对象可用作运算符模拟器（带或不带对齐点），可作为换行符，或用于防止行内断行。例如，`==` 运算符应使用盒子包装以防止换行。

- **MathDelimiter** 类：指定分隔符对象，由左、右字符（如括号、大括号、方括号或竖线）以及其中的一个或多个数学元素组成，可使用指定字符分隔。例如：(𝑥2); [𝑥2|𝑦2]。

示例：

![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** 类：指定重音符号，由基体和组合变音符号组成。

示例：𝑎́。

- **MathBar** 类：指定上横线或下横线，由基体参数以及上横线或下横线组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** 类：指定放置在表达式上方或下方的分组符号，通常用于突出元素之间的关系。

示例：

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**

每个数学元素以及每个通过 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 表示的数学表达式都实现了 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口。这使您能够对现有结构执行操作并形成更复杂的数学表达式。所有运算都有两组参数：可以是 [IMathElement] 或字符串。当使用字符串参数时，会隐式创建 [MathematicalText] 类的实例。以下列出 Aspose.Slides 中可用的数学运算。

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

这些方法使用指定的分子和分母创建指定类型的分数。例如：
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose 方法**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

这些方法使用指定字符（如括号或其他框定字符）将元素包围。例如：
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Function 方法**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

这些方法使用当前对象作为函数名，对参数调用函数。例如：
```py
function = math.MathematicalText("sin").function("x")
```


### **AsArgumentOfFunction 方法**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

这些方法使用当前实例作为参数，将其作为指定函数的参数。您可以：

- 使用字符串指定函数名，例如 `"cos"`；
- 选择枚举 [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) 或 [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) 中的预定义值，例如 `MathFunctionsOfOneArgument.ARC_SIN`；
- 选择 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 实例。

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

这些方法设置下标和上标。您可以在左侧或右侧同时设置两者；但单独的下标或上标仅在右侧受支持。**Superscript** 还可用于设置数字的数学指数。

示例：
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical 方法**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

这些方法根据指定参数设置给定指数的数学根。

示例：
```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit 和 SetLowerLimit 方法**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

这些方法接受上限或下限，其中 “upper” 与 “lower” 表示相对于基数的位置。

考虑以下表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

此类表达式可通过组合 [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) 和 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) 类，以及 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 接口的操作来创建，如下所示：
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

`nary` 与 `integral` 方法均创建并返回由 [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) 类型表示的 N 元运算符。`nary` 方法的枚举 [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) 指定运算符类型（如求和或并集），不包括积分。`integral` 方法则提供专用于积分的操作，使用枚举 [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) 。

示例：
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray 方法**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) 将元素放入垂直数组。如果在 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 实例上调用此操作，所有子元素将被放入返回的数组中。

示例：
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**

- [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) 方法为元素添加重音符（元素顶部的字符）。
- [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) 与 [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) 方法分别在顶部或底部添加横线。
- [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) 方法使用分组字符（如底部大括号）将元素放入组中。
- [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) 方法将元素放入边框盒。
- [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) 方法将元素放入非可视盒（逻辑分组）。

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


## **FAQ**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，您需要创建一个 [math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 对象，该对象会自动包含一个数学段落。随后，从该 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 中获取 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)，并向其添加 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 允许通过嵌套 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 来创建复杂的数学表达式。每个数学元素都提供 Join、Divide、Enclose 等操作，以将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，首先通过 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 访问已有的 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)。然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。