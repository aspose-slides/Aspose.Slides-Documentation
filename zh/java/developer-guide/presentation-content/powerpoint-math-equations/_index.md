---
title: 在 Java 中向 PowerPoint 演示文稿添加数学方程式
linktitle: PowerPoint 数学方程式
type: docs
weight: 80
url: /zh/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学方程式，支持 OMML、格式控制，并提供清晰的 Java 示例代码。"
---
## **概述**

PowerPoint 将方程式存储为 Office Math 标记语言 (OMML)。使用 Aspose.Slides for Java，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 进制运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **Insert > Equation** 添加方程式：

![PowerPoint Insert 选项卡中选中的 Equation 命令](powerpoint-math-equations_1.png)

结果是在幻灯片上出现可编辑的数学文本：

![包含可编辑数学方程式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 使用 [addMathShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) 创建的数学形状，用于容纳方程式。
- [MathPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathportion/) 在形状的文本框中存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathematicaltext/) 和来自 [IMathElement](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/) 的流式方法，以保持代码简洁易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in Java](/slides/zh/java/exporting-math-equations/)。

## **创建方程式**

本示例创建一个数学形状并添加勾股定理：

![方程式 c² = a² + b² 的示意图](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}

`addMathShape` 创建的形状已经包含一个数学段落。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其中添加数学块或数学元素。

{{% /alert %}}

## **添加分数**

使用 `divide` 创建分数。可以通过 [MathFractionTypes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathfractiontypes/) 选择分数样式。

![一个倾斜的数学分数，显示 1 除以 x](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于堆叠分数，使用 `MathFractionTypes.Bar`：

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **添加根式**

使用 `radical` 创建平方根、立方根或其他根式。当前元素成为根式的底数，参数成为指数。

![一个 n 次根式，x 位于根号下方的示意图](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加函数和极限**

使用 `asArgumentOfFunction` 或 `function` 添加诸如 `sin(x)`、`log(x)` 或自定义函数名的函数。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathlimit/) 或使用 `setLowerLimit`。

![当 x 趋于无穷大时的极限示意图](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若使用自定义函数名，只需将函数名设为当前元素：

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **添加 N 进制运算符和积分**

使用 `nary` 添加求和、并集、交集等大型运算符。使用 `integral` 添加积分。这两种方法都可以设置上下限。

![带上下限的求和示意图](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N 进制运算符用于带可选上下限的大型运算符。像 `+`、`-`、`=` 这样的简单运算符通常通过 `MathematicalText` 添加并直接拼接到表达式中。

对于积分，使用 `integral`：

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathmatrix/) 定义行和列。矩阵默认不包含括号，如需括号、方括号或大括号，请自行在矩阵外围添加。

![一个包含空单元格的两行矩阵示意图](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加方程数组**

当需要对齐的方程式或垂直堆叠的表达式时，使用 `toMathArray`。

![垂直排列的数学数组，x 位于 y 之上](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 `asArgumentOfFunction`。

![三角函数 cos 作用于 2x 的示意图](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加下标和上标**

使用下标和上标助手添加索引和幂。当索引必须出现在基准的左侧时，使用 `setSubSuperscriptOnTheLeft`。

![带左侧下标 1 和上标 n 的大写字母 Y 示例](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加分界符**

使用 `enclose` 将表达式放入分界符中。对于包含多个元素的分界符表达式，还可以设置分隔符字符。

![包含 x、y、z 并以竖线分隔的分界符表达式示意图](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加边框框**

使用 `toBorderBox` 为整个方程式添加边框。

![带有框线的方程式，显示 a² = b² + c² 的示意图](powerpoint-math-equations_12.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **分组项**

使用 `group` 在表达式上方或下方放置分组字符。添加限制可为分组项添加标签。

![表达式 x + y 被分组，并在下方标注任意文本的示意图](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化数学元素**

仅在能提升公式可读性的地方使用格式化助手。例如，`overbar` 在数学元素上方添加一条横线。

![带上划线的数学表达式 ABC 示例图](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathematicaltext/) |
| 合并元素 | [IMathElement.join](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| 创建分数 | [IMathElement.divide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| 添加上标或下标 | [setSuperscript](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| 添加函数 | [function](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| 添加根式 | [IMathElement.radical](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| 添加极限 | [setLowerLimit](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| 添加左侧脚本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mathmatrix/) |
| 添加方程数组 | [toMathArray](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#toMathArray--) |
| 添加分界符 | [enclose](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#toBorderBox--) |
| 分组项 | [group](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **常见问题**

**我可以编辑已有的 PowerPoint 方程式吗？**

可以。打开演示文稿，定位包含 `MathPortion` 的形状，获取其 `MathParagraph`，然后更新该段落中的数学块。

**方程式会以可编辑的 PowerPoint 数学格式保存吗？**

会。保存为 PPTX 时，Aspose.Slides 会将方程式写入可编辑的 Office 数学内容。

**我可以将方程式导出为 LaTeX 吗？**

可以。先从对应的 [IMathPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathportion/) 获取其 [IMathParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathparagraph/)，然后调用 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imathparagraph/#toLatex--) 直接导出。完整示例请参阅 [Export Math Equations from Presentations in Java](/slides/zh/java/exporting-math-equations/#export-math-equations-to-latex)。