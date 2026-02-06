---
title: 连接器
type: docs
weight: 190
url: /zh/python-net/examples/elements/connector/
keywords:
- 连接器
- 添加连接器
- 访问连接器
- 删除连接器
- 重新连接形状
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 绘制和控制连接器：添加、路由、重新路由、设置连接点、箭头和样式，以在 PPT、PPTX 和 ODP 中链接形状。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 将形状连接起来并更改它们的目标。

## **添加连接线**

在幻灯片的两个点之间插入一个连接线形状。

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加弯曲连接器形状。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **访问连接线**

检索添加到幻灯片的第一个连接线形状。

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个连接器。
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **删除连接线**

从幻灯片中删除一个连接线。

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是连接器。
        connector = slide.shapes[0]

        # 删除连接器。
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **重新连接形状**

通过分配起始和结束目标，将连接线附加到两个形状。

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 添加第一个矩形形状。
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # 添加第二个矩形形状。
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # 添加弯曲连接器形状。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # 将连接器的起点连接到第一个形状。
        connector.start_shape_connected_to = shape1
        # 将连接器的终点连接到第二个形状。
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```