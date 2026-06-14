---
title: Quản lý các Dấu Dữ liệu Biểu đồ trong Bản trình bày với Python
linktitle: Dấu dữ liệu
type: docs
url: /vi/python-net/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- các tùy chọn dấu
- kích thước dấu
- loại tô
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh các dấu dữ liệu biểu đồ trong Aspose.Slides, nâng cao hiệu quả bản trình bày trên các định dạng PPT, PPTX và ODP với các ví dụ mã rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một series và các điểm dữ liệu của nó, áp dụng fill ảnh cho các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình bày đã cập nhật. Nó cũng lưu ý rằng các hình dạng dấu tiêu chuẩn có sẵn thông qua enumeration `MarkerStyleType` và rằng giao diện dấu được giữ nguyên khi xuất biểu đồ sang định dạng raster hoặc SVG.

## **Đặt tùy chọn dấu biểu đồ**
Các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong một series cụ thể. Để đặt tùy chọn dấu biểu đồ, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
- Tạo biểu đồ mặc định.
- Đặt ảnh.
- Lấy series biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Tạo biểu đồ mặc định
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
    defaultWorksheetIndex = 0

    # Lấy worksheet dữ liệu biểu đồ
    fact = chart.chart_data.chart_data_workbook

    # Xóa series demo
    chart.chart_data.series.clear()

    # Thêm series mới
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Đặt hình ảnh
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Đặt hình ảnh
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Lấy series biểu đồ đầu tiên
    series = chart.chart_data.series[0]

    # Thêm điểm mới (1:3) ở đó.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Thay đổi dấu series biểu đồ
    series.marker.size = 15

    # Ghi bản trình bày ra đĩa
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Những hình dạng dấu nào có sẵn ngay từ đầu?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được định nghĩa bởi enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng dấu với fill ảnh để mô phỏng các hình ảnh tùy chỉnh.

**Các dấu có được giữ lại khi xuất biểu đồ sang hình ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/python-net/convert-powerpoint-to-png/) hoặc lưu [các hình dạng dưới dạng SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/), các dấu giữ nguyên giao diện và cài đặt của chúng, bao gồm kích thước, fill và outline.