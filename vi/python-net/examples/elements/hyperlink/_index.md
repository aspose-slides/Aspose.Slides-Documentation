---
title: Siêu liên kết
type: docs
weight: 130
url: /vi/python-net/examples/elements/hyperlink/
keywords:
- siêu liên kết
- thêm siêu liên kết
- truy cập siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Thêm, chỉnh sửa và xóa siêu liên kết trong Python với Aspose.Slides: liên kết văn bản, hình dạng, slide, URL và email; đặt mục tiêu và hành động cho PPT, PPTX và ODP."
---
Minh họa cách thêm, truy cập, xóa và cập nhật siêu liên kết trên các hình dạng bằng **Aspose.Slides for Python via .NET**.

## **Thêm Siêu Liên Kết**

Tạo một hình chữ nhật có siêu liên kết trỏ đến một trang web bên ngoài.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy Cập Siêu Liên Kết**

Đọc thông tin siêu liên kết từ phần văn bản của một hình dạng.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Xóa Siêu Liên Kết**

Xóa siêu liên kết khỏi văn bản của hình dạng.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập Nhật Siêu Liên Kết**

Thay đổi đích của một siêu liên kết hiện có. Sử dụng `HyperlinkManager` để chỉnh sửa văn bản đã chứa siêu liên kết, mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Thay đổi siêu liên kết trong văn bản hiện có nên thực hiện qua
        # HyperlinkManager thay vì thiết lập thuộc tính trực tiếp.
        # Điều này mô phỏng cách PowerPoint cập nhật siêu liên kết một cách an toàn.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```