---
title: 在 PHP 中获取演示文稿的形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/php-java/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 如何计算并应用形状的有效属性，以实现精确的 PowerPoint 渲染。"
---
## **概览**

本主题解释 **本地** 与 **有效** 属性之间的区别。本地值是直接在特定格式级别设置的值，例如：

1. 幻灯片上的段落属性。
1. 在布局或母版幻灯片上的原型形状文本样式（当段落的文本框形状具有该样式时）。
1. 演示文稿中的全局文本设置。

本地值可以在任何级别定义或省略。当 Aspose.Slides 需要最终“渲染后”的格式时，它会解析继承链并返回 **有效** 值。您可以通过对本地格式对象调用 `getEffective` 方法来获取它们。

下面的示例演示如何获取有效值。假设第一张幻灯片上的第一个形状是一个带有文本框且至少包含一个段落的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
有效的格式数据表示在应用继承后当前计算得到的格式。在当前实现中，通过诸如 [PortionFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/geteffective/) 等方法返回的某些有效数据对象可能在内部被缓存。在更改父级或继承的格式后再次调用 `getEffective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需的属性（如字体高度、填充颜色、字体样式或对齐方式）复制到您自己的数据对象中。
{{% /alert %}}

## **获取相机的有效属性**

Aspose.Slides 允许您获取相机的有效属性。通过 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 返回的有效数据包含了用于 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 的最终相机属性。

下面的代码示例演示如何获取相机的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **获取灯光装置的有效属性**

Aspose.Slides 允许您获取灯光装置的有效属性。通过 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 返回的有效数据包含了用于 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 的最终灯光装置属性。

下面的代码示例演示如何获取灯光装置的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **获取斜角形状的有效属性**

Aspose.Slides 允许您获取形状斜角的有效属性。通过 [ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 返回的有效数据包含了用于 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 的最终面部浮雕属性。

下面的代码示例演示如何获取形状顶部斜角的有效属性。假设第一张幻灯片上的第一个形状具有 3D 格式。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。通过 [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/geteffective/) 返回的有效数据包含文本框的格式属性。

下面的代码示例演示如何获取文本框的有效格式属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。通过 [TextStyle.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textstyle/geteffective/) 返回的有效数据包含文本样式属性。

下面的代码示例演示如何获取文本样式的有效属性。假设第一张幻灯片上的第一个形状是一个带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **获取有效字体高度值**

使用 Aspose.Slides，您可以获取有效的字体高度。下面的代码演示在演示文稿结构的不同层级设置本地字体高度后，段落的有效字体高度如何变化。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取不同表格部分的有效填充格式。通过格式对象返回的有效数据包含 [FillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/) 属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整表格式。

因此，绘制表格单元格时会使用有效的 [CellFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellformat/) 属性。下面的代码示例演示如何获取不同表格部分的有效填充格式。假设第一张幻灯片上的第一个形状是一个 [Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/)。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**`getEffective` 会返回快照吗？**

并非总是如此。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能在内部被缓存。随后调用 `getEffective` 可能会重新计算格式并刷新缓存的数据，因此先前获取的对象不应视为持久的快照。

**何时需要重新读取有效属性？**

在更改本地格式、父级样式、布局格式、母版格式或演示文稿级默认值后，请再次调用 `getEffective`。下一次调用会重新评估格式层次并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已经检索到的有效属性吗？**

会，但变化会在下次调用 `getEffective` 时体现。如果父级格式源被更改或删除，先前获取的有效数据可能已过时。再次调用 `getEffective` 后，Aspose.Slides 会重新评估格式树， resulting fonts, colors, sizes, or other values may change.（此句保持原意，已翻译如下）重新评估后，字体、颜色、尺寸等值可能会改变。

**我可以通过有效数据对象修改值吗？**

不能。有效数据对象只提供计算后的值。请在本地格式对象上进行修改，然后再次获取有效值。

**如果属性既未在形状层级设置，也未在布局/母版或全局设置中出现，会怎样？**

有效值将由默认机制决定，其中包括 PowerPoint 和 Aspose.Slides 的默认值。解析后的值会成为当前有效数据的一部分。

**从有效字体值中，我能判断是哪个层级提供了尺寸或字体吗？**

不能直接判断。有效数据只返回最终值。若要查找来源，需要检查段落、文本框、布局、母版以及演示文稿层级的本地值，寻找首次出现的显式定义。

**为什么有效值有时看起来与本地值相同？**

因为本地值已经是最终值（无需更高层级的继承）。在这种情况下，有效值与本地值相匹配。

**何时使用有效属性，何时仅使用本地属性？**

在需要“渲染后”结果（即所有继承已应用）的情况下使用有效数据，例如对齐颜色、缩进或尺寸。如果您需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。如果您需在特定层级修改格式，请修改本地属性，然后（如有必要）再次读取有效数据以验证结果。