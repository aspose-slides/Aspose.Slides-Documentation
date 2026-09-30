---
title: 管理 JavaScript 中的演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/nodejs-java/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式
- 表格样式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 及 Node.js 版 Aspose.Slides，在 PowerPoint 幻灯片中创建并编辑表格。发现简洁的代码示例，以简化您的表格工作流程。"
---
## **简介**

PowerPoint 中的表格将信息组织成行和列，使阅读和比较数值更加容易。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 类、[Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) 类以及其他类型，以便在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，您可以设置单元格边框、合并单元格并插入文本。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个以点为单位的列宽数组。
4. 定义一个以点为单位的行高数组。
5. 通过 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) 方法向幻灯片添加一个 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 对象。
6. 遍历每个 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) 并为上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) 方法访问合并后的单元格。
9. 设置合并单元格中的文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点处创建一个包含三列五行的表格。它为单元格设置宽度为 5 点的红色边框，合并首行的前两个单元格，并将结果保存为 `table.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **标准表格中的编号**

在标准表格中，单元格索引从零开始，顺序为（列，行）。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上图所示的 4 × 4 表格，列宽和行高均为 70 点，单元格边框为宽度 5 点的红色。坐标用于说明单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问现有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 类读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含表格的幻灯片的引用。
3. 遍历 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 对象并在找到表格时停止。如果幻灯片包含多个表格，请使用 [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx` 并在第一张幻灯片上找到第一个表格。它将列 0、行 1 的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入必须至少包含一张幻灯片，并且该幻灯片上的第一个表格必须至少有一列两行。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

要调整现有表格中行的大小并了解其实际高度为何可能超过请求的最小值，请参阅 [控制行高](/slides/zh/nodejs-java/manage-rows-and-columns/#control-row-height)。

## **查找拥有 TextFrame 的单元格**

当通用文本处理代码从表格中收到一个 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 时，使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 方法检索拥有该文本框的 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)。对于表格单元格的文本框，[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 返回拥有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) 返回 `null`，即使表格本身是一个形状。

可以通过只读的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) 和 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) 方法获取单元格坐标。[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 还提供只读导航：它返回所有者但不更改所有权。使用前务必检查返回的单元格是否为 `null`。

有关完整示例（包括识别表格单元格和形状所有者以及与 SmartArt 节点关联的形状），请参阅 [搜索和替换文本](/slides/zh/nodejs-java/search-and-replace-text/)。

## **对齐表格中的文本**

您可以控制各个表格单元格的垂直锚点和文本方向。本节示例将第一单元格中的文本居中并旋转 270 度。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 对象。
4. 从表格中获取一个 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 对象。
5. 获取第一个 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 并设置其文本和颜色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) 和 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) 设置单元格的垂直锚点和文本方向。
7. 保存修改后的演示文稿。

此示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它对单元格 (0, 0) 的文本进行格式化，向首行其余单元格添加值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格级别设置文本格式**

使用 [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) 可对表格中所有单元格应用文本格式。其重载接受部分、段落和文本框格式，从而无需遍历单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 从幻灯片获取一个 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 对象。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) 为文本设置字体大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 和 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 设置段落对齐方式和右边距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 设置文本方向。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张包含表格的幻灯片，表格为第一形状）。它将字体大小设为 25 点，段落右对齐并设置右边距为 20 点，使文本垂直显示。格式化后的演示文稿保存为 `result.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **获取表格样式属性**

使用 [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) 可读取表格的预设样式，使用 [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) 可为其分配样式。此示例对一个表格应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/)，打印预设值，并将相同的预设分配给第二个表格。两个表格均保存在 `table-style.pptx` 中。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比值。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) 可以锁定该比例。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张包含表格的幻灯片，表格为第一形状）。它打印当前的锁定状态，启用宽高比锁定，打印更新后的状态 (`true`)，并将结果保存为 `pres-out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) 方法，段落则有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-)。同时使用两者可确保单元格内部的 RTL 顺序和渲染正确。

**如何阻止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 可禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内插入图像作为背景？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。