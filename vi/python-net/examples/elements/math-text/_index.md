---
title: Văn bản toán học
type: docs
weight: 160
url: /vi/python-net/examples/elements/math-text/
keywords:
- văn bản toán học
- thêm văn bản toán học
- truy cập văn bản toán học
- xóa văn bản toán học
- định dạng văn bản toán học
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Làm việc với văn bản toán học trong Python bằng Aspose.Slides: tạo và chỉnh sửa phương trình, phân số, căn bậc, chỉ số, định dạng và kết xuất kết quả cho PPT và PPTX."
---
Mô tả cách làm việc với các hình dạng văn bản toán học và định dạng phương trình bằng **Aspose.Slides for Python via .NET**.

## **Thêm Văn Bản Toán Học**

Tạo một hình dạng toán học chứa một phân số và công thức Pythagoras.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một hình dạng Toán học vào slide.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Truy cập đoạn văn Toán học.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Thêm một phân số đơn giản: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Thêm phương trình: c² = a² + b².
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy Cập Văn Bản Toán Học**

Xác định một hình dạng có chứa đoạn văn bản toán học trên slide.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Tìm hình dạng đầu tiên chứa đoạn văn Toán học.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **Xóa Văn Bản Toán Học**

Xóa một hình dạng toán học khỏi slide.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một hình dạng có văn bản toán học.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Định Dạng Văn Bản Toán Học**

Đặt thuộc tính font cho một phần toán học.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một hình dạng có văn bản toán học.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```