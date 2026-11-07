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
- 網站來源
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for .NET 以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速上手指南。"
---
## **簡介**

影片可以協助說明概念並吸引觀眾。Aspose.Slides for .NET 讓您能在投影片中加入影片框架、調整播放設定、管理字幕，並擷取嵌入的影片資料。

PowerPoint 支援本機影片和指向線上影片的連結，例如 YouTube 影片。

為了表示影片資料與影片框架，Aspose.Slides 提供 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 介面以及其他相關類型。

## **建立嵌入式影片框架**

如果您想要加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

此範例將本機影片嵌入現有簡報的第一張投影片，並儲存結果。框架的座標與尺寸以點 (point) 為單位。因為 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) 會在簡報使用時保持串流鎖定，所以串流會保持開啟直到儲存完成。

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

您也可以直接將本機影片路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)。此範例將影片嵌入新簡報的第一張投影片。影片必須在簡報儲存之前保持可存取。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **精確設定影片音量**

在 Aspose.Slides for .NET 26.11 或更新版本中，[IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 設定 0 到 100 之間的浮點百分比。當 [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) 預設值過於粗糙時請使用它。例如，`75.5f` 代表 75.5% 音量。

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

自行驗證輸入；不要依賴 setter 來拒絕超出文件範圍的值。在 26.11 中，Low、Medium 和 Loud 預設分別對應 20、50 和 80。設定預設值可能會取代先前的百分比，因此在需要精確值時應最後指派百分比。使用 [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) 進行明確的靜音設定；數值 0 與預設列舉不是可互換的狀態。

在設定連結影片時也請明確設定 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)，並確保其媒體檔案對觀眾可取得。儲存後再開啟可驗證儲存的設定；實際播放與音量取決於簡報播放器及其音訊設定。

## **使用網路來源影片建立影片框架**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在簡報中支援線上影片。您可以建立指向線上影片（例如 YouTube 影片）的影片框架。

此範例將 YouTube 影片連結與縮圖加入第一張投影片。將影片識別碼替換即可使用其他影片。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 設定請求自動播放。下載縮圖與播放影片需要網路連線。簡報檢視器也必須支援線上影片播放。

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

在訓練簡報中，您可以以全螢幕模式播放軟體示範，讓觀眾看見細節。將 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 設為 `true` 即可在播放期間啟用此行為。

此範例開啟簡報，尋找第一張投影片上的第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用全螢幕播放。輸入的簡報必須在第一張投影片上至少有一個已存在的影片框架。

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

全螢幕播放會控制影片的顯示方式。除此之外，[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 決定是否自動或點擊時開始播放，且 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 決定是否重複播放。若要選擇開始行為，請將播放模式設定為 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)。此範例保留了現有的開始與迴圈設定。

## **播放後倒回影片**

在訓練簡報中，將示範影片倒回開頭可讓講者再次播放。將 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) 設為 `true`，即可在播放結束後將影片返回起點。

此範例開啟簡報，尋找第一張投影片上的第一個 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，並啟用倒回功能。它會停用迴圈以讓播放結束，並將播放設定為點擊時開始。輸入的簡報必須在第一張投影片上至少有一個已存在的影片框架。

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

倒回會將影片返回起點但不會再次啟動。相較之下，啟用 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 會自動重複播放。當您希望影片結束後仍可隨時重新播放時，請保持迴圈停用。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 獨立控制自動或點擊啟動；此範例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)，讓講者自行決定何時開始播放。請如範例所示在設定迴圈後再設定播放模式。倒回功能與 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 獨立運作。

## **裁剪影片框架**

使用 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) 可在播放時跳過影片的開頭或結尾部分。兩個值皆以毫秒為單位。裁剪會變更播放設定，但不會修改嵌入的影片資料。

**設定裁剪參數**

此範例嵌入本機影片，於播放時跳過前 2.5 秒與最後 1 秒。請使用長於 3.5 秒的影片，以保留可播放的片段。

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

此範例列印第一張投影片上第一個影片框架的裁剪值（以毫秒為單位）。簡報必須至少包含一張投影片。若該投影片沒有影片框架，則不會列印任何內容。前述範例會產生 2500 與 1000 的值。

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

Aspose.Slides 允許您在 PowerPoint 簡報中管理影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並可透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 屬性存取。

**為影片框架新增字幕**

此範例嵌入本機影片，並新增一個標示為 English 的 WebVTT 字幕軌。字幕時間戳記應與影片相符。儲存的簡報同時包含影片與其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 介面亦提供一個允許您從串流加入字幕的多載方法。

**從影片框架擷取字幕**

此範例將第一張投影片上所有影片框架的字幕軌儲存為個別的 WebVTT 檔案。依序編號以保持輸出檔案的獨特性。主控台會回報擷取的軌道數量。簡報必須至少包含一張投影片。

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

此範例移除第一張投影片上第一個圖形位置的影片框架中的所有字幕，並儲存結果。它假設投影片與圖形皆存在且該圖形為影片框架。

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

如果您只需要移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 方法，而非 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)。

## **從投影片擷取影片**

除了向投影片加入影片之外，Aspose.Slides 亦允許您擷取簡報中嵌入的影片。

此範例將每張投影片的嵌入影片擷取為獨立的編號二進位檔。連結的影片會被略過，因為它們沒有嵌入資料。主控台會印出每個影片的 MIME 類型以及總計數。輸出使用通用的 `.bin` 副檔名；如有需要可依報告的媒體類型更改副檔名。

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

您可以控制 [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自動或點擊）與 [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被納入文件中，簡報大小會隨檔案大小成比例增長。當您連結至線上影片並加入縮圖時，簡報只儲存連結與預覽圖像，而非影片資料，因而大小增幅通常較小。

**我可以在不變更位置與尺寸的情況下，替換現有影片框架中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，交換框架內的 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，這是更新既有版面媒體的常見情況。

**可以判斷嵌入影片的內容類型 (MIME) 嗎？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，您可將其用於例如儲存至磁碟等情況。