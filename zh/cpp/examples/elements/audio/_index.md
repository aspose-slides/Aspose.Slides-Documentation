---
title: 音频
type: docs
weight: 70
url: /zh/cpp/examples/elements/audio/
keywords:
- 代码示例
- 音频
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "发现 Aspose.Slides for C++ 音频示例：在 PPT、PPTX 和 ODP 演示文稿中插入、播放、修剪和提取声音，提供清晰的 C++ 代码。"
---
本文演示如何使用 **Aspose.Slides for C++** 嵌入音频帧并控制播放。下面的示例展示了基本的音频操作。

## **添加音频帧**

插入一个空的音频帧，以便以后容纳嵌入的音频数据。

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 创建一个空的音频帧（音频将在稍后嵌入）。
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **访问音频帧**

此代码检索幻灯片上的第一个音频帧。

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 访问幻灯片上的第一个音频帧。
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

## **移除音频帧**

删除之前添加的音频帧。

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 删除音频帧。
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **设置音频播放**

配置音频帧，使其在幻灯片出现时自动播放。

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 幻灯片出现时自动播放。
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```