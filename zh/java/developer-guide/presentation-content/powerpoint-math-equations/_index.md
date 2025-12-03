---
title: 添加数学公式到 PowerPoint 演示文稿（Java）
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，使用 Aspose.Slides for Java，支持 OMML、格式控制，并提供清晰的 Java 代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学公式或方程并在演示文稿中显示。为此，PowerPoint 中表示了各种数学符号，可将其添加到文本或公式中。PowerPoint 使用数学公式构造器来创建诸如：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学公式，请使用 *Insert → Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将创建以 XML 形式的数学文本，可在 PowerPoint 中显示为：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号来创建数学公式。然而，在 PowerPoint 中创建复杂的数学公式往往难以得到美观且专业的效果。需要频繁制作数学演示文稿的用户，通常会求助于第三方解决方案来生成好看的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学公式。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像的功能也部分支持。

## **如何创建数学公式**
数学元素用于构建任意层级嵌套的数学结构。线性集合的数学元素形成由[**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)类表示的数学块。**MathBlock** 类本质上是一个独立的数学表达式、公式或方程。**MathPortion** 是用于保存数学文本的数学部分（请勿与[**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)混淆）。**MathParagraph** 允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学公式的关键。

下面演示如何使用 Aspose.Slides API 创建以下数学公式：

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

创建后，该形状默认已包含一个段落，其中含有一个数学部分。**MathPortion** 类是包含数学文本的部分。要访问 **MathPortion** 中的数学内容，请引用 **MathParagraph** 变量：

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

**MathParagraph** 类允许读取、添加、编辑和删除由多个数学元素组合而成的数学块（**MathBlock**）。例如，创建一个分数并放入演示文稿：

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

每个数学元素都有对应的类实现了[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口。该接口提供了大量方法，可轻松创建数学表达式。您可以仅用一行代码创建相当复杂的表达式。例如，勾股定理可以这样写：

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

**IMathElement** 接口的操作在所有元素类型中均可使用，包括 **MathBlock**。

完整代码示例：

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
数学表达式由一系列数学元素组成。数学元素的序列由数学块表示，数学元素的参数形成树形嵌套。

可以使用多种数学元素类型来构建数学块。每个元素都可以包含在另一个元素中，即元素本身是容器，形成树形结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现了[**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement)接口，允许对不同类型的数学元素使用通用的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) 类表示数学文本——所有数学构造的基础元素。数学文本可表示操作数、运算符、变量以及任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) 类表示分数对象，由分子和分母组成，之间由分数线分隔。分数线可以是水平或对角线，取决于属性。该对象也可用于表示堆叠函数，即将一个元素放在另一个元素上方且不带分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) 类表示根号函数，由基数和可选的指数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) 类表示带参数的函数。包含属性：`getName`（函数名）和 `getBase`（函数参数）。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) 类表示 N 元数学对象，例如求和和积分。它由运算符、基数（或操作数）以及可选的上、下限组成。示例包括求和、并集、交集、积分。

该类不包含加、减等简单运算符，后者由单一文本元素 **MathematicalText** 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) 类创建上限或下限。它由基线文本和位于其上方或下方的缩小文本组成。该元素本身不包含 “lim” 关键字，但可用于在表达式的顶部或底部放置文本。例如：

![todo:image_alt_text](powerpoint-math-equations_8.png)

通过组合 **MathFunction** 和 **MathLimit** 可以这样创建：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

这些类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**MathSubscriptElement** 还可用于设置数字的数学次数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) 类表示矩阵对象，由若干子元素按行列布局构成。矩阵本身不带内置定界符。若需在括号中显示矩阵，应使用 **IMathDelimiter** 对象。使用空参数可在矩阵中创建间隙。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) 类表示垂直排列的方程或其他数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **格式化数学元素**
- **MathBorderBox** 类：在 **IMathElement** 周围绘制矩形或其他边框。

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** 类：指定数学元素的逻辑包装。可用于防止换行、作为运算符仿真等。

- **MathDelimiter** 类：指定定界符对象，由左、右字符（如括号、花括号、方括号、竖线）以及内部的一个或多个数学元素组成，元素之间可用指定字符分隔。

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** 类：指定重音符号，由基字符和组合变音符组成。

  示例：𝑎́。

- **MathBar** 类：指定上划线或下划线，由基元素和相应的条线组成。

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** 类：指定表达式上下的分组符号，通常用于突出元素之间的关系。

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和数学表达式（通过 **MathBlock**）实现 **IMathElement** 接口。该接口允许对已有结构进行操作，形成更复杂的数学表达式。所有操作支持两种参数形式：**IMathElement** 或字符串。使用字符串时，会隐式创建 **MathematicalText** 实例。以下列出 Aspose.Slides 中可用的数学操作。

### **Join 方法**
- `join(String)`
- `join(IMathElement)`

将两个数学元素连接成一个数学块。例如：

```java
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");
IMathBlock block = element1.join(element2);
``` 

### **Divide 方法**
- `divide(String)`
- `divide(IMathElement)`
- `divide(String, MathFractionTypes)`
- `divide(IMathElement, MathFractionTypes)`

根据指定分子和分母创建相应类型的分数。例如：

```java
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- `enclose()`
- `enclose(Char, Char)`

用指定字符（如括号）将元素包裹起来。

```java
public IMathDelimiter enclose();
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

示例：

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function 方法**
- `function(String)`
- `function(IMathElement)`

将当前对象作为函数名，对参数创建函数。

```java
public IMathFunction function(IMathElement functionArgument);
public IMathFunction function(String functionArgument);
``` 

示例：

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction 方法**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(IMathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

将当前实例作为函数参数，可指定函数名字符串、预定义枚举或 **IMathElement** 实例。

示例：

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);
IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");
IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- `setSubscript(String)`
- `setSubscript(IMathElement)`
- `setSuperscript(String)`
- `setSuperscript(IMathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(IMathElement, IMathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(IMathElement, IMathElement)`

设置下标和上标。可在左侧或右侧同时设置，但单独的下标或上标仅在右侧受支持。**Superscript** 还可用于设置数字的数学次数。

示例：

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- `radical(String)`
- `radical(IMathElement)`

为指定参数设置指定次数的根号。

示例：

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 和 SetLowerLimit 方法**
- `setUpperLimit(String)`
- `setUpperLimit(IMathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(IMathElement)`

设置上限或下限，表示基元素相对于基线的位置。

示例表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

通过组合 **MathFunction** 和 **MathLimit** 可以这样实现：

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 和 Integral 方法**
- `nary(MathNaryOperatorTypes, IMathElement, IMathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, IMathElement, IMathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

这两个方法均返回 **IMathNaryOperator** 类型的 N 元运算符。`nary` 使用 **MathNaryOperatorTypes** 枚举指定运算符类型（如求和、并集），不包括积分；`integral` 使用 **MathIntegralTypes** 枚举指定积分类型。

示例：

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
`toMathArray` 将元素放入垂直数组。如果对 **MathBlock** 实例调用，所有子元素将被放入返回的数组中。

示例：

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- `accent`：设置重音符号（元素上方的字符）。
- `overbar`、`underbar`：在元素上方或下方添加横线。
- `group`：使用分组字符（如下方的大括号）将元素分组。
- `toBorderBox`：将元素放入带边框的盒子。
- `toBox`：将元素放入非可视的逻辑盒子。

示例：

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');
IMathBar bar = new MathematicalText("x").overbar();
IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();
IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **常见问题解答**

**如何将数学公式添加到 PowerPoint 幻灯片中？**

需创建一个数学形状对象，该对象会自动包含一个数学部分。然后，从 **MathPortion** 中获取 **MathParagraph**，并向其中添加 **MathBlock** 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 通过嵌套 **MathBlock** 支持创建复杂的数学表达式。每个数学元素实现 **IMathElement** 接口，可使用 Join、Divide、Enclose 等操作将元素组合成更复杂的结构。

**如何更新或修改已有的数学公式？**

通过 **MathParagraph** 访问现有的 **MathBlock**，然后使用 Join、Divide、Enclose 等方法修改公式的各个元素。编辑完成后保存演示文稿即可生效。