---
title: ビデオ
type: docs
weight: 80
url: /ja/python-net/examples/elements/video/
keywords:
- ビデオ
- ビデオフレーム
- ビデオを追加
- ビデオにアクセス
- ビデオを削除
- ビデオ再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でビデオを操作します。ビデオの挿入、置換、トリミング、ポスターフレームと再生オプションの設定、そして PPT、PPTX、ODP 用にプレゼンテーションをエクスポートできます。"
---
**Aspose.Slides for Python via .NET** を使用して、ビデオフレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオフレームを追加**

スライドに空のビデオフレームを挿入します。

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # ビデオフレームを追加します。
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **ビデオフレームにアクセス**

スライドに追加された最初のビデオフレームを取得します。

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初のビデオフレームにアクセスします。
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **ビデオフレームを削除**

スライドからビデオフレームを削除します。

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがビデオフレームであると仮定します。
        video_frame = slide.shapes[0]

        # ビデオフレームを削除します。
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ビデオ再生を設定**

スライドが表示されたときにビデオが自動的に再生されるように構成します。

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のシェイプがビデオフレームであると仮定します。
        video_frame = slide.shapes[0]

        # ビデオが自動的に再生されるように設定します。
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```