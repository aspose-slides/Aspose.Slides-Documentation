---
title: Nhóm Hình dạng Bài thuyết trình trong Python qua Java
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/python-java/group/
keywords:
- hình nhóm
- nhóm hình
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách nhóm và tách nhóm các hình dạng trong bản PowerPoint bằng Aspose.Slides cho Python qua Java — hướng dẫn từng bước kèm mã Python miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các group shape trong Aspose.Slides. Nó cho thấy cách thêm một group shape vào slide, đặt các shape bên trong và lưu bản trình bày đã cập nhật. Nó cũng minh họa cách truy cập các shape được lưu trong một group và đọc alternative text của chúng bằng [getAlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText). Ngoài ra, bài viết còn đề cập ngắn gọn tới các khả năng liên quan đến group‑shape như nhóm lồng nhau, z‑order và các tùy chọn khóa.

## **Thêm một Group Shape**

Aspose.Slides hỗ trợ làm việc với group shape trên các slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides for Python via Java hỗ trợ việc thêm và truy cập group shape. Bạn có thể điền một group shape bằng các shape hoặc truy cập các thuộc tính của nó. Để thêm một group shape vào slide bằng Aspose.Slides for Python via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một group shape vào slide.
1. Thêm các shape vào group shape.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một group shape vào slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Khởi tạo lớp Presentation.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Truy cập bộ sưu tập shape của slide.
    slide_shapes = slide.getShapes()

    # Thêm một group shape vào slide.
    group_shape = slide_shapes.addGroupShape()

    # Thêm các shape bên trong group shape.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Đặt frame cho group shape.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Ghi tệp PPTX ra đĩa.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập Alternative Text**

Phần này cho thấy cách truy cập alternative text của các shape bên trong một group trên slide. Để truy cập văn bản này bằng Aspose.Slides for Python via Java:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) đại diện cho tệp PPTX.
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Truy cập bộ sưu tập shape của slide.
1. Truy cập group shape.
1. Đọc alternative text của các shape bên trong bằng [getAlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText).

Ví dụ dưới đây truy cập alternative text của các shape bên trong một group:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Truy cập một shape trong bộ sưu tập shape của slide.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Truy cập các shape bên trong group.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Đọc văn bản thay thế.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Có hỗ trợ nhóm lồng nhau (một group bên trong một group) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/) có phương thức [getParentGroup](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getParentGroup), cho thấy hỗ trợ phân cấp: một group có thể là con của một group khác.

**Làm sao điều chỉnh z‑order của group so với các đối tượng khác trên slide?**

Sử dụng phương thức [getZOrderPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getZOrderPosition) của đối tượng [GroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Có thể ngăn việc di chuyển, chỉnh sửa hoặc tách nhóm không?**

Có. Các khóa của group được cung cấp qua [getGroupShapeLock](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/#getGroupShapeLock), cho phép bạn hạn chế các thao tác trên đối tượng.