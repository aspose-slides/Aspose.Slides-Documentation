---
title: 在 PHP 中从演示文稿获取形状的有效属性
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
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中区分形状的本地、继承和有效格式设置。"
---
## **了解本地、继承和有效属性**

PowerPoint 的格式可以来自多个来源。直接存储在对象上的值称为 **本地值**。如果该值未设置，PowerPoint 会查找父级格式来源，例如段落默认、文本样式、布局或母版幻灯片、主题或演示文稿级默认。这些值称为 **继承值**。在整个层级解析完成后留下的值即为 **有效值**——用于渲染对象的值。

例如，某段文本可能未定义自己的字体高度。它的本地 [getFontHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/) 值为 `NAN`，表示“此处未设置”。该段可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对该段格式调用 [getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/geteffective/) 将返回最终解析后的高度。

根据不同需求使用两种格式数据：

- 当需要控制值的定义位置时，读取或更改本地格式对象，例如 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/)；
- 当需要最终渲染结果时，读取有效数据对象，例如 [PortionFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/geteffective/) 返回的 **data**。有效数据为只读。

运行示例前，请先 [install Aspose.Slides for PHP via Java](/slides/zh/php-java/installation/)。

## **比较本地、继承和有效值**

下面的完整示例创建一个形状，并在演示文稿、段落和段落级别分别设置字体高度。每一步都会打印在这些层级定义的值以及同一文本段的最终有效值。它还演示了在格式更改后必须重新读取有效数据的原因。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // 读取前面更改后的有效数据。
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // 在两个不同层级定义继承值。
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // 段落片段的本地值覆盖两个继承值。
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // 更改继承值不会覆盖已有的本地值。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // 清除本地值。该片段再次从段落继承。
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // 清除段落值。演示文稿默认值现在提供结果。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

本例的优先级顺序为：段落本地格式 > 段落格式 > 演示文稿默认。其他对象可能拥有不同的继承链，但原理相同：更具体的显式值获胜，且 [getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/geteffective/) 返回最终结果。

## **获取有效的文本属性**

文本格式分散在多个对象中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/geteffective/) 解析文本框属性，如边距、锚点、自动适应和垂直文字方向；
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textstyle/geteffective/) 解析每个文本样式层级的段落格式；
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/geteffective/) 解析段落属性，如对齐、缩进和项目符号；
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/geteffective/) 解析字符属性，如字体高度、字体、颜色、粗体和斜体。

对于下面的示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个包含非空文本框的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。AutoShape 可以位于形状集合的任意位置；代码会搜索合适的对象并在使用前进行验证。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **获取有效的 3D 属性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 返回一个有效数据对象，汇总所有解析后的 3D 设置。它的 [getCamera](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/)、[getLightRig](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/)、[getBevelTop](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 和 [getBevelBottom](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/geteffective/) 方法分别公开对应的有效数据。一起读取这些相关设置可更容易理解形状的最终 3D 外观。

对于本例，`shape-3d.pptx` 必须在其首张幻灯片上至少包含一个形状。若希望输出包含非默认值，请为该形状应用 3D 相机、光照或斜角设置。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **获取有效的表格格式**

表格格式可能来源于表格样式，也可能来源于对整个表、列、行或单元格的格式设置。对于显式定义的填充冲突，优先级为：单元格 > 行 > 列 > 整个表。单元格的有效格式就是绘制该单元格时使用的最终格式。

对于本例，`table-formatting.pptx` 必须在其首张幻灯片上至少包含一个表格，且该表格至少有一行一列。代码会搜索 [Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/)，而不是假设 `getShapes()->get_Item(0)` 为表格。

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

如果需要颜色而不仅仅是填充类型，首先检查有效的 [getFillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/geteffective/) 值，然后读取对应类型的方法，例如针对实色填充的 [getSolidFillColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/geteffective/)。

## **更改后重新读取有效数据**

有效数据描述了解析时的格式层级。更改任何可能参与该层级的内容后，请再次调用 `getEffective`，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格格式；
- 布局或母版幻灯片格式；
- 主题数据或演示文稿级默认值；
- 分配给幻灯片的布局或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存部分有效数据，后续的 `getEffective` 调用可以刷新这些数据。如果需要在更改前后比较值，请在更改前将所需的标量值（例如字体高度、颜色、对齐方式或斜角宽度）复制到自己的变量中。

要更改值，请更新相应的本地格式对象，然后调用 `getEffective` 验证结果。有效数据对象本身是只读的。

## **FAQ**

**如何判断是哪一级提供的有效值？**

有效数据只包含最终值，而不指明来源。请从最具体的层级向外检查相应的本地对象。对于文本，这可能包括段落、文本框、布局、母版、主题以及演示文稿默认值。`NAN` 或 `null` 等未定义值表示搜索将继续到更高层级。

**如果没有任何层级定义属性会怎样？**

Aspose.Slides 会解析出相应的 PowerPoint 或库默认值。该解析后的值会出现在有效数据中，即使没有本地对象显式定义它。

**为什么有效值有时等于本地值？**

本地值在继承计算中获胜。当属性在对象上显式设置且没有更具体的规则覆盖时，就会出现这种情况。

**何时应使用本地数据而不是有效数据？**

在检查或编辑特定格式层级时使用本地数据。需要在继承、主题规则和适用样式全部解析后得到的最终外观时使用有效数据。完整的比较示例（[#compare-local-inherited-and-effective-values]）在同一工作流中演示了两者的使用。