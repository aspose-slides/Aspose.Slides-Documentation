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
description: "学习使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速操作指南。"
---
## **简介**

视频可以帮助解释概念并吸引观众。Aspose.Slides for .NET 让您可以向幻灯片添加视频帧，调整播放设置，管理字幕，并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频的链接，例如 YouTube 视频。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您想要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例将在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧坐标和尺寸使用点（points）为单位。由于 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) 在演示文稿使用时保持流锁定，流会保持打开状态直至保存完成。

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

您也可以直接将本地视频路径传递给 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)。此示例将在新演示文稿的第一张幻灯片上嵌入视频。视频必须保持可访问，直至演示文稿保存完成。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **精确设置视频音量**

在 Aspose.Slides for .NET 26.11 或更高版本中，[IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 设置 0 到 100 之间的浮点百分比。当 [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) 预设太粗糙时使用它。例如，`75.5f` 表示 75.5% 音量。

此示例需要 [Aspose.Slides for .NET](/slides/zh/net/installation/) 26.11 或更高版本以及本地 `video.mp4`。它嵌入视频，显式初始化播放，保存演示文稿，并读取存储的百分比。

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

请自行验证输入；不要依赖属性设置器来拒绝超出文档范围的值。在 26.11 中，Low、Medium 和 Loud 预设分别对应 20、50 和 80。设置预设可能会覆盖之前的百分比，因此在需要精确数值时请最后分配百分比。使用 [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) 进行显式静音；数值零和预设枚举不是可互换的状态。

在配置链接视频时也要显式设置 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)，并确保其媒体文件对观看者可用。保存后重新打开可验证存储的设置；实际播放和音量取决于演示播放器及其音频设置。

## **使用网页来源视频创建视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在演示文稿中支持在线视频。您可以创建链接到在线视频（例如 YouTube 视频）的视频帧。

此示例在第一张幻灯片中添加 YouTube 视频链接和缩略图。替换视频标识符即可使用其他视频。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 设置请求自动播放。下载缩略图和播放视频需要互联网访问。演示文稿查看器也必须支持在线视频播放。

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

## **全屏播放视频**

在培训演示中，您可以以全屏模式播放软件演示，以便观众看到细节。将 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 设置为 `true`，即可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，其第一张幻灯片上有现有的视频帧。

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

全屏播放决定视频的显示方式。与此同时，[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 控制是自动开始还是点击开始，[PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 控制是否循环。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.Auto 或 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **播放后倒回视频**

在培训演示中，将演示视频返回到起始位置可让演示者再次播放。将 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) 设置为 `true`，即可在播放结束后将视频倒回起始位置。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)，并启用倒回。它禁用循环以让播放结束，并将播放设置为点击开始。输入演示文稿必须至少包含一张幻灯片，其第一张幻灯片上有现有的视频帧。

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

倒回会将视频返回起始位置而不重新开始。相反，启用 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) 会自动重复播放。当您希望视频播放完毕并保持可重新播放时，请保持循环关闭。[PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 独立控制自动或点击启动；本例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)，因此演示者可控制何时开始播放。请如示例所示在设置循环后再设置播放模式。倒回独立于 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) 工作。

## **裁剪视频帧**

使用 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) 和 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) 可在播放期间跳过视频的开头或结尾部分。两个值均以毫秒为单位。裁剪会更改播放设置，但不修改嵌入的视频数据。

**设置裁剪参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用长度超过 3.5 秒的视频，以保证仍有可播放的片段。

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

**读取裁剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会输出任何内容。前面的示例会产生 2500 和 1000 的值。

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

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭路字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 属性公开。

**向视频帧添加字幕**

此示例嵌入本地视频，并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一张幻灯片上所有视频帧的字幕轨道保存为单独的 WebVTT 文件。使用顺序编号保持输出文件的区别。控制台报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

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

每个 [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) 对象公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧移除字幕**

此示例从第一张幻灯片上第一个形状位置的视频帧中移除所有字幕并保存结果。它假设幻灯片和形状存在且该形状是视频帧。

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

如果只需要移除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/)。

## **从幻灯片提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例将每张幻灯片中的嵌入视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台打印每个视频的 MIME 类型和总计数。输出使用通用的 `.bin` 扩展名；如有需要可更改为匹配报告的媒体类型。

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

您可以控制[播放模式](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自动或点击），以及[循环](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

会的。嵌入本地视频时，二进制数据会包含在文档中，演示文稿大小随文件大小成比例增长。链接到在线视频并添加缩略图时，演示文稿仅存储链接和预览图像，而不是视频数据，因此大小增加通常较小。

**我能在不更改位置和尺寸的情况下替换现有视频帧中的视频吗？**

可以。您可以在保持形状几何不变的情况下替换框内的[视频内容](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入视频拥有可以读取并使用的[内容类型](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，例如将其保存到磁盘时。