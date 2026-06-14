---
title: Biểu đồ
type: docs
weight: 60
url: /vi/python-net/examples/elements/chart/
keywords:
- biểu đồ
- thêm biểu đồ
- truy cập biểu đồ
- xóa biểu đồ
- cập nhật biểu đồ
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo và tùy chỉnh biểu đồ trong Python với Aspose.Slides: thêm dữ liệu, định dạng chuỗi, trục và nhãn, thay đổi loại biểu đồ và xuất ra - hoạt động với PPT, PPTX và ODP."
---
Các ví dụ về việc thêm, truy cập, xóa và cập nhật các loại biểu đồ khác nhau với **Aspose.Slides for Python via .NET**. Các đoạn mã dưới đây minh họa các thao tác cơ bản trên biểu đồ.

## **Thêm biểu đồ**

Phương pháp này thêm một biểu đồ khu vực đơn giản vào slide đầu tiên.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một biểu đồ cột đơn giản vào slide đầu tiên.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập biểu đồ**

Mã sau đây lấy một biểu đồ từ bộ sưu tập shape.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập biểu đồ đầu tiên trên slide.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Xóa biểu đồ**

Mã sau đây xóa một biểu đồ khỏi slide.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là biểu đồ.
        chart = slide.shapes[0]

        # Xóa biểu đồ.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập nhật dữ liệu biểu đồ**

Bạn có thể thay đổi các thuộc tính của biểu đồ như tiêu đề.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là biểu đồ.
        chart = slide.shapes[0]

        # Thay đổi tiêu đề biểu đồ.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```