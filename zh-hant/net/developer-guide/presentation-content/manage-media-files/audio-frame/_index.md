---
title: 管理 .NET 簡報中的音訊框架
linktitle: 音訊框架
type: docs
weight: 10
url: /zh-hant/net/audio-frame/
keywords:
- 音訊
- 音訊框架
- 縮圖
- 新增音訊
- 音訊屬性
- 音訊選項
- 擷取音訊
- .NET
- C#
- Aspose.Slides
description: "在投影片中嵌入音訊、更改音訊圖示、設定播放、管理 WebVTT 字幕，並使用 Aspose.Slides for .NET 擷取投影片轉場聲音。"
---
## **概述**

音訊框架讓您在投影片上播放聲音。使用 Aspose.Slides for .NET，您可以嵌入音訊剪輯、選擇代表它的圖像、調整播放方式，並附加字幕。您也可以取得指派給投影片轉場的聲音。

## **建立音訊框架**

使用 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) 在第一張投影片上嵌入本機音訊剪輯。前兩個座標定位框架於投影片上，接下來的兩個值以點為單位設定寬度與高度。本範例將 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) 設為自動開始剪輯，並將 [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) 設為大聲預設。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **變更音訊框架縮圖**

預設情況下，音訊框架會顯示揚聲器圖示。若要顯示自訂縮圖，請使用 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) 將影像加入簡報，並將其指派給框架的 [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) 屬性。此範例使用 JPEG 作為嵌入音訊剪輯的縮圖。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **變更音訊播放選項**

PowerPoint 的 **Audio Options** 控制項決定剪輯何時開始、音量多大，以及在投影片放映期間的行為。

![PowerPoint 音訊選項控制項（音訊框架）](audio_frame_0.png)

| PowerPoint 控制項 | Aspose.Slides 屬性 |
| --- | --- |
| 開始 | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| 音量預設 | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| 跨投影片播放 | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| 持續迴圈直到停止 | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| 在放映期間隱藏 | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| 播放後倒帶 | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| 淡入 | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| 淡出 | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| 剪輯音訊開始時間 | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| 剪輯音訊結束時間 | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| 音量滑桿 | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

此範例在第一張投影片上找到第一個音訊框架，將 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) 設為點擊時開始播放，並選取低音量預設。剪輯在投影片間持續播放，且未啟用迴圈。圖示在放映期間保持隱藏，且剪輯在播放後倒帶。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

對於長度超過 3.5 秒的剪輯，此範例會跳過前 1.5 秒與最後 2 秒。[TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) 量測要從剪輯結尾省略的時間長度。要取得 PowerPoint 顯示的結束時間，請將該偏移量從完整剪輯時長中減去。修剪後的剪輯在 200 毫秒內淡入，並在 500 毫秒內淡出。所有四個屬性的值皆以毫秒為單位。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

若要將播放音量設定為特定百分比，請使用 [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/)。此範例將第一張投影片上的第一個音訊框架設定為 85%。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **管理音訊字幕**

每個音訊框架都有一個 [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) 集合。可使用它將 WebVTT 字幕附加到剪輯、匯出現有軌道，或將其移除。

### **新增音訊字幕**

此範例在第一張投影片嵌入音訊剪輯，並使用 [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) 附加本機 WebVTT 軌道。第一個參數提供軌道標籤，第二個參數指定包含時間字幕的檔案。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **擷取音訊字幕**

此範例匯出附加於第一張投影片音訊框架的每個字幕軌道。它將軌道的 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) 寫入 WebVTT 檔案，並以其 [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) 作為檔名，使每個軌道都有單獨的輸出。

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **移除音訊字幕**

使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) 刪除個別軌道。此範例使用 [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) 移除第一張投影片上第一個音訊框架的所有字幕，同時保留剪輯。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **在音訊字幕中尋找行**

若要在第一張投影片的音訊字幕中尋找行，請於記憶體中讀取每個軌道的 [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/)。在純文字 WebVTT 提示中，時間行包含 `-->`，字幕行跟在其後，空白行則結束提示。此範例輸出軌道標籤以及每一行包含 “café” 的字幕。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **擷取音訊**

投影片轉場可以有自己的聲音。若要取得它，請讀取轉場的 [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) 屬性。此範例存取聲音的 [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) 並輸出其位元組大小。若第一張投影片沒有轉場聲音，則會改為輸出訊息。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **常見問題**

**我可以在多張投影片之間重複使用相同的音訊剪輯而不會重複嗎？**

是的。將剪輯一次加入簡報的 [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) ，然後對每張投影片呼叫 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) 並傳入相同的音訊物件。

**我可以取代現有音訊框架中的聲音嗎？**

是的。對於連結的聲音，更新 [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) 以指向取代的檔案。對於嵌入的聲音，將簡報音訊集合中的另一個剪輯指派給 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)。兩種方式皆保留現有框架。

**剪輯會改變簡報中存儲的音訊資料嗎？**

不會。[TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) 與 [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) 設定播放邊界。您仍可從 [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) 取得完整剪輯。