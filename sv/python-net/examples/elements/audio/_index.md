---
title: Ljud
type: docs
weight: 70
url: /sv/python-net/examples/elements/audio/
keywords:
- ljud
- ljudram
- lägg till ljud
- åtkomst till ljud
- ta bort ljud
- ljuduppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med ljud i Python med hjälp av Aspose.Slides: lägg till, ersätt, extrahera och trimma ljud, ställ in volym och uppspelning för bilder och former i PowerPoint och OpenDocument."
---
Visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for Python via .NET**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Kodexemplet nedan lägger till en ljudram på en presentationsbild.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en ljudram**

Denna kod hämtar den första ljudramen från bilden.

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

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en AudioFrame.
        audio_frame = slide.shapes[0]

        # Ta bort ljudramen.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en AudioFrame.
        audio_frame = slide.shapes[0]

        # Spela automatiskt när bilden visas.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```