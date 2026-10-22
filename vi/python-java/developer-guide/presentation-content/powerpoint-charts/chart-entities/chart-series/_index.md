---
title: Quản lý Dữ liệu Series Biểu đồ trong Bản trình chiếu bằng Python
linktitle: Series Dữ liệu
type: docs
url: /vi/python-java/chart-series/
keywords:
- series biểu đồ
- chồng lấp series
- màu series
- tên series
- điểm dữ liệu
- ô workbook
- khoảng trống series
- giá trị âm
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý series biểu đồ, điểm dữ liệu, ô workbook, định dạng, độ chồng lấp, độ rộng khoảng trống và giá trị âm trong bản trình chiếu với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Biểu đồ có thể lưu trữ các giá trị đã vẽ trong các ô của workbook hoặc trực tiếp dưới dạng các literal số. Một [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) đại diện cho một điểm trong tập hợp đó. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các series. Trong các biểu đồ được tạo với dữ liệu mặc định, tên series, danh mục và giá trị điểm sử dụng các đối tượng [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) từ workbook của biểu đồ.

Đối với một biểu đồ danh mục điển hình, workbook mặc định sử dụng hàng 0 cho tên series, cột 0 cho tên danh mục và các ô còn lại cho giá trị series. Các chỉ mục worksheet, hàng và cột được truyền vào [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) là chỉ số bắt đầu từ 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình chiếu đã tải, hãy kiểm tra các ô được series, danh mục và điểm dữ liệu tham chiếu trước khi thay đổi giá trị trong workbook.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt ở mức Series, chẳng hạn như [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), cung cấp giao diện mặc định cho tất cả các điểm trong một series.
- Cài đặt điểm dữ liệu, chẳng hạn như [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), ghi đè giao diện của series cho một điểm.
- Cài đặt nhóm áp dụng cho các series tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Truy cập nhóm thông qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) khi bạn cần đặt các tùy chọn như overlap hoặc gap width.

Khi không có màu nền điểm hoặc series nào được thiết lập rõ ràng, kiểu biểu đồ và chủ đề sẽ xác định giao diện tự động. Khi cả hai định dạng series và điểm đều tồn tại, định dạng điểm sẽ được ưu tiên cho điểm đó.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Đặt giá trị Series bằng Literal số**

Sử dụng literal số khi giá trị series đến từ dữ liệu ứng dụng hoặc tính toán và không cần tham chiếu tới ô worksheet. Gọi [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) với [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) trước khi gán kết quả của mỗi điểm qua phương thức [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) bằng [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Cài đặt của collection kiểm soát loại nguồn của tất cả các giá trị điểm trong series đó. Phương thức [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) của mỗi giá trị điểm báo cáo loại đã chọn; thay đổi nó qua cài đặt của collection. Với `Worksheet`, sử dụng [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) để truy cập ô được tham chiếu. Với `DoubleLiterals`, sử dụng [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) hoặc `setAsLiteralDouble` để đọc hoặc ghi số trực tiếp.

Ví dụ sau tạo một biểu đồ cột với series và danh mục mặc định, sau đó gán các giá trị tính toán 10, 20, … cho các điểm hiện có của series đầu tiên. Nó lưu bản trình chiếu, mở lại và in các giá trị đã lưu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Loại nguồn giá trị điểm tách biệt khỏi [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), phương thức này xác định cấu hình workbook nội bộ hoặc ngoại bộ của biểu đồ. Sử dụng literal số không tự động loại bỏ workbook nhúng. Trong ví dụ này, workbook vẫn còn sẵn cho nhãn danh mục, tên series và các series khác. Xem [Workbook biểu đồ](/slides/vi/python-java/chart-workbook/) để quản lý workbook.

Đối với biểu đồ scatter và bubble, sử dụng [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) và [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) để chọn nguồn cho [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) và [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Biểu đồ bubble cũng sử dụng [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) cho [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Đặt mỗi nguồn áp dụng thành `DoubleLiterals` trước khi gán số qua phương thức `setAsLiteralDouble` của giá trị tương ứng.

## **Đặt Overlap cho Series biểu đồ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm series cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) để cập nhật mọi series tương thích trong nhóm đó. Tùy chọn này áp dụng cho các loại biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm series không liên quan trong biểu đồ kết hợp.

Ví dụ sau đặt overlap cho nhóm chứa series đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Biểu đồ mới chứa các series mẫu, danh mục và giá trị.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The series overlap](series_overlap.png)

## **Thay đổi màu nền Series**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) để đặt màu nền mặc định cho toàn bộ series. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) của nó sẽ ghi đè màu nền series cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho series đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The color of the series](series_color.png)

## **Thay đổi Tên Series**

Tên series được lưu trong workbook dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong workbook mặc định được tạo cho biểu đồ cột nhóm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của series đầu tiên. Các biến được đặt tên trong ví dụ sau làm rõ cấu trúc này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bạn cũng có thể cập nhật ô đã được [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) tham chiếu. Cách này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ đã tồn tại:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The series name](series_name.png)

### **Tạo Series với Tên từ Nhiều Ô**

Tên series tổng hợp hữu ích khi tên sản phẩm và khoảng thời gian báo cáo được lưu trong các ô workbook riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` ở B1 và `2026` ở C1 thành một tên series duy nhất trong khi vẫn giữ liên kết tới các ô nguồn.

Sử dụng [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) để lấy phạm vi tên, sau đó truyền collection này cho [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Tham số `skipHiddenCells` điều khiển việc bao gồm các ô ẩn: `True` loại trừ, `False` bao gồm. Ví dụ này dùng `False` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình chiếu với một series và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên series; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Hai ô này cung cấp tên series.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Các ô riêng biệt cung cấp danh mục và các điểm dữ liệu số.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tên series tạo ra là `Product A 2026`, với một khoảng trắng giữa hai giá trị ô. Chú giải hiển thị điều này như một mục duy nhất cho cả hai cột. Hình dưới minh họa kết quả:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Lấy màu nền Series tự động**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) trả về màu được tính dựa trên chỉ số series và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền series chưa được định nghĩa rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in màu tự động của mỗi series mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Đầu ra mẫu cho kiểu biểu đồ mặc định:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Màu cụ thể phụ thuộc vào kiểu biểu đồ và chủ đề.

## **Đặt màu Nghịch đảo cho Series biểu đồ**

Đối với series thanh, cột và bubble, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) có thể hiển thị giá trị âm bằng màu nền khác. Đặt màu nền series thường thành màu đặc, bật tính năng nghịch đảo và gán màu cho giá trị âm qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Các số âm vẫn giữ nguyên trong workbook; chỉ màu hiển thị thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một series. Hàng 0 của worksheet chứa tên series, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bạn có thể bật nghịch đảo cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Trong ví dụ sau, nghịch đảo bị tắt cho series và chỉ bật cho điểm đã chọn. Điểm này cũng được gán giá trị âm để thấy hiệu ứng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa Giá trị Điểm Dữ liệu Cụ thể**

Để làm trống một điểm mà không xóa các điểm khác, đặt ô workbook hỗ trợ của nó thành `None`. Đối với biểu đồ cột, giá trị đã vẽ có sẵn qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Điểm dữ liệu vẫn giữ vị trí danh mục, nhưng biểu đồ sẽ coi giá trị là trống theo cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong series đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Biểu đồ scatter sử dụng các ô X và Y riêng biệt, và biểu đồ bubble còn có ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) khi muốn giữ các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu trong collection.

## **Kiểm soát Hiển thị Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng biệt so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột ẩn, xem [Bao gồm dữ liệu từ các hàng và cột ẩn](/slides/vi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô workbook trống đại diện cho dữ liệu thiếu; một ô chứa `0` đại diện cho một giá trị số đã biết. Gọi [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) với `None` để làm ô trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) để chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách vẽ các khoảng trống mà không phải lấp đầy ô workbook trống bằng 0 hoặc giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một series, xóa giá trị cho Ngày 3, và lưu biểu đồ với mỗi chế độ. Không cần tệp nhập. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục và cột 1 cho giá trị; hàng 0 chứa tên series. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Để Ngày 3 thực sự trống, trong khi vẫn giữ lại danh mục và điểm dữ liệu.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mỗi tệp đầu ra lưu chế độ được gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình chiếu một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 trong workbook là trống trong mọi trường hợp:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Hiệu ứng hiển thị phụ thuộc vào loại biểu đồ. Biểu đồ đường giúp dễ so sánh ba chế độ. Biểu đồ thanh và cột không có đường nối qua danh mục thiếu, vì vậy `Span` không tạo đoạn nối như trên; một cột thiếu và một cột cao 0 cũng có thể trông giống nhau. Tương tự, biểu đồ scatter chỉ có các dấu chấm sẽ không có đường nối. Đừng mong đợi ba kết quả riêng biệt cho mọi loại biểu đồ; hãy kiểm tra đầu ra cho loại bạn sử dụng.

## **Đặt Độ rộng Khoảng cách giữa Series**

Khoảng cách (gap width) là khoảng không gian giữa các cụm thanh hoặc cột liền kề, biểu thị bằng phần trăm độ rộng của thanh hoặc cột. Giống như overlap, nó thuộc về nhóm series cha chứ không phải một series riêng. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) một lần cho nhóm. Giá trị lớn hơn tạo nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và chỉ lưu bản trình chiếu cuối cùng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![The gap width](gap_width.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ series dữ liệu?**

Tất cả các loại biểu đồ được đại diện bởi enum [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng series của chúng không có cùng cấu trúc giá trị hoặc cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ scatter sử dụng giá trị X và Y, và biểu đồ bubble thêm kích thước bubble. Sử dụng phương pháp tạo điểm dữ liệu phù hợp với loại series. Các tùy chọn như overlap và gap width chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Series group là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) chứa các series tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, do đó thay đổi nhóm được truy cập qua một series không nhất thiết thay đổi mọi series trong biểu đồ.

**Biểu đồ mới tạo có chứa dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) tạo các series, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô này hoặc xóa cả collection series và collection danh mục trước khi thêm một bộ dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được liên kết với ô workbook như thế nào?**

Tên series, nhãn danh mục và giá trị điểm dữ liệu tham chiếu đến các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ cho các hàng danh mục và các hàng giá trị series đồng nhất để mỗi điểm được vẽ dưới danh mục dự định.

**Làm sao để xóa một điểm mà không xóa toàn bộ series?**

Đặt ô giá trị tương ứng thành `None` để giữ vị trí danh mục của điểm như một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn xóa tất cả các điểm trong series đó. Nếu bạn cũng xóa các danh mục, hãy cập nhật mọi series để giá trị của chúng vẫn đồng bộ với collection danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào loại biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Các biểu đồ được hỗ trợ có thể hiển thị khoảng trống dưới dạng khoảng hở, giá trị 0, hoặc nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình chiếu của bạn. Xem [Kiểm soát Hiển thị Ô Trống](#control-the-display-of-empty-cells) để có ví dụ đầy đủ và so sánh trực quan.

**Giá trị âm được định dạng như thế nào?**

Đối với các series thanh, cột và bubble được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) và đặt màu trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Bạn có thể ghi đè hành vi cho một điểm riêng bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Các phương pháp này ảnh hưởng tới định dạng, không phải các giá trị số lưu trữ.

**Định dạng nào thắng khi cả series và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng sẽ ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng series rõ ràng hoặc, khi không có định dạng series, sử dụng kiểu và chủ đề biểu đồ tự động. Các cài đặt nhóm như overlap và gap width điều khiển bố cục và không phải là ghi đè định dạng mức điểm.

**Có giới hạn số series mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số series. Trong thực tế, các ràng buộc của tệp trình chiếu, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ quyết định mức giới hạn thực tế.

**Nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) trên nhóm series cha phù hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.