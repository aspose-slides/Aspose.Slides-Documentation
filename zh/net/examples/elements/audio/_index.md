---
title: 音频
type: docs
weight: 70
url: /zh/net/examples/elements/audio/
keywords:
- 音频示例
- 音频帧
- 添加音频
- 访问音频
- 删除音频
- 音频播放
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 C# 中处理音频：添加、替换、提取和剪裁声音，为 PowerPoint 和 OpenDocument 中的幻灯片和形状设置音量和播放。"
---

演示如何使用 **Aspose.Slides for .NET** 嵌入音频帧并控制播放。以下示例展示了基本的音频操作。

## 添加音频帧

插入一个空的音频帧，以便以后可以容纳嵌入的音频数据。
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 创建一个空的音频帧（音频将在稍后嵌入）
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## 访问音频帧

此代码检索幻灯片上的第一个音频帧。
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 访问幻灯片上的第一个音频帧
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## 删除音频帧

删除先前添加的音频帧。
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 删除音频帧
    slide.Shapes.Remove(audioFrame);
}
```


## 设置音频播放

将音频帧配置为在幻灯片出现时自动播放。
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 当幻灯片出现时自动播放
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
