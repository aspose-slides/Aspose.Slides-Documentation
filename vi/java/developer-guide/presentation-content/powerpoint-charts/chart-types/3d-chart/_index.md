---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng Java
linktitle: Biểu đồ 3D
type: docs
url: /vi/java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Học cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho Java, hỗ trợ các tệp PPT và PPTX—nâng cao bản trình bày của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bản trình bày, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập hiển thị 3D cần thiết và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Thiết lập các thuộc tính RotationX, RotationY và DepthPercents của biểu đồ 3D**
Aspose.Slides for Java cung cấp API đơn giản để thiết lập các thuộc tính này. Bài viết sau sẽ giúp bạn cách thiết lập các thuộc tính khác nhau như **X,Y Rotation, DepthPercents**… Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt các thuộc tính Rotation3D.
5. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```java
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm biểu đồ với dữ liệu mặc định
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Đặt chỉ mục của sheet dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;
    
    // Lấy worksheet dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Thêm series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Thêm danh mục
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Đặt các thuộc tính Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Lấy series thứ hai của biểu đồ
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Bây giờ đang điền dữ liệu cho series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Đặt giá trị OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Ghi bản trình bày ra đĩa
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được khai báo qua lớp [ChartType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đang sử dụng.

**Tôi có thể lấy hình raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) hoặc [renderm toàn slide](/slides/vi/java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần một bản preview pixel‑perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc tạo và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp trực quan. Để có kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng các kết cấu nặng trên tường và khu vực vẽ, giới hạn số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.