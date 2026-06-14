---
title: Bảng
type: docs
weight: 120
url: /vi/net/examples/elements/table/
keywords:
- bảng
- thêm bảng
- truy cập bảng
- xóa bảng
- hợp nhất ô
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Làm việc với bảng trong Aspose.Slides cho .NET: tạo, định dạng, hợp nhất ô, áp dụng kiểu, nhập dữ liệu và xuất với các ví dụ C# cho PPT, PPTX và ODP."
---
Các ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô bằng cách sử dụng **Aspose.Slides for .NET**.

## **Thêm bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

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

## **Truy cập bảng**

Lấy hình dạng bảng đầu tiên trên slide.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // Truy cập bảng đầu tiên trên slide.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **Xóa bảng**

Xóa một bảng khỏi slide.

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

## **Hợp nhất ô bảng**

Hợp nhất các ô liền kề của bảng thành một ô duy nhất.

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