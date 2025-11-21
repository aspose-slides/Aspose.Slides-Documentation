---
title: PowerPoint 数学方程
type: docs
weight: 80
url: /zh/nodejs-java/powerpoint-math-equations/
keywords: " PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
description: "PowerPoint 数学方程, PowerPoint 数学符号, PowerPoint 公式, PowerPoint 数学文本"
---

## **概述**
在 PowerPoint 中，可以编写数学方程或公式并在演示文稿中显示。为此，PowerPoint 中表示了各种数学符号，可以将它们添加到文本或方程中。PowerPoint 使用数学方程构造器来帮助创建诸如以下的复杂公式：

- 数学分数
- 数学根式
- 数学函数
- 极限和对数函数
- N 元运算
- 矩阵
- 大型运算符
- 正弦、余弦函数

要在 PowerPoint 中添加数学方程，请使用 *Insert -> Equation* 菜单：

![todo:image_alt_text](powerpoint-math-equations_1.png)

这将创建一个以 XML 表示的数学文本，在 PowerPoint 中显示如下：

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint 支持大量数学符号以创建数学方程。然而，在 PowerPoint 中创建复杂数学方程往往难以得到美观、专业的效果。需要频繁制作数学演示文稿的用户，往往会求助于第三方解决方案来生成美观的数学公式。

使用[**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/)，您可以在 C# 中以编程方式处理 PowerPoint 演示文稿中的数学方程。可以创建新的数学表达式或编辑已有的表达式。对数学结构导出为图像也得到了一定程度的支持。

## **如何创建数学方程**
数学元素用于构建任意层次嵌套的数学结构。线性的数学元素集合形成由[**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)类表示的数学块。**MathBlock** 类本质上是一个独立的数学表达式、公式或方程。**MathPortion** 是用于保存数学文本的数学片段（请勿与[**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)混淆）。**MathParagraph** 允许操作一组数学块。上述类是通过 Aspose.Slides API 操作 PowerPoint 数学方程的关键。

下面演示如何使用 Aspose.Slides API 创建如下数学方程：

![todo:image_alt_text](powerpoint-math-equations_3.png)

要在幻灯片上添加数学表达式，首先添加一个将容纳数学文本的形状：

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

创建后，形状默认已包含一个带有数学片段的段落。**MathPortion** 类是包含数学文本的片段。要访问 **MathPortion** 中的数学内容，请参考 **MathParagraph** 变量：

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

**MathParagraph** 类允许读取、添加、编辑和删除由多个数学元素组合而成的数学块（**MathBlock**）。例如，创建一个分数并将其放入演示文稿：

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

每个数学元素都由实现 **MathElement** 类的某个类表示。该类提供了大量方法，可轻松创建数学表达式。仅用一行代码即可创建相当复杂的数学表达式。例如，勾股定理可以这样写：

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

**MathElement** 类的操作在任何类型的元素中实现，包括 **MathBlock**。

完整示例代码：

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
数学表达式由一系列数学元素组成。数学元素序列由数学块表示，数学元素的参数形成树形嵌套。

可以使用大量数学元素类型来构造数学块。每个元素都可以包含在另一个元素中，即元素本身是容器，形成树形结构。最简单的元素类型不包含其他数学文本元素。

每种数学元素类型实现 **MathElement** 类，允许对不同类型的数学元素使用通用的数学操作集合。

### **MathematicalText 类**
[**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) 类表示数学文本——所有数学构造的基础元素。数学文本可以表示操作数、运算符、变量以及任何其他线性文本。

示例：𝑎=𝑏+𝑐

### **MathFraction 类**
[**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) 类表示分数对象，由分子和分母组成，之间以分数线分隔。分数线可以是水平或对角线，取决于分数属性。该对象也用于表示堆叠函数，即一个元素位于另一个元素之上且无分数线。

示例：

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical 类**
[**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) 类表示根式函数，由基数和可选的指数组成。

示例：

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction 类**
[**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) 类表示具有参数的函数。包含属性：`getName`（函数名）和 `getBase`（函数参数）。

示例：

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator 类**
[**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) 类表示 N 元数学对象，如求和和积分。它由运算符、基数（或操作数）以及可选的上、下限组成。N 元运算符的示例包括求和、并集、交集、积分。

该类不包含加法、减法等简单运算符，这些运算符由单一文本元素 **MathematicalText** 表示。

示例：

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit 类**
[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) 类用于创建上限或下限。它由基线文本和位于其上方或下方的缩小文本组成。该元素本身不包含“lim”文字，但可用于在表达式的顶部或底部放置文本。例如，下面的表达式

![todo:image_alt_text](powerpoint-math-equations_8.png)

是通过组合 [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) 和 [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) 元素实现的：

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **MathSubscriptElement、MathSuperscriptElement、MathRightSubSuperscriptElement、MathLeftSubSuperscriptElement 类**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

这些类用于指定下标或上标。可以在参数的左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**MathSubscriptElement** 还可用于设置数字的指数。

示例：

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix 类**
[**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) 类表示矩阵对象，由子元素按行列布局。需要注意的是，矩阵本身没有内置的分隔符。如需在括号中显示矩阵，请使用分隔符对象 **MathDelimiter**。可以使用空参数在矩阵中创建空白。

示例：

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray 类**
[**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) 类表示垂直排列的方程或任意数学对象数组。

示例：

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **数学元素的格式化**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox) 类：在 **MathElement** 周围绘制矩形或其他边框。  

  示例：![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox) 类：指定数学元素的逻辑盒装（封装），用于防止换行或作为运算符模拟等。

- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter) 类：指定分隔符对象，由左、右界定符以及内部一个或多个数学元素组成，可使用指定字符分隔。示例：(𝑥²); [𝑥²|𝑦²]。  

  示例：![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent) 类：指定重音符号，由基字符和组合变音符号组成。  

  示例：𝑎́。

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar) 类：指定上横线或下横线，由基对象和横线组成。  

  示例：![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter) 类：在表达式上方或下方放置分组符号，通常用于突出元素之间的关系。  

  示例：![todo:image_alt_text](powerpoint-math-equations_15.png)

## **数学运算**
每个数学元素和通过 **MathBlock** 表示的数学表达式都实现了 **MathElement** 类。该类允许在已有结构上执行操作，以形成更复杂的数学表达式。所有操作都有两套参数：可以是 **MathElement** 或字符串。使用字符串时，会隐式创建 **MathematicalText** 实例。以下列出 Aspose.Slides 提供的数学操作。

### **Join 方法**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

将数学元素连接成数学块。例如：

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide 方法**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

创建指定类型的分数。例如：

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose 方法**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

用指定字符（如括号）将元素框住。

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
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

使用当前对象作为函数名，创建带参数的函数。

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

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction 方法**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

将当前实例作为参数，传入指定函数。可以：

- 使用字符串指定函数名，例如 “cos”。
- 选择枚举 **MathFunctionsOfOneArgument** 或 **MathFunctionsOfTwoArguments** 中的预定义值，例如 **MathFunctionsOfOneArgument**.ArcSin。
- 直接使用 **MathElement** 实例。

示例：

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript、SetSuperscript、SetSubSuperscriptOnTheRight、SetSubSuperscriptOnTheLeft 方法**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

设置下标和上标。可以在左侧或右侧同时设置下标和上标，但单独的下标或上标仅在右侧受支持。**Superscript** 也可用于设置数字的指数。

示例：

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical 方法**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

指定给定参数的指定次数方根。

示例：

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit 与 SetLowerLimit 方法**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

设置上限或下限。这里的上、下仅表示参数相对于基数的位置。

考虑下面的表达式：

![todo:image_alt_text](powerpoint-math-equations_8.png)

该表达式可通过组合 **MathFunction** 与 **MathLimit** 类以及 **MathElement** 的操作实现：

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary 与 Integral 方法**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

**nary** 与 **integral** 方法均创建并返回 **MathNaryOperator** 类型的 N 元运算符。**nary** 方法使用 **MathNaryOperatorTypes** 枚举指定运算符类型（求和、并集等），不包括积分。**integral** 方法使用 **MathIntegralTypes** 枚举指定积分类型。

示例：

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray 方法**
[**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) 将元素置于垂直数组中。若对 **MathBlock** 实例调用此操作，所有子元素将被放入返回的数组。

示例：

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **格式化操作：Accent、Overbar、Underbar、Group、ToBorderBox、ToBox**
- **accent** 方法在元素顶部设置重音符号。  
- **overbar** 与 **underbar** 方法在元素上方或下方添加横线。  
- **group** 方法使用分组字符（如底部大括号等）将元素组合在一起。  
- **toBorderBox** 方法将元素放入带边框的盒子。  
- **toBox** 方法将元素放入非可视的逻辑盒子。

示例：

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **常见问题**

**如何在 PowerPoint 幻灯片中添加数学方程？**

要添加数学方程，需要创建 `MathShape` 对象，系统会自动包含一个数学片段。随后从 `MathPortion` 获取 `MathParagraph`，并向其添加 `MathBlock` 对象。

**是否可以创建复杂的嵌套数学表达式？**

可以。Aspose.Slides 允许通过嵌套 MathBlocks 创建复杂的数学表达式。每个数学元素实现 `IMathElement` 接口，可使用 Join、Divide、Enclose 等方法将元素组合成更复杂的结构。

**如何更新或修改已有的数学方程？**

要更新方程，需要通过 `MathParagraph` 访问已有的 MathBlocks。随后使用 Join、Divide、Enclose 等方法修改方程的各个元素。编辑完成后，保存演示文稿即可生效。