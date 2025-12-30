---
title: 在 PHP 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制和清晰的代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并将其显示在幻灯片中。为此，PowerPoint 提供了各种数学符号，能够添加到文本或公式中。PowerPoint 使用数学公式构造器来帮助创建诸如：

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

PowerPoint 支持大量数学符号以创建公式。然而，在 PowerPoint 中创建复杂公式往往难以得到专业且美观的效果。需要频繁制作数学演示的用户，会求助于第三方方案来生成好看的公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像也得到部分支持。

## **如何创建数学公式**
数学元素用于构建任意层次嵌套的数学结构。线性集合的数学元素形成由[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)类表示的数学块。**MathBlock**本质上是一个独立的数学表达式、公式或方程。**MathPortion**是用于保存数学文本的数学部分（不要与[**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)混淆）。**MathParagraph**允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建下图所示的数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将容纳数学文本的形状：
```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


创建后，该形状默认已包含一个带有数学部分的段落。**MathPortion**类表示包含数学文本的部分。要访问 **MathPortion** 内的数学内容，请引用[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)变量：
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **数学元素类型**
数学表达式由一系列数学元素组成。数学元素序列由数学块表示，元素的参数形成树形嵌套。

有许多数学元素类型可用于构建数学块。每个元素都可以被包含在另一个元素中，即元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)接口，允许对不同类型的数学元素使用统一的数学操作集。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)类表示数学文本——所有数学构造的基础元素。数学文本可以表示操作数、运算符、变量以及其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction)类指定分数对象，由分子和分母组成，二者由分数线分隔。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，即将一个元素置于另一个元素之上且无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical)类指定根号函数（数学根），由基数和可选的次数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)类指定带参数的函数。包含属性：`getName`‑函数名和`getBase`‑函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator)类指定 N 元数学对象，如求和和积分。它由运算符、基数（或操作数）以及可选的上、下界组成。N 元运算的例子包括求和、并集、交集、积分。

该类不包括加、减等简单运算符，这些通过单个文本元素[MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)类创建上界或下界。它指定由基线文本及其上下方的缩小文本组成的限制对象。该元素本身不包括单词“lim”，但可用于在表达式的顶部或底部放置文本。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)和[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)组合实现的，如下：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

上述类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。`MathSubscriptElement` 也可用于设置数字的数学次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix)类指定矩阵对象，由子元素按行列布局组成。需要注意的是矩阵本身没有内置分隔符。若要在括号中放置矩阵，需要使用分隔符对象‑[**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter)。可使用空参数在矩阵中创建空位。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray)类指定垂直排列的方程或任意数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素的格式化**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox)类：在[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)周围绘制矩形或其他边框。  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox)类：指定数学元素的逻辑包装。例如，包装后的对象可作为带或不带对齐点的运算符仿真、行断点或防止行内换行的组合。比如 “==” 运算符应被包装以防止换行。

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter)类：指定分隔符对象，由左、右字符（如圆括号、花括号、方括号、竖线）以及内部的一个或多个数学元素组成，元素之间可用指定字符分隔。示例：(𝑥2); [𝑥2|𝑦2]。  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent)类：指定重音函数，由基字符和组合变音符组成。  
  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar)类：指定上横线或下横线函数，由基参数和相应的横线组成。  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter)类：指定位于表达式上方或下方的分组符号，通常用于强调元素之间的关系。  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)）实现[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)接口。它允许对现有结构进行操作，组成更复杂的数学表达式。所有操作都有两组参数：可以是[**IMathElement**]或字符串。使用字符串参数时，会隐式创建[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)实例。以下列出 Aspose.Slides 提供的数学操作。

### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

将两个数学元素连接成一个数学块。例如：

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide 方法**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

使用指定的分子和分母创建指定类型的分数。例如：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

用指定字符（如括号）将元素包裹起来。

```php

``` 

示例：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function 方法**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

使用当前对象作为函数名，将其作为参数函数。

```php

``` 

示例：

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction 方法**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

使用当前实例作为参数，将其作为指定函数的参数。可：

- 指定函数名字符串，例如 “cos”。
- 选择枚举 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) 或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) 中的预定义值，例如 [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin)。
- 传入 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 实例。

示例：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

设置下标和上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的数学次数。

示例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定给定次数的数学根。

示例：

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

设置上界或下界。这里的上、下仅表示参数相对于基数的位置。

考虑以下表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

该表达式可通过组合 [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) 与 [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) 类以及 [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 的操作实现：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary 与 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 与 **integral** 方法均创建并返回 [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator) 类型的 N 元运算符。**nary** 方法的 `MathNaryOperatorTypes` 枚举指定运算符类型（求和、并集等），不包括积分。**integral** 方法则使用 `MathIntegralTypes` 枚举专门处理积分。

示例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) 将元素放入垂直数组中。对 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 实例调用此操作时，所有子元素将被放入返回的数组。

示例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **accent** 方法为元素添加重音符（位于元素顶部的字符）。  
- **overbar** 与 **underbar** 方法分别在元素上方或下方添加横线。  
- **group** 方法使用分组字符（如底部大括号）将元素组合在一起。  
- **toBorderBox** 方法将元素放入边框盒。  
- **toBox** 方法将元素放入非可视盒（逻辑分组）。

示例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **常见问题**

**如何在 PowerPoint 幻灯片中添加数学公式？**

要添加数学公式，需要创建一个数学形状对象，系统会自动包含一个数学部分。随后，从 **MathPortion** 中获取 **MathParagraph**，并向其添加 **MathBlock** 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 通过嵌套 **MathBlock** 支持创建复杂的数学表达式。每个数学元素均可使用 Join、Divide、Enclose 等操作组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需通过 **MathParagraph** 访问现有的 **MathBlock**，然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后保存演示文稿即可。