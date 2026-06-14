---
title: 音訊
type: docs
weight: 70
url: /zh-hant/python-net/examples/elements/audio/
keywords:
- 音訊
- 音訊框架
- 新增音訊
- 存取音訊
- 移除音訊
- 音訊播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理音訊：新增、取代、提取與裁剪聲音，並在 PowerPoint 與 OpenDocument 中設定投影片與圖形的音量與播放方式。"
---
說明如何在 **Aspose.Slides for Python via .NET** 中嵌入音訊框架並控制播放。以下範例展示基本的音訊操作。

## **新增音訊框架**

以下程式碼範例會在投影片上新增音訊框架。

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **存取音訊框架**

此程式碼會從投影片中取得第一個音訊框架。

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

## **移除音訊框架**

刪除先前新增的音訊框架。

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 AudioFrame.
        audio_frame = slide.shapes[0]

        # 移除音訊框架.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **設定音訊播放**

設定音訊框架，使其在投影片出現時自動播放。

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 AudioFrame.
        audio_frame = slide.shapes[0]

        # 投影片出現時自動播放.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```