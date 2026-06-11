---
title: Wideo
type: docs
weight: 80
url: /pl/python-net/examples/elements/video/
keywords:
- wideo
- ramka wideo
- dodaj wideo
- dostęp do wideo
- usuń wideo
- odtwarzanie wideo
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Praca z wideo w Python przy użyciu Aspose.Slides: wstawianie, zamiana, przycinanie, ustawianie klatek plakatu i opcji odtwarzania oraz eksport prezentacji do formatów PPT, PPTX i ODP."
---
Pokaże, jak osadzić ramki wideo i ustawić opcje odtwarzania przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj ramkę wideo**

Wstaw pustą ramkę wideo na slajd.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj ramkę wideo.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest ramką wideo.
        video_frame = slide.shapes[0]

        # Usuń ramkę wideo.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj wideo, aby odtwarzało się automatycznie, gdy slajd zostanie wyświetlony.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest ramką wideo.
        video_frame = slide.shapes[0]

        # Skonfiguruj wideo, aby odtwarzało się automatycznie.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```