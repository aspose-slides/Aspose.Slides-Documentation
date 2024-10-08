---
title: 视频帧
type: docs
weight: 10
url: /net/video-frame/
keywords: "添加视频，创建视频帧，提取视频，PowerPoint演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "在C#或.NET中向PowerPoint演示文稿添加视频帧"
---

在演示文稿中适当地放置视频可以使您的信息更具吸引力，并提高与观众的互动水平。

PowerPoint允许您通过两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自网络来源，如YouTube）。

为了让您可以向演示文稿中添加视频（视频对象），Aspose.Slides提供了[IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)接口、[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您想要添加到幻灯片的视频文件存储在本地，您可以创建一个视频帧将视频嵌入到您的演示文稿中。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加[IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)对象，并传递视频文件路径以将视频与演示文稿嵌入。
1. 添加[IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)对象以创建视频的框架。
1. 保存修改后的演示文稿。

以下C#代码展示了如何将本地存储的视频添加到演示文稿中：

```c#
// Instantiates the Presentation class
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Loads the video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Gets the first slide and adds a videoframe
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Saves the presentation to disk
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
另外，您也可以通过直接将文件路径传递给[AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)方法来添加视频：

```csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **从网络来源创建视频帧**
Microsoft [PowerPoint 2013及更新版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支持在演示文稿中使用YouTube视频。如果您想要使用的视频在线可用（例如在YouTube上），您可以通过其网页链接将其添加到演示文稿中。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加[IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/)对象并传递视频链接。
1. 设置视频帧的缩略图。
1. 保存演示文稿。

以下C#代码展示了如何将网络视频添加到PowerPoint演示文稿的幻灯片中：

```c#
public static void Run()
{
    // Instantiates a Presentation object that represents a presentation file 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Adds a VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Loads thumbnail
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **从幻灯片中提取视频**
除了向幻灯片添加视频，Aspose.Slides还允许您提取嵌入在演示文稿中的视频。

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例以加载包含视频的演示文稿。
2. 遍历所有[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)对象。
3. 遍历所有[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)对象以查找[VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe)。
4. 将视频保存到磁盘。

以下C#代码展示了如何从演示文稿幻灯片中提取视频：

```c#
// Instantiates a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("Video.pptx");

// Iterates through slides
foreach (ISlide slide in presentation.Slides)
{
    // Iterates through shapes
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Saves video to disk once VideoFrame containing video is found
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