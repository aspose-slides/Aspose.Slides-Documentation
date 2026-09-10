---
title: Quản lý các dấu dữ liệu biểu đồ trong bản trình bày bằng Python
linktitle: Dấu dữ liệu
type: docs
url: /vi/python-java/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- loại fill
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh các dấu dữ liệu biểu đồ trong Aspose.Slides cho Python thông qua Java, nâng cao tác động của bản trình bày trên các định dạng PPT và PPTX với các ví dụ mã Python rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó chỉ ra cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng fill hình ảnh cho các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình bày đã cập nhật. Nó cũng ghi chú rằng các hình dạng dấu chuẩn có sẵn thông qua enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markerstyletype/) và rằng diện mạo của dấu được giữ nguyên khi xuất biểu đồ sang định dạng raster hoặc SVG.

## **Đặt tùy chọn dấu biểu đồ**
Các dấu có thể được đặt trên các điểm dữ liệu biểu đồ trong một series cụ thể. Để đặt tùy chọn dấu biểu đồ, thực hiện các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Truy cập series biểu đồ đầu tiên.
- Thêm các điểm dữ liệu mới.
- Ghi bản trình bày ra đĩa.

Ví dụ sau đặt tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Tạo một bản trình bày trống.
try:
    # Truy cập slide đầu tiên
    slide = presentation.getSlides().get_Item(0)

    # Tạo biểu đồ mặc định
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định.
    default_worksheet_index = 0

    # Lấy workbook dữ liệu biểu đồ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Xóa series demo
    chart.getChartData().getSeries().clear()

    # Thêm series mới
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Tải hình ảnh đầu tiên.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Tải hình ảnh thứ hai.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Truy cập series biểu đồ đầu tiên.
    series = chart.getChartData().getSeries().get_Item(0)

    # Thêm các điểm dữ liệu.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Thay đổi kích thước dấu của series biểu đồ.
    series.getMarker().setSize(15)

    # Lưu bản trình bày với biểu đồ
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Các hình dạng dấu nào có sẵn mặc định?**

Các hình dạng chuẩn có sẵn (hình tròn, hình vuông, hình kim cương, hình tam giác, v.v.); danh sách được định nghĩa bởi lớp [MarkerStyleType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markerstyletype/). Nếu bạn cần một hình dạng không chuẩn, hãy sử dụng dấu với fill hình ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu có được giữ nguyên khi xuất biểu đồ sang hình ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/python-java/convert-powerpoint-to-png/) hoặc lưu [các hình dạng dưới dạng SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/), các dấu giữ nguyên diện mạo và cài đặt của chúng, bao gồm kích thước, fill và viền.