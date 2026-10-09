---
title: 在 .NET 中管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/net/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "学习使用 Aspose.Slides for .NET 以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速入门指南。"
---
## **简介**

视频可以帮助解释概念并吸引观众。Aspose.Slides for .NET 允许您向幻灯片添加视频帧、调整播放设置、管理字幕，并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频（如 YouTube 视频）的链接。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件保存在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例在现有演示文稿的第一页嵌入本地视频并保存结果。帧坐标和尺寸使用点（point）为单位。由于 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) 在演示文稿使用流期间保持其锁定，流会保持打开状态直至保存完成。

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

您也可以将本地视频路径直接传递给 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)。此示例在新演示文稿的第一页嵌入视频。视频在保存演示文稿之前必须保持可访问。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **创建来自网络源的视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。您可以创建一个链接到在线视频（如 YouTube 视频）的视频帧。

此示例在第一页添加 YouTube 视频链接和缩略图。将视频标识符替换为其他视频即可使用另一段视频。 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 设置请求自动播放。下载缩略图和播放视频均需要网络访问。演示文稿查看器也必须支持在线视频播放。

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

## **以全屏模式播放视频**

在培训演示中，您可以以全屏模式播放软件演示，让观众看到细节。将 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 设置为 `true` 即可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一页的第一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，并启用全屏播放。输入演示文稿必须至少在第一页包含一个已有的视频帧。

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

全屏播放决定视频的显示方式。与此同时， [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 控制是自动启动还是点击启动， [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 控制是否循环播放。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)。示例保留了已有的启动和循环设置。

## **在播放后倒回视频**

在培训演示中，将演示视频倒回开头可让演讲者再次播放。将 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) 设置为 `true` 即可在播放完成后将视频倒回开头。

此示例打开一个演示文稿，查找第一页的第一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，并启用倒回。它关闭循环以便播放结束，并将播放设置为点击启动。输入演示文稿必须至少在第一页包含一个已有的视频帧。

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

倒回会将视频返回到开头而不会再次启动。相反，启用 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 会自动循环播放。希望视频播放完毕后保持可重新播放时，请保持循环关闭。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 独立控制自动或点击启动；本例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) 让演讲者自行控制播放开始时机。请先设置循环属性后再设置播放模式，如示例所示。倒回独立于 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 工作。

## **剪辑视频帧**

使用 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) 和 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) 可在播放期间跳过视频开头或结尾的部分。两个值的单位为毫秒。剪辑仅更改播放设置，不会修改嵌入的视频数据。

**设置剪辑参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放的片段。

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

**读取剪辑参数**

此示例以毫秒为单位打印第一页第一视频帧的剪辑值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会输出任何内容。前面的示例会产生 2500 和 1000 两个值。

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

## **管理视频字幕**

Aspose.Slides 允许您在 PowerPoint 演示文稿中管理视频帧的闭合字幕。字幕以 WebVTT 格式存储，可通过 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 属性访问。

**向视频帧添加字幕**

此示例嵌入本地视频并添加标签为 English 的 WebVTT 字幕轨。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 接口还提供了一个重载，可让您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一页所有视频帧的字幕轨保存为单独的 WebVTT 文件。使用递增编号确保输出文件唯一。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

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

每个 [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) 对象会暴露字幕标识符、标签、二进制数据以及 UTF-8 编码的字幕文本。

**从视频帧删除字幕**

此示例删除第一页第一个形状位置的视频帧的所有字幕并保存结果。它假设幻灯片和形状均存在，且该形状是视频帧。

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

如果只需要删除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取演示文稿中嵌入的视频。

此示例将每张幻灯片中嵌入的视频提取为单独的、带序号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型以及总数。输出使用通用的 `.bin` 扩展名；如有需要，可根据报告的媒体类型更改为相应的扩展名。

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

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以控制 [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自动或点击）和 [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

会的。当您嵌入本地视频时，二进制数据会被写入文档，因而演示文稿大小会按视频文件大小成比例增长。若链接到在线视频并添加缩略图，演示文稿只存储链接和预览图像，而不是视频本身，通常导致的大小增长更小。

**是否可以在不改变位置和尺寸的情况下替换已有视频帧中的视频？**

可以。您可以在保持形状几何不变的前提下替换帧内的 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，这在更新已有布局中的媒体时非常常见。

**是否可以确定嵌入视频的内容类型（MIME）？**

可以。嵌入视频具有可读取的 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，您可以在保存到磁盘等场景中使用该信息。