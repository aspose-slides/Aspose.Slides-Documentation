---
title: オーディオ
type: docs
weight: 70
url: /ja/net/examples/elements/audio/
keywords:
- 音声サンプル
- 音声フレーム
- 音声の追加
- 音声へのアクセス
- 音声の削除
- 音声再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で音声を操作します：音声の追加、置換、抽出、トリミング、PowerPoint および OpenDocument のスライドやシェイプの音量と再生設定を行います。"
---

**Aspose.Slides for .NET** を使用して音声フレームを埋め込み、再生を制御する方法を示します。以下の例は基本的な音声操作を示しています。

## 音声フレームを追加

後で埋め込み音声データを保持できる空の音声フレームを挿入します。
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 空のオーディオフレームを作成します（後で音声が埋め込まれます）
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## 音声フレームにアクセス

このコードはスライド上の最初の音声フレームを取得します。
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライド上の最初の音声フレームにアクセス
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## 音声フレームの削除

以前に追加した音声フレームを削除します。
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // オーディオフレームを削除
    slide.Shapes.Remove(audioFrame);
}
```


## 音声再生の設定

スライドが表示されたときに音声フレームが自動的に再生されるように設定します。
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライドが表示されたときに自動的に再生
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
