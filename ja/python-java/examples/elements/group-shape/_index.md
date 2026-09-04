---
title: グループ シェイプ
type: docs
weight: 170
url: /ja/python-java/examples/elements/group-shape/
keywords:
- コード例
- グループ シェイプ
- グループ シェイプの追加
- グループ シェイプへのアクセス
- グループ シェイプの削除
- グループ化解除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してプレゼンテーションのグループ シェイプを管理します。PowerPoint と OpenDocument ファイルでシェイプの追加、アクセス、削除、グループ化解除が可能です。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して、シェイプのグループを作成し、アクセスし、削除し、コンテンツのグループ化を解除する方法を示します。

パッケージは[Installation](/slides/ja/python-java/installation/)に記載された手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **Add a Group Shape**

2つの基本シェイプを含むグループを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Access a Group Shape**

スライドから最初のグループシェイプを取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Remove a Group Shape**

スライドからグループシェイプを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Ungroup Shapes**

シェイプをグループコンテナから外へ移動します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # シェイプをグループから外へ移動します。
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```