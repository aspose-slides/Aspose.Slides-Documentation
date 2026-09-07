---
title: スライドトランジション
type: docs
weight: 110
url: /ja/python-java/examples/elements/slide-transition/
keywords:
- コード例
- スライドトランジション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java のコード例を使用して、スライドのトランジションを適用および削除し、PPT、PPTX、ODP プレゼンテーションの自動スライド進行タイミングを設定します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用したスライドのトランジション効果とタイミングの適用方法を示します。

[Installation](/slides/ja/python-java/installation/) に記載されている手順でパッケージをインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **Add a Slide Transition**

最初のスライドにフェードトランジション効果を適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # フェードトランジションを適用します。
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Access a Slide Transition**

スライドに現在割り当てられているトランジションタイプを取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # トランジションタイプにアクセスします。
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Remove a Slide Transition**

トランジション効果をすべてクリアします。JPype は Java の定数 `None` を Python の予約語である `None` と衝突しないように `None_` として公開します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # トランジション効果を削除します。
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Set Transition Duration**

スライドが自動的に次へ進むまでの表示時間を指定します。この例では 2 秒後に自動で進み、マウスクリックでも進められるようにしています。このタイミングはスライドの進行を制御するもので、トランジション効果の速度を制御するものではありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # ミリ秒単位です。
finally:
    presentation.dispose()
```