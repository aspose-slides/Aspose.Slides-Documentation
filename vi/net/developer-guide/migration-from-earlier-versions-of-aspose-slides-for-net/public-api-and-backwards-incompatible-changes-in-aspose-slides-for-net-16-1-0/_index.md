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
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: Xem xét các cập nhật API công cộng và những thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn.
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) và những thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 16.1.0.

{{% /alert %}} 
## **Public API Changes**


#### **Property RotationAngle Has Been Added to IChartTextBlockFormat and ITextFrameFormat Interfaces**
Thuộc tính RotationAngle đã được thêm vào các giao diện Aspose.Slides.Charts.IChartTextBlockFormat và Aspose.Slides.ITextFrameFormat. Thuộc tính này chỉ định góc quay tùy chỉnh được áp dụng cho văn bản bên trong hộp giới hạn.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


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
#### **OdpException Moved from Aspose.Slides.Odp to Aspose.Slides Namespace**
OdpException đã được chuyển từ Aspose.Slides.Odp sang không gian tên Aspose.Slides