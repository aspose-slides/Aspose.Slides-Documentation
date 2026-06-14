---
title: Kết nối
type: docs
weight: 190
url: /vi/python-net/examples/elements/connector/
keywords:
- kết nối
- thêm kết nối
- truy cập kết nối
- xóa kết nối
- kết nối lại các hình
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Vẽ và điều khiển các connector trong Python với Aspose.Slides: thêm, định tuyến, định tuyến lại, thiết lập các điểm kết nối, mũi tên và kiểu dáng để liên kết các hình trong PPT, PPTX và ODP."
---
Hiển thị cách kết nối các hình dạng với connector và thay đổi mục tiêu của chúng bằng **Aspose.Slides for Python via .NET**.

## **Thêm Connector**

Chèn một shape connector giữa hai điểm trên slide.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một shape connector gập.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Connector**

Lấy shape connector đầu tiên được thêm vào slide.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập connector đầu tiên trên slide.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Xóa Connector**

Xóa một connector khỏi slide.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử shape đầu tiên là một connector.
        connector = slide.shapes[0]

        # Xóa connector.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kết nối lại Shapes**

Gắn một connector vào hai shape bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Thêm hình chữ nhật đầu tiên.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Thêm hình chữ nhật thứ hai.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Thêm một connector gập.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Kết nối đầu của connector với hình đầu tiên.
        connector.start_shape_connected_to = shape1
        # Kết nối cuối của connector với hình thứ hai.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```