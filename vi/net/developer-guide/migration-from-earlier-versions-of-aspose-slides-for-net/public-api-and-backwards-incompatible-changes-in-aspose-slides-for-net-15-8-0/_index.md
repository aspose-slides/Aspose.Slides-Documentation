---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.8.0
linktitle: Aspose.Slides cho .NET 15.8.0
type: docs
weight: 190
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho .NET để dễ dàng di chuyển các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính được [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Property DoughnutHoleSize Has Been Added to IChartSeries and ChartSeries**
Thuộc tính DoughnutHoleSize đã được thêm vào IChartSeries và ChartSeries.

Xác định kích thước của lỗ trong biểu đồ bánh rán.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```