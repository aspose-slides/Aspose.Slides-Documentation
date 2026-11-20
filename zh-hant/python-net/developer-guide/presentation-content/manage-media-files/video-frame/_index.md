---
title: 在 Python 中管理簡報的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/python-net/video-frame/
keywords:
- 新增影片
- 建立影片
- 嵌入影片
- 抽取影片
- 擷取影片
- 影片框架
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via .NET 以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與抽取影片框架。快速上手指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for Python via .NET 讓您能將影片框架新增至投影片、調整播放設定、管理字幕，並抽取嵌入的影片資料。

PowerPoint 支援本機影片以及指向線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供 [視訊](https://reference.aspose.com/slides/python-net/aspose.slides/video/) 類別、[影片框架](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 類別，以及其他相關型別。

## **建立嵌入式影片框架**

如果您想加入至投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例在現有簡報的第一張投影片上嵌入本機影片並儲存結果。框架的座標與尺寸以點 (point) 為單位。串流會保持開啟直到儲存完成，因為 [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) 在簡報使用時會鎖定它。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

您也可以直接將本機影片路徑傳遞給 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/)。此範例在新簡報的第一張投影片上嵌入影片。影片必須保持可存取狀態，直到簡報儲存為止。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立連結至線上影片的影片框架，例如 YouTube 影片。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。請替換影片識別碼以使用其他影片。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 設定要求自動播放。下載縮圖與播放影片皆需網路存取。簡報檢視器也必須支援線上影片播放。

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

## **以全螢幕模式播放影片**

在教學簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看見細節。將 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 設為 `True` 即可在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片找到第一個 [影片框架](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，並啟用全螢幕播放。輸入的簡報必須在第一張投影片至少包含一個已存在的影片框架。

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

全螢幕播放會控制影片的顯示方式。另一方面，[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 決定是自動開始或點擊後開始，而 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 決定是否重複播放。若要選擇開始行為，請將播放模式設為 [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)。此範例保留了原有的開始與迴圈設定。

## **回繞影片於播放後**

在教學簡報中，將示範影片回到開頭可讓主持人再次播放。將 [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) 設為 `True` 即可在播放結束後將影片返回起點。

此範例開啟簡報，於第一張投影片找到第一個 [影片框架](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)，並啟用回繞。它會停用迴圈以讓播放結束，並將播放模式設為點擊開始。輸入的簡報必須在第一張投影片至少包含一個已存在的影片框架。

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

回繞會將影片返回開頭但不會再次啟動。相反地，啟用 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 會自動重複播放。當您希望影片結束且保持可重新播放時，請將迴圈停用。[play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) 讓主持人自行決定何時開始播放。請如範例所示在設定迴圈之後再設定播放模式。回繞與 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) 無關。

## **裁剪影片框架**

使用 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) 與 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) 於播放期間跳過影片的開頭或結尾部分。兩個數值皆以毫秒為單位。裁剪會變更播放設定，卻不會修改嵌入的影片資料。

**設定裁剪參數**

此範例嵌入本機影片，並於播放時跳過前 2.5 秒與最後 1 秒。請使用長於 3.5 秒的影片，以確保保留可播放的片段。

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

**讀取裁剪參數**

此範例以毫秒為單位列印第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片。若該投影片沒有影片框架，則不會輸出任何內容。前一個範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您管理 PowerPoint 簡報中影片框架的隱蔽字幕。字幕以 WebVTT 格式儲存，並透過 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) 屬性提供。

### **為影片框架新增字幕**

此範例嵌入本機影片，並新增一條標示為 English 的 WebVTT 字幕軌。字幕的時間戳記應與影片相符。儲存的簡報會同時包含影片與其字幕。

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

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) 類別亦提供一個重載，允許您從串流新增字幕。

### **從影片框架抽取字幕**

此範例將第一張投影片上所有影片框架的字幕軌另存為個別的 WebVTT 檔案。使用連續編號以區分輸出檔案。主控台會報告抽取的軌道數量。簡報必須至少包含一張投影片。

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

每個 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) 物件會公開字幕識別碼、標籤、二進位資料，以及作為 UTF-8 字串的字幕文字。

### **從影片框架移除字幕**

此範例從第一張投影片第一個圖形位置的影片框架中移除所有字幕，並儲存結果。它假設該投影片與圖形皆存在且圖形為影片框架。

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

如果只需要移除單一字幕軌，請使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 方法，而非 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)。

### **搜尋影片字幕**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) 會回傳整個 WebVTT 軌道，包括其標頭、時間線與字幕文字。例如，投影片 2 上的 English 軌道可能包含以下提示：

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例開啟 `captioned_media.pptx`，並讀取每張投影片上每個頂層影片框架的 [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/)。對於每個純文字提示，程式會找出包含 `-->` 的時間線，並收集該提示直到下一個空白行或軌道結尾的字幕行。它會不分大小寫搜尋字幕文字中是否包含「café」，並為每個符合的結果列印投影片編號、軌道標籤、原始時間線與完整字幕。

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

此範例軌道會產生一筆符合。標頭中的「Café」不屬於字幕文字，且輸出會保留時間設定與兩行字幕。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片抽取影片**

除了將影片新增至投影片之外，Aspose.Slides 也允許您抽取嵌入於簡報中的影片。

此範例將每張投影片中嵌入的影片抽取為個別、編號的二進位檔案。連結的影片會被跳過，因為它們沒有嵌入資料。主控台會列印每支影片的 MIME 類型與總數量。輸出使用通用的 `.bin` 副檔名；如有需要，可依回報的媒體類型更改副檔名。

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

## **常見問答**

**可以變更影片框架的哪些播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)（自動或點擊）與 [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) 進行控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。當您嵌入本機影片時，二進位資料會寫入文件中，因而使簡報大小按檔案大小成比例增加。若您鏈結至線上影片並加入縮圖，簡報只儲存連結與預覽影像，而非影片資料，通常大小增幅較小。

**我可以在不變更位置與大小的情況下替換現有影片框架中的影片嗎？**

可以。您可以交換框架內的 [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)，同時保留形狀的幾何尺寸；這在更新現有版面配置中的媒體時很常見。

**可以判斷嵌入影片的內容類型 (MIME) 嗎？**

可以。嵌入的影片具有一個 [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)，您可以讀取並使用，例如在儲存至磁碟時。