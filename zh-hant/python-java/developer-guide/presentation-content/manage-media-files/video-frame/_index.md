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
description: "學習使用 Aspose.Slides for Python via Java，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速操作指南。"
---
## **簡介**

影片可以協助解釋概念並吸引觀眾。Aspose.Slides for Python via Java 讓您能將影片框架新增至投影片、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片與線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 類別以及其他相關類型。

## **建立嵌入式影片框架**

如果您要新增至投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入至簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架的座標與尺寸以點 (point) 為單位。Python 從磁碟讀取影片位元組，JPype 會將其轉換為 Java 位元組陣列，然後將影片新增至簡報中。

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

您也可以直接將本機影片路徑傳遞給 [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame)。此範例將影片嵌入新簡報的第一張投影片。必須在儲存簡報之前保持影片可存取。

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

## **使用網路來源的影片建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立連結至線上影片（例如 YouTube 影片）的影片框架。

此範例將 YouTube 影片連結與縮圖新增至第一張投影片。請替換影片識別碼以使用其他影片。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 方法會要求自動播放。下載縮圖與播放影片皆需網際網路連線。簡報檢視器亦必須支援線上影片播放。

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

## **以全螢幕模式播放影片**

在訓練簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看到細節。呼叫 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 並傳入 `True` 即可在播放期間啟用此行為。

此範例開啟一個簡報，於第一張投影片中搜尋第一個 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入簡報必須至少在第一張投影片上包含一個已存在的影片框架。

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

全螢幕播放會控制影片的顯示方式。另一方面，[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 決定影片是自動開始還是點擊後開始，而 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 決定是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/)。此範例保留了原有的開始與迴圈設定。

## **播放後倒帶影片**

在訓練簡報中，將示範影片倒回開頭可讓簡報者再次播放。呼叫 [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) 並傳入 `True`，即可在播放結束後將影片返回開頭。

此範例開啟簡報，於第一張投影片上找到第一個 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/)，並啟用倒帶。它會停用迴圈，使播放能夠結束，並將播放設定為點擊開始。輸入簡報必須在第一張投影片上至少包含一個已存在的影片框架。

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

倒帶會將影片返回開頭而不會重新開始。相較之下，將 [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) 設為 `True` 會自動重複播放。當您希望影片播放完畢後仍保持可重新播放時，請保持迴圈關閉。[setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) 讓簡報者自行決定何時開始播放。請在設定迴圈之後再設定播放模式，如範例所示。倒帶功能與 [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) 無關。

## **剪裁影片框架**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) 與 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) 於播放時略過影片的開頭或結尾部分。兩個值皆以毫秒為單位。剪裁會變更播放設定，但不會修改嵌入的影片資料。

**設定剪裁參數**

此範例嵌入本機影片，於播放時略過前 2.5 秒與最後 1 秒。請使用長於 3.5 秒的影片，以確保仍有可播放的片段。

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

**讀取剪裁參數**

此範例以毫秒為單位印出第一張投影片上第一個影片框架的剪裁值。簡報必須至少包含一張投影片。若該投影片沒有影片框架，則不會印出任何內容。前述範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) 方法取得。

### **為影片框架加入字幕**

此範例嵌入本機影片，並加入標記為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) 類別亦提供一個重載，可讓您從串流加入字幕。

### **從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌另存為個別的 WebVTT 檔案。使用連續編號以保持輸出檔案的唯一性。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) 物件會顯示字幕識別碼、標籤、二進位資料以及以 UTF-8 字串表示的字幕文字。

### **從影片框架移除字幕**

此範例從第一張投影片第一個圖形位置的影片框架移除所有字幕，並儲存結果。假設該投影片與圖形皆存在，且圖形為影片框架。

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

如果只需移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 方法，而非 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear)。

### **搜尋影片字幕**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) 會回傳完整的 WebVTT 軌道，包含標頭、時間線與字幕文字。您可以在記憶體中搜尋字幕，以找出特定片語及其時間戳記。例如，第 2 張投影片的英文軌道可能包含以下文字。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並使用 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) 讀取每張投影片上每個頂層影片框架的軌道。在純文字提示中，時間線會包含 `-->`，且空白行結束提示。對於每個包含「café」且不分大小寫的字幕，範例會印出投影片編號、軌道標籤、原始時間線與完整字幕。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue
                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)
                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

搜尋「café」會在範例軌道中產生一筆匹配結果。搜尋會排除軌道標頭，並保留時間設定與換行。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了將影片加入投影片外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。

此範例將每張投影片中嵌入的影片擷取為個別編號的二進位檔案。連結的影片會被略過，因為它們沒有嵌入資料。主控台會印出每個影片的 MIME 類型及總數。輸出使用通用的 `.bin` 副檔名；如有需要，請改為符合報告的媒體類型。

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

## **常見問題**

**可以變更影片框架的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) 物件的方法，控制[播放模式](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode)（auto or on click）以及[迴圈](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode)。這些選項可透過相應的方法設定。

**新增影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被寫入文件，因此簡報大小會隨影片檔案大小成比例增長。若您連結至線上影片並加入縮圖，簡報只會儲存連結與預覽影像，而非影片資料，因而大小增幅通常較小。

**是否可以在不變更位置與大小的情況下，替換既有影片框架中的影片？**

會。您可以在框架內交換[影片內容](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) 同時保留形狀的幾何資訊；這是在既有版面更新媒體的常見情況。

**是否能判斷嵌入影片的內容類型（MIME）？**

會。嵌入的影片具有可透過[內容類型](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType)讀取的內容類型，您可以使用它，例如在儲存至磁碟時。