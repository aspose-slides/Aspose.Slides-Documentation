---
title: Biểu đồ
type: docs
weight: 60
url: /vi/net/examples/elements/chart/
keywords:
- biểu đồ
- thêm biểu đồ
- truy cập biểu đồ
- xóa biểu đồ
- cập nhật biểu đồ
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Thành thạo biểu đồ với Aspose.Slides cho .NET: tạo, định dạng, liên kết dữ liệu và xuất biểu đồ sang PPT, PPTX và ODP với các ví dụ C#."
---
Các ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for .NET**. Các đoạn mã dưới đây minh họa các thao tác cơ bản với biểu đồ.

## **Thêm biểu đồ**

Phương thức này thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Truy cập biểu đồ**

Sau khi tạo biểu đồ, bạn có thể lấy nó thông qua bộ sưu tập hình dạng.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Truy cập biểu đồ đầu tiên trên slide.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Xóa biểu đồ**

Đoạn mã dưới đây xóa một biểu đồ khỏi slide.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Xóa biểu đồ.
    slide.Shapes.Remove(chart);
}
```

## **Cập nhật dữ liệu biểu đồ**

Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Thay đổi tiêu đề biểu đồ.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```