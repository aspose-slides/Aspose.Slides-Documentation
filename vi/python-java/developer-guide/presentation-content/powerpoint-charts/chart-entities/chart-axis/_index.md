---
title: Tùy chỉnh trục biểu đồ trong bản trình bày bằng Python
linktitle: Trục biểu đồ
type: docs
url: /vi/python-java/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
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
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho Python thông qua Java để tùy chỉnh trục biểu đồ trong bản trình bày PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides cho Python thông qua Java. Nó bao gồm các giá trị trục đã tính toán, chuyển đổi hàng và cột biểu đồ, hiển thị trục, khoảng cách nhãn danh mục và đánh dấu tick, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy các giá trị tối đa trên trục dọc của biểu đồ**

Tạo một [Bản trình bày](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) trước khi đọc các giá trị trục đã tính để bố cục biểu đồ được cập nhật.

Đọc [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) và [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) để lấy giới hạn trục, và [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) và [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) để lấy khoảng cách tick. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) và [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) cung cấp tỉ lệ đơn vị thời gian, có liên quan đến trục ngày. Ví dụ lưu các giá trị này vào các biến cục bộ và lưu biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Hoán đổi dữ liệu giữa các trục**

Sử dụng [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) để hoán đổi vai trò của series và categories trong dữ liệu biểu đồ. Mỗi category cũ trở thành một series, và mỗi series cũ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không hoán đổi các trục ngang và dọc. Ví dụ sử dụng [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) để liên kết dữ liệu mặc định với `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ có bốn series và ba category.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đảo ngược thứ tự vẽ của một trục**

Sử dụng [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) để đảo ngược một trục category hoặc value. Ví dụ, một biểu đồ thanh ngang có thể hiển thị các giai đoạn dự án từ trên xuống dưới theo cùng thứ tự với bảng tính: Kế hoạch, Phát triển, Kiểm thử. Đảo ngược trục thay đổi hướng vẽ; nó không sắp xếp hay thay đổi dữ liệu trong workbook. Ngược lại, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) hoán đổi vai trò của series và categories.

Ví dụ sau tạo một biểu đồ thanh ngang với ba giai đoạn và một series. Nó lưu một bản trình bày với ba slide: thứ tự bình thường, categories đảo ngược, và values đảo ngược. Mỗi bản sao sử dụng cùng một dataset, và chỉ một trục được đảo ngược trên mỗi bản sao.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Slide 2: hiển thị danh mục đầu tiên ở trên cùng.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Giữ trục giá trị ngang ở dưới cùng.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Slide 3: đảo ngược chỉ thang số ngang.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đảo ngược một trục cũng có thể di chuyển trục vuông góc sang phía đối diện của biểu đồ. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) kiểm soát nơi trục còn lại cắt trục đang được cấu hình. Trong slide 2, gọi nó với [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) trên trục category đã đảo ngược giữ trục value ngang ở dưới cùng. Đối với một điểm cắt cụ thể, sử dụng [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Kiểm tra cài đặt cắt khi thay đổi hướng, đặc biệt nếu biểu đồ đã có một điểm cắt tùy chỉnh. Gọi [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) với `False` để khôi phục hướng vẽ bình thường; cài đặt cắt là riêng biệt.

| Thứ tự bình thường (slide 1) | Danh mục được đảo ngược (slide 2) | Giá trị được đảo ngược (slide 3) |
| --- | --- | --- |
| ![Biểu đồ thanh ngang với thứ tự trục danh mục và giá trị bình thường](axis-order-normal.png) | ![Biểu đồ thanh ngang với danh mục hiển thị từ trên xuống dưới](axis-order-categories-reversed.png) | ![Biểu đồ thanh ngang với trục giá trị đảo ngược và số 0 ở bên phải](axis-order-values-reversed.png) |
| Danh mục chạy từ dưới lên trên; giá trị tăng từ trái sang phải. | Kế hoạch, Phát triển và Kiểm thử chạy từ trên xuống dưới. Giá trị và thứ tự hàng trong sổ làm việc không thay đổi. | Danh mục giữ nguyên thứ tự bình thường; giá trị tăng từ phải sang trái. Trục danh mục cắt tại số 0 ở bên phải. |

## **Vô hiệu hoá trục dọc cho biểu đồ đường**

Gọi [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) với `False` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục dọc ẩn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Vô hiệu hoá trục ngang cho biểu đồ đường**

Gọi [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) với `False` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu lại với trục ngang ẩn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Thay đổi trục Category**

Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) để chọn trục category dạng ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là shape đầu tiên trên slide đầu tiên và các ô category chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Gọi [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) với `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) với `1`, và [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) với [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) để đặt các tick chính ở khoảng cách một tháng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Kiểm soát khoảng cách nhãn trục Category**

Khi một biểu đồ có nhiều category, giảm số lượng nhãn trục hiển thị mà không loại bỏ category hoặc điểm dữ liệu. Gọi [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) với `False`, sau đó truyền khoảng cách category mong muốn vào [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Đối với các category dạng văn bản trong thứ tự bình thường, việc đếm bắt đầu từ category đầu tiên:

| Khoảng cách | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Khoảng cách `3` hiển thị mỗi nhãn thứ ba, để hai nhãn ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian có sẵn; nó không nhất thiết hiển thị mọi nhãn.

Các đánh dấu tick có các điều khiển riêng. Gọi [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) với `False` và sử dụng [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một đánh dấu tick ở mỗi khoảng category trong khi nhãn chỉ xuất hiện mỗi category thứ ba. Sử dụng [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) với kiểu hiển thị để bạn có thể thấy kết quả. Gọi lại bất kỳ setter tự động nào với `True` sẽ để biểu đồ chọn lại khoảng cách đó.

Ví dụ tự chứa sau tạo 24 category và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với các tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho mật độ dễ nhận thấy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Slide 2: hiển thị mỗi nhãn thứ ba, nhưng giữ một dấu tick cho mỗi danh mục.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Slide 3: cho phép biểu đồ tự chọn lại cả hai khoảng cách.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Khoảng cách tự động (slide 1):** Trong bản render này, mỗi nhãn category thứ hai được hiển thị và xuống hai dòng. Kết quả tự động có thể thay đổi tùy thuộc vào kích thước biểu đồ, phông chữ và bộ render.

![Khoảng cách nhãn category tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Khoảng cách thủ công (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi các tick vẫn ở mỗi khoảng category. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng giá trị. Slide 3 khôi phục giao diện tự động đã nêu ở trên.

![Khoảng cách nhãn category thủ công ba với tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn trục và khoảng cách đúng**

Sử dụng khoảng cách dựa trên số lượng category này cho một trục category dạng văn bản, chẳng hạn trục category của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục category nằm dọc, vì vậy áp dụng các cài đặt này cho trục được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Khoảng cách đánh dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục này.

Không sử dụng khoảng cách nhãn category để đặt thang số cho trục value. Trên trục value, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) chỉ định sự khác biệt giữa các giá trị: ví dụ, một đơn vị chính `10` tạo các tick tại 0, 10, 20, … khi trục bắt đầu từ 0. Khoảng cách nhãn category `3` đếm vị trí category, bất kể giá trị dữ liệu. Các biểu đồ scatter và bubble sử dụng trục value thay vì trục category dạng văn bản. Đối với trục ngày, sử dụng các đơn vị và tỉ lệ thời gian như mô tả trong [Thay đổi trục Category](#thay-đổi-trục-category).

## **Đặt định dạng ngày cho các giá trị trục Category**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Các ngày được lưu dưới dạng số serial OLE Automation trong worksheet đầu tiên (chỉ số `0`), được tính là số ngày kể từ ngày 30 tháng 12 năm 1899 cho các ngày này. Sử dụng [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) với [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), gọi [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) với `False`, và truyền `yyyy` vào [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) để nhãn category hiển thị năm bốn chữ số độc lập với định dạng ô.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đặt góc xoay cho tiêu đề trục biểu đồ**

Gọi [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) với `True` trên trục dọc, cung cấp văn bản tiêu đề, và đặt góc xoay trong định dạng khối văn bản của tiêu đề. Góc được đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục giá trị xoay 90 độ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đặt vị trí trục trên trục Category hoặc Value**

Sử dụng [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) để kiểm soát trục value có cắt trục category giữa các category hay tại các đánh dấu tick của category. Cài đặt này áp dụng cho các trục category. Ví dụ đặt nó thành `True` trên trục category ngang của một biểu đồ cột và lưu kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Đặt đơn vị hiển thị trên trục Value của biểu đồ**

Sử dụng [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) để thu phóng các nhãn trên trục value mà không thay đổi dữ liệu gốc. Với [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) đặt thành `Millions`, một giá trị 60.000.000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị triệu cho trục dọc của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **Cấu hình trục Value logarit**

Một trục Value logarit hữu ích khi các giá trị dương trải rộng qua nhiều bậc độ. Ví dụ, một dịch vụ có thể nhận 10, 100, 1.000, 10.000 và 100.000 yêu cầu trong năm kỳ. Trên thang tuyến tính, các giá trị nhỏ nằm gần nhau ở phía zero. Thang logarit làm cho sự tăng trưởng tương đối dễ so sánh hơn: khoảng cách bằng nhau đại diện cho tỉ lệ bằng nhau thay vì chênh lệch bằng nhau.

Gọi [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) với `True` trên trục value và sử dụng [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) để chọn cơ số. Điều này thay đổi cách các giá trị hiện tại được hiển thị; nó không thay đổi dữ liệu hay thêm đường xu hướng logarit. Đường xu hướng là một tính năng riêng, đại diện cho mối quan hệ khớp trong dữ liệu.

### **Chọn trục Value và cơ số**

Đối với biểu đồ đường hoặc cột, trục value được trả về bởi [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Đối với biểu đồ thanh ngang, nó được trả về bởi [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Các biểu đồ scatter và bubble có hai trục value, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỷ lệ logarit cho trục category.

Cơ số logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ số từ `2` đến `1000`, bao gồm; các cơ số phân số như `2.5` cũng được hỗ trợ. Với cơ số `10`, các lũy thừa liên tiếp như 10, 100, 1.000 và 10.000 được cách đều nhau.

### **So sánh thang tuyến tính và logarit**

Ví dụ tự chứa sau tạo một biểu đồ đường với năm số lượng yêu cầu trên slide đầu tiên, sau đó sao chép slide đó và bật trục value logarit cơ số 10 trên slide thứ hai. Cả hai slide giữ cùng dữ liệu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi tỷ lệ trục giá trị của bản sao.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Thang tuyến tính (slide 1):** Khoảng cách dọc bằng nhau đại diện cho chênh lệch số yêu cầu bằng nhau. Giá trị lớn nhất chiếm phần lớn biểu đồ, làm cho các giá trị nhỏ khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm số lượng yêu cầu trên trục value tuyến tính](value-axis-linear.png)

**Thang logarit (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỉ lệ bằng nhau. Mỗi kỳ có số yêu cầu gấp mười lần kỳ trước, vì vậy các điểm tạo thành một đường thẳng tăng trên thang logarit cơ số 10. Các nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![Năm số lượng yêu cầu giống nhau trong PowerPoint trên trục value logarit cơ số 10](value-axis-logarithmic.png)

### **Xử lý giá trị zero và âm**

Thang logarit chỉ hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật. Nếu giá trị zero hoặc âm có ý nghĩa, hãy giữ thang tuyến tính hoặc hiển thị chúng riêng biệt. Nếu việc loại bỏ các giá trị đó là phù hợp cho phân tích, hãy giải thích lý do. Đừng thay thế âm thầm bằng các số dương nhỏ, vì điều này thay đổi ý nghĩa dữ liệu. Bất kỳ giá trị min hoặc max được cấu hình thủ công cho trục logarit cũng phải là dương.

## **Câu hỏi thường gặp**

**Làm thế nào để đặt giá trị mà tại đó một trục cắt trục kia (điểm cắt trục)?**

Sử dụng [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) để chọn hành vi cắt. Để chỉ định một giá trị cắt số, sử dụng [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Các cài đặt này cho phép bạn di chuyển điểm cắt trục tới một mức nền phù hợp.

**Làm sao tôi có thể định vị nhãn tick so với trục?**

Gọi [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) sử dụng [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để kiểm soát các dấu tick сами, sử dụng [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) hoặc [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); các cài đặt này riêng biệt với vị trí nhãn.