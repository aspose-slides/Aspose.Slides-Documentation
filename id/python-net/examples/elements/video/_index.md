---
title: Video
type: docs
weight: 80
url: /id/python-net/examples/elements/video/
keywords:
- video
- bingkai video
- menambahkan video
- akses video
- hapus video
- pemutaran video
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan video di Python menggunakan Aspose.Slides: menyisipkan, mengganti, memotong, mengatur bingkai poster dan opsi pemutaran, serta mengekspor presentasi ke PPT, PPTX, dan ODP."
---
Menampilkan cara menyematkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for Python via .NET**.

## **Tambahkan Bingkai Video**

Sisipkan bingkai video kosong ke slide.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan bingkai video.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Bingkai Video**

Ambil bingkai video pertama yang ditambahkan ke slide.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses bingkai video pertama pada slide.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Hapus Bingkai Video**

Hapus bingkai video dari slide.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah bingkai video.
        video_frame = slide.shapes[0]

        # Hapus bingkai video.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis saat slide ditampilkan.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah bingkai video.
        video_frame = slide.shapes[0]

        # Mengonfigurasi video agar diputar secara otomatis.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```