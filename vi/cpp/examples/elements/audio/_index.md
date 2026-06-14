---
title: Âm thanh
type: docs
weight: 70
url: /vi/cpp/examples/elements/audio/
keywords:
- ví dụ mã
- âm thanh
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá các ví dụ âm thanh của Aspose.Slides for C++: chèn, phát, cắt và trích xuất âm thanh trong các bản trình chiếu PPT, PPTX và ODP với mã C++ rõ ràng."
---
Bài viết này trình bày cách nhúng khung âm thanh và điều khiển việc phát lại với **Aspose.Slides for C++**. Các ví dụ sau đây minh họa các thao tác âm thanh cơ bản.

## **Thêm một khung âm thanh**
Chèn một khung âm thanh trống có thể sau này chứa dữ liệu âm thanh nhúng.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tạo một khung âm thanh trống (âm thanh sẽ được nhúng sau này).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Truy cập một khung âm thanh**
Mã này lấy khung âm thanh đầu tiên trên một slide.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Truy cập khung âm thanh đầu tiên trên slide.
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

## **Xóa một khung âm thanh**
Xóa một khung âm thanh đã được thêm trước đó.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Xóa khung âm thanh.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Cài đặt phát lại âm thanh**
Cấu hình khung âm thanh để tự động phát khi slide xuất hiện.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Tự động phát khi slide xuất hiện.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```