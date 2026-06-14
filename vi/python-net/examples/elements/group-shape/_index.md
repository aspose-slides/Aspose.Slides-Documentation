---
title: Nhóm Hình
type: docs
weight: 170
url: /vi/python-net/examples/elements/group-shape/
keywords:
- nhóm
- thêm nhóm hình
- truy cập nhóm hình
- xóa nhóm hình
- tách nhóm các hình
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Làm việc với các nhóm hình trong Python bằng Aspose.Slides: tạo và tách nhóm, sắp xếp lại các hình con, thiết lập biến đổi và giới hạn cho PowerPoint và OpenDocument."
---
Ví dụ về cách tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bỏ bằng **Aspose.Slides for Python via .NET**.

## **Thêm một Nhóm Hình**

Tạo một nhóm chứa hai hình cơ bản.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một nhóm hình.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập một Nhóm Hình**

Lấy hình nhóm đầu tiên từ một slide.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập nhóm hình đầu tiên trên slide.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Xóa một Nhóm Hình**

Xóa một hình nhóm khỏi slide.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình đầu tiên là một nhóm hình.
        group = slide.shapes[0]

        # Xóa nhóm hình.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Tách Nhóm Các Hình**

Di chuyển các hình ra khỏi container nhóm.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình đầu tiên là một nhóm hình.
        group = slide.shapes[0]

        # Di chuyển các hình ra khỏi nhóm.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```