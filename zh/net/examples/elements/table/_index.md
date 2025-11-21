---
title: 表格
type: docs
weight: 120
url: /zh/net/examples/elements/table/
keywords:
- 表格示例
- 添加表格
- 访问表格
- 删除表格
- 合并单元格
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 的 Aspose.Slides 创建和格式化表格：插入数据、合并单元格、设置边框样式、对齐内容，并支持 PPT、PPTX 和 ODP 的导入/导出。"
---

使用 **Aspose.Slides for .NET** 添加表格、访问表格、删除表格以及合并单元格的示例。

## 添加表格

创建一个包含两行两列的简单表格。
```csharp
static void Add_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```


## 访问表格

获取幻灯片上的第一个表格形状。
```csharp
static void Access_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // 访问幻灯片上的第一个表格
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```


## 删除表格

从幻灯片中删除表格。
```csharp
static void Remove_Table()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```


## 合并表格单元格

将表格相邻的单元格合并为一个单元格。
```csharp
static void Merge_Table_Cells()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```
