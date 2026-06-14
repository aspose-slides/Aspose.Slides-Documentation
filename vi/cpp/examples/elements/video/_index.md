---
title: Video
type: docs
weight: 80
url: /vi/cpp/examples/elements/video/
keywords:
- ví dụ mã
- video
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Thêm và kiểm soát video bằng Aspose.Slides cho C++: chèn, phát, cắt, đặt khung poster, và xuất với các ví dụ C++ cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for C++**.

## **Thêm khung video**

Chèn một khung video trống vào một slide.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Thêm một video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Truy cập khung video**

Lấy khung video đầu tiên được thêm vào slide.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Truy cập khung video đầu tiên trên slide.
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

## **Xóa khung video**

Xóa một khung video khỏi slide.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Xóa khung video.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Thiết lập phát video**

Cấu hình video để phát tự động khi slide được hiển thị.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Cấu hình video để phát tự động.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```