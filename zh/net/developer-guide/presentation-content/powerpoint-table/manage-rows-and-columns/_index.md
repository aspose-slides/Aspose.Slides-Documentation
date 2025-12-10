---
title: 在 .NET 中管理 PowerPoint 表格的行和列
linktitle: 行和列
type: docs
weight: 20
url: /zh/net/manage-rows-and-columns/
keywords:
- 表格行
- 表格列
- 首行
- 表格标题
- 克隆行
- 克隆列
- 复制行
- 复制列
- 删除行
- 删除列
- 行文本格式化
- 列文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中管理表格的行和列，加快演示文稿编辑和数据更新。"
---

为了让您在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 接口以及许多其他类型。 

## **将首行设为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿。 
2. 通过索引获取幻灯片的引用。 
3. 创建一个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象并将其设为 null。 
4. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 对象以找到相应的表格。 
5. 将表格的首行设为标题行。 

下面的 C# 代码演示了如何将表格的首行设为标题行：
```c#
// 实例化 Presentation 类
Presentation pres = new Presentation("table.pptx");

// 访问第一张幻灯片
ISlide sld = pres.Slides[0];

// 将 TableEx 初始化为 null
ITable tbl = null;

// 遍历形状并设置对表格的引用
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// 将表格的首行设为标题行
tbl.FirstRow = true;

// 将演示文稿保存到磁盘
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **克隆表格行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 定义 `columnWidth` 数组。 
4. 定义 `rowHeight` 数组。 
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
6. 克隆表格行。 
7. 克隆表格列。 
8. 保存修改后的演示文稿。 

下面的 C# 代码演示了如何克隆 PowerPoint 表格的行或列：
```c#
 // 实例化 Presentation 类
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 访问第一张幻灯片
    ISlide sld = presentation.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 向幻灯片添加表格形状
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 向第1行第1列单元格添加文本
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 向第1行第2列单元格添加文本
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // 在表格末尾复制第1行
    table.Rows.AddClone(table.Rows[0], false);

    // 向第2行第1列单元格添加文本
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 向第2行第2列单元格添加文本
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // 将第2行复制为表格的第4行
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 在末尾复制第一列
    table.Columns.AddClone(table.Columns[0], false);

    // 在第4列位置复制第二列
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // 将演示文稿保存到磁盘 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **从表格中删除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 定义 `columnWidth` 数组。 
4. 定义 `rowHeight` 数组。 
5. 通过 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法向幻灯片添加一个 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
6. 删除表格行。 
7. 删除表格列。 
8. 保存修改后的演示文稿。 

下面的 C# 代码演示了如何从表格中删除行或列：
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
3. 从幻灯片访问相应的 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
4. 设置首行单元格的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。 
5. 设置首行单元格的 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。 
6. 设置第二行单元格的 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。 
7. 保存修改后的演示文稿。 

下面的 C# 代码演示了此操作。
```c#
 // 创建 Presentation 类的实例
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// 设置首行单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 设置首行单元格的文本对齐方式和右侧边距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 设置第二行单元格的文字垂直方向类型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// 将演示文稿保存到磁盘
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **在表格列级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例并加载演示文稿， 
2. 通过索引获取幻灯片的引用。 
3. 从幻灯片访问相应的 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 对象。 
4. 设置首列单元格的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。 
5. 设置首列单元格的 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 和 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。 
6. 设置第二列单元格的 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。 
7. 保存修改后的演示文稿。 

下面的 C# 代码演示了此操作： 
```c#
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 假设第一张幻灯片上的第一个形状是表格

// 设置首列单元格的字体高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 设置首列单元格的文本对齐方式和右侧边距（一次调用）
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 设置第二列单元格的文字垂直方向类型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// 将演示文稿保存到磁盘
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便将这些细节用于其他表格或其他位置。下面的 C# 代码演示了如何从表格预设样式中获取样式属性： 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改默认样式预设主题
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**我可以对已经创建的表格应用 PowerPoint 主题/样式吗？**

可以。表格会继承幻灯片/版式/母版的主题，并且您仍然可以在此主题之上覆盖填充、边框和文字颜色。

**我可以像在 Excel 中那样对表格行进行排序吗？**

不能，Aspose.Slides 表格没有内置的排序或筛选功能。请先在内存中对数据进行排序，然后按该顺序重新填充表格行。

**我可以在保留特定单元格自定义颜色的同时使用带状（条纹）列吗？**

可以。开启带状列后，可对特定单元格使用局部格式覆盖；单元格级别的格式优先于表格样式。