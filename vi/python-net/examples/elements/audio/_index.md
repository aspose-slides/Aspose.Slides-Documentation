---
title: Âm thanh
type: docs
weight: 70
url: /vi/python-net/examples/elements/audio/
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
- Python
- Aspose.Slides
description: "Làm việc với âm thanh trong Python bằng Aspose.Slides: thêm, thay thế, trích xuất và cắt ghép âm thanh, đặt âm lượng và phát lại cho các slide và hình dạng trong PowerPoint và OpenDocument."
---
Mô tả cách nhúng khung âm thanh và điều khiển phát lại với **Aspose.Slides for Python via .NET**. Các ví dụ dưới đây minh họa các thao tác âm thanh cơ bản.

## **Thêm khung âm thanh**

Ví dụ mã dưới đây thêm một khung âm thanh vào slide trình chiếu.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập khung âm thanh**

Mã này truy xuất khung âm thanh đầu tiên từ slide.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Xóa khung âm thanh**

Xóa một khung âm thanh đã được thêm trước đó.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một AudioFrame.
        audio_frame = slide.shapes[0]

        # Xóa khung âm thanh.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cài đặt phát lại âm thanh**

Cấu hình khung âm thanh để tự động phát khi slide xuất hiện.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một AudioFrame.
        audio_frame = slide.shapes[0]

        # Phát tự động khi slide xuất hiện.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```