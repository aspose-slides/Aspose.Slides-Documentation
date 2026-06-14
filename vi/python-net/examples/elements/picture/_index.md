---
title: Hình ảnh
type: docs
weight: 50
url: /vi/python-net/examples/elements/picture/
keywords:
- hình ảnh
- khung hình
- thêm hình ảnh
- truy cập hình ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Làm việc với hình ảnh trong Python bằng Aspose.Slides: chèn, thay thế, cắt, nén, điều chỉnh độ trong suốt và hiệu ứng, tô màu cho các hình dạng, và xuất ra các định dạng PPT, PPTX và ODP."
---
Hiển thị cách chèn và truy cập hình ảnh từ các ảnh trong bộ nhớ sử dụng **Aspose.Slides for Python via .NET**. Các ví dụ dưới đây tạo một ảnh trong bộ nhớ, đặt nó lên một slide, và sau đó truy xuất nó.

## **Thêm hình ảnh**

Đoạn mã này tải một ảnh từ tệp và chèn nó dưới dạng khung ảnh trên slide đầu tiên.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tải một hình ảnh từ tệp.
        with open("image.png", "rb") as image_stream:
            # Thêm hình ảnh vào tài nguyên của bản trình bày.
            image = presentation.images.add_image(image_stream)

        # Chèn khung ảnh hiển thị hình ảnh trên slide đầu tiên.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập hình ảnh**

Ví dụ này đảm bảo một slide chứa khung ảnh và sau đó truy cập vào khung đầu tiên được tìm thấy.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập khung ảnh đầu tiên trên slide.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```