---
title: Tạo hoặc Cập nhật Biểu đồ PowerPoint trong Python
linktitle: Tạo hoặc Cập nhật Biểu đồ
type: docs
weight: 10
url: /vi/python-java/create-chart/
keywords:
- thêm biểu đồ
- tạo biểu đồ
- chỉnh sửa biểu đồ
- thay đổi biểu đồ
- cập nhật biểu đồ
- biểu đồ phân tán
- biểu đồ tròn
- biểu đồ đường
- biểu đồ cây bản đồ
- biểu đồ cổ phiếu
- biểu đồ hộp và râu
- biểu đồ phễu
- biểu đồ sunburst
- biểu đồ histogram
- biểu đồ radar
- biểu đồ đa danh mục
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho Python qua Java. Thêm, định dạng và chỉnh sửa biểu đồ với các ví dụ mã thực tế trong Python."
---
## **Tổng quan**

Bài viết này cung cấp hướng dẫn toàn diện về cách tạo và tùy chỉnh biểu đồ bằng Aspose.Slides. Bạn sẽ học cách thêm một biểu đồ vào slide bằng mã, đưa dữ liệu vào và áp dụng các tùy chọn định dạng khác nhau để đáp ứng yêu cầu thiết kế cụ thể của mình. Trong suốt bài viết, các ví dụ mã chi tiết minh họa từng bước, từ việc khởi tạo bản trình bày và đối tượng biểu đồ đến cấu hình chuỗi, trục và chú giải. Khi thực hiện theo hướng dẫn này, bạn sẽ nắm vững cách tích hợp việc tạo biểu đồ động vào ứng dụng, giúp đơn giản hoá quá trình tạo các bài thuyết trình dựa trên dữ liệu.

## **Tạo biểu đồ**

Biểu đồ giúp người dùng nhanh chóng hình dung dữ liệu và rút ra những hiểu biết mà có thể không ngay lập tức rõ ràng từ bảng hoặc bảng tính.

**Tại sao nên tạo biểu đồ?**

Sử dụng biểu đồ, bạn có thể:

* tổng hợp, nén hoặc tóm tắt một lượng lớn dữ liệu trên một slide duy nhất trong bài thuyết trình
* hiển thị các mẫu và xu hướng trong dữ liệu
* suy luận hướng và xu hướng của dữ liệu theo thời gian hoặc so với một đơn vị đo lường cụ thể
* phát hiện các điểm ngoại lệ, sai lệch, lỗi, dữ liệu vô nghĩa, v.v.
* truyền đạt hoặc trình bày dữ liệu phức tạp

Trong PowerPoint, bạn có thể tạo biểu đồ thông qua chức năng *Insert*, cung cấp các mẫu cho việc thiết kế nhiều loại biểu đồ. Khi dùng Aspose.Slides, bạn có thể tạo cả biểu đồ thông thường (dựa trên các loại biểu đồ phổ biến) và biểu đồ tùy chỉnh.

{{% alert color="info" title="Lưu ý" %}}
Để tạo biểu đồ, sử dụng lớp [ChartType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/). Các trường trong lớp này tương ứng với các loại biểu đồ khác nhau.
{{% /alert %}}

### **Tạo biểu đồ Cột Gom Nhóm**

Phần này giải thích cách tạo biểu đồ cột gom nhóm bằng Aspose.Slides. Bạn sẽ học cách khởi tạo bản trình bày, thêm biểu đồ và tùy chỉnh các thành phần như tiêu đề, dữ liệu, chuỗi, danh mục và kiểu dáng. Thực hiện các bước dưới đây để xem cách một biểu đồ cột gom nhóm tiêu chuẩn được tạo ra:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với một số dữ liệu và chỉ định kiểu `ChartType.ClusteredColumn`.
1. Thêm tiêu đề cho biểu đồ.
1. Truy cập bảng tính dữ liệu của biểu đồ.
1. Xóa tất cả các chuỗi và danh mục mặc định.
1. Thêm chuỗi và danh mục mới.
1. Thêm dữ liệu mới cho chuỗi biểu đồ.
1. Áp dụng màu nền cho chuỗi biểu đồ.
1. Thêm nhãn cho chuỗi biểu đồ.
1. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã C# sau đây minh họa cách tạo biểu đồ cột gom nhóm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Khởi tạo một lớp presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Thêm một biểu đồ với dữ liệu mặc định
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Đặt chỉ số cho trang dữ liệu của biểu đồ
    default_worksheet_index = 0

    # Lấy WorkSheet dữ liệu biểu đồ
    workbook = chart.getChartData().getChartDataWorkbook()

    # Xóa các chuỗi và danh mục được tạo mặc định
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Thêm chuỗi mới
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Thêm danh mục mới
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Lấy chuỗi biểu đồ đầu tiên
    series = chart.getChartData().getSeries().get_Item(0)

    # Bây giờ điền dữ liệu cho chuỗi
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Đặt màu nền cho chuỗi
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Lấy chuỗi biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1)

    # Điền dữ liệu cho chuỗi
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Đặt màu nền cho chuỗi
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Tạo nhãn tùy chỉnh cho mỗi danh mục cho chuỗi mới
    # Đặt nhãn đầu tiên để hiển thị tên danh mục
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Hiển thị giá trị cho nhãn thứ ba
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Lưu bản trình bày kèm biểu đồ
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Phân tán**

Biểu đồ phân tán (còn gọi là scatter plot hoặc đồ thị x‑y) thường được dùng để kiểm tra các mẫu hoặc minh họa mối tương quan giữa hai biến.

Sử dụng biểu đồ phân tán khi:

* bạn có dữ liệu số cặp đôi
* bạn có hai biến phù hợp với nhau
* bạn muốn xác định liệu hai biến có liên quan hay không
* bạn có một biến độc lập có nhiều giá trị cho một biến phụ thuộc

1. Thực hiện các bước trong [Create Clustered Column Charts](#create-clustered-column-charts).
2. Ở bước ba, thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ là một trong các lựa chọn sau:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Biểu thị một biểu đồ phân tán với các dấu đánh dấu._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Biểu thị một biểu đồ phân tán kết nối bằng đường cong, có dấu đánh dấu dữ liệu._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Biểu thị một biểu đồ phân tán kết nối bằng đường cong, không có dấu đánh dấu dữ liệu._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Biểu thị một biểu đồ phân tán kết nối bằng đường thẳng, có dấu đánh dấu dữ liệu._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Biểu thị một biểu đồ phân tán kết nối bằng đường thẳng, không có dấu đánh dấu dữ liệu._

Mã Python dưới đây cho thấy cách tạo biểu đồ phân tán với các dấu đánh dấu khác nhau cho mỗi chuỗi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Khởi tạo một lớp presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Tạo biểu đồ mặc định
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Lấy chỉ số trang tính dữ liệu biểu đồ mặc định
    default_worksheet_index = 0

    # Lấy trang tính dữ liệu biểu đồ
    workbook = chart.getChartData().getChartDataWorkbook()

    # Xóa chuỗi demo
    chart.getChartData().getSeries().clear()

    # Thêm chuỗi mới
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Lấy chuỗi biểu đồ đầu tiên
    series = chart.getChartData().getSeries().get_Item(0)

    # Thêm một điểm mới (1:3) vào chuỗi
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thêm một điểm mới (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thay đổi kiểu chuỗi
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Thay đổi ký hiệu chuỗi biểu đồ
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Lấy chuỗi biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1)

    # Thêm một điểm mới (5:2) ở đó
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thêm một điểm mới (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thêm một điểm mới (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thêm một điểm mới (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Thay đổi ký hiệu chuỗi biểu đồ
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Tròn**

Biểu đồ tròn thích hợp để hiển thị mối quan hệ phần‑với‑toàn trong dữ liệu, đặc biệt khi dữ liệu có các nhãn phân loại kèm giá trị số. Tuy nhiên, nếu dữ liệu của bạn có quá nhiều phần hoặc nhãn, bạn có thể cân nhắc dùng biểu đồ cột thay thế.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Pie](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Pie).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Thêm dữ liệu mới cho chuỗi biểu đồ.
8. Thêm các điểm mới cho biểu đồ và áp dụng màu tùy chỉnh cho các phần của biểu đồ tròn.
9. Đặt nhãn cho các chuỗi.
10. Bật các đường dẫn cho nhãn chuỗi.
11. Đặt góc quay cho các phần của biểu đồ tròn.
12. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ tròn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Khởi tạo một lớp presentation đại diện cho tệp PPTX.
presentation = Presentation()
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Thêm một biểu đồ với dữ liệu mặc định
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Đặt tiêu đề cho biểu đồ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Đặt chỉ số cho trang dữ liệu của biểu đồ
    default_worksheet_index = 0

    # Lấy trang tính dữ liệu biểu đồ
    workbook = chart.getChartData().getChartDataWorkbook()

    # Xóa các chuỗi và danh mục được tạo mặc định
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Thêm danh mục mới
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Thêm chuỗi mới
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Điền dữ liệu cho chuỗi
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Thêm các điểm mới và đặt màu cho sector
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Đặt viền sector
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Đặt viền sector
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Đặt viền sector
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Tạo nhãn tùy chỉnh cho mỗi danh mục cho chuỗi mới
    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Hiển thị đường dẫn cho biểu đồ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Đặt góc quay cho các sector của biểu đồ tròn
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Lưu bản trình bày kèm biểu đồ
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Đường**

Biểu đồ đường (còn gọi là line graph) thích hợp khi bạn muốn thể hiện sự thay đổi giá trị theo thời gian. Với biểu đồ đường, bạn có thể so sánh một lượng lớn dữ liệu cùng lúc, theo dõi biến đổi và xu hướng theo thời gian, làm nổi bật các bất thường trong chuỗi dữ liệu, và nhiều hơn nữa.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.
1. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Line](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Line).
1. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ đường:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Theo mặc định, các điểm trên biểu đồ đường được nối bằng các đường thẳng liên tục. Nếu bạn muốn các điểm được nối bằng dấu gạch, bạn có thể chỉ định kiểu gạch mong muốn như sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Cây bản đồ**

Biểu đồ cây bản đồ thích hợp cho dữ liệu bán hàng khi bạn muốn hiển thị kích thước tương đối của các danh mục dữ liệu và nhanh chóng thu hút sự chú ý tới các mục đóng góp lớn trong mỗi danh mục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Treemap](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Treemap).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Thêm dữ liệu mới cho chuỗi biểu đồ.
8. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ cây bản đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #nhánh 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #nhánh 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Cổ phiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#OpenHighLowClose).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Thêm dữ liệu mới cho chuỗi biểu đồ.
8. Chỉ định định dạng đường cao‑thấp.
9. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ cổ phiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Hộp và Râu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#BoxAndWhisker).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Thêm dữ liệu mới cho chuỗi biểu đồ.
8. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ hộp và râu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Phễu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Funnel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Funnel).
4. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ phễu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Sunburst**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Sunburst](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Sunburst).
4. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ sunburst:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #nhánh 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #nhánh 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Histogram**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.Histogram](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Histogram).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ histogram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Radar**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với một số dữ liệu và chỉ định loại biểu đồ bạn muốn ([ChartType.Radar](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#Radar) trong trường hợp này).
4. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ radar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Đa danh mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và chỉ định loại [ChartType.ClusteredColumn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ClusteredColumn).
4. Truy cập sổ làm việc dữ liệu biểu đồ [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/).
5. Xóa các chuỗi và danh mục mặc định.
6. Thêm chuỗi và danh mục mới.
7. Thêm dữ liệu mới cho chuỗi biểu đồ.
8. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách tạo biểu đồ đa danh mục:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Thêm chuỗi
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Lưu bản trình bày với biểu đồ
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Bản đồ**

Biểu đồ bản đồ trực quan hoá dữ liệu địa lý và giúp so sánh các giá trị giữa các khu vực.

Mã Python dưới đây cho thấy cách tạo biểu đồ bản đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tạo biểu đồ Kết hợp**

Biểu đồ kết hợp (hoặc combo chart) kết hợp hai hoặc nhiều loại biểu đồ trong một biểu đồ duy nhất. Loại biểu đồ này cho phép bạn làm nổi bật, so sánh hoặc xem xét sự khác biệt giữa hai hoặc nhiều bộ dữ liệu, giúp xác định mối quan hệ giữa chúng.

![The combination chart](combination_chart.png)

Mã Python sau đây cho thấy cách tạo biểu đồ kết hợp như trong hình trên trong một bản PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Đặt tiêu đề cho biểu đồ.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Đặt chú giải cho biểu đồ.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Xóa các chuỗi và danh mục được tạo mặc định.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Thêm danh mục mới.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Thêm chuỗi đầu tiên.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Đặt trục ngang.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Đặt trục dọc.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Đặt màu cho các đường lưới chính dọc.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Đặt trục ngang phụ.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Đặt trục dọc phụ.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Cập nhật biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) đại diện cho bản trình bày chứa biểu đồ cần cập nhật.
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập bảng tính dữ liệu biểu đồ.
5. Sửa chuỗi dữ liệu biểu đồ bằng cách thay đổi giá trị chuỗi.
6. Thêm một chuỗi mới và điền dữ liệu cho nó.
7. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách cập nhật một biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Mở bản trình bày chứa biểu đồ cần cập nhật
presentation = Presentation("ExistingChart.pptx")
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Lấy biểu đồ từ slide
    chart = slide.getShapes().get_Item(0)

    # Đặt chỉ số cho trang dữ liệu của biểu đồ
    default_worksheet_index = 0

    # Lấy trang tính dữ liệu của biểu đồ
    workbook = chart.getChartData().getChartDataWorkbook()

    # Thay đổi tên danh mục của biểu đồ
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Lấy chuỗi biểu đồ đầu tiên
    series = chart.getChartData().getSeries().get_Item(0)

    # Bây giờ đang cập nhật dữ liệu chuỗi
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Sửa tên chuỗi
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Lấy chuỗi biểu đồ thứ hai
    series = chart.getChartData().getSeries().get_Item(1)

    # Bây giờ đang cập nhật dữ liệu chuỗi
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Sửa tên chuỗi
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Bây giờ, đang thêm một chuỗi mới
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Lấy chuỗi biểu đồ thứ ba
    series = chart.getChartData().getSeries().get_Item(2)

    # Bây giờ đang điền dữ liệu cho chuỗi
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Lưu bản trình bày kèm biểu đồ
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt phạm vi dữ liệu cho biểu đồ**

Để đặt phạm vi dữ liệu cho một biểu đồ, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) đại diện cho bản trình bày chứa biểu đồ.
2. Lấy tham chiếu tới một slide bằng chỉ số của nó.
3. Duyệt qua tất cả các shape để tìm biểu đồ mong muốn.
4. Truy cập dữ liệu biểu đồ và đặt phạm vi.
5. Lưu bản trình bày đã sửa dưới dạng tệp PPTX.

Mã Python dưới đây cho thấy cách đặt phạm vi dữ liệu cho một biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Mở bản trình bày chứa biểu đồ
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sử dụng các dấu đánh dấu mặc định trong biểu đồ**

Khi bạn sử dụng các dấu đánh dấu mặc định trong biểu đồ, mỗi chuỗi biểu đồ sẽ tự động nhận một ký hiệu dấu đánh dấu khác nhau.

Mã Python dưới đây cho thấy cách tự động đặt dấu đánh dấu cho một chuỗi biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Lấy chuỗi biểu đồ thứ hai
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Bây giờ đang điền dữ liệu cho chuỗi
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào được Aspose.Slides hỗ trợ?**

Aspose.Slides hỗ trợ một loạt các [chart types](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/), bao gồm biểu đồ cột, đường, tròn, diện tích, phân tán, histogram, radar và nhiều loại khác. Sự linh hoạt này cho phép bạn chọn loại biểu đồ phù hợp nhất cho nhu cầu trực quan hoá dữ liệu của mình.

**Làm thế nào để thêm một biểu đồ mới vào slide?**

Để thêm một biểu đồ, trước tiên bạn tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), lấy slide mong muốn bằng chỉ số, sau đó gọi phương thức để thêm biểu đồ, chỉ định loại biểu đồ và dữ liệu ban đầu. Quá trình này tích hợp biểu đồ trực tiếp vào bản trình bày của bạn.

**Làm sao tôi có thể cập nhật dữ liệu hiển thị trong biểu đồ?**

Bạn có thể cập nhật dữ liệu của biểu đồ bằng cách truy cập sổ làm việc dữ liệu của nó ([ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/)), xóa các chuỗi và danh mục mặc định, rồi thêm dữ liệu tùy chỉnh của bạn. Điều này cho phép bạn làm mới biểu đồ để phản ánh dữ liệu mới nhất.

**Có thể tùy chỉnh giao diện của biểu đồ không?**

Có, Aspose.Slides cung cấp các tùy chọn tùy chỉnh phong phú. Bạn có thể thay đổi màu sắc, phông chữ, nhãn, chú giải và các [formatting elements](/slides/vi/python-java/chart-entities/) khác để điều chỉnh giao diện biểu đồ sao cho phù hợp với yêu cầu thiết kế của mình.