---
title: Âm thanh
type: docs
weight: 70
url: /vi/net/examples/elements/audio/
keywords:
- âm thanh
- khung âm thanh
- thêm âm thanh
- truy cập âm thanh
- xóa âm thanh
- phát lại âm thanh
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá các ví dụ âm thanh của Aspose.Slides for .NET: chèn, phát, cắt và trích xuất âm thanh trong các bản trình bày PPT, PPTX và ODP với mã C# rõ ràng."
---
Bài viết này trình bày cách nhúng khung âm thanh và kiểm soát việc phát lại với **Aspose.Slides for .NET**. Các ví dụ sau minh họa các thao tác âm thanh cơ bản.

## **Thêm khung âm thanh**

Chèn một khung âm thanh trống mà sau này có thể chứa dữ liệu âm thanh được nhúng.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tạo một khung âm thanh trống (âm thanh sẽ được nhúng sau).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Truy cập khung âm thanh**

Đoạn mã này lấy khung âm thanh đầu tiên trên một slide.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Truy cập khung âm thanh đầu tiên trên slide.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Xóa khung âm thanh**

Xóa một khung âm thanh đã được thêm trước đó.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Xóa khung âm thanh.
    slide.Shapes.Remove(audioFrame);
}
```

## **Đặt chế độ phát âm thanh**

Đặt cấu hình cho khung âm thanh để tự động phát khi slide xuất hiện.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Phát tự động khi slide xuất hiện.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```