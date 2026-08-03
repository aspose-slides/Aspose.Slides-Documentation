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
description: "学习使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---
## **简介**

在演示文稿中恰当地放置视频可以使您的信息更具说服力并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿中的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自诸如 YouTube 的网络来源）。

为帮助您向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideo/) 对象，并传递视频文件路径以将视频嵌入到演示文稿中。  
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象以为视频创建帧。  
1. 保存修改后的演示文稿。  

下面的 C# 代码展示了如何将本地存储的视频添加到演示文稿中：

```c#
// 实例化 Presentation 类
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 加载视频
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // 获取第一张幻灯片并添加视频帧
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // 将演示文稿保存到磁盘
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
另外，您也可以通过将文件路径直接传递给 [AddVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **使用网络来源视频创建视频帧**
较新版本的 Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中插入在线视频。如果您要使用的视频在线可用（例如在 YouTube 上），可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideo/) 对象，并传递视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。  

下面的 C# 代码展示了如何将网络视频添加到 PowerPoint 演示文稿的幻灯片中：

```c#
public static void Run()
{
    // 实例化一个表示演示文稿文件的 Presentation 对象
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // 添加 VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // 加载缩略图
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **裁剪视频帧**

Aspose.Slides 允许您通过设置 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromstart/) 和 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromend/) 的 trim-from-start 与 trim-from-end 值来控制播放视频的哪一部分。这两个值以毫秒为单位，分别定义从视频开头和结尾跳过的时间长度。这些设置会更改演示文稿中的视频播放设置；它们不会剪切或以其他方式修改嵌入的视频二进制数据。

**设置裁剪参数**

要创建视频帧并设置其裁剪参数：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加一个 [IVideo](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideo/) 对象。  
1. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象。  
1. 通过 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromstart/) 和 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromend/) 设置 trim-from-start 与 trim-from-end 值。  
1. 保存修改后的演示文稿。  

下面的代码示例在播放期间跳过嵌入视频的前 2.5 秒和最后 1 秒：

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

**读取裁剪参数**

要检查现有的裁剪参数，加载演示文稿，在第一张幻灯片的形状中找到一个 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象，并通过 [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromstart/) 和 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/trimfromend/) 读取这些值。

下面的代码示例查找第一张幻灯片上的第一个视频帧并以毫秒报告其裁剪参数：

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

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/captiontracks/) 属性公开。

**向视频帧添加字幕**

要向视频帧添加字幕：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加视频。  
1. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象。  
1. 使用 [CaptionTracks](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/captiontracks/) 集合添加 WebVTT 字幕轨道。  
1. 保存修改后的演示文稿。  

下面的代码展示了如何向视频帧添加字幕：

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // 从 WebVTT 文件添加新的字幕轨道。
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

要从视频帧提取字幕：

1. 加载包含该视频的演示文稿。  
1. 找到目标 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象。  
1. 遍历 [CaptionTracks](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/captiontracks/) 集合。  
1. 将每个字幕轨道保存为 `.vtt` 文件。  

下面的代码展示了如何从视频帧提取字幕：

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
                // 将字幕轨道保存为 WebVTT 文件。
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

每个 [ICaptions](https://reference.aspose.com/slides/zh/net/aspose.slides/icaptions/) 对象公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧移除字幕**

要从视频帧移除字幕：

1. 加载包含该视频的演示文稿。  
1. 获取目标 [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 对象。  
1. 从 [CaptionTracks](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/captiontracks/) 集合中移除字幕轨道。  
1. 保存修改后的演示文稿。  

下面的代码展示了如何移除视频帧中的所有字幕：

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // 删除视频帧中的所有字幕。
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

如果您只需要移除单个字幕轨道，请使用 [Remove](https://reference.aspose.com/slides/zh/net/aspose.slides/captionscollection/remove/) 或 [RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides/captionscollection/removeat/) 方法，而不是 [Clear](https://reference.aspose.com/slides/zh/net/aspose.slides/captionscollection/clear/)。

## **从幻灯片提取视频**
除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide) 对象。  
3. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/videoframe)。  
4. 将视频保存到磁盘。  

下面的 C# 代码展示了如何提取演示文稿幻灯片上的视频：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("Video.pptx");

// 遍历幻灯片
foreach (ISlide slide in presentation.Slides)
{
    // 遍历形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 在找到包含视频的 VideoFrame 后将视频保存到磁盘
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

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/videoframe/) 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/net/aspose.slides/videoframe/playmode/)（自动或点击）和 [looping](https://reference.aspose.com/slides/zh/net/aspose.slides/videoframe/playloopmode/)。这些选项通过 VideoFrame 对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

是的。嵌入本地视频时，二进制数据会包含在文档中，因此演示文稿大小会随文件大小成比例增长。添加在线视频时，只会嵌入链接和缩略图，文件大小增加较少。

**我可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

是的。您可以在保持形状几何的情况下交换帧内的 [video content](https://reference.aspose.com/slides/zh/net/aspose.slides/videoframe/embeddedvideo/)，这在更新现有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

是的。嵌入视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/net/aspose.slides/video/contenttype/)，您可以在将其保存到磁盘时使用。