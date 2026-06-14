---
title: 音訊
type: docs
weight: 70
url: /zh-hant/cpp/examples/elements/audio/
keywords:
- 程式碼範例
- 音訊
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 的音訊範例：在 PPT、PPTX 與 ODP 簡報中插入、播放、剪裁與擷取聲音，並提供清晰的 C++ 程式碼。"
---
本文示範如何使用 **Aspose.Slides for C++** 嵌入音訊框架並控制播放。以下範例展示基本的音訊操作。

## **加入音訊框架**

插入一個空的音訊框架，以便之後儲存嵌入的聲音資料。

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 建立一個空的音訊框架（音訊稍後將被嵌入）。
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **存取音訊框架**

此程式碼會取得投影片上的第一個音訊框架。

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 存取投影片上的第一個音訊框架。
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

## **移除音訊框架**

刪除先前加入的音訊框架。

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 移除音訊框架。
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **設定音訊播放**

設定音訊框架，使其在投影片出現時自動播放。

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 投影片出現時自動播放。
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```