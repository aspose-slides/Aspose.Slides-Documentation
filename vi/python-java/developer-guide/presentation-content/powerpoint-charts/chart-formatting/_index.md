---
title: Định dạng biểu đồ trong trình chiếu bằng Python
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/python-java/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Python qua Java và nâng cao bản trình chiếu PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, vùng vẽ và màu nền tường để cải thiện ngoại hình và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật góc bo tròn cho khu vực biểu đồ. Tất cả các ví dụ này cho thấy cách kiểm soát cả phong cách hình ảnh và cách trình bày dữ liệu của biểu đồ trong một bản trình chiếu.

## **Định dạng các thực thể biểu đồ**
Aspose.Slides for Python via Java cho phép nhà phát triển thêm các biểu đồ tùy chỉnh vào các slide từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị.

Aspose.Slides for Python via Java cung cấp API đơn giản để quản lý các thực thể biểu đồ và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Truy cập slide theo chỉ mục.
1. Thêm một biểu đồ loại mong muốn với dữ liệu mặc định (ví dụ này sử dụng [ChartType.LineWithMarkers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Truy cập trục giá trị của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của trục giá trị.
   1. Đặt **Line format** cho các đường lưới phụ của trục giá trị.
   1. Đặt **Number Format** cho trục giá trị.
   1. Đặt **minimum, maximum, major, and minor units** cho trục giá trị.
   1. Đặt **Text Properties** cho dữ liệu trục giá trị.
   1. Đặt **Title** cho trục giá trị.
1. Truy cập trục danh mục của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của trục danh mục.
   1. Đặt **Line format** cho các đường lưới phụ của trục danh mục.
   1. Đặt **Text Properties** cho dữ liệu trục danh mục.
   1. Đặt **Title** cho trục danh mục.
   1. Đặt **Label Positioning** cho trục danh mục.
   1. Đặt **Rotation Angle** cho nhãn trục danh mục.
1. Truy cập chú giải của biểu đồ và đặt **text properties** cho nó.
1. Hiển thị chú giải biểu đồ mà không làm chồng lên biểu đồ.
1. Truy cập **secondary value axis** của biểu đồ và đặt các thuộc tính sau:
   1. Bật **value axis** phụ.
   1. Đặt **Line Format** cho trục giá trị phụ.
   1. Đặt **Number Format** cho trục giá trị phụ.
   1. Đặt **minimum, maximum, major, and minor units** cho trục giá trị phụ.
1. Vẽ chuỗi biểu đồ đầu tiên trên trục giá trị phụ.
1. Đặt màu nền tường phía sau của biểu đồ.
1. Đặt màu nền vùng vẽ của biểu đồ.
1. Ghi bản trình chiếu đã chỉnh sửa ra tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

    # Tạo một thể hiện của lớp Presentation
    presentation = Presentation()
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Thêm biểu đồ mẫu
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Đặt tiêu đề biểu đồ
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Đặt định dạng đường lưới chính cho trục giá trị
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Đặt định dạng đường lưới phụ cho trục giá trị
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Đặt định dạng số cho trục giá trị
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Đặt thuộc tính văn bản cho trục giá trị
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Đặt tiêu đề cho trục giá trị
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Đặt định dạng đường lưới chính cho trục danh mục
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Đặt định dạng đường lưới phụ cho trục danh mục
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Đặt thuộc tính văn bản cho trục danh mục
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Đặt tiêu đề danh mục
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Đặt vị trí nhãn trục danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Đặt góc quay nhãn trục danh mục
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Đặt thuộc tính văn bản cho chú giải
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Hiển thị chú giải biểu đồ mà không chồng lên biểu đồ

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Đặt trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Đặt định dạng số cho trục giá trị phụ
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Đặt giá trị tối đa, tối thiểu cho biểu đồ
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Đặt màu tường phía sau của biểu đồ
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Đặt màu vùng vẽ
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Lưu bản trình chiếu
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt thuộc tính phông chữ cho biểu đồ**
Aspose.Slides for Python via Java hỗ trợ đặt thuộc tính phông chữ cho các biểu đồ. Thực hiện các bước sau để đặt thuộc tính phông chữ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
- Thêm một biểu đồ vào slide.
- Đặt chiều cao phông chữ.
- Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau minh họa các bước này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng số**
Aspose.Slides for Python via Java cung cấp API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Truy cập slide theo chỉ mục.
1. Thêm một biểu đồ loại mong muốn với dữ liệu mặc định (ví dụ này sử dụng [ChartType.ClusteredColumn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Đặt định dạng số có sẵn từ các giá trị có sẵn.
1. Duyệt qua các ô dữ liệu trong mỗi chuỗi biểu đồ và đặt định dạng số cho chúng.
1. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation
presentation = Presentation()
try:
    # Truy cập slide đầu tiên của bản trình chiếu
    slide = presentation.getSlides().get_Item(0)

    # Thêm biểu đồ cột nhóm mặc định
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Truy cập bộ sưu tập chuỗi biểu đồ
    chart_series_collection = chart.getChartData().getSeries()

    # Duyệt qua từng chuỗi biểu đồ
    for chart_series in chart_series_collection:
        # Duyệt qua từng điểm dữ liệu trong chuỗi
        for data_point in chart_series.getDataPoints():
            # Đặt định dạng số
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Lưu bản trình chiếu
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các định dạng số có sẵn và chỉ mục của chúng được liệt kê dưới đây:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Đặt viền bo tròn cho khu vực biểu đồ**
Aspose.Slides for Python via Java hỗ trợ góc bo tròn cho khu vực biểu đồ thông qua các phương thức [hasRoundedCorners](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#hasRoundedCorners) và [setRoundedCorners](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#setRoundedCorners) của lớp [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm một biểu đồ vào slide.
1. Đặt kiểu và kiểu nền cho đường viền biểu đồ.
1. Bật góc bo tròn.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau minh họa các bước này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho cột/khu vực trong khi vẫn giữ viền không trong suốt không?**

Có. Độ trong suốt của nền và viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao để xử lý nhãn dữ liệu khi chúng bị chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), đặt độ lệch/vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng thành “giá trị + chú giải”.

**Tôi có thể áp dụng màu nền gradient hoặc hoa văn cho chuỗi không?**

Có. Cả màu nền đặc và gradient/hoa văn thường đều khả dụng. Trong thực tế, nên dùng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.