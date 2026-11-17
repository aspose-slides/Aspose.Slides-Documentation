---
title: 使用 JavaScript 管理演示文稿中的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/nodejs-java/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并使用 Aspose.Slides for Node.js（通过 Java）设置背景颜色和图像。"
---
## **概览**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文说明了如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、修改单元格的背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用零基索引按 `(column, row)` 顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿并将第一页的第一个形状作为表格访问。它假设该幻灯片和形状存在且形状是表格。随后遍历所有行和列，并使用[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/)来识别位于合并区域的单元格。对于每个匹配项，它按 `row;column` 顺序打印单元格坐标，输出[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)以及区域起始坐标的[getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/)和[getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **删除表格单元格边框**

创建一个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)并使用[addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/)在其第一张幻灯片上添加表格。列宽、行高和表格位置均以点为单位指定。示例将四个单元格边框全部设为[FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，使其不可见。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **添加对角线单元格边框**

使用[getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/)绘制从左上角到右下角的线，使用[getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/)绘制从左下角到右上角的线。对角线可以标记角落标题；两个对角线组成的 X 可标记单元格为“不适用”。

每条对角线都是一个[LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/)。在其[getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/)中，使用[setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/)选择[FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)并通过[getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/)选择颜色。使用[setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/)以点为单位设置线宽。

示例在同一行创建了三个单元格：一个红色下倾对角线、一个蓝色上倾对角线，以及两个对角线。它保持了上、下、左、右四个单元格边框不变。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对角线是一种格式属性，而非单元格拆分。每个单元格保留单个文本框，可通过[getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/)访问；对角线两侧的区域不能独立编辑。

保存的表格在 Microsoft PowerPoint 中的渲染效果：

![三个表格单元格分别显示从左上到右下的红色对角线、从左下到右上的蓝色对角线，以及形成 X 的两条对角线。](diagonal-cell-borders.png)

*从左到右：下倾对角线（红色，3 pt）、上倾对角线（蓝色，5 pt）以及两条对角线。*

## **合并表格单元格**

使用[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/)将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包括范围之外的单元格；`false` 将合并限制在该范围内。

示例创建了一个 4×4 的表格，列宽和行高均为 70 点，然后合并了从 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格底层网格仍保留四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中的 `table.get_Item(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围之外单元格的索引不会改变。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **拆分表格单元格**

前面示例中的合并操作保留了表格的网格。拆分单元格可能会引入新的网格列并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

此示例创建了一个 4×4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用[splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/)。将单元格宽度的 70 点的一半传入，以创建两个等宽单元格。

拆分后，这两个半单元格可通过 `table.get_Item(1, 1)` 和 `table.get_Item(2, 1)` 访问。表格网格现在有五列：原本位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用更新后的列索引。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![未合并的 70 点单元格拆分为两个 35 点单元格，新增第五列网格并将右侧索引向右移动。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*宽度拆分影响单元格 (1, 1)，使用零基 (column, row) 索引。其它行保持单元格跨越两个新列位置。*
<!-- visual-explanation:manage-cells:end -->

### **按行或列跨度拆分合并单元格**

要为数据填充准备合并的模板单元格，请使用[splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/)沿现有行边界拆分，或使用[splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/)沿列边界拆分。

`index` 参数计数拆分上部的行或左部的列；它相对于合并区域：

- 行拆分：`0 < index <`[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。
- 列拆分：`0 < index <`[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

示例假设演示文稿的第一张幻灯片的第一形状是表格，并且 `(1, 2)` 与 `(1, 3)` 垂直合并。它从下方位置出发，使用[getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)和[getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/)定位起点并检查两个跨度。`splitByRowSpan(1)` 随后分离第 2 行和第 3 行，以填充产品名称。对于水平的两列合并，请改为使用 `splitByColSpan(1)`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // 检索拆分后表格中产生的单元格。
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

表格网格及其周围单元格索引保持不变。通过坐标检索结果单元格；此处两者的跨度均为 1，且[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/)返回 `false`。较大的区域在一次拆分后仍可能部分保留合并状态。

原始文本及其格式保留在上（或左）单元格；新单元格为空，但继承单元格的填充、边框和边距等格式。拆分后填充单元格并显式设置任何所需的文本格式。

保存的演示文稿包含独立的 “Product A” 与 “Product B” 单元格，保留了模板单元格的格式。请参阅[Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)获取详细信息。

### **在特定高度拆分单元格**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/)接受上部的高度（以点为单位）。[splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/)接受上部已有网格行的数量。要在右侧列中将一个 40 点的单元格居中，需要先从单元格实际高度中减去 40，然后将剩余空间平均分配到上下两侧。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

第一次拆分新增一行网格，并在单元格 `(1, 1)` 留下下部 90 点。第二次拆分将该单元格分为一个 40 点的中间单元格和一个 50 点的底部单元格。右侧列现在有三个单元格，顶部到底部的高度依次为 50、40、50 点。左侧单元格跨越所有三行，保持原始高度 140 点。

![左侧单元格跨越整个表格高度，右侧有三个单元格，其中中间为 “Middle”。](split-by-height.png)

## **更改表格单元格背景颜色**

本示例创建了一个列宽 150 点、行高 50 点的表格。它使用[setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/)选择实心填充，并通过[getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/)将颜色设为红色，以填充单元格 `(2, 3)`（第 3 列第 4 行）。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格单元格内添加图像**

在运行本示例之前，请将输入图像放置在工作目录中。它使用[Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile)加载图像，并通过[addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/)将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格中的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)会将图像拉伸以填满单元格，这可能会改变其宽高比。列宽和行高均以点为单位。加载的图像在添加到演示文稿后于 `finally` 块中释放。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**我可以为单个单元格的不同边设置不同的线粗和样式吗？**

可以。单元格的[top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)、[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)、[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)、[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/)四个边各有独立属性，可分别设置其粗细和样式。

**在将图片设置为单元格背景后，如果更改列/行大小，图片会怎样？**

行为取决于[fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸时，图片会随新单元格大小调整；使用平铺时，会重新计算平铺方式。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/nodejs-java/manage-hyperlinks/)在单元格的文本框（文字段）层级或整个表格/形状层级设置。实际操作时，您可以将链接分配给文本段落中的全部文字或仅部分文字。

**我可以在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持[portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（文字运行），每个部分可以独立设置字体系列、样式、大小和颜色。