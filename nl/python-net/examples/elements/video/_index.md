---
title: Video
type: docs
weight: 80
url: /nl/python-net/examples/elements/video/
keywords:
- video
- videoframe
- video toevoegen
- video openen
- video verwijderen
- videoweergave
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met video in Python met Aspose.Slides: invoegen, vervangen, bijsnijden, posterframes instellen en afspeelopties, en exporteer presentaties naar PPT, PPTX en ODP."
---
Toont hoe videoframes in te sluiten en afspeelopties in te stellen met **Aspose.Slides for Python via .NET**.

## **Videoframe toevoegen**

Voeg een leeg videoframe toe aan een dia.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een videoframe toe.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een videoframe**

Haal het eerste toegevoegde videoframe op van een dia.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot het eerste videoframe op de dia.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Videoframe verwijderen**

Verwijder een videoframe van de dia.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een videoframe is.
        video_frame = slide.shapes[0]

        # Verwijder het videoframe.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Videoweergave instellen**

Stel de video in om automatisch af te spelen wanneer de dia wordt weergegeven.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemende dat de eerste vorm een videoframe is.
        video_frame = slide.shapes[0]

        # Configureren zodat de video automatisch afspeelt.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```