---
title: 音频
type: docs
weight: 70
url: /zh/net/examples/elements/audio/
keywords:
- 音频
- 音频帧
- 添加音频
- 访问音频
- 删除音频
- 音频播放
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的音频示例：在 PPT、PPTX 和 ODP 演示文稿中插入、播放、裁剪和提取音频，附带清晰的 C# 代码。"
---
本文演示如何嵌入音频帧并使用 **Aspose.Slides for .NET** 控制播放。以下示例展示基本的音频操作。

## **Add an Audio Frame**
插入一个空的音频帧，以便稍后容纳嵌入的声音数据。

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 创建一个空的音频帧（音频将在稍后嵌入）。
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Access an Audio Frame**
此代码检索幻灯片上的第一个音频帧。

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 访问幻灯片上的第一个音频帧。
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Remove an Audio Frame**
删除先前添加的音频帧。

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 删除音频帧。
    slide.Shapes.Remove(audioFrame);
}
```

## **Set Audio Playback**
配置音频帧，使其在幻灯片出现时自动播放。

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 幻灯片出现时自动播放。
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```