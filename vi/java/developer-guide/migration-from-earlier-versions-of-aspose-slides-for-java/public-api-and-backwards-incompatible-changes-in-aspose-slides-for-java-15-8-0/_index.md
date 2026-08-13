---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.8.0
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển một cách suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) hoặc [đã xóa](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Các phương thức getDoughnutHoleSize(), setDoughnutHoleSize(byte) đã được thêm vào IChartSeries và ChartSeries**
Xác định kích thước lỗ trong biểu đồ bánh donut.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```