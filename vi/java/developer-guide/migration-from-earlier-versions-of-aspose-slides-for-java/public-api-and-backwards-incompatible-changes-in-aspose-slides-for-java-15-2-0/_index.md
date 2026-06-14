---
title: API Công khai và Các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.2.0
linktitle: Aspose.Slides cho Java 15.2.0
type: docs
weight: 110
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển nhanh chóng các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}}

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác đã được [added](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/), bất kỳ hạn chế mới nào và các [changes](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) được giới thiệu trong API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}}

Có một số vấn đề đã biết với một số bullet hình ảnh và đối tượng WordArt sẽ được khắc phục trong Aspose.Slides for Java 15.2.0.

{{% /alert %}}
## **Public API Changes**
### **addDataPointForDoughnutSeries methods have been added**
Hai overload của phương thức IChartDataPointCollection.addDataPointForDoughnutSeries() đã được thêm vào để thêm các điểm dữ liệu vào series loại Doughnut.
### **com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class**
Lớp com.aspose.slides.SmartArtShape đã kế thừa từ lớp com.aspose.slides.GeometryShape. Thay đổi này cải thiện mô hình đối tượng Aspose.Slides và bổ sung các tính năng mới cho lớp SmartArtShape.
### **IGradientStopCollection.add(...) and IGradientStopCollection.insert(...) methods have been changed**
Chữ ký của IGradientStop add(float position, int presetColor) được thay thế bằng chữ ký IGradientStop addPresetColor(float position, int presetColor).

Chữ ký của phương thức IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) được thay thế bằng chữ ký IGradientStop addSchemeColor(float position, int schemeColor).

Chữ ký của phương thức IGradientStopCollection void insert(int index, float position, int presetColor) được thay thế bằng chữ ký void insertPresetColor(int index, float position, int presetColor).

Chữ ký của phương thức IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) được thay thế bằng chữ ký void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor() method has been added to com.aspose.slides.IChartSeries**
Phương thức getAutomaticSeriesColor() trả về màu tự động của series dựa trên chỉ mục series và kiểu biểu đồ. Màu này được sử dụng mặc định nếu FillType bằng NotDefined.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Method for removing chart data point and chart category by its index has been added**
Phương thức IChartDataPointCollection.removeAt(int index) đã được thêm để xóa điểm dữ liệu của biểu đồ theo chỉ mục.
Phương thức IChartCategoryCollection.removeAt(int index) đã được thêm để xóa danh mục biểu đồ theo chỉ mục.
### **PptXPptY value has been added to com.aspose.slides.PropertyType enumeration**
Giá trị PptXPptY đã được thêm vào enumeration com.aspose.slides.PropertyType trong phạm vi sửa lỗi vấn đề tuần tự hoá.