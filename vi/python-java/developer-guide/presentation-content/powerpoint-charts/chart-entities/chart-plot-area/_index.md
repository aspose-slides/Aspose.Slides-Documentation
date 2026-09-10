---
title: Tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu bằng Python
linktitle: Vùng vẽ
type: docs
url: /vi/python-java/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- độ rộng vùng vẽ
- độ cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ của biểu đồ trong bản trình chiếu PowerPoint với Aspose.Slides cho Python qua Java. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với vùng vẽ của biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác nhận bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao.

Nó cũng minh họa cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được thiết lập thủ công, sử dụng [LayoutTargetType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layouttargettype/) để xác định vùng vẽ được tính bằng khu vực bên trong hay khu vực bên ngoài cùng với các trục và nhãn trục.

## **Lấy chiều rộng và chiều cao của vùng vẽ biểu đồ**

Aspose.Slides for Python via Java cung cấp API đơn giản để đọc vị trí và kích thước thực tế của vùng vẽ biểu đồ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Truy cập slide đầu tiên.
1. Thêm một biểu đồ với dữ liệu mặc định.
1. Gọi phương thức [Chart.validateChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/#validateChartLayout) trước khi lấy các giá trị thực tế.
1. Lấy vị trí X thực tế (trái) của phần tử biểu đồ so với góc trên‑trái của biểu đồ.
1. Lấy vị trí Y thực tế (trên) của phần tử biểu đồ so với góc trên‑trái của biểu đồ.
1. Lấy chiều rộng thực tế của phần tử biểu đồ.
1. Lấy chiều cao thực tế của phần tử biểu đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Đặt chế độ bố cục của vùng vẽ biểu đồ**

Aspose.Slides for Python via Java cung cấp API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Các phương thức [setLayoutTargetType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) và [getLayoutTargetType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) có sẵn trong lớp [ChartPlotArea](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartplotarea/). Nếu bố cục của vùng vẽ được xác định thủ công, cài đặt này chỉ định việc bố trí vùng vẽ theo bên trong (không bao gồm trục và nhãn trục) hoặc bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị khả dụng được định nghĩa trong kiểu liệt kê [LayoutTargetType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layouttargettype/#Inner) chỉ ra rằng kích thước vùng vẽ không bao gồm các dấu tick và nhãn trục.
- [Outer](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layouttargettype/#Outer) chỉ ra rằng kích thước vùng vẽ bao gồm các dấu tick và nhãn trục.

Mã mẫu được đưa ra bên dưới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Tạo một thể hiện của lớp Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các giá trị X thực tế, Y thực tế, chiều rộng thực tế và chiều cao thực tế được trả về bằng đơn vị nào?**

Bằng điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng vẽ (Plot Area) khác gì so với vùng biểu đồ (Chart Area) về nội dung?**

Vùng vẽ là khu vực vẽ dữ liệu (dòng dữ liệu, lưới, đường xu hướng, v.v.); vùng biểu đồ bao gồm các yếu tố xung quanh (tiêu đề, chú giải, v.v.). Trong biểu đồ 3D, vùng vẽ còn bao gồm các mặt tường/sàn và các trục.

**Khi bố cục được đặt thủ công, các giá trị X, Y, chiều rộng và chiều cao của vùng vẽ được hiểu như thế nào?**

Chúng là các tỷ lệ (0–1) của tổng kích thước biểu đồ; trong chế độ này, việc tự động định vị bị tắt và các tỷ lệ bạn thiết lập sẽ được sử dụng.

**Tại sao vị trí của vùng vẽ thay đổi sau khi thêm hoặc di chuyển chú giải?**

Chú giải nằm trong vùng biểu đồ bên ngoài vùng vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, vì vậy vùng vẽ có thể dịch chuyển khi tính năng tự động định vị đang hoạt động. (Đây là hành vi tiêu chuẩn của biểu đồ PowerPoint.)