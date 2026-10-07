---
title: 在演示文稿中使用 PHP 管理表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/php-java/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格以及设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文说明如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格背景颜色以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用零基索引按 `(column, row)` 顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开一个现有的演示文稿，并将第一张幻灯片上的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状是表格。然后遍历所有行和列，使用 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 来识别合并区域中的单元格。对于每个匹配项，按 `row;column` 顺序打印单元格坐标、[getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) 以及该区域的起始坐标，[getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **删除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 在其第一页幻灯片上添加表格。列宽、行高和表格位置以点（points）为单位指定。示例将所有四条单元格边框设置为 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，使其不可见。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`false` 将合并限制在该范围内。

示例创建一个 4×4 表格，列宽和行高为 70 点，然后合并位于 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。结果单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中为 `$table->get_Item(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围之外单元格的索引不会改变。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **拆分表格单元格**

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建一个 4×4 表格，列宽和行高为 70 点，并对单元格 `(1, 1)` 调用 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)。将该单元格 70 点宽度的一半传入，以创建两个等宽的单元格。

拆分后，这两个半单元格分别通过 `$table->get_Item(1, 1)` 和 `$table->get_Item(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **按行或列跨度拆分合并的单元格**

要为数据填充准备合并的模板单元格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) 按列边界拆分。

`index` 参数统计拆分上部的行数或左侧的列数；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，且 `(1, 2)` 和 `(1, 3)` 垂直合并。从下部位置开始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 和 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 定位起点并检查两个跨度。`splitByRowSpan(1)` 将行 2 和 3 分离用于产品名称。对于水平的两列合并，请改用 `splitByColSpan(1)`。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // 检索拆分后表格中得到的单元格。
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

表格网格及其周围单元格的索引保持不变。可通过坐标检索得到的单元格；此处两者的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 返回 `false`。较大的区域在一次拆分后仍可能部分保持合并状态。

原始文本及其格式保留在上部（或左部）单元格；新单元格为空，但继承了单元格的格式，如填充、边框和边距。拆分后填充单元格并显式设置任何所需的文本格式。

保存的演示文稿包含分开的 “Product A” 与 “Product B” 单元格，并保留了模板的单元格格式。请参阅 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 获取详细信息。

## **更改表格单元格背景颜色**

本示例创建一个列宽 150 点、行高 50 点的表格。它使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 选择实色填充，并将 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 返回的颜色设置为红色，应用于单元格 `(2, 3)`（第 3 列第 4 行）。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在表格单元格内添加图像**

在运行本示例之前，请将输入图像放置在工作目录中。它使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 加载图像，并通过 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格中的第一个单元格）的图片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，这可能会改变其纵横比。列宽和行高以点为单位。加载的图像在添加到演示文稿后于 `finally` 块中释放。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**我可以为单个单元格的不同边设置不同的线粗细和样式吗？**

是的。单元格格式的 [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 边框各有独立的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设置为单元格背景后更改列/行尺寸，图像会发生什么？**

行为取决于 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸时，图像会调整以适应新的单元格；使用平铺时，平铺会重新计算。

**我可以将超链接分配给单元格的全部内容吗？**

[Hyperlinks](/slides/zh/php-java/manage-hyperlinks/) 在单元格的文本框内部的文本（段落）级别或整个表格/形状级别设置。实际操作中，您可以将链接分配给段落或单元格中的全部文本。

**我可以在单个单元格中设置不同的字体吗？**

是的。单元格的文本框支持 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（即运行），它们可以拥有独立的格式——字体系列、样式、大小和颜色。