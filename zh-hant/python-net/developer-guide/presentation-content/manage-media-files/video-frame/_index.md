---
title: 在 Python 中管理簡報中的影片框格
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
description: "學習如何使用 Aspose.Slides for Python via .NET 以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框格。快速操作指南。"
---
## **介紹**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Python via .NET 讓您可以將影片框格加入投影片、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片（例如 YouTube 影片）的連結。

為了表示影片資料與影片框格，Aspose.Slides 提供了 [影片](https://reference.aspose.com/slides/python-net/aspose.slides/video/) 類別、[影片框格](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框格**

如果要加入的影片檔案位於本機，您可以建立影片框格將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並將結果儲存。框格座標與尺寸的單位為點。因為 [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) 會在簡報使用期間保持鎖定，所以串流會持續開啟，直到儲存完成為止。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

您也可以直接將本機影片路徑傳遞給 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前保持可存取。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **建立來自網路來源的影片框格**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。您可以建立連結至線上影片（例如 YouTube 影片）的影片框格。

此範例將 YouTube 影片連結與縮圖加入第一張投影片。將影片識別碼替換為其他影片即可使用其他影片。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 設定要求自動播放。下載縮圖與播放影片需要網路存取，簡報檢視器亦必須支援線上影片播放。

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **全螢幕播放影片**

在培訓簡報中，您可以全螢幕播放軟體示範，讓觀眾看到細節。將 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 設為 `True`，即可在播放期間啟用此行為。

此範例開啟簡報，找出第一張投影片上的第一個 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入簡報必須至少在第一張投影片上包含一個已存在的影片框格。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

全螢幕播放決定影片的顯示方式。獨立地，[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 控制它是自動播放或點擊播放，而 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 則控制是否重複播放。若要選擇開始行為，請將播放模式設為 [VideoPlayModePreset.AUTO 或 VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)。此範例會保留既有的開始與迴圈設定。

## **播放完畢後倒回影片**

在培訓簡報中，將示範影片倒回開頭可使簡報者再次播放。將 [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) 設為 `True`，即可在播放結束後將影片倒回開頭。

此範例開啟簡報，找出第一張投影片上的第一個 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，並啟用倒回。它會停用迴圈，使播放能完整結束，並將播放設定為點擊開始。輸入簡報必須至少在第一張投影片上包含一個已存在的影片框格。

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

倒回會將影片返回開頭而不會再次啟動。相反地，啟用 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 會自動重複播放。當您希望影片結束後保持可重播狀態時，請停用迴圈。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)，讓簡報者自行決定何時開始播放。請在設定迴圈之後再設定播放模式，如範例所示。倒回與 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 獨立運作。

## **剪裁影片框格**

使用 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) 與 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) 可在播放期間跳過影片開頭或結尾的部分。兩個值的單位為毫秒。剪裁會變更播放設定，但不會修改嵌入的影片資料。

**設定剪裁**

此範例將本機影片嵌入，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長於 3.5 秒的影片，以確保仍有可播放的段落。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**讀取剪裁設定**

此範例以毫秒為單位輸出第一張投影片上第一個影片框格的剪裁值。簡報必須至少包含一張投影片；若該投影片沒有影片框格，則不會輸出任何內容。前面的範例會產生 2500 與 1000 兩個值。

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框格中管理隱蔽字幕。字幕以 WebVTT 格式儲存，並可透過 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/)屬性存取。

**為影片框格加入字幕**

此範例將本機影片嵌入，並加入標記為 English 的 WebVTT 字幕軌道。字幕時間戳記必須與影片相符。儲存的簡報會同時包含影片與其字幕。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) 類別亦提供一個多載，允許您從串流加入字幕。

**從影片框格擷取字幕**

此範例將第一張投影片上所有影片框格的字幕軌道保存為個別的 WebVTT 檔案。使用連續編號以確保輸出檔案唯一。主控台會報告擷取的軌道數量。簡報必須至少包含一張投影片。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

每個 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料以及作為 UTF-8 字串的字幕文字。

**從影片框格移除字幕**

此範例移除第一張投影片上第一個形狀位置的影片框格的所有字幕，並儲存結果。它假設該投影片與形狀皆存在且該形狀為影片框格。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只需要移除單一字幕軌道，請使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 方法，取代 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)。

## **從投影片中擷取影片**

除了將影片加入投影片，Aspose.Slides 也允許您從簡報中擷取嵌入的影片。

此範例將每張投影片中的嵌入影片擷取為獨立的編號二進位檔案。連結影片會被跳過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 型別與總計數量。輸出使用通用的 `.bin` 副檔名；必要時可依報告的媒體型別更改副檔名。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **常見問題**

**可以變更影片框格的哪些播放參數？**

您可以控制 [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動或點擊）與 [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。若將本機影片嵌入，二進位資料會被寫入文件，簡報大小會隨影片檔案大小成比例增長。若連結線上影片並加入縮圖，簡報僅儲存連結與預覽影像，而非影片資料，通常會使檔案大小增幅較小。

**可以在不變更位置與尺寸的情況下替換既有影片框格中的影片嗎？**

可以。您可以交換影片框格內的 [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)，同時保留形狀的幾何屬性；這是更新既有版面中媒體的常見情境。

**能否判斷嵌入影片的內容類型 (MIME)？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)，您可以在例如儲存至磁碟時使用它。