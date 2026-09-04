---
title: Văn Bản Toán Học
type: docs
weight: 160
url: /vi/python-java/examples/elements/math-text/
keywords:
- ví dụ mã
- văn bản toán học
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Khám phá các ví dụ văn bản toán học của Aspose.Slides for Python via Java: tạo và định dạng phương trình, phân số, ma trận và ký hiệu trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với các hình dạng văn bản toán học và định dạng các phương trình bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như đã mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm Văn Bản Toán Học**

Tạo một hình dạng toán học chứa một phân số và công thức Pythagore.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

        # Thêm một hình dạng toán học vào slide.
        math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

        # Truy cập đoạn văn toán học.
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # Thêm một phân số đơn giản: x / y.
        fraction = MathematicalText("x").divide("y")
        math_paragraph.add(MathBlock(fraction))

        # Thêm phương trình: c² = a² + b².
        math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
        math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **Truy Cập Văn Bản Toán Học**

Xác định một hình dạng chứa đoạn văn toán học trên slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình dạng toán học có thể được tìm thấy bên dưới.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # Tìm hình dạng đầu tiên chứa đoạn văn toán học.
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # Ví dụ: tạo một phân số (không được thêm ở đây).
        fraction = MathematicalText("x").divide("y")

        # Sử dụng math_paragraph hoặc fraction khi cần.
finally:
    presentation.dispose()
```

## **Xóa Văn Bản Toán Học**

Xóa một hình dạng toán học khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Xóa hình dạng toán học.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **Định Dạng Văn Bản Toán Học**

Thiết lập các thuộc tính phông chữ cho một phần toán học.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```