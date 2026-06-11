---
title: Audio
type: docs
weight: 70
url: /pl/python-net/examples/elements/audio/
keywords:
- dźwięk
- ramka audio
- dodaj dźwięk
- uzyskaj dostęp do dźwięku
- usuń dźwięk
- odtwarzanie dźwięku
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Pracuj z dźwiękiem w Pythonie przy użyciu Aspose.Slides: dodawaj, zastępuj, wyodrębniaj i przycinaj dźwięki, ustawiaj głośność i odtwarzanie dla slajdów i kształtów w PowerPoint i OpenDocument."
---
Ilustruje, jak osadzać ramki audio i sterować odtwarzaniem przy użyciu **Aspose.Slides for Python via .NET**. Poniższe przykłady pokazują podstawowe operacje audio.

## **Dodaj ramkę audio**

Poniższy przykład kodu dodaje ramkę audio na slajdzie prezentacji.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do ramki audio**

Ten kod pobiera pierwszą ramkę audio ze slajdu.

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

## **Usuń ramkę audio**

Usuń wcześniej dodaną ramkę audio.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest AudioFrame.
        audio_frame = slide.shapes[0]

        # Usuń ramkę audio.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw odtwarzanie audio**

Skonfiguruj ramkę audio, aby odtwarzała się automatycznie, gdy slajd się pojawi.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest AudioFrame.
        audio_frame = slide.shapes[0]

        # Odtwarzaj automatycznie, gdy slajd się pojawi.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```