---
title: コネクタ
type: docs
weight: 190
url: /ja/python-java/examples/elements/connector/
keywords:
- コード例
- コネクタ
- コネクタの追加
- コネクタへのアクセス
- コネクタの削除
- シェイプの再接続
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PPT、PPTX、ODP プレゼンテーションでシェイプをコネクタで追加、アクセス、削除、再接続する方法を学びます。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して、シェイプをコネクタで接続し、ターゲットを変更する方法を示します。

パッケージは [Installation](/slides/ja/python-java/installation/) に記載されている手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **コネクタを追加**

スライド上の 2 つのポイント間にコネクタ シェイプを挿入します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **コネクタへアクセス**

スライドに追加された最初のコネクタ シェイプを取得します。

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # スライド上の最初のコネクタにアクセスします。
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **コネクタの削除**

スライドからコネクタを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **シェイプの再接続**

開始ターゲットと終了ターゲットを割り当てることで、コネクタを 2 つのシェイプに接続します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```