---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong Python
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
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho Python qua Java — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó trình bày cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ, và làm việc với nhiều loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Câu hỏi thường gặp ngắn về các giá trị chiếu xu hướng “tiến” và “lùi”, cũng như việc các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ thành hình ảnh hay không.

## **Thêm Đường Xu Hướng**

Sử dụng [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) để thêm một đường xu hướng vào một chuỗi biểu đồ, chọn loại bằng [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Ví dụ tạo một biểu đồ cột cụm với dữ liệu mặc định và thêm hai đường xu hướng cho mỗi trong ba chuỗi của nó.

Đường xu hướng hàm mũ ẩn phương trình và giá trị R‑squared bằng cách sử dụng [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) và [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) để đặt nhãn tùy chỉnh. Đường trung bình động sử dụng [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) với ba điểm dữ liệu và một [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) tùy chỉnh.

Đường xu hướng đa thức có bậc ba, được đặt qua [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) và mở rộng một danh mục về phía trước qua [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Đường xu hướng lũy thừa mở rộng một danh mục về phía sau qua [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Điểm Giao Cắt Đường Xu Hướng**

Sử dụng [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này được hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, mô hình chi phí sản xuất có thể cần bắt đầu từ chi phí cố định đã biết là 100, ngay cả khi các đo lường ở khối lượng sản xuất không bằng không gợi ý một nền tảng khác. Đối với đường xu hướng tuyến tính, việc cố định điểm giao cắt ràng buộc phương trình `y = ax + b` thành `b = 100`; độ dốc được điều chỉnh phù hợp với dữ liệu dưới ràng buộc này. Nó không chỉ di chuyển một đường đã được điều chỉnh sẵn. Cài đặt giao điểm trục kiểm soát vị trí các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã được điều chỉnh.

Ví dụ dưới đây tạo một biểu đồ phân tán (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí 170, 200, 230 và 260. Nó lưu biểu đồ với điểm giao cắt tự động mặc định, đặt điểm giao cắt thành 100 và lưu một tệp PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt điểm giao cắt. Đường xu hướng hiển thị phương trình và mở rộng trở lại X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Với tính toán tự động, các dữ liệu này cho ra `y = 30x + 140`. Đặt điểm giao cắt thành 100 thay thế cho ra xấp xỉ `y = 43.33x + 100`: giá trị điều chỉnh tại mức zero khớp với nền tảng đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu.

| Điểm giao cắt tự động | Điểm giao cắt cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với điểm giao cắt được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với điểm giao cắt cố định là 100](intercept-fixed.png) |

Cả hai hình đều sử dụng cùng một dữ liệu và tỉ lệ trục. Các đường xu hướng được mở rộng trở lại X = 0 để hiển thị điểm giao cắt của chúng.

Mặc định, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) trả về `NaN`, đại diện cho một điểm giao cắt chưa được chỉ định thay vì zero. Khi đó, điểm giao cắt được tính tự động từ dữ liệu.

## **Thêm Đường Tùy Chỉnh**

Một đường tùy chỉnh là một hình dạng được vẽ lên trên biểu đồ thay vì một đường xu hướng được tính toán từ dữ liệu chuỗi. Ví dụ này sử dụng [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) để thêm một đường ngang vào slide trên biểu đồ. Vị trí của đường được chỉ định bằng tọa độ slide, đo bằng điểm, vì vậy nó bắt đầu từ cạnh trái của biểu đồ và nằm ở giữa chiều cao của biểu đồ. Chiều rộng của nó bằng với chiều rộng của biểu đồ. Phương thức [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) cung cấp quyền truy cập vào định dạng đường được dùng để áp dụng màu đỏ đặc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**'Tiến' và 'Lùi' có nghĩa gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu ra phía tiến hoặc lùi: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi các bản trình chiếu sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/) hoặc [SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/python-java/create-shape-thumbnails/).