---
title: Quản lý Dữ liệu Chuỗi Biểu đồ trong Bản trình bày bằng Python
linktitle: Chuỗi Dữ liệu
type: docs
url: /vi/python-java/chart-series/
keywords:
- chuỗi biểu đồ
- độ chồng lắp chuỗi
- màu chuỗi
- tên chuỗi
- điểm dữ liệu
- ô sổ làm việc
- khoảng cách chuỗi
- giá trị âm
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý chuỗi biểu đồ, điểm dữ liệu, ô sổ làm việc, định dạng, độ chồng lắp, độ rộng khoảng cách và giá trị âm trong bản trình bày với Aspose.Slides cho Python thông qua Java."
---
## **Tổng quan**

Biểu đồ lưu trữ dữ liệu đã vẽ của nó trong một sổ làm việc dữ liệu biểu đồ. Một [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) đại diện cho một tập hợp các giá trị liên quan, và mỗi [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) trong chuỗi tham chiếu tới một hoặc nhiều ô trong sổ làm việc. Các đối tượng [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) cung cấp các nhãn hoặc giá trị nhóm được chia sẻ bởi các chuỗi. Vì vậy, tên chuỗi, các danh mục và giá trị điểm đều được kết nối với các đối tượng [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) thay vì chỉ được lưu dưới dạng văn bản hiển thị.

Đối với một biểu đồ danh mục tiêu chuẩn, sổ làm việc mặc định sử dụng hàng 0 cho tên chuỗi, cột 0 cho tên danh mục, và các ô còn lại cho các giá trị chuỗi. Các chỉ số worksheet, hàng và cột được truyền vào [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) là dựa trên chỉ số 0. Bố cục này hữu ích khi bạn tạo biểu đồ với dữ liệu mặc định, nhưng không nên cho rằng mọi biểu đồ hiện có đều sử dụng nó. Đối với một bản trình bày đã tải, hãy kiểm tra các ô được tham chiếu bởi chuỗi, danh mục và các điểm dữ liệu trước khi thay đổi giá trị trong sổ làm việc.

Cài đặt biểu đồ có ba phạm vi khác nhau:

- Cài đặt cấp chuỗi, chẳng hạn như [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), cung cấp giao diện mặc định cho tất cả các điểm trong một chuỗi.
- Cài đặt điểm dữ liệu, chẳng hạn như [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), ghi đè giao diện chuỗi cho một điểm.
- Cài đặt nhóm áp dụng cho các chuỗi tương thích thuộc cùng một [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Truy cập nhóm thông qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) khi bạn cần đặt các tùy chọn như độ chồng lắp hoặc độ rộng khoảng cách.

Khi không có màu nền điểm hoặc chuỗi nào được đặt một cách rõ ràng, kiểu biểu đồ và chủ đề sẽ quyết định giao diện tự động. Khi cả định dạng chuỗi và điểm đều tồn tại, định dạng điểm sẽ có ưu tiên cho điểm đó.

![chuỗi-biểu-đồ-powerpoint](chart-series-powerpoint.png)

## **Đặt Độ Chồng Lắp Chuỗi Biểu Đồ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) báo cáo mức độ các thanh hoặc cột chồng lên nhau trong một biểu đồ 2D, từ -100 đến 100 phần trăm. Đây là một phép chiếu chỉ đọc của cài đặt trên nhóm chuỗi cha. Sử dụng [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) để cập nhật mọi chuỗi tương thích trong nhóm đó. Tùy chọn này áp dụng cho các kiểu biểu đồ hiển thị các thanh hoặc cột được nhóm lại; nó không ảnh hưởng đến các nhóm chuỗi không liên quan trong một biểu đồ kết hợp.

Ví dụ sau thiết lập độ chồng lắp cho nhóm chứa chuỗi đầu tiên:

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

    # Biểu đồ mới chứa các chuỗi mẫu, danh mục và giá trị.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![độ chồng lắp chuỗi](series_overlap.png)

## **Thay Đổi Màu Nền Chuỗi**

Sử dụng [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) để đặt màu nền mặc định cho toàn bộ chuỗi. Nếu một điểm đã có màu nền rõ ràng, cài đặt [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) của nó sẽ ghi đè màu nền chuỗi cho điểm đó.

Ví dụ sau áp dụng màu nền xanh đậm đặc cho chuỗi đầu tiên:

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

![màu của chuỗi](series_color.png)

## **Thay Đổi Tên Chuỗi**

Tên chuỗi được lưu trong sổ làm việc dữ liệu biểu đồ và thường được hiển thị trong chú giải. Trong sổ làm việc mặc định được tạo cho một biểu đồ cột cụm, ô B1 nằm ở hàng 0, cột 1 và chứa tên của chuỗi đầu tiên. Các biến được đặt tên trong ví dụ dưới đây làm cho cấu trúc này trở nên rõ ràng:

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

Bạn cũng có thể cập nhật ô đã được tham chiếu bởi [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Cách tiếp cận này tránh việc giả định một hàng và cột cụ thể trong một biểu đồ hiện có:

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

![tên chuỗi](series_name.png)

### **Tạo Một Chuỗi Với Tên Từ Nhiều Ô**

Tên chuỗi hợp thành hữu ích khi tên sản phẩm và khoảng thời gian báo cáo được lưu trong các ô sổ làm việc riêng biệt. Ví dụ, bạn có thể kết hợp `Product A` trong B1 và `2026` trong C1 thành một tên chuỗi duy nhất trong khi vẫn giữ cả hai phần liên kết với ô nguồn của chúng.

Sử dụng [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) để lấy phạm vi tên, sau đó truyền tập hợp này vào [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Tham số `skipHiddenCells` kiểm soát việc có bao gồm các ô ẩn hay không: `True` loại trừ chúng, trong khi `False` bao gồm chúng. Ví dụ này sử dụng `False` để bao gồm mọi ô trong phạm vi tên.

Ví dụ sau tạo một bản trình bày với một chuỗi và hai điểm dữ liệu. Các ô B1:C1 chỉ cung cấp tên chuỗi; A2:A3 cung cấp nhãn danh mục, và B2:B3 cung cấp các giá trị số.

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

    # Hai ô này cung cấp tên chuỗi.
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

Tên chuỗi tạo ra là `Product A 2026`, với một khoảng trắng giữa hai giá trị ô. Chú giải hiển thị nó như một mục cho cả hai cột. Hình ảnh dưới đây minh họa kết quả:

![Biểu đồ cột với giá trị Bắc và Nam và tên chuỗi hợp thành Product A 2026 trong chú giải](composite_series_name.png)

## **Lấy Màu Nền Chuỗi Tự Động**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) trả về màu được tính dựa trên chỉ số chuỗi và kiểu biểu đồ. Đây là màu được sử dụng khi màu nền chuỗi không được định nghĩa một cách rõ ràng. Gọi phương thức này chỉ đọc màu đã tính; nó không gán màu nền mới.

Ví dụ sau in ra màu tự động của mỗi chuỗi mặc định:

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

## **Đặt Màu Nền Đảo Ngược Cho Một Chuỗi Biểu Đồ**

Đối với các chuỗi thanh, cột và bong bóng, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) có thể hiển thị các giá trị âm bằng một màu nền khác. Đặt màu nền chuỗi bình thường thành đặc, bật chế độ đảo ngược, và chỉ định màu giá trị âm thông qua [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Các số âm vẫn giữ nguyên trong sổ làm việc; chỉ màu hiển thị thay đổi.

Ví dụ sau thay thế dữ liệu biểu đồ mặc định bằng một chuỗi. Hàng 0 của worksheet chứa tên chuỗi, cột 0 chứa tên danh mục, và cột 1 chứa các giá trị:

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

![màu nền đặc đảo ngược](inverted_solid_fill_color.png)

Bạn có thể bật đảo ngược cho một điểm thông qua [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Trong ví dụ sau, đảo ngược bị tắt cho chuỗi và chỉ bật cho điểm được chọn. Điểm này cũng được gán giá trị âm để hiệu ứng hiển thị:

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

## **Xóa Giá Trị Điểm Dữ Liệu Cụ Thể**

Để làm cho một điểm trống mà không xóa các điểm khác, đặt ô sổ làm việc hỗ trợ nó thành `None`. Đối với biểu đồ cột, giá trị đã vẽ có thể truy cập qua [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Điểm dữ liệu vẫn ở vị trí danh mục giống nhau, nhưng biểu đồ sẽ coi giá trị của nó là trống dựa trên cài đặt giá trị trống của biểu đồ.

Ví dụ sau chỉ xóa điểm thứ hai trong chuỗi đầu tiên:

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

Biểu đồ phân tán sử dụng các ô X và Y riêng biệt, và biểu đồ bong bóng cũng sử dụng một ô kích thước. Chỉ xóa ô đại diện cho giá trị bạn muốn loại bỏ. Không gọi [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn giữ lại các điểm khác, vì phương thức này sẽ xóa mọi điểm dữ liệu khỏi bộ sưu tập.

## **Kiểm Soát Hiển Thị Các Ô Trống**

Các ô ẩn chứa giá trị là một trường hợp riêng so với các ô trống. Để bao gồm hoặc loại trừ dữ liệu từ các hàng và cột worksheet ẩn, xem [Include Data from Hidden Rows and Columns](/slides/vi/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Một ô sổ làm việc trống biểu thị dữ liệu thiếu; một ô chứa `0` biểu thị một giá trị số đã biết. Gọi [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) với `None` để làm ô trở thành trống. Số 0 vẫn là 0 bất kể cài đặt ô trống.

Sử dụng [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) để lựa chọn cách biểu đồ hiển thị các ô trống. Cài đặt này áp dụng cho toàn bộ biểu đồ. Nó thay đổi cách các khoảng trống được vẽ, mà không điền ô sổ làm việc trống thành 0 hoặc một giá trị nội suy.

Ví dụ tự chứa sau tạo một biểu đồ đường với một chuỗi, xóa giá trị cho Ngày 3, và lưu cùng một biểu đồ với mỗi chế độ. Không cần tệp đầu vào. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) sử dụng worksheet 0, cột 0 cho nhãn danh mục, và cột 1 cho các giá trị; hàng 0 giữ tên chuỗi. Dữ liệu cuối cùng là `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

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

    # Để Ngày 3 thực sự trống, đồng thời giữ lại danh mục và điểm dữ liệu của nó.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mỗi tệp đầu ra lưu chế độ đã gán trước khi lưu: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, và `empty_cells_Span.pptx`. Để lưu chỉ một phiên bản, gán chế độ mong muốn và lưu bản trình bày một lần thay vì lặp qua các chế độ.

So sánh dưới đây cho thấy cùng một dữ liệu trong ba tệp. Ngày 3 là trống trong sổ làm việc trong mọi trường hợp:

![Biểu đồ đường với dữ liệu giống nhau: Gap ngắt đường tại Ngày 3, Zero hạ đường xuống 0, và Span nối Ngày 2 tới Ngày 4.](display_blanks_as.png)

Hiệu ứng nhìn thấy phụ thuộc vào kiểu biểu đồ. Một biểu đồ đường làm cho cả ba chế độ dễ so sánh. Biểu đồ thanh và cột không có đường để nối qua danh mục thiếu, vì vậy `Span` không thể tạo đoạn nối như trên; một cột thiếu và một cột có chiều cao 0 cũng có thể trông giống nhau. Tương tự, một biểu đồ phân tán chỉ có điểm đánh dấu không có đường nối. Đừng mong đợi ba kết quả rõ ràng cho mọi kiểu biểu đồ; hãy kiểm tra đầu ra cho kiểu bạn sử dụng.

## **Đặt Độ Rộng Khoảng Cách Giữa Các Chuỗi**

Độ rộng khoảng cách là khoảng cách giữa các cụm thanh hoặc cột liền kề, biểu thị dưới dạng phần trăm của chiều rộng thanh hoặc cột. Giống như độ chồng lắp, nó thuộc về nhóm chuỗi cha chứ không phải một chuỗi đơn lẻ. Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) một lần cho nhóm. Giá trị lớn hơn tạo ra nhiều không gian hơn giữa các cụm; giá trị nhỏ hơn làm chúng dày đặc hơn.

Ví dụ sau thay đổi độ rộng khoảng cách và lưu chỉ bản trình bày cuối cùng:

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

![độ rộng khoảng cách](gap_width.png)

## **Câu Hỏi Thường Gặp**

**Các kiểu biểu đồ nào hỗ trợ chuỗi dữ liệu?**

Tất cả các kiểu biểu đồ được liệt kê trong enumeration [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) đều sử dụng dữ liệu biểu đồ, nhưng chuỗi của chúng không phải lúc nào cũng có cùng cấu trúc giá trị hoặc cùng cài đặt. Ví dụ, biểu đồ danh mục sử dụng danh mục và giá trị, biểu đồ phân tán sử dụng giá trị X và Y, và biểu đồ bong bóng thêm kích thước bong bóng. Sử dụng phương thức tạo điểm dữ liệu phù hợp với kiểu chuỗi. Các tùy chọn như độ chồng lắp và độ rộng khoảng cách chỉ áp dụng cho các nhóm thanh hoặc cột tương thích.

**Một nhóm chuỗi biểu đồ là gì?**

Một [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) chứa các chuỗi tương thích chia sẻ các cài đặt vẽ ở mức nhóm. Một biểu đồ kết hợp có thể chứa nhiều hơn một nhóm, vì vậy việc thay đổi nhóm thông qua một chuỗi không nhất thiết thay đổi mọi chuỗi trong biểu đồ.

**Biểu đồ mới tạo có dữ liệu mặc định không?**

Có. Mặc định, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) tạo các chuỗi, danh mục và giá trị mẫu. Bạn có thể chỉnh sửa các ô đó hoặc xóa cả hai bộ sưu tập chuỗi và danh mục trước khi thêm một tập dữ liệu tùy chỉnh hoàn toàn. Một overload cũng có thể tạo biểu đồ không có dữ liệu mặc định.

**Các đối tượng biểu đồ được kết nối với các ô trong sổ làm việc như thế nào?**

Tên chuỗi, nhãn danh mục và giá trị điểm dữ liệu tham chiếu các ô trong một [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Thay đổi một ô được tham chiếu sẽ cập nhật phần tử biểu đồ tương ứng. Khi bạn xây dựng dữ liệu tùy chỉnh, hãy giữ các hàng danh mục và các hàng giá trị chuỗi đồng bộ để mỗi điểm được vẽ dưới danh mục dự kiến.

**Làm sao để xóa một điểm mà không xóa toàn bộ chuỗi?**

Đặt ô giá trị liên quan thành `None` để giữ vị trí danh mục của điểm đó dưới dạng một điểm trống. Chỉ sử dụng [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) khi bạn muốn xóa tất cả các điểm trong chuỗi đó. Nếu bạn cũng xóa danh mục, hãy cập nhật mọi chuỗi để giá trị của chúng vẫn đồng bộ với bộ sưu tập danh mục.

**Các điểm trống được hiển thị như thế nào?**

Kết quả phụ thuộc vào kiểu biểu đồ và giá trị được cấu hình qua [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Các biểu đồ được hỗ trợ có thể hiển thị khoảng trống dưới dạng lỗ hổng, giá trị 0, hoặc bằng cách nối các điểm lân cận. Chọn cài đặt phù hợp với ý nghĩa của dữ liệu thiếu trong bản trình bày của bạn. Xem mục [Kiểm Soát Hiển Thị Các Ô Trống](#control-the-display-of-empty-cells) để biết ví dụ đầy đủ và so sánh trực quan.

**Các giá trị âm được định dạng như thế nào?**

Đối với các chuỗi thanh, cột và bong bóng được hỗ trợ, gọi [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) và đặt màu được trả về bởi [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Bạn có thể ghi đè hành vi cho một điểm riêng lẻ bằng [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Các phương thức này ảnh hưởng đến định dạng, không phải giá trị số lưu trữ.

**Định dạng nào thắng khi cả chuỗi và điểm đều được định dạng?**

Định dạng điểm dữ liệu rõ ràng có ưu tiên cho điểm đó. Các điểm khác tiếp tục sử dụng định dạng chuỗi rõ ràng hoặc, khi không có định dạng chuỗi, dùng kiểu và chủ đề biểu đồ tự động. Cài đặt nhóm như độ chồng lắp và độ rộng khoảng cách kiểm soát bố cục và không phải là việc ghi đè định dạng cấp điểm.

**Có giới hạn số lượng chuỗi mà một biểu đồ có thể chứa không?**

Aspose.Slides không áp đặt một giới hạn cố định riêng cho số chuỗi. Trên thực tế, các ràng buộc của tệp trình bày, bộ nhớ khả dụng, thời gian render và khả năng đọc biểu đồ sẽ quyết định một giới hạn thực tế.

**Tôi nên thay đổi gì khi các cột quá gần nhau hoặc quá xa?**

Gọi [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) trên nhóm chuỗi cha thích hợp. Tăng giá trị để mở rộng không gian giữa các cụm, hoặc giảm để đưa các cụm lại gần nhau hơn.