---
title: Lấy giới hạn đoạn văn từ bản trình bày trong Python
linktitle: Giới hạn đoạn văn
type: docs
weight: 43
url: /vi/python-net/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách truy xuất giới hạn đoạn văn trong Aspose.Slides cho Python thông qua .NET để tối ưu hóa vị trí văn bản trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của một đoạn văn từ một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) bằng cách sử dụng [Paragraph.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/get_rect/), cách lấy tọa độ đoạn văn trong khung văn bản ô bảng, và nhấn mạnh các chi tiết quan trọng như đơn vị đo lường, ảnh hưởng của việc ngắt ký tự khi xuống dòng tới giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “effective”.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [Paragraph.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/get_rect/) để lấy hình chữ nhật bao quanh một đoạn văn.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Lấy kích thước của một đoạn văn trong TextFrame ô bảng**

Để lấy kích thước và tọa độ của một [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) trong khung văn bản ô bảng, hãy sử dụng [Paragraph.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/get_rect/). Hình chữ nhật trả về là tương đối với khung văn bản ô bảng, vì vậy cần cộng vị trí bảng và độ dịch ô khi bạn cần tọa độ ở mức slide.

Ví dụ sau lấy giới hạn của đoạn văn trong ô bảng và vẽ các hình chữ nhật trên slide để hiển thị các giới hạn đó:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Các tọa độ đoạn văn được đo bằng đơn vị nào?**

Chúng được đo bằng điểm (point), trong đó 1 inch bằng 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/wrap_text/) được bật cho [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), văn bản sẽ tự động ngắt để vừa với chiều rộng khu vực, làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh đã xuất không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = point × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm sao để lấy các tham số định dạng đoạn văn “effective”, có tính đến kế thừa kiểu dáng?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/python-net/shape-effective-properties/); nó trả về các giá trị cuối cùng đã hợp nhất cho thụt lề, khoảng cách, ngắt dòng, RTL và các thuộc tính khác.