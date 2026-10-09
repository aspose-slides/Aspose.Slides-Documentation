---
title: 在 .NET 中管理簡報的影片框架
linktitle: 影片框架
type: docs
weight: 10
url: /zh-hant/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 於 PowerPoint 與 OpenDocument 投影片中，以程式方式新增與擷取影片框架。快速操作指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for .NET 讓您能將影片框架加入投影片、調整播放設定、管理字幕，並擷取內嵌影片資料。

PowerPoint 支援本機影片以及連結至線上影片，例如 YouTube 影片。

為了表示影片資料和影片框架，Aspose.Slides 提供 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 介面，以及其他相關類型。

## **建立內嵌影片框架**

如果您想加入投影片的影片檔案儲存在本機，您可以建立影片框架以將影片內嵌至簡報中。

此範例在現有簡報的第一張投影片上內嵌本機影片並儲存結果。框架的座標與尺寸以點 (point) 為單位。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) 會在簡報使用時保持資料流鎖定，所以資料流會保持開啟，直至儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)。此範例在新簡報的第一張投影片上內嵌影片。影片必須在簡報儲存之前保持可存取。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **從網路來源建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。您可以建立一個連結至線上影片（例如 YouTube 影片）的影片框架。

此範例在第一張投影片加入 YouTube 影片連結與縮圖。請更換影片識別碼以使用其他影片。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 設定會請求自動播放。下載縮圖與播放影片均需網路連線。簡報檢視器亦必須支援線上影片播放。

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

在培訓簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看到細節。將 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 設為 `true` 即可在播放期間啟用此行為。

此範例開啟簡報，於第一張投影片上找尋第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入的簡報必須至少在第一張投影片上包含一個現有的影片框架。

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

全螢幕播放決定影片的顯示方式。除此之外，[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 控制是否自動或點擊開始播放，而 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 控制是否重複播放。若要選擇開始行為，請將播放模式設為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)。此範例保留了既有的開始與迴圈設定。

## **播放後倒回影片**

在培訓簡報中，將示範影片倒回至開頭可讓簡報者再次播放。將 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) 設為 `true`，即可在播放結束後將影片返回起始點。

此範例開啟簡報，於第一張投影片上找尋第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用倒回功能。它會停用迴圈以讓播放完成，並將播放設定為點擊開始。輸入的簡報必須至少在第一張投影片上包含一個現有的影片框架。

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

倒回會將影片返回起始點，但不會重新開始播放。相較之下，啟用 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 會自動重複播放。當您希望影片播放結束且保持可重新播放時，請保持迴圈停用。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)，讓簡報者自行決定何時開始播放。請在設定迴圈之後再設定播放模式，如範例所示。倒回功能與 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 獨立運作。

## **裁剪影片框架**

使用 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) 可在播放時略過影片開頭或結尾的部分。兩個數值皆以毫秒為單位。裁剪會變更播放設定，但不會修改內嵌影片資料。

**設定裁剪參數**

此範例內嵌本機影片，並在播放時跳過前 2.5 秒與最後 1 秒。請使用長度超過 3.5 秒的影片，以保留可播放的片段。

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

**讀取裁剪參數**

此範例以毫秒為單位列印第一張投影片上第一個影片框架的裁剪值。簡報必須至少包含一張投影片。如果該投影片沒有影片框架，則不會列印任何內容。前一個範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您在 PowerPoint 簡報中管理影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 屬性取得。

**為影片框架加入字幕**

此範例內嵌本機影片，並加入標記為 English 的 WebVTT 字幕軌。字幕時間戳必須與影片相符。儲存的簡報會同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 介面也提供一個重載，允許您從串流新增字幕。

**從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌儲存為個別的 WebVTT 檔案。使用連續編號以保持輸出檔案的唯一性。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

**從影片框架移除字幕**

此範例移除第一張投影片第一個形狀位置的影片框架上所有字幕，並儲存結果。它假設投影片與形狀皆存在且該形狀為影片框架。

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

如果您只想移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)。

## **從投影片擷取影片**

除了將影片加入投影片之外，Aspose.Slides 也允許您擷取簡報中內嵌的影片。

此範例將每張投影片內嵌的影片擷取為單獨的編號二進位檔案。連結的影片會被略過，因為它們沒有內嵌資料。主控台會列印每支影片的 MIME 類型與總計數量。輸出使用通用的 `.bin` 副檔名；必要時請依回報的媒體類型更改副檔名。

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

## **常見問題**

**可以變更影片框架的哪些播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自動或點擊）以及 [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 來控制。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會的。當您內嵌本機影片時，二進位資料會被包含在文件中，簡報大小會隨檔案大小成比例增加。當您連結至線上影片並加入縮圖時，簡報僅儲存連結與預覽圖像，而不是影片資料，通常會造成較小的檔案增長。

**我可以在不變更位置與大小的情況下取代現有影片框架中的影片嗎？**

會的。您可以在保留形狀幾何的前提下，交換框架內的 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，這是更新既有版面中媒體的常見情況。

**能否判定內嵌影片的內容類型（MIME）？**

會的。內嵌影片具有可讀取的 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，您可以使用它，例如在儲存至磁碟時。