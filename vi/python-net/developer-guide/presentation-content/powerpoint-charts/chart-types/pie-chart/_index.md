---
title: Tùy chỉnh biểu đồ tròn trong bản thuyết trình bằng Python
linktitle: Biểu đồ tròn
type: docs
url: /vi/python-net/pie-chart/
keywords:
- biểu đồ tròn
- quản lý biểu đồ
- tùy chỉnh biểu đồ
- tùy chọn biểu đồ
- cài đặt biểu đồ
- tùy chọn vẽ
- màu lát
- PowerPoint
- OpenDocument
- bản thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ tròn trong Python với Aspose.Slides, có thể xuất ra PowerPoint và OpenDocument, nâng cao khả năng kể chuyện dữ liệu của bạn chỉ trong vài giây."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với biểu đồ tròn trong Aspose.Slides. Nó cho thấy cách cấu hình tùy chọn đồ thị phụ cho biểu đồ Pie of Pie và Bar of Pie, và cách bật tính năng tự động tô màu các lát của biểu đồ tròn tiêu chuẩn.

Các ví dụ tập trung vào các bước tùy chỉnh biểu đồ thực tế như thêm biểu đồ vào một slide, điều chỉnh cài đặt series và nhãn, thay thế dữ liệu biểu đồ mặc định bằng các danh mục và giá trị tùy chỉnh, và lưu bản trình bày đã cập nhật.

## **Tùy chọn Đồ thị Phụ cho Biểu đồ Pie of Pie và Bar of Pie**

Aspose.Slides for Python via .NET hiện đã hỗ trợ các tùy chọn đồ thị phụ cho biểu đồ Pie of Pie hoặc Bar of Pie. Trong chủ đề này, chúng ta sẽ xem qua ví dụ cách chỉ định các tùy chọn này bằng Aspose.Slides. Để chỉ định các thuộc tính, vui lòng làm theo các bước dưới đây:

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm biểu đồ vào slide.
1. Chỉ định các tùy chọn đồ thị phụ của biểu đồ.
1. Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã thiết lập các thuộc tính khác nhau của biểu đồ Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:
    # Thêm biểu đồ vào slide
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Đặt các thuộc tính khác nhau
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Ghi bản trình bày ra đĩa
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Màu Tự Động cho Các Lát của Biểu đồ Tròn**

Aspose.Slides for Python via .NET cung cấp API đơn giản để đặt màu tự động cho các lát của biểu đồ tròn. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp Presentation.
1. Truy cập slide đầu tiên.
1. Thêm biểu đồ với dữ liệu mặc định.
1. Đặt tiêu đề cho biểu đồ.
1. Đặt series đầu tiên để Hiển thị Giá trị.
1. Đặt chỉ mục của bảng dữ liệu biểu đồ.
1. Lấy worksheet dữ liệu biểu đồ.
1. Xóa các series và danh mục được tạo mặc định.
1. Thêm danh mục mới.
1. Thêm series mới.

Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp PPTX
with slides.Presentation() as presentation:
	# Truy cập slide đầu tiên
	slide = presentation.slides[0]

	# Thêm biểu đồ với dữ liệu mặc định
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Đặt tiêu đề cho biểu đồ
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Đặt series đầu tiên để Hiển thị Giá trị
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Đặt chỉ mục của bảng dữ liệu biểu đồ
	defaultWorksheetIndex = 0

	# Lấy worksheet dữ liệu biểu đồ
	fact = chart.chart_data.chart_data_workbook

	# Xóa các series và danh mục được tạo mặc định
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Thêm danh mục mới
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Thêm series mới
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Bây giờ điền dữ liệu cho series
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Liệu các biến thể 'Pie of Pie' và 'Bar of Pie' có được hỗ trợ không?**

Có, thư viện [hỗ trợ](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) một đồ thị phụ cho các biểu đồ tròn, bao gồm các kiểu 'Pie of Pie' và 'Bar of Pie'.

**Tôi có thể xuất chỉ biểu đồ dưới dạng hình ảnh (ví dụ, PNG) không?**

Có, bạn có thể [xuất riêng biểu đồ dưới dạng hình ảnh](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/get_image/) (như PNG) mà không cần xuất toàn bộ bản trình bày.