---
title: 在 .NET 中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/net/manage-table/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 幻灯片中创建和编辑表格。发现简单的 C# 代码示例，以简化您的表格工作流程。"
---
## **介绍**

PowerPoint 中的表格将信息组织为行和列，便于阅读和比较数值。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 接口以及其他类型，以便在演示文稿中创建、更新和管理表格。

## **从头创建表格**

通过指定位置、列宽和行高来创建表格。将其添加到幻灯片后，可以设置单元格边框、合并单元格并插入文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取对幻灯片的引用。
3. 定义以点为单位的列宽数组。
4. 定义以点为单位的行高数组。
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 以对上、下、左、右边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 通过其 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 属性访问合并后的单元格。
9. 在合并的单元格中设置文本。
10. 保存修改后的演示文稿。

下面的示例在 (100, 50) 点处创建一个三列五行的表格，应用宽度为 5 点的红色边框，合并第一行的前两个单元格，并将结果保存为 `table.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **标准表格中的编号**

在标准表格中，单元格索引从零开始，顺序为 (列, 行)。第一个单元格的索引为 (0, 0)。

例如，具有 4 列 4 行的表格的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此示例创建上图所示的 4 × 4 表格，列宽和行高均为 70 点，红色单元格边框宽度为 5 点。坐标展示了单元格索引；示例保持单元格为空并将表格保存为 `StandardTables_out.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **访问现有表格**

表格存储在幻灯片的形状集合中。遍历形状以定位表格，然后使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口读取或更新其单元格。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取包含该表格的幻灯片的引用。
3. 遍历 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 对象，找到表格后停止。如果幻灯片包含多个表格，使用 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) 来识别所需的表格。
4. 更新目标单元格中的文本。
5. 保存修改后的演示文稿。

下面的示例打开 `UpdateExistingTable.pptx` 并查找第一张幻灯片上的第一个表格。它将列 0、行 1 的单元格设置为 `New`，并将结果保存为 `table1_out.pptx`。输入必须至少包含一张幻灯片，且该幻灯片上的第一个表格必须至少有一列两行。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

要调整现有表格中行的大小并了解其实际高度为何可能超过请求的最小值，请参阅 [控制行高](/slides/zh/net/manage-rows-and-columns/#control-row-height)。

## **查找拥有文本框的单元格**

当通用文本处理代码从表格中获取到 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 时，使用 [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 属性检索拥有该文本框的 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)。对于表格单元格的文本框，[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 已设置且 [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) 为 `null`，即使表格本身也是一个形状。

单元格坐标可通过只读的 [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 和 [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 属性获取。[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 也是只读的：它提供对所有者的导航，但不改变所有权。使用前请始终检查返回的单元格是否为 `null`。

有关识别表格单元格和形状所有者（包括与 SmartArt 节点关联的形状）的完整示例，请参阅 [搜索和替换文本](/slides/zh/net/search-and-replace-text/)。

## **对齐表格中的文本**

您可以控制单个表格单元格的垂直锚定和文本方向。本节示例将第一单元格的文本居中并旋转 270 度。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取对幻灯片的引用。
3. 向幻灯片添加 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。
4. 从表格中获取 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 对象。
5. 访问第一个 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)，并设置其文本和颜色。
6. 设置单元格的 [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) 和 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/)。
7. 保存修改后的演示文稿。

此示例创建一个 4 × 4 表格，列宽为 120 点，行高为 100 点。它对单元格 (0, 0) 的文本进行格式化，在第一行的其余单元格中添加值，并将结果保存为 `Vertical_Align_Text_out.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **在表格级别设置文本格式**

使用 [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) 可对表格中所有单元格应用文本格式。其重载接受段落、文本块和文本框的格式设置，无需遍历单元格即可设置这些属性。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿。
2. 通过索引获取对幻灯片的引用。
3. 从幻灯片获取 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。
4. 设置文本的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
5. 设置 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
6. 设置 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
7. 保存修改后的演示文稿。

下面的示例打开 `table.pptx`（该文件必须至少包含一张包含表格的幻灯片，且表格为第一形状），将字体大小设置为 25 点，段落右对齐并设置右边距为 20 点，使文本垂直显示。格式化后的演示文稿保存为 `result.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **获取表格样式属性**

使用 [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) 读取或分配表格的预设样式。此示例将 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) 应用于一个表格，打印预设名称，并将相同的预设分配给第二个表格。两个表格均保存在 `table-style.pptx` 中。

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

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **锁定表格的宽高比**

表格的宽高比是其宽度与高度的比例。使用 [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) 可锁定表格的宽高比。

下面的示例打开 `pres.pptx`（该文件必须至少包含一张包含表格的幻灯片，且表格为第一形状），打印当前锁定状态，启用宽高比锁定，打印更新后的状态 (`True`)，并将结果保存为 `pres-out.pptx`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **常见问题**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格公开了 [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) 属性，段落具有 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/)。同时使用这两个属性即可确保单元格内的正确 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/net/applying-protection-to-presentation/) 可禁用移动、缩放、选择等。这些锁同样适用于表格。

**是否支持在单元格内插入图像作为背景？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。