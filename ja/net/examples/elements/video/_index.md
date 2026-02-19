---
title: ビデオ
type: docs
weight: 80
url: /ja/net/examples/elements/video/
keywords:
- ビデオ
- ビデオ フレーム
- ビデオの追加
- ビデオへのアクセス
- ビデオの削除
- ビデオ再生
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してビデオを追加および制御します。挿入、再生、トリミング、ポスター フレームの設定、そして PPT、PPTX、ODP プレゼンテーション用の C# サンプルでエクスポートできます。"
---
この記事では、**Aspose.Slides for .NET** を使用してビデオ フレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオ フレームの追加**

スライドに空のビデオ フレームを挿入します。

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // ビデオを追加します。
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **ビデオ フレームへのアクセス**

スライドに追加された最初のビデオ フレームを取得します。

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // スライド上の最初のビデオ フレームにアクセスします。
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **ビデオ フレームの削除**

スライドからビデオ フレームを削除します。

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ビデオ フレームを削除します。
    slide.Shapes.Remove(videoFrame);
}
```

## **ビデオの再生設定**

スライドが表示されたときにビデオが自動的に再生されるように設定します。

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ビデオが自動的に再生されるように設定します。
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```