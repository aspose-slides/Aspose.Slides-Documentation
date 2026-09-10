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
description: "Tìm hiểu cách tạo và tùy chỉnh biểu đồ 3D trong Aspose.Slides cho Python qua Java, hỗ trợ tệp PPT và PPTX—nâng cao bản trình bày của bạn ngay hôm nay."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh biểu đồ 3D trong Aspose.Slides bằng cách cấu hình các thiết lập [Rotation3D](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotation3d/) như [setRotationX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotation3d/#setDepthPercents) và [setRightAngleAxes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Nó hướng dẫn tạo một bản trình bày, thêm một biểu đồ 3D với dữ liệu mặc định, áp dụng các thiết lập xem 3D cần thiết, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

## **Đặt X Rotation, Y Rotation và Depth của biểu đồ 3D**
Aspose.Slides for Python via Java cung cấp một API đơn giản để đặt các thuộc tính này. Ví dụ sau cho thấy cách đặt X rotation, Y rotation và depth của một biểu đồ 3D.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Thêm một biểu đồ với dữ liệu mặc định.
4. Đặt các thuộc tính xoay 3D.
5. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Truy cập slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một biểu đồ với dữ liệu mặc định.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Đặt chỉ mục worksheet dữ liệu biểu đồ.
    default_worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Thêm series.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Thêm danh mục.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Đặt các thuộc tính xoay 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Truy cập series biểu đồ thứ hai.
    series = chart.getChartData().getSeries().get_Item(1)

    # Điền dữ liệu cho series.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Lưu bản trình bày.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Những loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của các biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được hiển thị qua lớp [ChartType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Tôi có thể nhận được hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh thông qua [chart API](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) hoặc [render the entire slide](/slides/vi/python-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần một bản xem trước hoàn hảo về pixel hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu suất phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh các kết cấu nặng trên tường và vùng vẽ, hạn chế số điểm dữ liệu mỗi series khi có thể, và render ra đầu ra có kích thước phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.