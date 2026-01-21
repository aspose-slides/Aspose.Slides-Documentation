---
title: 在 C++ 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/cpp/powerpoint-math-equations/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 C++ 代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中表示了各种数学符号，可以将其添加到文本或公式中。为此，PowerPoint 使用数学公式构造器，帮助创建诸如：

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

PowerPoint 支持大量数学符号来创建数学公式。然而，在 PowerPoint 中创建复杂的数学公式往往难以获得专业的外观。需要频繁制作数学演示文稿的用户，往往会求助于第三方解决方案，以创建美观的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)，您可以在 C++ 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑已创建的表达式。对数学结构导出为图像也得到部分支持。

## **如何创建数学公式**
数学元素用于构建任何层次嵌套的数学结构。线性的数学元素集合形成一个由[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)类本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)是用于保存数学文本的数学部分（不要与[**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)混淆）。[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何通过 Aspose.Slides API 创建如下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将容纳数学文本的形状：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

创建后，形状默认已包含一个带有数学部分的段落。[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)类是一个包含数学文本的部分。要访问[**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)内部的数学内容，请引用[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)变量：

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)类允许读取、添加、编辑和删除由数学元素组合而成的数学块（[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)）。例如，创建一个分数并将其放入演示文稿：

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

每个数学元素都由实现[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)接口的类表示。该接口提供了大量方法，可轻松创建数学表达式。您可以用一行代码创建相当复杂的数学表达式。例如，勾股定理的写法如下：

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)接口的操作在任何类型的元素中实现，包括[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)。

完整源码示例：

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
数学表达式由一系列数学元素构成。数学元素序列由数学块表示，数学元素的参数形成树状嵌套。

有许多数学元素类型可用于构建数学块。每种元素都可以被包含在另一元素中，即元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)接口，允许对不同类型的数学元素使用统一的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)类表示数学文本——所有数学构造的底层元素。数学文本可表示操作数、运算符、变量以及任何线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/)类定义分数对象，由分子和分母组成，之间有分数线。分数线可以是水平或对角线，取决于属性。该类亦用于表示堆叠函数，即一个元素位于另一元素之上且无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/)类定义根号函数，由基底和可选的次数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/)类表示含参函数。包含方法：[`get_Name()`](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/)——函数名，以及[`get_Base()`](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/)——函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/)类表示 N 元数学对象，如求和和积分。它由运算符、基底（或操作数）以及可选的上、下限组成。N 元运算符的示例包括求和、并集、交集、积分。

该类不包括加、减等简单运算符；它们由单一文本元素——[MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/)类创建上限或下限。它由基线上的文本和紧邻其上方或下方的缩小文本组成。该元素本身不包含“lim”字样，但可在表达式的上方或下方放置文本。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

可通过组合[**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/)和[**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/)元素实现：

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

这些类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。[MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)也可用于设置数字的数学次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/)类表示矩阵对象，由子元素按行列布局组成。需要注意的是矩阵本身没有内置分隔符。若需在括号中放置矩阵，应使用分隔符对象——[**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/)。可以使用空参数创建矩阵中的空白。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/)类表示垂直排列的方程或任何数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/)类：在[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/)类：指定数学元素的逻辑分箱（包装）。例如，分箱对象可用作带或不带对齐点的运算符模拟器，可用作换行点，或作为不可换行的组合。例如，"==" 运算符应分箱以防止换行。
- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/)类：指定分隔符对象，由左、右字符（如括号、花括号、方括号或竖线）组成，内部可包含一个或多个数学元素，使用指定字符分隔。示例：(𝑥2); [𝑥2|𝑦2]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/)类：指定重音符号，由基底和组合的变音符号组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/)类：指定上横线或下横线，由基底参数和横线组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/)类：指定位于表达式上方或下方的分组符号，通常用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和通过[**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)表示的数学表达式都实现了[**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)接口。它允许在已有结构上使用运算并构建更复杂的数学表达式。所有运算都有两套参数：可以是[**IMathElement**]或字符串。使用字符串时，会隐式从指定的字符串创建[**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)实例。下面列出 Aspose.Slides 支持的数学运算。

### **Join 方法**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

将数学元素连接形成数学块。例如：

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Divide 方法**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

使用指定分子和分母创建指定类型的分数。例如：

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose 方法**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

使用指定字符（如括号）将元素括起来。

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

示例：

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function 方法**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

使用当前对象作为函数名，接受一个参数。

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

示例：

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **AsArgumentOfFunction 方法**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

使用当前实例作为参数，接受指定函数。例如：

- 使用字符串作为函数名，如 “cos”；
- 选择枚举值[**MathFunctionsOfOneArgument**]或[**MathFunctionsOfTwoArguments**]中的预定义函数，例如 **MathFunctionsOfOneArgument.ArcSin**；
- 使用[**IMathElement**]实例。

示例：

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

设置下标和上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的次数。

示例：

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical 方法**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

指定给定次数的数学根号。

示例：

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

设置上限或下限。这里的上、下仅表示参数相对于基底的位置。

考虑表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

该表达式可以通过组合[MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/)和[MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/)类以及[IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)的操作实现：

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary 与 Integral 方法**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

**Nary** 与 **Integral** 方法均返回由[**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/)类型表示的 N 元运算符。**Nary** 方法中，枚举[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperatortypes/)指定运算符类型，如求和、并集等，不包括积分。**Integral** 方法则使用枚举[**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathintegraltypes/)指定积分类型。

示例：

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray 方法**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/)将元素放入垂直数组。如果对 **MathBlock** 实例调用此操作，所有子元素将被放入返回的数组中。

示例：

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **Accent** 方法为元素添加重音符号（元素上方的字符）。
- **Overbar** 与 **Underbar** 方法在元素上方或下方添加横线。
- **Group** 方法使用分组字符（如底部大括号等）将元素组合为一组。
- **ToBorderBox** 方法为元素添加边框框。
- **ToBox** 方法将元素放入非可视的逻辑盒（分组）。

示例：

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **常见问题解答**

**如何在 PowerPoint 幻灯片中添加数学公式？**

要添加数学公式，需要创建一个 math shape 对象，该对象会自动包含一个数学部分。随后，从 [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) 获取 [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)，并向其添加 [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) 对象。

**能否创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 允许通过嵌套 MathBlock 创建复杂数学表达式。每个数学元素实现了 [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) 接口，可使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过 [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) 访问已有的 MathBlock。随后，可使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。