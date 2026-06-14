---
title: 影片
type: docs
weight: 80
url: /zh-hant/net/examples/elements/video/
keywords:
- 影片
- 影片框
- 新增影片
- 存取影片
- 移除影片
- 影片播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 新增與控制影片：插入、播放、剪輯、設定海報框，並提供 C# 範例以匯出 PPT、PPTX 與 ODP 簡報。"
---
此文章示範如何使用 **Aspose.Slides for .NET** 嵌入影片框並設定播放選項。

## **新增影片框**

在投影片上插入一個空的影片框。

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 新增影片。
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **存取影片框**

取得已新增至投影片的第一個影片框。

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 存取投影片上的第一個影片框。
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **移除影片框**

從投影片中刪除影片框。

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 移除影片框。
    slide.Shapes.Remove(videoFrame);
}
```

## **設定影片播放**

設定影片在投影片顯示時自動播放。

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 設定影片自動播放。
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```