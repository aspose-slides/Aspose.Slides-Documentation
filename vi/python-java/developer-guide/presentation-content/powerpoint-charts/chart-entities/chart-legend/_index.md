---
title: Tùy chỉnh chú giải biểu đồ trong bản trình bày bằng Python
linktitle: Chú giải biểu đồ
type: docs
url: /vi/python-java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Python thông qua Java để tối ưu hóa bản trình bày PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for Python via Java cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này cho thấy cách định vị và thay đổi kích thước chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

Phần Câu hỏi thường gặp đề cập đến các hành vi liên quan, bao gồm việc dự trữ không gian cho chú giải, hiển thị nhãn đa dòng, và kế thừa định dạng từ giao diện chủ đề của bản trình bày.

## **Định vị Chú giải**

Sử dụng các phương thức [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), và [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng tỷ lệ của kích thước biểu đồ.

Ví dụ này tạo một bản trình bày và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Khi chia các độ dịch và kích thước mong muốn của chú giải cho chiều rộng và chiều cao của biểu đồ, chúng được chuyển thành giá trị tương đối: chú giải được dịch 50 điểm so với góc trên‑trái của biểu đồ và có kích thước 100 x 100 điểm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Diễn đạt vị trí và kích thước của chú giải tương đối với biểu đồ.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Kích Thước Phông Chữ cho Chú Giải**

Sử dụng [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) của chú giải để truy cập định dạng văn bản và dùng [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) để đặt kích thước phông chữ tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt giới hạn tự động cho trục dọc và đặt phạm vi của nó từ -5 tới 10.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Kích Thước Phông Chữ cho Mục Chú Giải Riêng Lẻ**

Sử dụng tập hợp trả về bởi phương thức [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) của chú giải để truy cập định dạng cho một mục cụ thể. Chỉ mục mục nhập bắt đầu từ 0, vì vậy chỉ mục `1` đề cập tới mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định của nó bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai với chữ đậm, nghiêng và văn bản màu xanh 20 điểm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ẩn Các Mục Chú Giải Riêng Lẻ**

Để loại trừ một chuỗi phụ khỏi chú giải trong khi vẫn giữ dữ liệu của nó hiển thị, gọi [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) với `True` thông qua [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Thao tác này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hoặc các điểm dữ liệu. Ngược lại, gọi [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) với `False` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ mục `1`) và lưu bản trình bày. Sau đó nó khôi phục mục này bằng cách gọi [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) với `False` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Khôi phục cùng mục mà không thay đổi dữ liệu biểu đồ.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

So sánh dưới đây hiển thị cùng một biểu đồ với tất cả các mục hiển thị và với mục thứ hai bị ẩn; các cột của chuỗi thứ hai vẫn không thay đổi.

![So sánh một biểu đồ với tất cả các mục chú giải hiển thị và với Series 2 bị ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định các chuỗi. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (miếng), vì vậy hãy sử dụng [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) trên miếng đã chọn. API ghi lại phương thức điểm dữ liệu này cho các loại biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng giả định nó áp dụng cho biểu đồ vòng, vì chúng không nằm trong danh sách đó.

## **Câu Hỏi Thường Gặp**

**Tôi có thể làm cho biểu đồ dành chỗ cho chú giải thay vì phủ lên nó không?**

Có. Gọi [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) với `False` để dự trữ không gian cho chú giải thay vì cho phép nó phủ lên khu vực vẽ.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Các nhãn dài có thể xuống dòng khi chiều rộng khả dụng không đủ. Bạn cũng có thể sử dụng ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm thế nào để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Để lại màu sắc, độ đổ bóng và phông chữ của chú giải không được đặt để nó có thể kế thừa định dạng của chủ đề. Định dạng cụ thể sẽ ghi đè lên các cài đặt chủ đề tương ứng.