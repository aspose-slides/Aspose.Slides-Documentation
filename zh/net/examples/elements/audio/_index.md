---
title: 音频
type: docs
weight: 70
url: /zh/net/examples/elements/audio/
keywords:
- 音频示例
- 音频框架
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
description: "使用 Aspose.Slides 在 C# 中处理音频：添加、替换、提取和裁剪声音，设置 PowerPoint 和 OpenDocument 中幻灯片和形状的音量和播放方式。"
---

演示如何在 **Aspose.Slides for .NET** 中嵌入音频框架并控制播放。以下示例展示了基本的音频操作。

## **添加音频框架**

插入一个空的音频框架，以便稍后容纳嵌入的声音数据。
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 创建一个空的音频框架（音频将在稍后嵌入）
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## **访问音频框架**

此代码检索幻灯片上的第一个音频框架。
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 访问幻灯片上的第一个音频框架
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## **删除音频框架**

删除之前添加的音频框架。
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 删除音频框架
    slide.Shapes.Remove(audioFrame);
}
```


## **设置音频播放**

配置音频框架，使其在幻灯片出现时自动播放。
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 幻灯片出现时自动播放
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
