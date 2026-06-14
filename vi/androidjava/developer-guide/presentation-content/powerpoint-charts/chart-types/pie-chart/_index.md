---
title: Tùy chỉnh biểu đồ tròn trong bài thuyết trình trên Android
linktitle: Biểu đồ tròn
type: docs
url: /vi/androidjava/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ đồ thị
- màu lát cắt
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong Java với Aspose.Slides cho Android, có thể xuất ra PowerPoint, nâng cao khả năng truyền tải dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó chỉ ra cách cấu hình tùy chọn biểu đồ phụ cho các biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát cắt cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào slide, điều chỉnh thiết lập chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie**
Aspose.Slides for Android via Java hiện hỗ trợ tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong mục này, chúng tôi sẽ chỉ cho bạn cách chỉ định các tùy chọn đó bằng Aspose.Slides. Để chỉ định các thuộc tính, thực hiện các bước sau:

1. Tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Chỉ định tùy chọn biểu đồ phụ cho biểu đồ.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các thuộc tính khác nhau của biểu đồ Pie of Pie.

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

## **Đặt màu tự động cho các lát cắt của biểu đồ tròn**
Aspose.Slides for Android via Java cung cấp API đơn giản để thiết lập màu tự động cho các lát cắt của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề cho biểu đồ.
1. Đặt chuỗi đầu tiên hiển thị giá trị.
1. Đặt chỉ mục của bảng dữ liệu biểu đồ.
1. Lấy bảng tính dữ liệu biểu đồ.
1. Xóa các chuỗi và danh mục được tạo mặc định.
1. Thêm danh mục mới.
1. Thêm chuỗi mới.

Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation();
try {
    // Thêm biểu đồ với dữ liệu mặc định
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Đặt chuỗi đầu tiên hiển thị giá trị
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Đặt chỉ mục của bảng dữ liệu biểu đồ
    int defaultWorksheetIndex = 0;

    // Lấy bảng tính dữ liệu biểu đồ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Xóa các chuỗi và danh mục được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Thêm danh mục mới
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Thêm chuỗi mới
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Bây giờ đang điền dữ liệu cho chuỗi
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

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [supports](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [export the chart itself as an image](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (như PNG) mà không cần xuất toàn bộ bản trình bày.