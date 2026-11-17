---
title: 在 .NET 中管理演示文稿的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/net/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 C# 中管理 PowerPoint 表格单元格：使用 Aspose.Slides for .NET 识别合并单元格、移除边框、拆分单元格以及设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您在 PowerPoint 演示文稿中访问和修改表格单元格。本文介绍如何识别合并的表格单元格、移除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格内添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿保存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引，以 `(column, row)` 顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开一个现有演示文稿，并将第一张幻灯片上的第一个形状作为表格进行访问。它假设幻灯片和形状均存在且该形状是表格。随后遍历所有行和列，并使用[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)来识别合并区域中的单元格。对于每个匹配项，它会以 `row;column` 顺序打印单元格坐标、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)以及该区域的起始坐标，[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)和[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```
## **移除表格单元格边框**

创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，并使用[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)在其第一张幻灯片上添加表格。列宽、行高和表格位置均以磅为单位指定。示例将四个单元格边框均设置为[FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，使其不可见。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```
## **添加对角线单元格边框**

使用[BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/)从左上角绘制一条线到右下角，使用[BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/)从左下角绘制一条线到右上角。对角线可用于标记角标题；两条对角线同时出现可形成 X，标记单元格为不适用。

每条对角线都是一个[ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/)。在其[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/)中，将[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)设置为[FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，并选择[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)。将线条的[Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/)以磅为单位设置。

示例在同一行创建了三个单元格：一个红色下向对角线、一个蓝色上向对角线，以及两条对角线均有的单元格。它保持上下左右单元格边框不变。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

对角线是一种格式属性，而非单元格拆分。每个单元格仅保留一个[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/)；对角线两侧的区域无法独立编辑。

保存的表格，在 Microsoft PowerPoint 中渲染如下：

![三个表格单元格分别显示从左上到右下的红色对角线、从左下到右上的蓝色对角线，以及两条对角线形成的 X。](diagonal-cell-borders.png)

*从左到右：下向对角线（红色，3 pt）、上向对角线（蓝色，5 pt）以及两条对角线。*

## **合并表格单元格**

使用[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/)将表格中矩形范围的单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包含指定范围之外的单元格；`false` 可将合并限制在该范围内。

示例创建了一个 4×4 的表格，列宽和行高均为 70 磅，然后合并了位于 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格的底层网格仍保留四列四行。要访问合并单元格的内容或格式，在本例中使用其左上位置 `table[1, 1]`。合并范围内的其他位置仍是表格网格的一部分，因此范围外单元格的索引保持不变。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```
## **拆分表格单元格**

在前面的示例中，合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列并更改其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本例创建了一个 4×4 的表格，列宽和行高均为 70 磅，并对单元格 `(1, 1)` 调用[SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)。将单元格 70 磅宽度的一半用于创建两个等宽单元格。

拆分后，这两半分别通过 `table[1, 1]` 和 `table[2, 1]` 访问。表格网格现在有五列：原先位于第 2 列和第 3 列的单元格分别移动到第 3 列和第 4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```
### **按行或列跨距拆分合并单元格**

为了准备合并的模板单元格用于填充数据，可使用[SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/)沿现有行边界拆分，或使用[SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/)沿列边界拆分。

`index` 参数统计拆分上部的行数或左部的列数；它相对于合并区域：

- 行拆分：`0 < index <`[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- 列拆分：`0 < index <`[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

示例假设演示文稿在第一张幻灯片的第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。首先从下方位置出发，使用[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)和[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)定位起始位置并检查两个跨距。`SplitByRowSpan(1)` 随后将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，则使用 `SplitByColSpan(1)`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // 检索拆分后表格中得到的单元格。
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

表格网格及其周围单元格索引保持不变。可通过坐标检索得到的单元格；此处两者的跨距均为 1，且[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)返回 `False`。较大的区域在一次拆分后仍可能部分保持合并。

原始文本及其格式保留在上（或左）单元格；新单元格为空，但继承单元格的填充、边框和边距等格式。拆分后填充单元格并显式设置任何所需的文本格式。

保存的演示文稿包含独立的 “Product A” 与 “Product B” 单元格，保留了模板的单元格格式。详情请参阅[Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)。

<!-- visual-explanation:manage-cells:start -->
[![列 1 第 2 行和第 3 行的合并单元格拆分为 Product A 和 Product B，网格索引保持不变。](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*行跨距拆分使用了已有的边界。Product A 和 Product B 分别占据 (1, 2) 和 (1, 3)。*
<!-- visual-explanation:manage-cells:end -->

### **按特定高度拆分单元格**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) 以磅为单位指定上部的高度。[SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) 以现有网格行数指定上部的行数。要在右侧列中使 40 磅高的单元格居中，需要先从单元格的实际高度减去 40 再将剩余空间上下等分。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

第一次拆分会添加一行网格，使下方 90 磅保留在 `[1, 1]`。第二次拆分针对该单元格，再在其下方添加一行。右侧列现在包含 `[1, 0]`（50 磅，`margin`）、`[1, 1]`（40 磅）和 `[1, 2]`（50 磅，`margin`）。左侧单元格跨越这三行，保持原始高度 140 磅。

![左侧单元格跨越整个表格高度，右侧有三个单元格，中间的位于中心。](split-by-height.png)

## **更改表格单元格背景颜色**

本例创建了一个列宽 150 磅、行高 50 磅的表格。对单元格 `(2, 3)`（第 3 列第 4 行），将[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)设为 solid，并将[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)设为红色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```
## **在表格单元格内添加图像**

在运行本示例前，将输入图像放置在工作目录中。示例使用[Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/)加载图像，并通过[AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/)将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格中的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) 会将图像拉伸以填满单元格，可能会改变其宽高比。列宽和行高以磅为单位。加载的图像在 using 声明结束后会自动释放。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```
## **常见问题**

**我可以为单个单元格的不同侧设置不同的线条粗细和样式吗？**

可以。单元格的[上](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[下](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[左](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[右](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/)边框各有独立的属性，因而每一侧的粗细和样式可以不同。

**如果在将图片设为单元格背景后更改列/行尺寸，图像会怎样？**

行为取决于[填充模式](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸时，图像会适应新的单元格大小；使用平铺时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/net/manage-hyperlinks/) 在单元格的文本框内部的文本（段）级别或整个表格/形状级别设置。实际使用时，您可以将链接分配给某段文本或单元格中的全部文本。

**我可以在单个单元格内设置不同的字体吗？**

可以。单元格的文本框支持[portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（文本块），可以独立设置格式——包括字体族、样式、大小和颜色。