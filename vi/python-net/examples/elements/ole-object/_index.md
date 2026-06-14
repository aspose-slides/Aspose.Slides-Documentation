---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/python-net/examples/elements/ole-object/
keywords:
- Đối tượng OLE
- Thêm đối tượng OLE
- Truy cập đối tượng OLE
- Xóa đối tượng OLE
- Cập nhật đối tượng OLE
- Ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Làm việc với các đối tượng OLE trong Python bằng Aspose.Slides: chèn hoặc cập nhật tệp nhúng, đặt biểu tượng hoặc liên kết, trích xuất nội dung, kiểm soát hành vi cho PPT, PPTX và ODP."
---
Minh họa việc nhúng một tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng cách sử dụng **Aspose.Slides for Python via .NET**.

## **Thêm Đối Tượng OLE**

Nhúng tệp PDF vào bản trình chiếu.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tải dữ liệu PDF để nhúng.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Thêm khung đối tượng OLE vào slide.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Đối Tượng OLE**

Lấy khung đối tượng OLE đầu tiên trên một slide.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Lấy khung đối tượng OLE đầu tiên trên slide.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Xóa Đối Tượng OLE**

Xóa một đối tượng OLE đã nhúng khỏi slide.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả định hình đầu tiên là một đối tượng OleObjectFrame object.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập Nhật Dữ Liệu Đối Tượng OLE**

Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả định hình đầu tiên là một đối tượng OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Cập nhật đối tượng OLE bằng dữ liệu nhúng mới.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```