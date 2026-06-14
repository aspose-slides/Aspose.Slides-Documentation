---
title: Video
type: docs
weight: 80
url: /vi/net/examples/elements/video/
keywords:
- video
- khung video
- thêm video
- truy cập video
- xóa video
- phát lại video
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thêm và điều khiển video bằng Aspose.Slides for .NET: chèn, phát, cắt, thiết lập khung poster, và xuất với các ví dụ C# cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for .NET**.

## **Thêm khung video**

Chèn một khung video trống vào một slide.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Thêm video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Truy cập khung video**

Lấy khung video đầu tiên được thêm vào slide.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Truy cập khung video đầu tiên trên slide.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Xóa khung video**

Xóa khung video khỏi slide.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Xóa khung video.
    slide.Shapes.Remove(videoFrame);
}
```

## **Cài đặt phát video**

Cấu hình video để tự động phát khi slide được hiển thị.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Cấu hình video để tự động phát.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```