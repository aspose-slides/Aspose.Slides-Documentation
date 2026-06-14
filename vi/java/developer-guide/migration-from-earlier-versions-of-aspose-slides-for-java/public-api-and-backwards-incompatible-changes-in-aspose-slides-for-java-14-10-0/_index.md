---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.10.0
linktitle: Aspose.Slides cho Java 14.10.0
type: docs
weight: 90
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- di chuyển
- mã di sản
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển một cách suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác, bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) được giới thiệu với API Aspose.Slides for Java 14.10.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
### **phương thức com.aspose.slides.FieldType.getFooter() đã được thêm**
Phương thức getFooter() trả về kiểu trường footer. Nó đã được thêm để cho phép tạo các trường kiểu này và để việc tuần tự hoá bản trình bày hợp lệ.
### **Phần tử com.aspose.slides.ShapeElementFillSource.Own đã bị xóa**
Phần tử ShapeElementFillSource.Own đã bị xóa vì trùng lặp. Hãy sử dụng ShapeElementFillSource.Shape thay cho ShapeElementFillSource.Own.
### **Các phương thức để xóa điểm dữ liệu biểu đồ, danh mục đã được thêm**
**Các phương thức sau, cho phép xóa một điểm dữ liệu biểu đồ khỏi bộ sưu tập điểm dữ liệu biểu đồ đã được thêm:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Phương thức sau, cho phép xóa một danh mục biểu đồ khỏi bộ sưu tập chứa nó đã được thêm:**

IChartCategory.remove()

``` java

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
### **Các phương thức Aspose.Slides.ParagraphFormat đã lỗi thời đã bị xóa**
Các phương thức getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() và các phương thức set tương ứng đã bị xóa. Chúng đã được đánh dấu là lỗi thời từ lâu.
### **Các hàm khởi tạo không hữu ích và đã lỗi thời đã bị xóa**
Các hàm khởi tạo sau đã bị xóa:

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