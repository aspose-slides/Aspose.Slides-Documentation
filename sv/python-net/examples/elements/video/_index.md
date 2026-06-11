---
title: Video
type: docs
weight: 80
url: /sv/python-net/examples/elements/video/
keywords:
- video
- videoram
- lägg till video
- åtkomst till video
- ta bort video
- videouppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med video i Python med Aspose.Slides: infoga, ersätta, trimma, ställa in poster-ramar och uppspelningsalternativ, samt exportera presentationer för PPT, PPTX och ODP."
---
Visar hur man bäddar in video-ramar och ställer in uppspelningsalternativ med **Aspose.Slides for Python via .NET**.

## **Lägg till en videoram**

Infoga en tom videoram på en bild.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en videoram.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till en videoram**

Hämta den första videoramen som lades till på en bild.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första videoramen på bilden.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Ta bort en videoram**

Ta bort en videoram från bilden.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en videoram.
        video_frame = slide.shapes[0]

        # Ta bort videoramen.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in videouppspelning**

Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en videoram.
        video_frame = slide.shapes[0]

        # Konfigurera videon så att den spelas upp automatiskt.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```