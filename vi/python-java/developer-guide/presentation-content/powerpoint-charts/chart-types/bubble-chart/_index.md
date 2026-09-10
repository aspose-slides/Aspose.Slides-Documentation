---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình bằng Python
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/python-java/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- tỉ lệ kích thước
- cách biểu diễn kích thước
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides for Python via Java để nâng cao khả năng hiển thị dữ liệu của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chỉnh cụ thể: điều chỉnh kích thước bong bóng thông qua phương thức [setBubbleSizeScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn thông qua phương thức [setBubbleSizeRepresentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỉ lệ kích thước và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần Câu hỏi thường gặp ngắn gọn, giải thích việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và mô tả cách xuất giữ nguyên giao diện của biểu đồ thông qua động cơ render của Aspose.Slides.

## **Điều chỉnh kích thước biểu đồ bong bóng**

Aspose.Slides for Python via Java hỗ trợ điều chỉnh kích thước biểu đồ bong bóng thông qua các phương thức [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) và [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Ví dụ sau cho thấy cách thay đổi tỉ lệ kích thước bong bóng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng**

Các phương thức [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) và [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) có sẵn trong lớp [ChartSeriesGroup](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartseriesgroup/). Thuộc tính biểu diễn kích thước bong bóng xác định cách các giá trị kích thước được hiển thị trong biểu đồ bong bóng. Các giá trị có thể là [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bubblesizerepresentationtype/#Area) và [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Kiểu liệt kê [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bubblesizerepresentationtype/) chỉ ra các cách có thể để biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Ví dụ dưới đây cho thấy cách biểu diễn kích thước bong bóng bằng chiều rộng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Biểu đồ bong bóng có hiệu ứng 3D có được hỗ trợ không, và nó khác gì so với biểu đồ thường?**

Có. Có một loại biểu đồ riêng, “Bubble with 3-D”. Loại này áp dụng kiểu dáng 3‑D cho các bong bóng nhưng không thêm trục phụ; dữ liệu vẫn là X‑Y‑S (kích thước). Loại này có sẵn trong lớp [loại biểu đồ](https://reference.aspose.com/slides/vi/python-java/aspose.slides/charttype/).

**Có giới hạn số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu. Đề xuất giữ số điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Quá trình xuất sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất sang các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi động cơ Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ (độ phân giải, khử răng cưa) vẫn áp dụng, vì vậy nên chọn DPI đủ lớn cho việc in.