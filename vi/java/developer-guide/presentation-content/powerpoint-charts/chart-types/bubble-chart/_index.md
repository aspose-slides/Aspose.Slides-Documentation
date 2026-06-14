---
title: Tùy chỉnh biểu đồ bong bóng trong bản trình chiếu bằng Java
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/java/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỷ lệ kích thước
- biểu diễn kích thước
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho Java để nâng cao việc trực quan hóa dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó đề cập đến hai tùy chọn tùy chỉnh cụ thể: điều chỉnh tỷ lệ kích thước bong bóng bằng phương thức `setBubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn bằng phương thức `setBubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo một biểu đồ bong bóng, điều chỉnh tỷ lệ kích thước và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn, giải thích việc hỗ trợ loại biểu đồ “Bubble with 3‑D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu suất và phiên bản PowerPoint mục tiêu, và mô tả việc xuất khẩu giữ nguyên giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Điều chỉnh tỷ lệ kích thước biểu đồ bong bóng**
Aspose.Slides for Java cung cấp hỗ trợ cho việc điều chỉnh tỷ lệ kích thước biểu đồ bong bóng. Trong Aspose.Slides cho Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) và [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) đã được bổ sung. Ví dụ mẫu dưới đây được đưa ra. 

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

## **Biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng**
Các phương thức [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) và [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) đã được thêm vào các giao diện [IChartSeries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartSeriesGroup) và các lớp liên quan. **BubbleSizeRepresentation** xác định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/BubbleSizeRepresentationType#Area) và [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Do đó, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/BubbleSizeRepresentationType) đã được bổ sung để chỉ ra các cách có thể biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được đưa ra bên dưới.

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

## **Câu hỏi thường gặp**

**Biểu đồ bong bóng với hiệu ứng 3‑D có được hỗ trợ không, và nó khác gì so với biểu đồ thông thường?**

Có. Có một loại biểu đồ riêng, “Bubble with 3‑D”. Nó áp dụng kiểu dáng 3‑D cho các bong bóng nhưng không thêm trục phụ nào; dữ liệu vẫn là X‑Y‑S (kích thước). Loại này có sẵn trong lớp [chart type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) .

**Có giới hạn nào về số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc phụ thuộc vào hiệu suất và phiên bản PowerPoint mục tiêu. Được khuyến nghị giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Xuất khẩu sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất sang các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine của Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc render đồ họa biểu đồ thông thường áp dụng (độ phân giải, khử răng cưa), vì vậy nên chọn DPI đủ cao cho việc in ấn.