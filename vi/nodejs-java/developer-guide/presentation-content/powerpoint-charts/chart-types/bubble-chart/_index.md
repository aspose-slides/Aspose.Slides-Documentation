---
title: Tùy chỉnh biểu đồ bong bóng trong bản trình chiếu bằng JavaScript
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/nodejs-java/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỷ lệ kích thước
- biểu diễn kích thước
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint bằng JavaScript và Aspose.Slides cho Node.js thông qua Java để nâng cao việc trực quan hóa dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chọn tùy chỉnh cụ thể: thay đổi tỷ lệ kích thước bong bóng thông qua phương thức `setBubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua phương thức `setBubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỷ lệ kích thước, và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một mục FAQ ngắn giải đáp hỗ trợ cho loại biểu đồ "Bubble with 3-D", lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích việc xuất khẩu giữ nguyên giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Tỷ lệ Kích thước Biểu đồ Bong bóng**
Aspose.Slides cho Node.js qua Java cung cấp hỗ trợ cho việc thay đổi tỷ lệ kích thước biểu đồ bong bóng. Trong Aspose.Slides cho Node.js qua Java, các phương thức [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) và [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) đã được thêm vào. Ví dụ mẫu dưới đây được đưa ra.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Biểu diễn Dữ liệu dưới dạng Kích thước Biểu đồ Bong bóng**
Các phương thức [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) và [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) đã được thêm vào lớp [ChartSeries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartSeriesGroup) và các lớp liên quan. **BubbleSizeRepresentation** xác định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị có thể là: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) và [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Do đó, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BubbleSizeRepresentationType) đã được thêm vào để chỉ định các cách có thể để biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được đưa ra dưới đây.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Biểu đồ bong bóng có hiệu ứng 3-D có được hỗ trợ không, và khác gì so với biểu đồ thông thường?**

Có. Có một loại biểu đồ riêng, "Bubble with 3-D". Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục bổ sung; dữ liệu vẫn là X-Y-S (kích thước). Loại này có sẵn trong enumeration [chart type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/).

**Có giới hạn về số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cố định ở mức API; các ràng buộc được quyết định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Được khuyến nghị giữ số lượng điểm ở mức hợp lý để dễ đọc và tốc độ render.

**Việc xuất khẩu sẽ ảnh hưởng đến giao diện của biểu đồ bong bóng (PDF, hình ảnh) như thế nào?**

Xuất sang các định dạng được hỗ trợ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ lớn cho việc in.