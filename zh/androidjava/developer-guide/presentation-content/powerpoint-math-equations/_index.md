---
title: 在 Android 上向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/androidjava/powerpoint-math-equations/
keywords:
- 数学方程式
- 数学符号
- 数学公式
- 数学文本
- 添加数学方程式
- 添加数学符号
- 添加数学公式
- 添加数学文本
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用适用于 Android 的 Aspose.Slides 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 Java 代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中提供了各种数学符号，可将其添加到文本或公式中。PowerPoint 使用数学公式构造器来创建复杂的公式，例如：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中插入数学公式，请使用 *Insert → Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建数学文本，PowerPoint 会显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学公式。不过，在 PowerPoint 中创建复杂的数学公式往往难以得到美观、专业的效果。需要频繁制作数学演示文稿的用户，往往求助于第三方方案来生成好看的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像也得到部分支持。

## **如何创建数学公式**
数学元素用于构建任意层级的数学结构。线性集合的数学元素形成一个由[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)是用于保存数学文本的数学片段（不要与[**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)混用）。[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

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

创建后，形状默认已包含一个带有数学片段的段落。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)类是包含数学文本的片段。要访问[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)内部的数学内容，请获取[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)变量：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)类允许读取、添加、编辑和删除由数学元素组合而成的数学块（[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)）。例如，创建一个分数并将其放入演示文稿：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

每个数学元素均由实现[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)接口的类表示。该接口提供了大量方法，可轻松创建数学表达式。只需一行代码即可创建相当复杂的数学表达式。例如，勾股定理可以这样写：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)接口的操作在任何类型的元素中实现，包括[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)。

完整示例代码：

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
数学表达式由一系列数学元素组成。该序列由数学块表示，数学元素的参数形成树状嵌套。

可用于构建数学块的元素类型很多。每个元素都可以被包含（聚合）在另一个元素中。也就是说，元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素类型实现[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)接口，从而可以对不同类型的数学元素使用相同的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)类表示数学文本——所有数学构造的基础元素。数学文本可以表示操作数、运算符、变量以及任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction)类表示分数对象，由分子和分母组成，之间有分数线。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，即将一个元素置于另一个元素之上且不带分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical)类表示根号函数（数学根），由底数和可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)类表示带参数的函数。包含属性：`getName`（函数名）和`getBase`（函数参数）。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator)类表示 N 元数学对象，如求和、积分等。它由运算符、基数（或操作数）以及可选的上限和下限组成。常见的 N 元运算符包括求和、并集、交集、积分。

该类不包括加、减等简单运算符；这些由单个文本元素[MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)类用于创建上限或下限。它由基线文本和位于其上方或下方的缩小文本组成。该元素本身不包含单词 “lim”，而是通过组合[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)和[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)来实现。例如：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

上述类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)还可用于设置数字的指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix)类表示矩阵对象，由子元素按行列排列组成。需要注意的是，矩阵本身不带内置分隔符。若要在括号中显示矩阵，需要使用分隔符对象——[**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter)。可以使用空参数在矩阵中创建空格。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray)类表示垂直排列的方程或其他数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox) 类：在[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox) 类：指定数学元素的逻辑包装。比如，将对象包装后可作为带或不带对齐点的运算符仿真，或作为行断点，亦可组合以防止行内换行。例如，运算符 “==” 应该被包装以防止换行。

- [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter) 类：指定分隔符对象，由左、右界符（如括号、花括号、方括号、竖线）以及内部的一个或多个数学元素组成。示例：(𝑥²); [𝑥²|𝑦²]。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent) 类：指定重音符号，由基字符和组合变音符号组成。

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar) 类：指定上划线或下划线函数，由基参数和上/下横线组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter) 类：指定位于表达式上方或下方的分组符号，通常用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和通过[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)表示的数学表达式都实现了[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)接口。该接口允许对已有结构进行操作，形成更复杂的数学表达式。所有运算都有两套参数：可以是[**IMathElement**]或字符串。使用字符串时，会隐式创建对应的[**MathematicalText**]实例。下面列出 Aspose.Slides 支持的数学运算。

### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

将两个数学元素连接成一个数学块。例如：

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide 方法**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

使用指定分子和分母创建特定类型的分数。例如：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

用指定字符（如括号或其他字符）将元素包裹起来。

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
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

使用当前对象的名称作为函数名，创建对参数的函数。

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

使用当前实例作为函数参数来创建指定函数。您可以：

- 使用字符串作为函数名，例如 “cos”；
- 选择枚举值[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument)或[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments)，如[**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin)；
- 传入[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)实例。

示例：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

设置下标和上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 还可用于设置数字的指数。

示例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

指定给定参数的指定指数的数学根。

示例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

设置上限或下限。这里的上限和下限仅表示参数相对于基线的位置。

例如下面的表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

可以通过组合[MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)和[MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)类以及[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)的操作来创建：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 和 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 和 **integral** 方法均返回由[**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator)类型表示的 N 元运算符。**nary** 方法使用[**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes)枚举指定运算符类型（例如求和、并集），不包括积分。**integral** 方法则针对积分，使用[**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes)枚举指定积分类型。

示例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) 将元素放入垂直数组中。如果对[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)实例调用，则所有子元素都会被放入返回的数组。

示例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **accent** 方法设置重音符号（元素上方的字符）。
- **overbar** 与 **underbar** 方法分别在元素上方或下方添加横线。
- **group** 方法使用分组字符（如底部花括号等）将元素组合在一起。
- **toBorderBox** 方法将元素放入带边框的盒子中。
- **toBox** 方法将元素放入非可视盒子（逻辑分组）中。

示例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **常见问题**

**如何向 PowerPoint 幻灯片添加数学公式？**

要添加数学公式，需要创建一个数学形状对象，该对象会自动包含一个数学片段。随后，从[MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)获取[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)，并向其添加[MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)对象。

**是否可以创建复杂的嵌套数学表达式？**

可以，Aspose.Slides 通过嵌套 MathBlocks 支持创建复杂的数学表达式。每个数学元素实现了[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/)接口，您可以使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)访问已有的 MathBlocks。随后，使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。