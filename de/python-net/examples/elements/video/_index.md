---
title: Video
type: docs
weight: 80
url: /de/python-net/examples/elements/video/
keywords:
- Video
- Video-Frame
- Video hinzufügen
- Video abrufen
- Video entfernen
- Video-Wiedergabe
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit Video in Python mittels Aspose.Slides: Einfügen, Ersetzen, Trimmen, Festlegen von Poster-Frames und Wiedergabeoptionen sowie Exportieren von Präsentationen für PPT, PPTX und ODP."
---
Zeigt, wie man Video‑Frames einbettet und Wiedergabeoptionen mit **Aspose.Slides for Python via .NET** festlegt.

## **Video‑Frame hinzufügen**

Fügen Sie einen leeren Video‑Frame zu einer Folie hinzu.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Video-Frame hinzufügen.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf einen Video‑Frame**

Rufen Sie den zuerst zu einer Folie hinzugefügten Video‑Frame ab.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Zugriff auf den ersten Video-Frame auf der Folie.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **Video‑Frame entfernen**

Löschen Sie einen Video‑Frame von der Folie.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein Video-Frame.
        video_frame = slide.shapes[0]

        # Video-Frame entfernen.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Video‑Wiedergabe festlegen**

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein Video-Frame.
        video_frame = slide.shapes[0]

        # Konfigurieren Sie das Video so, dass es automatisch abgespielt wird.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```