---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 16.1.0
linktitle: Aspose.Slides cho Java 16.1.0
type: docs
weight: 200
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác đã được [added](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) hoặc [removed](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/), cũng như các thay đổi khác được giới thiệu trong API Aspose.Slides cho Java 16.1.0.
{{% /alert %}} 
## **Thay đổi API công khai**

#### **Các phương thức getRotationAngle() và setRotationAngle() đã được thêm vào các giao diện IChartTextBlockFormat và ITextFrameFormat**
Các phương thức getRotationAngle() và setRotationAngle() đã được thêm vào các giao diện com.aspose.slides.IChartTextBlockFormat và com.aspose.slides.ITextFrameFormat. Chúng cung cấp quyền truy cập vào việc xoay tùy chỉnh được áp dụng cho văn bản bên trong hộp bao quanh.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```