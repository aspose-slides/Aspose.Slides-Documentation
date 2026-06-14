---
title: Bảng
type: docs
weight: 120
url: /vi/python-net/examples/elements/table/
keywords:
- bảng
- thêm bảng
- truy cập bảng
- xóa bảng
- hợp nhất ô
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và định dạng bảng trong Python bằng Aspose.Slides: chèn dữ liệu, hợp nhất ô, tạo kiểu viền, căn chỉnh nội dung, và nhập/xuất cho PPT, PPTX và ODP."
---
Các ví dụ về việc thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô bằng cách sử dụng **Aspose.Slides for Python via .NET**.

## **Add a Table**
Tạo một bảng đơn giản với hai hàng và hai cột.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Định nghĩa độ rộng cột và độ cao hàng.
        widths = [80, 80]
        heights = [30, 30]

        # Thêm một hình bảng vào slide.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Table**
Lấy hình dạng bảng đầu tiên trên slide.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập bảng đầu tiên trên slide.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Remove a Table**
Xóa một bảng khỏi slide.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một bảng.
        table = slide.shapes[0]

        # Xóa bảng khỏi slide.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Merge Table Cells**
Hợp nhất các ô liền kề của bảng thành một ô duy nhất.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một bảng.
        table = slide.shapes[0]

        # Hợp nhất các ô.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```