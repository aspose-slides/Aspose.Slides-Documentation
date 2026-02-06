---
title: オーディオ
type: docs
weight: 70
url: /ja/python-net/examples/elements/audio/
keywords:
- オーディオ
- オーディオ フレーム
- 音声の追加
- 音声へのアクセス
- 音声の削除
- 音声再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で音声を操作します：音声の追加、置換、抽出、トリミング、PowerPoint と OpenDocument のスライドやシェイプの音量と再生を設定します。"
---
**Aspose.Slides for Python via .NET** を使用して音声フレームを埋め込み、再生を制御する方法を示します。以下の例では基本的な音声操作を紹介します。

## **音声フレームの追加**

以下のコード例は、プレゼンテーション スライドに音声フレームを追加します。

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **音声フレームへのアクセス**

このコードは、スライドから最初の音声フレームを取得します。

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **音声フレームの削除**

以前に追加された音声フレームを削除します。

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが AudioFrame であると仮定します。
        audio_frame = slide.shapes[0]

        # 音声フレームを削除します。
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **音声再生の設定**

スライドが表示されたときに音声フレームが自動的に再生されるように設定します。

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプが AudioFrame であると仮定します。
        audio_frame = slide.shapes[0]

        # スライドが表示されたときに自動的に再生します。
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```