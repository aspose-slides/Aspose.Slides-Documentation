---
title: ビデオ
type: docs
weight: 80
url: /ja/python-java/examples/elements/video/
keywords:
- コード例
- ビデオ
- ビデオフレーム
- ビデオの追加
- ビデオへのアクセス
- ビデオの削除
- ビデオ再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションにビデオフレームを追加、アクセス、削除、構成します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してビデオフレームを追加し、再生オプションを設定する方法を示します。

パッケージは[Installation](/slides/ja/python-java/installation/)に記載された手順でインストールします。各サンプルは JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **ビデオフレームの追加**

外部ビデオファイルを参照するビデオフレームを挿入します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # ビデオファイルにリンクされたビデオフレームを追加します。
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **ビデオフレームへのアクセス**

スライドに追加された最初のビデオフレームを取得します。

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # スライド上の最初のビデオフレームにアクセスします。
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **ビデオフレームの削除**

スライドからビデオフレームを削除します。

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # ビデオフレームを削除します。
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **ビデオ再生の設定**

スライドが表示されたときにビデオが自動的に再生されるように設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # ビデオを自動再生するように設定します。
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```