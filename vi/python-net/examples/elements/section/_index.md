---
title: Phần
type: docs
weight: 90
url: /vi/python-net/examples/elements/section/
keywords:
- phần
- phần slide
- thêm phần
- truy cập phần
- xóa phần
- đổi tên phần
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các phần slide trong Python với Aspose.Slides: tạo, đổi tên, sắp xếp lại dễ dàng, di chuyển slide giữa các phần, và kiểm soát khả năng hiển thị cho PPT, PPTX và ODP."
---
Các ví dụ về việc quản lý các phần của bản trình chiếu—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for Python via .NET**.

## **Thêm một phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một phần mới và chỉ định slide đánh dấu đầu phần.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập một phần**

Lấy một phần từ bản trình chiếu.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Truy cập một phần theo chỉ mục.
        section = presentation.sections[0]
```

## **Xóa một phần**

Xóa một phần đã được thêm trước đó.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Xóa phần.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Đổi tên phần**

Thay đổi tên của một phần hiện có.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Đổi tên phần.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```