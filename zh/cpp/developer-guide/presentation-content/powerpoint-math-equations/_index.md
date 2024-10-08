---
title: PowerPoint 数学方程
type: docs
weight: 80
url: /zh/cpp/powerpoint-math-equations/
keywords: " PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
description: "PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示它。为此，PowerPoint 中表示了各种数学符号，并可以将其添加到文本或方程中。为此，使用 PowerPoint 中的数学方程构造器，可以帮助创建复杂的公式，例如：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N-元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，使用 *插入 -> 方程* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建一个数学文本，可以在 PowerPoint 中显示为如下形式：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持许多数学符号来创建数学方程。然而，在 PowerPoint 中创建复杂的数学方程通常不会带来良好的专业效果。需要频繁创建数学演示文稿的用户往往会求助于第三方解决方案来创建外观良好的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/)，您可以以编程方式在 C++ 中处理 PowerPoint 演示文稿中的数学方程。创建新的数学表达式或编辑先前创建的表达式。数学结构导出为图像也部分支持。


## **如何创建数学方程**
数学元素用于构建任何数字构造，具有任何嵌套级别。数学元素的线性集合形成一个由 [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) 类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) 类本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) 是一个数学部分，用于保存数学文本（与 [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) 不混淆）。[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) 允许操作一组数学块。这些类是通过 Aspose.Slides API 处理 PowerPoint 数学方程的关键。


我们来看看如何通过 Aspose.Slides API 创建以下数学方程：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将包含数学文本的形状：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


创建后，该形状将默认包含一个带有数学部分的段落。 [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) 类是一个包含数学文本的部分。要访问 [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) 内部的数学内容，请参考 [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) 变量：

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


[**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) 类允许读取、添加、编辑和删除由一组数学元素组合而成的数学块（[**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)）。例如，创建一个分数，并将其放置在演示文稿中：

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


每个数学元素由某个实现 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 接口的类表示。该接口提供了许多方法，可轻松创建数学表达式。例如，毕达哥拉斯定理可以如下所示：

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 


接口 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 的操作在任何类型的元素中实现，包括 [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)。

完整的源代码示例：

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
数学表达式由数学元素序列组成。数学元素的序列被表示为一个数学块，而数学元素的参数形成一个树状嵌套。

有许多数学元素类型可以用于构建数学块。这些元素中的每一个都可以包含（聚合）在另一个元素中。也就是说，元素实际上是其他元素的容器，形成树状结构。最简单的元素类型是不含其他数学文本元素的元素。

每种类型的数学元素实现 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 接口，允许在不同类型的数学元素上使用共同的数学操作。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) 类表示数学文本 - 所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量以及任何其他线性文本。

示例： 𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) 类指定分数对象，由分子和分母组成，中间有分数线。分数线可以是水平的或对角线的，具体取决于分数的属性。分数对象也被用来表示堆叠函数，该函数将一个元素放在另一个元素之上，而没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) 类指定根函数（数学根），由一个基数和一个可选的程度组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) 类指定一个参数的函数。包含方法：[get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) - 函数名称和 [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) 类指定一个 N-元数学对象，例如求和和积分。它由一个运算符、一个基数（或操作数）以及可选的上限和下限组成。N-元运算符的示例包括求和、并集、交集、积分。

此类不包括简单运算符，例如加法、减法等。它们由单个文本元素表示 - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) 类创建上限或下限。它指定限制对象，由基线上的文本和紧接其上方或下方的小字体文本组成。此元素不包括单词“lim”，而是允许您在表达式的顶部或底部放置文本。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过将 [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) 和 [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) 元素组合创建的，如下所示：

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

以下类指定下标或上标。您可以在一个参数的左侧或右侧同时设置下标和上标，但仅支持右侧的单个下标或上标。[MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) 也可用于设置数的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) 类指定矩阵对象，由得以排列的一行或多行子元素组成。需要注意的是，矩阵没有内置的分隔符。要将矩阵置于括号中，您应使用分隔符对象 - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter)。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) 类指定一组垂直的方程或任何数学对象。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box) 类：绘制一个矩形或其他边框在 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 周围。

  示例： ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box) 类：指定数学元素的逻辑包装（打包）。例如，盒装对象可以作为运算符仿真器，无论是否有对齐点，可以作为换行点，或被分组，以便不允许在其中换行。例如，“==”运算符应被盒装，以防止换行。
- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter) 类：指定分隔符对象，由开合字符（如括号、大括号、方括号和竖线）和一个或多个数学元素组成，元素之间用指定字符分隔。示例：(𝑥2); [𝑥2|𝑦2]。

  示例： ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent) 类：指定重音功能，由基数和一个组合的变音符号组成。

  示例： 𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar) 类：指定条形函数，由基数参数和一个上划线或下划线组成。

  示例： ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character) 类：指定在表达式上方或下方的分组符号，通常用于突出元素之间的关系。

  示例： ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)）实现 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 接口。它允许您对现有结构进行操作，并形成更复杂的数学表达式。所有操作有两组参数：参数可以是 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 或字符串。当使用字符串参数时，从指定字符串隐式创建 [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) 类的实例。Aspose.Slides 中可用的数学操作列出如下。

### **Join 方法**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

连接数学元素并形成数学块。例如：

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 


### **Divide 方法**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

创建具有指定类型的分数及其分子和指定的分母。例如：

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose 方法**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

将元素包裹在指定字符中，如圆括号或其他字符作为框架。

``` cpp
/// <summary>
/// 将数学元素包裹在圆括号中
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// 将该元素包裹在指定字符中，如圆括号或其他字符作为框架
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 


例如：

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function 方法**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

使用当前对象作为函数名称获取函数参数。

``` cpp
/// <summary>
/// 将此实例作为函数名获取函数的参数
/// </summary>
/// <param name="functionArgument">函数的参数</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 


例如：

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **AsArgumentOfFunction 方法**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

使用当前实例作为参数获取指定函数。您可以：

- 指定字符串作为函数名，例如 “cos”。
- 选择 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) 或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b) 的枚举之一，例如 **MathFunctionsOfOneArgument.ArcSin.**
- 选择 [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 的实例。

例如：

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft 方法**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

设置下标和上标。您可以在参数的左侧或右侧同时设置下标和上标，但仅支持右侧的单个下标或上标。**上标**也可用于设置数字的数学指数。

示例：

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical 方法**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

指定给定参数的根号数学根。

示例：

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

获取上限或下限。在这里，上限和下限只是表明参数相对于基础的位置信息。

我们考虑一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

这样的表达式可以通过结合 [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) 和 [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) 类以及 [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) 的操作创建，如下所示：

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary 和 Integral 方法**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

**Nary** 和 **Integral** 方法创建并返回由 [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator) 类型表示的 N-元运算符。在 Nary 方法中，枚举 [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) 指定运算符的类型：求和、并集等，而不包括积分。在 Integral 方法中，有积分的特殊运算，带有积分类型的枚举 [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607)。

示例：

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray 方法**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) 将元素放入垂直数组。如果对 **MathBlock** 实例调用此操作，则所有子元素将放置在返回的数组中。

示例：

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) 方法设置重音标记（在元素顶部的字符）。
- [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) 和 [**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) 方法在顶部或底部设置一个条形。
- [**Group**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546) 方法使用底部大括号或其他符号放置在组中。
- [**ToBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b) 方法放置在边框箱中。
- [**ToBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2) 方法放置在非视觉框（逻辑分组）中。

示例：

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 
