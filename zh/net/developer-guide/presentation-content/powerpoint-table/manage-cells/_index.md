---
title: 在 .NET 中管理演示文稿的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/net/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图像
- 背景颜色
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中管理 PowerPoint 表格单元格：识别合并单元格、删除边框、拆分单元格，并设置背景颜色和图像。"
---
## **概述**

Aspose.Slides 允许您访问和修改 PowerPoint 演示文稿中的表格单元格。本文介绍如何识别合并的表格单元格、删除单元格边框、在合并或拆分单元格后处理单元格编号、更改单元格的背景颜色以及在表格单元格中添加图像。示例展示了如何创建或打开演示文稿、从幻灯片获取表格、通过单元格属性更新单元格格式，并将修改后的演示文稿另存为 PPTX 文件。

Aspose.Slides 使用从零开始的索引以 `(column, row)` 的顺序访问表格单元格。

## **识别合并的表格单元格**

示例打开一个现有的演示文稿，并将第一页的第一个形状作为表格访问。它假设幻灯片和形状存在且该形状是表格。随后遍历所有行和列，并使用[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)来识别合并区域中的单元格。对于每个匹配项，它以 `row;column` 顺序打印单元格坐标、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)，以及区域的起始坐标，[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 和 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)。

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

## **删除表格单元格边框**

创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，并使用[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)在其第一页添加表格。列宽、行高以及表格位置均以点为单位指定。示例将所有四个单元格边框设置为[FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，使其不可见。

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

## **合并表格单元格**

使用[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/)将矩形范围的表格单元格合并为一个单元格。指定范围左上角和右下角的单元格。最后一个参数控制合并是否可以包括指定范围之外的单元格；`false` 将合并限制在该范围内。

示例创建了一个 4×4 的表格，列宽和行高均为 70 点，然后合并了从 `(1, 1)` 到 `(2, 2)` 的四个中心单元格。合并后的单元格跨越两列两行，而表格的底层网格仍保持四列四行。要访问合并单元格的内容或格式，请使用其左上位置：本例中的 `table[1, 1]`。合并范围内的其他位置仍属于表格网格，因此范围之外单元格的索引保持不变。

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

在前面的示例中合并单元格会保留表格的网格。拆分单元格可能会引入新的网格列，并改变其右侧单元格的列索引。Aspose.Slides 遵循 PowerPoint 的表格网格模型。

本示例创建一个 4×4 的表格，列宽和行高均为 70 点，并对单元格 `(1, 1)` 调用[SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)。将该单元格 70 点宽度的一半传入，以创建两个等宽单元格。

拆分后，这两个半部可分别通过 `table[1, 1]` 和 `table[2, 1]` 访问。表格网格现在有五列：原先位于第 2、3 列的单元格分别移动到第 3、4 列。行索引保持不变。拆分后访问单元格时请使用这些更新后的列索引。

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

### **按行或列跨度拆分合并的单元格**

为了在填充数据前准备合并的模板单元格，可使用[SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/)沿现有行边界拆分，或使用[SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/)沿列边界拆分。

`index` 参数计数拆分上部的行或左部的列；它相对于合并区域：

- 行拆分：`0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- 列拆分：`0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

示例假设演示文稿的第一页第一个形状是表格，且 `(1, 2)` 与 `(1, 3)` 垂直合并。从下方位置开始，它使用[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)和[FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)定位起点并检查两个跨度。`SplitByRowSpan(1)`随后将第 2 行和第 3 行分离用于产品名称。对于水平的两列合并，请改用 `SplitByColSpan(1)`。

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

表格网格和周围单元格的索引保持不变。可通过坐标检索结果单元格；此处两个单元格的跨度均为 1，且[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)返回 `False`。较大的区域在一次拆分后仍可能部分保持合并。

原始文本及其格式保留在上（或左）单元格中；新单元格为空，但继承了填充、边框和边距等单元格格式。拆分后填充单元格并显式设置任何所需的文本格式。

保存后的演示文稿包含单独的“Product A”和“Product B”单元格，并保留模板的单元格格式。详见[Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)。

## **更改表格单元格背景颜色**

本示例创建一个列宽 150 点、行高 50 点的表格。对位于第 3 列第 4 行的单元格 `(2, 3)` 将[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)设置为实色，并将[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)设置为红色。

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

## **在表格单元格中添加图像**

在运行此示例之前，请将输入图像放置在工作目录中。它使用[Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/)加载图像，并通过[AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/)将其添加到演示文稿的图像集合中。随后将该图像分配给单元格 `(0, 0)`（表格的第一个单元格）的图片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) 将图像拉伸以填充单元格，可能会改变其宽高比。列宽和行高以点为单位。加载的图像会在 using 声明中自动释放。

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

**我可以为单个单元格的不同边设置不同的线粗细和样式吗？**

可以。单元格的[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/)边框各自拥有独立的属性，因此每一侧的粗细和样式可以不同。

**如果在将图片设置为单元格背景后更改列/行大小，图像会怎样？**

行为取决于[fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)。使用拉伸时，图像会调整以适应新的单元格；使用平铺时，平铺会重新计算。

**我可以为单元格的全部内容分配超链接吗？**

[Hyperlinks](/slides/zh/net/manage-hyperlinks/) 可以在单元格文本框的文本（段落）级别或整个表格/形状级别设置。实际上，你可以将链接分配给文本的某个段落或整个单元格的所有文本。

**我可以在单个单元格内设置不同的字体吗？**

可以。单元格的文本框支持具有独立格式（字体系列、样式、大小和颜色）的[portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（文本块）。