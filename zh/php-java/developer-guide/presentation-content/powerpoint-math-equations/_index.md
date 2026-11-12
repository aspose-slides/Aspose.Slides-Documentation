---
title: 在 PHP 中向 PowerPoint 演示文稿添加数学公式
linktitle: PowerPoint 数学公式
type: docs
weight: 80
url: /zh/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint PPT 和 PPTX 中插入和编辑数学公式，支持 OMML、格式控制以及清晰的 PHP 代码示例。"
---
## **概述**

PowerPoint 将公式存储为 Office Math Markup Language (OMML)。使用 Aspose.Slides for PHP via Java，您可以以编程方式创建相同类型的数学内容：分数、根式、函数、极限、N 元运算符、矩阵、数组以及格式化的数学块。

在 PowerPoint 中，用户通常通过 **Insert > Equation** 添加公式：

![PowerPoint 插入选项卡选择了“Equation”命令](powerpoint-math-equations_1.png)

结果是在幻灯片上呈现可编辑的数学文本：

![包含可编辑数学公式的 PowerPoint 幻灯片](powerpoint-math-equations_2.png)

Aspose.Slides 通过三个主要对象构建该数学文本：

- 通过 [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) 创建的数学形状，是包含公式的形状。
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) 在形状文本框内存储数学内容。
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) 包含一个或多个 [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) 对象。

下面的大多数示例使用 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) 和来自 [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) 的流式方法，以保持代码简洁易读。

对于从 PHP via Java 导出 MathML 的场景，请参阅 [从 PHP via Java 的演示文稿中导出数学公式](/slides/zh/php-java/exporting-math-equations/)。

## **创建公式**

此示例使用 [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) 创建数学形状并添加勾股定理：

![c² = a² + b² 公式](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) 创建的形状已经包含一个数学段落。访问第一个 [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/)，调用 [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)，并向其添加数学块或数学元素。
{{% /alert %}}

## **添加分数**

使用 [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) 创建分数。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) 选择分数样式。

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

对于堆叠分数，使用 [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **添加根式**

使用 [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) 创建平方根、立方根或其他根。当前元素成为底数，参数成为指数。

![一个 n 次根表达式，x 位于根号下](powerpoint-math-equations_5.png)

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

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) 处理函数，例如 `sin(x)`、`log(x)` 或自定义函数名。对于极限，将 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/)，或使用 [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit)。

![当 x 趋于无穷大时的极限](powerpoint-math-equations_8.png)

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

对于自定义函数名，将函数名设为当前元素并使用其参数调用 [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function)：

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **添加 N 元运算符和积分**

使用 [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) 处理求和、并集、交集以及其他大型运算符。使用 [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) 处理积分。这两种方法都可以设置上下限。

![带有上下限的求和](powerpoint-math-equations_7.png)

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

N 元运算符用于带可选上下限的大型运算符。像 `+`、`-`、`=` 这样的简单运算符通常使用 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) 添加并连接到表达式中。

对于积分，使用 [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **添加矩阵**

使用 [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) 表示行和列。矩阵默认不带括号，因此在需要圆括号、方括号或大括号时请自行包裹矩阵。

![一个两行的数学矩阵，包含一个空单元格](powerpoint-math-equations_10.png)

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

当需要对齐的方程或垂直堆叠的表达式时，使用 [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray)。

![一个垂直的数学数组，x 在 y 上方](powerpoint-math-equations_11.png)

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

### **使数组与周围元素对齐**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) 控制数组相对于其旁边数学元素的垂直对齐方式。下面的示例比较了第一行、数组中心和最后一行的对齐效果。

以下示例创建了三个相同的数组，每个数组有三行，并且旁边的元素为 `A=` 和 `=B`。所有数学文本均使用 24 磅的 Cambria Math。唯一变化的是数组的对齐方式。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下面的比较展示了在 PowerPoint 中保存的演示文稿。请注意每个数组旁边的 `A=` 和 `=B` 位置。

![PowerPoint 中的方程数组，分别使用顶部、居中和底部对齐，并且邻近元素相同](equation-array-alignment.png)

### **配置行间距**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) 选择数组内行的间距规则。[setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) 为显式间距规则提供数值，并在预设规则下被忽略。

对于精确间距，数值以磅为单位。对于比例间距，数值以半行计：示例中的值 `3` 表示 1.5 行。指定显式数值时需同时设置两个属性，仅更改数值不会选择间距规则。

下面的示例保存了五个演示文稿，方程、对齐和字体设置相同。前三个使用预设，后两个显示显式数值。

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

数组行间距与段落间距是分开的。[setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) 为包含段落添加前后间距，而不是数组行之间的间距。同样，[MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) 仅水平定位整个数学段落；它不会替代数组的垂直对齐设置。

## **添加三角函数**

当参数为当前元素且函数名称已知时，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

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

使用下标和上标帮助函数处理索引和幂。当索引必须出现于基底左侧时，使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![一个大写 Y，左侧下标为 1，上标为 n](powerpoint-math-equations_9.png)

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

## **添加分界符**

使用 [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) 将表达式放入分界符中。对于包含多个元素的分界符表达式，还可以设置分隔字符。

![一个分界符表达式，包含 x、y、z 并以竖线分隔](powerpoint-math-equations_13.png)

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

### **大小与对齐分界符**

向 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) 传入 `true` 可让括号随高操作数而增大，传入 `false` 则保持正常大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) 并选择两种 [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) 值之一。`Centered` 将括号居中于数学轴（即等号中线），`Match` 则使其与包含的内容对齐。这两个设置仅影响分界符，内部表达式保持不变。

示例将分数放在 `x` 的指数位置，使表达式在基线以上的延伸大于基线以下。所有四个公式均使用相同的括号和字体设置。

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在 PowerPoint 中，对比各行即可看到增长效果。顶部行的括号会随指数增大并在两种形状下保持相同。底部行则关闭了增长。左侧较小的括号（`Centered`）与等号对齐，而右侧（`Match`）则在表达式上方稍高。

![PowerPoint 中的四个公式，上排启用分界符增长，下排关闭，左侧为 Centered，右侧为 Match](delimiter-sizing.png)

## **添加边框框**

对分数调用 [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) 可为整个表达式加框。返回的 [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) 默认显示四条边。使用 [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) 和 [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) 可移除单独的边。

示例在同一幻灯片上放置了六个相同的分数。为了显示抵消，隐藏四条边并向 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 传入 `true` 以绘制上升对角线 (↗)，或向 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) 传入 `true` 绘制下降对角线 (↘)。也可以使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 并结合任意可见边进行设置。

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint 中的六个可编辑分数。上排：完整边框、底部和左侧边框、上升对角线。下排：下降对角线、水平划线、垂直划线并带完整边框。](border-box-fractions.png)

在此分数上，水平划线与分数线重叠。垂直划线穿过分子和分母，而周围的边框仍然可见。这些线条装饰整个表达式。普通的文本删除线仅作用于文本运行中的字符。重新在 PowerPoint 中打开演示文稿后，仍可分别编辑分子和分母。

## **分组项**

使用 [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) 可在表达式上方或下方放置分组字符。添加上下限可为分组项标记标签。

![表达式 x + y 被分组，并在下方添加标签任意文本](powerpoint-math-equations_15.png)

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

仅在有助于阐明公式时使用格式化帮助函数。例如，[overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) 在数学元素上方加上一条横线。

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

### **格式化已有公式中的文本**

要格式化现有公式中的所有文本，需要遍历每个数学块的元素树。[MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) 仅返回直接子元素，因此需要递归调用以访问分数、上标/下标、根式及其他嵌套结构中的文本。检查当前元素及其子元素，以在起始元素为 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) 时也包含在内。

本示例假设 `input.pptx` 包含类似 `z = xᵢ / ∛y` 的公式，其中分数的分子包含下标，分母包含根式。如果仅处理块的顶层元素，则会遗漏分数内部的文本。示例在幻灯片文本框中查找数学部分，通过 [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) 访问其块，并使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 将每个文本元素的 [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) 方法的字体大小设为 28 磅。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存的演示文稿在每个已处理公式的各层级都包含更新后的文本格式，同时保持其文本内容和数学结构不变。

## **快速参考**

| 任务 | 主要 API |
| --- | --- |
| 创建数学文本 | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| 组合元素 | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 创建分数 | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加上标或下标 | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加函数 | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加根式 | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加极限 | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加左侧脚本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加求和和积分 | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加矩阵 | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| 添加方程数组 | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加分界符 | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 添加横线和边框 | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 分组项 | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **常见问题**

**我可以编辑现有的 PowerPoint 公式吗？**

是的。打开演示文稿，找到包含 [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) 的形状，调用 [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph)，并在该段落中更新数学块。

**公式是否以可编辑的 PowerPoint 数学形式保存？**

是的。保存为 PPTX 时，Aspose.Slides 会将公式写入为可编辑的 Office 数学内容。

**我可以将公式导出为 LaTeX 吗？**

是的。从其 [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) 获取公式的 [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)，并调用 [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) 直接导出。完整示例请参阅 [Export Math Equations from Presentations in PHP via Java](/slides/zh/php-java/exporting-math-equations/#export-math-equations-to-latex)。