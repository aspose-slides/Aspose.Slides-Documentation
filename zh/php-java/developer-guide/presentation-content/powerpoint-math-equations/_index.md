---
title: 在 PHP 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 PHP 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language（OMML）。通过适用于 PHP via Java 的 Aspose.Slides，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **插入 > 公式** 添加公式：

![PowerPoint 插入选项卡，已选择“公式”命令](powerpoint-math-equations_1.png)

结果是在幻灯片上显示可编辑的数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 使用 [addMathShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addMathShape) 创建的数学形状，即包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathportion/) 将数学内容存储在形状的文本框中。
- [MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathematicaltext/) 和来自 [MathElementBase](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 的流式方法，以保持代码简短易读。

有关 MathML 导出场景，请参阅 [Export Math Equations from Presentations in PHP via Java](/slides/zh/php-java/exporting-math-equations/).

## **创建公式**

此示例创建一个数学形状并添加勾股定理：

![公式：c² = a² + b²](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` 创建了一个已包含数学段落的形状。访问第一个 `MathPortion`，获取其 `MathParagraph`，并向其中添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 [`divide`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathfractiontypes/) 选择分数样式。

![一个倾斜的数学分数，显示 1 除以 x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

对于堆叠分数，使用 `MathFractionTypes::Bar`：

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **添加根式**

使用 [`radical`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 创建平方根、立方根或其他根式。当前元素成为基数，参数成为指数。

![一个 n 次根式表达式，x 位于根号下](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加函数和极限**

使用 [`asArgumentOfFunction`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 或 [`function`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 处理 `sin(x)`、`log(x)` 等函数或自定义函数名。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathlimit/) 或使用 [`setLowerLimit`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/)。

![当 x 趋向无穷大时的极限](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

对于自定义函数名，请将函数名设为当前元素：

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **添加 N 元运算符和积分**

使用 [`nary`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 处理求和、并集、交集等大运算符。使用 [`integral`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 处理积分。两者均可设置上下限。

![带有上下限的求和符号](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N 元运算符用于可选上下限的大运算符。`+`、`-`、`=` 等简单运算符通常以 `MathematicalText` 添加并组合进表达式。

对于积分，使用 `integral`：

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathmatrix/) 处理行和列。矩阵默认不包括括号，如需圆括号、方括号或大括号，请自行包裹矩阵。

![一个两行的数学矩阵，其中一个单元格为空](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加方程数组**

需要对齐的公式或垂直堆叠的表达式时，使用 [`toMathArray`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/)。

![垂直排列的数学数组，x 在 y 之上](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加三角函数**

当参数是当前元素且函数名已知时，使用 [`asArgumentOfFunction`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/)。

![三角函数 cos 作用于 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加下标和上标**

使用下标和上标助手处理索引和幂。当索引需出现在基数左侧时，使用 [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/)。

![带左侧下标 1 和上标 n 的大写字母 Y](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加分隔符**

使用 [`enclose`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 将表达式放入分隔符内。对于包含多个元素的分隔符表达式，还可以设置分隔字符。

![包含 x、y、z，并使用竖线分隔的分隔符表达式](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添加边框盒子**

当公式本身需要被框住时，使用 [`toBorderBox`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/)。

![一个带框的公式，显示 a² = b² + c²](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **对项分组**

使用 [`group`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 在表达式上方或下方放置分组字符。添加上下限以标记分组的项。

![表达式 x + y 进行分组，并在下方添加标签任意文本](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **格式化数学元素**

仅在有助于阐明公式时使用格式化辅助。例如，[`overbar`](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) 在数学元素上方加一条横线。

![带有上划线的数学表达式 ABC](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathematicaltext/) |
| 组合元素 | [join](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 创建分数 | [divide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加上标或下标 | [setSuperscript](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加函数 | [function](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加根式 | [radical](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加极限 | [setLowerLimit](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加左侧脚本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathmatrix/) |
| 添加方程数组 | [toMathArray](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加分隔符 | [enclose](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 添加上划线和边框 | [overbar](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |
| 对项分组 | [group](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathelementbase/) |

## **常见问题**

**我可以编辑现有的 PowerPoint 公式吗？**

可以。打开演示文稿，找到包含 `MathPortion` 的形状，获取其 `MathParagraph`，并在该段落中更新数学块。

**公式是否以可编辑的 PowerPoint 数学形式保存？**

是的。保存为 PPTX 时，Aspose.Slides 会将公式写入可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

Aspose.Slides 将数学公式导出为 MathML。如果需要 LaTeX，请先导出为 MathML，然后使用支持目标 LaTeX 方言的工具将 MathML 转换为 LaTeX。