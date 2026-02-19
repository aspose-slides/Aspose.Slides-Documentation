---
title: オーディオ
type: docs
weight: 70
url: /ja/cpp/examples/elements/audio/
keywords:
- コード例
- オーディオ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のオーディオ例を発見しましょう：PPT、PPTX、ODP プレゼンテーションでサウンドの挿入、再生、トリミング、抽出を、明確な C++ コードで実装できます。"
---
本記事では、**Aspose.Slides for C++** を使用してオーディオ フレームを埋め込み、再生を制御する方法を示します。以下の例では、基本的なオーディオ操作を紹介します。

## **オーディオ フレームの追加**

後で埋め込みサウンド データを保持できる空のオーディオ フレームを挿入します。

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 空のオーディオ フレームを作成します（後でオーディオが埋め込まれます）。
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **オーディオ フレームへのアクセス**

このコードは、スライド上の最初のオーディオ フレームを取得します。

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // スライド上の最初のオーディオ フレームにアクセスします。
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **オーディオ フレームの削除**

以前に追加したオーディオ フレームを削除します。

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // オーディオ フレームを削除します。
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **オーディオ 再生の設定**

スライドが表示されたときに自動的に再生されるように、オーディオ フレームを設定します。

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // スライドが表示されたときに自動的に再生します。
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```