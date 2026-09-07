---
title: 影片
type: docs
weight: 80
url: /zh-hant/python-java/examples/elements/video/
keywords:
- 程式碼範例
- 影片
- 影片框架
- 新增影片
- 存取影片
- 移除影片
- 影片播放
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 與 OpenDocument 簡報中新增、存取、移除與設定影片框架。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 來加入影片框架並設定播放選項。

按照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 運行後匯入 API。

## **加入影片框架**

插入一個參照外部影片檔案的影片框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增一個連結至影片檔案的影片框架。
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **存取影片框架**

取得已新增至投影片的第一個影片框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 取得投影片上的第一個影片框架。
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

## **移除影片框架**

從投影片中刪除影片框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 移除影片框架。
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **設定影片播放**

設定影片在投影片顯示時自動播放。

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

    # 設定影片自動播放。
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```