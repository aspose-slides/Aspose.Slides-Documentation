---
title: 在 .NET 中管理簡報的影片框格
linktitle: 影片框格
type: docs
weight: 10
url: /zh-hant/net/video-frame/
keywords:
- 加入影片
- 建立影片
- 嵌入影片
- 擷取影片
- 取得影片
- 影片框格
- 網路來源
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 以程式方式在 PowerPoint 和 OpenDocument 投影片中加入與擷取影片框格。快速使用指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for .NET 讓您能在投影片中加入影片框格、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片與線上影片連結，例如 YouTube 影片。

為了表示影片資料與影片框格，Aspose.Slides 提供 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 介面，以及其他相關型別。

## **建立嵌入式影片框格**

如果您要加入至投影片的影片檔案儲存在本機，可以建立影片框格將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框格座標與尺寸以點 (points) 為單位。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) 在簡報使用期間保持鎖定，故串流會保持開啟直到儲存完成。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

您也可以直接將本機影片路徑傳給 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前持續可存取。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **精確設定影片音量**

在 Aspose.Slides for .NET 26.11 或更新版本中，[IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 可設定 0 到 100 的浮點百分比。當 [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) 預設值太粗糙時使用。例如，`75.5f` 代表 75.5% 音量。

此範例需要 [Aspose.Slides for .NET](/slides/zh-hant/net/installation/) 26.11 或更新版本以及本機 `video.mp4`。它會嵌入影片、明確初始化播放、儲存簡報，並讀回儲存的百分比。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

請自行驗證輸入；不要依賴設定子在文件化範圍之外自動拒絕值。Low、Medium 與 Loud 預設分別對應 26.11 版的 20、50、80。設定預設可能會取代先前的百分比，因此在需要精確值時最後指定百分比。若要明確靜音，請使用 [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/)；數值 0 與預設列舉並非可互換的狀態。

在設定連結影片時，也請明確設定 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)，並保持其媒體檔案對觀眾可用。儲存後重新開啟可驗證儲存的設定；實際播放與音量仍取決於簡報播放器及其音訊設定。

## **建立來自網路來源的影片框格**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援簡報中的線上影片。您可以建立連結至線上影片的影片框格，例如 YouTube 影片。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。將影片識別碼替換為其他影片即可。設定 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 會要求自動播放。下載縮圖與播放影片皆需網路連線。簡報檢視器亦必須支援線上影片播放。

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **全螢幕播放影片**

在訓練簡報中，您可以全螢幕播放軟體示範，讓觀眾看到細節。將 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 設為 `true` 即可在播放期間啟用此行為。

此範例開啟簡報、在第一張投影片上尋找第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入簡報必須至少在第一張投影片上已有一個影片框格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

全螢幕播放決定影片的顯示方式。另一方面，[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 控制是否自動或點擊開始，[PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 控制是否重複播放。若要選擇開始行為，請將播放模式設為 [VideoPlayModePreset.Auto 或 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)。此範例保留了現有的開始與迴圈設定。

## **影片播放完畢後倒帶**

在訓練簡報中，將示範影片倒回至起始位置可讓講者再次播放。將 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) 設為 `true`，即可在播放結束後將影片倒回至開頭。

此範例開啟簡報、在第一張投影片上尋找第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用倒帶。它會關閉迴圈以讓播放結束，並將播放模式設為點擊開始。輸入簡報必須至少在第一張投影片上已有一個影片框格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

倒帶會將影片回到起始位置而不會重新啟動。相對地，啟用 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 會自動重複播放。希望影片結束後仍可隨時重播時，請保持迴圈關閉。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) 讓講者自行決定何時開始播放。請在設定迴圈之後再設定播放模式，如範例所示。倒帶與 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 互不影響。

## **修剪影片框格**

使用 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) 可在播放時略過影片開頭或結尾的部分。兩個值皆以毫秒為單位。修剪會變更播放設定，而不會修改嵌入的影片資料。

**設定修剪參數**

此範例嵌入本機影片，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的片段。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**讀取修剪參數**

此範例在第一張投影片的第一個影片框格上印出修剪值（單位：毫秒）。簡報必須至少包含一張投影片；若該投影片沒有影片框格，則不會印出任何內容。前一個範例會產生 2500 與 1000 的值。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框格中管理閉路字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 屬性存取。

### **為影片框格加入字幕**

此範例嵌入本機影片，並加入標記為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片吻合。儲存的簡報同時包含影片與其字幕。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 介面亦提供可從串流加入字幕的多載方法。

### **從影片框格擷取字幕**

此範例將第一張投影片上所有影片框格的字幕軌保存為個別的 WebVTT 檔案。使用連續編號以保持輸出檔案的唯一性。主控台會顯示擷取到的軌道數量。簡報必須至少包含一張投影片。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

每個 [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) 物件會公開字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

### **從影片框格移除字幕**

此範例移除第一張投影片第一個形狀位置的影片框格上所有字幕，並儲存結果。它假設該投影片與形狀皆存在且形狀為影片框格。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

如果只需要移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)。

### **搜尋影片字幕**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) 會回傳完整的 WebVTT 軌，包括標頭、時間線與字幕文字。若要找出特定語句及其時間戳記，可在記憶體中讀取 cue。例如，第 2 張投影片的英文軌可能包含以下文字：

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

此範例會走訪每張投影片，透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 讀取其頂層影片框格的軌道。純文字 cue 的時間線包含 `-->`，空白行結束 cue。當字幕文字包含「café」時，範例會印出投影片編號、軌道標籤、原始時間線與完整字幕。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

搜尋「café」會產生一筆符合樣本軌的結果。標頭與時間設定不在 cue 文字內。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **從投影片擷取影片**

除了向投影片加入影片之外，Aspose.Slides 也允許您擷取簡報中嵌入的影片。

此範例將每張投影片上嵌入的影片擷取為獨立的編號二進位檔案。連結影片會被略過，因為它們沒有嵌入資料。主控台會印出每段影片的 MIME 類型與總計數量。輸出使用通用的 `.bin` 副檔名；需要時請改為符合報告之媒體類型的副檔名。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **常見問題集**

**可以修改影片框格的哪些播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 物件的屬性控制[播放模式](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自動或點擊）以及[迴圈](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會寫入文件，簡報大小會隨影片檔案大小成比例增長。若您連結至線上影片並加入縮圖，簡報僅儲存連結與預覽影像，通常會較小。

**能否在不變更位置與尺寸的情況下替換已有影片框格中的影片？**

可以。您可以交換 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) 而保留形狀的幾何屬性，這是更新既有版面媒體的常見情境。

**能否判斷嵌入影片的內容類型 (MIME)？**

能。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，可用於例如儲存至磁碟時的檔案類型判斷。