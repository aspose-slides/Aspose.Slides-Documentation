---
title: Quản lý Nhãn Dữ liệu Biểu đồ trong Bản trình chiếu bằng Python
linktitle: Nhãn Dữ liệu
type: docs
url: /vi/python-java/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python thông qua Java để tạo các slide sinh động hơn."
---
## **Giới thiệu**

Nhãn dữ liệu hiển thị thông tin về chuỗi biểu đồ và các điểm dữ liệu riêng lẻ, giúp người đọc xác định giá trị và hiểu biểu đồ. Bài viết này giải thích cách định dạng giá trị, hiển thị phần trăm, đọc văn bản nhãn, kiểm soát nhãn vượt quá giá trị tối đa của trục, điều chỉnh khoảng cách nhãn trục danh mục và định vị nhãn biểu đồ tròn.

## **Đặt độ chính xác dữ liệu trong Nhãn Dữ liệu biểu đồ**

Sử dụng [setNumberFormatOfValues](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) để định dạng giá trị của chuỗi. Ví dụ này tạo một biểu đồ đường với dữ liệu mặc định, hiển thị bảng dữ liệu của nó và bật nhãn giá trị cho chuỗi đầu tiên. Định dạng `#,##0.00` hiển thị dấu phân cách hàng nghìn và hai chữ số thập phân mà không thay đổi giá trị gốc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hiển thị phần trăm dưới dạng nhãn**

Đối với biểu đồ cột chồng, tính mỗi giá trị dưới dạng phần trăm của tổng danh mục và gán văn bản vào khung văn bản được trả về bởi [getTextFrameForOverriding](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Ví dụ này sử dụng dữ liệu biểu đồ mặc định và hiển thị phần trăm với hai chữ số thập phân trong phông chữ 8 điểm. Các danh mục có tổng bằng không sẽ bị bỏ qua để tránh chia cho không. Tính lại văn bản nhãn tùy chỉnh nếu dữ liệu biểu đồ thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt ký hiệu phần trăm với Nhãn Dữ liệu biểu đồ**

Khi các giá trị được lưu dưới dạng phân số, sử dụng [setNumberFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setNumberFormat) để hiển thị phần trăm. Gửi `False` vào [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) để áp dụng định dạng nhãn độc lập với các ô nguồn.

Ví dụ này tạo một biểu đồ cột chồng 100% với các chuỗi màu đỏ và xanh lam qua bốn danh mục. Mỗi cặp giá trị cộng lại bằng 1. Định dạng nhãn `0.0%` hiển thị 0.30 thành 30.0%, trong khi trục dọc sử dụng hai chữ số thập phân. Cả hai chuỗi đều sử dụng nhãn màu trắng, kích thước 10 điểm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đọc văn bản thực tế của Nhãn Dữ liệu**

Sử dụng [getActualLabelText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#getActualLabelText) để lấy văn bản do cài đặt của nhãn dữ liệu tạo ra. Điều này hữu ích khi trích xuất nhãn cho báo cáo, tìm kiếm nội dung bản trình chiếu hoặc xác nhận các biểu đồ đã tạo. Trong ví dụ dưới đây, định dạng nhãn dữ liệu mặc định kết hợp tên danh mục, tên chuỗi và giá trị. Một điểm định dạng giá trị của nó dưới dạng phần trăm, và một điểm khác sử dụng văn bản tùy chỉnh từ [getTextFrameForOverriding](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Số được lưu trong một điểm dữ liệu vẫn là `0.75`, ngay cả khi nhãn của nó hiển thị `75%` cùng với tên danh mục và chuỗi. Văn bản tùy chỉnh thay thế nhãn đã tạo. [getActualLabelText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#getActualLabelText) trả về chuỗi nhãn kết quả trong cả hai trường hợp. Kiểm tra [isVisible](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#isVisible) riêng biệt, như đã trình bày ở trên, khi bạn muốn trích xuất chỉ những nhãn hiển thị.

## **Kiểm soát Nhãn Dữ liệu vượt quá Giá trị Tối đa của Trục**

Khi bạn giới hạn phạm vi trục theo cách thủ công, một số điểm dữ liệu có thể vượt quá giá trị tối đa của nó. Sử dụng [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) để kiểm soát việc hiển thị nhãn dữ liệu của chúng. Cài đặt này thay đổi khả năng hiển thị nhãn; nó không thay đổi phạm vi trục hay giá trị dữ liệu gốc.

Ví dụ dưới đây tạo một biểu đồ cột cụm 2D với các giá trị 60 và 120. Nó gửi `False` vào [setAutomaticMaxValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setAutomaticMaxValue) và đặt giá trị tối đa thành 100 bằng [setMaxValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setMaxValue) trên trục dọc. Slide đầu tiên cho phép nhãn vượt quá giá trị tối đa; bản sao của slide đó vô hiệu hoá chúng. Cả hai slide đều được lưu trong `DataLabelsOverMaximum.pptx`.

Bật nhãn giá trị bằng [setShowValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setShowValue). Cài đặt ở mức biểu đồ không tự động bật hiển thị giá trị hoặc ghi đè lên việc tắt hiển thị giá trị của nhãn riêng lẻ. Ví dụ này bật giá trị cho toàn bộ chuỗi và sử dụng [setPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabelformat/#setPosition) để đặt nhãn ở cuối ngoài của mỗi cột.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các hình ảnh dưới đây cho thấy các slide đã lưu được render bằng Microsoft PowerPoint. Với `True`, nhãn **120** hiển thị ở rìa trên; với `False`, nó bị ẩn. Nhãn **60** vẫn hiển thị, giá trị tối đa của trục vẫn là **100**, và điểm dữ liệu thứ hai vẫn là **120** trong cả hai trường hợp.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Biểu đồ PowerPoint hiển thị nhãn giá trị 120 với tối đa trục là 100](data-labels-over-maximum-true.png) | ![Biểu đồ PowerPoint ẩn nhãn giá trị 120 với tối đa trục là 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ví dụ này sử dụng một biểu đồ cột 2D với trục giá trị. Các biểu đồ không có trục giá trị, như biểu đồ tròn và biểu đồ vòng, không có giá trị tối đa của trục để giới hạn theo cách này.
{{% /alert %}}

## **Đặt Khoảng cách Nhãn từ Trục**

Sử dụng [setLabelOffset](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setLabelOffset) để kiểm soát khoảng cách giữa nhãn trục danh mục và trục. Giá trị là phần trăm của kích thước phông chữ tối đa của các nhãn trục. Ví dụ này tạo một biểu đồ cột cụm và đặt khoảng cách nhãn trục ngang thành 500. Cài đặt này ảnh hưởng đến nhãn trục danh mục hơn là nhãn gắn vào các điểm dữ liệu riêng lẻ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Điều chỉnh vị trí Nhãn**

Trên biểu đồ tròn, điều chỉnh vị trí nhãn dữ liệu để cải thiện khoảng cách và tạo không gian cho các đường dẫn. Ví dụ này hiển thị giá trị của điểm dữ liệu đầu tiên, đặt nhãn của nó bên ngoài phần bánh và điều chỉnh độ dịch ngang và dọc bằng [setX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#setX) và [setY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/datalabel/#setY). Các độ dịch này tương đối so với độ rộng và độ cao của biểu đồ, tương ứng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Biểu đồ tròn với vị trí nhãn dữ liệu được điều chỉnh](pie-chart-adjusted-label.png)

## **FAQ**

**Làm sao để ngăn nhãn dữ liệu chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ danh mục) hoặc chỉ hiển thị nhãn cho các giá trị cực trị hoặc các điểm quan trọng.

**Làm sao để tắt nhãn chỉ cho các giá trị bằng không, âm hoặc trống?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị thiếu theo quy tắc đã định.

**Làm sao để đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Thiết lập rõ ràng họ phông chữ và kích thước, đồng thời xác minh phông chữ có sẵn trong môi trường render để tránh việc fallback.