---
title: 在 Android 上向 PowerPoint 演示文稿添加数学公式
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
description: "使用 Aspose.Slides for Android 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制，并提供清晰的 Java 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。使用 Aspose.Slides for Android via Java，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡，已选择“公式”命令](powerpoint-math-equations_1.png)

结果是在幻灯片上的可编辑数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 一个数学形状，使用 [addMathShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/) 创建，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathportion/) 在形状的文本框中存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathematicaltext/) 和 [IMathElement](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) 的流式方法，以保持代码简洁易读。

有关 MathML 导出场景，请参阅 [从 Android 演示文稿导出数学公式](/slides/zh/androidjava/exporting-math-equations/)。

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![公式 c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` 创建一个已包含数学段落的形状。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 `divide` 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathfractiontypes/) 选择分数样式。

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

使用 `radical` 创建平方根、立方根或其他根式。当前元素成为基数，参数成为指数。

![一个 n 次根表达式，x 位于根号下](powerpoint-math-equations_5.png)

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

使用 `asArgumentOfFunction` 或 `function` 添加 `sin(x)`、`log(x)` 等函数或自定义函数名。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathlimit/) 或使用 `setLowerLimit`。

![当 x 趋于无穷大时的极限](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于自定义函数名，使函数名成为当前元素：

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **添加 N 元运算符和积分**

使用 `nary` 添加求和、并集、交集等大运算符。使用 `integral` 添加积分。两种方法都可以设置上下限。

![带有上下限的求和](powerpoint-math-equations_7.png)

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

N 元运算符用于带可选上下限的大运算符。`+`、`-`、`=` 等简单运算符通常作为 `MathematicalText` 添加并拼接到表达式中。

对于积分，使用 `integral`：

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathmatrix/) 定义行列。矩阵默认不包括括号，如需括号、方括号或大括号，请自行包裹矩阵。

![一个两行的数学矩阵，其中有一个空单元格](powerpoint-math-equations_10.png)

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

## **添加公式数组**

当需要对齐的公式或垂直堆叠的表达式时，使用 `toMathArray`。

![一个垂直的数学数组，x 在 y 上方](powerpoint-math-equations_11.png)

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

当已知函数名且参数为当前元素时，使用 `asArgumentOfFunction`。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

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

使用下标和上标辅助方法添加索引和幂。当索引必须出现在基数左侧时，使用 `setSubSuperscriptOnTheLeft`。

![大写字母 Y，左侧下标 1，上标 n](powerpoint-math-equations_9.png)

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

![一个包含 x、y、z，且用竖线分隔的分界符表达式](powerpoint-math-equations_13.png)

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

## **添加边框盒**

当需要为公式加框时，使用 `toBorderBox`。

![一个带框的公式，显示 a² = b² + c²](powerpoint-math-equations_12.png)

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

使用 `group` 在表达式上方或下方放置分组字符。添加极限以对分组项进行标记。

![将表达式 x + y 分组，并在其下方标注任意文本](powerpoint-math-equations_15.png)

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

仅在有助于澄清公式时使用格式化辅助方法。例如，`overbar` 在数学元素上方添加一条横线。

![带有上划线的数学表达式 ABC](powerpoint-math-equations_14.png)

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
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathematicaltext/) |
| 组合元素 | [IMathElement.join](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 创建分数 | [IMathElement.divide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加上标或下标 | [setSuperscript](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加函数 | [function](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加根式 | [IMathElement.radical](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加极限 | [setLowerLimit](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加左侧脚本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathmatrix/) |
| 添加公式数组 | [toMathArray](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加分界符 | [enclose](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |
| 分组项 | [group](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathelement/) |

## **常见问题**

**我可以编辑现有的 PowerPoint 公式吗？**

可以。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，然后更新该段落中的数学块。

**公式会保存为可编辑的 PowerPoint 数学吗？**

会。保存为 PPTX 时，Aspose.Slides 会将公式写入可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

可以。通过其 `IMathPortion` 获取公式的 [IMathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathparagraph/)，并调用 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathparagraph/#toLatex--) 直接导出。完整示例请参阅 [从 Android via Java 的演示文稿导出数学公式](/slides/zh/androidjava/exporting-math-equations/#export-math-equations-to-latex)。