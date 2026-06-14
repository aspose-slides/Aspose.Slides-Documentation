---
title: Tùy chỉnh thanh lỗi trong biểu đồ trình chiếu bằng Python
linktitle: Thanh lỗi
type: docs
url: /vi/python-net/error-bar/
keywords:
- thanh lỗi
- giá trị tùy chỉnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách thêm và tùy chỉnh thanh lỗi trong biểu đồ bằng Aspose.Slides cho Python qua .NET—tối ưu hóa hình ảnh dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với thanh lỗi trong biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách thêm thanh lỗi vào một chuỗi biểu đồ, cấu hình thiết lập thanh lỗi X và Y, và áp dụng các loại giá trị khác nhau như giá trị cố định, phần trăm và giá trị tùy chỉnh.

Nó cũng minh họa cách gán giá trị thanh lỗi tùy chỉnh cho các điểm dữ liệu riêng lẻ trong một chuỗi bằng cách sử dụng bộ sưu tập các điểm dữ liệu tương ứng. Ngoài ra, bài viết bao gồm các ghi chú ngắn về cách thanh lỗi hoạt động khi xuất, khả năng tương thích của chúng với các ký hiệu và nhãn dữ liệu, và nơi tìm các lớp và enum tham chiếu API liên quan.

## **Thêm Thanh Lỗi**
Aspose.Slides for Python via .NET cung cấp API đơn giản để quản lý các giá trị thanh lỗi. Mã mẫu áp dụng khi sử dụng loại giá trị tùy chỉnh. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm biểu đồ bubble vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình bày đã sửa đổi thành tệp PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Tạo bản trình chiếu trống
with slides.Presentation() as presentation:
    # Tạo biểu đồ bubble
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Thêm thanh lỗi và thiết lập định dạng của chúng
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Lưu bản trình chiếu
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Giá Trị Thanh Lỗi Tùy Chỉnh**
Aspose.Slides for Python via .NET cung cấp API đơn giản để quản lý các giá trị thanh lỗi tùy chỉnh. Mã mẫu áp dụng khi thuộc tính **IErrorBarsFormat.ValueType** bằng **Custom**. Để chỉ định một giá trị, hãy sử dụng thuộc tính **ErrorBarCustomValues** của một điểm dữ liệu cụ thể trong bộ sưu tập **DataPoints** của chuỗi:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Thêm biểu đồ bubble vào slide mong muốn.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi X.
1. Truy cập chuỗi biểu đồ đầu tiên và đặt định dạng thanh lỗi Y.
1. Truy cập các điểm dữ liệu riêng lẻ của chuỗi biểu đồ và đặt giá trị Thanh Lỗi cho từng điểm dữ liệu của chuỗi.
1. Đặt giá trị và định dạng cho các thanh.
1. Ghi bản trình bày đã sửa đổi thành tệp PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

    # Tạo bản trình chiếu trống
    with slides.Presentation() as presentation:
        # Tạo biểu đồ bubble
        chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

        # Thêm thanh lỗi tùy chỉnh và thiết lập định dạng của chúng
        series = chart.chart_data.series[0]
        errBarX = series.error_bars_x_format
        errBarY = series.error_bars_y_format
        errBarX.is_visible = True
        errBarY.is_visible = True
        errBarX.value_type = charts.ErrorBarValueType.CUSTOM
        errBarY.value_type = charts.ErrorBarValueType.CUSTOM

        # Truy cập điểm dữ liệu của chuỗi biểu đồ và thiết lập giá trị thanh lỗi cho từng điểm
        points = series.data_points
        points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
        points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
        points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
        points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

        # Thiết lập thanh lỗi cho các điểm của chuỗi biểu đồ
        for i in range(len(points)):
            points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
            points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
            points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
            points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

        # Lưu bản trình chiếu
        presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu Hỏi Thường Gặp**

**Điều gì xảy ra với thanh lỗi khi xuất bản trình chiếu sang PDF hoặc hình ảnh?**

Chúng được render như một phần của biểu đồ và được giữ nguyên trong quá trình chuyển đổi cùng với phần còn lại của định dạng biểu đồ, với giả định sử dụng phiên bản hoặc bộ render tương thích.

**Thanh lỗi có thể được kết hợp với các ký hiệu và nhãn dữ liệu không?**

Có. Thanh lỗi là một phần tử riêng biệt và tương thích với các ký hiệu và nhãn dữ liệu; nếu các phần tử chồng lên nhau, bạn có thể cần điều chỉnh định dạng.

**Tôi có thể tìm danh sách các thuộc tính và enum để làm việc với thanh lỗi trong API ở đâu?**

Trong tài liệu tham chiếu API: lớp [ErrorBarsFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/errorbarsformat/) và các enum liên quan [ErrorBarType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/errorbartype/) và [ErrorBarValueType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/errorbarvaluetype/).