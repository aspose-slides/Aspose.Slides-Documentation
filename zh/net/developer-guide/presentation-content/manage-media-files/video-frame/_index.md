---
title: 视频帧
type: docs
weight: 10
url: /zh/net/video-frame/
keywords: "添加视频，创建视频帧，提取视频，PowerPoint 演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加视频帧"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提高观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自如 YouTube 的网络来源）。

为了让您向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建视频帧以在演示文稿中嵌入该视频。

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 对象，并传递视频文件路径以将视频嵌入演示文稿中。
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 对象来为视频创建帧。
1. 保存已修改的演示文稿。

以下 C# 代码演示如何将本地存储的视频添加到演示文稿中：
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

或者，您可以通过将文件路径直接传递给 [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **创建来自网络源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频在线可用（例如在 YouTube 上），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 对象，并传递视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下 C# 代码演示如何将网络视频添加到 PowerPoint 演示文稿的幻灯片中：
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
    // 添加一个 VideoFrame
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


## **从幻灯片提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) 对象，以查找 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe)。
4. 将视频保存到磁盘。

以下 C# 代码演示如何提取演示文稿幻灯片上的视频：
```c#
 // 实例化一个表示演示文稿文件的 Presentation 对象 
 Presentation presentation = new Presentation("Video.pptx");

// Iterates through slides
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


## **常见问题**

**可以为 VideoFrame 更改哪些视频播放参数？**

您可以控制[播放模式](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)（自动或点击时）和[循环](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

是的。嵌入本地视频时，二进制数据会被包含在文档中，导致演示文稿的大小按文件大小比例增加。添加在线视频时，只会嵌入链接和缩略图，因而大小增幅较小。

**我能在不改变位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何不变的情况下替换框架内的[视频内容](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)，这在更新现有布局中的媒体时是常见的做法。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频拥有一个[内容类型](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)，您可以读取并使用，例如在保存到磁盘时。