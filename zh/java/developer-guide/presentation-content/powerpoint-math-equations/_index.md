---
title: PowerPoint 数学方程
type: docs
weight: 80
url: /zh/java/powerpoint-math-equations/
keywords: " PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
description: "PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并将其显示在演示文稿中。为此，PowerPoint 中表示了各种数学符号，并可以将其添加到文本或方程中。为此，PowerPoint 中使用数学方程构造函数，可以创建复杂的公式，如：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，可以使用 *插入 -> 方程* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建一个数学文本，可以在 PowerPoint 中显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学方程。然而，在 PowerPoint 中创建复杂的数学方程通常不能带来良好和专业的外观结果。需要频繁创建数学演示文稿的用户，常常依赖第三方解决方案来创建美观的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/java/)，您可以通过 C# 程序性地处理 PowerPoint 演示文稿中的数学方程。创建新的数学表达式或编辑以前创建的表达式。将数学结构导出为图像也部分支持。


## **如何创建数学方程**
数学元素用于构建任何层次嵌套的数学结构。线性数学元素的集合形成由 [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) 类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) 类本质上是一个分离的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) 是一个数学部分，用于包含数学文本（不要与 [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) 混淆）。[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) 允许操作一组数学块。上述类是通过 Aspose.Slides API 使用 PowerPoint 数学方程的关键。

让我们看看如何通过 Aspose.Slides API 创建以下数学方程：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先，添加一个包含数学文本的形状：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

创建后，形状将默认包含一个段落和一个数学部分。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) 类是包含数学文本的部分。要访问 [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) 中的数学内容，请引用 [**MathParagraph** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph)变量：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) 类允许读取、添加、编辑和删除数学块（[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)），这些块由数学元素的组合组成。例如，创建一个分数并将其放置在演示文稿中：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

每个数学元素由实现 [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 接口的某个类表示。该接口提供了许多方法，便于创建数学表达式。您可以用一行代码创建一个相当复杂的数学表达式。例如，勾股定理的表达式如下：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

接口 [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 的操作可在任何类型的元素中实现，包括 [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)。

完整的示例代码：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **数学元素类型**
数学表达式是由数学元素的序列构成的。数学元素的序列由一个数学块表示，而数学元素的参数形成树状嵌套结构。

可以使用许多数学元素类型来构造数学块。每个元素可以包含（聚合）在另一个元素中。也就是说，元素实际上是容器，用于形成树状结构。最简单的元素类型是不包含其他数学文本的元素。

每种类型的数学元素实现 [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 接口，允许在不同类型的数学元素上使用通用的数学操作集。
### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) 类表示数学文本 - 所有数学结构的基础元素。数学文本可以表示操作数和运算符、变量以及其他任何线性文本。

示例： 𝑎=𝑏+𝑐
### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) 类指定分数对象，由分数线分隔的分子和分母组成。分数线可以是水平或对角的，具体取决于分数的属性。分数对象还用于表示堆叠函数，该函数将一个元素放在另一个元素上方，而无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) 类指定根号函数（数学根），由一个基数和一个可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) 类指定一个参数的函数。包含属性: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - 函数名称和 [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - 函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) 类指定 N 叉数学对象，例如求和和积分。它由操作符、基数（或操作数）、可选的上限和下限组成。N 叉操作符的示例包括求和、并集、交集、积分。

该类不包括简单的运算符，如加法、减法等。它们由一个单独的文本元素 - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) 类创建上限或下限。它指定限制对象，包含基线上的文本和立即在其上方或下方的缩小尺寸文本。该元素不包含单词“lim”，但允许在表达式的顶部或底部放置文本。因此，该表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过以下方式使用 [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) 和 [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) 元素的组合创建的：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

以下类指定下标或上标。您可以在参数的左侧或右侧同时设置下标和上标，但单个下标或上标仅在右侧支持。 [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) 还可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) 类指定矩阵对象，由一行或多行和多列排列的子元素组成。需要注意的是，矩阵没有内置的分隔符。要将矩阵放在括号中，您应该使用分隔符对象 - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter)。可以使用空参数在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) 类指定方程或任何数学对象的垂直数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) 类：在 [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 周围绘制矩形或其他边框。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) 类：指定数学元素的逻辑封装（包装）。例如，带或不带对齐点的盒子对象可以作为运算符仿真器，或者作为行断点，或者分组不允许在其中换行。例如，“==” 运算符应该被包装以防止换行。
- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) 类：指定分隔符对象，由打开和关闭字符（如括号、大括号、方括号和垂直条）组成，并包含一个或多个内部的数学元素，用指定字符分隔。示例：（𝑥2）；[𝑥2|𝑦2]。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) 类：指定的是一个基数和一个结合的变音符号的基线函数。 

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) 类：指定由基数参数和上划线或下划线组成的条形函数。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) 类：指定在表达式上方或下方的分组符号，通常用于突出元素之间的关系。
  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)


## **数学运算**
每个数学元素和数学表达式（通过 [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)）实现 [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 接口。它允许您对现有结构进行操作并形成更复杂的数学表达式。所有操作都有两个参数集：要么是 [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)，要么是字符串作为参数。当使用字符串参数时，**MathematicalText** 类的实例会从指定的字符串隐式创建。Aspose.Slides 中可用的数学操作列举如下。
### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

连接数学元素并形成数学块。例如：

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide 方法**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

使用这个分子和指定的分母创建指定类型的分数。例如：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

用指定的字符（例如括号或其他字符）将元素封闭以进行框架。

```java
/**
 * <p>
 * 将数学元素封闭在括号中
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * 用指定的字符（例如括号或其他字符）封闭此元素
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


例如：

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function 方法**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

使用当前对象作为函数名称的参数。

```java
/**
 * <p>
 * 使用此实例作为函数名称取得一个参数的函数
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * 使用此实例作为函数名称取得一个参数的函数
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


例如：

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction 方法**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

使用当前实例作为参数取得指定的函数。您可以：

- 指定一个字符串作为函数名称，例如“cos”。
- 选择预定义的枚举值之一 [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) 或 [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)，例如 [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin)。
- 选择 [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 的实例。

例如：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

设置下标和上标。您可以同时在参数的左侧或右侧设置下标和上标，但单个下标或上标仅在右侧支持。**上标** 还可用于设置数字的数学指数。

示例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定给定度数的根号来自指定的参数。

示例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

获取上限或下限。这里，上限和下限简单表明参数相对于基数的位置。

考虑表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

这样的表达式可以通过 [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) 和 [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) 类的组合，以及 [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) 的操作创建如下：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 和 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 和 **integral** 方法均创建并返回由 [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator) 类型表示的 N 叉操作符。在 nary 方法中， [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) 枚举指定操作符的类型：求和、并集等，但不包括积分。而在 Integral 方法中，专门化操作积分包含 [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes) 的枚举。

示例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) 将元素放入垂直数组。如果该操作被调用于 [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) 实例，所有子元素将被放入返回的数组中。

示例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) 方法设置一个重音标记（一个顶部的元素上的字符）。
- [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) 和 [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) 方法在顶部或底部设置一个条形。
- [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) 方法使用分组字符（如底部大括号或其他）分组。
- [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) 方法放入边框框中。
- [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) 方法放入一个非视觉框（逻辑分组）。

示例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 
