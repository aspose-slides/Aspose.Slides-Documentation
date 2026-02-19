---
title: 表格
type: docs
weight: 120
url: /zh/net/examples/elements/table/
keywords:
- 表格
- 添加表格
- 访问表格
- 删除表格
- 合并单元格
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用表格：创建、格式化、合并单元格、应用样式、导入数据，并使用 C# 示例导出为 PPT、PPTX 和 ODP。"
---
使用 **Aspose.Slides for .NET** 添加表格、访问表格、删除表格以及合并单元格的示例。

## **添加表格**

创建一个包含两行两列的简单表格。

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **访问表格**

获取幻灯片上的第一个表格形状。

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // 访问幻灯片上的第一个表格。
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **删除表格**

从幻灯片中删除表格。

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **合并表格单元格**

将表格中相邻的单元格合并为一个单元格。

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```