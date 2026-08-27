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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的 C# 示例代码，以简化表格工作流。"
---
## **简介**

PowerPoint 中的表格是一种高效的显示和表达信息的方式。将信息放在按行列排列的单元格网格中，直观且易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh/net/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/zh/net/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/) 接口以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [AddTable](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 对象。  
6. 遍历每个 [ICell](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/) 为其上、下、左、右边框设置格式。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [ICell](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/textframe/) 添加一些文本。  
10. 保存修改后的演示文稿。  

此 C# 代码演示了如何在演示文稿中创建表格：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();

// 访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 定义列宽和行高
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// 向幻灯片添加表格形状
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// 为每个单元格设置边框格式
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// 合并第 1 行的第 1 和第 2 个单元格
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// 向合并的单元格添加文本
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// 将演示文稿保存到磁盘
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **标准表格中的编号**

在标准表格中，单元格的编号方式简单且基于零索引。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格，其单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此 C# 代码创建了上述标准 4×4 表格并为每个单元格设置了边框格式：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // 将演示文稿保存到磁盘
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **访问现有表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  

2. 通过索引获取包含表格的幻灯片的引用。  

3. 创建一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 对象并将其设为 null。  

4. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 对象，直到找到表格。  

   如果您确信当前幻灯片只包含一个表格，可以直接检查其所有形状。当形状被识别为表格时，可以将其强制转换为 [Table](https://reference.aspose.com/slides/zh/net/aspose.slides/table/) 对象。但如果幻灯片中包含多个表格，建议通过其 [AlternativeText](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/alternativetext/) 来搜索所需的表格。  

5. 使用 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 对象对表格进行操作。下面的示例向表格添加了一行新行。  

6. 保存修改后的演示文稿。  

此 C# 代码演示了如何访问并操作现有表格：

```c#
using Aspose.Slides;

// 实例化一个表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 将 TableEx 初始化为 null
    ITable tbl = null;

    // 遍历形状并设置对发现的表格的引用
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 设置第二行第一列的文本
    tbl[0, 1].TextFrame.Text = "New";

    // 将修改后的演示文稿保存到磁盘
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **查找拥有文本框的单元格**

当通用文本处理代码从表格中收到一个 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 时，使用 [ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/) 属性来获取所属的 [ICell](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/)。对于表格单元格的文本框，[ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/) 已设置，而 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentshape/) 为 `null`，即使表格本身也是一种形状。

单元格坐标可通过只读属性 [ICell.FirstColumnIndex](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/firstcolumnindex/) 和 [ICell.FirstRowIndex](https://reference.aspose.com/slides/zh/net/aspose.slides/icell/firstrowindex/) 获取。[ITextFrame.ParentCell](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/parentcell/) 本身也是只读的：它提供对所有者的导航，但不更改所有权。使用前请始终检查返回的单元格是否为 `null`。

有关完整示例（包括识别表格单元格和形状所有者，以及与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/net/search-and-replace-text/)。

## **对齐表格中的文本**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 对象。  
4. 从表格中获取一个 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 对象。  
5. 获取该 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。  

此 C# 代码演示了如何对齐表格中的文本：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 创建一个 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取第一张幻灯片 
ISlide slide = presentation.Slides[0];

// 定义列宽和行高
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// 向幻灯片添加表格形状
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// 访问文本框
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// 为文本框创建 Paragraph 对象
IParagraph paragraph = txtFrame.Paragraphs[0];

// 为段落创建 Portion 对象
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 垂直对齐文本
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// 将演示文稿保存到磁盘
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **在表格级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中获取一个 [ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 对象。  
4. 为文本设置 [FontHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/fontheight/)。  
5. 设置 [Alignment](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraphformat/marginright/)。  
6. 设置 [TextVerticalType](https://reference.aspose.com/slides/zh/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 保存修改后的演示文稿。  

此 C# 代码演示了如何将首选的格式选项应用于表格中的文本：

```c#
using Aspose.Slides;

// 创建一个 Presentation 类的实例
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// 设置表格单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// 在一次调用中设置表格单元格的文本对齐方式和右边距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// 设置表格单元格的文本垂直类型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便将这些细节用于其他表格或其他位置。此 C# 代码展示了如何从表格预设样式中获取样式属性：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改默认样式预设主题 

    // 获取表格的样式预设。
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // 将检索到的样式预设应用于另一个表格。
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **锁定表格的宽高比**

几何形状的宽高比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 `AspectRatioLocked` 属性，以便您锁定表格和其他形状的宽高比设置。

此 C# 代码演示了如何锁定表格的宽高比：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 取反

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格公开了 [RightToLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/table/righttoleft/) 属性，段落则拥有 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/zh/net/aspose.slides/paragraphformat/righttoleft/)。两者同时使用可确保单元格内部的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/net/applying-protection-to-presentation/) 可以禁用移动、缩放、选择等操作。这些锁定同样适用于表格。

**是否支持在单元格内部将图像作为背景插入？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。