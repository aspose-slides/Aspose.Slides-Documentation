---
title: 在 С++ 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/cpp/powerpoint-math-equations/
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
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 С++ 代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学公式并在演示文稿中显示。为此，PowerPoint 中提供了各种数学符号，可添加到文本或公式中。PowerPoint 使用数学公式构建器来创建诸如以下的复杂公式：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- N 进制运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建可在 PowerPoint 中显示的数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建公式。然而，在 PowerPoint 中创建复杂的公式往往难以获得专业的外观。需要频繁制作数学演示文稿的用户通常会求助于第三方解决方案，以获得美观的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)，您可以在 C++ 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有表达式。对数学结构导出为图像也得到部分支持。


## **如何创建数学公式**
数学元素用于构建任意层次嵌套的数学结构。线性集合的数学元素形成由[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)类表示的数学块。**MathBlock** 类本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) 用于保存数学文本（不要与 [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) 混淆）。[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) 允许操作一组数学块。上述类是通过 Aspose.Slides API 在 PowerPoint 中处理数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个容纳数学文本的形状：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

创建后，形状默认已包含一个带数学文本的段落。**MathPortion** 类表示包含数学文本的段落。要访问 **MathPortion** 中的数学内容，请使用 **MathParagraph** 变量：

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

**MathParagraph** 类允许读取、添加、编辑和删除由数学元素组合而成的 **MathBlock**（数学块）。例如，创建一个分数并将其放入演示文稿：

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

每个数学元素都由实现 **IMathElement** 接口的类表示。该接口提供大量方法，可轻松创建数学表达式。只需一行代码即可创建相当复杂的表达式。例如，勾股定理可以这样写：

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

**IMathElement** 接口的操作在所有元素类型中实现，包括 **MathBlock**。

完整代码示例：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 


## **数学元素类型**
数学表达式由一系列数学元素组成。元素序列由数学块表示，元素的参数形成树状嵌套。

可以使用多种数学元素类型构建数学块。每种元素都可以包含在另一个元素中，即元素本身是容器。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现 **IMathElement** 接口，从而可以对不同类型的元素使用统一的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) 类表示数学文本，是所有数学构造的基础元素。数学文本可以是操作数、运算符、变量或任何线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) 类表示分数对象，由分子和分母组成，之间由分数线分隔。分数线可以是水平或对角线，取决于属性。该类也用于表示堆叠函数，即将一个元素放在另一个元素上方且无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) 类表示根号函数，由基数和可选的次数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) 类表示带参数的函数。包含以下方法：`get_Name()` — 函数名称，`get_Base()` — 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) 类表示 N 元数学对象，例如求和符号和积分符号。它由运算符、基数（或操作数）以及可选的上下限组成。常见的 N 元运算符包括求和、并集、交集、积分。

该类不包括加、减等简单运算符，这些由单个 **MathematicalText** 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) 类用于创建上下限。它由基线文本以及位于其上方或下方的缩小文本组成。该元素本身不包含“lim”字样，但可以在表达式的顶部或底部放置文本。例如，下式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

可通过 **MathFunction** 与 **MathLimit** 组合实现：

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

上述类用于指定下标或上标。可以同时在左侧或右侧设置下标和上标，但单独的下标或上标仅在右侧受支持。**MathSubscriptElement** 还能用于设置数字的次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) 类表示矩阵对象，由子元素按行列布局组成。矩阵本身不带内置定界符；如需加括号，应使用 **IMathDelimiter**。可以使用空参创建矩阵中的空位。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) 类表示垂直排列的方程或其他数学对象。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- **MathBorderBox** 类：在 **IMathElement** 周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** 类：对数学元素进行逻辑盒装，例如防止换行或作为运算符仿真。

- **MathDelimiter** 类：定义定界符对象，由左/右字符及内部的一个或多个数学元素组成。示例： (𝑥²); [𝑥²|𝑦²]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** 类：定义重音符号，由基字符和组合变音符组成。

  示例：𝑎́.

- **MathBar** 类：定义上横线或下横线，包含基字符和相应的横线。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** 类：在表达式上方或下方放置分组符号，以强调元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学运算**
每个数学元素和数学表达式（通过 **MathBlock**）实现 **IMathElement** 接口。该接口允许在现有结构上执行操作，形成更复杂的表达式。所有操作支持两套参数：**IMathElement** 或字符串。使用字符串时会隐式创建 **MathematicalText** 实例。以下列出 Aspose.Slides 提供的数学操作。

### **Join 方法**
- `Join(String)`
- `Join(IMathElement)`

将两个数学元素连接，形成数学块。例如：

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
auto element2 = System::MakeObject<MathematicalText>(u"y");
auto block = element1->Join(element2);
``` 

### **Divide 方法**
- `Divide(String)`
- `Divide(IMathElement)`
- `Divide(String, MathFractionTypes)`
- `Divide(IMathElement, MathFractionTypes)`

创建指定类型的分数。例如：

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose 方法**
- `Enclose()`
- `Enclose(Char, Char)`

使用指定字符（如括号）将元素括起来。

``` cpp
/// <summary>
/// 用括号括住数学元素
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// 用指定字符将元素括住，例如括号或其他字符
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

示例：

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function 方法**
- `Function(String)`
- `Function(IMathElement)`

使用当前对象作为函数名，对参数进行函数包装。

``` cpp
/// <summary>
/// 将当前实例作为函数名，对参数进行函数包装
/// </summary>
virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;
virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

示例：

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **AsArgumentOfFunction 方法**
- `AsArgumentOfFunction(String)`
- `AsArgumentOfFunction(IMathElement)`
- `AsArgumentOfFunction(MathFunctionsOfOneArgument)`
- `AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)`
- `AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

使用当前实例作为函数参数，可指定函数名字符串、预定义枚举或 **IMathElement** 实例。

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);
auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");
auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);
auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- `SetSubscript(String)`
- `SetSubscript(IMathElement)`
- `SetSuperscript(String)`
- `SetSuperscript(IMathElement)`
- `SetSubSuperscriptOnTheRight(String, String)`
- `SetSubSuperscriptOnTheRight(IMathElement, IMathElement)`
- `SetSubSuperscriptOnTheLeft(String, String)`
- `SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)`

设置下标和上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的次数。

示例：

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical 方法**
- `Radical(String)`
- `Radical(IMathElement)`

为给定参数指定指定次数的根号。

示例：

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- `SetUpperLimit(String)`
- `SetUpperLimit(IMathElement)`
- `SetLowerLimit(String)`
- `SetLowerLimit(IMathElement)`

设置上限或下限。例如：

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary 和 Integral 方法**
- `Nary(MathNaryOperatorTypes, IMathElement, IMathElement)`
- `Nary(MathNaryOperatorTypes, String, String)`
- `Integral(MathIntegralTypes)`
- `Integral(MathIntegralTypes, IMathElement, IMathElement)`
- `Integral(MathIntegralTypes, String, String)`
- `Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)`
- `Integral(MathIntegralTypes, String, String, MathLimitLocations)`

这些方法返回 **IMathNaryOperator** 类型的 N 元运算符或积分对象。例如：

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray 方法**
`ToMathArray` 将元素放入垂直数组中。对 **MathBlock** 调用时，所有子元素将被放入返回的数组。

示例：

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **Accent**：在元素上方添加重音符号。
- **Overbar**、**Underbar**：在元素上方或下方添加横线。
- **Group**：使用分组字符（如底部大括号）将元素分组。
- **ToBorderBox**：为元素绘制边框盒。
- **ToBox**：将元素放入非可视盒（逻辑分组）。

示例：

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();
auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();
auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **常见问题**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，需要创建一个数学形状对象，该对象会自动包含一个数学段落。然后，从 **MathPortion** 中获取 **MathParagraph**，并向其添加 **MathBlock** 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 通过嵌套 **MathBlock** 支持创建复杂的数学表达式。每个数学元素实现 **IMathElement** 接口，可使用 Join、Divide、Enclose 等操作组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，首先通过 **MathParagraph** 访问已有的 **MathBlock**，然后使用 Join、Divide、Enclose 等方法修改对应的元素。编辑完成后，保存演示文稿即可应用更改。