---
title: SmartArt
type: docs
weight: 140
url: /ja/python-java/examples/elements/smart-art/
keywords:
- コード例
- SmartArt
- SmartArt を追加
- SmartArt にアクセス
- SmartArt を削除
- SmartArt レイアウト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で SmartArt を操作します：PowerPoint および OpenDocument プレゼンテーションで SmartArt を追加、アクセス、削除、レイアウトを変更できます。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して、SmartArt グラフィックの追加、アクセス、削除、レイアウトの変更方法を示します。

パッケージは、[Installation](/slides/ja/python-java/installation/) に記載されている手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **SmartArt の追加**

組み込みレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **SmartArt にアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **SmartArt の削除**

スライドから SmartArt のシェイプを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **SmartArt のレイアウトを変更**

既存の SmartArt グラフィックのレイアウトタイプを更新します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```