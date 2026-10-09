---
title: 使用 Python 管理簡報中的影片框架
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
description: "學習如何使用 Aspose.Slides for Python via Java，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速入門指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Python via Java 讓您能在投影片中加入影片框架、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片（例如 YouTube 影片）的連結。

為了表示影片資料與影片框架，Aspose.Slides 提供 [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框架**

如果您要加入投影片的影片檔案位於本機，您可以建立影片框架將影片嵌入簡報中。

此範例會在既有簡報的第一張投影片嵌入本機影片，並儲存結果。框架的座標與尺寸以點 (point) 為單位。Python 從磁碟讀取影片位元組，JPype 會在將影片加入簡報前將其轉換為 Java 位元組陣列。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame)。此範例在新簡報的第一張投影片嵌入影片。影片必須保持可存取，直到簡報儲存為止。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **使用來自網路來源的影片建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援簡報中的線上影片。您可以建立指向線上影片（例如 YouTube 影片）的影片框架。

此範例會在第一張投影片加入 YouTube 影片連結與縮圖。請替換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 方法會要求自動播放。下載縮圖與播放影片皆需要網路連線。簡報檢視器亦必須支援線上影片播放。

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在全螢幕模式播放影片**

在訓練簡報中，您可以在全螢幕模式播放軟體示範，讓觀眾看到細節。將 `True` 傳入 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 即可在播放期間啟用此行為。

此範例會開啟簡報，尋找第一張投影片上的第一個 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入簡報必須至少在第一張投影片包含一個已存在的影片框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

全螢幕播放會控制影片的顯示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 控制是否自動或點擊開始播放，而 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 控制是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/)。此範例會保留既有的開始與循環設定。

## **在播放後倒回影片**

在訓練簡報中，將示範影片倒回起始位置可讓簡報者再次播放。將 `True` 傳入 [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) 即可在播放結束後將影片倒回起始位置。

此範例會開啟簡報，尋找第一張投影片上的第一個 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，並啟用倒帶。它會停用循環，使播放能結束，並將播放設定為點擊開始。輸入簡報必須至少在第一張投影片包含一個已存在的影片框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

倒帶會將影片回到起始位置，但不會重新啟動。相較之下，將 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 設為 `True` 會自動重複播放。當您希望影片播放完畢後仍保持可再次播放的狀態時，請停用循環。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) 讓簡報者自行決定何時開始播放。請先設定循環，再設定播放模式，如範例所示。倒帶與 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 的使用彼此獨立。

## **修剪影片框架**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) 可在播放時跳過影片的開頭或結尾部分。兩個數值的單位為毫秒。修剪會變更播放設定，而不會修改嵌入的影片資料。

**設定修剪參數**

此範例會嵌入本機影片，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的片段。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**讀取修剪參數**

此範例會列印第一張投影片上第一個影片框架的修剪值（單位：毫秒）。簡報必須至少包含一張投影片；若該投影片沒有影片框架，則不會印出任何資訊。前述範例會產生 2500 與 1000 的數值。

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

Aspose.Slides 允許您在 PowerPoint 簡報的影片框架中管理隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

**將字幕加入影片框架**

此範例會嵌入本機影片，並加入標記為 English 的 WebVTT 字幕軌道。字幕時間戳記應與影片相符。儲存的簡報會同時包含影片與其字幕。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # 從 WebVTT 檔案新增字幕軌道。
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) 類別同時提供接受串流的載入字幕之多載方法。

**從影片框架擷取字幕**

此範例會將第一張投影片上所有影片框架的字幕軌道另存為獨立的 WebVTT 檔案。使用連續編號可保持輸出檔案的唯一性。主控台會回報擷取到的軌道數量。簡報必須至少包含一張投影片。

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

每個 [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) 物件會公開字幕的識別碼、標籤、二進位資料以及以 UTF-8 字串表示的字幕文字。

**從影片框架移除字幕**

此範例會移除第一張投影片上第一個形狀位置的影片框架的所有字幕，並儲存結果。它假設投影片與形狀皆存在且該形狀為影片框架。

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
        # 從影片框架移除所有字幕。
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

如果只需移除單一字幕軌道，請改用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear)。

## **從投影片擷取影片**

除了向投影片加入影片外，Aspose.Slides 也允許您擷取嵌入在簡報中的影片。

此範例會將每張投影片中嵌入的影片擷取為獨立的、編號的二進位檔案。連結的影片會被跳過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型與總數。輸出使用通用的 `.bin` 副檔名；必要時可依報告的媒體類型更改副檔名。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **常見問題集**

**可以變更影片框架的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 物件的方式，控制[播放模式](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode)（自動或點擊）與[循環](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode)。  

**加入影片會影響 PPTX 檔案大小嗎？**

會。若您嵌入本機影片，二進位資料會寫入文件，簡報的大小會隨影片檔案大小成比例增加。若您連結線上影片並加入縮圖，簡報只會儲存連結與預覽圖像，而非影片本身，通常會較少增加檔案大小。

**我可以在不變更位置與尺寸的情況下，替換既有影片框架中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) 交換框架內的影片內容，這是更新既有版面媒體的常見做法。

**是否可以判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入的影片具有 [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType)，您可以讀取並使用它，例如在儲存至磁碟時決定適當的副檔名。