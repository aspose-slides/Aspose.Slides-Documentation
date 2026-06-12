---
title: Audio
type: docs
weight: 70
url: /id/python-net/examples/elements/audio/
keywords:
- audio
- frame audio
- tambahkan audio
- akses audio
- hapus audio
- pemutaran audio
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan audio di Python menggunakan Aspose.Slides: menambahkan, mengganti, mengekstrak, dan memotong suara, mengatur volume dan pemutaran untuk slide dan bentuk di PowerPoint dan OpenDocument."
---
Menunjukkan cara menyisipkan frame audio dan mengontrol pemutaran dengan **Aspose.Slides for Python via .NET**. Contoh-contoh berikut menunjukkan operasi audio dasar.

## **Menambahkan Frame Audio**

Contoh kode di bawah ini menambahkan frame audio pada slide presentasi.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Frame Audio**

Kode ini mengambil frame audio pertama dari slide.

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

## **Menghapus Frame Audio**

Hapus frame audio yang sebelumnya ditambahkan.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah AudioFrame.
        audio_frame = slide.shapes[0]

        # Hapus frame audio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Pemutaran Audio**

Konfigurasikan frame audio agar diputar secara otomatis ketika slide muncul.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bahwa bentuk pertama adalah AudioFrame.
        audio_frame = slide.shapes[0]

        # Putar secara otomatis ketika slide muncul.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```