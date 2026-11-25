---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng Python
linktitle: Biểu đồ 3D
type: docs
url: /vi/python-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các series với các ví dụ Python."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn tùy chỉnh góc nhìn của biểu đồ 3D thông qua phương thức [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu của biểu đồ 3D**

Ví dụ dưới tạo một [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và sử dụng [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các series và danh mục mặc định bằng hai series, mỗi series chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên series, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) và [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) đặt độ sâu bằng 150 % chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) bật trục góc vuông thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được thiết lập các thiết lập xem 3D này.

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

## **Áp dụng màu nền hình ảnh cho bề mặt biểu đồ 3D**

Biểu đồ 3D có ba bề mặt bạn có thể điền màu độc lập: [tường bên](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), [tường sau](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) và [sàn](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Đặt [kiểu nền](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) của bề mặt thành `Picture` và chỉ định một hình ảnh. Đặt cả [chế độ điền hình ảnh](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) và [kiểu ảnh](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) của bề mặt thành `Stretch` để một bản sao của hình ảnh phủ toàn bộ bề mặt.

Lưu [arrow.png](arrow.png) trong thư mục làm việc. Ví dụ quay biểu đồ và tăng giá trị tối đa trên trục tung để sàn hiển thị giữa các cột. Sau đó sao chép slide hai lần và áp dụng mũi tên vào bề mặt khác nhau trên mỗi slide. Ba biểu đồ đều giữ cùng dữ liệu, góc nhìn và nền.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Tường bên | Tường sau | Sàn |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo tường bên](side-wall.png) | ![Mũi tên chỉ sang phải qua tường sau](back-wall.png) | ![Mũi tên chỉ sang phải qua sàn giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) với dữ liệu mặc định: ba series và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50 %, 100 % và 200 %. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách series và định dạng đều giống nhau trong ba tệp; chỉ tỷ lệ chiều cao thay đổi.

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

Các hình ảnh dưới minh họa cùng một thiết lập chiều cao trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint. Phần trăm thấp hơn tạo cảnh phẳng hơn, trong khi phần trăm cao hơn tạo cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các đánh dấu trục và vị trí nhãn để vừa với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt bằng 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 200% chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các series dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình tháp, cũng như các biểu đồ đường, diện tích, bánh tròn và mặt phẳng 3D. So sánh ở trên sử dụng loại `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc biểu đồ `BubbleWith3D`; các tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/python-java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các Series**

Sử dụng [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng marker. Sử dụng giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các marker mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Cài đặt áp dụng cho mọi series trong nhóm đó, không chỉ series được dùng để truy cập. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình tháp, cũng như các biểu đồ đường và diện tích 3D. Giao diện phụ thuộc vào việc các series được sắp xếp theo độ sâu, nhóm lại hay chồng lên nhau. Để so sánh rõ ràng các khoảng cách giữa các series riêng biệt, sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Khoảng cách giữa các series dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Khoảng cách giữa các nhóm thanh hoặc cột liền kề, dưới dạng phần trăm của chiều rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Độ sâu tổng thể của biểu đồ, dưới dạng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa sau sử dụng dữ liệu biểu đồ mặc định, bao gồm ba series và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, khoảng cách và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng cách thay đổi.

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

Các hình ảnh dưới minh họa cùng một cài đặt độ sâu khoảng cách trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng cách: 0% | Độ sâu khoảng cách: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các series dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng cách 500% giữa các series dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại Series 3D và hình dạng thanh**

Trong biểu đồ hình trụ nhóm, series đầu tiên bắt đầu với hình dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên trả về bởi [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) và [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) trước và sau mỗi thay đổi. Bảng dưới cung cấp các tên hằng tương ứng.

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

| Thay đổi series đầu tiên | Loại series | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt loại series thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi loại series thành `ClusteredColumn3D`. Nếu mã của bạn kiểm tra loại series, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị đã lưu trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị series đầu tiên dưới dạng hình trụ, hình nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100 % Stacked Column 3D, cùng các loại 3D liên quan được khai thác qua lớp [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đang sử dụng.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) hoặc [render toàn bộ slide](/slides/vi/python-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để có kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, giới hạn số điểm dữ liệu mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.