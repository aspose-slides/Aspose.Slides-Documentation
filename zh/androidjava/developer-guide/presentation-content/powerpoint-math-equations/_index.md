---
title: 在 Android 上为 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 Java 代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中提供了各种数学符号，可将它们添加到文本或公式中。PowerPoint 使用数学方程构造器来创建诸如以下的复杂公式：

- Math Fraction
- Math Radical
- Math Function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

要在 PowerPoint 中添加数学公式，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建数学文本，可在 PowerPoint 中如下显示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建公式。但在 PowerPoint 中创建复杂数学公式往往难以得到美观、专业的效果。需要频繁制作数学演示文稿的用户，会转而使用第三方方案来创建美观的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。创建新的数学表达式或编辑已创建的表达式。对数学结构导出为图像也部分受支持。

## **如何创建数学公式**
数学元素用于构建任意层次嵌套的数学结构。线性的数学元素集合形成一个由[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)类表示的数学块。[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)本质上是一个独立的数学表达式、公式或方程。[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)是用于保存数学文本的数学片段（请勿与[**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)混淆）。[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建下图所示的数学公式：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个包含数学文本的形状：

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

创建后，形状默认已包含一个带有数学片段的段落。`[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)`类表示包含数学文本的片段。要访问 `[**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)` 中的数学内容，请获取 `[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)`：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

`[**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)`类允许读取、添加、编辑和删除由多个数学元素组合而成的数学块（`[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)`）。例如，创建一个分数并放入演示文稿：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

每个数学元素都由实现 `[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)` 接口的类表示。该接口提供了大量方法，可轻松创建数学表达式。使用一行代码即可创建相当复杂的表达式。例如，勾股定理可以这样写：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

`[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)` 接口的操作在任何元素类型中实现，包括 `[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)`。

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
数学表达式由一系列数学元素组成。元素序列由数学块表示，元素的参数形成树状嵌套。

可以使用许多数学元素类型来构建数学块。每个元素都可以被包含在另一个元素中，即元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现`[**IMathElement** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)`接口，从而可以对不同类型的数学元素使用统一的数学操作集。

### **MathematicalText 类**
`[**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)`类表示数学文本——所有数学结构的基础元素。数学文本可以表示操作数、运算符、变量以及任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
`[**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction)`类指定分数对象，由分子和分母组成，之间有分数线。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，即一个元素位于另一个元素上方且没有分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
`[**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical)`类指定根号函数，由基数和可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
`[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)`类指定带参数的函数。包含属性：`[getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--)`‑函数名和`[getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--)`‑函数参数。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
`[**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator)`类指定 N 元数学对象，例如求和和积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算符示例包括求和、并集、交集、积分等。

该类不包括加、减等简单运算符，后者由单一文本元素`[MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)`表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
`[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)`类用于创建上限或下限。它由基线文本和位于其上方或下方的缩小文本组成。此元素本身不包含“lim”字样，但可以在表达式的顶部或底部放置文本。因此，下面的表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合`[**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)`和`[**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)`元素实现的：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- `[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)`
- `[MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)`
- `[MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)`
- `[MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)`

这些类用于指定下标或上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。`[MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)`还可用于设置数字的数学指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
`[**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix)`类指定矩阵对象，由子元素按行列布局组成。需要注意的是矩阵本身不带内置分界符。若要将矩阵放入括号，需要使用分界符对象`[**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter)`。可使用空参数在矩阵中创建空位。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
`[**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray)`类指定垂直排列的方程或其他数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- `[**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox)` 类：在 `[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)` 周围绘制矩形或其他边框。  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- `[**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox)` 类：指定数学元素的逻辑盒包装。例如，盒装对象可用作带或不带对齐点的运算符模拟器，或用作行断点，或用于防止行内换行等。比如，`==` 运算符应盒装以防止换行。

- `[**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter)` 类：指定分界符对象，由左、右字符（如括号、花括号、方括号、竖线）以及内部的一个或多个数学元素组成，元素之间可用指定字符分隔。示例：(𝑥2); [𝑥2|𝑦2]。  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- `[**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent)` 类：指定重音符号，由基字符和组合变音符组成。  
  示例：𝑎́。

- `[**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar)` 类：指定上横线或下横线函数，由基参数和相应的横线组成。  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- `[**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter)` 类：指定放置在表达式上方或下方的分组符号，通常用于突出元素之间的关系。  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过`[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)`）实现`[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)`接口。该接口允许对已有结构执行操作并形成更复杂的数学表达式。所有操作有两套参数：可以是`[**IMathElement**]`或字符串。当使用字符串时，会隐式创建对应的`[**MathematicalText**]`实例。以下列出 Aspose.Slides 支持的数学操作。

### **Join 方法**
- `[join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)`
- `[join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)`

将两个数学元素合并为一个数学块。例如：

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide 方法**
- `[divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)`
- `[divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)`
- `[divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)`
- `[divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)`

根据指定类型创建分数。例如：

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- `[enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)`
- `[enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)`

使用指定字符（如括号）将元素包裹起来。

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
- `[function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)`
- `[function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)`

使用当前对象作为函数名，对参数创建函数。

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
- `[asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)`
- `[asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)`
- `[asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)`
- `[asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)`
- `[asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)`

将当前实例作为参数传递给指定函数。可以：

- 使用字符串作为函数名，例如 “cos”；
- 选择 `[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument)` 或 `[**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments)` 中的枚举值，例如 `[**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin)；
- 传入 `[**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)` 实例。

示例：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- `[setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)`
- `[setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)`
- `[setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)`
- `[setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)`
- `[setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)`
- `[setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)`
- `[setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)`
- `[setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)`

设置下标和上标。可以在左侧或右侧同时设置，但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的数学指数。

示例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- `[radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)`
- `[radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)`

指定给定参数的指定次数根。

示例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- `[setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)`
- `[setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)`
- `[setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)`
- `[setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)`

设置上限或下限。这里的上限和下限仅表示参数相对于基数的位置。

例如，下图所示的表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

可以通过组合 `[MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)` 和 `[MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)` 类以及 `[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)` 的操作实现：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 和 Integral 方法**
- `[nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)`
- `[nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)`
- `[integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)`
- `[integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)`
- `[integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)`
- `[integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)`
- `[integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)`

**nary** 与 **integral** 方法均创建并返回由 `[**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator)` 类型表示的 N 元运算符。**nary** 方法的枚举 `[MathNaryOperatorTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes)` 指定运算符类型（求和、并集等），不包括积分。**integral** 方法使用枚举 `[MathIntegralTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes)` 指定积分类型。

示例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
`[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--)` 将元素放入垂直数组中。如果对 `[**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)` 实例调用，此操作会将所有子元素放入返回的数组。

示例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- `[**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-)` 方法为元素添加重音符号（位于元素上方的字符）。
- `[**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--)` 与 `[**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--)` 方法分别在元素上方或下方添加横线。
- `[**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--)` 方法使用分组字符（如底部花括号）将元素组合在一起。
- `[**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--)` 方法将元素放入边框盒。
- `[**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--)` 方法将元素放入非可视盒（逻辑分组）。

示例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **常见问题**

**如何在 PowerPoint 幻灯片中添加数学公式？**

要添加数学公式，需要创建一个自动包含数学片段的数学形状对象。然后，从 `[MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/)` 获取 `[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)`，并向其添加 `[MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)` 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 允许通过嵌套 `MathBlock` 来创建复杂的数学表达式。每个数学元素实现 `[IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/)` 接口，可使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

要更新公式，需要通过 `[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)` 访问已有的 `MathBlock`。然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后，保存演示文稿即可应用更改。