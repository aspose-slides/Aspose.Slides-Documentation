---
title: ビデオ
type: docs
weight: 80
url: /ja/net/examples/elements/video/
keywords:
- ビデオ例
- ビデオフレーム
- ビデオの追加
- ビデオの取得
- ビデオの削除
- ビデオ再生
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# でビデオを操作します：挿入、置換、トリミング、ポスターフレームと再生オプションの設定、そして PPT、PPTX、ODP 用にプレゼンテーションをエクスポートします。"
---

**Aspose.Slides for .NET** を使用して、ビデオフレームを埋め込み、再生オプションを設定する方法を示します。

## **Add a Video Frame**
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


## **Access a Video Frame**
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


## **Remove a Video Frame**
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


## **Set Video Playback**
スライドが表示されたときにビデオが自動的に再生されるように設定します。
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ビデオを自動的に再生するように設定
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
