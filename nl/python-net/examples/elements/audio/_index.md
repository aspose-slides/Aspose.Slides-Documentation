---
title: Audio
type: docs
weight: 70
url: /nl/python-net/examples/elements/audio/
keywords:
- audio
- audioframe
- audio toevoegen
- audio openen
- audio verwijderen
- audio weergave
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met audio in Python met Aspose.Slides: voeg geluiden toe, vervang, extraheer en knip ze bij, stel het volume en de weergave in voor dia's en vormen in PowerPoint en OpenDocument."
---
Illustreert hoe je audiokaders kunt insluiten en de weergave kunt regelen met **Aspose.Slides for Python via .NET**. De volgende voorbeelden tonen basis‑audio‑bewerkingen.

## **Audioframe toevoegen**

Het onderstaande codevoorbeeld voegt een audioframe toe aan een presentatieslide.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een audioframe**

De code haalt het eerste audioframe van de slide op.

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

## **Audioframe verwijderen**

Verwijder een eerder toegevoegd audioframe.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een AudioFrame is.
        audio_frame = slide.shapes[0]

        # Verwijder het audioframe.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Audioweergave instellen**

Configureer het audioframe om automatisch af te spelen wanneer de slide verschijnt.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een AudioFrame is.
        audio_frame = slide.shapes[0]

        # Automatisch afspelen wanneer de dia verschijnt.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```