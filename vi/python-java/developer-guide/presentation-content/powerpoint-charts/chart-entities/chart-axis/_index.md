---
title: Tuỳ chỉnh trục biểu đồ trong bản trình chiếu bằng Python
linktitle: Trục biểu đồ
type: docs
url: /vi/python-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tuỳ chỉnh trục
- thao tác trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Python thông qua Java để tuỳ chỉnh trục biểu đồ trong các bản trình chiếu PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ trong Aspose.Slides. Nó cho thấy cách lấy các giá trị thực tế của trục, hoán đổi dữ liệu giữa các trục, ẩn trục dọc hoặc trục ngang cho biểu đồ đường, thay đổi loại trục danh mục, đặt định dạng ngày cho các giá trị trục danh mục, quay tiêu đề trục, đặt vị trí trục và đặt đơn vị hiển thị của trục giá trị.

## **Lấy Các Giá Trị Tối Đa Trên Trục Dọc Của Biểu Đồ**

Aspose.Slides cho Python thông qua Java cho phép bạn lấy các giá trị tối thiểu và tối đa trên trục dọc. Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Lấy giá trị tối đa thực tế trên trục.
1. Lấy giá trị tối thiểu thực tế trên trục.
1. Lấy đơn vị chính thực tế của trục.
1. Lấy đơn vị phụ thực tế của trục.
1. Lấy tỉ lệ đơn vị chính thực tế của trục.
1. Lấy tỉ lệ đơn vị phụ thực tế của trục.

Mã mẫu này — một triển khai các bước trên — cho bạn thấy cách lấy các giá trị cần thiết trong Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Lưu bản trình chiếu
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hoán đổi Dữ liệu Giữa Các Trục**

Aspose.Slides cho phép bạn nhanh chóng hoán đổi dữ liệu giữa các trục — dữ liệu trên trục dọc (trục y) chuyển sang trục ngang (trục x) và ngược lại.

Mã Python này cho bạn thấy cách thực hiện việc hoán đổi dữ liệu giữa các trục trên một biểu đồ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Tải dữ liệu mặc định của biểu đồ vào workbook — switchRowColumn chuyển đổi workbook,
    # vì vậy phải được điền dữ liệu trước
    workbook = chart.getChartData().getChartDataWorkbook()

    # Chuyển đổi hàng và cột
    chart.getChartData().switchRowColumn()

    # Lưu bản trình chiếu
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vô hiệu hoá Trục Dọc cho Biểu đồ Đường**

Mã Python này cho bạn thấy cách ẩn trục dọc cho biểu đồ đường:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vô hiệu hoá Trục Ngang cho Biểu đồ Đường**

Mã này cho bạn thấy cách ẩn trục ngang cho biểu đồ đường:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay đổi Trục Danh mục**

Sử dụng phương thức [setCategoryAxisType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setCategoryAxisType), bạn có thể chỉ định loại trục danh mục mong muốn (**date** hoặc **text**). Mã Python này minh họa thao tác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Đặt Định dạng Ngày cho Các Giá trị Trục Danh mục**

Aspose.Slides cho Python thông qua Java cho phép bạn đặt định dạng ngày cho một giá trị trục danh mục. Thao tác này được minh họa trong mã Python sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Góc Xoay cho Tiêu đề Trục Biểu đồ**

Aspose.Slides cho Python thông qua Java cho phép bạn đặt góc xoay cho tiêu đề trục biểu đồ. Mã Python này minh họa thao tác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Vị trí Trục trên Trục Danh mục hoặc Trục Giá trị**

Aspose.Slides cho Python thông qua Java cho phép bạn đặt vị trí trục trên trục danh mục hoặc trục giá trị. Mã Python này cho thấy cách thực hiện nhiệm vụ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Đơn vị Hiển thị trên Trục Giá trị của Biểu đồ**

Aspose.Slides cho Python thông qua Java cho phép bạn đặt đơn vị hiển thị cho trục giá trị của biểu đồ. Trục sau đó sẽ tỷ lệ các nhãn đánh dấu theo đơn vị đó: với [DisplayUnitType.Millions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/displayunittype/#Millions), một trục có giá trị lên tới 60,000,000 sẽ được gán nhãn từ 0 đến 60. Mã Python này minh họa thao tác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Làm thế nào tôi có thể đặt giá trị mà tại đó một trục cắt qua trục còn lại (cắt trục)?**

Các trục cung cấp một [cài đặt cắt trục](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setCrossType): bạn có thể chọn cắt tại số 0, tại danh mục/giá trị tối đa, hoặc tại một giá trị số cụ thể. Điều này hữu ích để di chuyển trục X lên hoặc xuống hoặc để nhấn mạnh một đường cơ sở.

**Làm thế nào tôi có thể đặt vị trí các dấu tick so với trục (cắt, ngoài, trong)?**

Đặt [vị trí dấu tick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/axis/#setMajorTickMark) thành "cross", "outside" hoặc "inside". Điều này ảnh hưởng đến khả năng đọc và giúp tiết kiệm không gian, đặc biệt trên các biểu đồ nhỏ.