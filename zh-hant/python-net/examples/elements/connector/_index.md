---
title: 連接線
type: docs
weight: 190
url: /zh-hant/python-net/examples/elements/connector/
keywords:
- 連接線
- 新增連接線
- 存取連接線
- 移除連接線
- 重新連接圖形
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中繪製與控制連接線：新增、路由、重新路由、設定連接點、箭頭與樣式，以在 PPT、PPTX 和 ODP 中連結圖形。"
---
示範如何使用 **Aspose.Slides for Python via .NET** 連接圖形與連接線並變更其目標。

## **新增連接線**

在投影片上的兩個點之間插入一個連接線形狀。

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增彎曲連接線形狀。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **存取連接線**

取得已新增至投影片的第一個連接線形狀。

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取投影片上的第一個連接線。
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **移除連接線**

從投影片中刪除連接線。

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是連接線。
        connector = slide.shapes[0]

        # 移除連接線。
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **重新連接圖形**

透過指定起始與結束目標，將連接線附加至兩個圖形。

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 新增第一個矩形形狀。
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # 新增第二個矩形形狀。
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # 新增彎曲連接線形狀。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # 將連接線的起點連接至第一個形狀。
        connector.start_shape_connected_to = shape1
        # 將連接線的終點連接至第二個形狀。
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```