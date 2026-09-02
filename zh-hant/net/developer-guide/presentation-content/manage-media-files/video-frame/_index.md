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
description: "學習如何使用 Aspose.Slides for .NET，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速操作指南。"
---
## **簡介**

在簡報中恰當放置的影片可以讓您的訊息更具說服力，並提升觀眾的參與度。 

PowerPoint 允許您以兩種方式將影片加入簡報中的投影片：

* 加入或嵌入本機影片（儲存在您的電腦上）
* 加入線上影片（來自如 YouTube 等網站來源）。

為了讓您能在簡報中加入影片（影片物件），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 介面以及其他相關型別。 

## **建立嵌入影片框架**

如果您想要加入投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
1. 透過索引取得投影片的參考。 
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 物件，並傳入影片檔案路徑以將影片嵌入簡報。 
1. 新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件以建立影片框架。  
1. 儲存修改後的簡報。 

以下 C# 程式碼示範如何將本機儲存的影片加入簡報：

```c#
// 實例化 Presentation 類別
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 載入影片
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // 取得第一張投影片並新增影片框架
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // 將簡報儲存至磁碟
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
或者，您也可以直接將檔案路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addvideoframe/) 方法以加入影片：

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **使用來自網路來源的影片建立影片框架**
較新版本的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支援在簡報中使用線上影片。如果您要使用的影片已在網路上提供（例如 YouTube），您可以透過其網路連結將其加入簡報。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例
1. 透過索引取得投影片的參考。 
1. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 物件，並傳入影片的連結。 
1. 設定影片框架的縮圖。 
1. 儲存簡報。 

以下 C# 程式碼示範如何將來自網路的影片加入 PowerPoint 簡報的投影片中：

```c#
public static void Run()
{
    // 實例化一個代表簡報檔案的 Presentation 物件
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // 新增影片框架
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // 載入縮圖
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **修剪影片框架**

Aspose.Slides 允許您透過設定 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromend/) 的值，來控制播放影片的哪一部分。這兩個值以毫秒為單位，分別定義從影片開始與結束處跳過的時間長度。這些設定會變更簡報中影片的播放設定；不會裁剪或以其他方式修改嵌入影片的二進位資料。

**設定修剪參數**

若要建立影片框架並設定其修剪參數：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 將 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 物件新增至簡報中。
1. 在投影片上新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
1. 透過 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromend/) 設定 trim-from-start 與 trim-from-end 的值。
1. 儲存已修改的簡報。

以下程式碼範例在播放時跳過嵌入影片的前 2.5 秒和最後 1 秒：

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**讀取修剪設定**

若要檢查現有的修剪設定，請載入簡報，於第一張投影片的圖形中找到 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件，並透過 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromstart/) 與 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/trimfromend/) 讀取其值。

以下程式碼範例會找出第一張投影片上的第一個影片框架，並以毫秒為單位回報其修剪設定：

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **管理影片字幕**

Aspose.Slides 允許您在 PowerPoint 簡報的影片框架上管理隱藏式字幕。字幕以 WebVTT 格式儲存，並透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 屬性公開。

**為影片框架新增字幕**

若要為影片框架新增字幕：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 將影片新增至簡報。
1. 在投影片上新增 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
1. 使用 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合新增 WebVTT 字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何為影片框架新增字幕：

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增字幕軌道。
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

此外，[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/) 介面也提供一個載入方式，允許您從串流新增字幕。

**從影片框架擷取字幕**

若要從影片框架擷取字幕：

1. 載入包含影片的簡報。
1. 找到目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
1. 遍歷 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合。
1. 將每個字幕軌儲存為 `.vtt` 檔案。

以下程式碼示範如何從影片框架擷取字幕：

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // 將字幕軌道儲存為 WebVTT 檔案。
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptions/) 物件會公開字幕的識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

**從影片框架移除字幕**

若要從影片框架移除字幕：

1. 載入包含影片的簡報。
1. 取得目標的 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
1. 從 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合中移除字幕軌。
1. 儲存已修改的簡報。

以下程式碼示範如何從影片框架中移除所有字幕：

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // 從影片框架中移除所有字幕。
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

如果您只需要移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/clear/)。

## **從投影片擷取影片**
除了將影片加入投影片外，Aspose.Slides 亦允許您擷取嵌入於簡報中的影片。 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，以載入包含影片的簡報。 
2. 遍歷所有 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide) 物件。
3. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 物件，以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe)。 
4. 將影片儲存至磁碟。

以下 C# 程式碼示範如何從簡報投影片上擷取影片：

```c#
// 實例化代表簡報檔案的 Presentation 物件 
Presentation presentation = new Presentation("Video.pptx");

// 迭代投影片
foreach (ISlide slide in presentation.Slides)
{
    // 迭代形狀
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 在找到包含影片的 VideoFrame 後，將影片儲存至磁碟
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**可以變更 VideoFrame 的哪些影片播放參數？**

您可以透過 [playback mode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/playmode/)（自動或點擊播放）與 [looping](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/playloopmode/) 來控制播放模式。這些選項可透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/) 物件的屬性取得。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會被包含在文件中，導致簡報大小隨檔案大小成比例增加。當您加入線上影片時，僅嵌入連結與縮圖，尺寸增長較小。

**我能在不變更位置與大小的情況下，取代現有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，交換框架內的 [video content](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/embeddedvideo/)，這在更新既有版面配置中的媒體時相當常見。

**能否判斷嵌入影片的內容類型（MIME）？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/video/contenttype/)，您可在例如儲存至磁碟時使用它。