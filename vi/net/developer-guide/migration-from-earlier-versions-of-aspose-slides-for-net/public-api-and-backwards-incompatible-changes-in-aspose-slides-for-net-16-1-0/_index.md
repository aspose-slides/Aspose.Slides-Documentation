---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 16.1.0
linktitle: Aspose.Slides cho .NET 16.1.0
type: docs
weight: 220
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển giải pháp trình chiếu PowerPoint PPT, PPTX và ODP của bạn một cách suôn sẻ."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) hoặc [đã xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 16.1.0.

{{% /alert %}} 
## **Thay đổi API công cộng**


#### **Thuộc tính RotationAngle đã được thêm vào các giao diện IChartTextBlockFormat và ITextFrameFormat**
Thuộc tính RotationAngle đã được thêm vào các giao diện Aspose.Slides.Charts.IChartTextBlockFormat và Aspose.Slides.ITextFrameFormat. Nó chỉ định góc quay tùy chỉnh được áp dụng cho văn bản bên trong hộp giới hạn.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException đã được chuyển từ Aspose.Slides.Odp sang không gian tên Aspose.Slides**