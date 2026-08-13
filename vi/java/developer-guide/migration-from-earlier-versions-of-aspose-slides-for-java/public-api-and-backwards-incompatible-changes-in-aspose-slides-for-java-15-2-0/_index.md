---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.2.0
linktitle: Aspose.Slides cho Java 15.2.0
type: docs
weight: 110
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi phá vỡ trong Aspose.Slides cho Java để di chuyển một cách suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) , bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) được giới thiệu với API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="info" %}} 

Có một số vấn đề đã biết với một số đầu dòng hình ảnh và đối tượng WordArt sẽ được sửa trong Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Các phương thức addDataPointForDoughnutSeries đã được thêm**
Hai phiên bản quá tải của phương thức IChartDataPointCollection.addDataPointForDoughnutSeries() đã được thêm để chèn các điểm dữ liệu vào chuỗi loại Doughnut.

### **Lớp com.aspose.slides.SmartArtShape đã kế thừa từ lớp com.aspose.slides.GeometryShape**
Lớp com.aspose.slides.SmartArtShape đã kế thừa từ lớp com.aspose.slides.GeometryShape. Thay đổi này cải thiện mô hình đối tượng của Aspose.Slides và thêm các tính năng mới cho lớp SmartArtShape.

### **Các phương thức IGradientStopCollection.add(...) và IGradientStopCollection.insert(...) đã được thay đổi**
Chữ ký của IGradientStop add(float position, int presetColor) đã được thay thế bằng chữ ký IGradientStop addPresetColor(float position, int presetColor).

Chữ ký của phương thức IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) đã được thay thế bằng chữ ký IGradientStop addSchemeColor(float position, int schemeColor).

Chữ ký của phương thức IGradientStopCollection void insert(int index, float position, int presetColor) đã được thay thế bằng chữ ký void insertPresetColor(int index, float position, int presetColor).

Chữ ký của phương thức IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) đã được thay thế bằng chữ ký void insertSchemeColor(int index, float position, int schemeColor).

### **Phương thức java.awt.Color getAutomaticSeriesColor() đã được thêm vào com.aspose.slides.IChartSeries**
Phương thức getAutomaticSeriesColor() trả về màu tự động của chuỗi dựa trên chỉ số chuỗi và kiểu biểu đồ. Màu này được sử dụng mặc định nếu FillType bằng NotDefined.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Phương thức để xóa điểm dữ liệu biểu đồ và danh mục biểu đồ theo chỉ mục đã được thêm**
Phương thức IChartDataPointCollection.removeAt(int index) đã được thêm để xóa điểm dữ liệu biểu đồ theo chỉ mục của nó.
Phương thức IChartCategoryCollection.removeAt(int index) đã được thêm để xóa danh mục biểu đồ theo chỉ mục của nó.

### **Giá trị PptXPptY đã được thêm vào enumeration com.aspose.slides.PropertyType**
Giá trị PptXPptY đã được thêm vào enumeration com.aspose.slides.PropertyType trong phạm vi sửa lỗi vấn đề tuần tự hóa.