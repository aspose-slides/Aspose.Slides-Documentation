---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng Python
linktitle: Biểu đồ 3D
type: docs
url: /vi/python-net/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bản trình bày PowerPoint bằng Aspose.Slides cho Python qua .NET. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các series bằng các ví dụ Python."
---
## **Tổng quan**

Aspose.Slides for Python thông qua .NET cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua thuộc tính [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc phải và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và sử dụng [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các series và danh mục mặc định bằng hai series, mỗi series chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên series, và cột `0` chứa nhãn danh mục.

Các thuộc tính [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) và [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) đặt độ sâu của nó bằng 150% chiều rộng, trong khi [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) bật trục góc phải thay vì góc nhìn phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập chế độ xem 3D này.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) với dữ liệu mặc định: ba series và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách series và định dạng đều giống nhau trong cả ba tệp; chỉ có phần trăm chiều cao thay đổi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Các hình ảnh sau được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các nhãn trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao được đặt bằng 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao được đặt bằng 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao được đặt bằng 200% chiều rộng](height_percent_200.png) |

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Property | Effect |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của độ rộng điểm đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ đường, khu vực, bánh và bề mặt 3D. So sánh ở trên sử dụng loại `COLUMN_3D` đã được xác nhận. Cài đặt này không thay đổi giao diện của biểu đồ 2D `CLUSTERED_COLUMN` hoặc biểu đồ `BUBBLE_WITH_3D`; những tên này là các thành viên của liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/python-net/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các Series**

Sử dụng [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục độ sâu của biểu đồ 3D, được biểu thị dưới dạng phần trăm của độ rộng điểm đánh dấu. Sử dụng các giá trị từ **0 tới 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi các giá trị lớn hơn làm tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các điểm đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm thông qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Cài đặt này áp dụng cho mọi series trong nhóm đó, không chỉ series được dùng để truy cập. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) là chỉ đọc và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cùng với các biểu đồ đường và khu vực 3D. Giao diện phụ thuộc vào việc các series được sắp xếp theo độ sâu, cụm hoặc chồng. Để so sánh rõ ràng các khoảng cách giữa các series riêng biệt, sử dụng `ChartType.COLUMN_3D` từ liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) .

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Property | Effect |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của độ rộng điểm đánh dấu. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Khoảng cách giữa các cụm cột hoặc thanh kề nhau, tính bằng phần trăm của độ rộng cột hoặc thanh. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, chứa ba series và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng cách và độ sâu biểu đồ giống nhau; chỉ có độ sâu khoảng cách thay đổi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Các hình ảnh sau được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint.

| Khoảng cách sâu: 0% | Khoảng cách sâu: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các series dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng cách 500% giữa các series dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại Series 3D và hình dạng thanh**

Trong biểu đồ hình trụ cụm, series đầu tiên bắt đầu với các thanh hình trụ. Ví dụ đọc [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) và [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) trước và sau mỗi lần thay đổi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Thay đổi cho series đầu tiên | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Tạo biểu đồ | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Đặt `type` thành `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Đặt `bar_3d_shape` thành `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Đặt hình dạng thành `BOX` cũng thay đổi loại series thành `CLUSTERED_COLUMN_3D`. Nếu mã của bạn phân nhánh dựa trên loại series, hãy đọc `series.type` sau khi thay đổi hình dạng. Giá trị đã lưu trước khi gán vẫn sẽ chọn nhánh `CLUSTERED_CONE`.

![So sánh PowerPoint hiển thị series đầu tiên dưới dạng trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được khai báo trong liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) hoặc [render the entire slide](/slides/vi/python-net/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu suất khi xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu suất phụ thuộc vào khối lượng dữ liệu và độ phức tạp của hình ảnh. Để có kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, giới hạn số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để khớp với nhu cầu hiển thị hoặc in.