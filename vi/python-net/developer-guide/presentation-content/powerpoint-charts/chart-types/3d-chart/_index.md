---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình bằng Python
linktitle: Biểu đồ 3D
type: docs
url: /vi/python-net/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho Python qua .NET. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu của biểu đồ và khoảng cách giữa các series bằng các ví dụ Python."
---
## **Tổng quan**

Aspose.Slides for Python via .NET cho phép bạn tùy chỉnh góc nhìn của biểu đồ 3D thông qua thuộc tính [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt Góc Quay và Độ Sâu của Biểu Đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và sử dụng [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) để thêm một biểu đồ cột 3D chồng vào slide đầu tiên. Nó thay thế các series và danh mục mặc định bằng hai series mỗi series chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên series, và cột `0` chứa nhãn danh mục.

Thuộc tính [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) và [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) đặt độ sâu của nó bằng 150% chiều rộng, trong khi [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) bật trục góc vuông thay vì quan điểm phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập hiển thị 3D này.

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

## **Áp dụng Đổ Hình Ảnh lên Bề Mặt Biểu Đồ 3D**

Bạn có thể đổ màu cho [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) và [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) của một biểu đồ 3D một cách độc lập. Đặt [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) của bề mặt thành `PICTURE` và gán một hình ảnh. Để phủ một bản sao của hình ảnh lên bề mặt, đặt cả [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) và [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) của bề mặt thành `STRETCH`.

Lưu [arrow.png](arrow.png) vào thư mục làm việc. Ví dụ quay biểu đồ và tăng giá trị tối đa trên trục dọc để sàn nhìn thấy giữa các cột. Nó sao chép slide hai lần, sau đó áp dụng mũi tên vào một bề mặt khác nhau trên mỗi slide. Ba biểu đồ đều chia sẻ cùng dữ liệu, góc nhìn và nền.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Tường bên | Tường sau | Sàn |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo tường bên](side-wall.png) | ![Mũi tên chỉ sang phải trên tường sau](back-wall.png) | ![Mũi tên chỉ sang phải trên sàn giữa các cột](floor.png) |

## **Điều chỉnh Tỷ lệ Chiều cao của Biểu Đồ 3D**

Sử dụng [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ dưới tạo một biểu đồ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) với dữ liệu mặc định: ba series và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách series và định dạng giống nhau trong ba tệp; chỉ tỷ lệ chiều cao thay đổi.

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

Các hình ảnh dưới đây được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các dấu tick trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao được đặt ở 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 200% chiều rộng](height_percent_200.png) |

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Ảnh hưởng |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng của nó. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng dấu đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ đường, vùng, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `COLUMN_3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `CLUSTERED_COLUMN` hay biểu đồ `BUBBLE_WITH_3D`; những tên này là thành viên của liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . Đối với các cài đặt giao diện biểu đồ khác, xem [Định dạng Biểu đồ](/slides/vi/python-net/chart-formatting/) .

## **Điều chỉnh Khoảng cách Giữa các Series**

Sử dụng [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng dấu đánh dấu. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các dấu đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Cài đặt áp dụng cho mọi series trong nhóm đó, không chỉ series được dùng để truy cập. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) là chỉ đọc và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như biểu đồ đường và vùng 3D. Giao diện phụ thuộc vào việc các series được sắp xếp theo độ sâu, nhóm hoặc chồng. Để so sánh rõ ràng khoảng cách giữa các series riêng biệt, sử dụng `ChartType.COLUMN_3D` từ liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) .

Các thuộc tính này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Thuộc tính | Ảnh hưởng |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng dấu đánh dấu. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của chiều rộng thanh hoặc cột. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, chứa ba series và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng cách và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

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

Các hình ảnh dưới đây được xuất từ các bản trình bày đã tạo bằng Microsoft PowerPoint.

| Độ sâu khoảng cách: 0% | Độ sâu khoảng cách: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các series dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng cách 500% giữa các series dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi Kiểu Series 3D và Hình dạng Thanh**

Trong biểu đồ hình trụ gom nhóm, series đầu tiên bắt đầu với các thanh dạng trụ. Ví dụ đọc [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) và [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) trước và sau mỗi thay đổi.

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

Đặt hình dạng thành `BOX` cũng làm thay đổi kiểu series thành `CLUSTERED_COLUMN_3D`. Nếu mã của bạn phân nhánh dựa trên kiểu series, hãy đọc `series.type` sau khi thay đổi hình dạng. Giá trị được lưu trước khi gán vẫn sẽ chọn nhánh `CLUSTERED_CONE`.

![So sánh PowerPoint hiển thị series đầu tiên dưới dạng trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được hiển thị qua liệt kê [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . Để có danh sách chính xác, cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) hoặc [render toàn bộ slide](/slides/vi/python-net/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần xem trước dưới dạng raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để có kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng các kết cấu nặng trên tường và khu vực vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để khớp với màn hình hoặc nhu cầu in.