---
title: Tùy chỉnh biểu đồ tròn trong các bài thuyết trình bằng Python qua Java
linktitle: Biểu đồ tròn
type: docs
url: /vi/python-java/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong Python qua Java với Aspose.Slides, có thể xuất ra PowerPoint, nâng cao khả năng kể chuyện dữ liệu của bạn trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ dạng tròn trong Aspose.Slides. Nó cho thấy cách cấu hình các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát của biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào một slide, điều chỉnh cài đặt chuỗi và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn biểu đồ phụ cho Pie of Pie và Bar of Pie**

Aspose.Slides for Python via Java hỗ trợ các tùy chọn biểu đồ phụ cho biểu đồ Pie of Pie và Bar of Pie. Phần này cho thấy cách chỉ định các tùy chọn đó bằng Aspose.Slides. Thực hiện các bước sau:

1. Tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm một biểu đồ vào slide.
1. Chỉ định các tùy chọn biểu đồ phụ cho biểu đồ.
1. Ghi bản trình bày ra đĩa.

Ví dụ dưới đây đặt các thuộc tính khác nhau cho biểu đồ Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    # Thêm một biểu đồ vào slide.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Thiết lập các thuộc tính khác nhau.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Ghi bản trình bày ra đĩa.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt màu tự động cho các lát biểu đồ tròn**

Aspose.Slides for Python via Java cung cấp một API đơn giản để đặt màu tự động cho các lát của biểu đồ tròn. Ví dụ sau minh họa cách áp dụng các thiết lập này.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề cho biểu đồ.
1. Đặt chỉ số của worksheet dữ liệu biểu đồ.
1. Lấy workbook dữ liệu biểu đồ.
1. Xóa các chuỗi và danh mục mặc định.
1. Thêm các danh mục mới.
1. Thêm một chuỗi mới.
1. Đặt chuỗi mới để hiển thị giá trị.
1. Ghi bản trình bày đã sửa đổi ra file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    # Thêm một biểu đồ với dữ liệu mặc định.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Đặt tiêu đề cho biểu đồ.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Đặt chỉ số của worksheet dữ liệu biểu đồ.
    default_worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Xóa các chuỗi và danh mục mặc định.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Thêm các danh mục mới.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Thêm một chuỗi mới.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Điền dữ liệu cho chuỗi.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Đặt chuỗi mới để hiển thị giá trị.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Có hỗ trợ các biến thể 'Pie of Pie' và 'Bar of Pie' không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/) một biểu đồ phụ cho các biểu đồ tròn, bao gồm các loại 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) (ví dụ PNG) mà không cần xuất toàn bộ bản trình bày.