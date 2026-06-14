---
title: Tùy chỉnh biểu đồ tròn trong bản trình bày bằng JavaScript
linktitle: Biểu đồ tròn
type: docs
url: /vi/nodejs-java/pie-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn bằng JavaScript với Aspose.Slides cho Node.js, có thể xuất ra PowerPoint, giúp bạn truyền tải dữ liệu chỉ trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát cho biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn Biểu đồ Phụ cho Biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for Node.js qua Java hiện hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách chỉ định các tùy chọn đó bằng Aspose.Slides. Để chỉ định các thuộc tính, thực hiện các bước sau:

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Chỉ định các tùy chọn biểu đồ phụ của biểu đồ.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt các thuộc tính khác nhau cho biểu đồ Pie of Pie.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Thêm biểu đồ vào slide
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Đặt các thuộc tính khác nhau
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Ghi bản trình bày ra đĩa
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Màu Tự Động cho Các Lát của Biểu đồ Tròn**

Aspose.Slides cho Node.js qua Java cung cấp API đơn giản để thiết lập màu tự động cho các lát của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề biểu đồ.
1. Đặt series đầu tiên hiển thị Giá Trị.
1. Đặt chỉ mục của bảng dữ liệu biểu đồ.
1. Lấy worksheet dữ liệu biểu đồ.
1. Xóa series và danh mục được tạo mặc định.
1. Thêm danh mục mới.
1. Thêm series mới.

Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```javascript
// Tạo một thể hiện của lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Thêm biểu đồ với dữ liệu mặc định
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Đặt tiêu đề biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Đặt series đầu tiên hiển thị Giá trị
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Đặt chỉ mục của bảng dữ liệu biểu đồ
    var defaultWorksheetIndex = 0;
    // Lấy worksheet dữ liệu biểu đồ
    var fact = chart.getChartData().getChartDataWorkbook();
    // Xóa series và danh mục được tạo mặc định
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Thêm danh mục mới
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Thêm series mới
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Bây giờ điền dữ liệu cho series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất riêng biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) (ví dụ PNG) mà không cần toàn bộ bản trình bày.