---
title: 在 JavaScript 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的代码示例。"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中使用了各种数学符号，用户可以将其添加到文本或方程中。PowerPoint 使用数学方程构造器来帮助创建诸如以下复杂公式：

- 数学分数
- 数学根号
- 数学函数
- 极限和对数函数
- 多元运算
- 矩阵
- 大运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将在 XML 中创建可在 PowerPoint 中显示的数学文本，如下所示：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学方程。然而，在 PowerPoint 中创建复杂数学方程往往难以获得专业外观。需要频繁制作数学演示文稿的用户，会求助第三方解决方案来创建美观的数学公式。

使用 [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学方程。可以创建新的数学表达式或编辑先前创建的表达式。对数学结构导出为图像的功能也得到部分支持。

## **如何创建数学方程**
数学元素用于构建任意层次嵌套的数学结构。线性集合的数学元素形成由 [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) 类表示的数学块。**MathBlock** 类本质上是一个独立的数学表达式、公式或方程。**MathPortion** 用于保存数学文本（不要与 [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 混淆）。**MathParagraph** 允许操作一组数学块。上述类是通过 Aspose.Slides API 在 PowerPoint 中处理数学方程的关键。

下面演示如何通过 Aspose.Slides API 创建如下数学方程：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个形状来容纳数学文本：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

创建后，形状默认已包含一个段落和一个数学文本段。**MathPortion** 类表示包含数学文本的段落。要访问 **MathPortion** 中的数学内容，请引用 **MathParagraph** 变量：

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

**MathParagraph** 类允许读取、添加、编辑和删除由多个数学元素组合而成的 **MathBlock**。例如，创建一个分数并将其放入演示文稿：

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

每个数学元素都由实现 **MathElement** 类的某个类表示。该类提供大量方法，可轻松创建数学表达式。只需一行代码即可创建相当复杂的表达式。例如，勾股定理可以这样写：

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

**MathElement** 的操作在任何类型的元素中实现，包括 **MathBlock**。

完整代码示例：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **数学元素类型**
数学表达式由数学元素序列构成。元素序列由数学块表示，元素的参数形成树状嵌套。

有大量数学元素类型可用于构建数学块。每个元素都可以包含在另一个元素中，即元素本身是其他元素的容器，形成树状结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素实现 **MathElement** 类，允许对不同类型的数学元素使用统一的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) 类表示数学文本——所有数学结构的底层元素。数学文本可表示操作数、运算符、变量以及任何线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) 类指定分数对象，由分子和分母组成，之间用分数线分隔。分数线可水平或对角，取决于属性。该对象亦可用于表示堆叠函数，即一个元素叠在另一个上方且无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) 类指定根号函数，由基数和可选的次数构成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) 类指定带参数的函数。包含属性：`getName`（函数名称）和 `getBase`（函数参数）。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) 类指定 N 元数学对象，如求和符号或积分符号。由运算符、基数（或操作数）以及可选的上、下限组成。示例包括求和、并集、交集、积分等。

该类不包括加、减等简单运算符，后者由单一文本元素 **MathematicalText** 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) 类创建上限或下限。它由基线文本以及紧贴其上（或下）的缩小文本组成。该元素本身不包含 “lim” 关键字，但可用于在表达式的顶部或底部放置文本。例如，表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

可通过 **MathFunction** 与 **MathLimit** 组合实现：

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

这些类用于指定下标或上标。可在左侧或右侧同时设置下标和上标，但单独的下标或上标仅支持在右侧。**MathSubscriptElement** 也可用于设置数字的数学次方。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) 类指定矩阵对象，由若干行列的子元素组成。需要注意，矩阵本身没有内置分隔符。若需在括号中显示矩阵，应使用 **MathDelimiter**。空参数可用于在矩阵中创建空位。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) 类指定垂直排列的方程或其他数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素的格式化**
- **MathBorderBox** 类：在 **MathElement** 周围绘制矩形或其他边框。  
  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox** 类：指定数学元素的逻辑盒装（分组），可用于防止换行或作为运算符的包装等。

- **MathDelimiter** 类：指定分隔符对象，由左右分隔字符（如括号、花括号、方括号、竖线）以及内部的一个或多个数学元素组成。示例： (𝑥²); [𝑥²|𝑦²]。  
  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent** 类：指定重音符号，由基字符和组合变音符组成。示例：𝑎́。

- **MathBar** 类：指定上横线或下横线，由基元素和相应的横线组成。  
  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter** 类：指定用于在表达式上方或下方显示的分组符号，通常用于强调元素之间的关系。  
  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和通过 **MathBlock** 组合的数学表达式都实现 **MathElement** 类。它允许在现有结构上执行操作，构建更复杂的表达式。所有操作支持两种参数形式：**MathElement** 或字符串。使用字符串时，会隐式创建相应的 **MathematicalText** 实例。以下列出 Aspose.Slides 中可用的数学操作。

### **Join 方法**
- `join(String)`
- `join(MathElement)`

将两个数学元素连接成一个数学块。例如：

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide 方法**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

使用当前对象作为分子、指定对象作为分母创建指定类型的分数。例如：

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- `enclose()`
- `enclose(Char, Char)`

将元素用指定字符（如括号）括起来。

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

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function 方法**
- `function(String)`
- `function(MathElement)`

使用当前对象作为函数名，对给定参数创建函数表达式。

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

示例：

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction 方法**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

使用当前实例作为参数调用指定函数。支持：

- 通过字符串指定函数名（如 “cos”）；
- 使用枚举 **MathFunctionsOfOneArgument** 或 **MathFunctionsOfTwoArguments** 中的预定义值；
- 直接传入 **MathElement** 实例。

示例：

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
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

设置下标和上标。可在左侧或右侧同时设置上下标，单独的下标或上标仅在右侧受支持。**Superscript** 亦可用于设置数字的数学次方。

示例：

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- `radical(String)`
- `radical(MathElement)`

指定给定次数的数学根号。

示例：

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

设置上限或下限。上、下仅表示参数相对于基数的相对位置。

考虑表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

该表达式可通过 **MathFunction** 与 **MathLimit** 组合，以及 **MathElement** 的操作实现：

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 与 Integral 方法**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

**nary** 与 **integral** 方法均返回 **MathNaryOperator** 类型的 N 元运算符。**nary** 使用 **MathNaryOperatorTypes** 枚举指定运算符类型（求和、并集等），不包括积分。**integral** 使用 **MathIntegralTypes** 枚举专门表示积分类型。

示例：

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
`toMathArray` 将元素放入垂直数组中。如果对 **MathBlock** 实例调用，所有子元素将被放入返回的数组。

示例：

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **accent**：为元素添加重音符号（位于元素上方的字符）。  
- **overbar**、**underbar**：在元素上方或下方添加横线。  
- **group**：使用分组字符（如底部大括号等）将元素组合。  
- **toBorderBox**：将元素放入带边框的盒子。  
- **toBox**：将元素放入非可视的逻辑盒子。

示例：

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **常见问题**

**如何向 PowerPoint 幻灯片添加数学方程？**

需要创建 `MathShape` 对象，它会自动包含一个数学段落。然后从 `MathPortion` 中获取 `MathParagraph`，并向其添加 `MathBlock` 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 通过嵌套 `MathBlock` 支持创建复杂的数学表达式。每个数学元素继承自 `MathElement`，可通过 Join、Divide、Enclose 等方法组合成更复杂的结构。

**如何更新或修改已有的数学方程？**

先通过 `MathParagraph` 访问已有的 `MathBlock`，然后使用 Join、Divide、Enclose 等方法对方程的各个元素进行修改。编辑完成后保存演示文稿即可生效。