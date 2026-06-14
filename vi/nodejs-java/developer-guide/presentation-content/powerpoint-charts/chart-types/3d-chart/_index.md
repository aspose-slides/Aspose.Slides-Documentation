---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình bằng JavaScript
linktitle: Biểu đồ 3D
type: docs
url: /vi/nodejs-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho Node.js qua Java, hỗ trợ các tệp PPT và PPTX—nâng cao bài thuyết trình của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bài thuyết trình, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập chế độ xem 3D yêu cầu, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các thuộc tính RotationX, RotationY và DepthPercents của biểu đồ 3D**

Aspose.Slides for Node.js via Java cung cấp một API đơn giản để đặt các thuộc tính này. Bài viết sau sẽ giúp bạn cách đặt các thuộc tính khác nhau như **X,Y Rotation, DepthPercents** vv. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt các thuộc tính Rotation3D.
1. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm biểu đồ với dữ liệu mặc định
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Đặt chỉ số của bảng dữ liệu biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Thêm chuỗi
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Thêm danh mục
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Đặt thuộc tính Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Lấy chuỗi biểu đồ thứ hai
    var series = chart.getChartData().getSeries().get_Item(1);
    // Bây giờ đang điền dữ liệu cho chuỗi
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Đặt giá trị OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Ghi bài thuyết trình vào đĩa
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Những loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được khai thác qua enumeration [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể lấy ảnh raster của biểu đồ 3D để báo cáo hoặc đăng lên web không?**

Có. Bạn có thể xuất biểu đồ ra hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) hoặc [render toàn bộ slide](/slides/vi/nodejs-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước pixel-perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp trực quan. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên tường và khu vực vẽ, hạn chế số điểm dữ liệu cho mỗi series khi có thể, và render ra kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn mục tiêu.