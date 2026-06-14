---
title: 影片
type: docs
weight: 80
url: /zh-hant/python-net/examples/elements/video/
keywords:
- 影片
- 影片框架
- 新增影片
- 存取影片
- 移除影片
- 影片播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理影片：插入、替換、剪輯、設定海報框架與播放選項，並將簡報匯出為 PPT、PPTX 與 ODP。"
---
顯示如何嵌入影片框架並設定播放選項，使用 **Aspose.Slides for Python via .NET**。

## **新增影片框架**

在投影片上插入一個空的影片框架。

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增影片框架。
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **存取影片框架**

取得在投影片上加入的第一個影片框架。

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取投影片上的第一個影片框架。
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **移除影片框架**

從投影片中刪除影片框架。

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是影片框架。
        video_frame = slide.shapes[0]

        # 移除影片框架。
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **設定影片播放**

設定影片在投影片顯示時自動播放。

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是影片框架。
        video_frame = slide.shapes[0]

        # 設定影片自動播放。
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```