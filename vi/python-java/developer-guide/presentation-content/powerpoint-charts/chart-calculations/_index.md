---
title: Tối ưu hoá tính toán biểu đồ cho bản trình bày trong Python qua Java
linktitle: Tính toán biểu đồ
type: docs
weight: 50
url: /vi/python-java/chart-calculations/
keywords:
- tính toán biểu đồ
- các thành phần biểu đồ
- vị trí thành phần
- vị trí thực
- phần tử con
- phần tử cha
- giá trị biểu đồ
- giá trị thực
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Hiểu các tính toán biểu đồ, cập nhật dữ liệu và kiểm soát độ chính xác trong Aspose.Slides cho Python qua Java cho PPT và PPTX, kèm các ví dụ mã Python thực tế."
---
## **Tổng quan**

Aspose.Slides cung cấp các API để làm việc với các phép tính biểu đồ và dữ liệu bố cục trong bản trình bày. Bài viết này cho thấy cách lấy các giá trị thực tế của các thành phần biểu đồ, bao gồm vị trí và kích thước thực của các thành phần biểu đồ cũng như các giá trị thực của các trục biểu đồ. Nó cũng giải thích rằng các giá trị này được điền sau khi thực hiện việc xác thực bố cục biểu đồ.

Ngoài ra, bài viết còn mô tả cách lấy vị trí thực của các thành phần cha của biểu đồ và cách ẩn các thành phần biểu đồ như tiêu đề, trục, chú giải và các đường lưới. Các ví dụ này giúp bạn kiểm tra thông tin bố cục biểu đồ và kiểm soát khả năng hiển thị của các thành phần biểu đồ trong bản trình bày PowerPoint một cách lập trình.

## **Tính Giá Trị Thực Tế Của Các Thành Phần Biểu Đồ**
Aspose.Slides for Python via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các phương thức của lớp [Axis](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/) cung cấp thông tin về các giá trị thực của các trục biểu đồ ([getActualMaxValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) trước để điền các thuộc tính này với các giá trị thực.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Tính Vị Trí Thực Tế Của Các Thành Phần Cha Của Biểu Đồ**
Aspose.Slides for Python via Java cung cấp một API đơn giản để lấy các thuộc tính này. Các phương thức của lớp [ChartPlotArea](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/) cung cấp thông tin về vị trí và kích thước thực của vùng vẽ biểu đồ ([getActualX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#getActualHeight)). Gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) trước để điền các thuộc tính này với các giá trị thực.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Ẩn Các Thành Phần Biểu Đồ**
Phần này giải thích cách ẩn thông tin khỏi một biểu đồ. Sử dụng Aspose.Slides for Python via Java, bạn có thể ẩn **Tiêu đề, Trục Dọc, Trục Ngang**, và **Các Đường Lưới**. Ví dụ mã sau cho thấy cách sử dụng các thuộc tính này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Ẩn tiêu đề biểu đồ.
    chart.setTitle(False)

    # Ẩn trục giá trị.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Ẩn trục danh mục.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Ẩn chú giải.
    chart.setLegend(False)

    # Ẩn các đường lưới chính.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Giữ lại chỉ chuỗi đầu tiên. Xóa từ cuối cùng sẽ giữ các chỉ mục còn lại hợp lệ.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Đặt màu đường chuỗi.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Sổ làm việc Excel bên ngoài có hoạt động như nguồn dữ liệu không, và điều này ảnh hưởng như thế nào đến việc tính lại?**

Có. Một biểu đồ có thể tham chiếu tới một sổ làm việc bên ngoài: khi bạn kết nối hoặc làm mới nguồn bên ngoài, các công thức và giá trị được lấy từ sổ làm việc đó, và biểu đồ sẽ phản ánh các cập nhật trong quá trình mở/chỉnh sửa. API cho phép bạn [specify the external workbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook) đường dẫn và quản lý dữ liệu liên kết.

**Tôi có thể tính toán và hiển thị các đường xu hướng mà không tự triển khai hồi quy không?**

Có. [Trendlines](/slides/vi/python-java/trend-line/) (đường thẳng, hàm mũ và các loại khác) được Aspose.Slides thêm vào và cập nhật; các tham số của chúng được tính lại tự động từ dữ liệu chuỗi, vì vậy bạn không cần tự thực hiện các phép tính.

**Nếu một bản trình bày có nhiều biểu đồ với các liên kết bên ngoài, tôi có thể kiểm soát sổ làm việc nào mỗi biểu đồ sử dụng để tính giá trị không?**

Có. Mỗi biểu đồ có thể chỉ tới [external workbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#setExternalWorkbook) riêng của nó, hoặc bạn có thể tạo/thay thế một sổ làm việc bên ngoài cho mỗi biểu đồ một cách độc lập với các biểu đồ khác.