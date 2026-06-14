---
title: 影片
type: docs
weight: 80
url: /zh-hant/cpp/examples/elements/video/
keywords:
- 程式碼範例
- 影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 新增與控制影片：插入、播放、剪輯、設定海報框架，並提供用於 PPT、PPTX 與 ODP 簡報的 C++ 範例以匯出。"
---
本文說明如何使用 **Aspose.Slides for C++** 嵌入影片框架並設定播放選項。

## **新增影片框架**

在投影片上插入一個空的影片框架。

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 新增影片。
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **存取影片框架**

取得已新增至投影片的第一個影片框架。

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 存取投影片上的第一個影片框架。
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

## **移除影片框架**

從投影片中刪除影片框架。

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 移除影片框架。
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **設定影片播放**

設定影片在投影片顯示時自動播放。

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 設定影片自動播放。
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```