---
title: 视频
type: docs
weight: 80
url: /zh/cpp/examples/elements/video/
keywords:
- 代码示例
- 视频
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 添加和控制视频：插入、播放、剪辑、设置海报帧，并通过 C++ 示例导出 PPT、PPTX 和 ODP 演示文稿。"
---
本文演示如何使用 **Aspose.Slides for C++** 嵌入视频帧并设置播放选项。

## **添加视频帧**

在幻灯片上插入一个空的视频帧。

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 添加视频。
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **访问视频帧**

检索添加到幻灯片的第一个视频帧。

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 访问幻灯片上的第一个视频帧。
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

## **删除视频帧**

从幻灯片中删除视频帧。

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 删除视频帧。
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **设置视频播放**

将视频配置为在显示幻灯片时自动播放。

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 配置视频自动播放。
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```