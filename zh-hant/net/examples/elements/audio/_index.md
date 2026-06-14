---
title: 音訊
type: docs
weight: 70
url: /zh-hant/net/examples/elements/audio/
keywords:
- 音訊
- 音訊框架
- 新增音訊
- 存取音訊
- 移除音訊
- 音訊播放
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的音訊範例：在 PPT、PPTX 和 ODP 簡報中插入、播放、剪輯及擷取聲音，並提供清晰的 C# 程式碼。"
---
本文示範如何使用 **Aspose.Slides for .NET** 嵌入音訊框架並控制播放。以下範例展示基本的音訊操作。

## **新增音訊框架**

插入一個空的音訊框架，之後可容納嵌入的聲音資料。

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 建立一個空的音訊框架（音訊將稍後嵌入）。
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **存取音訊框架**

此程式碼會取得投影片上的第一個音訊框架。

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 存取投影片上的第一個音訊框架。
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **移除音訊框架**

刪除先前加入的音訊框架。

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 移除音訊框架。
    slide.Shapes.Remove(audioFrame);
}
```

## **設定音訊播放**

設定音訊框架於投影片顯示時自動播放。

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 在投影片出現時自動播放。
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```