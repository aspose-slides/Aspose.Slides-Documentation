---
title: 添加数学公式到 PowerPoint 演示文稿（Java）
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/java/powerpoint-math-equations/
keywords:
- 数学等式
- 数学符号
- 数学公式
- 数学文本
- 添加数学等式
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 Java 示例代码。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中提供了各种数学符号，可将其添加到文本或公式中。PowerPoint 使用数学公式构造器来帮助创建诸如以下的复杂公式：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert → Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建可在 PowerPoint 中显示的数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建公式。然而，在 PowerPoint 中创建复杂的数学公式往往难以获得专业的外观。需要频繁制作数学演示文稿的用户，通常会求助第三方解决方案来创建美观的公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像的功能也部分受支持。

## **如何创建数学公式**
数学元素用于构建任意层次嵌套的数学结构。线性集合的数学元素形成由[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)是用于保存数学文本的数学段（请勿与[**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)混淆）。[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph)用于操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建下列数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将容纳数学文本的形状：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

创建后，形状默认已包含一个带有数学段的段落。[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)类表示包含数学文本的段。要访问[**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion)中的数学内容，请引用[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph)变量：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph)类允许读取、添加、编辑和删除由数学元素组合而成的数学块（[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)）。例如，创建一个分数并将其放入演示文稿：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

每个数学元素都由实现[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口的类表示。该接口提供大量方法，可轻松创建数学表达式。只需一行代码即可构建相当复杂的表达式。例如，勾股定理可以这样写：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口的操作在任何元素类型中都已实现，包括[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)。

完整源码示例：

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
数学表达式由一系列数学元素组成。数学元素序列由数学块表示，数学元素的参数形成树状嵌套。

有许多数学元素类型可用于构建数学块。每个元素都可以被包含（聚合）到另一个元素中。也就是说，元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素类型实现[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口，从而可以在不同类型的数学元素上使用统一的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText)类表示数学文本——所有数学构造的基础元素。数学文本可表示操作数、运算符、变量以及任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction)类指定分数对象，由分子和分母组成，之间有分数线。分数线可以是水平的或对角的，取决于分数属性。该对象也用于表示堆叠函数，即一个元素位于另一个元素之上且没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical)类指定根函数（数学根），由基底和可选的指数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction)类指定一个带参数的函数。包含属性：`getName`——函数名称以及`getBase`——函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator)类指定 N 元数学对象，例如求和或积分。它由运算符、基底（或操作数）以及可选的上、下限组成。N 元运算的示例包括求和、并集、交集、积分。

该类不包括加法、减法等简单运算符，这些由单一文本元素[MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText)表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit)类用于创建上限或下限。它由基线文本和紧挨其上的（或下方）缩小文本组成。该元素本身不包含 “lim” 字样，但可用于在表达式顶部或底部放置文本。例如，以下表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

可以通过组合[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction)和[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit)元素实现：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

上述类用于指定下标或上标。可以在左侧或右侧同时设置下标和上标，但仅在右侧支持单独的下标或上标。[MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)也可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix)类指定矩阵对象，由子元素按行列布局组成。需要注意的是矩阵本身没有内置分隔符。若要在括号中放置矩阵，需要使用分隔符对象——[**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter)。可以使用空参数在矩阵中创建空格。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray)类指定垂直排列的方程或任意数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox)类：在[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox)类：指定数学元素的逻辑盒装。例如，可将盒装对象用作运算符模拟器，带或不带对齐点，或用作换行点，亦可将其分组以防止在内部换行。例如，"==" 运算符应盒装以防止换行。

- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter)类：指定分隔符对象，由左、右字符（如圆括号、花括号、方括号、竖线）以及内部一个或多个数学元素组成，元素之间可使用指定字符分隔。示例：(𝑥²); [𝑥²|𝑦²]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent)类：指定重音函数，由基底和组合变音符组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar)类：指定横杠函数，由基底参数和上横线或下横线组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter)类：指定用于在表达式上方或下方标记分组的符号，通常用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)）实现了[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口。该接口允许对现有结构执行操作，以形成更复杂的数学表达式。所有操作都有两套参数：可以是[**IMathElement**]或字符串。当使用字符串参数时，会隐式创建[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText)实例。以下列出 Aspose.Slides 支持的数学操作。

### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

将数学元素连接并形成数学块。例如：

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

使用给定分子和指定分母创建指定类型的分数。例如：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

用指定字符（如括号或其他字符）将元素括起来。

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

示例：

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function 方法**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

使用当前对象作为函数名称，创建带参数的函数。

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

示例：

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction 方法**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

使用当前实例作为参数，调用指定函数。您可以：

- 使用字符串作为函数名，例如 “cos”。
- 选择[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument)或[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments)枚举值，例如[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument).ArcSin。
- 传入[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)实例。

示例：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

设置下标和上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 还能用于设置数字的数学指数。

示例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定给定指数的数学根。

示例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

设置上限或下限。上限和下限仅表示参数相对于基底的位置。

例如表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

此类表达式可通过组合[MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction)和[MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit)以及[IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)的操作创建：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 与 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 与 **integral** 方法均返回表示 N 元运算符的[**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator)类型。**nary** 方法的 [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) 枚举指定运算符类型（求和、并集等），不包括积分。**integral** 方法则使用 [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes) 枚举表示积分类型。

示例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) 将元素放入垂直数组中。如果对[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)实例调用此操作，所有子元素将被放入返回的数组。

示例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) 方法为元素添加重音符（位于元素顶部的字符）。
- [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) 与 [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) 方法分别在元素上方或下方添加横线。
- [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) 方法使用分组字符（如底部大括号等）将元素分组。
- [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) 方法将元素放入边框盒。
- [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) 方法将元素放入非可视的逻辑盒。

示例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**如何在 PowerPoint 幻灯片中添加数学公式？**

要添加数学公式，需要创建一个自动包含数学段的数学形状对象。然后，从[MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/)获取[MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)，并向其添加[MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)对象。

**是否可以创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 通过嵌套 MathBlocks 支持创建复杂的数学表达式。每个数学元素实现了[IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/)接口，可使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过[MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)访问已有的 MathBlocks。然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。