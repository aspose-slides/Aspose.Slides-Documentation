---
title: Giao diện API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.10.0
linktitle: Aspose.Slides cho Java 14.10.0
type: docs
weight: 90
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và những thay đổi gây lỗi trong Aspose.Slides cho Java để dễ dàng di chuyển các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}}

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác [đã thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) , bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) được giới thiệu cùng API Aspose.Slides for Java 14.10.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
### **phương thức com.aspose.slides.FieldType.getFooter() đã được thêm**
Phương thức getFooter() trả về kiểu trường footer. Nó được thêm để thực hiện khả năng tạo các trường kiểu này và để việc tuần tự hoá bản trình bày hợp lệ.
### **Phần tử com.aspose.slides.ShapeElementFillSource.Own đã bị xóa**
Phần tử ShapeElementFillSource.Own đã bị xóa vì trùng lặp. Sử dụng ShapeElementFillSource.Shape thay vì ShapeElementFillSource.Own.
### **Các phương thức để xóa điểm dữ liệu và danh mục biểu đồ đã được thêm**
**Các phương thức sau, cho phép xóa điểm dữ liệu biểu đồ khỏi bộ sưu tập điểm dữ liệu biểu đồ, đã được thêm:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Phương thức sau, cho phép xóa một danh mục biểu đồ khỏi bộ sưu tập chứa, đã được thêm:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // xóa bằng ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // xóa bằng ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // xóa bằng ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Các phương thức lỗi thời của Aspose.Slides.ParagraphFormat đã bị xóa**
Các phương thức getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() và các phương thức set tương ứng đã bị xóa. Chúng đã được đánh dấu là lỗi thời từ rất lâu.
### **Các hàm tạo không hữu ích và lỗi thời đã bị xóa**
Các hàm tạo sau đã bị xóa:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)