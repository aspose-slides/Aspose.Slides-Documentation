---
title: コネクタ
type: docs
weight: 190
url: /ja/python-net/examples/elements/connector/
keywords:
- コネクタ
- コネクタを追加
- コネクタにアクセス
- コネクタを削除
- 図形を再接続
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python でコネクタを描画および制御します。コネクタの追加、ルーティング、再ルーティング、接続ポイント、矢印、スタイルの設定により、PPT、PPTX、ODP の図形をリンクします。"
---
**Aspose.Slides for Python via .NET** を使用して、コネクタで図形を接続し、ターゲットを変更する方法を示します。

## **コネクタを追加**

スライド上の2点間にコネクタ形状を挿入します。

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # ベンドコネクタ形状を追加します。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタにアクセス**

スライドに追加された最初のコネクタ形状を取得します。

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初のコネクタにアクセスします。
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **コネクタを削除**

スライドからコネクタを削除します。

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがコネクタであると仮定します。
        connector = slide.shapes[0]

        # コネクタを削除します。
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **図形を再接続**

開始ターゲットと終了ターゲットを割り当てて、コネクタを2つの図形に接続します。

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初の長方形シェイプを追加します。
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # 2番目の長方形シェイプを追加します。
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # ベンドコネクタ形状を追加します。
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # コネクタの開始点を最初のシェイプに接続します。
        connector.start_shape_connected_to = shape1
        # コネクタの終了点を2番目のシェイプに接続します。
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```