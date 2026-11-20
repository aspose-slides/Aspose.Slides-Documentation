---
title: 使用 Python 管理簡報中的音訊框架
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/python-net/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- WebVTT
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在投影片中嵌入音訊、更改音訊圖示、設定播放、管理 WebVTT 字幕，並擷取投影片轉場聲音。"
---
## **概述**

音訊框架讓您可以在投影片上播放聲音。使用 Aspose.Slides for Python via .NET，您可以嵌入音訊剪輯、選擇表示它的影像、調整播放設定，並附加字幕。您也可以取得指派給投影片轉場的聲音。

## **建立音訊框架**

使用 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 在第一張投影片上嵌入本機音訊剪輯。前兩個座標決定框架在投影片上的位置，接下來的兩個數值以點為單位設定其寬度與高度。此範例將 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 設為自動開始剪輯，並將 [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) 設為大音量預設。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **變更音訊框縮圖**

預設情況下，音訊框會顯示揚聲器圖示。若要顯示自訂縮圖，請使用 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 將圖像加入簡報，並指派給框架的 [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) 屬性。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **變更音訊播放選項**

PowerPoint 的 **Audio Options** 控制項決定剪輯何時開始、音量大小以及於投影片播放期間的行為。

![PowerPoint 音訊選項控制項 (針對音訊框)](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides property |
| --- | --- |
| 開始 | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| 音量預設 | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| 跨投影片播放 | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| 循環直到停止 | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| 播放時隱藏 | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| 播放後倒退 | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| 淡入 | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| 淡出 | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| 修剪音訊開始時間 | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| 修剪音訊結束時間 | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| 音量滑桿 | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

此範例在第一張投影片上尋找第一個音訊框，將 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 設為點擊時開始播放，並選擇低音量預設。剪輯在投影片間持續播放，且未啟用循環。圖示在播放期間保持隱藏，且剪輯在播放完畢後會倒退。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

對於長於 3.5 秒的剪輯，此範例會跳過前 1.5 秒與最後 2 秒。[trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 用於測量要從剪輯結尾省略的時間長度。若要取得 PowerPoint 中顯示的結束時間，請將此偏移量從完整剪輯長度中減去。修剪後的剪輯在 200 毫秒內淡入，並在 500 毫秒內淡出。所有四個屬性皆以毫秒為單位。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

若要將播放音量設定為特定百分比，可使用 [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/)。此範例將第一張投影片上的第一個音訊框音量設定為 85%。

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理音訊字幕**

每個音訊框都有一個 [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) 集合。可使用它為剪輯附加 WebVTT 字幕、匯出現有軌道，或將其移除。

### **新增音訊字幕**

此範例在第一張投影片上嵌入音訊剪輯，並使用 [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) 附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數指定包含時間字幕的檔案。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **擷取音訊字幕**

此範例匯出附加於第一張投影片音訊框的每個字幕軌道。它將軌道的 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) 寫入 WebVTT 檔案，並以其 [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) 作為檔名，使每個軌道產生獨立的輸出。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **移除音訊字幕**

使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 或 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 可刪除單一軌道。此範例使用 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) 從第一張投影片的第一個音訊框中移除所有字幕，同時保留剪輯。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **在音訊字幕中尋找行**

若要在第一張投影片的音訊字幕中尋找特定行，請於記憶體中讀取每個軌道的 [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/)。在純文字的 WebVTT 提示中，時間線包含 `-->`，字幕行緊隨其後，空白行則結束此提示。此範例列印出軌道標籤以及包含「café」的每一字幕行。

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **擷取音訊**

投影片轉場可以有自己的聲音。若要取得它，請讀取轉場的 [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) 屬性。此範例存取聲音的 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/)，並列印其位元組大小。若第一張投影片沒有轉場聲音，則會列印訊息。

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **常見問題**

**我可以在多張投影片中重複使用相同的音訊剪輯而不產生重複嗎？**

可以。將剪輯一次加入簡報的 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/)，然後於每張投影片呼叫 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 時傳遞相同的音訊物件。

**我可以替換現有音訊框中的聲音嗎？**

可以。對於連結聲音，請更新 [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) 指向替換檔案。對於嵌入聲音，將簡報音訊集合中的其他剪輯指派給 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/)。兩種方式皆保留現有框架。

**修剪會改變儲存在簡報中的音訊資料嗎？**

不會。[trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) 與 [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 只設定播放範圍。仍可從 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) 取得完整剪輯。