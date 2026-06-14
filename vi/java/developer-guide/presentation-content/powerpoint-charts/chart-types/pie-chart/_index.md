---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày bằng Java
linktitle: Biểu Đồ Tròn
type: docs
url: /vi/java/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong Java với Aspose.Slides, có thể xuất sang PowerPoint, nâng cao khả năng kể chuyện dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình tùy chọn biểu đồ phụ cho các biểu đồ Pie of Pie và Bar of Pie, và cách bật màu tự động cho các lát của biểu đồ tròn chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào một slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn Biểu đồ Phụ cho Biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides cho Java hiện hỗ trợ tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách chỉ định các tùy chọn đó bằng Aspose.Slides. Để chỉ định các thuộc tính, thực hiện các bước sau:

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Thêm biểu đồ vào slide.
3. Xác định tùy chọn biểu đồ phụ cho biểu đồ.
4. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt các thuộc tính khác nhau cho biểu đồ Pie of Pie.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Thêm biểu đồ vào slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Đặt các thuộc tính khác nhau
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Ghi bản trình bày ra đĩa
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Màu Tự Động cho Các Lát Biểu Đồ Pie**

Aspose.Slides cho Java cung cấp API đơn giản để đặt màu tự động cho các lát của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt tiêu đề cho biểu đồ.
5. Đặt series đầu tiên hiển thị giá trị.
6. Đặt chỉ mục của bảng dữ liệu biểu đồ.
7. Lấy bảng dữ liệu của biểu đồ.
8. Xóa series và danh mục được tạo mặc định.
9. Thêm danh mục mới.
10. Thêm series mới.

Ghi bản trình bày đã sửa đổi thành tệp PPTX.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Thêm biểu đồ với dữ liệu mặc định
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Đặt tiêu đề biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Đặt series đầu tiên để hiển thị giá trị
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Đặt chỉ mục của bảng dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;

    // Lấy bảng dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Xóa series và danh mục được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Thêm danh mục mới
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Thêm series mới
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**

Có, thư viện [supports](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Can I export just the chart as an image (for example, PNG)?**

Có, bạn có thể [export the chart itself as an image](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-) (ví dụ PNG) mà không cần toàn bộ bản trình bày.