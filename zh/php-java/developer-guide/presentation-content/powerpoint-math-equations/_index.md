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
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制和清晰的代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学公式并在演示文稿中显示。为此，PowerPoint 中表示了各种数学符号，可将它们添加到文本或公式中。PowerPoint 使用数学公式构造器来帮助创建诸如以下的复杂公式：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- 多元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert → Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将生成 XML 格式的数学文本，PowerPoint 可显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学公式。然而，在 PowerPoint 中创建复杂的数学公式往往难以得到美观、专业的效果。需要频繁制作数学演示文稿的用户通常会求助第三方解决方案来生成美观的公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑已有表达式。对数学结构导出为图像也得到部分支持。

## **如何创建数学公式**
数学元素用于构建任意层次嵌套的数学结构。线性集合的数学元素形成由 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 类表示的数学块。**MathBlock** 类本质上是一个独立的数学表达式、公式或方程。**MathPortion** 是用于保存数学文本的数学部分（不要与 [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) 混淆）。**MathParagraph** 允许操作一组 MathBlock。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面展示如何使用 Aspose.Slides API 创建以下数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将包含数学文本的形状：
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


创建后，形状默认已包含一个带有数学部分的段落。**MathPortion** 类是包含数学文本的部分。要访问 **MathPortion** 内的数学内容，请参考 **MathParagraph** 变量：
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
```


## **数学元素类型**
数学表达式由一系列数学元素组成。元素序列由数学块表示，元素的参数形成树形嵌套。

有许多数学元素类型可用于构建数学块。每种元素都可以被包含在另一元素中，即元素本身是容器，形成树形结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现 `MathElement` 类，允许对不同类型的数学元素使用通用的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) 类表示数学文本——所有数学构造的底层元素。数学文本可以表示操作数、运算符、变量以及任何线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) 类定义分数对象，由分子和分母组成，之间用分数线分隔。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，即一个元素位于另一个元素之上且没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) 类定义根号函数，由基数和可选的指数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) 类定义带参数的函数。包含属性：`getName` ——函数名，`getBase` ——函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) 类定义 N 元数学对象，如求和和积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算符的示例包括求和、并集、交集、积分。

该类不包括加法、减法等简单运算符，这些由单个文本元素 **MathematicalText** 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) 类创建上限或下限。它由基线文本和紧邻其上方或下方的缩小文本组成。该元素本身不包含 “lim” 关键字，但可用于在表达式的上方或下方放置文本。因此，下面的表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合 **MathFunction** 和 **MathLimit** 元素实现的：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

这些类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**MathSubscriptElement** 还可用于设置数字的数学次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) 类定义矩阵对象，由子元素按行列布局组成。需要注意的是矩阵本身没有内置分隔符。若要将矩阵放入括号中，需要使用分隔符对象 **MathDelimiter**。可使用空参数在矩阵中创建空位。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) 类定义垂直排列的方程或其他数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) 类：在 `MathElement` 周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) 类：指定数学元素的逻辑包装。例如，盒装对象可作为带或不带对齐点的运算符仿真，充当换行点，或被分组以防止换行。比如 “==” 运算符应盒装以防止换行。

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) 类：指定分隔符对象，由左、右字符（如括号、大括号、方括号、竖线）以及内部的一个或多个数学元素组成。示例：(𝑥²); [𝑥²|𝑦²]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) 类：指定重音符号，由基字符和组合变音符号组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) 类：指定横线函数，由基参数和上横线或下横线组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) 类：指定分组符号，放在表达式上方或下方，用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)）都继承 `MathElement` 类。它允许对现有结构进行操作并构建更复杂的数学表达式。所有运算都有两种参数形式：`MathElement` 或字符串。当使用字符串参数时，将隐式创建相应的 **MathematicalText** 实例。以下列出 Aspose.Slides 提供的数学运算。

### **Join 方法**
- `join(String)`
- `join(MathElement)`

将两个数学元素连接形成数学块。例如：

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

使用指定的分子和分母创建指定类型的分数。例如：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose 方法**
- `enclose()`
- `enclose(Char, Char)`

用指定字符（如括号）将元素括起来。

```php

``` 

示例：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function 方法**
- `function(String)`
- `function(MathElement)`

使用当前对象作为函数名，创建对参数的函数调用。

```php

``` 

示例：

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction 方法**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

将当前实例作为指定函数的参数。您可以：

- 使用字符串指定函数名，例如 “cos”。
- 选择枚举 **MathFunctionsOfOneArgument** 或 **MathFunctionsOfTwoArguments** 中的预定义值，例如 **MathFunctionsOfOneArgument::ArcSin**。
- 直接传入 `MathElement` 实例。

示例：

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

设置下标和上标。可在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 还能用于设置数字的数学次数。

示例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- `radical(String)`
- `radical(MathElement)`

指定给定参数的指定次数的数学根。

示例：

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

设置上限或下限。上、下限仅表示相对于基数的上下位置。

例如下面的表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

可通过组合 **MathFunction** 与 **MathLimit** 类以及 `MathElement` 的操作实现：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary 与 Integral 方法**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

**nary** 与 **integral** 方法均创建并返回 **MathNaryOperator** 类型的 N 元运算符。`MathNaryOperatorTypes` 枚举指定运算符类型（求和、并集等），不包括积分。`MathIntegralTypes` 枚举用于积分运算。

示例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray 方法**
`MathElement.toMathArray` 将元素放入垂直数组。如果对 **MathBlock** 实例调用此操作，所有子元素将被放入返回的数组中。

示例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **`accent`** 方法在元素顶部添加重音符号。
- **`overbar`** 与 **`underbar`** 方法在元素顶部或底部添加横线。
- **`group`** 方法使用分组字符（如底部大括号）将元素分组。
- **`toBorderBox`** 方法将元素放入带边框的盒子。
- **`toBox`** 方法将元素放入非可视的逻辑盒子。

示例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **常见问答**

**如何在 PowerPoint 幻灯片中添加数学公式？**

首先创建一个数学形状对象，系统会自动包含一个数学部分。然后从 **MathPortion** 中获取 **MathParagraph**，向其添加 **MathBlock** 对象即可。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 通过嵌套 **MathBlock** 支持创建复杂的数学表达式。每个数学元素都可以使用 Join、Divide、Enclose 等操作组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

通过 **MathParagraph** 访问已有的 **MathBlock**，使用 Join、Divide、Enclose 等方法修改各个元素，编辑完成后保存演示文稿即可。