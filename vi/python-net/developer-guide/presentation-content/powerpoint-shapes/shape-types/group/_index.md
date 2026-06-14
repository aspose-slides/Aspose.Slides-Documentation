---
title: Nhóm các hình trong bài thuyết trình với Python
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/python-net/group/
keywords:
- hình nhóm
- nhóm hình
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách nhóm và tách nhóm các hình trong PowerPoint và bộ tài liệu OpenDocument bằng Aspose.Slides cho Python—hướng dẫn nhanh, chi tiết từng bước kèm mã nguồn miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với hình nhóm trong Aspose.Slides. Nó chỉ ra cách thêm một hình nhóm vào slide, đặt các hình bên trong và lưu bản trình bày đã cập nhật. Ngoài ra còn trình bày cách truy cập các hình được lưu trong một nhóm và đọc giá trị `alternative_text` của chúng. Bài viết cũng đề cập ngắn gọn đến các khả năng liên quan đến hình nhóm như nhóm lồng nhau, thứ tự z và các tùy chọn khóa.

## **Thêm hình nhóm**

Aspose.Slides hỗ trợ làm việc với hình nhóm trên một slide. Tính năng này cho phép bạn tạo các bản trình bày phong phú hơn bằng cách xử lý nhiều hình như một đối tượng duy nhất. Bạn có thể thêm các hình nhóm mới, truy cập các hình nhóm hiện có, đưa các hình con vào chúng và đọc hoặc sửa đổi bất kỳ thuộc tính nào. Để thêm một hình nhóm vào slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục.
3. Thêm một [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/) vào slide.
4. Thêm các hình vào hình nhóm mới.
5. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Ví dụ dưới đây cho thấy cách thêm một hình nhóm vào slide.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một hình nhóm vào slide.
    group_shape = slide.shapes.add_group_shape()

    # Thêm các hình vào trong hình nhóm.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Ghi tệp PPTX ra đĩa.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập thuộc tính Alt Text**

Phần này giải thích cách đọc Alt Text của các hình nằm trong một hình nhóm trên slide bằng Aspose.Slides. Để truy cập Alt Text của các hình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để đại diện cho tệp PPTX.
2. Lấy tham chiếu tới slide theo chỉ mục của nó.
3. Truy cập bộ sưu tập các hình của slide.
4. Truy cập [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/) .
5. Đọc thuộc tính Alt Text.

Ví dụ dưới đây lấy Alt Text của các hình nằm trong các hình nhóm.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation để mở tệp PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Truy cập hình nhóm.
            for child_shape in shape.shapes:
                # Truy cập thuộc tính Alt Text.
                print(child_shape.alternative_text)
```

## **Câu hỏi thường gặp**

**Có hỗ trợ nhóm lồng nhau (một nhóm bên trong một nhóm) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/) có thuộc tính [parent_group](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/parent_group/) cho thấy hỗ trợ phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm sao tôi kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng thuộc tính [z_order_position](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/z_order_position/) của [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Có thể ngăn việc di chuyển/chỉnh sửa/ungroup không?**

Có. Phần khóa của nhóm được mở ra qua [group_shape_lock](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/group_shape_lock/), cho phép bạn hạn chế các thao tác trên đối tượng.