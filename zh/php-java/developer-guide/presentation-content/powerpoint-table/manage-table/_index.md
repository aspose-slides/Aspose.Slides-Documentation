---
title: 在 PHP 中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/php-java/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 纵横比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化您的表格工作流。"
---
## **介绍**

PowerPoint 中的表格将信息组织为行和列，便于阅读和比较数值。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 类、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 类以及其他类型，帮助您在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格并插入文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义以点为单位的列宽数组。
4. 定义以点为单位的行高数组。
5. 通过 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 方法向幻灯片添加 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 对象。
6. 遍历每个 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)，为上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) 方法访问合并后的单元格。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点处创建一个包含三列五行的表格。它为单元格设置宽度为 5 点的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **标准表格中的编号**

在标准表格中，单元格索引从零开始，顺序为 (列, 行)。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上面展示的 4 × 4 表格，列宽和行高均为 70 点，单元格边框为宽度 5 点的红色。坐标用于展示单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **访问现有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 类读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含表格的幻灯片引用。
3. 遍历 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象，找到表格后停止。如果幻灯片包含多个表格，请使用 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx` 并在第一张幻灯片上找到第一个表格。它将第 0 列第 1 行的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入文件必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列两行。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

要在现有表格中调整行的大小并了解其实际高度为何可能超过请求的最小值，请参阅 [Control Row Height](/slides/zh/php-java/manage-rows-and-columns/#control-row-height)。

## **查找拥有文本框的单元格**

当通用文本处理代码从表格中获取到 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 时，使用 [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 方法检索拥有该文本框的 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)。对于表格单元格的文本框，[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 返回所有者，而 [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) 返回 `null`，即使表格本身也是一个形状。

单元格坐标可通过只读的 [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 和 [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 方法获取。[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) 还提供只读导航：它返回所有者但不改变所有权。在使用之前，请始终使用 `java_is_null` 检查返回的单元格。

有关完整示例，展示如何识别表格单元格和形状的所有者（包括与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/php-java/search-and-replace-text/)。

## **在表格中对齐文本**

您可以控制单个表格单元格的垂直锚点和文本方向。本节示例将第一单元格的文本居中并旋转 270 度。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 对象。
4. 从表格中获取 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象。
5. 获取第一个 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 并设置其文本和颜色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) 和 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) 设置单元格的垂直锚点和文本方向。
7. 保存修改后的演示文稿。

该示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它在单元格 (0, 0) 中设置文本，在第一行的其余单元格中添加值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格级别设置文本格式**

使用 [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) 为表格中的所有单元格应用文本格式。其重载接受段落、文本块以及文本框的格式设置，您无需遍历单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 从幻灯片中获取 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 对象。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) 为文本设置字体大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) 和 [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) 设置段落对齐方式和右边距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) 设置文本方向。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张幻灯片，且表格是第一形状），将字体大小设为 25 点，段落右对齐并设置右边距为 20 点，使文本垂直显示。格式化后的演示文稿保存为 `result.pptx`。

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) 读取表格的预设样式，使用 [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) 分配样式。本示例将 [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) 应用于一个表格，打印预设值，并将相同的预设分配给第二个表格。两个表格均保存为 `table-style.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **锁定表格的纵横比**

表格的纵横比是其宽度与高度的比率。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) 可锁定该比率。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张幻灯片，且表格是第一形状），打印当前锁定状态，启用纵横比锁定，打印更新后的状态 (`true`)，并将结果保存为 `pres-out.pptx`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题解答**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) 方法，段落提供了 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/)。同时使用可确保单元格内的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部将图像作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)，图像将依据所选模式（拉伸或平铺）覆盖单元格区域。