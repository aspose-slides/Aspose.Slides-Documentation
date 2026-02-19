---
title: 视频
type: docs
weight: 80
url: /zh/net/examples/elements/video/
keywords:
- 视频
- 视频帧
- 添加视频
- 访问视频
- 删除视频
- 视频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 添加和控制视频：插入、播放、剪辑、设置海报帧，并提供 C# 示例以导出 PPT、PPTX 和 ODP 演示文稿。"
---
本文演示如何使用 **Aspose.Slides for .NET** 嵌入视频帧并设置播放选项。

## **添加视频帧**

在幻灯片上插入一个空的视频帧。

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 添加视频。
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 访问幻灯片上的第一个视频帧。
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **删除视频帧**

从幻灯片中删除视频帧。

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 删除视频帧。
    slide.Shapes.Remove(videoFrame);
}
```

## **设置视频播放**

配置视频，使其在幻灯片显示时自动播放。

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 配置视频自动播放。
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```