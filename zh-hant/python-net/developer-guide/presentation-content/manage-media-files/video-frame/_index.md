---
title: 在 Python 中將影片加入簡報
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/python-net/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框格
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via .NET，以程式方式在 PowerPoint 與 OpenDocument 投影片中加入與擷取影片框格。快速入門指南。"
---
## **簡介**

在簡報中恰當地放置影片，可使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 提供兩種方式將影片加入投影片：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自如 YouTube 等網路來源）

為了讓您能在簡報中加入影片（video objects），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框格**

如果要加入的影片檔案儲存在本機，您可以建立影片框格將影片嵌入簡報中。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。
1. 新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件以為影片建立框格。  
1. 儲存已修改的簡報。

以下 Python 程式碼示範如何將本機儲存的影片加入簡報：

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 取得第一張投影片並加入影片框格
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # 將簡報儲存至磁碟
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

或者，您也可以直接將檔案路徑傳入 `add_video_frame(x, y, width, height, fname)` 方法：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **建立來自網路來源的影片框格**

較新版的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) 支援在簡報中使用線上影片。若您想使用的影片已上傳至網路（如 YouTube），即可透過其網址將影片加入簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例
1. 透過索引取得投影片的參考。 
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 物件，並傳入影片連結。
1. 為影片框格設定縮圖。 
1. 儲存簡報。 

以下 Python 程式碼示範如何將網路影片加入 PowerPoint 投影片：

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 新增影片框格
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # 載入縮圖
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **修剪影片框格**

Aspose.Slides 允許透過 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_start/) 與 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_end/) 設定修剪起始與結束時間，以控制播放的影片段落。兩個數值皆以毫秒為單位，分別定義從影片開頭與結尾跳過的時間長度。此設定僅會變更簡報中的播放行為，並不會切割或修改嵌入的影片二進位資料。

**設定修剪參數**

建立影片框格並設定修剪參數的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 新增 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 物件至簡報。
1. 在投影片上新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。
1. 透過 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_start/) 與 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_end/) 設定修剪起始與結束值。
1. 儲存已修改的簡報。

以下程式碼示範在播放時略過嵌入影片的前 2.5 秒與最後 1 秒：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**讀取修剪參數**

若要檢查現有的修剪設定，可載入簡報、在第一張投影片的形狀中找到 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件，並透過 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_start/) 與 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/trim_from_end/) 讀取其值。

以下程式碼示範找到第一張投影片的第一個影片框格，並以毫秒為單位回報其修剪設定：

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **管理影片字幕**

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框格的隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 屬性取得。

**為影片框格新增字幕**

將字幕加入影片框格的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 為簡報新增影片。
1. 在投影片上新增 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。
1. 使用由 [caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 回傳的 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 以加入 WebVTT 字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何為影片框格新增字幕：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # 從 WebVTT 檔案新增一個字幕軌道。
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 類別亦提供可從資料流加入字幕的重載方法。

**從影片框格擷取字幕**

從影片框格擷取字幕的步驟：

1. 載入包含影片的簡報。
1. 找到目標的 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。
1. 迭代 [caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 集合。
1. 將每條字幕軌道儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框格擷取字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # 將字幕軌道儲存為 WebVTT 檔案。
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

每個 [Captions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料與 UTF-8 字串形式的字幕文字。

**從影片框格移除字幕**

從影片框格移除字幕的步驟：

1. 載入包含影片的簡報。
1. 取得目標的 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。
1. 從 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 中移除字幕軌道。
1. 儲存已修改的簡報。

以下程式碼示範如何移除影片框格中的全部字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 類型: slides.VideoFrame

    # 從影片框格移除所有字幕。
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只想移除單一字幕軌道，請使用 [remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/remove_at/) 方法，而非 [clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/clear/)。

## **從投影片中擷取影片**

除了將影片加入投影片，Aspose.Slides 也允許您從簡報中擷取已嵌入的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例以載入含有影片的簡報。 
2. 迭代所有 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 物件。
3. 於每張投影片的所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件中尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/)。 
4. 將影片儲存至磁碟。

以下 Python 程式碼示範如何從簡報投影片中擷取影片：

```python
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 物件
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **常見問題**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件的屬性控制 [playback mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/play_mode/)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/play_loop_mode/)。  

**加入影片會影響 PPTX 檔案大小嗎？**

會。若嵌入本機影片，二進位資料會寫入文件，簡報大小會隨影片檔案大小等比例增長。若加入線上影片，僅嵌入連結與縮圖，大小增加較少。

**我能在不變更位置與尺寸的情況下取代現有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何的前提下交換 [video content](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/embedded_video/)；這是更新既有版面媒體的常見情境。

**能否判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/content_type/)，您可在儲存至磁碟等情況下使用。