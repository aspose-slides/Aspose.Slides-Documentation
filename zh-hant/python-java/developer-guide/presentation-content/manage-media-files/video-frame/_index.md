---
title: 使用 Python 在簡報中管理影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/python-java/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框架
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via Java，在 PowerPoint 與 OpenDocument 投影片中以程式方式新增與擷取影片框架。快速上手指南。"
---
## **簡介**

在簡報中適當放置的影片可以使您的訊息更加有說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片新增至簡報中的投影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自諸如 YouTube 等網路來源）。

為了讓您能將影片（video 物件）新增至簡報，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 類別以及其他相關類型。

## **建立內嵌影片框架**

如果您想新增至投影片的影片檔案儲存在本機，您可以建立影片框架以將影片內嵌至簡報中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 透過索引取得投影片的參考。
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/video/) 物件，並傳遞影片檔案資料以將影片內嵌至簡報中。
1. 新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件，以建立影片的框架。
1. 儲存已修改的簡報。

以下 Python 程式碼示範如何將本機儲存的影片新增至簡報：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

或者，您也可以直接將檔案路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addVideoFrame) 方法來新增影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。若您要使用的影片線上可取得（例如在 YouTube 上），您可以透過其網路連結將其加入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體
1. 透過索引取得投影片的參考。
1. 新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件，並傳遞影片的連結。
1. 為影片框架設定縮圖。
1. 儲存簡報。

以下 Python 程式碼示範如何將來自網路的影片新增至 PowerPoint 簡報的投影片中：

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # 載入縮圖。
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **修剪影片框架**

Aspose.Slides 允許您透過 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setTrimFromEnd) 設定 trim-from-start 與 trim-from-end 之值，以控制影片播放的區段。兩個值皆以毫秒為單位，分別定義從影片開始與結束處跳過的時間長度。此設定會變更簡報中影片的播放行為，並不會裁剪或以其他方式修改內嵌影片的二進位資料。

**設定修剪參數**

建立影片框架並設定其修剪參數的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 向簡報新增 [Video](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/video/) 物件。
1. 向投影片新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件。
1. 透過 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setTrimFromEnd) 設定 trim-from-start 與 trim-from-end 的值。
1. 儲存已修改的簡報。

以下程式碼示範在播放時跳過內嵌影片的前 2.5 秒與最後 1 秒：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**讀取修剪參數**

若要檢視現有的修剪參數，請載入簡報，於第一張投影片的形狀中尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件，並透過 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#getTrimFromStart) 與 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#getTrimFromEnd) 讀取其值。

以下程式碼示範如何找出第一張投影片中的第一個影片框架，並以毫秒為單位回報其修剪參數：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**新增字幕至影片框架**

將字幕新增至影片框架的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 向簡報新增影片。
1. 向投影片新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件。
1. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#getCaptionTracks) 回傳的 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 來新增 WebVTT 字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何將字幕新增至影片框架：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # 從 WebVTT 檔案新增字幕軌。
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 類別亦提供一個重載，可讓您從串流新增字幕。

**從影片框架擷取字幕**

從影片框架擷取字幕的步驟如下：

1. 載入包含影片的簡報。
1. 找到目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件。
1. 迭代 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 中的字幕軌。
1. 將每個字幕軌儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # 將字幕軌儲存為 WebVTT 檔案。
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

每個 [Captions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captions/) 物件會公開字幕的 identifier、label、二進位資料，以及以 UTF-8 編碼的字幕文字。

**從影片框架移除字幕**

從影片框架移除字幕的步驟如下：

1. 載入包含影片的簡報。
1. 取得目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件。
1. 從 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/) 中移除字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何移除影片框架中的全部字幕：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # 移除影片框架中的所有字幕。
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

如果您只需移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了將影片新增至投影片外，Aspose.Slides 也允許您擷取簡報中內嵌的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體，以載入包含影片的簡報。
2. 迭代所有 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 物件。
3. 迭代所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/)。
4. 將影片儲存至磁碟。

以下 Python 程式碼示範如何擷取簡報投影片上的影片：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **常見問題**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 物件的屬性控制 [playback mode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setPlayMode)（自動或點擊播放）以及 [looping](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setPlayLoopMode)。

**新增影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被寫入文件，簡報大小會依檔案大小等比例增加。當您新增線上影片時，僅會嵌入連結與縮圖，因而僅會稍微增加大小。

**能否在不變更位置與大小的情況下取代現有 VideoFrame 的影片？**

可以。您可以在保留形狀幾何的情況下，於框架內更換 [video content](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/#setEmbeddedVideo)，此為更新現有版面媒體的常見情境。

**能否判斷內嵌影片的內容類型 (MIME)？**

可以。內嵌影片具備可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/video/#getContentType)，您可以使用它，例如在儲存至磁碟時。