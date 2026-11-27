---
title: Định dạng biểu đồ trình chiếu trong Python
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
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho Python qua Java và nâng cao bài trình chiếu PowerPoint của bạn với các trục tùy chỉnh, phông chữ, định dạng số và viền biểu đồ bo tròn."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides. Nó trình bày cách tùy chỉnh các thành phần chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện diện mạo và khả năng đọc dữ liệu biểu đồ.

Nó cũng chỉ ra cách đặt thuộc tính phông chữ cho văn bản biểu đồ, áp dụng các định dạng số có sẵn cho dữ liệu biểu đồ và bật góc bo tròn cho khu vực biểu đồ. Các ví dụ này cho thấy cách kiểm soát cả phong cách trực quan và cách trình bày dữ liệu của biểu đồ trong một bản trình chiếu.

Đối với các màu nền và viền riêng biệt ở các khoảng tăng và giảm, xem **[ví dụ biểu đồ cổ phiếu](/slides/vi/python-java/create-chart/#create-stock-charts)**.

## **Định dạng Thực thể Biểu đồ**

Sử dụng [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) để định dạng tiêu đề biểu đồ, trục, đường lưới, chú giải và khu vực vẽ. Ví dụ này tạo một biểu đồ đường có ký hiệu và dữ liệu mặc định, sau đó áp dụng các kiểu văn bản và đường riêng cho trục giá trị và trục danh mục. Kích thước phông và độ rộng đường được chỉ định bằng điểm; nhãn danh mục được quay 45 độ.

Trục giá trị sử dụng [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) một cách độc lập với các ô nguồn. Thang đo chạy từ -2 đến 15, với khoảng chính là 2 và khoảng phụ là 0.5. Ví dụ cũng kết hợp định dạng phần trăm với [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) được đặt thành hàng nghìn, vì vậy hãy điều chỉnh các thiết lập này cho phù hợp với ý nghĩa và quy mô dữ liệu của bạn. Chú giải được để ngoài khu vực vẽ vì [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) được gọi với `False`. Các màu nền tường và sàn được cấu hình thông qua [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) và [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor), nhưng những bề mặt này chỉ hiển thị trong các biểu đồ 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Thuộc tính Phông chữ cho Biểu đồ**

Đặt kích thước phông chữ mặc định cho văn bản biểu đồ thông qua [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). Ví dụ tạo một biểu đồ cột nhóm với phông 20 điểm và bật nhãn giá trị cho chuỗi đầu tiên bằng [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Các phần tử văn bản có cài đặt phông chữ riêng có thể ghi đè lên mặc định của biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tái sử dụng Định dạng Khung Văn bản cho Chú giải Biểu đồ**

Để đồng nhất chú giải với tiêu đề slide, đặt phông tiêu đề qua [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) trên đoạn văn đầu tiên. Gọi [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) trên định dạng được trả về bởi [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) của chú giải. Điều này sao chép cài đặt khung văn bản, định dạng đoạn văn đầu tiên và các thuộc tính phông mặc định của đoạn văn đó. Định dạng được áp dụng trực tiếp cho các phần riêng lẻ hoặc cho các đoạn sau sẽ chỉ ảnh hưởng cục bộ tới nguồn.

Ví dụ sử dụng tiêu đề đậm, 26 điểm Calibri màu xanh hải quân làm mẫu. Sau khi định dạng chú giải, nó gọi [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) để áp dụng cùng một định dạng cho một chú thích riêng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong bản trình chiếu được lưu, chú giải và chú thích khớp với tiêu đề về kích thước, độ đậm và màu sắc. Chú giải vẫn hiển thị tên chuỗi, và chú thích giữ nguyên văn bản của mình. Nếu một phần trong chú thích đã có kích thước phông chữ cụ thể, kích thước đó sẽ ưu tiên hơn so với đoạn văn mặc định đã sao chép.

| Trước khi sao chép | Sau khi sao chép |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **Đặt Định dạng Số**

Sử dụng [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) để áp dụng một định dạng số tích hợp sẵn cho các ô trong bảng tính biểu đồ. Ví dụ này tạo một biểu đồ cột nhóm với dữ liệu mặc định, dựa trên ô và áp dụng chỉ số định dạng 10 (`0.00%`) cho mỗi ô giá trị chuỗi. Điều này thay đổi cách hiển thị giá trị trong bảng tính mà không thay đổi con số gốc; ví dụ, 0.25 sẽ hiển thị là 25.00%. Các định dạng trục và nhãn dữ liệu có thể được cấu hình riêng biệt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bảng sau liệt kê các chỉ số định dạng số tích hợp sẵn kèm theo các định dạng Excel tiêu biểu cho bản địa Anh (Hoa Kỳ). Các chuỗi định dạng và cách hiển thị có thể khác nhau tùy ứng dụng và bản địa, đặc biệt đối với tiền tệ và ngày tháng. Một số định dạng Excel cũng khác với mặc định trong chuẩn OOXML, như mô tả trong [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Chỉ số | Định dạng |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Đặt Viền Bo Tròn cho Khu vực Biểu đồ**

Gọi [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) với `True` để bo tròn các góc của khu vực biểu đồ. Ví dụ tạo một biểu đồ cột nhóm và sử dụng [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) để đặt viền của nó thành màu xám nguyên màu và kiểu đường đơn trước khi lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chỉnh sửa Chú thích Biểu đồ hiện có**

Một biểu đồ có thể chứa các hình dạng tùy chỉnh, chẳng hạn như chú thích văn bản giải thích trạng thái của báo cáo. Truy cập các hình dạng này qua [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). Bộ sưu tập được trả về bởi [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) chứa các hình dạng thuộc sở hữu của biểu đồ.

Một hộp văn bản thông thường đặt trên biểu đồ thuộc về slide, ngay cả khi nó trông giống như một phần của biểu đồ. Duyệt qua [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) sẽ tìm thấy biểu đồ và các hình dạng slide thông thường, nhưng không liệt kê các hình dạng riêng lẻ bên trong biểu đồ. Tiêu đề biểu đồ và nhãn dữ liệu là các thành phần biểu đồ riêng biệt, không phải là chú thích tùy chỉnh trong bộ sưu tập này.

Tải xuống **[chart-annotations.pptx](chart-annotations.pptx)** và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa một biểu đồ với một chú thích chưa nhóm có nội dung "Preliminary results", một đường thuộc sở hữu biểu đồ, và một hộp văn bản slide thông thường có nội dung "Slide overlay". Ví dụ tìm biểu đồ đầu tiên trên slide đó và thay đổi chú thích thành "Final results" khi báo cáo đã sẵn sàng để công bố. Nó kiểm tra bộ sưu tập rỗng và chỉ chỉnh sửa một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) có khung văn bản khác `None` được trả về bởi [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) và chứa văn bản mong đợi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

Đường và hộp văn bản slide vẫn giữ nguyên. Các hình ảnh sau đây hiển thị đầu vào và kết quả đã lưu, mở lại:

| Trước khi chỉnh sửa | Sau khi chỉnh sửa |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Ví dụ chỉ kiểm tra các hình dạng thuộc sở hữu cấp cao nhất của biểu đồ. Nếu một chú thích nằm bên trong một [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), hãy kiểm tra bộ sưu tập [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) của nhóm đó nữa. Lặp lại quy trình này một cách đệ quy cho các nhóm lồng nhau, áp dụng cùng các kiểm tra văn bản cho các hình dạng con của chúng. Một nhóm tự nó là một container; không nên coi nó là một hộp văn bản.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho các cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các biểu đồ dày đặc.

**Làm sao để xử lý nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), điều chỉnh vị trí nhãn, hiển thị nhãn chỉ cho các điểm được chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng màu nền gradient hoặc hoa văn cho các chuỗi không?**

Có. Các chuỗi hỗ trợ màu nền đặc, gradient và hoa văn. Trong thực tế, hãy sử dụng gradient một cách tiết kiệm và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.