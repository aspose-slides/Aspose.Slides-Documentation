---
title: ビデオ
type: docs
weight: 80
url: /ja/net/examples/elements/video/
keywords:
- ビデオの例
- ビデオフレーム
- ビデオの追加
- ビデオへのアクセス
- ビデオの削除
- ビデオ再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してビデオを操作します：挿入、置換、トリミング、ポスターフレームや再生オプションの設定、そして PPT、PPTX、ODP 用にプレゼンテーションをエクスポートします。"
---

**Aspose.Slides for .NET** を使用してビデオフレームを埋め込み、再生オプションを設定する方法を示します。

## ビデオフレームの追加

スライドに空のビデオフレームを挿入します。
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // 空の埋め込みビデオフレームを追加
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## ビデオフレームへのアクセス

スライドに追加された最初のビデオフレームを取得します。
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // スライド上の最初のビデオフレームにアクセス
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## ビデオフレームの削除

スライドからビデオフレームを削除します。
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ビデオフレームを削除
    slide.Shapes.Remove(videoFrame);
}
```


## ビデオ再生の設定

スライドが表示されたときにビデオが自動的に再生されるように設定します。
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ビデオを自動再生するように設定
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
