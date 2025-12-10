---
title: オーディオ
type: docs
weight: 70
url: /ja/net/examples/elements/audio/
keywords:
- オーディオ例
- オーディオ フレーム
- オーディオの追加
- オーディオへのアクセス
- オーディオの削除
- オーディオ再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# で Aspose.Slides を使用してオーディオを操作します。サウンドの追加、置換、抽出、トリミング、音量や再生設定を PowerPoint および OpenDocument のスライドやシェイプに対して行えます。"
---

**Aspose.Slides for .NET** を使用してオーディオ フレームを埋め込み、再生を制御する方法を示します。以下の例は基本的なオーディオ操作を示しています。

## **オーディオ フレームの追加**
後で埋め込みサウンド データを保持できる空のオーディオ フレームを挿入します。
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 空のオーディオ フレームを作成します（後でオーディオが埋め込まれます）
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## **オーディオ フレームへのアクセス**
このコードはスライド上の最初のオーディオ フレームを取得します。
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライド上の最初のオーディオフレームにアクセスする
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## **オーディオ フレームの削除**
以前に追加されたオーディオ フレームを削除します。
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // オーディオフレームを削除する
    slide.Shapes.Remove(audioFrame);
}
```


## **オーディオ 再生の設定**
スライドが表示されたときにオーディオ フレームが自動的に再生されるように構成します。
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // スライドが表示されたときに自動的に再生する
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
