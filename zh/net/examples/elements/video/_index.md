---
title: 视频
type: docs
weight: 80
url: /zh/net/examples/elements/video/
keywords:
- 视频示例
- 视频帧
- 添加视频
- 访问视频
- 删除视频
- 视频播放
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理视频：插入、替换、裁剪、设置海报帧和播放选项，并将演示文稿导出为 PPT、PPTX 和 ODP。"
---

展示如何嵌入视频帧并使用 **Aspose.Slides for .NET** 设置播放选项。

## **添加视频帧**
在幻灯片上插入一个空的视频帧。
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 添加一个空的嵌入式视频帧
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## **访问视频帧**
检索添加到幻灯片的第一个视频帧。
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 访问幻灯片上的第一个视频帧
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## **删除视频帧**
从幻灯片中删除视频帧。
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 删除视频帧
    slide.Shapes.Remove(videoFrame);
}
```


## **设置视频播放**
配置视频，使其在显示幻灯片时自动播放。
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 配置视频自动播放
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
