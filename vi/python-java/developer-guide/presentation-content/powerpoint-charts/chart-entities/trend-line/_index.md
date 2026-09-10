---
title: Thêm Đường Xu Hướng vào Biểu Đồ Bài Thuyết Trình bằng Python
linktitle: Đường Xu Hướng
type: docs
url: /vi/python-java/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint bằng Aspose.Slides cho Python thông qua Java — một hướng dẫn thực tiễn để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó mô tả cách tạo một biểu đồ, thêm các đường xu hướng vào các chuỗi biểu đồ, và làm việc với nhiều loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi đáp ngắn về các giá trị chiếu xu hướng “forward” và “backward” cũng như việc các đường xu hướng có được bảo tồn khi xuất sang PDF hoặc SVG và khi hiển thị biểu đồ dưới dạng hình ảnh.

## **Thêm Đường Xu Hướng**

Aspose.Slides for Python via Java cung cấp một API đơn giản để quản lý các đường xu hướng khác nhau của biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu đến slide dựa trên chỉ mục của nó.
3. Thêm một biểu đồ với dữ liệu mặc định và loại mong muốn (ví dụ này sử dụng [ChartType.ClusteredColumn](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Thêm một đường xu hướng hàm mũ vào chuỗi biểu đồ 1.
5. Thêm một đường xu hướng tuyến tính vào chuỗi biểu đồ 1.
6. Thêm một đường xu hướng logarit vào chuỗi biểu đồ 2.
7. Thêm một đường xu hướng trung bình động vào chuỗi biểu đồ 2.
8. Thêm một đường xu hướng đa thức vào chuỗi biểu đồ 3.
9. Thêm một đường xu hướng lũy thừa vào chuỗi biểu đồ 3.
10. Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

Mã sau tạo một biểu đồ có các đường xu hướng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    # Tạo một biểu đồ cột cụm.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Thêm một đường xu hướng hàm mũ vào chuỗi biểu đồ 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Thêm một đường xu hướng tuyến tính vào chuỗi biểu đồ 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Thêm một đường xu hướng logarit vào chuỗi biểu đồ 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Thêm một đường xu hướng trung bình động vào chuỗi biểu đồ 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Thêm một đường xu hướng đa thức vào chuỗi biểu đồ 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Thêm một đường xu hướng lũy thừa vào chuỗi biểu đồ 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Lưu bản trình bày.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Đường Tùy Chỉnh**

Aspose.Slides for Python via Java cung cấp một API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào biểu đồ trên một slide đã chọn, thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
- Lấy một tham chiếu đến slide dựa trên chỉ mục của nó.
- Tạo một biểu đồ mới bằng cách sử dụng phương thức [addChart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addChart) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/) .
- Thêm một hình dạng đường thẳng bằng phương thức [addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) với [ShapeType.Line](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Line) .
- Đặt màu cho đường của hình dạng.
- Ghi bản trình bày đã chỉnh sửa vào tệp PPTX.

Mã sau tạo một biểu đồ có đường tùy chỉnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**'forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu về phía trước hoặc phía sau: đối với biểu đồ scatter (XY), chúng được đo bằng đơn vị trục; đối với các biểu đồ không phải scatter, chúng được đo bằng số lượng danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được bảo tồn khi xuất bản trình bày sang PDF hoặc SVG, hoặc khi hiển thị slide dưới dạng hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình bày sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/) và hiển thị các biểu đồ dưới dạng hình ảnh; các đường xu hướng, như một phần của biểu đồ, được bảo tồn trong các thao tác này. Một phương thức cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/python-java/create-shape-thumbnails/) riêng.