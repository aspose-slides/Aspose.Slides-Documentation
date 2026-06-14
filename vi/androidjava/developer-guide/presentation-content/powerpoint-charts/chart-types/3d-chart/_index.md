---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình trên Android
linktitle: Biểu đồ 3D
type: docs
url: /vi/androidjava/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3‑D trong Aspose.Slides cho Android bằng Java, hỗ trợ tệp PPT và PPTX — nâng cao các bài thuyết trình của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các cài đặt `Rotation3D` như `RotationX`, `RotationY`, `DepthPercents` và `RightAngleAxes`. Nó hướng dẫn tạo một bản trình chiếu, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các cài đặt hiển thị 3D cần thiết, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các thuộc tính RotationX, RotationY và DepthPercents cho biểu đồ 3D**
Aspose.Slides for Android via Java cung cấp một API đơn giản để đặt các thuộc tính này. Bài viết tiếp theo sẽ giúp bạn cách thiết lập các thuộc tính khác nhau như **X,Y Rotation, DepthPercents** v.v. Mã mẫu áp dụng việc cài đặt các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt các thuộc tính Rotation3D.
5. Ghi bản trình chiếu đã chỉnh sửa vào tệp PPTX.

```java
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm biểu đồ với dữ liệu mặc định
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Đặt chỉ mục của bảng dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;
    
    // Lấy bảng tính dữ liệu biểu đồ
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
    
    // Lấy series biểu đồ thứ hai
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
    
    // Write presentation to disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được cung cấp thông qua lớp [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể nhận được hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) hoặc [render toàn bộ slide](/slides/vi/androidjava/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần một bản xem trước chính xác pixel hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng khi tạo và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng texture nặng trên tường và vùng vẽ, giới hạn số điểm dữ liệu cho mỗi chuỗi khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để phù hợp với màn hình hoặc nhu cầu in ấn mục tiêu.