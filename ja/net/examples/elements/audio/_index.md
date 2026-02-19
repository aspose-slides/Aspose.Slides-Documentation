---
title: オーディオ
type: docs
weight: 70
url: /ja/net/examples/elements/audio/
keywords:
- オーディオ
- オーディオフレーム
- オーディオを追加
- オーディオへのアクセス
- オーディオの削除
- オーディオ再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のオーディオ サンプルを探る：PPT、PPTX、ODP プレゼンテーションでサウンドを挿入、再生、トリム、抽出する方法を、明快な C# コードで示します。"
---
この記事では、**Aspose.Slides for .NET** を使用して音声フレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的な音声操作をご紹介します。

## **音声フレームの追加**

後で埋め込み音声データを保持できる空の音声フレームを挿入します。

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 空のオーディオフレームを作成します（後で音声が埋め込まれます）。
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **音声フレームへのアクセス**

このコードはスライド上の最初の音声フレームを取得します。

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライド上の最初のオーディオフレームにアクセスします。
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **音声フレームの削除**

以前に追加された音声フレームを削除します。

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // オーディオフレームを削除します。
    slide.Shapes.Remove(audioFrame);
}
```

## **音声再生の設定**

スライドが表示されたときに音声フレームが自動的に再生されるように設定します。

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライドが表示されたときに自動的に再生します。
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```