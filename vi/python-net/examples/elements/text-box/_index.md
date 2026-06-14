---
title: Hộp Văn Bản
type: docs
weight: 40
url: /vi/python-net/examples/elements/text-box/
keywords:
- hộp văn bản
- thêm hộp văn bản
- truy cập hộp văn bản
- xóa hộp văn bản
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo và định dạng hộp văn bản trong Python với Aspose.Slides: thiết lập phông chữ, căn chỉnh, ngắt dòng, tự động điều chỉnh kích thước và liên kết để hoàn thiện các slide cho PowerPoint và OpenDocument."
---
Trong Aspose.Slides, một **hộp văn bản** được biểu diễn bằng một `AutoShape`. Hầu như bất kỳ hình dạng nào cũng có thể chứa văn bản, nhưng một hộp văn bản điển hình không có màu nền hoặc viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa các hộp văn bản một cách lập trình.

## **Thêm một Hộp Văn Bản**

Một hộp văn bản chỉ đơn giản là một `AutoShape` không có màu nền hoặc viền và chứa một số văn bản đã định dạng. Dưới đây là cách tạo một hộp văn bản:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tạo một hình chữ nhật (mặc định được tô đầy với viền và không có văn bản).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Xóa màu nền và viền để nó trông giống như một hộp văn bản điển hình.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Thiết lập định dạng văn bản.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Gán nội dung văn bản thực tế.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa một `TextFrame` không rỗng cũng có thể hoạt động như một hộp văn bản.

## **Truy cập Hộp Văn Bản theo Nội Dung**

Để tìm tất cả các hộp văn bản chứa một từ khóa cụ thể (ví dụ: "Slide"), lặp qua các hình dạng và kiểm tra văn bản của chúng:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Chỉ các AutoShape mới có thể chứa văn bản có thể chỉnh sửa.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Thực hiện một thao tác nào đó với hộp văn bản phù hợp.
                    pass
```

## **Xóa Hộp Văn Bản theo Nội Dung**

Ví dụ này tìm và xóa tất cả các hộp văn bản trên slide đầu tiên chứa một từ khóa cụ thể:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Tìm các hình dạng cần xóa là AutoShape chứa từ "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Xóa từng hình dạng phù hợp khỏi slide.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập hình dạng trước khi sửa đổi nó trong quá trình lặp để tránh lỗi sửa đổi bộ sưu tập.