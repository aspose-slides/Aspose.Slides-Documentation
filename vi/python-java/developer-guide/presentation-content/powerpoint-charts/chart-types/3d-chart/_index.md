---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình bằng Python
linktitle: Biểu đồ 3D
type: docs
url: /vi/python-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bài thuyết trình PowerPoint với Aspose.Slides cho Python qua Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các chuỗi bằng các ví dụ Python."
---
## **Tổng quan**

Aspose.Slides cho Python thông qua Java cho phép bạn tùy chỉnh khung nhìn của biểu đồ 3D thông qua phương thức [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các chuỗi, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và sử dụng [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) và [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) đặt độ sâu của nó ở mức 150% chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) bật trục góc vuông thay vì góc nhìn phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các cài đặt hiển thị 3D này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách chuỗi và định dạng đều giống nhau trong cả ba tệp; chỉ có phần trăm chiều cao thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các hình ảnh dưới đây minh họa cùng một cài đặt chiều cao trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách đánh dấu trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao được đặt ở 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao được đặt ở 200% chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các chuỗi dọc trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, khu vực, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc `BubbleWith3D`; những tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Định dạng biểu đồ](/slides/vi/python-java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Sử dụng [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc trục độ sâu của biểu đồ 3D, được biểu thị dưới dạng phần trăm của chiều rộng marker. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các marker mỏng hơn dọc trục độ sâu.

Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Cài đặt này áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được dùng để truy cập. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường và khu vực 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, nhóm hoặc chồng. Để so sánh rõ ràng khoảng cách giữa các chuỗi riêng biệt, sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các chuỗi dọc trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Khoảng cách giữa các cụm thanh hoặc cột kề nhau, dưới dạng phần trăm của chiều rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu tổng thể của biểu đồ, dưới dạng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa sau sử dụng dữ liệu biểu đồ mặc định, chứa ba chuỗi và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng cách và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các hình ảnh dưới đây minh họa cùng một cài đặt độ sâu khoảng cách trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng cách: 0% | Độ sâu khoảng cách: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các chuỗi dọc trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng cách 500% giữa các chuỗi dọc trục độ sâu](gap_depth_500.png) |

## **Thay đổi kiểu chuỗi 3D và hình dạng thanh**

Trong biểu đồ hình trụ nhóm, chuỗi đầu tiên bắt đầu với hình dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên trả về bởi [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) và [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) trước và sau mỗi thay đổi. Bảng dưới cung cấp các tên hằng số tương ứng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Thay đổi cho chuỗi đầu tiên | Kiểu chuỗi | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt kiểu chuỗi thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi kiểu chuỗi thành `ClusteredColumn3D`. Nếu mã của bạn nhánh dựa trên kiểu chuỗi, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị được lưu trong bộ nhớ cache trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint cho thấy chuỗi đầu tiên là các thanh hình trụ, hình nón và cột chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được mở thông qua lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Để có danh sách chính xác, cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D để báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) hoặc [render toàn bộ slide](/slides/vi/python-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần xem trước dạng raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để đạt kết quả tốt nhất, giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để khớp với nhu cầu hiển thị hoặc in.