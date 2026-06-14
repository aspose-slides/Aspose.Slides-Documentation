---
title: Lấy giới hạn đoạn văn từ bản trình bày trong Python
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/python-net/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần văn bản
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn và phần văn bản trong Aspose.Slides cho Python qua .NET để tối ưu vị trí văn bản trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của đoạn văn và các phần văn bản trong Aspose.Slides. Nó chỉ ra cách lấy hình chữ nhật của đoạn văn trong một `TextFrame` bằng cách sử dụng `get_rect()`, cách lấy tọa độ của đoạn và phần bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc gói văn bản lên giới hạn, chuyển đổi sang pixel và các giá trị định dạng đoạn văn “hiệu quả”.

## **Lấy tọa độ đoạn và phần trong TextFrame**
Sử dụng Aspose.Slides for Python qua .NET, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong bộ sưu tập paragraphs của TextFrame. Nó cũng cho phép bạn lấy tọa độ của portion trong bộ sưu tập portion của một đoạn văn. Trong chủ đề này, chúng tôi sẽ trình bày với một ví dụ về cách lấy tọa độ hình chữ nhật cho đoạn cùng với vị trí của phần bên trong đoạn.

## **Lấy tọa độ hình chữ nhật của Paragraph**
Phương thức mới **GetRect()** đã được thêm vào. Nó cho phép lấy hình chữ nhật giới hạn của đoạn văn.

```py
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Lấy kích thước của đoạn và phần bên trong khung văn bản ô bảng** ##

Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) hoặc [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) trong một khung văn bản ô bảng, bạn có thể sử dụng các phương pháp [IPortion.GetRect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportion/) và [IParagraph.GetRect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iparagraph/).

Đoạn mã mẫu dưới đây minh họa hoạt động đã mô tả:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **Câu hỏi thường gặp**

**Các tọa độ trả về cho đoạn và các phần văn bản được đo bằng đơn vị nào?**

Bằng điểm, trong đó 1 inch = 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc gói từ ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/wrap_text/) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), văn bản sẽ ngắt để phù hợp với chiều rộng vùng, làm thay đổi giới hạn thực tế của đoạn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh đã xuất không?**

Có. Chuyển đổi điểm sang pixel bằng: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render/ xuất.

**Làm thế nào để lấy các tham số định dạng đoạn “hiệu quả”, có tính đến kế thừa kiểu?**

Sử dụng [effective paragraph formatting data structure](/slides/vi/python-net/shape-effective-properties/); nó trả về các giá trị cuối cùng đã hợp nhất cho indent, spacing, wrapping, RTL và các thuộc tính khác.