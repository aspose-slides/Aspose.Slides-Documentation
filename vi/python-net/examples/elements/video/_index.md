---
title: Video
type: docs
weight: 80
url: /vi/python-net/examples/elements/video/
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
- Python
- Aspose.Slides
description: "Làm việc với video trong Python bằng Aspose.Slides: chèn, thay thế, cắt, thiết lập khung poster và các tùy chọn phát lại, và xuất bản trình chiếu sang PPT, PPTX và ODP."
---
Hiển thị cách nhúng khung video và thiết lập các tùy chọn phát lại bằng **Aspose.Slides for Python via .NET**.

## **Thêm một Khung Video**
Chèn một khung video trống vào slide.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một khung video.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Khung Video**
Lấy khung video đầu tiên được thêm vào slide.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập khung video đầu tiên trên slide.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Xóa Khung Video**
Xóa một khung video khỏi slide.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một khung video.
        video_frame = slide.shapes[0]

        # Xóa khung video.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Thiết lập Phát Video**
Cấu hình video để tự động phát khi slide được hiển thị.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một khung video.
        video_frame = slide.shapes[0]

        # Cấu hình video để tự động phát.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```