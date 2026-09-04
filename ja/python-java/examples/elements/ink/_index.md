---
title: インク
type: docs
weight: 180
url: /ja/python-java/examples/elements/ink/
keywords:
- コード例
- インク
- インクのアクセス
- インクの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のプレゼンテーション（PPT、PPTX、ODP ファイルを含む）において、インク形状にアクセスし削除します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して既存のインク形状にアクセスし、削除する例を示します。

[Installation](/slides/ja/python-java/installation/) に記載されている手順でパッケージをインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

{{% alert color="info" title="Note" %}}
インク形状は、専用デバイスからのユーザー入力を表します。Aspose.Slides ではプログラムで新しいインクストロークを作成できませんが、既存のインクを読み取り、変更することは可能です。
{{% /alert %}}

## **インクへのアクセス**

スライド上の最初のインク形状からタグを読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # 必要に応じて tag_name を使用します。
finally:
    presentation.dispose()
```

## **インクの削除**

スライドにインク形状が存在する場合、それを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```