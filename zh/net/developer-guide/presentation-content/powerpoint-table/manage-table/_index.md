---
title: 管理表格
type: docs
weight: 10
url: /net/manage-table/
keywords: "表格, 创建表格, 访问表格, 表格长宽比, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中创建和管理 PowerPoint 演示文稿中的表格"
---

在 PowerPoint 中，表格是展示和表现信息的有效方式。以网格形式排列的单元格中的信息（按行和列排列）直观易懂。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类、 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口、 [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) 类、 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 接口以及其他类型，以帮助您在各种演示文稿中创建、更新和管理表格。

## **从头开始创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象添加到幻灯片中。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)，在顶部、底部、右侧和左侧边框上应用格式。
7. 合并表格第一行的前两个单元格。
8. 访问 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) 添加一些文本。
10. 保存修改后的演示文稿。

以下 C# 代码展示了如何在演示文稿中创建一个表格：

```c#
// 创建一个表示 PPTX 文件的 Presentation 类实例
Presentation pres = new Presentation();

// 访问第一个幻灯片
ISlide sld = pres.Slides[0];

// 定义列宽和行高
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// 向幻灯片添加一个表格形状
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
// 合并第一行的第1和第2个单元格
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 向合并的单元格添加文本
tbl.Rows[0][0].TextFrame.Text = "合并的单元格";

// 将演示文稿保存到磁盘
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **标准表格中的编号**

在标准表格中，单元格的编号简单且基于零。表格中的第一个单元格的索引为 0,0（列 0，行 0）。

例如，具有 4 列和 4 行的表格中的单元格的编号方式为：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 C# 代码展示了如何为表格中的单元格指定编号：

```c#
// 创建一个表示 PPTX 文件的 Presentation 类实例
using (Presentation pres = new Presentation())
{

    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加一个表格形状
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

2. 通过索引获取包含表格的幻灯片的引用。

3. 创建 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象并将其设置为 null。

4. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 对象，直到找到表格为止。

   如果您怀疑您正在处理的幻灯片包含一个表格，您可以简单地检查它包含的所有形状。当一个形状被识别为表格时，您可以将其强制转换为 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 对象。但如果您正在处理的幻灯片包含多个表格，则最好通过其 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) 搜索所需的表格。

5. 使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象操作表格。如下例所示，我们向表格中添加了一行。

6. 保存修改后的演示文稿。

以下 C# 代码展示了如何访问和操作现有表格：

```c#
// 创建一个表示 PPTX 文件的 Presentation 类实例
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 访问第一个幻灯片
    ISlide sld = pres.Slides[0];

    // 初始化空的 TableEx
    ITable tbl = null;

    // 遍历形状并将找到的表格的引用设置为表格
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 设置第二行第一列的文本
    tbl[0, 1].TextFrame.Text = "新";

    // 将修改后的演示文稿保存到磁盘
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **对齐表格中的文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。
4. 从表格中访问 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 对象。
5. 访问 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)。
6. 垂直对齐文本。
7. 保存修改后的演示文稿。

以下 C# 代码展示了如何在表格中对齐文本：

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

// 获取第一个幻灯片
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

// 创建文本框的段落对象
IParagraph paragraph = txtFrame.Paragraphs[0];

// 创建段落的部分对象
IPortion portion = paragraph.Portions[0];
portion.Text = "这里是文本";
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
3. 从幻灯片访问 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。
4. 为文本设置 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
5. 设置 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
6. 设置 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
7. 保存修改后的演示文稿。

以下 C# 代码展示了如何将您首选的格式设置应用于表格中的文本：

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是一个表格

// 设置表格单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// 一次调用设置表格单元格的文本对齐和右边距
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

Aspose.Slides 允许您检索表格的样式属性，以便可以将这些细节用于另一个表格或其他地方。以下 C# 代码展示了如何从预设样式的表格中获取样式属性：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改默认样式预设主题 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **锁定表格的长宽比**

几何形状的长宽比是其在不同维度大小的比率。Aspose.Slides 提供了 `AspectRatioLocked` 属性，以允许您锁定表格和其他形状的长宽比设置。

以下 C# 代码展示了如何锁定表格的长宽比：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"锁定长宽比设置: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 反转

    Console.WriteLine($"锁定长宽比设置: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```