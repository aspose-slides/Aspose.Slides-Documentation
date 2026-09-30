---
title: 在 .NET 中管理 PowerPoint 表格的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/net/manage-rows-and-columns/
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
- 行文本格式
- 列文本格式
- 表格样式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 管理 PowerPoint 表格的行和列，快速编辑演示文稿和更新数据。"
---
## **介绍**

Aspose.Slides for .NET 允许您通过 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类和 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口在 PowerPoint 演示文稿中管理表格结构和格式。您可以指定标题行，克隆或删除行和列，并对整行或整列应用文本格式。

本文使用 C# 示例解释这些操作。它还展示了如何检索表格的样式预设以便重复使用。表格行和列的索引从零开始。

## **控制行高**

使用 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) 设置行的最小高度（单位：磅）。它是下限，而非固定高度。[IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) 返回实际高度，只读。通过 [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) 访问行。

示例加载 [row-height-input.pptx](row-height-input.pptx)，该文件在第一张幻灯片的第一个形状中包含一个表格。其第一行起始高度为 70 磅。单元格使用 18 磅 Arial 文本，自动换行，顶部和底部边距为 6 磅；第二列的较长文本会换成多行。示例将最小值提升至 100 磅，然后降低至 20 磅，分别打印每次更改后的实际高度，并保存两种结果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

使用提供的演示文稿，增加最小值会向行中添加空白，减少最小值会移除多余的空白，但实际高度仍大于 20 磅，因为文本和单元格边距需要更多空间。仅缩小最小值无法将行高度压低到内容所需空间以下。

实际高度受以下因素影响：

- **文本和字体大小：** 较长的文本、显式换行或更大的字体会需要更多的垂直空间。
- **换行和列宽度：** 启用换行后，更窄的 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) 会产生更多行。更宽的列可以减少垂直所需空间。
- **单元格边距：** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) 和 [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) 添加垂直空间。[ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) 和 [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) 减少文本可用宽度，可能导致额外换行。

对于此未合并单元格的表格，需垂直空间最多的单元格决定整行的内容驱动下限。若要使行更短，可能还需要缩短文本、减小字号或边距，或增宽列宽。

下图显示了相同尺度下的同一表格。本次运行的实际高度分别为 70、100 和 55.2 磅：最终行仍高于其 20 磅的最小值。文本的精确测量会随环境中可用的字体而变化。下载保存的结果：[增加的最小值](row-height-increased.pptx) 和 [减少的最小值](row-height-decreased.pptx)。

| 原始：最小 70 pt，实际 70 pt | 增加后：最小 100 pt，实际 100 pt | 减少后：最小 20 pt，实际 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一行 70 点。](row-height-before.png) | ![将第一行最小值提高到 100 点后的表格。](row-height-increased.png) | ![将第一行最小值降低到 20 点后的表格；换行文本使行仍高于最小值。](row-height-decreased.png) |

## **将第一行设置为标题**

使用 [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) 属性将第一行标记为标题格式。其外观取决于表格应用的表格样式。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 访问存储在幻灯片上第一个形状中的表格。
4. 为其第一行启用标题格式。
5. 保存修改后的演示文稿。

示例需要 `table.pptx`（第一张幻灯片的第一个形状为表格）。它为第一行启用标题格式并保存为 `First_row_header.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **克隆表格行或列**

克隆行或列以复用其内容和格式。您可以将副本追加到表格末尾，或插入到指定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法添加表格。
5. 克隆所需的行。
6. 克隆所需的列。
7. 保存修改后的演示文稿。

示例需要 `Test.pptx`（至少包含一张幻灯片）。它创建一个三列五行的表格，尺寸以磅为单位。然后将第一行和第一列的副本追加到表格末尾，再在索引 3（即第四个位置）插入第二行和第二列的副本。结果表格拥有七行五列。`false` 参数禁用向相邻合并行或列的克隆；此表格没有合并单元格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **从表格中删除行或列**

删除表格中不再需要的行或列。删除项目会使随后行或列的索引向前移动。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类创建演示文稿。
2. 访问第一张幻灯片。
3. 定义列宽和行高。
4. 使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法添加表格。
5. 删除第二行和第二列。
6. 保存修改后的演示文稿。

此示例创建一个 3×3 表格并删除索引为 1 的行和列，生成一个 2×2 表格并保存为 `TestTable_out.pptx`。尺寸以磅为单位。`false` 参数禁用删除相邻合并行或列；此表格没有合并单元格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **在表格行级别设置文本格式**

对整行应用文本格式，以保持单元格的一致性。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 为第一行设置 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
4. 为第一行设置 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
5. 为第二行设置 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`（第一张幻灯片的第一个形状为表格且至少有两行）。它对第一行应用 25 磅文本、右对齐以及 20 磅的右侧段落边距，然后在第二行设置垂直文本。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **在表格列级别设置文本格式**

对整列应用文本格式，以保持单元格的一致性。您可以设置字体属性、段落格式和文本方向，而无需逐个单元格格式化。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 访问第一张幻灯片上的表格。
3. 为第一列设置 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
4. 为第一列设置 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
5. 为第二列设置 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
6. 保存修改后的演示文稿。

示例需要 `table.pptx`（第一张幻灯片的第一个形状为表格且至少有两列）。它对第一列应用 25 磅文本、右对齐以及 20 磅的右侧段落边距，然后在第二列设置垂直文本。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **获取表格样式属性**

使用 [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) 属性检索表格应用的预设样式，以便在另一张表格上重复使用。这标识的是预设，而非单元格的单独格式覆盖。

示例创建一个表格，应用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) 并读取回该预设。它打印 `DarkStyle1` 并将表格保存为 `table.pptx`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **常见问题**

**我可以将 PowerPoint 主题/样式应用于已经创建的表格吗？**

可以。表格继承幻灯片/布局/母版的主题，您仍然可以在此主题之上覆盖填充、边框和文字颜色。

**我可以像在 Excel 中那样对表格行进行排序吗？**

不，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保持特定单元格自定义颜色的同时使用分段（条纹）列吗？**

可以。启用分段列后，可对特定单元格进行本地格式覆盖；单元格级别的格式会优先于表格样式。