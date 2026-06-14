---
title: 在 Python 中於簡報加入影片
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
description: "了解如何使用 Aspose.Slides for Python via .NET，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框格。快速操作指南。"
---
## **簡介**

在簡報中恰當地放置影片可以讓您的訊息更具說服力，並提升觀眾的參與度。 

PowerPoint 允許您以兩種方式將影片加入簡報的投影片中：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自網站來源，例如 YouTube）。

為了讓您能在簡報中加入影片（影片物件），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 類別、[VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 類別以及其他相關型別。 

## **建立嵌入式影片框格**

如果您想加入至投影片的影片檔案儲存在本機，您可以建立影片框格將影片嵌入簡報中。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 新增一個 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 物件，並傳遞影片檔案路徑以將影片嵌入簡報。  
1. 新增一個 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件，以建立影片的框格。  
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

或者，您也可以直接將檔案路徑傳遞給 `add_video_frame(x, y, width, height, fname)` 方法，以加入影片：

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **建立來自網路來源影片的影片框格**

Microsoft [PowerPoint 2013 及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。若您要使用的影片已上傳至線上（例如 YouTube），即可透過其網路連結將影片加入簡報。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例  
1. 透過索引取得投影片的參考。  
1. 新增一個 [Video](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/) 物件，並傳遞影片的連結。  
1. 為影片框格設定縮圖。  
1. 儲存簡報。  

以下 Python 程式碼示範如何將線上影片加入 PowerPoint 簡報的投影片中：

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

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框格中管理隱藏式字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 屬性取得。  

**將字幕加入影片框格**

將字幕加入影片框格的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
1. 將影片加入簡報。  
1. 在投影片中新增一個 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。  
1. 使用由 [caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 回傳的 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 以新增 WebVTT 字幕軌。  
1. 儲存已修改的簡報。  

以下程式碼示範如何將字幕加入影片框格：

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

[CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 類別也提供一個多載，可讓您從資料流新增字幕。  

**從影片框格擷取字幕**

從影片框格擷取字幕的步驟：

1. 載入包含影片的簡報。  
1. 尋找目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。  
1. 遍歷 [caption_tracks](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/caption_tracks/) 集合。  
1. 將每個字幕軌儲存為 `.vtt` 檔案。  

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

每個 [Captions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。  

**從影片框格移除字幕**

從影片框格移除字幕的步驟：

1. 載入包含影片的簡報。  
1. 取得目標 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/) 物件。  
1. 從 [CaptionsCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/) 中移除字幕軌。  
1. 儲存已修改的簡報。  

以下程式碼示範如何移除影片框格中的所有字幕：

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 類型：slides.VideoFrame

    # 移除影片框格中的所有字幕。
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

若您只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/remove_at/) 方法，取代 [clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/captionscollection/clear/)。  

## **從投影片擷取影片**

除了將影片加入投影片之外，Aspose.Slides 亦允許您擷取嵌入於簡報中的影片。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，以載入包含影片的簡報。  
2. 遍歷所有 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 物件。  
3. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 物件以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/)。  
4. 將影片儲存至磁碟。  

以下 Python 程式碼示範如何擷取簡報投影片中的影片：

```python
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **常見問題**

**可以為 VideoFrame 更改哪些影片播放參數？**

您可以透過 [VideoFrame] 物件的屬性控制 [playback mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/play_mode/)（自動或點擊播放）以及 [looping](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/play_loop_mode/)。  

**將影片加入 PPTX 會影響檔案大小嗎？**

是。當您嵌入本機影片時，二進位資料會包含在文件中，簡報大小會隨檔案大小成比例增長。當您加入線上影片時，只會嵌入連結與縮圖，尺寸增幅較小。  

**我可以在不更改位置和大小的情況下，替換現有 VideoFrame 的影片嗎？**

可以。您可以在保留形狀幾何的情況下，交換框格內的 [video content](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/videoframe/embedded_video/)，這是更新現有版面中媒體的常見情境。  

**能否判斷嵌入影片的內容類型（MIME）？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/video/content_type/)，您可以使用它，例如在儲存至磁碟時。