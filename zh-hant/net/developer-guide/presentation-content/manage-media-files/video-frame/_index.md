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
description: "學習如何使用 Aspose.Slides for .NET，以程式方式在 PowerPoint 與 OpenDocument 投影片中新增與擷取影片框架。快速上手指南。"
---
## **簡介**

在簡報中恰當放置影片可以使您的訊息更具說服力，並提升觀眾的參與度。

PowerPoint 允許您以兩種方式將影片新增至簡報的投影片中：

* 新增或嵌入本機影片（儲存在您的電腦上）
* 新增線上影片（來自 YouTube 等網路來源）

為了讓您能在簡報中加入影片（video 物件），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 介面、[IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 介面，以及其他相關型別。

## **建立嵌入式影片框架**

如果您要加入至投影片的影片檔案儲存在本機，您可以建立影片框架將影片嵌入簡報中。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得投影片的參照。
3. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 物件，並傳入影片檔案路徑，以將影片嵌入簡報中。
4. 新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件，以為影片建立框架。
5. 儲存已修改的簡報。

以下 C# 程式碼示範如何將本機儲存的影片新增至簡報：

```c#
// 建立 Presentation 類別的實例
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
或者，您也可以直接將檔案路徑傳遞給 [AddVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addvideoframe/) 方法來新增影片：

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **建立來自網路來源的影片框架**

Microsoft [PowerPoint 2013 以及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支援在簡報中使用 YouTube 影片。若您欲使用的影片已在網路上（例如 YouTube），即可透過其網路連結將其加入簡報。

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例
2. 透過索引取得投影片的參照。
3. 新增一個 [IVideo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideo/) 物件，並傳入影片的連結。
4. 為影片框架設定縮圖。
5. 儲存簡報。

以下 C# 程式碼示範如何從網路將影片新增至 PowerPoint 投影片中：

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
    // 新增 VideoFrame
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

## **管理影片字幕**

Aspose.Slides 讓您能管理 PowerPoint 簡報中影片框架的隱藏字幕。字幕以 WebVTT 格式儲存，並透過 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 屬性存取。

**將字幕加入影片框架**

將字幕加入影片框架的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 將影片新增至簡報。
3. 在投影片上新增一個 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
4. 使用 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合，新增 WebVTT 字幕軌。
5. 儲存已修改的簡報。

以下程式碼示範如何將字幕加入影片框架：

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // 從 WebVTT 檔案新增一條字幕軌。
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptionscollection/) 介面亦提供一個可從串流加入字幕的多載方法。

**從影片框架擷取字幕**

從影片框架擷取字幕的步驟：

1. 載入包含該影片的簡報。
2. 尋找目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
3. 遍歷 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合。
4. 將每個字幕軌儲存為 `.vtt` 檔案。

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
                // 將字幕軌保存為 WebVTT 檔案。
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

每個 [ICaptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icaptions/) 物件會揭露字幕識別碼、標籤、二進位資料，以及以 UTF-8 字串表示的字幕文字。

**移除影片框架的字幕**

從影片框架移除字幕的步驟：

1. 載入包含該影片的簡報。
2. 取得目標 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/) 物件。
3. 從 [CaptionTracks](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ivideoframe/captiontracks/) 集合中移除字幕軌。
4. 儲存已修改的簡報。

以下程式碼示範如何移除影片框架中的所有字幕：

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

如果只需移除單一字幕軌，請使用 [Remove](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/removeat/) 方法，而非 [Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/captionscollection/clear/)。

## **從投影片擷取影片**

除了將影片新增至投影片之外，Aspose.Slides 也允許您擷取嵌入於簡報中的影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，以載入包含影片的簡報。
2. 遍歷所有 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide) 物件。
3. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape) 物件，以尋找 [VideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe)。
4. 將影片儲存至磁碟。

以下 C# 程式碼示範如何從簡報投影片中擷取影片：

```c#
// 實例化一個代表簡報檔案的 Presentation 物件 
Presentation presentation = new Presentation("Video.pptx");

// 迭代投影片
foreach (ISlide slide in presentation.Slides)
{
    // 迭代形狀
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 當找到包含影片的 VideoFrame 時，將影片儲存至磁碟
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

## **常見問題**

**可以對 VideoFrame 更改哪些影片播放參數？**

您可以透過 [VideoFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/) 物件的屬性控制 [playback mode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/playmode/)（自動或點擊播放）以及 [looping](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/playloopmode/)。

**加入影片會影響 PPTX 檔案大小嗎？**

會。當您嵌入本機影片時，二進位資料會寫入文件中，導致簡報大小隨檔案大小成比例增加。加入線上影片時，只會嵌入連結與縮圖，大小增幅較小。

**我可以在不變更位置與大小的情況下，取代現有 VideoFrame 中的影片嗎？**

可以。您可以在保留形狀幾何的前提下，交換框架內的 [video content](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/videoframe/embeddedvideo/)，這是更新既有版面中媒體的常見情境。

**可以判斷嵌入影片的內容類型（MIME）嗎？**

可以。嵌入的影片具有可讀取的 [content type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/video/contenttype/)，您可在例如儲存至磁碟時使用它。