---
title: 使用 JavaScript 管理 PowerPoint 表格中的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/nodejs-java/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 第一行
- 表格标题
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文本格式化
- 列文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及适用于 Node.js via Java 的 Aspose.Slides，在 PowerPoint 中管理表格行和列，并加快演示文稿的编辑和数据更新。"
---
## **介绍**

Aspose.Slides for Node.js via Java 允许您通过 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 类在 PowerPoint 演示文稿中管理表格结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文通过 JavaScript 示例说明这些操作。它还展示了如何检索表格的样式预设，以便重复使用。表格行和列的索引从零开始。

## **控制行高度**

使用 [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) 将行的最小高度设为点数。它是下限，而非固定高度。 [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) 返回实际高度。通过 [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，该文件在第一张幻灯片的第一个形状中包含一个表格。其第一行起始高度为 70 点。单元格使用 18 点 Arial 文本，自动换行，且上下边距为 6 点；第二列的较长文本会换成多行。示例先将最小高度提升至 100 点，再降至 20 点，在每次更改后打印实际高度，并保存两种结果。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用提供的演示文稿时，增加最小值会为行添加空间。减少最小值会去除这些额外空间，但实际高度仍大于 20 点，因为文本和单元格边距需要更多空间。仅降低最小值无法将行高度压低到内容所需空间以下。

实际高度受多种因素影响：

- **文本和字体大小：** 较长的文本、显式换行或更大的字体会需要更多垂直空间。
- **换行和列宽：** 启用换行后，使用 [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) 缩小列宽会产生更多行。更宽的列可以减少垂直空间需求。
- **单元格边距：** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) 和 [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) 会增加垂直空间。[Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) 和 [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) 会减少文本可用宽度，可能导致额外换行。

对于此无合并单元格的表格，所需垂直空间最多的单元格决定整行的内容驱动下限。要让行更短，可能还需要缩短文本、减小字体大小或边距，或加宽列宽。

下图展示了相同尺度下的同一表格。示例结果中实际高度分别为 70、100 和 55.2 点：最终行仍高于其 20 点的最小值。具体文本尺寸会因环境中可用的字体而异。下载保存的结果文件： [increased minimum](row-height-increased.pptx) 和 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，实际 70 pt | 增加后：最小 100 pt，实际 100 pt | 减少后：最小 20 pt，实际 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一行 70 点。](row-height-before.png) | ![将第一行最小值提升至 100 点后的表格。](row-height-increased.png) | ![将第一行最小值降至 20 点后的表格；换行文本使行高仍高于最小值。](row-height-decreased.png) |

## **将首行设为标题**

使用 [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) 方法将第一行标记为标题格式。其外观取决于表格所应用的表格样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 访问幻灯片上作为第一个形状存储的表格。
4. 为其第一行启用标题格式。
5. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状为表格。它为第一行启用标题格式并保存为 `First_row_header.pptx`。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **克隆表格行或列**

克隆行或列以复用其内容和格式。您可以将副本追加到表格末尾，或插入到特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法添加表格。
5. 克隆所需的行。
6. 克隆所需的列。
7. 保存修改后的演示文稿。

示例需要 `Test.pptx`，至少包含一张幻灯片。它创建一个三列五行的表格，尺寸以点为单位。示例将第一行和第一列的副本追加至表格末尾，然后在索引 3（第四个位置）插入第二行和第二列的副本。最终表格拥有七行五列。`false` 参数禁止在相邻的合并行或列中进行克隆；此表格没有合并单元格。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除项目会导致其后面的行或列索引发生偏移。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类创建演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法添加表格。
5. 删除第二行和第二列。
6. 保存修改后的演示文稿。

此示例创建一个三行三列的表格，并删除索引为 1 的行和列，生成一个两行两列的表格并保存为 `TestTable_out.pptx`。尺寸以点为单位。`false` 参数禁止删除相邻的合并行或列；此表格没有合并单元格。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格行级别设置文本格式**

对整行应用文本格式，以保持单元格的一致性。您可以一次性设置字体属性、段落格式和文本方向，而无需对每个单元格单独格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 对第一行使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 对第一行使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。
5. 对第二行使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状为表格且至少有两行。它为第一行应用 25 点文字、右对齐以及 20 点右侧段落边距，然后为第二行设置垂直文本。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格列级别设置文本格式**

对整列应用文本格式，以保持单元格的一致性。您可以一次性设置字体属性、段落格式和文本方向，而无需对每个单元格单独格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 对第一列使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 对第一列使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。
5. 对第二列使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`，其中第一张幻灯片的第一个形状为表格且至少有两列。它为第一列应用 25 点文字、右对齐以及 20 点右侧段落边距，然后为第二列设置垂直文本。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) 方法检索表格所应用的预设样式，以便在其他表格上复用。该方法返回的是预设标识，而非单元格的逐项格式覆盖。

示例创建一个表格，应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1)，然后读取该预设。它打印对应于 `DarkStyle1` 的整数值，并将表格保存为 `table.pptx`。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以对已经创建好的表格应用 PowerPoint 主题/样式吗？**

可以。表格会继承幻灯片/版面/母版的主题，您仍然可以在此基础上覆盖填充、边框和文字颜色。

**我能像 Excel 那样对表格行排序吗？**

不能，Aspose.Slides 的表格没有内置的排序或过滤功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用条纹列吗？**

可以。启用条纹列后，针对特定单元格的本地格式会覆盖表格样式，单元格级别的格式具有更高优先级。