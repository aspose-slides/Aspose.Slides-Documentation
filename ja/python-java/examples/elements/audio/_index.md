---
title: オーディオ
type: docs
weight: 70
url: /ja/python-java/examples/elements/audio/
keywords:
- コード例
- オーディオ
- オーディオ フレーム
- オーディオを追加
- オーディオにアクセス
- オーディオを削除
- オーディオの再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションにオーディオ フレームを追加、アクセス、削除、設定します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用してオーディオ フレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的なオーディオ操作を紹介します。

パッケージは、[Installation](/slides/ja/python-java/installation/) に記載された手順でインストールします。各例では、JVM を起動する前に `asposeslides` をインポートし、JVM が起動した後に API をインポートします。

## **Add an Audio Frame**
後で埋め込み音声データを保持できる空のオーディオ フレームを挿入します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # 空のオーディオ フレームを作成します（オーディオは後で埋め込まれます）。
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **Access an Audio Frame**
このコードは、スライド上の最初のオーディオ フレームを取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # スライド上の最初のオーディオ フレームにアクセスします。
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **Remove an Audio Frame**
以前に追加されたオーディオ フレームを削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # オーディオ フレームを削除します。
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **Set Audio Playback**
スライドが表示されたときに自動的に再生されるようにオーディオ フレームを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # スライドが表示されたときに自動的に再生します。
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```