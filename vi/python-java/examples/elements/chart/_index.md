---
title: Biểu đồ
type: docs
weight: 60
url: /vi/python-java/examples/elements/chart/
keywords:
- biểu đồ
- thêm biểu đồ
- truy cập biểu đồ
- xóa biểu đồ
- cập nhật biểu đồ
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo, truy cập, xóa và cập nhật biểu đồ trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java."
---
Bài viết này minh họa cách thêm, truy cập, xóa và cập nhật biểu đồ trong một bản trình chiếu bằng cách sử dụng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy. Chạy ví dụ thêm đầu tiên để tạo `chart.pptx` cho các ví dụ còn lại.

## **Thêm biểu đồ**

Thêm một biểu đồ khu vực vào slide đầu tiên và lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một biểu đồ khu vực vào slide đầu tiên.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập biểu đồ**

Tìm biểu đồ đầu tiên trong bộ sưu tập hình dạng trên slide đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Truy cập biểu đồ đầu tiên trên slide.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Xóa biểu đồ**

Xóa biểu đồ đầu tiên khỏi slide và lưu bản trình chiếu đã được chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Tìm và xóa biểu đồ đầu tiên trên slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cập nhật dữ liệu biểu đồ**

Hiển thị tiêu đề biểu đồ, thay đổi văn bản của nó và lưu bản trình chiếu đã cập nhật.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Tìm biểu đồ đầu tiên trên slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Hiển thị tiêu đề biểu đồ và thay đổi nội dung văn bản của nó.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```