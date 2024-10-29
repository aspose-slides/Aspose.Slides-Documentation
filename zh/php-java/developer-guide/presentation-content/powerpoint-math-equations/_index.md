---
title: PowerPoint 数学方程
type: docs
weight: 80
url: /zh/php-java/powerpoint-math-equations/
keywords: " PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
description: "PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
---

## **概述**
在 PowerPoint 中，可以书写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中提供了多种数学符号，可以添加到文本或方程中。为此，在 PowerPoint 中使用数学方程构造器，可以帮助创建复杂的公式，如：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N-元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，可以使用 *插入 -> 方程* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将创建一个可以在 PowerPoint 中显示为 XML 的数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建数学方程。然而，在 PowerPoint 中创建复杂的数学方程通常不会产生良好且专业的外观。需要频繁创建数学演示文稿的用户，常常求助于第三方解决方案以生成外观良好的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/)，可以在 PowerPoint 演示文稿中以编程方式处理数学方程。创建新的数学表达式或编辑先前创建的表达式。还部分支持将数学结构导出为图像。

## **如何创建数学方程**
数学元素用于构建任何级别的数学结构。一系列数学元素形成一个数学块，由 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 类表示。 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 类本质上是一个独立的数学表达式、公式或方程。 [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) 是一个数学部分，用于保存数学文本（不要与 [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) 混淆）。 [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) 允许操作一组数学块。上述类是通过 Aspose.Slides API 与 PowerPoint 数学方程进行交互的关键。

让我们看看如何通过 Aspose.Slides API 创建以下数学方程：

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

创建后，形状默认情况下将包含一个段落和一个数学部分。 [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) 类是一个包含数学文本的部分。要访问 [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) 内的数学内容，请参考 [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) 变量：

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

[**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) 类允许读取、添加、编辑和删除数学块（[**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)），由一组合数学元素组成。例如，创建一个分数并将其放置在演示文稿中：

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

每个数学元素由某个实现 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 接口的类表示。该接口提供了许多方法，可以轻松创建数学表达式。您可以编写单行代码来创建相当复杂的数学表达式。例如，勾股定理可以这样表示：

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

[**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 接口的操作实现了任何类型的元素，包括 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)。

完整的源代码示例：

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
数学表达式由数学元素的序列构成。数学元素的序列由数学块表示，数学元素的参数形成树状嵌套。

可以使用许多数学元素类型来构建数学块。每个元素都可以包含（聚合）在另一个元素中。也就是说，元素实际上是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本的元素。

每种类型的数学元素都实现了 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 接口，允许在不同类型的数学元素上使用一组通用的数学操作。
### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) 类表示数学文本 - 所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量及任何其他线性文本。

示例： 𝑎=𝑏+𝑐
### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) 类指定分数对象，由分子和分母组成，中间用分数线分隔。分数线可以是水平或对角线，具体取决于分数的属性。分数对象还用于表示堆叠函数，该函数将一个元素放置在另一个元素上方，而不使用分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) 类指定根函数（数学根），由基数和可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) 类指定一个参数的函数。包含属性：[getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - 函数名称和 [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) 类指定 N-元数学对象，如求和和积分。它由运算符、基数（或操作数）以及可选的上限和下限组成。N-元运算符的示例包括求和、并、交、积分。

此类不包括简单运算符，如加法、减法等。它们由单个文本元素 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) 类创建上限或下限。它指定的限度对象由基线上的文本和紧接在其上方或下方的缩小文本组成。此元素不包括“lim”这个单词，但允许您在表达式的顶部或底部放置文本。因此，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过以下方式使用 [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) 和 [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) 元素的组合创建的：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

以下类指定下标或上标。您可以同时在左侧或右侧设置下标和上标，但单个下标或上标仅在右侧支持。 [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) 也可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) 类指定矩阵对象，由一级或多级子元素排列组成。重要的是，矩阵没有内置分隔符。要将矩阵放在括号中，您需要使用分隔符对象 - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter)。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) 类指定方程组或任何数学对象的垂直数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox) 类：在 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 周围绘制矩形或其他边框。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox) 类：指定数学元素的逻辑框（打包）。例如，框住的对象可以作为运算符仿真器，带或不带对齐点，可以作为换行点，或者允许对其进行分组，使其不允许在内部换行。例如，"==" 运算符应被框住以防止换行。
- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter) 类：指定分隔符对象，由打开和关闭字符（如括号、大括号、方括号和垂直线）以及一个或多个数学元素组成，这些元素用指定字符分隔。示例：（𝑥2）； [𝑥2|𝑦2]。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent) 类：指定的重音函数，由基数和结合的发音符号组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar) 类：指定的条形函数，由基数参数和上划线或下划线组成。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter) 类：指定在表达式上方或下方的分组符号，通常用于突出显示元素之间的关系。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)）都实现了 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 接口。它允许您对现有结构进行操作并形成更复杂的数学表达式。所有操作都有两组参数集：可以是 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 或字符串作为参数。当使用字符串参数时，隐式创建 [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) 类的实例。Aspose.Slides 中可用的数学操作列举如下。
### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

连接一个数学元素并形成一个数学块。例如：

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

使用指定的分子和指定的分母创建指定类型的分数。例如：

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

将元素用指定字符（如括号或其他字符）括起来。

```php

``` 


例如：

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **Function 方法**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

利用当前对象作为函数名称来获取一个参数的函数。

```php

``` 


例如：

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **AsArgumentOfFunction 方法**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

使用当前实例作为参数来获取指定函数。您可以：

- 以字符串指定函数名称，例如 “cos”。
- 选择 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) 或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) 中的预定义值，例如 [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin)。
- 选择 [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 的实例。

例如：

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

设置下标和上标。您可以同时在左侧或右侧设置下标和上标，但单个下标或上标仅在右侧支持。**上标** 也可以用于设置数字的数学指数。

示例：

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定给定参数的给定次数的数学根。

示例：

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

获取上限或下限。这里，上下仅指提示中参数相对于基数的位置。

让我们考虑一个表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

这样的表达式可以通过 [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) 和 [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) 类的组合以及 [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) 的操作创建如下：

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **Nary 和 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 和 **integral** 方法都创建并返回由 [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator) 类型表示的 N-元运算符。在 nary 方法中， [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) 枚举指定运算符的类型：求和、并等，不包括积分。在积分方法中，专门的运算是有积分的，枚举积分类型是 [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes)。

示例：

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) 将元素放入垂直数组。如果对 [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) 实例调用此操作，则所有子元素将放置在返回的数组中。

示例：

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **格式化操作：重音、上划线、下划线、组、边框框、框**
- [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) 方法设置重音符号（元素顶部的字符）。
- [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) 和 [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) 方法在顶部或底部设置一个条。
- [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) 方法使用分组字符（如底部大括号或其他字符）对其放置在组中。
- [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) 方法将元素放置在边框框中。
- [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) 方法对其放置在非可视框中（逻辑分组）。

示例：

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 