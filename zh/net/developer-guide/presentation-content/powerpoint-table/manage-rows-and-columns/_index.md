---
title: 管理行和列
type: docs
weight: 20
url: /zh/net/manage-rows-and-columns/
keywords: "表格, 表格行和列, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中管理 PowerPoint 演示文稿中的表格行和列"

---

为了让您能够在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类， [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口和许多其他类型。

## **将第一行设置为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 创建一个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象并将其设置为 null。
4. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 对象以查找相关表格。
5. 将表格的第一行设置为其标题。

以下 C# 代码显示了如何将表格的第一行设置为其标题：

```c#
// 实例化 Presentation 类
Presentation pres = new Presentation("table.pptx");

// 访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 初始化 null TableEx
ITable tbl = null;

// 遍历形状并设置对表格的引用
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// 将表格的第一行设置为其标题
tbl.FirstRow = true;

// 将演示文稿保存到磁盘
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **克隆表格的行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象添加到幻灯片。
6. 克隆表格行。
7. 克隆表格列。
8. 保存修改后的演示文稿。

以下 C# 代码显示了如何克隆 PowerPoint 表格的行或列：

```c#
// 实例化 Presentation 类
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 访问第一张幻灯片
    ISlide sld = presentation.Slides[0];

    // 定义具有宽度的列和具有高度的行
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 向幻灯片添加一个表格形状
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 向第 1 行第 1 列添加一些文本
    table[0, 0].TextFrame.Text = "第 1 行 第 1 列";

    // 向第 1 行第 2 列添加一些文本
    table[1, 0].TextFrame.Text = "第 1 行 第 2 列";

    // 在表格末尾克隆第 1 行
    table.Rows.AddClone(table.Rows[0], false);

    // 向第 2 行第 1 列添加一些文本
    table[0, 1].TextFrame.Text = "第 2 行 第 1 列";

    // 向第 2 行第 2 列添加一些文本
    table[1, 1].TextFrame.Text = "第 2 行 第 2 列";

    // 将第 2 行克隆为表格的第 4 行
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 在末尾克隆第 1 列
    table.Columns.AddClone(table.Columns[0], false);

    // 在第 4 列索引处克隆第 2 列
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // 将演示文稿保存到磁盘 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **从表中移除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 定义一个 `columnWidth` 数组。 
4. 定义一个 `rowHeight` 数组。 
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象添加到幻灯片。
6. 移除表格行。
7. 移除表格列。
8. 保存修改后的演示文稿。

以下 C# 代码显示了如何从表中移除行或列：

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **在表格行级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片访问相关 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
4. 设置第一行单元格的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。 
5. 设置第一行单元格的 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。 
6. 设置第二行单元格的 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。 
7. 保存修改后的演示文稿。

以下 C# 代码演示了该操作。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// 设置第一行单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 设置第一行单元格的文本对齐方式和右边距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 设置第二行单元格的文本垂直类型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// 将演示文稿保存到磁盘
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **在表格列级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片访问相关 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
4. 设置第一列单元格的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。 
5. 设置第一列单元格的 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。 
6. 设置第二列单元格的 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。 
7. 保存修改后的演示文稿。

以下 C# 代码演示了该操作：

```c#
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// 设置第一列单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 在一次调用中设置第一列单元格的文本对齐方式和右边距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 设置第二列单元格的文本垂直类型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// 将演示文稿保存到磁盘
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。以下 C# 代码展示了如何从表格预设样式中获取样式属性：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改默认样式预设主题 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```