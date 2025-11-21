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
description: "学习使用 Aspose.Slides for .NET 以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速实用指南。"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（来自诸如 YouTube 的网络来源）

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您想要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 对象，并传递视频文件路径以在演示文稿中嵌入视频。
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 对象以创建视频帧。
1. 保存修改后的演示文稿。

下面的 C# 代码演示了如何将本地存储的视频添加到演示文稿中：
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

或者，您也可以直接将视频文件路径传递给 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您想使用的视频可在线获取（例如在 YouTube 上），您可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 对象，并传递视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

下面的 C# 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：
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


## **从幻灯片中提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe)。
4. 将视频保存到磁盘。

下面的 C# 代码演示了如何提取演示文稿幻灯片中的视频：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation("Video.pptx");

// 遍历幻灯片
foreach (ISlide slide in presentation.Slides)
{
    // 遍历形状
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 在找到包含视频的 VideoFrame 时将视频保存到磁盘
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


## **常见问题**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以控制 [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自动或点击）和 [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

会的。当您嵌入本地视频时，二进制数据会被包含在文档中，因此演示文稿的大小会随文件大小成比例增长。添加在线视频时，仅嵌入链接和缩略图，大小增加相对较小。

**我可以在不更改位置和尺寸的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何不变的情况下，替换帧内的 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，您可以使用它，例如在将视频保存到磁盘时。