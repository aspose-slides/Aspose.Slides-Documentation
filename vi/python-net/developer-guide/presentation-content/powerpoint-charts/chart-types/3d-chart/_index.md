---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình bằng Python
linktitle: Biểu đồ 3D
type: docs
url: /vi/python-net/3d-chart/
keywords:
- biểu đồ 3d
- xoay
- độ sâu
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3-D trong Aspose.Slides cho Python qua .NET, hỗ trợ các tệp PPT, PPTX và ODP — nâng cao các bài thuyết trình của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các cài đặt `rotation_3d` như `rotation_x`, `rotation_y`, `depth_percents` và `right_angle_axes`. Nó hướng dẫn tạo một bản trình bày, thêm biểu đồ 3D với dữ liệu mặc định, áp dụng các cài đặt chế độ xem 3D cần thiết và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt các thuộc tính RotationX, RotationY và DepthPercents của biểu đồ 3D**
Aspose.Slides for Python qua .NET cung cấp một API đơn giản để đặt các thuộc tính này. Bài viết sau sẽ giúp bạn cách đặt các thuộc tính khác nhau như X,Y Rotation, **DepthPercents** etc. Mã mẫu áp dụng việc thiết lập các thuộc tính đã nêu ở trên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Đặt các thuộc tính Rotation3D.
5. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:
            
    # Truy cập slide đầu tiên
    slide = presentation.slides[0]

    # Thêm biểu đồ với dữ liệu mặc định
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Đặt chỉ mục của bảng dữ liệu biểu đồ
    defaultWorksheetIndex = 0

    # Lấy bảng tính dữ liệu biểu đồ
    fact = chart.chart_data.chart_data_workbook

    # Thêm chuỗi dữ liệu
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Thêm danh mục
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Đặt các thuộc tính Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Lấy chuỗi biểu đồ thứ hai
    series = chart.chart_data.series[1]

    # Bây giờ đang điền dữ liệu cho chuỗi
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Đặt giá trị OverLap
    series.parent_series_group.overlap = 100         

    # Ghi bản trình bày ra đĩa
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được hiển thị qua enumeration [ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/get_image/) hoặc [render toàn bộ slide](/slides/vi/python-net/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước pixel-perfect hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển, hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên các bức tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn mục tiêu.