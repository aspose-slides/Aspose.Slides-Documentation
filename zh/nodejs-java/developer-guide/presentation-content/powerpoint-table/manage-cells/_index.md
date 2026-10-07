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
description: "使用 JavaScript 管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并使用 Aspose.Slides for Node.js 通过 Java 设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文介绍如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿另存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引以 `(column, row)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开现有演示文稿，并将第一张幻灯片上的第一个形状作为表格进行访问。它假设幻灯片和形状存在且该形状是表格。随后遍历所有行和列，并使用 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 来识别合并区域中的单元格。对于每个匹配项，输出 `row;column` 顺序的单元格坐标、[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)，以及该区域的起始坐标，分别为 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)。

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

创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 并使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) 在其第一张幻灯片上添加表格。列宽、行高和表格位置均以磅为单位指定。示例将所有四个单元格边框设置为 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，使其不可见。

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

## **合并表格单元格**

使用 [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) 将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`false` 将合并限制在该范围内。

示例创建一个 4×4 的表格，列宽和行高均为 70 磅，然后将 `(1, 1)` 到 `(2, 2)` 的四个中心单元格合并。合并后的单元格跨越两列两行，而表格的底层网格仍保持四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中的 `table.get_Item(1, 1)`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引保持不变。

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

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列，并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建一个 4×4 的表格，列宽和行高均为 70 磅，并对单元格 `(1, 1)` 调用 [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/)。将单元格 70 磅宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半部可分别通过 `table.get_Item(1, 1)` 和 `table.get_Item(2, 1)` 访问。表格网格现在有五列：原来位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

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

### **按行或列跨度拆分合并的单元格**

为了在数据填充前准备合并的模板单元格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) 按现有行边界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) 按列边界拆分。

`index` 参数计算拆分上部的行数或左侧的列数；它相对于合并区域：

- 行拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。
- 列拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

示例假设演示文稿的第一张幻灯片的第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。它从下方位置开始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) 和 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 定位起点并检查两个跨度。随后调用 `splitByRowSpan(1)` 将第 2 行和第 3 行分离用于产品名称。若为水平两列合并，则使用 `splitByColSpan(1)`。

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

        // 检索拆分后表格中得到的单元格。
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

表格网格及周围单元格索引保持不变。可按坐标检索得到的单元格；此处两个单元格的跨度均为 1，且 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 输出 `false`。更大的区域在一次拆分后仍可部分保持合并状态。

原始文本及其格式保留在上部（或左部）单元格；新单元格为空，但继承填充、边框和边距等单元格格式。拆分后请填充单元格并显式设置所需的文本格式。

保存的演示文稿包含独立的 “Product A” 与 “Product B” 单元格，且保留了模板单元格的格式。详见 [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)。

## **更改表格单元格背景颜色**

本示例创建一个列宽 150 磅、行高 50 磅的表格。它使用 [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 选择实色填充，并将 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) 返回的颜色设置为红色，以填充单元格 `(2, 3)`（第 3 列第 4 行）。

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

在运行本示例之前，请将输入图像放置在工作目录中。示例使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) 加载图像，并通过 [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) 将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) 将图像拉伸以填满单元格，可能会改变其宽高比。列宽和行高均以磅为单位。加载的图像在加入演示文稿后于 `finally` 块中被释放。

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

## **常见问题**

**我能为单个单元格的不同边设置不同的线粗细和样式吗？**

是的。单元格的 [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) 边框具有独立的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行尺寸，会发生什么？**

行为取决于 [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)（stretch/til�）。使用拉伸时，图片会随新单元格尺寸调整；使用平铺时，会重新计算平铺块。

**我能将超链接分配给单元格的全部内容吗？**

[Hyperlinks](/slides/zh/nodejs-java/manage-hyperlinks/) 只能在单元格文本框的文字（portion）级别或整个表格/形状级别设置。实际操作时，您可以把链接赋给文本框中的某个部分，或把整个单元格的所有文字都设为同一链接。

**我能在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持 [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（文字段）并可为每个段落单独设置字体系列、样式、大小和颜色。