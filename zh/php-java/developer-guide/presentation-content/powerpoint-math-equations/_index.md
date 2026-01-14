---
title: 在 PHP 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/php-java/powerpoint-math-equations/
keywords:
- 数学方程
- 数学符号
- 数学公式
- 数学文本
- 添加数学方程
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制和清晰的代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中提供了各种数学符号，可添加到文本或公式中。PowerPoint 使用数学公式构造器来创建诸如以下复杂公式：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，可使用 *插入 -> 公式* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建数学文本，可在 PowerPoint 中显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学公式。然而，在 PowerPoint 中创建复杂的数学公式往往难以获得良好且专业的效果。需要经常制作数学演示文稿的用户会求助于第三方解决方案来创建美观的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像也部分支持。

## **如何创建数学公式**
数学元素用于构建任何层次嵌套的数学结构。线性集合的数学元素形成一个由 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 类表示的数学块。[**MathBlock**] 类本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) 是用于保存数学文本的数学部分（请勿与 [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) 混淆）。[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) 允许操作一组数学块。上述类是通过 Aspose.Slides API 处理 PowerPoint 数学公式的关键。

下面我们来看如何通过 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先，添加一个将包含数学文本的形状：
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


创建后，形状默认已包含一个带有数学部分的段落。[**MathPortion**] 类是包含数学文本的部分。要访问 [**MathPortion**] 中的数学内容，请参阅 [**MathParagraph**] 变量：
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

Each mathematical element is represented by some class that implements the `MathElement` class. This class provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

Operations of the class `MathElement` are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

The full source code sample:

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
数学表达式由一系列数学元素构成。数学元素序列由数学块表示，数学元素的参数形成树状嵌套。

有许多数学元素类型可用于构建数学块。每个元素都可以包含（聚合）在另一个元素中。也就是说，元素实际上是其他元素的容器，形成树状结构。最简单的元素类型是不包含其他数学文本元素的。

每种数学元素类型都实现了 `MathElement` 类，允许对不同类型的数学元素使用通用的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**] 类表示数学文本——所有数学构造的基础元素。数学文本可以表示操作数和运算符、变量以及其他任何线性文本。

示例： 𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**] 类表示分数对象，由分子和分母通过分数线分隔。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，它将一个元素放在另一个元素之上且没有分数线。

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**] 类表示根式（数学根），包括基数和可选的指数。

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**] 类表示带参函数。包含属性：`getName` – 函数名称，`getBase` – 函数参数。

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**] 类表示 N 元数学对象，例如求和和积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算的示例有求和、并集、交集、积分。

此类不包括加法、减法等简单运算符。这些由单个文本元素 [MathematicalText] 表示。

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**] 类用于创建上限或下限。它指定由基线上的文本和紧邻其上（或下）的缩小文本组成的限制对象。此元素不包括单词 “lim”，但允许您在表达式的顶部或底部放置文本。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是使用 [**MathFunction**] 和 [**MathLimit**] 元素组合而成，代码如下：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

以下类用于指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅支持右侧。[MathSubscriptElement] 还可用于设置数字的数学次方。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**] 类表示矩阵对象，由排列在一个或多个行列中的子元素组成。需要注意的是，矩阵本身没有内置的分隔符。若要在括号中放置矩阵，需要使用分隔符对象 - [**MathDelimiter**]。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**] 类表示垂直排列的方程或其他数学对象的数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素格式化**
- [**MathBorderBox**] 类：在 `MathElement` 周围绘制矩形或其他形状的边框。  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**] 类：指定数学元素的逻辑盒装（封装）。例如，盒装对象可用作带或不带对齐点的运算符模拟器，作为换行点，或分组以防止在其中换行。例如，应该对 “==” 运算符进行盒装以防止换行。

- [**MathDelimiter**] 类：指定分隔符对象，由左、右字符（如圆括号、花括号、方括号和竖线）以及其中的一个或多个数学元素组成，元素之间用指定字符分隔。例如：(𝑥2); [𝑥2|𝑦2]。  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**] 类：指定重音（变音）函数，由基底和组合变音记号组成。  
  示例：𝑎́。

- [**MathBar**] 类：指定条形函数，由基底参数以及上横线或下横线组成。  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**] 类：指定放置在表达式上方或下方的分组符号，通常用于突出元素之间的关系。  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**]）都继承自 `MathElement` 类。它允许对已有结构使用操作并形成更复杂的数学表达式。所有操作有两套参数：`MathElement` 或字符串。在使用字符串参数时，会隐式从指定的字符串创建 [**MathematicalText**] 类的实例。Aspose.Slides 支持的数学操作列举如下。

### **Join 方法**
- `join(String)`
- `join(MathElement)`

将数学元素连接形成数学块。例如：

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide 方法**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

使用指定的分子和分母创建特定类型的分数。例如：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose 方法**
- `enclose()`
- `enclose(Char, Char)`

将元素用指定字符（如括号或其他字符）包裹起来。

```php

``` 

例如：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function 方法**
- `function(String)`
- `function(MathElement)`

使用当前对象作为函数名，对参数进行函数调用。

```php

``` 

例如：

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction 方法**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

使用当前实例作为参数，将指定函数应用于其上。您可以：

- 以字符串形式指定函数名称，例如 “cos”。
- 选择枚举 [**MathFunctionsOfOneArgument**] 或 [**MathFunctionsOfTwoArguments**] 中的预定义值，例如 [**MathFunctionsOfOneArgument**].[**ArcSin**]。
- 传入 `MathElement` 实例。

例如：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

设置下标和上标。您可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅支持右侧。**Superscript** 还可用于设置数字的数学次方。

示例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- `radical(String)`
- `radical(MathElement)`

指定给定参数的数学根及其次数。

示例：

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

设置上限或下限。这里的上、下仅表示相对于基底的相对位置。

考虑以下表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

此类表达式可通过组合 [MathFunction] 和 [MathLimit] 类以及 `MathElement` 的操作创建，如下：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary 和 Integral 方法**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

两者均创建并返回由 [**MathNaryOperator**] 类型表示的 N 元运算符。`nary` 方法使用 [**MathNaryOperatorTypes**] 枚举指定运算符类型（如求和、并集等），不包括积分。`integral` 方法使用积分类型枚举 [**MathIntegralTypes**]。

示例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray 方法**
`MathElement.toMathArray` 将元素放入垂直数组中。如果对 [**MathBlock**] 实例调用此操作，所有子元素都将放入返回的数组。

示例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **`accent`** 方法为元素添加重音标记（位于元素上方的字符）。
- **`overbar`** 与 **`underbar`** 方法分别在元素上方或下方添加横线。
- **`group`** 方法使用分组字符（如底部大括号等）将元素分组。
- **`toBorderBox`** 方法将元素放入带边框的盒子中。
- **`toBox`** 方法将元素放入非可视的逻辑盒中（逻辑分组）。

示例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **常见问题**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，需要创建一个数学形状对象，系统会自动包含一个数学部分。然后，从该 [MathPortion] 中获取 [MathParagraph]，并向其添加 [MathBlock] 对象。

**是否可以创建复杂的嵌套数学表达式？**

是的，Aspose.Slides 通过嵌套 MathBlocks 允许创建复杂的数学表达式。每个数学元素均可使用 Join、Divide、Enclose 等操作组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过 [MathParagraph] 访问已有的 MathBlocks。随后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可生效。