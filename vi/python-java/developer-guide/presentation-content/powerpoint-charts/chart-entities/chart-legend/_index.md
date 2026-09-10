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

Aspose.Slides cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này cho thấy cách đặt vị trí và kích thước của chú giải, đặt kích thước phông chữ cho toàn bộ chú giải và áp dụng định dạng cho một mục chú giải riêng lẻ.

Nó cũng đề cập đến một số hành vi liên quan trong phần Câu hỏi thường gặp, bao gồm việc sử dụng chế độ không chồng lên để vùng vẽ biểu đồ nhường chỗ cho chú giải, cho phép nhãn chú giải dài được cuộn hoặc sử dụng ngắt dòng, và cho phép định dạng chú giải kế thừa từ giao diện bản trình bày khi không áp dụng các thiết lập màu và nền cụ thể.

## **Định vị chú giải**

Để thiết lập các thuộc tính của chú giải, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide.
1. Thêm một biểu đồ vào slide.
1. Đặt các thuộc tính của chú giải.
1. Lưu bản trình bày dưới dạng tệp PPTX.

Ví dụ sau thiết lập vị trí và kích thước của chú giải biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpure.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Tạo một bản trình bày trống.
presentation = Presentation()
try:
    # Lấy tham chiếu tới slide.
    slide = presentation.getSlides().get_Item(0)

    # Thêm biểu đồ cột nhóm vào slide.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Đặt các thuộc tính của chú giải.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Lưu bản trình bày vào đĩa.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt kích thước phông chữ cho chú giải**

Aspose.Slides for Python via Java cho phép bạn đặt kích thước phông chữ của chú giải. Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Tạo biểu đồ mặc định.
1. Đặt kích thước phông chữ.
1. Đặt giá trị tối thiểu cho trục.
1. Đặt giá trị tối đa cho trục.
1. Lưu bản trình bày vào đĩa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Tạo một bản trình bày trống.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**

Aspose.Slides for Python via Java cho phép bạn đặt kích thước phông chữ cho các mục chú giải riêng lẻ. Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Tạo biểu đồ mặc định.
1. Truy cập một mục chú giải.
1. Đặt kích thước phông chữ.
1. Lưu bản trình bày vào đĩa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Tạo một bản trình bày trống.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chú giải để biểu đồ tự động cấp phát không gian cho nó thay vì phủ lên không?**

Có. Sử dụng [setOverlay](https://reference.aspose.com/slides/vi/python-java/aspose.slides/legend/#setOverlay) với `False` để bật chế độ không chồng lên; trong trường hợp này, vùng vẽ sẽ thu nhỏ lại để chứa chú giải.

**Tôi có thể tạo nhãn chú giải nhiều dòng không?**

Có. Nhãn dài sẽ tự động cuộn khi không gian không đủ; ngắt dòng bắt buộc được hỗ trợ bằng ký tự xuống dòng trong tên chuỗi.

**Làm thế nào để chú giải tuân theo bảng màu của giao diện bản trình bày?**

Không đặt màu, nền hoặc phông chữ cụ thể cho chú giải hoặc văn bản của nó. Khi đó chúng sẽ kế thừa từ giao diện và cập nhật đúng khi thiết kế thay đổi.