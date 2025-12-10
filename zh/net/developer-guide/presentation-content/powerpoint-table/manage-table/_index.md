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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的 C# 示例代码，以简化表格工作流程。"
---

PowerPoint 中的表格是展示和表达信息的高效方式。网格单元格（按行列排列）中的信息直观易懂。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 接口以及其他类型，帮助您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。  
6. 遍历每个 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)，为上、下、左、右边框设置格式。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) 添加文本。  
10. 保存修改后的演示文稿。

下面的 C# 代码演示了如何在演示文稿中创建表格：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
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
// 合并第 1 行的第 1、2 个单元格
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 为合并后的单元格添加文本
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// 将演示文稿保存到磁盘
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **标准表格中的编号**

在标准表格中，单元格的编号是直观的零基索引。表格的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 C# 代码演示了如何为表格中的单元格指定编号：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
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

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  

2. 通过索引获取包含表格的幻灯片引用。  

3. 创建 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象并将其设为 null。  

4. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 对象，直至找到表格。  

   如果您确信当前幻灯片仅包含一个表格，可以直接检查其所有形状。当形状被识别为表格时，可将其强制转换为 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 对象。但如果幻灯片包含多个表格，最好通过其 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) 来搜索所需的表格。  

5. 使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象对表格进行操作。下面的示例向表格添加了一行新行。  

6. 保存修改后的演示文稿。

下面的 C# 代码演示了如何访问并操作现有表格：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 将 TableEx 初始化为 null
    ITable tbl = null;

    // 遍历形状并设置对找到的表格的引用
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 设置第二行第一列的文本
    tbl[0, 1].TextFrame.Text = "New";

    // 将修改后的演示文稿保存到磁盘
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **对表格中的文本进行对齐**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。  
4. 从表格中获取 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 对象。  
5. 获取 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 C# 代码演示了如何对表格中的文本进行对齐：
```c#
// 创建 Presentation 类的实例
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

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片获取 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。  
4. 设置文本的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。  
5. 设置 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。  
6. 设置 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 保存修改后的演示文稿。

下面的 C# 代码演示了如何对表格中的文本应用首选的格式设置：
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便将这些细节用于其他表格或其他位置。下面的 C# 代码演示了如何从表格预设样式获取样式属性：
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改默认样式预设主题
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **锁定表格的宽高比**

几何形状的宽高比是其各维度尺寸的比例。Aspose.Slides 提供了 `AspectRatioLocked` 属性，帮助您锁定表格及其他形状的宽高比设置。

下面的 C# 代码演示了如何锁定表格的宽高比：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 取反

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**我可以为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格公开了 [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) 属性，段落则具有 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/)。同时使用可确保单元格内部的 RTL 顺序和渲染正确。

**如何防止用户在最终文件中移动或调整表格大小？**

使用 [shape locks](/slides/zh/net/applying-protection-to-presentation/) 禁用移动、缩放、选择等。这些锁同样适用于表格。

**是否支持在单元格内部将图片设为背景？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/)，图片会根据所选模式（拉伸或平铺）覆盖单元格区域。