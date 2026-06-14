---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình trên Android
linktitle: Biểu đồ Bong bóng
type: docs
url: /vi/androidjava/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỷ lệ kích thước
- cách biểu diễn kích thước
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho Android qua Java để nâng cao việc trực quan hóa dữ liệu của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chọn tùy chỉnh cụ thể: thay đổi tỷ lệ kích thước bong bóng thông qua phương thức `setBubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua phương thức `setBubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỷ lệ kích thước của nó và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần FAQ ngắn giải thích việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích rằng xuất file sẽ giữ nguyên giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Tỷ lệ Kích thước Biểu đồ Bong bóng**
Aspose.Slides for Android via Java cung cấp hỗ trợ cho việc thay đổi tỷ lệ kích thước biểu đồ bong bóng. Trong Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) và [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) đã được thêm vào. Ví dụ mẫu dưới đây được đưa ra.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Biểu thị Dữ liệu dưới dạng Kích thước Biểu đồ Bong bóng**
Các phương thức [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) và [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) đã được thêm vào các giao diện [IChartSeries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartSeriesGroup) và các lớp liên quan. **BubbleSizeRepresentation** xác định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) và [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Do đó, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/BubbleSizeRepresentationType) đã được thêm vào để xác định các cách biểu thị dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được đưa ra dưới đây.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**"Biểu đồ bong bóng có hiệu ứng 3-D" có được hỗ trợ không, và nó khác gì so với biểu đồ thông thường?**

Có. Có một loại biểu đồ riêng, "Bubble with 3-D". Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục bổ sung; dữ liệu vẫn là X‑Y‑S (kích thước). Loại này có sẵn trong lớp [chart type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/).

**Có giới hạn về số lượng series và points trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu. Bạn nên giữ số lượng điểm ở mức hợp lý để đảm bảo độ đọc được và tốc độ render.

**Xuất file sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất ra các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ cho việc in ấn.