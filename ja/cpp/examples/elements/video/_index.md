---
title: ビデオ
type: docs
weight: 80
url: /ja/cpp/examples/elements/video/
keywords:
- コード例
- ビデオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してビデオを追加および制御します。挿入、再生、トリミング、ポスターフレームの設定、そして PPT、PPTX、ODP プレゼンテーション向けの C++ サンプルでエクスポートできます。"
---
この記事では、**Aspose.Slides for C++** を使用してビデオ フレームを埋め込み、再生オプションを設定する方法を示します。

## **ビデオ フレームを追加**

スライドに空のビデオ フレームを挿入します。

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // ビデオを追加します。
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **ビデオ フレームにアクセス**

スライドに追加された最初のビデオ フレームを取得します。

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // スライド上の最初のビデオ フレームにアクセスします。
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ビデオ フレームの削除**

スライドからビデオ フレームを削除します。

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // ビデオ フレームを削除します。
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **ビデオ 再生の設定**

スライドが表示されるときにビデオが自動的に再生されるように設定します。

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // ビデオを自動再生するように設定します。
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```