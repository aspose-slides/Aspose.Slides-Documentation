---
title: 使用 JavaScript 管理演示文稿表格
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
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 在 PowerPoint 幻灯片中创建和编辑表格。发现简易代码示例，简化您的表格工作流。"
---

PowerPoint 中的表格是展示和呈现信息的高效方式。以行列排列的单元格网格中的信息直观且易于理解。

Aspose.Slides 提供了 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 类、**[单元格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)** 类以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 方法向幻灯片添加 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象。  
6. 遍历每个 **[单元格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)**，为上、下、左、右边框应用格式。  
7. 合并表格首行的前两个单元格。  
8. 访问 **[单元格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)** 的 **[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)**。  
9. 向 **[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)** 添加一些文本。  
10. 保存修改后的演示文稿。

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 定义列宽和行高
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 向幻灯片添加表格形状
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 为每个单元格设置边框格式
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 合并第 1 行的第 1、2 个单元格
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // 向合并后的单元格添加一些文本
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // 将演示文稿保存到磁盘
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **标准表格的编号**

在标准表格中，单元格的编号是直接且从零开始的。表格中的第一个单元格索引为 0,0（列 0，行 0）。

例如，具有 4 列和 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 JavaScript 代码演示如何为表格中的单元格指定编号：

```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 定义列宽和行高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 向幻灯片添加表格形状
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 为每个单元格设置边框格式
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **访问现有表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取包含表格的幻灯片的引用。  
3. 创建 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象并将其设为 null。  
4. 遍历所有 **[形状](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)** 对象，直至找到表格。  

   如果您怀疑当前幻灯片只包含一个表格，可以直接检查其中的所有形状。当形状被识别为表格时，可以将其强制转换为 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象。但若幻灯片中包含多个表格，建议通过其 **[setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-)** 来搜索所需表格。  

5. 使用 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象对表格进行操作。下面的示例向表格添加了一行新行。  
6. 保存修改后的演示文稿。

```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 将 TableEx 初始化为 null
    var tbl = null;
    // 遍历形状并将找到的表格引用设置为变量
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 为第二行的第一列设置文本
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // 将修改后的演示文稿保存到磁盘
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **对齐表格中文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象。  
4. 从表格中获取 **[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)** 对象。  
5. 获取 **[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)** 的 **[段落](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)**。  
6. 纵向对齐文本。  
7. 保存修改后的演示文稿。

```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 定义列宽和行高
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // 向幻灯片添加表格形状
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // 访问文本框
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // 为文本框创建 Paragraph 对象
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 垂直对齐文本
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // 将演示文稿保存到磁盘
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在表格层面设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片访问 **[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table)** 对象。  
4. 为文本设置 **[setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)**。  
5. 设置 **[setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-)** 和 **[setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)**。  
6. 设置 **[setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)**。  
7. 保存修改后的演示文稿。

```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 假设第一张幻灯片上的第一个形状是表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 设置表格单元格的字体高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // 一次调用设置表格单元格的文本对齐方式和右侧边距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // 设置表格单元格的文本垂直方向
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便在其他表格或其他位置使用这些信息。以下 JavaScript 代码演示如何从预设样式中获取表格的样式属性：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 更改默认样式预设主题
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **锁定表格宽高比**

几何形状的宽高比指的是其在不同维度上的尺寸比例。Aspose.Slides 提供了 **[setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)** 属性，帮助您锁定表格和其他形状的宽高比设置。

以下 JavaScript 代码演示如何锁定表格的宽高比：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// 取反
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我能为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格提供了 **[setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/)** 方法，段落则有 **[ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/)**。两者一起使用可确保单元格内的 RTL 顺序和渲染正确。

**如何阻止用户在最终文件中移动或调整表格大小？**

使用形状锁来禁用移动、大小调整、选择等。这些锁同样适用于表格。

**是否支持在单元格内插入图像作为背景？**

可以。您可以为单元格设置 **[picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/)**；图像会根据所选模式（拉伸或平铺）覆盖单元格区域。