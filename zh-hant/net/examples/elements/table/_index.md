---
title: 表格
type: docs
weight: 120
url: /zh-hant/net/examples/elements/table/
keywords:
- 表格
- 新增表格
- 存取表格
- 移除表格
- 合併儲存格
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 處理表格：建立、格式化、合併儲存格、套用樣式、匯入資料，並以 C# 範例匯出 PPT、PPTX 和 ODP。"
---
使用 **Aspose.Slides for .NET** 添加表格、存取表格、移除表格以及合併儲存格的範例。

## **新增表格**

建立一個包含兩列兩欄的簡易表格。

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

## **存取表格**

取得投影片上的第一個表格形狀。

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // 存取投影片上的第一個表格。
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **移除表格**

從投影片中刪除表格。

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

## **合併表格儲存格**

將表格相鄰的儲存格合併為單一儲存格。

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