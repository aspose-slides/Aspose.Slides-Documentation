---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides for Java 15.8.0
linktitle: Aspose.Slides cho Java 15.8.0
type: docs
weight: 160
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để dễ dàng di chuyển các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) hoặc [bị loại bỏ](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), cùng các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Public API Changes**
#### **Methods getDoughnutHoleSize(), setDoughnutHoleSize(byte) have been added to IChartSeries and ChartSeries**
Xác định kích thước của lỗ trong biểu đồ donut.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```