---
title: 使用 PHP 管理演示文稿中的表格单元格
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
description: "在 PHP 中管理 PowerPoint 表格单元格：识别合并单元格、移除边框、拆分单元格，并使用 Aspose.Slides for PHP（通过 Java）设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文介绍了如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格内添加图像。示例演示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。Aspose.Slides 使用从零开始的索引，以 `(column, row)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一页的第一个形状作为表格访问。它假设幻灯片和形状存在，并且该形状是表格。然后遍历所有行和列，使用 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 来识别合并区域中的单元格。对于每个匹配项，它以 `row;column` 顺序打印单元格坐标，调用 [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) ，以及该区域的起始坐标，使用 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/)。

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

## **移除表格单元格边框**

创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) 在其第一张幻灯片上添加表格。列宽、行高以及表格位置均以点为单位指定。示例将所有四个单元格边框设置为 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，使其不可见。

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

## **添加对角线单元格边框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) 绘制从左上角到右下角的线，并使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) 绘制从左下角到右上角的线。对角线可以标记角落标题；两个对角线一起可以形成 X，标记单元格不适用。

每条对角线都有其自己的 [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) 中，使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 选择 [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 并通过 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 选择颜色。使用 [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) 以点为单位设置线宽。

示例在同一行创建了三个单元格：一个红色向下的对角线、一个蓝色向上的对角线，以及两个对角线。它保留了顶部、底部、左侧和右侧单元格边框不变。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对角线仅更改单元格的格式。每个单元格保留一个文本框，可通过 [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) 访问。对角线两侧的区域无法独立编辑。

保存的表格，在 Microsoft PowerPoint 中呈现如下：

![三个表格单元格显示从左上到右下的红色对角线、从左下到右上的蓝色对角线以及形成 X 的两条对角线。](diagonal-cell-borders.png)

*从左到右：向下对角线（红色，3 pt），向上对角线（蓝色，5 pt），以及两条对角线。*

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`false` 将合并限制在该范围内。

示例创建了一个 4x4 的表格，列宽和行高均为 70 点，然后合并了从 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，在本示例中使用其左上位置：`$table->get_Item(1, 1)`。合并范围内的其他位置仍属于表格网格，因此范围外单元格的索引保持不变。

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

前面示例中的单元格合并保留了表格的网格。拆分单元格可能会引入新列并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

此示例创建了一个 4x4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用 [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)。将单元格 70 点宽度的一半用于创建两个等宽的单元格。

拆分后，这两半可分别通过 `$table->get_Item(1, 1)` 和 `$table->get_Item(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

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

<!-- visual-explanation:manage-cells:start -->
[![未合并的 70 点单元格拆分为两个 35 点单元格，添加了第五列网格并将其右侧的索引向后移动。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*宽度拆分影响单元格 (1, 1)，使用基于零的 (column, row) 索引。其他行保持一个单元格跨越两个新列位置。*
<!-- visual-explanation:manage-cells:end -->

### **按行或列跨度拆分合并单元格**

为了为数据填充准备已合并的模板单元格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) 按列边界拆分。

`index` 参数统计拆分上部的行数或左部的列数；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。从下方位置开始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) 和 [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) 定位起始点并检查两个跨度。随后 `splitByRowSpan(1)` 将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，则改用 `splitByColSpan(1)`。

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

        // 检索拆分后表格中的结果单元格。
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

表格网格和周围单元格的索引保持不变。可通过坐标检索得到的单元格；此处两个单元格的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) 打印 `false`。更大的区域在一次拆分后仍可能部分保持合并。

原始文本及其格式保留在上部（或左侧）单元格；新单元格为空，但会继承单元格的格式，例如填充、边框和边距。拆分后填充单元格，并显式设置所需的文本格式。

保存的演示文稿包含单独的 “Product A” 和 “Product B” 单元格，保留了模板的单元格格式。详见 [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)。

### **按特定高度拆分单元格**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) 接受上部的高度（点）。[splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) 接受上部已有网格行的数量。要在右列居中一个 40 点的单元格，需要先从单元格的实际高度减去 40，然后将剩余空间在上方和下方平均分配。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

第一次拆分添加了一行网格，并在单元格 `(1, 1)` 中留下了下部的 90 点。第二次拆分将该单元格分为一个 40 点的中部单元格和一个 50 点的底部单元格。右列现在从上到下有三个单元格，高度分别为 50、40 和 50 点。左侧单元格跨越所有三行，保持原始的 140 点高度。

![左侧单元格跨越整个表格高度，右侧有三个单元格，中间的单元格位于中部。](split-by-height.png)

## **更改表格单元格背景颜色**

本示例创建了一个列宽 150 点、行高 50 点的表格。它使用 [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) 选择实线填充，并将 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) 返回的颜色设置为红色，针对第 3 列第 4 行的单元格 `(2, 3)`。

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

在运行本示例之前，请将输入图像放置在工作目录中。它使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 加载图像，并使用 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) 将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，这可能会改变其宽高比。列宽和行高以点为单位。加载的图像在添加到演示文稿后于 `finally` 块中被释放。

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

是的。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) 边框具有各自的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设置为单元格背景后更改列/行大小，图像会怎样？**

行为取决于 [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（stretch/tile）。使用 stretch 时，图像会随新的单元格调整；使用 tile 时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/php-java/manage-hyperlinks/) 在单元格的文本框（段落）级别或整个表格/形状层级设置。实际上，您可以将链接分配给段落的一部分，或分配给单元格中的全部文本。

**我可以在单个单元格内设置不同的字体吗？**

是的。单元格的文本框支持 [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（文本块），它们可以拥有独立的格式——字体、样式、大小和颜色。